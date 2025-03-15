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
			this.label_Bent = new System.Windows.Forms.Label();
			this.dataGridView_Bentonit_La3 = new System.Windows.Forms.DataGridView();
			this.Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_m_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_qt_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_proc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label_Kinetika_Sorb_La3 = new System.Windows.Forms.Label();
			this.dataGridView_Kinetika_Sorb_La3 = new System.Windows.Forms.DataGridView();
			this.Column_Kin_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_qt_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_log_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_t_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label_Title = new System.Windows.Forms.Label();
			this.graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.textBox_X_Value = new System.Windows.Forms.TextBox();
			this.label_X_value = new System.Windows.Forms.Label();
			this.label_Y_Value = new System.Windows.Forms.Label();
			this.textBox_Y_Value = new System.Windows.Forms.TextBox();
			this.label_Trend_equ = new System.Windows.Forms.Label();
			this.textBox_Trend_equ = new System.Windows.Forms.TextBox();
			this.textBox_R2 = new System.Windows.Forms.TextBox();
			this.button_Change_Point = new System.Windows.Forms.Button();
			this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel_Tables = new System.Windows.Forms.TableLayoutPanel();
			this.button_Recalculate = new System.Windows.Forms.Button();
			this.tableLayoutPanel_Graphs = new System.Windows.Forms.TableLayoutPanel();
			this.label_R2 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeColumnMRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeColumnAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.Load_Table_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Save_Table_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bentonit_La3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Kinetika_Sorb_La3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
			this.tableLayoutPanel_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel_Tables.SuspendLayout();
			this.tableLayoutPanel_Graphs.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label_Bent
			// 
			this.label_Bent.AutoSize = true;
			this.label_Bent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label_Bent.Location = new System.Drawing.Point(3, 0);
			this.label_Bent.Name = "label_Bent";
			this.label_Bent.Size = new System.Drawing.Size(701, 13);
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
			this.dataGridView_Bentonit_La3.Size = new System.Drawing.Size(701, 220);
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
			// label_Kinetika_Sorb_La3
			// 
			this.label_Kinetika_Sorb_La3.AutoSize = true;
			this.label_Kinetika_Sorb_La3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 239);
			this.label_Kinetika_Sorb_La3.Name = "label_Kinetika_Sorb_La3";
			this.label_Kinetika_Sorb_La3.Size = new System.Drawing.Size(701, 13);
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
			this.dataGridView_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 255);
			this.dataGridView_Kinetika_Sorb_La3.Name = "dataGridView_Kinetika_Sorb_La3";
			this.dataGridView_Kinetika_Sorb_La3.Size = new System.Drawing.Size(701, 220);
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
			// graph
			// 
			chartArea1.Name = "ChartArea1";
			this.graph.ChartAreas.Add(chartArea1);
			this.tableLayoutPanel_Graphs.SetColumnSpan(this.graph, 4);
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
			this.graph.Size = new System.Drawing.Size(503, 418);
			this.graph.TabIndex = 0;
			this.graph.Text = "График";
			this.graph.Click += new System.EventHandler(this.graph_Click);
			this.graph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graph_MouseClick);
			// 
			// textBox_X_Value
			// 
			this.textBox_X_Value.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBox_X_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox_X_Value.Location = new System.Drawing.Point(72, 453);
			this.textBox_X_Value.Name = "textBox_X_Value";
			this.textBox_X_Value.Size = new System.Drawing.Size(170, 22);
			this.textBox_X_Value.TabIndex = 1;
			// 
			// label_X_value
			// 
			this.label_X_value.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label_X_value.AutoSize = true;
			this.label_X_value.Location = new System.Drawing.Point(52, 457);
			this.label_X_value.Name = "label_X_value";
			this.label_X_value.Size = new System.Drawing.Size(14, 13);
			this.label_X_value.TabIndex = 0;
			this.label_X_value.Text = "X";
			this.label_X_value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label_Y_Value
			// 
			this.label_Y_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label_Y_Value.AutoSize = true;
			this.label_Y_Value.Location = new System.Drawing.Point(288, 457);
			this.label_Y_Value.Name = "label_Y_Value";
			this.label_Y_Value.Size = new System.Drawing.Size(14, 13);
			this.label_Y_Value.TabIndex = 0;
			this.label_Y_Value.Text = "Y";
			this.label_Y_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox_Y_Value
			// 
			this.textBox_Y_Value.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBox_Y_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox_Y_Value.Location = new System.Drawing.Point(308, 453);
			this.textBox_Y_Value.Name = "textBox_Y_Value";
			this.textBox_Y_Value.Size = new System.Drawing.Size(170, 22);
			this.textBox_Y_Value.TabIndex = 1;
			// 
			// label_Trend_equ
			// 
			this.label_Trend_equ.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label_Trend_equ.AutoSize = true;
			this.label_Trend_equ.Location = new System.Drawing.Point(3, 430);
			this.label_Trend_equ.Name = "label_Trend_equ";
			this.label_Trend_equ.Size = new System.Drawing.Size(63, 13);
			this.label_Trend_equ.TabIndex = 0;
			this.label_Trend_equ.Text = "Уравнение";
			// 
			// textBox_Trend_equ
			// 
			this.textBox_Trend_equ.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBox_Trend_equ.Location = new System.Drawing.Point(72, 427);
			this.textBox_Trend_equ.Name = "textBox_Trend_equ";
			this.textBox_Trend_equ.Size = new System.Drawing.Size(170, 20);
			this.textBox_Trend_equ.TabIndex = 0;
			// 
			// textBox_R2
			// 
			this.textBox_R2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBox_R2.Location = new System.Drawing.Point(308, 427);
			this.textBox_R2.Name = "textBox_R2";
			this.textBox_R2.Size = new System.Drawing.Size(170, 20);
			this.textBox_R2.TabIndex = 0;
			// 
			// button_Change_Point
			// 
			this.button_Change_Point.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.tableLayoutPanel_Graphs.SetColumnSpan(this.button_Change_Point, 4);
			this.button_Change_Point.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button_Change_Point.Location = new System.Drawing.Point(200, 481);
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
			this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
			this.tableLayoutPanel_Main.RowCount = 2;
			this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1226, 538);
			this.tableLayoutPanel_Main.TabIndex = 2;
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
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel_Graphs);
			this.splitContainer1.Size = new System.Drawing.Size(1220, 507);
			this.splitContainer1.SplitterDistance = 707;
			this.splitContainer1.TabIndex = 1;
			// 
			// tableLayoutPanel_Tables
			// 
			this.tableLayoutPanel_Tables.ColumnCount = 1;
			this.tableLayoutPanel_Tables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Tables.Controls.Add(this.label_Kinetika_Sorb_La3, 0, 2);
			this.tableLayoutPanel_Tables.Controls.Add(this.dataGridView_Kinetika_Sorb_La3, 0, 3);
			this.tableLayoutPanel_Tables.Controls.Add(this.label_Bent, 0, 0);
			this.tableLayoutPanel_Tables.Controls.Add(this.dataGridView_Bentonit_La3, 0, 1);
			this.tableLayoutPanel_Tables.Controls.Add(this.button_Recalculate, 0, 4);
			this.tableLayoutPanel_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Tables.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel_Tables.Name = "tableLayoutPanel_Tables";
			this.tableLayoutPanel_Tables.RowCount = 5;
			this.tableLayoutPanel_Tables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Tables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Tables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Tables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Tables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Tables.Size = new System.Drawing.Size(707, 507);
			this.tableLayoutPanel_Tables.TabIndex = 0;
			// 
			// button_Recalculate
			// 
			this.button_Recalculate.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button_Recalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button_Recalculate.Location = new System.Drawing.Point(292, 481);
			this.button_Recalculate.Name = "button_Recalculate";
			this.button_Recalculate.Size = new System.Drawing.Size(123, 23);
			this.button_Recalculate.TabIndex = 2;
			this.button_Recalculate.Text = "Пересчитать";
			this.button_Recalculate.UseVisualStyleBackColor = true;
			this.button_Recalculate.Click += new System.EventHandler(this.button_Recalculate_Click);
			// 
			// tableLayoutPanel_Graphs
			// 
			this.tableLayoutPanel_Graphs.ColumnCount = 4;
			this.tableLayoutPanel_Graphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel_Graphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Graphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel_Graphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel_Graphs.Controls.Add(this.textBox_Y_Value, 3, 2);
			this.tableLayoutPanel_Graphs.Controls.Add(this.label_Y_Value, 2, 2);
			this.tableLayoutPanel_Graphs.Controls.Add(this.textBox_X_Value, 1, 2);
			this.tableLayoutPanel_Graphs.Controls.Add(this.label_R2, 2, 1);
			this.tableLayoutPanel_Graphs.Controls.Add(this.label_X_value, 0, 2);
			this.tableLayoutPanel_Graphs.Controls.Add(this.label_Trend_equ, 0, 1);
			this.tableLayoutPanel_Graphs.Controls.Add(this.graph, 0, 0);
			this.tableLayoutPanel_Graphs.Controls.Add(this.textBox_R2, 3, 1);
			this.tableLayoutPanel_Graphs.Controls.Add(this.textBox_Trend_equ, 1, 1);
			this.tableLayoutPanel_Graphs.Controls.Add(this.button_Change_Point, 0, 3);
			this.tableLayoutPanel_Graphs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_Graphs.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel_Graphs.Name = "tableLayoutPanel_Graphs";
			this.tableLayoutPanel_Graphs.RowCount = 4;
			this.tableLayoutPanel_Graphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Graphs.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Graphs.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Graphs.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Graphs.Size = new System.Drawing.Size(509, 507);
			this.tableLayoutPanel_Graphs.TabIndex = 0;
			// 
			// label_R2
			// 
			this.label_R2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label_R2.AutoSize = true;
			this.label_R2.Location = new System.Drawing.Point(275, 430);
			this.label_R2.Name = "label_R2";
			this.label_R2.Size = new System.Drawing.Size(27, 13);
			this.label_R2.TabIndex = 4;
			this.label_R2.Text = "R^2";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1226, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// менюToolStripMenuItem
			// 
			this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeColumnMRToolStripMenuItem,
            this.changeColumnAToolStripMenuItem,
            this.toolStripSeparator1,
            this.Load_Table_ToolStripMenuItem,
            this.Save_Table_ToolStripMenuItem});
			this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
			this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.менюToolStripMenuItem.Text = "Меню";
			// 
			// changeColumnMRToolStripMenuItem
			// 
			this.changeColumnMRToolStripMenuItem.Name = "changeColumnMRToolStripMenuItem";
			this.changeColumnMRToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.changeColumnMRToolStripMenuItem.Text = "Изменить столец m, г";
			this.changeColumnMRToolStripMenuItem.Click += new System.EventHandler(this.изменитьСтолбецMГToolStripMenuItem_Click);
			// 
			// changeColumnAToolStripMenuItem
			// 
			this.changeColumnAToolStripMenuItem.Name = "changeColumnAToolStripMenuItem";
			this.changeColumnAToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.changeColumnAToolStripMenuItem.Text = "Изменить столбец A";
			this.changeColumnAToolStripMenuItem.Click += new System.EventHandler(this.changeColumnAToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
			// 
			// Load_Table_ToolStripMenuItem
			// 
			this.Load_Table_ToolStripMenuItem.Name = "Load_Table_ToolStripMenuItem";
			this.Load_Table_ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.Load_Table_ToolStripMenuItem.Text = "Загрузить";
			this.Load_Table_ToolStripMenuItem.Click += new System.EventHandler(this.Load_Table_ToolStripMenuItem_Click);
			// 
			// Save_Table_ToolStripMenuItem
			// 
			this.Save_Table_ToolStripMenuItem.Name = "Save_Table_ToolStripMenuItem";
			this.Save_Table_ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.Save_Table_ToolStripMenuItem.Text = "Сохранить";
			this.Save_Table_ToolStripMenuItem.Click += new System.EventHandler(this.Save_Table_ToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1226, 562);
			this.Controls.Add(this.tableLayoutPanel_Main);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bentonit_La3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Kinetika_Sorb_La3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
			this.tableLayoutPanel_Main.ResumeLayout(false);
			this.tableLayoutPanel_Main.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel_Tables.ResumeLayout(false);
			this.tableLayoutPanel_Tables.PerformLayout();
			this.tableLayoutPanel_Graphs.ResumeLayout(false);
			this.tableLayoutPanel_Graphs.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label_Title;
		private System.Windows.Forms.Label label_Bent;
		private System.Windows.Forms.DataGridView dataGridView_Bentonit_La3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_time;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_m_r;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_A;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_C;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_qt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_qt_ml;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_proc;
		private System.Windows.Forms.Label label_Kinetika_Sorb_La3;
		private System.Windows.Forms.DataGridView dataGridView_Kinetika_Sorb_La3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
		private System.Windows.Forms.DataVisualization.Charting.Chart graph;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_time;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_qt_ml;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_qe_qt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_log_qe_qt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_t_qt;
		private System.Windows.Forms.Label label_X_value;
		private System.Windows.Forms.TextBox textBox_X_Value;
		private System.Windows.Forms.Label label_Y_Value;
		private System.Windows.Forms.TextBox textBox_Y_Value;
		private System.Windows.Forms.Button button_Change_Point;
		private System.Windows.Forms.Label label_Trend_equ;
		private System.Windows.Forms.TextBox textBox_Trend_equ;
		private System.Windows.Forms.TextBox textBox_R2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeColumnMRToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeColumnAToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Graphs;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Tables;
		private System.Windows.Forms.Label label_R2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem Load_Table_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Save_Table_ToolStripMenuItem;
		private System.Windows.Forms.Button button_Recalculate;
	}
}

