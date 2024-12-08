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

namespace Graphs
{
	public partial class Form1 : Form
	{
		OpenFileDialog openFileDialog;
		SaveFileDialog saveFileDialog;

		int pointIndex = -1; //индекс точки на графике

		//функция начального заполнения таблицы из csv файла (чтобы они не пустовали при открытии)
		public void Fill_DataGridView_Bentonit_La3(string path_to_csv, DataGridView table)
		{
			//чтение данных
			string[] rows = File.ReadAllLines(path_to_csv);

			for (int i = 1; i < rows.Length; i++)
			{
				string[] columns = rows[i].Split('|');
				table.Rows.Add();
				for (int j = 0; j < columns.Length; j++)
				{
					table.Rows[i - 1].Cells[j].Value = columns[j];
				}
			}

			//заполнение ячеек по формулам

			//заполнение столбца "С,мкг/мл"
			for (int i = 0; i < rows.Length - 1; i++)
			{
				table["Column_C", i].Value = (double.Parse(table["Column_A", i].Value.ToString()) / 0.0158).ToString(); //CultureInfo.InvariantCulture чтобы распознавалась ".", а не ","

			}
			//заполнение столбца "qt, мкг/г"
			double column_c_0 = double.Parse(table["Column_C", 0].Value.ToString());
			for (int i = 1; i < rows.Length - 1; i++)
			{
				double column_c_i = double.Parse(table["Column_C", i].Value.ToString());
				double column_m_r_i = double.Parse(table["Column_m_r", i].Value.ToString());
				table["Column_qt", i].Value = (column_c_0 - column_c_i) * 20 / column_m_r_i;

			}
			//заполнение столбца "qt, μмоль/г"
			for (int i = 1; i < rows.Length - 1; i++)
			{
				table["Column_qt_ml", i].Value = double.Parse(table["Column_qt", i].Value.ToString()) / 1355;

			}
			//заполнение столбца "%"
			column_c_0 = double.Parse(table["Column_C", 0].Value.ToString());
			for (int i = 1; i < rows.Length - 1; i++)
			{
				double column_c_i = double.Parse(table["Column_C", i].Value.ToString());
				table["Column_proc", i].Value = (column_c_0 - column_c_i) / column_c_0 * 100;

			}
		}

		public void Fill_DataGridView_Kinetika_Sorb_La3(string path_to_csv, DataGridView table)
		{
			//чтение данных
			string[] rows = File.ReadAllLines(path_to_csv);

			for (int i = 1; i < rows.Length; i++)
			{
				string[] columns = rows[i].Split('|');
				table.Rows.Add();
				for (int j = 0; j < columns.Length; j++)
				{
					table.Rows[i - 1].Cells[j].Value = columns[j];
				}
			}

			//зваполнение столбца "qt, μмоль/г"
			for (int i = 0; i < rows.Length - 1; i++)
			{
				table["Column_Kin_qt_ml", i].Value = this.dataGridView_Bentonit_La3["Column_qt_ml", i].Value;
			}

			//заполнение столбца "qe-qt"
			double Qe1 = 0.362;
			for (int i = 0; i < rows.Length - 1; i++)
			{
				double Kin_qt_ml_i = double.Parse(table["Column_Kin_qt_ml", i].Value.ToString());
				table["Column_Kin_qe_qt", i].Value = Qe1 - Kin_qt_ml_i;
			}

			//заполнение столбца "log(qe-qt)"
			for (int i = 0; i < rows.Length - 1; i++)
			{
				table["Column_Kin_log_qe_qt", i].Value = Math.Log(double.Parse(table["Column_Kin_qe_qt", i].Value.ToString()), 10);
			}

			//заполнение столбца "t\qt"
			for (int i = 1; i < rows.Length - 1; i++)
			{
				double column_Kin_time_i = double.Parse(table["Column_Kin_time", i].Value.ToString());
				double column_Kin_qt_ml_i = double.Parse(table["Column_Kin_qt_ml", i].Value.ToString());
				table["Column_Kin_t_qt", i].Value = column_Kin_time_i / column_Kin_qt_ml_i;
			}
		}

