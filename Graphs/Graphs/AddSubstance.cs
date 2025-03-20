using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs
{
    public partial class AddSubstance: Form
    {
        public AddSubstance()
        {
            InitializeComponent();

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
            for (int i = 0; i < 4; i++)
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
    }
}
