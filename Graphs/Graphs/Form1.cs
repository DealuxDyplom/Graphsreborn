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
		AddSubstance addSubstanceForm;

		OpenFileDialog openFileDialog;
		SaveFileDialog saveFileDialog;

		// 0 - меняем столбец m, r
		// 1 - меняем столбец A
		uint column_change = 0;

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

		public void changeTableFromGrpahic()
		{
			double x = 0.011005050817319;
			double y = -1.95840794769216;
			double log_x = Math.Log(x, 10);
			double y_10 = Math.Pow(10, log_x);

			// редактируем таблицу Kinetika_Sorb_La3
			DataGridView table = this.dataGridView_Kinetika_Sorb_La3;
			int rowCount = table.RowCount;
			for (int i = 0; i < rowCount - 1; i++)
			{
				table["Column_Kin_log_qe_qt", i].Value = this.graph.Series[0].Points[i].YValues[0];
			}
			for (int i = 0; i < rowCount - 1; i++)
			{
				double column_kin_qe_qt_i = Math.Pow(10, double.Parse(table["Column_Kin_log_qe_qt", i].Value.ToString()));
				table["Column_Kin_qe_qt", i].Value = column_kin_qe_qt_i;
			}
			double Qe1 = 0.362;
			for (int i = 0; i < rowCount - 1; i++)
			{
				table["Column_Kin_qt_ml", i].Value = Qe1 - double.Parse(table["Column_Kin_qe_qt", i].Value.ToString());
			}

			// редактируем таблицу Bentonit_La3
			table = this.dataGridView_Bentonit_La3;
			rowCount = table.RowCount;
			for (int i = 1; i < rowCount - 1; i++)
			{
				table["Column_qt_ml", i].Value = this.dataGridView_Kinetika_Sorb_La3["Column_Kin_qt_ml", i].Value;
			}
			for (int i = 1; i < rowCount - 1; i++)
			{
				table["Column_qt", i].Value = double.Parse(table["Column_qt_ml", i].Value.ToString()) * 1355;
			}
			if (column_change == 0)
			{
				double C_0 = double.Parse(table["Column_C", 0].Value.ToString());
				for (int i = 1; i < rowCount - 1; i++)
				{
					double column_c_0 = double.Parse(table["Column_C", i].Value.ToString());
					double column_qt_i = double.Parse(table["Column_qt", i].Value.ToString());
					table["Column_m_r", i].Value = (C_0 - column_c_0) * 20 / column_qt_i;

				}
			}
			else if (column_change == 1)
			{
				double C_0 = double.Parse(table["Column_C", 0].Value.ToString());
				for (int i = 1; i < rowCount - 1; i++)
				{
					double column_qt_i = double.Parse(table["Column_qt", i].Value.ToString());
					double column_m_r_i = double.Parse(table["Column_m_r", i].Value.ToString());
					table["Column_C", i].Value = C_0 - (column_qt_i * column_m_r_i / 20);

				}
				for (int i = 1; i < rowCount - 1; i++)
				{
					table["Column_A", i].Value = double.Parse(table["Column_C", i].Value.ToString()) * 0.0158;

				}
			}

		}

		// линия тренда рисуется по точкам на chart
		public void drawTrendLine()
		{
			double X_mean = 0;
			double Y_mean = 0;
			double XY = 0;
			double X2 = 0;
			for (int i = 0; i < this.graph.Series[0].Points.Count; i++)
			{
				X_mean += this.graph.Series[0].Points[i].XValue;
				Y_mean += this.graph.Series[0].Points[i].YValues[0];
				XY += this.graph.Series[0].Points[i].XValue * this.graph.Series[0].Points[i].YValues[0];
				X2 += this.graph.Series[0].Points[i].XValue * this.graph.Series[0].Points[i].XValue;
			}
			X_mean = X_mean / this.graph.Series[0].Points.Count;
			Y_mean = Y_mean / this.graph.Series[0].Points.Count;

			double b = (XY - this.graph.Series[0].Points.Count * X_mean * Y_mean) / (X2 - this.graph.Series[0].Points.Count * X_mean * X_mean);
			double a = Y_mean - b*X_mean;

			//уравнение линии тренда: y = a + bx

			double x1 = this.graph.Series[0].Points[0].XValue;
			double y1 = a + b * x1;
			double x2 = this.graph.Series[0].Points[this.graph.Series[0].Points.Count - 1].XValue;
			double y2 = a + b * x2;

			this.graph.Series[1].Points.Clear();

			this.graph.Series[1].Points.AddXY(x1, y1);
			this.graph.Series[1].Points.AddXY(x2, y2);

			// выводим уравнение линии тренда на экран
			string trend_equ = "y = " + a.ToString("0.0000") + " + (" + b.ToString("0.0000") + ") * x"; 
			this.textBox_Trend_equ.Text = trend_equ;

			// находим R^2 - коэффициент детерминации
			// R^2 = SSE / SST

			double SSE = 0;
			double SSR = 0;
			double Y_sum = 0;
			for (int i = 0; i < this.graph.Series[0].Points.Count; i++)
			{
				Y_sum += a + b * this.graph.Series[0].Points[i].XValue;
			}
			for (int i = 0; i < this.graph.Series[0].Points.Count; i++)
			{
				double y_true = this.graph.Series[0].Points[i].YValues[0];
				double y_get = a + b * this.graph.Series[0].Points[i].XValue;

				SSE += Math.Pow((y_get - y_true), 2);
				SSR += Math.Pow((y_get - Y_mean), 2);
			}
			double SST = SSE + SSR;
			double R2 = 1 - SSE / SST;
			this.textBox_R2.Text = R2.ToString("0.0000");

		}
		public void createGraphics()
		{
			for (int i = 0; i < 6; i++)
			{
				double x = double.Parse(this.dataGridView_Kinetika_Sorb_La3["Column_Kin_time", i].Value.ToString());
				double y = double.Parse(this.dataGridView_Kinetika_Sorb_La3["Column_Kin_log_qe_qt", i].Value.ToString());
				this.graph.Series[0].Points.AddXY(x, y);
			}

			drawTrendLine();
		}
		public Form1()
		{
			InitializeComponent();

			//string path_to_data = "D:\\Repositories\\GitHub\\Graphs\\data.txt";
			//string path_to_data_Kin = "D:\\Repositories\\GitHub\\Graphs\\KinLa3.txt";

			this.splitContainer1.Panel2Collapsed = true;

			((ToolStripMenuItem)changeColumnMRToolStripMenuItem).Checked = true;

			//заполнение таблицы из файла
			//Fill_DataGridView_Bentonit_La3(path_to_data, this.dataGridView_Bentonit_La3);

			//Fill_DataGridView_Kinetika_Sorb_La3(path_to_data_Kin, this.dataGridView_Kinetika_Sorb_La3);

			//this.splitContainer1.Panel2Collapsed = false;
			//createGraphics();

			DataBank.ListOfSubstance = new List<Substance>();

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

			drawTrendLine();
			changeTableFromGrpahic();
		}

		private void изменитьСтолбецMГToolStripMenuItem_Click(object sender, EventArgs e)
		{
			((ToolStripMenuItem)changeColumnMRToolStripMenuItem).Checked = true;
			((ToolStripMenuItem)changeColumnAToolStripMenuItem).Checked = false;
			column_change = 0;
		}

		private void changeColumnAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			((ToolStripMenuItem)changeColumnAToolStripMenuItem).Checked = true;
			((ToolStripMenuItem)changeColumnMRToolStripMenuItem).Checked = false;
			column_change = 1;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Save_Table_ToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void Load_Table_ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				readCSVtoDataGridView_Bentonit_La3(openFileDialog.FileName, this.dataGridView_Bentonit_La3);
			}
		}

        private void button_AddSubstance_Click(object sender, EventArgs e)
        {
			addSubstanceForm = new AddSubstance(this);
			addSubstanceForm.ShowDialog();
            MessageBox.Show("окно закрылось");
			for (int i = 0; i < DataBank.ListOfSubstance.Count; i++)
			{
				//dataGridView_TableOne.Rows[i].Cells[0].Value = DataBank.ListOfSubstance[i].concentration;
				//            dataGridView_TableOne.Rows[i].Cells[1].Value = DataBank.ListOfSubstance[i].m_r;
				//            dataGridView_TableOne.Rows[i].Cells[2].Value = DataBank.ListOfSubstance[i].A;
				//            string[] row = new string[] { DataBank.ListOfSubstance[i].concentration.ToString(), DataBank.ListOfSubstance[i].m_r.ToString(), DataBank.ListOfSubstance[i].A.ToString() };
				//dataGridView_TableOne.Rows.Add(row);
				string[] row = new string[] { DataBank.ListOfSubstance[i].name };
				dataGridView_TableOne.Rows.Add(row);
            }
        }
    }
}