		public void readCSVtoDataGridView_Bentonit_La3(string path_to_csv, DataGridView table)
		{
			//очищаем таблицу
			table.Rows.Clear();
			table.Refresh();

			//чтение данных
			string[] rows = File.ReadAllLines(path_to_csv);

			for (int i = 1; i < rows.Length; i++)
			{
				string[] columns = rows[i].Split('|');
				table.Rows.Add();
				for (int j = 0; j < columns.Length; j++)
				{
					table.Rows[i - 1].Cells[j].Value = columns[j];
				}
			}
		}

		public void readCSVtoDataGridView_Kinetika_Sorb_La3(string path_to_csv, DataGridView table)
		{
			//очищаем таблицу
			table.Rows.Clear();
			table.Refresh();

			//чтение данных
			string[] rows = File.ReadAllLines(path_to_csv);

			for (int i = 1; i < rows.Length; i++)
			{
				string[] columns = rows[i].Split('|');
				table.Rows.Add();
				for (int j = 0; j < columns.Length; j++)
				{
					table.Rows[i - 1].Cells[j].Value = columns[j];
				}
			}
		}

		public void createGraphics()
		{
			for (int i = 0; i < 6; i++)
			{
				double x = double.Parse(this.dataGridView_Kinetika_Sorb_La3["Column_Kin_time", i].Value.ToString());
				double y = double.Parse(this.dataGridView_Kinetika_Sorb_La3["Column_Kin_log_qe_qt", i].Value.ToString());
				this.graph.Series[0].Points.AddXY(x, y);
			}
		}
		public Form1()
		{
			InitializeComponent();

			//string path_to_data = "D:\\Repositories\\GitHub\\Graphs\\data.txt";
			//string path_to_data_Kin = "D:\\Repositories\\GitHub\\Graphs\\KinLa3.txt";

			this.splitContainer1.Panel2Collapsed = true;

			//заполнение таблицы из файла
			//Fill_DataGridView_Bentonit_La3(path_to_data, this.dataGridView_Bentonit_La3);

			//Fill_DataGridView_Kinetika_Sorb_La3(path_to_data_Kin, this.dataGridView_Kinetika_Sorb_La3);

			//this.splitContainer1.Panel2Collapsed = false;
			//createGraphics();


		}

		private void Button_Load_Click(object sender, EventArgs e)
		{
			openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				readCSVtoDataGridView_Bentonit_La3(openFileDialog.FileName, this.dataGridView_Bentonit_La3);
			}
		}

