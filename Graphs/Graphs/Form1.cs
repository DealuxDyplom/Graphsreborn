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
    public partial class Form1: Form
    {
        List<CheckBox> checkBoxes;
        public Form1()
        {
            InitializeComponent();
            Databank.substances = new List<Substance>();
            checkBoxes = new List<CheckBox>();
            chart_Graphs.Hide();
        }

        #region [ Kinetics ]
        private void button_AddSubstance_Click(object sender, EventArgs e)
        {
            AddSubstance addSubstanceForm = new AddSubstance();
            addSubstanceForm.ShowDialog();

            flowLayoutPanel.Controls.Clear();
            checkBoxes.Clear();

            for (int i = 0; i < Databank.substances.Count; i++)
            {
                checkBoxes.Add(new CheckBox());
                checkBoxes[checkBoxes.Count - 1].Text = Databank.substances[i].name;
                flowLayoutPanel.Controls.Add(checkBoxes[checkBoxes.Count - 1]);
            }
        }

        private void button_Compare_Click(object sender, EventArgs e)
        {
            chart_Graphs.Show();
            chart_Graphs.Series.Clear();

            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    chart_Graphs.Series.Add(checkBoxes[i].Text);
                    chart_Graphs.Series[chart_Graphs.Series.Count - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    
                    //search substance name
                    for (int j = 0; j < Databank.substances.Count; j++)
                    {
                        if (Databank.substances[j].name == checkBoxes[i].Text)
                        {
                            for (int k = 0; k < Databank.substances[j].data.Count; k++)
                            {
                                double x = Databank.substances[j].data[k].time;
                                double y = Databank.substances[j].data[k].C_mkmol;
                                chart_Graphs.Series[chart_Graphs.Series.Count - 1].Points.AddXY(x, y);
                            }

                            break;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
