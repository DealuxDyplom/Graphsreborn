using System.Globalization;

namespace Graphs
{
	public partial class Form1 : Form
	{
		string path_to_data = "D:\\Repositories\\GitHub\\Graphs\\data.txt";
		//функция заполнения таблицы из csv файла
		public void readCSVtoDataGriedView(string path_to_csv, DataGridView table)
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
		public Form1()
		{
			InitializeComponent();

			//заполнение таблицы из файла
			readCSVtoDataGriedView(path_to_data, this.dataGridView_Bentonit_La3);


		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}
	}
}
