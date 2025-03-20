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

namespace Graphs
{
    public partial class AddSubstance: Form
    {
        Substance substance;

        public AddSubstance()
        {
            InitializeComponent();

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

            double k2 = (xy_srd - x_srd * y_srd) / (x_2_srd - x_srd * x_srd);
            double k1 = y_srd - k2*x_srd;

            double x1_trendline = chart1.Series[0].Points[0].XValue;
            double y1_trendline = k1 + k2 * x1_trendline;
            this.chart1.Series[1].Points.AddXY(x1_trendline, y1_trendline);
            double x2_trendline = chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].XValue;
            double y2_trendline = k1 + k2 * x2_trendline;
            this.chart1.Series[1].Points.AddXY(x2_trendline, y2_trendline);

            textBox_Coef.Text = k2.ToString();

            //find out determination
            double SS_tot = 0;
            double SS_res = 0;
            double SS_reg = 0;
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {
                double y_res = k1 + k2 * chart1.Series[0].Points[i].XValue;
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

            double k2 = (xy_srd - x_srd * y_srd) / (x_2_srd - x_srd * x_srd);
            double k1 = y_srd - k2 * x_srd;

            double x1_trendline = chart1.Series[0].Points[0].XValue;
            double y1_trendline = k1 + k2 * x1_trendline;
            this.chart1.Series[1].Points.AddXY(x1_trendline, y1_trendline);
            double x2_trendline = chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].XValue;
            double y2_trendline = k1 + k2 * x2_trendline;
            this.chart1.Series[1].Points.AddXY(x2_trendline, y2_trendline);

            textBox_Coef.Text = k2.ToString();

            //find out determination
            double SS_tot = 0;
            double SS_res = 0;
            double SS_reg = 0;
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {
                double y_res = k1 + k2 * chart1.Series[0].Points[i].XValue;
                SS_res += (chart1.Series[0].Points[i].YValues[0] - y_res) * (chart1.Series[0].Points[i].YValues[0] - y_res);
                SS_reg += (y_res - y_srd) * (y_res - y_srd);
            }

            SS_tot = SS_reg + SS_res;

            double determination = SS_reg / SS_tot;
            textBox_Detr.Text = determination.ToString();

            //fill dataGridView_Data
            double OpticDens = double.Parse(textBox_OpticDens.Text);
            double C_from_OpticDens = OpticDens / k2;
            for (int i = 0; i < dataGridView_ExprData.Rows.Count - 1; i++)
            {
                double C_mkmol = double.Parse(dataGridView_ExprData["DataGridView_ExprData_Column_A", i].Value.ToString()) / k2;
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
                substanceData.q_ml = qt_ml;
                substanceData.proc = proc;

                substance.data.Add(substanceData);
            }
        }

        private void button_AddSubstance_Click(object sender, EventArgs e)
        {
            substance.name = textBox_SubstanceName.Text;
            Databank.substances.Add(substance);
            this.Close();
        }
    }
}
