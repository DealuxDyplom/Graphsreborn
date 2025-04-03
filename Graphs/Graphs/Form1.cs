using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace Graphs
{
    public partial class Form1: Form
    {
        List<CheckBox> checkBoxes;
        public Form1()
        {
            InitializeComponent();
            Databank.substances = new List<Substance>();
            Databank.graduations = new List<Graduation>();

            Graduation graduation = new Graduation();
            graduation.data = new List<GraduationData>();


            GraduationData graduationData = new GraduationData();
            graduationData.C_mkmol = 5;
            graduationData.A = 0.089;
            graduation.data.Add(graduationData);

            graduationData = new GraduationData();
            graduationData.C_mkmol = 10;
            graduationData.A = 0.165;
            graduation.data.Add(graduationData);

            graduationData = new GraduationData();
            graduationData.C_mkmol = 20;
            graduationData.A = 0.318;
            graduation.data.Add(graduationData);

            graduationData = new GraduationData();
            graduationData.C_mkmol = 30;
            graduationData.A = 0.471;
            graduation.data.Add(graduationData);

            graduation.name = "Градуировка В12/H2O";

            Databank.graduations.Add(graduation);

            checkBoxes = new List<CheckBox>();
            chart_Graphs.Hide();
        }

        #region [ Kinetics ]

        public void fillFlowLayoutCheckboxes()
        {
            chart_Graphs.Series.Clear();
            flowLayoutPanel.Controls.Clear();
            checkBoxes.Clear();

            for (int i = 0; i < Databank.substances.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = Databank.substances[i].name;
                checkBox.CheckedChanged += paintGraphFromCheckbox;
                checkBoxes.Add(checkBox);
                flowLayoutPanel.Controls.Add(checkBox);
            }
        }

        public void updateflowLayoutPanel()
        {
            fillFlowLayoutCheckboxes();
        }

        private void button_AddSubstance_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddSubstanceForm addSubstanceForm = new AddSubstanceForm(this);
            addSubstanceForm.Show();
        }

        private void button_Compare_Click(object sender, EventArgs e)
        {
            //create Graphs
            chart_Graphs.Show();
            chart_Graphs.Series.Clear();
            Random rand = new Random();
            int count_of_checked_checkboxes = 0;
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    count_of_checked_checkboxes++;
                    Series added_series = chart_Graphs.Series.Add(checkBoxes[i].Text);
                    added_series.ChartType = SeriesChartType.Spline;
                    added_series.Color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                    added_series.BorderWidth = 3;

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

                    //paint points
                    for (int j = 0; j < series_with_visible_points.Points.Count; j++)
                    {
                        series_with_visible_points.Points[j].MarkerSize = 10;
                        series_with_visible_points.Points[j].MarkerBorderColor = Color.Black;
                        series_with_visible_points.Points[j].MarkerStyle = MarkerStyle.Circle;
                    }
                }
            }
            if (count_of_checked_checkboxes == 0)
            {
                MessageBox.Show("Ни один раствор не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_EditSubstance_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditSubstanceForm editSubstanceForm = new EditSubstanceForm(this);
            editSubstanceForm.Show();
        }

        private void button_GraduationList_Click(object sender, EventArgs e)
        {
            this.Hide();
            GraduationForm graduationForm = new GraduationForm(this);
            graduationForm.Show();
        }

        private void button_PsevdoGraphs_Click(object sender, EventArgs e)
        {
            int count_of_checked_checkboxes = 0;
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    count_of_checked_checkboxes++;
                    for (int j = 0; j < Databank.substances.Count; j++)
                    {
                        if (checkBoxes[i].Text == Databank.substances[j].name)
                        {
                            PsevdoGraphsForm psevdoGraphsForm = new PsevdoGraphsForm(Databank.substances[j]);
                            psevdoGraphsForm.Show();
                        }
                    }

                }
            }
            if (count_of_checked_checkboxes == 0)
            {
                MessageBox.Show("Ни один раствор не выбран", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paintGraphFromCheckbox(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked) {

                chart_Graphs.Series.Remove(chart_Graphs.Series[((CheckBox)sender).Text]);
                chart_Graphs.Series.Remove(chart_Graphs.Series[((CheckBox)sender).Text + "_Points"]);

                return; 
            }
            chart_Graphs.Show();
            for (int i = 0; i < Databank.substances.Count; i++)
            {
                if (Databank.substances[i].name == ((CheckBox)sender).Text)
                {
                    CheckBox checkBox = ((CheckBox)sender);

                    Random rand = new Random();
                    Series added_series = chart_Graphs.Series.Add(checkBox.Text);
                    added_series.ChartType = SeriesChartType.Spline;
                    //to make graph more smooth
                    added_series.SetCustomProperty("LineTension", "0.2");
                    added_series.Color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                    added_series.BorderWidth = 3;

                    Series series_with_visible_points = chart_Graphs.Series.Add(checkBox.Text + "_Points");
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

                    //paint points
                    for (int j = 0; j < series_with_visible_points.Points.Count; j++)
                    {
                        series_with_visible_points.Points[j].MarkerSize = 10;
                        series_with_visible_points.Points[j].MarkerBorderColor = Color.Black;
                        series_with_visible_points.Points[j].MarkerStyle = MarkerStyle.Circle;
                    }
                }
            }
        }

        #endregion

        #region [Menu]
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var json = JsonConvert.SerializeObject(Databank.substances);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName, true))
                {
                    writer.WriteLine(json);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                string json = reader.ReadToEnd();
                Console.Write(json);
                Databank.substances.Clear();
                Databank.substances = JsonConvert.DeserializeObject<List<Substance>>(json);

                //add new checkboxes
                fillFlowLayoutCheckboxes();
            }
        }

        private void сохранитьГрадуировкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var json = JsonConvert.SerializeObject(Databank.graduations);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName, true))
                {
                    writer.WriteLine(json);
                }
            }
        }

        private void загрузитьГрадуировкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                string json = reader.ReadToEnd();
                Console.Write(json);
                Databank.graduations.Clear();
                Databank.graduations = JsonConvert.DeserializeObject<List<Graduation>>(json);
            }
        }


        #endregion
    }
}
