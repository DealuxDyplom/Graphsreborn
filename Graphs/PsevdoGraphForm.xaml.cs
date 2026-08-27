using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    /// <summary>
    /// Shows experimental q(t) values together with a directly fitted kinetic curve.
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
            Color modelColor = isPfo ? Color.SteelBlue : Color.DarkOrange;
            Label_PsevdoGraph_Name.Content = substance.name + " — " + modelName + " (нелинейная аппроксимация)";

            var chartArea = new ChartArea();
            chartArea.AxisX.Title = "t, мин";
            chartArea.AxisY.Title = "qₜ, мкмоль/г";
            chartArea.AxisX.IsStartedFromZero = true;
            chartArea.AxisY.IsStartedFromZero = true;
            chartArea.AxisX.MajorGrid.LineColor = Color.Gainsboro;
            chartArea.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            Graph_PsevdoChart.ChartAreas.Add(chartArea);
            Graph_PsevdoChart.Legends.Add(new Legend { Docking = Docking.Top });

            var experimental = new Series("Экспериментальные qₜ")
            {
                ChartType = SeriesChartType.Point,
                Color = modelColor,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 10,
                MarkerBorderColor = Color.Black,
                BorderWidth = 2
            };
            experimental.Points.AddXY(0, 0);
            foreach (var point in substance.data.OrderBy(row => row.time))
                experimental.Points.AddXY(point.time, point.qt_ml);

            var fittedCurve = new Series(modelName + " — расчётная кривая")
            {
                ChartType = SeriesChartType.Line,
                Color = modelColor,
                BorderWidth = 3
            };

            double maxTime = Math.Max(1.0, substance.data.Max(row => row.time));
            for (int i = 0; i <= 160; i++)
            {
                double time = maxTime * i / 160.0;
                double qt = isPfo
                    ? KineticModelFitter.PredictPseudoFirstOrder(time, substance.psevdo_1_data.Qe1, substance.psevdo_1_data.k1)
                    : KineticModelFitter.PredictPseudoSecondOrder(time, substance.psevdo_2_data.Qe2, substance.psevdo_2_data.k2);
                fittedCurve.Points.AddXY(time, qt);
            }

            Graph_PsevdoChart.Series.Add(fittedCurve);
            Graph_PsevdoChart.Series.Add(experimental);

            if (isPfo)
            {
                TextBox_Equastion.Text = "qₜ = qₑ·(1 − e^(−k₁t))";
                TextBox_R2.Text = Format(substance.psevdo_1_data.determination);
                Label_Qe.Content = "qₑ, мкмоль/г";
                TextBox_Qe.Text = Format(substance.psevdo_1_data.Qe1);
                Label_K.Content = "k₁, мин⁻¹";
                TextBox_K.Text = substance.psevdo_1_data.rateConstantIdentifiable
                    ? Format(substance.psevdo_1_data.k1)
                    : "не определяется";
                TextBox_K.ToolTip = substance.psevdo_1_data.fitNote;
            }
            else
            {
                TextBox_Equastion.Text = "qₜ = (k₂·qₑ²·t)/(1 + k₂·qₑ·t)";
                TextBox_R2.Text = Format(substance.psevdo_2_data.determination);
                Label_Qe.Content = "qₑ, мкмоль/г";
                TextBox_Qe.Text = Format(substance.psevdo_2_data.Qe2);
                Label_K.Content = "k₂, г/(мкмоль·мин)";
                TextBox_K.Text = substance.psevdo_2_data.rateConstantIdentifiable
                    ? Format(substance.psevdo_2_data.k2)
                    : "не определяется";
                TextBox_K.ToolTip = substance.psevdo_2_data.fitNote;
            }
        }

        private static string Format(double value)
        {
            return double.IsNaN(value) || double.IsInfinity(value) ? "—" : value.ToString("G7");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Show();
        }
    }
}
