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
            Label label_listSubstances = new Label();
            label_listSubstances.Text = "Список растворов:";
            flowLayoutPanel.Controls.Add(label_listSubstances);
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
                    Series added_series = chart_Graphs.Series.Add(checkBoxes[i].Text);
                    added_series.ChartType = SeriesChartType.Spline;
                    added_series.Color = Color.Black;

                    Series series_with_visible_points = chart_Graphs.Series.Add(i.ToString());
                    series_with_visible_points.ChartType = SeriesChartType.Point;
                    series_with_visible_points.IsVisibleInLegend = false;
                    series_with_visible_points.Color = added_series.Color;

                    //add null data into series
                    added_series.Points.AddXY(0, 0);
                    series_with_visible_points.Points.AddXY(0, 0);

                    //search substance name
                    for (int j = 0; j < Databank.substances.Count; j++)
                    {
                        if (Databank.substances[j].name == checkBoxes[i].Text)
                        {
                            for (int k = 0; k < Databank.substances[j].data.Count; k++)
                            {
                                double x = Databank.substances[j].data[k].time;
                                double y = Databank.substances[j].data[k].qt_ml;
                                added_series.Points.AddXY(x, y);
                                series_with_visible_points.Points.AddXY(x, y);
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
