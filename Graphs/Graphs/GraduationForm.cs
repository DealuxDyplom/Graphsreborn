using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Graphs
{
    public partial class GraduationForm: Form
    {
        List<RadioButton> radioButtons;
        public GraduationForm()
        {
            radioButtons = new List<RadioButton>();
            InitializeComponent();

            foreach (Graduation graduation in Databank.graduations)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Text = graduation.name;
                radioButton.AutoSize = true;

                radioButton.CheckedChanged += radioButton_CheckedChanged;

                radioButtons.Add(radioButton);
                flowLayoutPanel1.Controls.Add(radioButton);
            }
        }

        private void button_AddGraduation_Click(object sender, EventArgs e)
        {
            AddGraduation addGraduationForm = new AddGraduation(this);
            addGraduationForm.Show();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView_GraduationData.Rows.Clear();
            dataGridView_GraduationData.Refresh();

            for (int i = 0; i < Databank.graduations.Count; i++)
            {
                if (Databank.graduations[i].name == ((RadioButton)sender).Text)
                {
                    for (int j = 0; j < Databank.graduations[i].data.Count; j++)
                    {
                        string[] row = { Databank.graduations[i].data[j].C_mkmol.ToString(), Databank.graduations[i].data[j].A.ToString() };
                        dataGridView_GraduationData.Rows.Add(row);
                    }
                    return;
                }
            }
        }

        public void updateGroupBoxwithRadioButtons()
        {
            flowLayoutPanel1.Controls.Clear();
            radioButtons.Clear();
            foreach (Graduation graduation in Databank.graduations)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Text = graduation.name;
                radioButton.AutoSize = true;

                radioButton.CheckedChanged += radioButton_CheckedChanged;

                radioButtons.Add(radioButton);
                flowLayoutPanel1.Controls.Add(radioButton);
            }
        }

        private void button_EditGraduation_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].Checked)
                {
                    for (int j = 0; j < Databank.graduations.Count; j++)
                    {
                        if (radioButtons[i].Text == Databank.graduations[j].name)
                        {
                            MessageBox.Show(radioButtons[i].Text);

                            Databank.graduations[j].data.Clear();
                            for (int k = 0; k < dataGridView_GraduationData.Rows.Count - 1; k++)
                            {
                                GraduationData graduationData = new GraduationData();
                                graduationData.C_mkmol = Convert.ToDouble(dataGridView_GraduationData["dataGridView_GraduationData_Column_C_mkmol", k].Value);
                                graduationData.A = Convert.ToDouble(dataGridView_GraduationData["dataGridView_GraduationData_Column_A", k].Value);
                                Databank.graduations[j].data.Add(graduationData);
                            }
                            return;
                        }
                    }
                    MessageBox.Show("Выбранная градуировка не найдена", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Ни одна градуировка не выбрана", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}
