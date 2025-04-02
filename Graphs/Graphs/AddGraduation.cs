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
    public partial class AddGraduation: Form
    {
        GraduationForm parentForm;

        public AddGraduation(GraduationForm owner)
        {
            parentForm = owner;
            InitializeComponent();
        }

        private void button_FillFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            //очищаем таблицу
            dataGridView_GraduationData.Rows.Clear();
            dataGridView_GraduationData.Refresh();

            //чтение данных
            if (openFileDialog.FileName != "")
            {
                string[] rows = File.ReadAllLines(openFileDialog.FileName);

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split('|');
                    dataGridView_GraduationData.Rows.Add(columns);
                }
            }
        }

        private void button_AddGraduation_Click(object sender, EventArgs e)
        {
            //error handling
            if (textBox_GraduationName.Text == "")
            {
                MessageBox.Show("Введите название градуировки", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView_GraduationData.Rows.Count <= 1)
            {
                MessageBox.Show("Заполните таблицу градуировки", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Graduation graduation = new Graduation();
            graduation.data = new List<GraduationData>();
            graduation.name = textBox_GraduationName.Text;

            for (int i = 0; i < dataGridView_GraduationData.Rows.Count - 1; i++)
            {
                GraduationData graduationData = new GraduationData();
                graduationData.C_mkmol = Convert.ToDouble(dataGridView_GraduationData["dataGridView_GraduationData_Column_C_mkmol", i].Value.ToString().Replace(".", ","));
                graduationData.A = Convert.ToDouble(dataGridView_GraduationData["dataGridView_GraduationData_Column_A", i].Value.ToString().Replace(".", ","));
                graduation.data.Add(graduationData);
            }
            Databank.graduations.Add(graduation);
            this.Close();
        }

        private void AddGraduation_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.updateGroupBoxwithRadioButtons();
            parentForm.Show();
        }
    }
}
