namespace Graphs
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.tableLayoutPanel_Tables = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel_Bentonit_La3 = new System.Windows.Forms.TableLayoutPanel();
			this.label_Bent = new System.Windows.Forms.Label();
			this.dataGridView_Bentonit_La3 = new System.Windows.Forms.DataGridView();
			this.Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_m_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_qt_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_proc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tableLayoutPanel_Kinetika_Sorb_La3 = new System.Windows.Forms.TableLayoutPanel();
			this.label_Kinetika_Sorb_La3 = new System.Windows.Forms.Label();
			this.dataGridView_Kinetika_Sorb_La3 = new System.Windows.Forms.DataGridView();
			this.Column_Kin_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_qt_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_log_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_t_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label_Title = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel_Graph_with_buttons = new System.Windows.Forms.TableLayoutPanel();
			this.graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel_text_for_graphs = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel_X_Value = new System.Windows.Forms.TableLayoutPanel();
			this.textBox_X_Value = new System.Windows.Forms.TextBox();
			this.label_X_value = new System.Windows.Forms.Label();
			this.tableLayoutPanel_Y_Value = new System.Windows.Forms.TableLayoutPanel();
			this.label_Y_Value = new System.Windows.Forms.Label();
			this.textBox_Y_Value = new System.Windows.Forms.TextBox();
			this.button_Change_Point = new System.Windows.Forms.Button();
			this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel_Buttons = new System.Windows.Forms.TableLayoutPanel();
			this.Button_Load = new System.Windows.Forms.Button();
			this.button_Save = new System.Windows.Forms.Button();
			this.button_Recalculate = new System.Windows.Forms.Button();
			this.tableLayout_Trend_param = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.textBox_Trend_equ = new System.Windows.Forms.TextBox();
			this.label_Trend_equ = new System.Windows.Forms.Label();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.label_R2 = new System.Windows.Forms.Label();
			this.textBox_R2 = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel_Tables.SuspendLayout();
			this.tableLayoutPanel_Bentonit_La3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bentonit_La3)).BeginInit();
			this.tableLayoutPanel_Kinetika_Sorb_La3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Kinetika_Sorb_La3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel_Graph_with_buttons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
			this.tableLayoutPanel_text_for_graphs.SuspendLayout();
			this.tableLayoutPanel_X_Value.SuspendLayout();
			this.tableLayoutPanel_Y_Value.SuspendLayout();
			this.tableLayoutPanel_Main.SuspendLayout();
			this.tableLayoutPanel_Buttons.SuspendLayout();
			this.tableLayout_Trend_param.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel_Tables
			// 
			this.tableLayoutPanel_Tables.AutoSize = true;
			this.tableLayoutPanel_Tables.ColumnCount = 1;
			this.tableLayoutPanel_Tables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel_Tables.Controls.Add(this.tableLayoutPanel_Bentonit_La3, 0, 1);
			this.tableLayoutPanel_Tables.Controls.Add(this.tableLayoutPanel_Kinetika_Sorb_La3, 0, 2);
			this.tableLayoutPanel_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Tables.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel_Tables.Name = "tableLayoutPanel_Tables";
			this.tableLayoutPanel_Tables.RowCount = 3;
			this.tableLayoutPanel_Tables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Tables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Tables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Tables.Size = new System.Drawing.Size(728, 481);
			this.tableLayoutPanel_Tables.TabIndex = 0;
			// 
			// tableLayoutPanel_Bentonit_La3
			// 
			this.tableLayoutPanel_Bentonit_La3.ColumnCount = 1;
			this.tableLayoutPanel_Bentonit_La3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Bentonit_La3.Controls.Add(this.label_Bent, 0, 0);
			this.tableLayoutPanel_Bentonit_La3.Controls.Add(this.dataGridView_Bentonit_La3, 0, 1);
			this.tableLayoutPanel_Bentonit_La3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Bentonit_La3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel_Bentonit_La3.Name = "tableLayoutPanel_Bentonit_La3";
			this.tableLayoutPanel_Bentonit_La3.RowCount = 2;
			this.tableLayoutPanel_Bentonit_La3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Bentonit_La3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Bentonit_La3.Size = new System.Drawing.Size(722, 234);
			this.tableLayoutPanel_Bentonit_La3.TabIndex = 1;
			// 
			// label_Bent
			// 
			this.label_Bent.AutoSize = true;
			this.label_Bent.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Bent.Location = new System.Drawing.Point(3, 0);
			this.label_Bent.Name = "label_Bent";
			this.label_Bent.Size = new System.Drawing.Size(716, 13);
			this.label_Bent.TabIndex = 0;
			this.label_Bent.Text = "Бентонит La3+ 0,7 (20°C) мкг/мл";
			this.label_Bent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// dataGridView_Bentonit_La3
			// 
			this.dataGridView_Bentonit_La3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_Bentonit_La3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Bentonit_La3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_time,
            this.Column_m_r,
            this.Column_A,
            this.Column_C,
            this.Column_qt,
            this.Column_qt_ml,
            this.Column_proc});
			this.dataGridView_Bentonit_La3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_Bentonit_La3.Location = new System.Drawing.Point(3, 16);
			this.dataGridView_Bentonit_La3.Name = "dataGridView_Bentonit_La3";
			this.dataGridView_Bentonit_La3.Size = new System.Drawing.Size(716, 215);
			this.dataGridView_Bentonit_La3.TabIndex = 1;
			// 
			// Column_time
			// 
			this.Column_time.HeaderText = "обр\\врем";
			this.Column_time.Name = "Column_time";
			// 
			// Column_m_r
			// 
			this.Column_m_r.HeaderText = "m, г";
			this.Column_m_r.Name = "Column_m_r";
			// 
			// Column_A
			// 
			this.Column_A.HeaderText = "А";
			this.Column_A.Name = "Column_A";
			// 
			// Column_C
			// 
			this.Column_C.HeaderText = "С,мкг/мл";
			this.Column_C.Name = "Column_C";
			// 
			// Column_qt
			// 
			this.Column_qt.HeaderText = "qt, мкг/г";
			this.Column_qt.Name = "Column_qt";
			// 
			// Column_qt_ml
			// 
			this.Column_qt_ml.HeaderText = "qt, μмоль/г";
			this.Column_qt_ml.Name = "Column_qt_ml";
			// 
			// Column_proc
			// 
			this.Column_proc.HeaderText = "%";
			this.Column_proc.Name = "Column_proc";
			// 
			// tableLayoutPanel_Kinetika_Sorb_La3
			// 
			this.tableLayoutPanel_Kinetika_Sorb_La3.ColumnCount = 1;
			this.tableLayoutPanel_Kinetika_Sorb_La3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Kinetika_Sorb_La3.Controls.Add(this.label_Kinetika_Sorb_La3, 0, 0);
			this.tableLayoutPanel_Kinetika_Sorb_La3.Controls.Add(this.dataGridView_Kinetika_Sorb_La3, 0, 1);
			this.tableLayoutPanel_Kinetika_Sorb_La3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 243);
			this.tableLayoutPanel_Kinetika_Sorb_La3.Name = "tableLayoutPanel_Kinetika_Sorb_La3";
			this.tableLayoutPanel_Kinetika_Sorb_La3.RowCount = 2;
			this.tableLayoutPanel_Kinetika_Sorb_La3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Kinetika_Sorb_La3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Kinetika_Sorb_La3.Size = new System.Drawing.Size(722, 235);
			this.tableLayoutPanel_Kinetika_Sorb_La3.TabIndex = 2;
			// 
			// label_Kinetika_Sorb_La3
			// 
			this.label_Kinetika_Sorb_La3.AutoSize = true;
			this.label_Kinetika_Sorb_La3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 0);
			this.label_Kinetika_Sorb_La3.Name = "label_Kinetika_Sorb_La3";
			this.label_Kinetika_Sorb_La3.Size = new System.Drawing.Size(716, 13);
			this.label_Kinetika_Sorb_La3.TabIndex = 0;
			this.label_Kinetika_Sorb_La3.Text = "Кинетика сорбции La3+ 0,7 (20°C) мкг/мл";
			this.label_Kinetika_Sorb_La3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// dataGridView_Kinetika_Sorb_La3
			// 
			this.dataGridView_Kinetika_Sorb_La3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_Kinetika_Sorb_La3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Kinetika_Sorb_La3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Kin_time,
            this.Column_Kin_qt_ml,
            this.Column_Kin_qe_qt,
            this.Column_Kin_log_qe_qt,
            this.Column_Kin_t_qt});
			this.dataGridView_Kinetika_Sorb_La3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 16);
			this.dataGridView_Kinetika_Sorb_La3.Name = "dataGridView_Kinetika_Sorb_La3";
			this.dataGridView_Kinetika_Sorb_La3.Size = new System.Drawing.Size(716, 216);
			this.dataGridView_Kinetika_Sorb_La3.TabIndex = 1;
			// 
			// Column_Kin_time
			// 
			this.Column_Kin_time.HeaderText = "обр\\врем";
			this.Column_Kin_time.Name = "Column_Kin_time";
			// 
			// Column_Kin_qt_ml
			// 
			this.Column_Kin_qt_ml.HeaderText = "qt, μмоль/г";
			this.Column_Kin_qt_ml.Name = "Column_Kin_qt_ml";
			// 
			// Column_Kin_qe_qt
			// 
			this.Column_Kin_qe_qt.HeaderText = "qe-qt";
			this.Column_Kin_qe_qt.Name = "Column_Kin_qe_qt";
			// 
			// Column_Kin_log_qe_qt
			// 
			this.Column_Kin_log_qe_qt.HeaderText = "log(qe-qt)";
			this.Column_Kin_log_qe_qt.Name = "Column_Kin_log_qe_qt";
			// 
			// Column_Kin_t_qt
			// 
			this.Column_Kin_t_qt.HeaderText = "t\\qt";
			this.Column_Kin_t_qt.Name = "Column_Kin_t_qt";
			// 
			// label_Title
			// 
			this.label_Title.AutoSize = true;
			this.label_Title.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label_Title.Location = new System.Drawing.Point(3, 0);
			this.label_Title.Name = "label_Title";
			this.label_Title.Size = new System.Drawing.Size(1220, 25);
			this.label_Title.TabIndex = 0;
			this.label_Title.Text = "Graphs";
			this.label_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 28);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel_Tables);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel_Graph_with_buttons);
			this.splitContainer1.Size = new System.Drawing.Size(1220, 481);
			this.splitContainer1.SplitterDistance = 728;
			this.splitContainer1.TabIndex = 1;
			// 
			// tableLayoutPanel_Graph_with_buttons
			// 
			this.tableLayoutPanel_Graph_with_buttons.ColumnCount = 1;
			this.tableLayoutPanel_Graph_with_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Graph_with_buttons.Controls.Add(this.graph, 0, 0);
			this.tableLayoutPanel_Graph_with_buttons.Controls.Add(this.tableLayoutPanel_text_for_graphs, 0, 2);
			this.tableLayoutPanel_Graph_with_buttons.Controls.Add(this.button_Change_Point, 0, 3);
			this.tableLayoutPanel_Graph_with_buttons.Controls.Add(this.tableLayout_Trend_param, 0, 1);
			this.tableLayoutPanel_Graph_with_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Graph_with_buttons.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel_Graph_with_buttons.Name = "tableLayoutPanel_Graph_with_buttons";
			this.tableLayoutPanel_Graph_with_buttons.RowCount = 4;
			this.tableLayoutPanel_Graph_with_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Graph_with_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel_Graph_with_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel_Graph_with_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Graph_with_buttons.Size = new System.Drawing.Size(488, 481);
			this.tableLayoutPanel_Graph_with_buttons.TabIndex = 1;
			// 
			// graph
			// 
			chartArea1.Name = "ChartArea1";
			this.graph.ChartAreas.Add(chartArea1);
			this.graph.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			this.graph.Legends.Add(legend1);
			this.graph.Location = new System.Drawing.Point(3, 3);
			this.graph.Name = "graph";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "TrendLine";
			this.graph.Series.Add(series1);
			this.graph.Series.Add(series2);
			this.graph.Size = new System.Drawing.Size(482, 376);
			this.graph.TabIndex = 0;
			this.graph.Text = "График";
			this.graph.Click += new System.EventHandler(this.graph_Click);
			this.graph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graph_MouseClick);
			// 
			// tableLayoutPanel_text_for_graphs
			// 
			this.tableLayoutPanel_text_for_graphs.ColumnCount = 2;
			this.tableLayoutPanel_text_for_graphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_text_for_graphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_text_for_graphs.Controls.Add(this.tableLayoutPanel_X_Value, 0, 0);
			this.tableLayoutPanel_text_for_graphs.Controls.Add(this.tableLayoutPanel_Y_Value, 1, 0);
			this.tableLayoutPanel_text_for_graphs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_text_for_graphs.Location = new System.Drawing.Point(3, 415);
			this.tableLayoutPanel_text_for_graphs.Name = "tableLayoutPanel_text_for_graphs";
			this.tableLayoutPanel_text_for_graphs.RowCount = 1;
			this.tableLayoutPanel_text_for_graphs.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_text_for_graphs.Size = new System.Drawing.Size(482, 34);
			this.tableLayoutPanel_text_for_graphs.TabIndex = 1;
			// 
			// tableLayoutPanel_X_Value
			// 
			this.tableLayoutPanel_X_Value.ColumnCount = 2;
			this.tableLayoutPanel_X_Value.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_X_Value.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_X_Value.Controls.Add(this.textBox_X_Value, 1, 0);
			this.tableLayoutPanel_X_Value.Controls.Add(this.label_X_value, 0, 0);
			this.tableLayoutPanel_X_Value.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_X_Value.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel_X_Value.Name = "tableLayoutPanel_X_Value";
			this.tableLayoutPanel_X_Value.RowCount = 1;
			this.tableLayoutPanel_X_Value.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_X_Value.Size = new System.Drawing.Size(235, 100);
			this.tableLayoutPanel_X_Value.TabIndex = 0;
			// 
			// textBox_X_Value
			// 
			this.textBox_X_Value.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox_X_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox_X_Value.Location = new System.Drawing.Point(120, 3);
			this.textBox_X_Value.Name = "textBox_X_Value";
			this.textBox_X_Value.Size = new System.Drawing.Size(112, 22);
			this.textBox_X_Value.TabIndex = 1;
			// 
			// label_X_value
			// 
			this.label_X_value.AutoSize = true;
			this.label_X_value.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_X_value.Location = new System.Drawing.Point(3, 0);
			this.label_X_value.Name = "label_X_value";
			this.label_X_value.Size = new System.Drawing.Size(111, 13);
			this.label_X_value.TabIndex = 0;
			this.label_X_value.Text = "X";
			this.label_X_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tableLayoutPanel_Y_Value
			// 
			this.tableLayoutPanel_Y_Value.ColumnCount = 2;
			this.tableLayoutPanel_Y_Value.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Y_Value.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Y_Value.Controls.Add(this.label_Y_Value, 0, 0);
			this.tableLayoutPanel_Y_Value.Controls.Add(this.textBox_Y_Value, 1, 0);
			this.tableLayoutPanel_Y_Value.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Y_Value.Location = new System.Drawing.Point(244, 3);
			this.tableLayoutPanel_Y_Value.Name = "tableLayoutPanel_Y_Value";
			this.tableLayoutPanel_Y_Value.RowCount = 1;
			this.tableLayoutPanel_Y_Value.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Y_Value.Size = new System.Drawing.Size(235, 100);
			this.tableLayoutPanel_Y_Value.TabIndex = 1;
			// 
			// label_Y_Value
			// 
			this.label_Y_Value.AutoSize = true;
			this.label_Y_Value.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Y_Value.Location = new System.Drawing.Point(3, 0);
			this.label_Y_Value.Name = "label_Y_Value";
			this.label_Y_Value.Size = new System.Drawing.Size(111, 13);
			this.label_Y_Value.TabIndex = 0;
			this.label_Y_Value.Text = "Y";
			this.label_Y_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox_Y_Value
			// 
			this.textBox_Y_Value.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox_Y_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox_Y_Value.Location = new System.Drawing.Point(120, 3);
			this.textBox_Y_Value.Name = "textBox_Y_Value";
			this.textBox_Y_Value.Size = new System.Drawing.Size(112, 22);
			this.textBox_Y_Value.TabIndex = 1;
			// 
			// button_Change_Point
			// 
			this.button_Change_Point.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button_Change_Point.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button_Change_Point.Location = new System.Drawing.Point(189, 455);
			this.button_Change_Point.Name = "button_Change_Point";
			this.button_Change_Point.Size = new System.Drawing.Size(109, 23);
			this.button_Change_Point.TabIndex = 2;
			this.button_Change_Point.Text = "Изменить";
			this.button_Change_Point.UseVisualStyleBackColor = true;
			this.button_Change_Point.Click += new System.EventHandler(this.button_Change_Point_Click);
			// 
			// tableLayoutPanel_Main
			// 
			this.tableLayoutPanel_Main.ColumnCount = 1;
			this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Main.Controls.Add(this.label_Title, 0, 0);
			this.tableLayoutPanel_Main.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Buttons, 0, 2);
			this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
			this.tableLayoutPanel_Main.RowCount = 3;
			this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1226, 562);
			this.tableLayoutPanel_Main.TabIndex = 2;
			// 
			// tableLayoutPanel_Buttons
			// 
			this.tableLayoutPanel_Buttons.ColumnCount = 3;
			this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel_Buttons.Controls.Add(this.Button_Load, 0, 0);
			this.tableLayoutPanel_Buttons.Controls.Add(this.button_Save, 2, 0);
			this.tableLayoutPanel_Buttons.Controls.Add(this.button_Recalculate, 1, 0);
			this.tableLayoutPanel_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Buttons.Location = new System.Drawing.Point(3, 515);
			this.tableLayoutPanel_Buttons.Name = "tableLayoutPanel_Buttons";
			this.tableLayoutPanel_Buttons.RowCount = 1;
			this.tableLayoutPanel_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Buttons.Size = new System.Drawing.Size(1220, 44);
			this.tableLayoutPanel_Buttons.TabIndex = 2;
			// 
			// Button_Load
			// 
			this.Button_Load.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Button_Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Button_Load.Location = new System.Drawing.Point(128, 7);
			this.Button_Load.Name = "Button_Load";
			this.Button_Load.Size = new System.Drawing.Size(150, 30);
			this.Button_Load.TabIndex = 0;
			this.Button_Load.Text = "Загрузить";
			this.Button_Load.UseVisualStyleBackColor = true;
			this.Button_Load.Click += new System.EventHandler(this.Button_Load_Click);
			// 
			// button_Save
			// 
			this.button_Save.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button_Save.Location = new System.Drawing.Point(941, 7);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new System.Drawing.Size(150, 30);
			this.button_Save.TabIndex = 1;
			this.button_Save.Text = "Сохранить";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
			// 
			// button_Recalculate
			// 
			this.button_Recalculate.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button_Recalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button_Recalculate.Location = new System.Drawing.Point(534, 7);
			this.button_Recalculate.Name = "button_Recalculate";
			this.button_Recalculate.Size = new System.Drawing.Size(150, 30);
			this.button_Recalculate.TabIndex = 2;
			this.button_Recalculate.Text = "Пересчитать";
			this.button_Recalculate.UseVisualStyleBackColor = true;
			this.button_Recalculate.Click += new System.EventHandler(this.button_Recalculate_Click);
			// 
			// tableLayout_Trend_param
			// 
			this.tableLayout_Trend_param.ColumnCount = 2;
			this.tableLayout_Trend_param.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayout_Trend_param.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayout_Trend_param.Controls.Add(this.splitContainer2, 0, 0);
			this.tableLayout_Trend_param.Controls.Add(this.splitContainer3, 1, 0);
			this.tableLayout_Trend_param.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayout_Trend_param.Location = new System.Drawing.Point(3, 385);
			this.tableLayout_Trend_param.Name = "tableLayout_Trend_param";
			this.tableLayout_Trend_param.RowCount = 1;
			this.tableLayout_Trend_param.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayout_Trend_param.Size = new System.Drawing.Size(482, 24);
			this.tableLayout_Trend_param.TabIndex = 3;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.label_Trend_equ);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.textBox_Trend_equ);
			this.splitContainer2.Size = new System.Drawing.Size(235, 18);
			this.splitContainer2.SplitterDistance = 78;
			this.splitContainer2.TabIndex = 0;
			// 
			// textBox_Trend_equ
			// 
			this.textBox_Trend_equ.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox_Trend_equ.Location = new System.Drawing.Point(0, 0);
			this.textBox_Trend_equ.Name = "textBox_Trend_equ";
			this.textBox_Trend_equ.Size = new System.Drawing.Size(153, 20);
			this.textBox_Trend_equ.TabIndex = 0;
			// 
			// label_Trend_equ
			// 
			this.label_Trend_equ.AutoSize = true;
			this.label_Trend_equ.Dock = System.Windows.Forms.DockStyle.Right;
			this.label_Trend_equ.Location = new System.Drawing.Point(15, 0);
			this.label_Trend_equ.Name = "label_Trend_equ";
			this.label_Trend_equ.Size = new System.Drawing.Size(63, 13);
			this.label_Trend_equ.TabIndex = 0;
			this.label_Trend_equ.Text = "Уравнение";
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(244, 3);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.label_R2);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.textBox_R2);
			this.splitContainer3.Size = new System.Drawing.Size(235, 18);
			this.splitContainer3.SplitterDistance = 78;
			this.splitContainer3.TabIndex = 1;
			// 
			// label_R2
			// 
			this.label_R2.AutoSize = true;
			this.label_R2.Dock = System.Windows.Forms.DockStyle.Right;
			this.label_R2.Location = new System.Drawing.Point(51, 0);
			this.label_R2.Name = "label_R2";
			this.label_R2.Size = new System.Drawing.Size(27, 13);
			this.label_R2.TabIndex = 0;
			this.label_R2.Text = "R^2";
			// 
			// textBox_R2
			// 
			this.textBox_R2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox_R2.Location = new System.Drawing.Point(0, 0);
			this.textBox_R2.Name = "textBox_R2";
			this.textBox_R2.Size = new System.Drawing.Size(153, 20);
			this.textBox_R2.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1226, 562);
			this.Controls.Add(this.tableLayoutPanel_Main);
			this.Name = "Form1";
			this.Text = "Form1";
			this.tableLayoutPanel_Tables.ResumeLayout(false);
			this.tableLayoutPanel_Bentonit_La3.ResumeLayout(false);
			this.tableLayoutPanel_Bentonit_La3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bentonit_La3)).EndInit();
			this.tableLayoutPanel_Kinetika_Sorb_La3.ResumeLayout(false);
			this.tableLayoutPanel_Kinetika_Sorb_La3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Kinetika_Sorb_La3)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel_Graph_with_buttons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
			this.tableLayoutPanel_text_for_graphs.ResumeLayout(false);
			this.tableLayoutPanel_X_Value.ResumeLayout(false);
			this.tableLayoutPanel_X_Value.PerformLayout();
			this.tableLayoutPanel_Y_Value.ResumeLayout(false);
			this.tableLayoutPanel_Y_Value.PerformLayout();
			this.tableLayoutPanel_Main.ResumeLayout(false);
			this.tableLayoutPanel_Main.PerformLayout();
			this.tableLayoutPanel_Buttons.ResumeLayout(false);
			this.tableLayout_Trend_param.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel1.PerformLayout();
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Tables;
		private System.Windows.Forms.Label label_Title;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Bentonit_La3;
		private System.Windows.Forms.Label label_Bent;
		private System.Windows.Forms.DataGridView dataGridView_Bentonit_La3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_time;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_m_r;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_A;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_C;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_qt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_qt_ml;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_proc;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Kinetika_Sorb_La3;
		private System.Windows.Forms.Label label_Kinetika_Sorb_La3;
		private System.Windows.Forms.DataGridView dataGridView_Kinetika_Sorb_La3;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
		private System.Windows.Forms.DataVisualization.Charting.Chart graph;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Buttons;
		private System.Windows.Forms.Button Button_Load;
		private System.Windows.Forms.Button button_Save;
		private System.Windows.Forms.Button button_Recalculate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_time;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_qt_ml;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_qe_qt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_log_qe_qt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_t_qt;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Graph_with_buttons;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_text_for_graphs;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_X_Value;
		private System.Windows.Forms.Label label_X_value;
		private System.Windows.Forms.TextBox textBox_X_Value;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Y_Value;
		private System.Windows.Forms.Label label_Y_Value;
		private System.Windows.Forms.TextBox textBox_Y_Value;
		private System.Windows.Forms.Button button_Change_Point;
		private System.Windows.Forms.TableLayoutPanel tableLayout_Trend_param;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Label label_Trend_equ;
		private System.Windows.Forms.TextBox textBox_Trend_equ;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.Label label_R2;
		private System.Windows.Forms.TextBox textBox_R2;
	}
}

