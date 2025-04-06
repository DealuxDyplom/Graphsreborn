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
using MathNet.Numerics.Optimization;
using Newtonsoft.Json.Linq;

namespace Graphs
{
    public partial class EditSubstanceForm: Form
    {
        Form1 parent;
        bool MouseDownOnPointOnGraph = false;
        int PointIndexMouseDown = -1;
        Substance substance;

        double Qe1;
        public EditSubstanceForm(Form1 owner)
        {
            InitializeComponent();
            parent = owner;

            foreach (Substance substance in Databank.substances)
            {
                comboBox1.Items.Add(substance.name);
            }

        }

        private void paintGraphFromComboBox() {
            //paint chart_Graph
            chart_Graph.Series.Clear();
            chart_Graph.Show();

            Random rand = new Random();
            Series series_spline = chart_Graph.Series.Add(comboBox1.SelectedItem.ToString() + "_Spline");
            series_spline.ChartType = SeriesChartType.Spline;
            //to make graph more smooth
            series_spline.SetCustomProperty("LineTension", "0.2");
            series_spline.Color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            series_spline.BorderWidth = 3;

            Series series_with_visible_points = chart_Graph.Series.Add(comboBox1.SelectedItem.ToString() + "_Points");
            series_with_visible_points.ChartType = SeriesChartType.Point;
            series_with_visible_points.IsVisibleInLegend = false;
            series_with_visible_points.Color = series_spline.Color;

            //add null data into series
            series_spline.Points.AddXY(0, 0);
            series_with_visible_points.Points.AddXY(0, 0);

            //search substance name
            for (int i = 0; i < dataGridView_Data.RowCount - 1; i++)
            {
                double x = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_time", i].Value.ToString().Replace(".", ","));
                double y = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qt_ml", i].Value.ToString().Replace(".", ","));
                series_spline.Points.AddXY(x, y);
                series_with_visible_points.Points.AddXY(x, y);
            }

            //paint points
            for (int j = 0; j < series_with_visible_points.Points.Count; j++)
            {
                series_with_visible_points.Points[j].MarkerSize = 10;
                series_with_visible_points.Points[j].MarkerBorderColor = Color.Black;
                series_with_visible_points.Points[j].MarkerStyle = MarkerStyle.Circle;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_Data.Rows.Clear();
            dataGridView_Data.Refresh();

            for (int i = 0; i < Databank.substances.Count; i++) {
                if (Databank.substances[i].name == comboBox1.SelectedItem.ToString()) {
                    substance = Databank.substances[i];

                    //fill DataGridView
                    for (int j = 0; j < Databank.substances[i].data.Count; j++) {
                        string[] rows = { Databank.substances[i].data[j].time.ToString(),
                        Databank.substances[i].data[j].m_r.ToString(),
                        Databank.substances[i].data[j].A.ToString(),
                        Databank.substances[i].data[j].C_mkmol.ToString(),
                        Databank.substances[i].data[j].qt_mr.ToString(),
                        Databank.substances[i].data[j].qt_ml.ToString(),
                        Databank.substances[i].data[j].proc.ToString(),
                        Databank.substances[i].data[j].qe_qt.ToString(),
                        Databank.substances[i].data[j].log_qe_qt.ToString(),
                        Databank.substances[i].data[j].t_qt.ToString()
                        };

                        dataGridView_Data.Rows.Add(rows);
                    }

                    paintGraphFromComboBox();


                    break;
                }
            }

        }

        private void button_SaveEdits_Click(object sender, EventArgs e)
        {
            //error handling
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите раствор", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Databank.substances[comboBox1.SelectedIndex].data.Clear();
            for (int i = 0; i < dataGridView_Data.Rows.Count - 1; i++)
            {
                SubstanceData substanceData = new SubstanceData();
                substanceData.time = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_time", i].Value.ToString().Replace(".", ","));
                substanceData.m_r = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_m_r", i].Value.ToString().Replace(".", ","));
                substanceData.A = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_A", i].Value.ToString().Replace(".", ","));
                substanceData.C_mkmol = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_C_mkmol", i].Value.ToString().Replace(".", ","));
                substanceData.qt_mr = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qt_mr", i].Value.ToString().Replace(".", ","));
                substanceData.qt_ml = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qt_ml", i].Value.ToString().Replace(".", ","));
                substanceData.proc = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_proc", i].Value.ToString().Replace(".", ","));
                substanceData.qe_qt = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qe_qt", i].Value.ToString().Replace(".", ","));
                substanceData.log_qe_qt = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_log_qe_qt", i].Value.ToString().Replace(".", ","));
                substanceData.t_qt = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_t_qt", i].Value.ToString().Replace(".", ","));
                substanceData.Qe1 = Qe1;

                Databank.substances[comboBox1.SelectedIndex].data.Add(substanceData);
            }
            this.Close();
        }

        private void EditSubstanceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.fillFlowLayoutCheckboxes();
            parent.Show();
        }

        private void dataGridView_Data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            paintGraphFromComboBox();
        }

        private void chart_Graph_MouseDown(object sender, MouseEventArgs e)
        {
            //когда нажата ЛКМ, определяется индекс точки
            PointIndexMouseDown = chart_Graph.HitTest(e.X, e.Y).PointIndex;
            if (PointIndexMouseDown == -1) { return; }
            //если ЛКМ нажата на точку, то её края окрашиваются в желтый
            chart_Graph.Series[1].Points[PointIndexMouseDown].MarkerBorderColor = Color.Yellow;

            MouseDownOnPointOnGraph = true;

        }

