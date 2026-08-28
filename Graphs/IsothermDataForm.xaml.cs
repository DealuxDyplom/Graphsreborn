using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    public partial class IsothermDataForm : Window
    {
        private readonly MainWindow parent;
        private readonly IsothermSeries original;
        private readonly ObservableCollection<IsothermPoint> points;
        private ChartArea chartArea;
        private Series graphLine;
        private Series graphPoints;
        private int draggedPointIndex = -1;
        private bool isDraggingPoint;

        public IsothermDataForm(MainWindow owner, IsothermSeries existing = null)
        {
            parent = owner;
            original = existing;
            InitializeComponent();

            points = new ObservableCollection<IsothermPoint>();
            if (existing != null)
            {
                TextBox_Name.Text = existing.name;
                TextBox_Temperature.Text = existing.temperatureC.ToString("G", CultureInfo.CurrentCulture);
                foreach (var point in existing.data ?? Enumerable.Empty<IsothermPoint>())
                    points.Add(new IsothermPoint { Ce = point.Ce, Qe = point.Qe });
            }
            DataGrid_Points.ItemsSource = points;
            BuildChart();
        }

        private void BuildChart()
        {
            Graph_Isotherm.Series.Clear();
            Graph_Isotherm.ChartAreas.Clear();
            Graph_Isotherm.Legends.Clear();

            chartArea = new ChartArea();
            chartArea.AxisX.Title = "Ce, мкмоль/л";
            chartArea.AxisY.Title = "qe, мкмоль/г";
            chartArea.AxisX.IsStartedFromZero = true;
            chartArea.AxisY.IsStartedFromZero = true;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea.AxisX.LabelStyle.Format = "0.#####";
            chartArea.AxisY.LabelStyle.Format = "0.#####";
            Graph_Isotherm.ChartAreas.Add(chartArea);
            Graph_Isotherm.Legends.Add(new Legend());

            graphLine = new Series("Изотерма")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3,
                Color = System.Drawing.Color.SeaGreen
            };
            graphLine.SetCustomProperty("LineTension", "0.2");

            graphPoints = new Series("Экспериментальные точки")
            {
                ChartType = SeriesChartType.Point,
                Color = System.Drawing.Color.SeaGreen,
                MarkerSize = 10,
                MarkerStyle = MarkerStyle.Circle,
                MarkerBorderColor = System.Drawing.Color.Black
            };

            foreach (var point in points.Where(IsValidPoint).OrderBy(point => point.Ce))
            {
                graphLine.Points.AddXY(point.Ce, point.Qe);
                graphPoints.Points.AddXY(point.Ce, point.Qe);
            }

            Graph_Isotherm.Series.Add(graphLine);
            Graph_Isotherm.Series.Add(graphPoints);
            Graph_Isotherm.Invalidate();
        }

        private static bool IsValidPoint(IsothermPoint point)
        {
            return IsFinite(point.Ce) && IsFinite(point.Qe) && point.Ce > 0 && point.Qe > 0;
        }

        private void Graph_Isotherm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HitTestResult hit = Graph_Isotherm.HitTest(e.X, e.Y);
            if (hit.Series != graphPoints || hit.PointIndex < 0) return;

            draggedPointIndex = hit.PointIndex;
            graphPoints.Points[draggedPointIndex].MarkerBorderColor = System.Drawing.Color.Gold;
            isDraggingPoint = true;
        }

        private void Graph_Isotherm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!isDraggingPoint || draggedPointIndex < 0) return;

            double qe;
            try
            {
                qe = Math.Max(0.00001, chartArea.AxisY.PixelPositionToValue(e.Y));
            }
            catch (ArgumentException)
            {
                return;
            }

            graphPoints.Points[draggedPointIndex].YValues[0] = qe;
            graphLine.Points[draggedPointIndex].YValues[0] = qe;
            Graph_Isotherm.Invalidate();
        }

        private void Graph_Isotherm_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!isDraggingPoint || draggedPointIndex < 0) return;

            IsothermPoint editedPoint = points
                .Where(IsValidPoint)
                .OrderBy(point => point.Ce)
                .ElementAtOrDefault(draggedPointIndex);
            if (editedPoint != null)
                editedPoint.Qe = graphPoints.Points[draggedPointIndex].YValues[0];

            foreach (DataPoint point in graphPoints.Points)
                point.MarkerBorderColor = System.Drawing.Color.Black;

            draggedPointIndex = -1;
            isDraggingPoint = false;
            DataGrid_Points.Items.Refresh();
        }

        private void DataGrid_Points_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(BuildChart));
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_Points.CommitEdit(DataGridEditingUnit.Cell, true);
            DataGrid_Points.CommitEdit(DataGridEditingUnit.Row, true);

            string name = TextBox_Name.Text.Trim();
            if (name.Length == 0)
            {
                ShowError("Введите название образца.");
                return;
            }

            double temperature;
            if (!TryParseNumber(TextBox_Temperature.Text, out temperature))
            {
                ShowError("Температура должна быть числом.");
                return;
            }

            if (points.Any(point => (point.Ce > 0 && point.Qe <= 0)
                || (point.Qe > 0 && point.Ce <= 0)))
            {
                ShowError("В каждой строке одновременно укажите положительные Ce и qe.");
                return;
            }

            var validPoints = points
                .Where(point => IsFinite(point.Ce) && IsFinite(point.Qe)
                    && point.Ce > 0 && point.Qe > 0)
                .OrderBy(point => point.Ce)
                .Select(point => new IsothermPoint { Ce = point.Ce, Qe = point.Qe })
                .ToList();
            if (validPoints.Count < 3)
            {
                ShowError("Для изотермы необходимо не менее трёх корректных точек Ce–qe.");
                return;
            }

            bool duplicate = Databank.isotherms.Any(item =>
                !ReferenceEquals(item, original)
                && string.Equals(item.name, name, StringComparison.CurrentCultureIgnoreCase));
            if (duplicate)
            {
                ShowError("Изотерма с таким названием уже существует.");
                return;
            }

            IsothermSeries target = original ?? new IsothermSeries();
            target.name = name;
            target.temperatureC = temperature;
            target.concentrationUnit = "мкмоль/л";
            target.capacityUnit = "мкмоль/г";
            target.data = validPoints;
            target.langmuir = null;
            if (original == null) Databank.isotherms.Add(target);

            parent.SelectIsotherm(name);
            Close();
        }

        private static bool TryParseNumber(string text, out double value)
        {
            return double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value)
                || double.TryParse(text.Replace(',', '.'), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out value);
        }

        private static bool IsFinite(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Данные изотермы", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.RefreshCurrentModeView();
            parent.Show();
        }
    }
}
