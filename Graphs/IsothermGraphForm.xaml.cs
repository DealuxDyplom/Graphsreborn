using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    public partial class IsothermGraphForm : Window
    {
        private readonly IsothermModelTableForm parent;

        public IsothermGraphForm(IsothermSeries series, IsothermModelTableForm owner)
        {
            parent = owner;
            InitializeComponent();
            IsothermModelFitter.FitLangmuir(series);

            Label_GraphName.Content = series.name + " — Langmuir (линеаризация)";
            var area = new ChartArea();
            area.AxisX.Title = "Ce, мкмоль/л";
            area.AxisY.Title = "Ce/qe, г/л";
            area.AxisX.IsStartedFromZero = false;
            area.AxisY.IsStartedFromZero = false;
            area.AxisX.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            Graph_LangmuirChart.ChartAreas.Add(area);
            Graph_LangmuirChart.Legends.Add(new Legend { Docking = Docking.Top });

            var experimental = new Series("Экспериментальные точки")
            {
                ChartType = SeriesChartType.Point,
                Color = Color.SeaGreen,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 10,
                MarkerBorderColor = Color.Black
            };
            foreach (var point in series.data.OrderBy(point => point.Ce))
            {
                if (point.Ce > 0 && point.Qe > 0)
                    experimental.Points.AddXY(point.LinearX, point.LinearY);
            }

            // Use a short, predictable scale (1, 2 or 5 multiplied by a power
            // of ten) so decimal labels remain compact and horizontal.
            ConfigureReadableAxis(
                area.AxisX,
                experimental.Points.Min(point => point.XValue),
                experimental.Points.Max(point => point.XValue));
            ConfigureReadableAxis(
                area.AxisY,
                experimental.Points.Min(point => point.YValues[0]),
                experimental.Points.Max(point => point.YValues[0]));

            var trend = new Series("Линия регрессии")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.SeaGreen,
                BorderWidth = 3
            };
            double minX = experimental.Points.Min(point => point.XValue);
            double maxX = experimental.Points.Max(point => point.XValue);
            trend.Points.AddXY(minX, series.langmuir.a + series.langmuir.b * minX);
            trend.Points.AddXY(maxX, series.langmuir.a + series.langmuir.b * maxX);
            Graph_LangmuirChart.Series.Add(trend);
            Graph_LangmuirChart.Series.Add(experimental);

            TextBox_Equation.Text = FormatEquation(series.langmuir.a, series.langmuir.b);
            TextBox_R2.Text = Format(series.langmuir.determination);
            TextBox_Qmax.Text = Format(series.langmuir.qMax);
            TextBox_KL.Text = Format(series.langmuir.kL);
            TextBox_Status.Text = series.langmuir.isPhysicallyValid ? "модель применима" : "модель неприменима";
            TextBox_Status.ToolTip = series.langmuir.fitNote;
            TextBox_R2.ToolTip = series.langmuir.fitNote;
        }

        private static string Format(double value)
        {
            return double.IsNaN(value) || double.IsInfinity(value) ? "—" : value.ToString("G7");
        }

        private static string FormatEquation(double a, double b)
        {
            return "y = " + Format(a) + (b < 0 ? " − " : " + ") + Format(Math.Abs(b)) + "·x";
        }

        private static void ConfigureReadableAxis(Axis axis, double minimum, double maximum)
        {
            double range = maximum - minimum;
            if (double.IsNaN(range) || double.IsInfinity(range) || range <= 0) return;

            double interval = NiceInterval(range / 6.0);
            axis.Minimum = Math.Floor(minimum / interval) * interval;
            axis.Maximum = Math.Ceiling(maximum / interval) * interval;
            if (axis.Maximum <= axis.Minimum) axis.Maximum = axis.Minimum + interval;
            axis.Interval = interval;
            axis.MajorGrid.Interval = interval;
            axis.LabelStyle.Interval = interval;
            axis.LabelStyle.Format = "0.###";
            axis.LabelStyle.Angle = 0;
            axis.IsLabelAutoFit = false;
            axis.LabelStyle.Font = new Font("Segoe UI", 9f);
        }

        private static double NiceInterval(double rawInterval)
        {
            double magnitude = Math.Pow(10.0, Math.Floor(Math.Log10(rawInterval)));
            double normalized = rawInterval / magnitude;
            double nice = normalized <= 1.0 ? 1.0
                : normalized <= 2.0 ? 2.0
                : normalized <= 5.0 ? 5.0
                : 10.0;
            return nice * magnitude;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Show();
        }
    }
}
