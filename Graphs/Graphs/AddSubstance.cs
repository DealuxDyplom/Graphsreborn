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
        OpenFileDialog openFileDialog;
        SubstanceData substanceData;
        Substance substance;
        public AddSubstance(Form1 owner)
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView_Substance.RowCount - 1; i++)
            {
                substanceData.concentration = double.Parse(dataGridView_Substance.Rows[i].Cells[0].Value.ToString());
                substanceData.A_src = double.Parse(dataGridView_Substance.Rows[i].Cells[1].Value.ToString());
                substanceData.m_r = double.Parse(dataGridView_Substance.Rows[i].Cells[2].Value.ToString());
                substanceData.A = double.Parse(dataGridView_Substance.Rows[i].Cells[3].Value.ToString());

                substanceData.C_mkmol_l_src = ((substanceData.A_src / 0.0157) / 1355.38) * 1000;
                substanceData.C_mkmol_l = (((substanceData.A / 0.0157) / 1355.38)) * 1000;
                substanceData.Q_ml = (substanceData.C_mkmol_l_src - substanceData.C_mkmol_l) * 0.02 / substanceData.m_r;

                dataGridView_Substance.Rows[i].Cells[4].Value = substanceData.C_mkmol_l_src;
                dataGridView_Substance.Rows[i].Cells[5].Value = substanceData.C_mkmol_l;
                dataGridView_Substance.Rows[i].Cells[6].Value = substanceData.Q_ml;
                substance.data = new List<SubstanceData>();
                substance.data.Add(substanceData);
            }
            substance.name = textBox_NameSubstance.Text;
            DataBank.ListOfSubstance.Add(substance);
        }

        private void button_FillFromFile_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //очищаем таблицу
                dataGridView_Substance.Rows.Clear();
                dataGridView_Substance.Refresh();

                //чтение данных
                string path_to_csv = openFileDialog.FileName;
                string[] rows = File.ReadAllLines(path_to_csv);

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split('|');
                    dataGridView_Substance.Rows.Add();
                    for (int j = 0; j < columns.Length; j++)
                    {
                        dataGridView_Substance.Rows[i - 1].Cells[j].Value = columns[j];
                    }
                }
            }
        }

        private void button_Calculate_Click(object sender, EventArgs e)
        {

        }
    }
}
