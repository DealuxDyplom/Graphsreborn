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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Graphs = new System.Windows.Forms.TabPage();
            this.tabPage_Comparison = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_TableTwo = new System.Windows.Forms.DataGridView();
            this.button_AddSubstance = new System.Windows.Forms.Button();
            this.button_Compare = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView_TableOne = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTableTwoColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tabControl1.SuspendLayout();
            this.tabPage_Graphs.SuspendLayout();
            this.tabPage_Comparison.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TableTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TableOne)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Bent
            // 
            this.label_Bent.AutoSize = true;
            this.label_Bent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Bent.Location = new System.Drawing.Point(3, 0);
            this.label_Bent.Name = "label_Bent";
            this.label_Bent.Size = new System.Drawing.Size(692, 13);
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
            this.dataGridView_Bentonit_La3.Size = new System.Drawing.Size(692, 204);
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
            this.label_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 223);
            this.label_Kinetika_Sorb_La3.Name = "label_Kinetika_Sorb_La3";
            this.label_Kinetika_Sorb_La3.Size = new System.Drawing.Size(692, 13);
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
            this.dataGridView_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 239);
            this.dataGridView_Kinetika_Sorb_La3.Name = "dataGridView_Kinetika_Sorb_La3";
            this.dataGridView_Kinetika_Sorb_La3.Size = new System.Drawing.Size(692, 204);
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
            this.label_Title.Size = new System.Drawing.Size(1206, 25);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Graphs";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // graph
            // 
            chartArea4.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea4);
            this.tableLayoutPanel_Graphs.SetColumnSpan(this.graph, 4);
            this.graph.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.graph.Legends.Add(legend4);
            this.graph.Location = new System.Drawing.Point(3, 3);
            this.graph.Name = "graph";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "TrendLine";
            this.graph.Series.Add(series7);
            this.graph.Series.Add(series8);
            this.graph.Size = new System.Drawing.Size(498, 386);
            this.graph.TabIndex = 0;
            this.graph.Text = "График";
            this.graph.Click += new System.EventHandler(this.graph_Click);
            this.graph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graph_MouseClick);
            // 
            // textBox_X_Value
            // 
            this.textBox_X_Value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_X_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_X_Value.Location = new System.Drawing.Point(72, 421);
            this.textBox_X_Value.Name = "textBox_X_Value";
            this.textBox_X_Value.Size = new System.Drawing.Size(170, 22);
            this.textBox_X_Value.TabIndex = 1;
            // 
            // label_X_value
            // 
            this.label_X_value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_X_value.AutoSize = true;
            this.label_X_value.Location = new System.Drawing.Point(52, 425);
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
            this.label_Y_Value.Location = new System.Drawing.Point(286, 425);
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
            this.textBox_Y_Value.Location = new System.Drawing.Point(306, 421);
            this.textBox_Y_Value.Name = "textBox_Y_Value";
            this.textBox_Y_Value.Size = new System.Drawing.Size(170, 22);
            this.textBox_Y_Value.TabIndex = 1;
            // 
            // label_Trend_equ
            // 
            this.label_Trend_equ.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Trend_equ.AutoSize = true;
            this.label_Trend_equ.Location = new System.Drawing.Point(3, 398);
            this.label_Trend_equ.Name = "label_Trend_equ";
            this.label_Trend_equ.Size = new System.Drawing.Size(63, 13);
            this.label_Trend_equ.TabIndex = 0;
            this.label_Trend_equ.Text = "Уравнение";
            // 
            // textBox_Trend_equ
            // 
            this.textBox_Trend_equ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_Trend_equ.Location = new System.Drawing.Point(72, 395);
            this.textBox_Trend_equ.Name = "textBox_Trend_equ";
            this.textBox_Trend_equ.Size = new System.Drawing.Size(170, 20);
            this.textBox_Trend_equ.TabIndex = 0;
            // 
            // textBox_R2
            // 
            this.textBox_R2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_R2.Location = new System.Drawing.Point(306, 395);
            this.textBox_R2.Name = "textBox_R2";
            this.textBox_R2.Size = new System.Drawing.Size(170, 20);
            this.textBox_R2.TabIndex = 0;
            // 
            // button_Change_Point
            // 
            this.button_Change_Point.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel_Graphs.SetColumnSpan(this.button_Change_Point, 4);
            this.button_Change_Point.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Change_Point.Location = new System.Drawing.Point(197, 449);
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
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 2;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1212, 506);
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
            this.splitContainer1.Size = new System.Drawing.Size(1206, 475);
            this.splitContainer1.SplitterDistance = 698;
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
            this.tableLayoutPanel_Tables.Size = new System.Drawing.Size(698, 475);
            this.tableLayoutPanel_Tables.TabIndex = 0;
            // 
            // button_Recalculate
            // 
            this.button_Recalculate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_Recalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Recalculate.Location = new System.Drawing.Point(287, 449);
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
            this.tableLayoutPanel_Graphs.Size = new System.Drawing.Size(504, 475);
            this.tableLayoutPanel_Graphs.TabIndex = 0;
            // 
            // label_R2
            // 
            this.label_R2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_R2.AutoSize = true;
            this.label_R2.Location = new System.Drawing.Point(273, 398);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Graphs);
            this.tabControl1.Controls.Add(this.tabPage_Comparison);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1226, 538);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage_Graphs
            // 
            this.tabPage_Graphs.Controls.Add(this.tableLayoutPanel_Main);
            this.tabPage_Graphs.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Graphs.Name = "tabPage_Graphs";
            this.tabPage_Graphs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Graphs.Size = new System.Drawing.Size(1218, 512);
            this.tabPage_Graphs.TabIndex = 0;
            this.tabPage_Graphs.Text = "Graphs";
            this.tabPage_Graphs.UseVisualStyleBackColor = true;
            // 
            // tabPage_Comparison
            // 
            this.tabPage_Comparison.Controls.Add(this.tableLayoutPanelMain);
            this.tabPage_Comparison.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Comparison.Name = "tabPage_Comparison";
            this.tabPage_Comparison.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Comparison.Size = new System.Drawing.Size(1218, 512);
            this.tabPage_Comparison.TabIndex = 1;
            this.tabPage_Comparison.Text = "Сравнение";
            this.tabPage_Comparison.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 4;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMain.Controls.Add(this.dataGridView_TableTwo, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.button_AddSubstance, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.button_Compare, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.button_Clear, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.button4, 3, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dataGridView_TableOne, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1212, 506);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // dataGridView_TableTwo
            // 
            this.dataGridView_TableTwo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_TableTwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TableTwo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTableTwoColumn1});
            this.dataGridView_TableTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TableTwo.Location = new System.Drawing.Point(609, 3);
            this.dataGridView_TableTwo.Name = "dataGridView_TableTwo";
            this.dataGridView_TableTwo.ReadOnly = true;
            this.dataGridView_TableTwo.Size = new System.Drawing.Size(297, 237);
            this.dataGridView_TableTwo.TabIndex = 1;
            // 
            // button_AddSubstance
            // 
            this.button_AddSubstance.Location = new System.Drawing.Point(3, 246);
            this.button_AddSubstance.Name = "button_AddSubstance";
            this.button_AddSubstance.Size = new System.Drawing.Size(75, 23);
            this.button_AddSubstance.TabIndex = 2;
            this.button_AddSubstance.Text = "Добавить";
            this.button_AddSubstance.UseVisualStyleBackColor = true;
            this.button_AddSubstance.Click += new System.EventHandler(this.button_AddSubstance_Click);
            // 
            // button_Compare
            // 
            this.button_Compare.Location = new System.Drawing.Point(306, 246);
            this.button_Compare.Name = "button_Compare";
            this.button_Compare.Size = new System.Drawing.Size(75, 23);
            this.button_Compare.TabIndex = 3;
            this.button_Compare.Text = "Сравнить";
            this.button_Compare.UseVisualStyleBackColor = true;
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(609, 246);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 4;
            this.button_Clear.Text = "Очистить";
            this.button_Clear.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(912, 246);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView_TableOne
            // 
            this.dataGridView_TableOne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_TableOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TableOne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridView_TableOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TableOne.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_TableOne.Name = "dataGridView_TableOne";
            this.dataGridView_TableOne.ReadOnly = true;
            this.dataGridView_TableOne.Size = new System.Drawing.Size(297, 237);
            this.dataGridView_TableOne.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Название вещества";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTableTwoColumn1
            // 
            this.dataGridViewTableTwoColumn1.HeaderText = "Название вещества";
            this.dataGridViewTableTwoColumn1.Name = "dataGridViewTableTwoColumn1";
            this.dataGridViewTableTwoColumn1.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 562);
            this.Controls.Add(this.tabControl1);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Graphs.ResumeLayout(false);
            this.tabPage_Comparison.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TableTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TableOne)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Graphs;
        private System.Windows.Forms.TabPage tabPage_Comparison;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.DataGridView dataGridView_TableOne;
        private System.Windows.Forms.DataGridView dataGridView_TableTwo;
        private System.Windows.Forms.Button button_AddSubstance;
        private System.Windows.Forms.Button button_Compare;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTableTwoColumn1;
    }
}

