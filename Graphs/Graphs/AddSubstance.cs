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

namespace Graphs
{
    public partial class AddSubstance: Form
    {
        Substance substance;
        bool Recalulate_done = false;
        Form1 parent;

        public AddSubstance(Form1 owner)
        {
            InitializeComponent();

            parent = owner;

            substance = new Substance();
            substance.data = new List<SubstanceData>();

            //fill dataGridView
            string[] row1 = {"5", "0,089" };
            string[] row2 = { "10", "0,165" };
            string[] row3 = { "20", "0,318" };
            string[] row4 = { "30", "0,471" };
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Rows.Add(row3);
            dataGridView1.Rows.Add(row4);

            //create graph on chart
            //add points into graph
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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

        private void button_FillFromFileExprData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

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

            //clear and fill grad table and graph
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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

            double OpticDens = double.Parse(textBox_OpticDens.Text);
            double C_from_OpticDens = OpticDens / k;
            for (int i = 0; i < dataGridView_ExprData.Rows.Count - 1; i++)
            {
                double C_mkmol = double.Parse(dataGridView_ExprData["DataGridView_ExprData_Column_A", i].Value.ToString()) / k;
                double qt_mr = (C_from_OpticDens - C_mkmol) * 20 / (double.Parse(dataGridView_ExprData["Column_m_r", i].Value.ToString()));
                double qt_ml = qt_mr / 1355; //??? что такое 1355
                double proc = (C_from_OpticDens - C_mkmol) / C_from_OpticDens * 100;

                string[] rows = { dataGridView_ExprData["Column_time", i].Value.ToString(),
                    dataGridView_ExprData["Column_m_r", i].Value.ToString(),
                    dataGridView_ExprData["DataGridView_ExprData_Column_A", i].Value.ToString(),
                    C_mkmol.ToString(),
                    qt_mr.ToString(),
                    qt_ml.ToString(),
                    proc.ToString()
                };
                dataGridView_Data.Rows.Add(rows);

                SubstanceData substanceData = new SubstanceData();
                substanceData.time = Convert.ToDouble(dataGridView_ExprData["Column_time", i].Value);
                substanceData.m_r = Convert.ToDouble(dataGridView_ExprData["Column_m_r", i].Value);
                substanceData.A = Convert.ToDouble(dataGridView_ExprData["DataGridView_ExprData_Column_A", i].Value);
                substanceData.C_mkmol = C_mkmol;
                substanceData.qt_mr = qt_mr;
                substanceData.qt_ml = qt_ml;
                substanceData.proc = proc;

                substance.data.Add(substanceData);
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
        }
    }
}
