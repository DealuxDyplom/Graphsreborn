using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using MathNet.Numerics.Optimization;
using System.Globalization;

namespace Graphs
{
    public partial class AddSubstanceForm: Form
    {
        Substance substance;
        bool Recalulate_done = false;
        Form1 parent;
        int decimalPlaces = 3; //округление значений до заданного количества знаков после запятой для таблиц

        public AddSubstanceForm(Form1 owner)
        {
            InitializeComponent();

            parent = owner;

            substance = new Substance();
            substance.data = new List<SubstanceData>();

            foreach (Graduation graduation in Databank.graduations)
            {
                comboBox_Graduation.Items.Add(graduation.name);
            }

            // при изменнеии comboBox_Graduation.SelectedIndex вызовется функция comboBox_Graduation_SelectedIndexChanged
            comboBox_Graduation.SelectedIndex = 0;
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

        private void button_FillFromFileExprData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "") return;

            //очищаем таблицу
            dataGridView_ExprData.Rows.Clear();
            dataGridView_ExprData.Refresh();

            //чтение данных
            string[] rows = File.ReadAllLines(openFileDialog.FileName);

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split('|');
                dataGridView_ExprData.Rows.Add(columns);
            }
        }

        private void button_Recalculate_Click(object sender, EventArgs e)
        {
            //error handling
            if (textBox_OpticDens.Text == "")
            {
                MessageBox.Show("Оптическая плотность раствора не указана", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox_OpticDens.Text.Any(c => char.IsLetter(c)))
            {
                MessageBox.Show("Оптическая плотность не должна содержать буквы", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (label_SubstanceName.Text == "")
            {
                MessageBox.Show("Название раствора не указано", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView1.Rows.Count - 1 == 0)
            {
                MessageBox.Show("Градуировка не заполнена", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView_ExprData.Rows.Count - 1 == 0)
            {
                MessageBox.Show("Экспериментальные данные не указаны", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //clear substance data
            substance = new Substance();
            substance.data = new List<SubstanceData>();

            //clear graduations taable and chart
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            for (int i = 0; i < Databank.graduations[comboBox_Graduation.SelectedIndex].data.Count; i++)
            {
                string[] row = { Databank.graduations[comboBox_Graduation.SelectedIndex].data[i].C_mkmol.ToString(),
                    Databank.graduations[comboBox_Graduation.SelectedIndex].data[i].A.ToString() };
                dataGridView1.Rows.Add(row);
            }

            //add points into graph
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double x = double.Parse(this.dataGridView1["Column_C_ml", i].Value.ToString());
                double y = double.Parse(this.dataGridView1["Column_A", i].Value.ToString());
                this.chart1.Series[0].Points.AddXY(x, y);
            }

            //create trend line
            double y_sum = 0;
            double x_sum = 0;
            double x_2_sum = 0;
            double xy_sum = 0;
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {
                y_sum += chart1.Series[0].Points[i].YValues[0];
                x_sum += chart1.Series[0].Points[i].XValue;
                x_2_sum += chart1.Series[0].Points[i].XValue * chart1.Series[0].Points[i].XValue;
                xy_sum += chart1.Series[0].Points[i].YValues[0] * chart1.Series[0].Points[i].XValue;
            }

            double y_srd = y_sum / chart1.Series[0].Points.Count;
            double x_srd = x_sum / chart1.Series[0].Points.Count;
            double x_2_srd = x_2_sum / chart1.Series[0].Points.Count;
            double xy_srd = xy_sum / chart1.Series[0].Points.Count;

            double k = (xy_sum) / x_2_sum;

            double x1_trendline = chart1.Series[0].Points[0].XValue;
            double y1_trendline = k * x1_trendline;
            this.chart1.Series[1].Points.AddXY(x1_trendline, y1_trendline);
            double x2_trendline = chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].XValue;
            double y2_trendline = k * x2_trendline;
            this.chart1.Series[1].Points.AddXY(x2_trendline, y2_trendline);

            textBox_Coef.Text = k.ToString();

            //find out determination
            double SS_tot = 0;
            double SS_res = 0;
            double SS_reg = 0;
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {
                double y_res = k * chart1.Series[0].Points[i].XValue;
                SS_res += (chart1.Series[0].Points[i].YValues[0] - y_res) * (chart1.Series[0].Points[i].YValues[0] - y_res);
                SS_reg += (y_res - y_srd) * (y_res - y_srd);
            }

            SS_tot = SS_reg + SS_res;

            double determination = SS_reg / SS_tot;
            textBox_Detr.Text = determination.ToString();

            //fill dataGridView_Data
            dataGridView_Data.Rows.Clear();
            dataGridView_Data.Refresh();

            double OpticDens = double.Parse(textBox_OpticDens.Text.Replace(".", ","));
            double C_from_OpticDens = OpticDens / k;
            substance.k = k;
            substance.OpticDens = OpticDens; ;
            for (int i = 0; i < dataGridView_ExprData.Rows.Count - 1; i++)
            {
                double C_mkmol = Math.Round(double.Parse(dataGridView_ExprData["DataGridView_ExprData_Column_A", i].Value.ToString().Replace(".", ",")) / k, decimalPlaces);
                double qt_mr = Math.Round((C_from_OpticDens - C_mkmol) * 20 / (double.Parse(dataGridView_ExprData["Column_m_r", i].Value.ToString().Replace(".", ","))), decimalPlaces);
                double qt_ml = Math.Round(qt_mr / 1355, decimalPlaces); //??? что такое 1355
                double proc = Math.Round((C_from_OpticDens - C_mkmol) / C_from_OpticDens * 100, decimalPlaces);

                SubstanceData substanceData = new SubstanceData();
                substanceData.time = Convert.ToDouble(dataGridView_ExprData["Column_time", i].Value.ToString().Replace(".", ","));
                substanceData.m_r = Convert.ToDouble(dataGridView_ExprData["Column_m_r", i].Value.ToString().Replace(".", ","));
                substanceData.A = Convert.ToDouble(dataGridView_ExprData["DataGridView_ExprData_Column_A", i].Value.ToString().Replace(".", ","));
                substanceData.C_mkmol = C_mkmol;
                substanceData.qt_mr = qt_mr;
                substanceData.qt_ml = qt_ml;
                substanceData.proc = proc;

                //substanceData.Qe1 = 0.362;

                //substanceData.qe_qt = substanceData.Qe1 - substanceData.qt_ml;
                //substanceData.log_qe_qt = Math.Log10(substanceData.qe_qt);
                //if (substanceData.qt_ml != 0)
                //{
                //    substanceData.t_qt = substanceData.time / substanceData.qt_ml;
                //}
                //else
                //{
                //    substanceData.t_qt = 0;
                //}

                substance.data.Add(substanceData);

                //string[] rows = { dataGridView_ExprData["Column_time", i].Value.ToString(),
                //    dataGridView_ExprData["Column_m_r", i].Value.ToString(),
                //    dataGridView_ExprData["DataGridView_ExprData_Column_A", i].Value.ToString(),
                //    substanceData.C_mkmol.ToString(),
                //    substanceData.qt_mr.ToString(),
                //    substanceData.qt_ml.ToString(),
                //    substanceData.proc.ToString(),
                //    substanceData.qe_qt.ToString(),
                //    substanceData.log_qe_qt.ToString(),
                //    substanceData.t_qt.ToString(),
                //};

                //dataGridView_Data.Rows.Add(rows);
            }

            //find out Qe1
            double[] time = new double[substance.data.Count];
            double[] qt_exp = new double[substance.data.Count];
            for (int i = 0; i < substance.data.Count; i++)
            {
                time[i] = substance.data[i].time;
                qt_exp[i] = substance.data[i].qt_ml;
            }
            double Qe1 = getQe(time, qt_exp);
            for (int i = 0; i < substance.data.Count; i++)
            {
                substance.data[i].Qe1 = Math.Round(Qe1, decimalPlaces);

                substance.data[i].qe_qt = Math.Round(substance.data[i].Qe1 - substance.data[i].qt_ml, decimalPlaces);
                substance.data[i].log_qe_qt = Math.Round(Math.Log10(substance.data[i].qe_qt), decimalPlaces);
                if (substance.data[i].qt_ml != 0)
                {
                    substance.data[i].t_qt = Math.Round(substance.data[i].time / substance.data[i].qt_ml, decimalPlaces);
                }
                else
                {
                    substance.data[i].t_qt = 0;
                }

                string[] rows = { dataGridView_ExprData["Column_time", i].Value.ToString(),
                    dataGridView_ExprData["Column_m_r", i].Value.ToString(),
                    dataGridView_ExprData["DataGridView_ExprData_Column_A", i].Value.ToString(),
                    substance.data[i].C_mkmol.ToString(),
                    substance.data[i].qt_mr.ToString(),
                    substance.data[i].qt_ml.ToString(),
                    substance.data[i].proc.ToString(),
                    substance.data[i].qe_qt.ToString(),
                    substance.data[i].log_qe_qt.ToString(),
                    substance.data[i].t_qt.ToString(),
                };

                dataGridView_Data.Rows.Add(rows);
            }

            Recalulate_done = true;
        }

        private void button_AddSubstance_Click(object sender, EventArgs e)
        {
            //error handling
            if (!Recalulate_done)
            {
                MessageBox.Show("Выполните перерасчет", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < Databank.substances.Count; i++)
            {
                if (Databank.substances[i].name == textBox_SubstanceName.Text)
                {
                    MessageBox.Show("Раствор с таким названием уже есть", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //add substance to list
            substance.name = textBox_SubstanceName.Text;
            Databank.substances.Add(substance);
            this.Close();
        }

        private void AddSubstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.updateflowLayoutPanel();
            parent.Show();
        }

        private void comboBox_Graduation_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            for (int i = 0; i < Databank.graduations[comboBox_Graduation.SelectedIndex].data.Count; i++)
            {
                string[] row = { Databank.graduations[comboBox_Graduation.SelectedIndex].data[i].C_mkmol.ToString(),
                    Databank.graduations[comboBox_Graduation.SelectedIndex].data[i].A.ToString() };
                dataGridView1.Rows.Add(row);
            }

            //create graph on chart
            //add points into graph
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double x = double.Parse(this.dataGridView1["Column_C_ml", i].Value.ToString());
                double y = double.Parse(this.dataGridView1["Column_A", i].Value.ToString());
                this.chart1.Series[0].Points.AddXY(x, y);
            }

            //create trend line
            double y_sum = 0;
            double x_sum = 0;
            double x_2_sum = 0;
            double xy_sum = 0;
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {
                y_sum += chart1.Series[0].Points[i].YValues[0];
                x_sum += chart1.Series[0].Points[i].XValue;
                x_2_sum += chart1.Series[0].Points[i].XValue * chart1.Series[0].Points[i].XValue;
                xy_sum += chart1.Series[0].Points[i].YValues[0] * chart1.Series[0].Points[i].XValue;
            }

            double y_srd = y_sum / chart1.Series[0].Points.Count;
            double x_srd = x_sum / chart1.Series[0].Points.Count;
            double x_2_srd = x_2_sum / chart1.Series[0].Points.Count;
            double xy_srd = xy_sum / chart1.Series[0].Points.Count;

            double k = (xy_sum) / x_2_sum;

            double x1_trendline = chart1.Series[0].Points[0].XValue;
            double y1_trendline = k * x1_trendline;
            this.chart1.Series[1].Points.AddXY(x1_trendline, y1_trendline);
            double x2_trendline = chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].XValue;
            double y2_trendline = k * x2_trendline;
            this.chart1.Series[1].Points.AddXY(x2_trendline, y2_trendline);

            textBox_Coef.Text = k.ToString();

            //find out determination
            double SS_tot = 0;
            double SS_res = 0;
            double SS_reg = 0;
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {
                double y_res = k * chart1.Series[0].Points[i].XValue;
                SS_res += (chart1.Series[0].Points[i].YValues[0] - y_res) * (chart1.Series[0].Points[i].YValues[0] - y_res);
                SS_reg += (y_res - y_srd) * (y_res - y_srd);
            }

            SS_tot = SS_reg + SS_res;

            double determination = SS_reg / SS_tot;
            textBox_Detr.Text = determination.ToString();
        }
    }
}
