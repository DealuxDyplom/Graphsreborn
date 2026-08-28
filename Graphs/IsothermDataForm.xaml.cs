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
        private readonly ObservableCollection<IsothermPoint> points = new ObservableCollection<IsothermPoint>();
        private IsothermSeries currentSeries;
        private ChartArea chartArea;
        private Series graphLine;
        private Series graphPoints;
        private int draggedPointIndex = -1;
        private bool isDraggingPoint;

        public IsothermDataForm(MainWindow owner, IsothermSeries selected = null)
        {
            parent = owner;
            InitializeComponent();
            DataGrid_Points.ItemsSource = points;
            foreach (IsothermSeries series in Databank.isotherms)
                ComboBox_Isotherm.Items.Add(series.name);
            if (ComboBox_Isotherm.Items.Count > 0)
            {
                int index = selected == null ? 0 : Databank.isotherms.IndexOf(selected);
                ComboBox_Isotherm.SelectedIndex = Math.Max(0, index);
            }
        }

        private void ComboBox_Isotherm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentSeries = Databank.isotherms.FirstOrDefault(item =>
                item.name == ComboBox_Isotherm.SelectedItem as string);
            points.Clear();
            if (currentSeries == null) return;
            foreach (IsothermPoint point in currentSeries.data ?? Enumerable.Empty<IsothermPoint>())
                points.Add(IsothermCalculator.Clone(point));
            TextBlock_Parameters.Text = string.Format(CultureInfo.CurrentCulture,
                "T = {0:0.##} °C   V = {1:0.##} мл   M = {2:0.##} г/моль   k = {3:0.#####}",
                currentSeries.temperatureC, currentSeries.solutionVolumeMl,
                currentSeries.molarMassGPerMol, currentSeries.calibrationK);
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
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisX.LabelStyle.Format = "0.#####";
            chartArea.AxisY.LabelStyle.Format = "0.#####";
            Graph_Isotherm.ChartAreas.Add(chartArea);
            Graph_Isotherm.Legends.Add(new Legend());

            System.Drawing.Color color = parent.GetSeriesColor(currentSeries == null ? "Изотерма" : currentSeries.name);
            graphLine = new Series((currentSeries == null ? "Изотерма" : currentSeries.name) + "_Line")
            { ChartType = SeriesChartType.Spline, BorderWidth = 3, Color = color };
            graphLine.SetCustomProperty("LineTension", "0.2");
            graphPoints = new Series((currentSeries == null ? "Изотерма" : currentSeries.name) + "_Point")
            { ChartType = SeriesChartType.Point, Color = color, MarkerSize = 10,
                MarkerStyle = MarkerStyle.Circle, MarkerBorderColor = System.Drawing.Color.Black };

            foreach (IsothermPoint point in points.Where(IsValidPoint).OrderBy(point => point.Ce))
            {
                graphLine.Points.AddXY(point.Ce, point.Qe);
                graphPoints.Points.AddXY(point.Ce, point.Qe);
            }
            Graph_Isotherm.Series.Add(graphLine);
            Graph_Isotherm.Series.Add(graphPoints);
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
            try { qe = Math.Max(0.00001, chartArea.AxisY.PixelPositionToValue(e.Y)); }
            catch (ArgumentException) { return; }
            graphPoints.Points[draggedPointIndex].YValues[0] = qe;
            graphLine.Points[draggedPointIndex].YValues[0] = qe;
        }

        private void Graph_Isotherm_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!isDraggingPoint || draggedPointIndex < 0) return;
            IsothermPoint editedPoint = points.Where(IsValidPoint).OrderBy(point => point.Ce)
                .ElementAtOrDefault(draggedPointIndex);
            if (editedPoint != null)
            {
                IsothermCalculator.UpdateFromQe(editedPoint, currentSeries,
                    graphPoints.Points[draggedPointIndex].YValues[0]);
            }
            draggedPointIndex = -1;
            isDraggingPoint = false;
            DataGrid_Points.Items.Refresh();
            BuildChart();
        }

        private void DataGrid_Points_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (currentSeries != null && currentSeries.calibrationK > 0)
                {
                    for (int i = 0; i < points.Count; i++)
                    {
                        IsothermPoint point = points[i];
                        if (point.InitialOpticalDensity > 0 && point.SorbentMassG > 0
                            && point.EquilibriumOpticalDensity >= 0
                            && point.EquilibriumOpticalDensity < point.InitialOpticalDensity)
                        {
                            try
                            {
                                points[i] = IsothermCalculator.Calculate(point.InitialOpticalDensity,
                                    point.SorbentMassG, point.EquilibriumOpticalDensity,
                                    currentSeries.calibrationK, currentSeries.solutionVolumeMl,
                                    currentSeries.molarMassGPerMol);
                            }
                            catch (ArgumentException) { }
                        }
                    }
                }
                DataGrid_Points.Items.Refresh();
                BuildChart();
            }));
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_Points.CommitEdit(DataGridEditingUnit.Cell, true);
            DataGrid_Points.CommitEdit(DataGridEditingUnit.Row, true);
            var valid = points.Where(IsValidPoint).OrderBy(point => point.Ce)
                .Select(IsothermCalculator.Clone).ToList();
            if (currentSeries == null || valid.Count < 3)
            {
                MessageBox.Show("Для изотермы необходимо не менее трёх корректных точек Ce–qe.",
                    "Редактирование изотерм", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            currentSeries.data = valid;
            currentSeries.langmuir = null;
            parent.SelectIsotherm(currentSeries.name);
            Close();
        }

        private static bool IsFinite(double value) { return !double.IsNaN(value) && !double.IsInfinity(value); }
        private void Window_Closed(object sender, EventArgs e) { parent.RefreshCurrentModeView(); parent.Show(); }
    }
}