        private void chart_Graph_MouseMove(object sender, MouseEventArgs e)
        {
            //если мышь двигается, и до этого ЛКМ была нажата на точку, то координаты точки меняются
            if (MouseDownOnPointOnGraph) {
                var chartArea = chart_Graph.ChartAreas[0];
                double xValue = chartArea.AxisX.PixelPositionToValue(e.X);
                double yValue = chartArea.AxisY.PixelPositionToValue(e.Y);

                //меняем координаты самой точки
                chart_Graph.Series[1].Points[PointIndexMouseDown].XValue = chart_Graph.Series[1].Points[PointIndexMouseDown].XValue;
                chart_Graph.Series[1].Points[PointIndexMouseDown].YValues[0] = yValue;

                //меняем координаты опорной точки Spline
                chart_Graph.Series[0].Points[PointIndexMouseDown].XValue = chart_Graph.Series[0].Points[PointIndexMouseDown].XValue;
                chart_Graph.Series[0].Points[PointIndexMouseDown].YValues[0] = yValue;

                //пишем в toolStripStatusLabel координаты точки
                toolStripStatusLabel_Y.Text = "Y = " + yValue.ToString();
            }
        }

        // Модель псевдо-первого порядка
        static double PseudoFirstOrder(double t, double qe, double k1)
        {
            return qe * (1 - Math.Exp(-k1 * t));
        }

        // Функция сгенерирована ChatGPT
        static double getQe(double[] time, double[] qt_exp)
        {
            ////Экспериментальные данные
            //double[] time = { 0, 5, 10, 20, 40, 60 };  // Время в минутах
            //double[] qt_exp = { 0, 0.3544, 0.3509, 0.3542, 0.3617, 0.3562 };  // Экспериментальные данные

            // Функция ошибки (минимизируемая)
            Func<double, double, double> errorFunc = (qe_local, k1_local) =>
            {
                double error = 0.0;
                for (int i = 0; i < time.Length; i++)
                {
                    double model = PseudoFirstOrder(time[i], qe_local, k1_local);
                    error += Math.Pow(model - qt_exp[i], 2);
                }
                return error;
            };

            // Начальные значения
            double qe = 0.1;
            double k1 = 0.1;
            int iterations = 5; // Количество итераций поочерёдной минимизации

            var minimizer = new GoldenSectionMinimizer(1e-9, 100);

            for (int iter = 0; iter < iterations; iter++)
            {
                // Минимизация по qe (фиксируем k1)
                var resultQe = minimizer.FindMinimum(ObjectiveFunction.ScalarValue(q => errorFunc(q, k1)), 0, 1);
                qe = resultQe.MinimizingPoint;

                // Минимизация по k1 (фиксируем qe)
                var resultK1 = minimizer.FindMinimum(ObjectiveFunction.ScalarValue(k => errorFunc(qe, k)), 0, 1);
                k1 = resultK1.MinimizingPoint;
            }

            //Console.WriteLine($"Подобранные параметры: qe = {qe}, k1 = {k1}");
            return qe * 1.02;
        }

        private void chart_Graph_MouseUp(object sender, MouseEventArgs e)
        {
            //когда мышь отпущена, края всех точек окрашиваются в черный
            for (int i = 0; i < chart_Graph.Series[1].Points.Count; i++)
            {
                chart_Graph.Series[1].Points[i].MarkerBorderColor = Color.Black;
            }

            //пересчитываем таблицу со значениями
            double k = substance.k;
            double OpticDens = substance.OpticDens;
            double C_from_OpticDens = OpticDens / k;

            for (int i = 0; i < dataGridView_Data.Rows.Count - 1; i++) {
                dataGridView_Data["dataGridView_Data_Column_qt_ml", i].Value = chart_Graph.Series[1].Points[i + 1].YValues[0];
                dataGridView_Data["dataGridView_Data_Column_qt_mr", i].Value = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qt_ml", i].Value) * 1355;
                dataGridView_Data["dataGridView_Data_Column_C_mkmol", i].Value = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_A", i].Value.ToString().Replace(".", ",")) / k;
                dataGridView_Data["dataGridView_Data_Column_m_r", i].Value = (C_from_OpticDens - Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_C_mkmol", i].Value)) * 20 / Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qt_mr", i].Value);
                dataGridView_Data["dataGridView_Data_Column_proc", i].Value = (C_from_OpticDens - Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_C_mkmol", i].Value)) / C_from_OpticDens * 100;
            }

            //find out Qe1
            double[] time = new double[dataGridView_Data.Rows.Count - 1];
            double[] qt_exp = new double[dataGridView_Data.Rows.Count - 1];
            for (int i = 0; i < dataGridView_Data.Rows.Count - 1; i++)
            {
                time[i] = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_time", i].Value);
                qt_exp[i] = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qt_ml", i].Value);
            }
            Qe1 = getQe(time, qt_exp);

            for (int i = 0; i < dataGridView_Data.Rows.Count - 1; i++)
            {
                dataGridView_Data["dataGridView_Data_Column_qe_qt", i].Value = Qe1 - Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qt_ml", i].Value);
                dataGridView_Data["dataGridView_Data_Column_log_qe_qt", i].Value = Math.Log10(Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qe_qt", i].Value));
                if (Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qt_ml", i].Value) != 0)
                {
                    dataGridView_Data["dataGridView_Data_Column_t_qt", i].Value = Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_time", i].Value) / Convert.ToDouble(dataGridView_Data["dataGridView_Data_Column_qt_ml", i].Value);
                }
                else {
                    dataGridView_Data["dataGridView_Data_Column_t_qt", i].Value = 0;
                }
            }

            PointIndexMouseDown = -1;
            MouseDownOnPointOnGraph = false;
            toolStripStatusLabel_Y.Text = "";
        }
    }
}
