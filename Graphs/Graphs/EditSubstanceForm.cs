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
    public partial class EditSubstanceForm: Form
    {
        Form1 parent;
        public EditSubstanceForm(Form1 owner)
        {
            InitializeComponent();
            parent = owner;

            foreach (Substance substance in Databank.substances)
            {
                comboBox1.Items.Add(substance.name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_Data.Rows.Clear();
            dataGridView_Data.Refresh();
            for (int i = 0; i < Databank.substances[comboBox1.SelectedIndex].data.Count; i++)
            {
                string[] rows = { Databank.substances[comboBox1.SelectedIndex].data[i].time.ToString(),
                Databank.substances[comboBox1.SelectedIndex].data[i].m_r.ToString(),
                Databank.substances[comboBox1.SelectedIndex].data[i].A.ToString(),
                Databank.substances[comboBox1.SelectedIndex].data[i].C_mkmol.ToString(),
                Databank.substances[comboBox1.SelectedIndex].data[i].qt_mr.ToString(),
                Databank.substances[comboBox1.SelectedIndex].data[i].qt_ml.ToString(),
                Databank.substances[comboBox1.SelectedIndex].data[i].proc.ToString(),
                Databank.substances[comboBox1.SelectedIndex].data[i].qe_qt.ToString(),
                Databank.substances[comboBox1.SelectedIndex].data[i].log_qe_qt.ToString(),
                Databank.substances[comboBox1.SelectedIndex].data[i].t_qt.ToString()
                };

                dataGridView_Data.Rows.Add(rows);
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

                Databank.substances[comboBox1.SelectedIndex].data.Add(substanceData);
            }
            this.Close();
        }

        private void EditSubstanceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }
    }
}
