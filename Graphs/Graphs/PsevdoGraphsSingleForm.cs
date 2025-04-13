using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    public partial class PsevdoGraphsSingleForm: Form
    {
        KineticModelTableForm parent;
        public PsevdoGraphsSingleForm(Substance substance, int psevdo, KineticModelTableForm owner)
        {
            parent = owner;
            InitializeComponent();

            if (psevdo == 1)
            {
                label_Main.Text = substance.name;

                //create psevdo graph 1
                chart_PsevdoGraph_1.Series.Clear();
                Random rand = new Random();
                Series added_series_psevdo_1 = chart_PsevdoGraph_1.Series.Add("Psevdo_1");
                added_series_psevdo_1.ChartType = SeriesChartType.Point;
                added_series_psevdo_1.Color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));

                for (int i = 0; i < substance.data.Count; i++)
                {
                    double x_local = substance.data[i].time;
                    double y_local = substance.data[i].log_qe_qt;
                    added_series_psevdo_1.Points.AddXY(x_local, y_local);
                    added_series_psevdo_1.Points[i].MarkerSize = 10;
                    added_series_psevdo_1.Points[i].MarkerStyle = MarkerStyle.Circle;
                    added_series_psevdo_1.Points[i].BorderColor = Color.Black;
                }

                //create trend line
                double y_sum = 0;
                double x_sum = 0;
                double x_2_sum = 0;
                double xy_sum = 0;
                for (int i = 0; i < added_series_psevdo_1.Points.Count; i++)
                {
                    y_sum += added_series_psevdo_1.Points[i].YValues[0];
                    x_sum += added_series_psevdo_1.Points[i].XValue;
                    x_2_sum += added_series_psevdo_1.Points[i].XValue * added_series_psevdo_1.Points[i].XValue;
                    xy_sum += added_series_psevdo_1.Points[i].YValues[0] * added_series_psevdo_1.Points[i].XValue;
                }

                double y_srd = y_sum / added_series_psevdo_1.Points.Count;
                double x_srd = x_sum / added_series_psevdo_1.Points.Count;
                double x_2_srd = x_2_sum / added_series_psevdo_1.Points.Count;
                double xy_srd = xy_sum / added_series_psevdo_1.Points.Count;

                double b = (xy_sum - added_series_psevdo_1.Points.Count * x_srd * y_srd) / (x_2_sum - added_series_psevdo_1.Points.Count * x_srd * x_srd);
                double a = y_srd - b * x_srd;
                textBox_Equation_1.Text = Math.Round(a, 5).ToString() + " + " + Math.Round(b, 5).ToString() + " * x";

                Series psevdo_1_trend_line_series = chart_PsevdoGraph_1.Series.Add("Psevdo_1_trendline");
                psevdo_1_trend_line_series.ChartType = SeriesChartType.Line;
                psevdo_1_trend_line_series.Color = added_series_psevdo_1.Color;
                psevdo_1_trend_line_series.BorderWidth = 3;

                double x = added_series_psevdo_1.Points[0].XValue;
                double y = a + b * x;
                psevdo_1_trend_line_series.Points.AddXY(x, y);
                x = added_series_psevdo_1.Points[added_series_psevdo_1.Points.Count - 1].XValue;
                y = a + b * x;
                psevdo_1_trend_line_series.Points.AddXY(x, y);

                //find out determination
                double SS_tot = 0;
                double SS_res = 0;
                double SS_reg = 0;
                for (int i = 0; i < added_series_psevdo_1.Points.Count; i++)
                {
                    double y_res = a + b * added_series_psevdo_1.Points[i].XValue;
                    SS_res += (added_series_psevdo_1.Points[i].YValues[0] - y_res) * (added_series_psevdo_1.Points[i].YValues[0] - y_res);
                    SS_reg += (y_res - y_srd) * (y_res - y_srd);
                }

                SS_tot = SS_reg + SS_res;

                double determination = SS_reg / SS_tot;
                textBox_Determination_1.Text = Math.Round(determination, 5).ToString();

                //find out Qe1
                textBox_Qe1.Text = substance.data[0].Qe1.ToString();

                //find out K1
                double k1 = -(b * 2.303);
                textBox_K1.Text = k1.ToString();

                //to paint points before trendline
                chart_PsevdoGraph_1.Series.Remove(added_series_psevdo_1);
                chart_PsevdoGraph_1.Series.Remove(psevdo_1_trend_line_series);
                chart_PsevdoGraph_1.Series.Add(psevdo_1_trend_line_series);
                chart_PsevdoGraph_1.Series.Add(added_series_psevdo_1);
            }
            else if (psevdo == 2)
            {

                label_Main.Text = substance.name;

                //create psevdo graph 1
                chart_PsevdoGraph_1.Series.Clear();
                Random rand = new Random();
                Series added_series_psevdo_1 = chart_PsevdoGraph_1.Series.Add("Psevdo_2");
                added_series_psevdo_1.ChartType = SeriesChartType.Point;
                added_series_psevdo_1.Color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));

                for (int i = 0; i < substance.data.Count; i++)
                {
                    double x_local = substance.data[i].time;
                    double y_local = substance.data[i].t_qt;
                    added_series_psevdo_1.Points.AddXY(x_local, y_local);
                    added_series_psevdo_1.Points[i].MarkerSize = 10;
                    added_series_psevdo_1.Points[i].MarkerStyle = MarkerStyle.Circle;
                    added_series_psevdo_1.Points[i].BorderColor = Color.Black;
                }

                //create trend line
                double y_sum = 0;
                double x_sum = 0;
                double x_2_sum = 0;
                double xy_sum = 0;
                for (int i = 0; i < added_series_psevdo_1.Points.Count; i++)
                {
                    y_sum += added_series_psevdo_1.Points[i].YValues[0];
                    x_sum += added_series_psevdo_1.Points[i].XValue;
                    x_2_sum += added_series_psevdo_1.Points[i].XValue * added_series_psevdo_1.Points[i].XValue;
                    xy_sum += added_series_psevdo_1.Points[i].YValues[0] * added_series_psevdo_1.Points[i].XValue;
                }

                double y_srd = y_sum / added_series_psevdo_1.Points.Count;
                double x_srd = x_sum / added_series_psevdo_1.Points.Count;
                double x_2_srd = x_2_sum / added_series_psevdo_1.Points.Count;
                double xy_srd = xy_sum / added_series_psevdo_1.Points.Count;

                double b = (xy_sum - added_series_psevdo_1.Points.Count * x_srd * y_srd) / (x_2_sum - added_series_psevdo_1.Points.Count * x_srd * x_srd);
                double a = y_srd - b * x_srd;
                textBox_Equation_1.Text = Math.Round(a, 5).ToString() + " + " + Math.Round(b, 5).ToString() + " * x";

                Series psevdo_1_trend_line_series = chart_PsevdoGraph_1.Series.Add("Psevdo_1_trendline");
                psevdo_1_trend_line_series.ChartType = SeriesChartType.Line;
                psevdo_1_trend_line_series.Color = added_series_psevdo_1.Color;
                psevdo_1_trend_line_series.BorderWidth = 3;

                double x = added_series_psevdo_1.Points[0].XValue;
                double y = a + b * x;
                psevdo_1_trend_line_series.Points.AddXY(x, y);
                x = added_series_psevdo_1.Points[added_series_psevdo_1.Points.Count - 1].XValue;
                y = a + b * x;
                psevdo_1_trend_line_series.Points.AddXY(x, y);

                //find out determination
                double SS_tot = 0;
                double SS_res = 0;
                double SS_reg = 0;
                for (int i = 0; i < added_series_psevdo_1.Points.Count; i++)
                {
                    double y_res = a + b * added_series_psevdo_1.Points[i].XValue;
                    SS_res += (added_series_psevdo_1.Points[i].YValues[0] - y_res) * (added_series_psevdo_1.Points[i].YValues[0] - y_res);
                    SS_reg += (y_res - y_srd) * (y_res - y_srd);
                }

                SS_tot = SS_reg + SS_res;

                double determination = SS_reg / SS_tot;
                textBox_Determination_1.Text = Math.Round(determination, 5).ToString();

                //find out Qe2
                label_Qe1.Text = "Qe2";
                double Qe2 = 1 / b;
                textBox_Qe1.Text = Qe2.ToString();

                //find out K1
                label_k1.Text = "K2";
                double k2 = 1 / (0.16 / (1 / (Qe2 * Qe2)));
                textBox_K1.Text = k2.ToString();

                //to paint points before trendline
                chart_PsevdoGraph_1.Series.Remove(added_series_psevdo_1);
                chart_PsevdoGraph_1.Series.Remove(psevdo_1_trend_line_series);
                chart_PsevdoGraph_1.Series.Add(psevdo_1_trend_line_series);
                chart_PsevdoGraph_1.Series.Add(added_series_psevdo_1);
            }
        }

        private void PsevdoGraphsSingleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }
    }
}
