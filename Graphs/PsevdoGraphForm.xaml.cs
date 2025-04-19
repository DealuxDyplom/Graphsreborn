using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Graphs
{
    /// <summary>
    /// Логика взаимодействия для PsevdoGraphForm.xaml
    /// </summary>
    public partial class PsevdoGraphForm : Window
    {
        KineticModelTableForm parent;
        int decimalPlaces = 3;
        public PsevdoGraphForm(Substance substance, int psevdo, KineticModelTableForm owner)
        {
            parent = owner;
            InitializeComponent();

            Label_PsevdoGraph_Name.Content = substance.name;

            ChartArea psevdoGraph_ChartArea = new ChartArea();
            psevdoGraph_ChartArea.AxisX.IsStartedFromZero = false;
            psevdoGraph_ChartArea.AxisX.MajorGrid.Enabled = false;
            psevdoGraph_ChartArea.AxisY.IsStartedFromZero = false;
            psevdoGraph_ChartArea.AxisY.MajorGrid.Enabled = false;
            psevdoGraph_ChartArea.AlignmentOrientation = AreaAlignmentOrientations.All;
            Graph_PsevdoChart.ChartAreas.Add(psevdoGraph_ChartArea);


            if (psevdo == 1)
            {
                Random rand = new Random();

                Series psevdoGraph_SeriesPoints = new Series();
                psevdoGraph_SeriesPoints.ChartType = SeriesChartType.Point;
                psevdoGraph_SeriesPoints.Name = substance.name + "_Point";
                psevdoGraph_SeriesPoints.Color = System.Drawing.Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                for (int j = 0; j < substance.data.Count; j++)
                {
                    double x_local = substance.data[j].time;
                    double y_local = substance.data[j].log_qe_qt;
                    psevdoGraph_SeriesPoints.Points.AddXY(x_local, y_local);
                }

                for (int j = 0; j < psevdoGraph_SeriesPoints.Points.Count; j++)
                {
                    psevdoGraph_SeriesPoints.Points[j].MarkerSize = 10;
                    psevdoGraph_SeriesPoints.Points[j].MarkerBorderColor = System.Drawing.Color.Black;
                    psevdoGraph_SeriesPoints.Points[j].MarkerStyle = MarkerStyle.Circle;
                }

                Series psevdoGraph_SeriesTrendLine = new Series();
                psevdoGraph_SeriesTrendLine.ChartType = SeriesChartType.Line;
                psevdoGraph_SeriesTrendLine.Name = substance.name + "_Line";
                psevdoGraph_SeriesTrendLine.BorderWidth = 3;
                psevdoGraph_SeriesTrendLine.Color = psevdoGraph_SeriesPoints.Color;

                double x = psevdoGraph_SeriesPoints.Points[0].XValue;
                double y = substance.psevdo_1_data.a + substance.psevdo_1_data.b * x;
                psevdoGraph_SeriesTrendLine.Points.AddXY(x, y);
                x = psevdoGraph_SeriesPoints.Points[psevdoGraph_SeriesPoints.Points.Count - 1].XValue;
                y = substance.psevdo_1_data.a + substance.psevdo_1_data.b * x;
                psevdoGraph_SeriesTrendLine.Points.AddXY(x, y);

                Graph_PsevdoChart.Series.Add(psevdoGraph_SeriesTrendLine);
                Graph_PsevdoChart.Series.Add(psevdoGraph_SeriesPoints);

                TextBox_Equastion.Text = "y = " + Math.Round(substance.psevdo_1_data.a, decimalPlaces).ToString() + " + " + Math.Round(substance.psevdo_1_data.b, decimalPlaces).ToString() + " * x";
                TextBox_R2.Text = Math.Round(substance.psevdo_1_data.determination, decimalPlaces).ToString();
                Label_Qe.Content = "Qe1";
                TextBox_Qe.Text = Math.Round(substance.psevdo_1_data.Qe1, decimalPlaces).ToString();
                Label_K.Content = "K1";
                TextBox_K.Text = Math.Round(substance.psevdo_1_data.k1, decimalPlaces).ToString();

            } 
            else if (psevdo == 2)
            {
                Random rand = new Random();

                Series psevdoGraph_SeriesPoints = new Series();
                psevdoGraph_SeriesPoints.ChartType = SeriesChartType.Point;
                psevdoGraph_SeriesPoints.Name = substance.name + "_Point";
                psevdoGraph_SeriesPoints.Color = System.Drawing.Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                for (int j = 0; j < substance.data.Count; j++)
                {
                    double x_local = substance.data[j].time;
                    double y_local = substance.data[j].t_qt;
                    psevdoGraph_SeriesPoints.Points.AddXY(x_local, y_local);
                }

                for (int j = 0; j < psevdoGraph_SeriesPoints.Points.Count; j++)
                {
                    psevdoGraph_SeriesPoints.Points[j].MarkerSize = 10;
                    psevdoGraph_SeriesPoints.Points[j].MarkerBorderColor = System.Drawing.Color.Black;
                    psevdoGraph_SeriesPoints.Points[j].MarkerStyle = MarkerStyle.Circle;
                }

                Series psevdoGraph_SeriesTrendLine = new Series();
                psevdoGraph_SeriesTrendLine.ChartType = SeriesChartType.Line;
                psevdoGraph_SeriesTrendLine.Name = substance.name + "_Line";
                psevdoGraph_SeriesTrendLine.BorderWidth = 3;
                psevdoGraph_SeriesTrendLine.Color = psevdoGraph_SeriesPoints.Color;

                double x = psevdoGraph_SeriesPoints.Points[0].XValue;
                double y = substance.psevdo_2_data.a + substance.psevdo_2_data.b * x;
                psevdoGraph_SeriesTrendLine.Points.AddXY(x, y);
                x = psevdoGraph_SeriesPoints.Points[psevdoGraph_SeriesPoints.Points.Count - 1].XValue;
                y = substance.psevdo_2_data.a + substance.psevdo_2_data.b * x;
                psevdoGraph_SeriesTrendLine.Points.AddXY(x, y);

                Graph_PsevdoChart.Series.Add(psevdoGraph_SeriesTrendLine);
                Graph_PsevdoChart.Series.Add(psevdoGraph_SeriesPoints);

                TextBox_Equastion.Text = "y = " + Math.Round(substance.psevdo_2_data.a, decimalPlaces).ToString() + " + " + Math.Round(substance.psevdo_2_data.b, decimalPlaces).ToString() + " * x";
                TextBox_R2.Text = Math.Round(substance.psevdo_2_data.determination, decimalPlaces).ToString();
                Label_Qe.Content = "Qe2";
                TextBox_Qe.Text = Math.Round(substance.psevdo_2_data.Qe2, decimalPlaces).ToString();
                Label_K.Content = "K2";
                TextBox_K.Text = Math.Round(substance.psevdo_2_data.k2, decimalPlaces).ToString();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Show();
        }
    }
}
