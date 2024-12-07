using Microsoft.VisualBasic.Logging;
using System.Globalization;
using System.Windows.Forms;

namespace Graphs
{
	public partial class Form1 : Form
	{
		//функция заполнения таблицы из csv файла
		public void readCSVtoDataGridView_Bentonit_La3(string path_to_csv, DataGridView table)
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

		public void readCSVtoDataGridView_Kinetika_Sorb_La3(string path_to_csv, DataGridView table)
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

		public void createGraphics()
		{
			pictureBox_Graphic.Image = new Bitmap(pictureBox_Graphic.Width, pictureBox_Graphic.Height);
			Pen pen = new Pen(Color.Black, 3f);
			using (Graphics g = Graphics.FromImage(pictureBox_Graphic.Image))
			{
				for (int i = 0; i < 6; i++)
				{
					double y = double.Parse(dataGridView_Kinetika_Sorb_La3["Column_Kin_log_qe_qt", i].Value.ToString());
					g.DrawRectangle(new Pen(Color.Black, 4), i + 30*i, (int)y - 50* (int)y, 2, 2);
				}
				//g.DrawRectangle(new Pen(Color.Black, 4), 2, 2, 2, 2);
				//g.DrawLine(new Pen(Color.Black, 4), 0, pictureBox_Graphic.Height / 2, pictureBox_Graphic.Width, pictureBox_Graphic.Height / 2);
			}
		}
		public Form1()
		{
			InitializeComponent();

			string path_to_data = "D:\\Repositories\\GitHub\\Graphs\\data.txt";
			string path_to_data_Kin = "D:\\Repositories\\GitHub\\Graphs\\KinLa3.txt";

			//заполнение таблицы из файла
			readCSVtoDataGridView_Bentonit_La3(path_to_data, this.dataGridView_Bentonit_La3);

			readCSVtoDataGridView_Kinetika_Sorb_La3(path_to_data_Kin, this.dataGridView_Kinetika_Sorb_La3);

			//this.splitContainer1.Panel2Collapsed = false;


			createGraphics();


		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
