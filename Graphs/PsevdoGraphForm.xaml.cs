using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    /// <summary>
    /// Shows the selected kinetic model in its linearized coordinates.
    /// </summary>
    public partial class PsevdoGraphForm : Window
    {
        private readonly KineticModelTableForm parent;

        public PsevdoGraphForm(Substance substance, int psevdo, KineticModelTableForm owner)
        {
            parent = owner;
            InitializeComponent();
            KineticModelFitter.Fit(substance);

            bool isPfo = psevdo == 1;
            string modelName = isPfo ? "PFO" : "PSO";
            Label_PsevdoGraph_Name.Content = substance.name + " — " + modelName + " (линеаризация)";

            var area = new ChartArea();
            area.AxisX.Title = "t, мин";
            area.AxisY.Title = isPfo ? "log₁₀(qₑ − qₜ)" : "t/qₜ";
            area.AxisX.IsStartedFromZero = false;
            area.AxisY.IsStartedFromZero = false;
            area.AxisX.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            Graph_PsevdoChart.ChartAreas.Add(area);
            Graph_PsevdoChart.Legends.Add(new Legend { Docking = Docking.Top });

            Color color = isPfo ? Color.SteelBlue : Color.DarkOrange;
            var experimental = new Series("Экспериментальные точки")
            {
                ChartType = SeriesChartType.Point,
                Color = color,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 10,
                MarkerBorderColor = Color.Black
            };

            foreach (var point in substance.data.OrderBy(row => row.time))
            {
                double y = isPfo ? point.log_qe_qt : point.t_qt;
                if (!double.IsNaN(y) && !double.IsInfinity(y))
                    experimental.Points.AddXY(point.time, y);
            }

            double a = isPfo ? substance.psevdo_1_data.a : substance.psevdo_2_data.a;
            double b = isPfo ? substance.psevdo_1_data.b : substance.psevdo_2_data.b;
            var trend = new Series("Линия регрессии")
            {
                ChartType = SeriesChartType.Line,
                Color = color,
                BorderWidth = 3
            };
            if (experimental.Points.Count > 0)
            {
                double minTime = experimental.Points.Min(point => point.XValue);
                double maxTime = experimental.Points.Max(point => point.XValue);
                trend.Points.AddXY(minTime, a + b * minTime);
                trend.Points.AddXY(maxTime, a + b * maxTime);
            }
            Graph_PsevdoChart.Series.Add(trend);
            Graph_PsevdoChart.Series.Add(experimental);

            TextBox_Equastion.Text = FormatEquation(a, b);
            if (isPfo)
            {
                TextBox_R2.Text = Format(substance.psevdo_1_data.determination);
                Label_Qe.Content = "qₑ, мкмоль/г";
                TextBox_Qe.Text = Format(substance.psevdo_1_data.Qe1);
                Label_K.Content = "k₁, мин⁻¹";
                TextBox_K.Text = Format(substance.psevdo_1_data.k1);
                TextBox_R2.ToolTip = substance.psevdo_1_data.fitNote;
            }
            else
            {
                TextBox_R2.Text = Format(substance.psevdo_2_data.determination);
                Label_Qe.Content = "qₑ, мкмоль/г";
                TextBox_Qe.Text = Format(substance.psevdo_2_data.Qe2);
                Label_K.Content = "k₂, г/(мкмоль·мин)";
                TextBox_K.Text = Format(substance.psevdo_2_data.k2);
                TextBox_R2.ToolTip = substance.psevdo_2_data.fitNote;
            }
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
