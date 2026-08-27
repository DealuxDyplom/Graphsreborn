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

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Show();
        }
    }
}