		private void button_Recalculate_Click(object sender, EventArgs e)
		{
			int rowCount = this.dataGridView_Bentonit_La3.RowCount;
			DataGridView table = this.dataGridView_Bentonit_La3;
			//заполнение ячеек по формулам

			//заполнение таблицы Benronit_La3
			//заполнение столбца "С,мкг/мл"
			for (int i = 0; i < rowCount - 1; i++)
			{
				table["Column_C", i].Value = (double.Parse(table["Column_A", i].Value.ToString()) / 0.0158).ToString(); //CultureInfo.InvariantCulture чтобы распознавалась ".", а не ","

			}
			//заполнение столбца "qt, мкг/г"
			double column_c_0 = double.Parse(table["Column_C", 0].Value.ToString());
			for (int i = 1; i < rowCount - 1; i++)
			{
				double column_c_i = double.Parse(table["Column_C", i].Value.ToString());
				double column_m_r_i = double.Parse(table["Column_m_r", i].Value.ToString());
				table["Column_qt", i].Value = (column_c_0 - column_c_i) * 20 / column_m_r_i;

			}
			//заполнение столбца "qt, μмоль/г"
			for (int i = 1; i < rowCount - 1; i++)
			{
				table["Column_qt_ml", i].Value = double.Parse(table["Column_qt", i].Value.ToString()) / 1355;

			}
			//заполнение столбца "%"
			column_c_0 = double.Parse(table["Column_C", 0].Value.ToString());
			for (int i = 1; i < rowCount - 1; i++)
			{
				double column_c_i = double.Parse(table["Column_C", i].Value.ToString());
				table["Column_proc", i].Value = (column_c_0 - column_c_i) / column_c_0 * 100;

			}

			table = this.dataGridView_Kinetika_Sorb_La3;
			//заполнение таблицы Kinetika_Sorb_La3
			table.Rows.Clear();
			table.Refresh();
			for (int i = 0; i < this.dataGridView_Bentonit_La3.RowCount - 1; i++)
			{
				table.Rows.Add();
			}
			rowCount = this.dataGridView_Kinetika_Sorb_La3.RowCount;
			//заполнение столбца "обр\врем"
			for (int i = 0; i < rowCount - 1; i++)
			{
				table["Column_Kin_time", i].Value = this.dataGridView_Bentonit_La3["Column_time", i].Value;
			}
			//зваполнение столбца "qt, μмоль/г"
			for (int i = 0; i < rowCount - 1; i++)
			{
				table["Column_Kin_qt_ml", i].Value = this.dataGridView_Bentonit_La3["Column_qt_ml", i].Value;
			}

			//заполнение столбца "qe-qt"
			double Qe1 = 0.362;
			for (int i = 0; i < rowCount - 1; i++)
			{
				double Kin_qt_ml_i = double.Parse(table["Column_Kin_qt_ml", i].Value.ToString());
				table["Column_Kin_qe_qt", i].Value = Qe1 - Kin_qt_ml_i;
			}

			//заполнение столбца "log(qe-qt)"
			for (int i = 0; i < rowCount - 1; i++)
			{
				table["Column_Kin_log_qe_qt", i].Value = Math.Log(double.Parse(table["Column_Kin_qe_qt", i].Value.ToString()), 10);
			}

			//заполнение столбца "t\qt"
			for (int i = 1; i < rowCount - 1; i++)
			{
				double column_Kin_time_i = double.Parse(table["Column_Kin_time", i].Value.ToString());
				double column_Kin_qt_ml_i = double.Parse(table["Column_Kin_qt_ml", i].Value.ToString());
				table["Column_Kin_t_qt", i].Value = column_Kin_time_i / column_Kin_qt_ml_i;
			}

			//перечерчиваем график
			this.splitContainer1.Panel2Collapsed = false;
			this.graph.Series[0].Points.Clear();
			createGraphics();
		}

		private void button_Save_Click(object sender, EventArgs e)
		{
			saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
				//string[] strings = new string[this.dataGridView_Bentonit_La3.RowCount];
				string title = "time|m|A|C|qt|qtm|%";
				sw.WriteLine(title);
				//strings[0] = title;
				for (int i = 0; i < this.dataGridView_Bentonit_La3.RowCount - 1; i++)
				{
					for (int j = 0; j < this.dataGridView_Bentonit_La3.ColumnCount; j++)
					{
						sw.Write(this.dataGridView_Bentonit_La3.Rows[i].Cells[j].Value);
						if (j != this.dataGridView_Bentonit_La3.ColumnCount - 1)
						{
							sw.Write("|");
						}
					}
					sw.WriteLine();
				}
				sw.Close();
			}
		}

		private void graph_Click(object sender, EventArgs e)
		{
		}

		private void graph_MouseClick(object sender, MouseEventArgs e)
		{
			var res = graph.HitTest(e.X, e.Y);
			if (res.Series != null)
			{
				if (pointIndex != -1) {
					res.Series.Points[pointIndex].BorderColor = res.Series.Points[pointIndex].Color;
				}
				pointIndex = res.PointIndex;
				res.Series.Points[pointIndex].BorderColor = Color.Red;

				this.textBox_X_Value.Text = res.Series.Points[pointIndex].XValue.ToString();
				this.textBox_Y_Value.Text = res.Series.Points[pointIndex].YValues[0].ToString();
			}

		}

		private void button_Change_Point_Click(object sender, EventArgs e)
		{
			if (pointIndex == -1)
			{
				return;
			}
			double x = double.Parse(this.textBox_X_Value.Text);
			double y = double.Parse(this.textBox_Y_Value.Text);
			this.graph.Series[0].Points[pointIndex].SetValueXY(x, y);
			this.graph.Series[0].Points[pointIndex].BorderColor = this.graph.Series[0].Points[pointIndex].Color;

			pointIndex = -1;
		}
	}
}
