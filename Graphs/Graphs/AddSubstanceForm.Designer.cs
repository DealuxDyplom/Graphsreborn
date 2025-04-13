namespace Graphs
{
    partial class AddSubstanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label_SubstanceName = new System.Windows.Forms.Label();
            this.textBox_SubstanceName = new System.Windows.Forms.TextBox();
            this.label_OpticDens = new System.Windows.Forms.Label();
            this.textBox_OpticDens = new System.Windows.Forms.TextBox();
            this.label_ExprData = new System.Windows.Forms.Label();
            this.dataGridView_ExprData = new System.Windows.Forms.DataGridView();
            this.Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_m_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView_ExprData_Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_FillFromFileExprData = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Graduation = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Graph = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox_Coef = new System.Windows.Forms.TextBox();
            this.label_Coef = new System.Windows.Forms.Label();
            this.label_Detr = new System.Windows.Forms.Label();
            this.textBox_Detr = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_C_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_Graduation = new System.Windows.Forms.Label();
            this.comboBox_Graduation = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel_Data = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.DataGridViewData_Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewData_Column_m_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewData_Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewData_Column_C_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewData_Column_qt_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewData_Column_qt_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewData_Column_proc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewData_Column_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewData_Column_log_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewData_Column_t_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Recalculate = new System.Windows.Forms.Button();
            this.button_AddSubstance = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel_ExprData = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_ExprDataParam = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_ExprDataButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_ExprDataTable = new System.Windows.Forms.TableLayoutPanel();
            this.button_SaveExprData = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExprData)).BeginInit();
            this.tableLayoutPanel_Graduation.SuspendLayout();
            this.tableLayoutPanel_Graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel_ExprData.SuspendLayout();
            this.tableLayoutPanel_ExprDataParam.SuspendLayout();
            this.tableLayoutPanel_ExprDataButtons.SuspendLayout();
            this.tableLayoutPanel_ExprDataTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Graduation, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Data, 0, 2);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_ExprData, 0, 1);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 4;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57142F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57144F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1151, 647);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // label_SubstanceName
            // 
            this.label_SubstanceName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_SubstanceName.AutoSize = true;
            this.label_SubstanceName.Location = new System.Drawing.Point(177, 5);
            this.label_SubstanceName.Name = "label_SubstanceName";
            this.label_SubstanceName.Size = new System.Drawing.Size(104, 13);
            this.label_SubstanceName.TabIndex = 0;
            this.label_SubstanceName.Text = "Нзвание раствора:";
            this.label_SubstanceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_SubstanceName
            // 
            this.textBox_SubstanceName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_SubstanceName.Location = new System.Drawing.Point(287, 3);
            this.textBox_SubstanceName.Name = "textBox_SubstanceName";
            this.textBox_SubstanceName.Size = new System.Drawing.Size(278, 20);
            this.textBox_SubstanceName.TabIndex = 1;
            // 
            // label_OpticDens
            // 
            this.label_OpticDens.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_OpticDens.AutoSize = true;
            this.label_OpticDens.Location = new System.Drawing.Point(661, 5);
            this.label_OpticDens.Name = "label_OpticDens";
            this.label_OpticDens.Size = new System.Drawing.Size(188, 13);
            this.label_OpticDens.TabIndex = 2;
            this.label_OpticDens.Text = "Оптическая плотность раствора(А):";
            this.label_OpticDens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_OpticDens
            // 
            this.textBox_OpticDens.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_OpticDens.Location = new System.Drawing.Point(855, 3);
            this.textBox_OpticDens.Name = "textBox_OpticDens";
            this.textBox_OpticDens.Size = new System.Drawing.Size(281, 20);
            this.textBox_OpticDens.TabIndex = 3;
            // 
            // label_ExprData
            // 
            this.label_ExprData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_ExprData.AutoSize = true;
            this.label_ExprData.Location = new System.Drawing.Point(492, 3);
            this.label_ExprData.Name = "label_ExprData";
            this.label_ExprData.Size = new System.Drawing.Size(154, 13);
            this.label_ExprData.TabIndex = 4;
            this.label_ExprData.Text = "Экспериментальные данные";
            // 
            // dataGridView_ExprData
            // 
            this.dataGridView_ExprData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ExprData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ExprData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_time,
            this.Column_m_r,
            this.DataGridView_ExprData_Column_A});
            this.dataGridView_ExprData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ExprData.Location = new System.Drawing.Point(3, 23);
            this.dataGridView_ExprData.Name = "dataGridView_ExprData";
            this.dataGridView_ExprData.Size = new System.Drawing.Size(1133, 147);
            this.dataGridView_ExprData.TabIndex = 5;
            // 
            // Column_time
            // 
            this.Column_time.HeaderText = "обр/врем";
            this.Column_time.Name = "Column_time";
            // 
            // Column_m_r
            // 
            this.Column_m_r.HeaderText = "m, г";
            this.Column_m_r.Name = "Column_m_r";
            // 
            // DataGridView_ExprData_Column_A
            // 
            this.DataGridView_ExprData_Column_A.HeaderText = "A";
            this.DataGridView_ExprData_Column_A.Name = "DataGridView_ExprData_Column_A";
            // 
            // button_FillFromFileExprData
            // 
            this.button_FillFromFileExprData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_FillFromFileExprData.Location = new System.Drawing.Point(3, 5);
            this.button_FillFromFileExprData.Name = "button_FillFromFileExprData";
            this.button_FillFromFileExprData.Size = new System.Drawing.Size(563, 24);
            this.button_FillFromFileExprData.TabIndex = 6;
            this.button_FillFromFileExprData.Text = "Заполнить из файла";
            this.button_FillFromFileExprData.UseVisualStyleBackColor = true;
            this.button_FillFromFileExprData.Click += new System.EventHandler(this.button_FillFromFileExprData_Click);
            // 
            // tableLayoutPanel_Graduation
            // 
            this.tableLayoutPanel_Graduation.ColumnCount = 2;
            this.tableLayoutPanel_Graduation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Graduation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Graduation.Controls.Add(this.tableLayoutPanel_Graph, 1, 1);
            this.tableLayoutPanel_Graduation.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel_Graduation.Controls.Add(this.label_Graduation, 0, 0);
            this.tableLayoutPanel_Graduation.Controls.Add(this.comboBox_Graduation, 1, 0);
            this.tableLayoutPanel_Graduation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Graduation.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_Graduation.Name = "tableLayoutPanel_Graduation";
            this.tableLayoutPanel_Graduation.RowCount = 2;
            this.tableLayoutPanel_Graduation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Graduation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Graduation.Size = new System.Drawing.Size(1145, 164);
            this.tableLayoutPanel_Graduation.TabIndex = 0;
            // 
            // tableLayoutPanel_Graph
            // 
            this.tableLayoutPanel_Graph.ColumnCount = 2;
            this.tableLayoutPanel_Graph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_Graph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 507F));
            this.tableLayoutPanel_Graph.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel_Graph.Controls.Add(this.textBox_Coef, 1, 1);
            this.tableLayoutPanel_Graph.Controls.Add(this.label_Coef, 0, 1);
            this.tableLayoutPanel_Graph.Controls.Add(this.label_Detr, 0, 2);
            this.tableLayoutPanel_Graph.Controls.Add(this.textBox_Detr, 1, 2);
            this.tableLayoutPanel_Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Graph.Location = new System.Drawing.Point(575, 33);
            this.tableLayoutPanel_Graph.Name = "tableLayoutPanel_Graph";
            this.tableLayoutPanel_Graph.RowCount = 3;
            this.tableLayoutPanel_Graph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Graph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Graph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Graph.Size = new System.Drawing.Size(567, 128);
            this.tableLayoutPanel_Graph.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea2.AxisX.IsStartedFromZero = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.tableLayoutPanel_Graph.SetColumnSpan(this.chart1, 2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "Градуировка";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Линия тренда";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(601, 82);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Градуировка";
            this.chart1.Titles.Add(title2);
            // 
            // textBox_Coef
            // 
            this.textBox_Coef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Coef.Location = new System.Drawing.Point(103, 91);
            this.textBox_Coef.Name = "textBox_Coef";
            this.textBox_Coef.ReadOnly = true;
            this.textBox_Coef.Size = new System.Drawing.Size(501, 20);
            this.textBox_Coef.TabIndex = 2;
            // 
            // label_Coef
            // 
            this.label_Coef.AutoSize = true;
            this.label_Coef.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Coef.Location = new System.Drawing.Point(17, 88);
            this.label_Coef.Name = "label_Coef";
            this.label_Coef.Size = new System.Drawing.Size(80, 20);
            this.label_Coef.TabIndex = 3;
            this.label_Coef.Text = "Коэффициент:";
            this.label_Coef.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Detr
            // 
            this.label_Detr.AutoSize = true;
            this.label_Detr.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Detr.Location = new System.Drawing.Point(11, 108);
            this.label_Detr.Name = "label_Detr";
            this.label_Detr.Size = new System.Drawing.Size(86, 20);
            this.label_Detr.TabIndex = 4;
            this.label_Detr.Text = "Детерминация:";
            this.label_Detr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_Detr
            // 
            this.textBox_Detr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Detr.Location = new System.Drawing.Point(103, 111);
            this.textBox_Detr.Name = "textBox_Detr";
            this.textBox_Detr.ReadOnly = true;
            this.textBox_Detr.Size = new System.Drawing.Size(501, 20);
            this.textBox_Detr.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_C_ml,
            this.Column_A});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(566, 128);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column_C_ml
            // 
            this.Column_C_ml.HeaderText = "С,мкг/мл";
            this.Column_C_ml.Name = "Column_C_ml";
            this.Column_C_ml.ReadOnly = true;
            // 
            // Column_A
            // 
            this.Column_A.HeaderText = "А (361 нм)";
            this.Column_A.Name = "Column_A";
            this.Column_A.ReadOnly = true;
            // 
            // label_Graduation
            // 
            this.label_Graduation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Graduation.AutoSize = true;
            this.label_Graduation.Location = new System.Drawing.Point(494, 8);
            this.label_Graduation.Name = "label_Graduation";
            this.label_Graduation.Size = new System.Drawing.Size(75, 13);
            this.label_Graduation.TabIndex = 3;
            this.label_Graduation.Text = "Градуировка:";
            // 
            // comboBox_Graduation
            // 
            this.comboBox_Graduation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_Graduation.FormattingEnabled = true;
            this.comboBox_Graduation.Location = new System.Drawing.Point(575, 4);
            this.comboBox_Graduation.Name = "comboBox_Graduation";
            this.comboBox_Graduation.Size = new System.Drawing.Size(239, 21);
            this.comboBox_Graduation.TabIndex = 4;
            this.comboBox_Graduation.SelectedIndexChanged += new System.EventHandler(this.comboBox_Graduation_SelectedIndexChanged);
            // 
            // tableLayoutPanel_Data
            // 
            this.tableLayoutPanel_Data.ColumnCount = 1;
            this.tableLayoutPanel_Data.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Data.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Data.Controls.Add(this.dataGridView_Data, 0, 0);
            this.tableLayoutPanel_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Data.Location = new System.Drawing.Point(3, 428);
            this.tableLayoutPanel_Data.Name = "tableLayoutPanel_Data";
            this.tableLayoutPanel_Data.RowCount = 1;
            this.tableLayoutPanel_Data.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Data.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Data.Size = new System.Drawing.Size(1145, 164);
            this.tableLayoutPanel_Data.TabIndex = 4;
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewData_Column_time,
            this.DataGridViewData_Column_m_r,
            this.DataGridViewData_Column_A,
            this.DataGridViewData_Column_C_ml,
            this.DataGridViewData_Column_qt_r,
            this.DataGridViewData_Column_qt_ml,
            this.DataGridViewData_Column_proc,
            this.DataGridViewData_Column_qe_qt,
            this.DataGridViewData_Column_log_qe_qt,
            this.DataGridViewData_Column_t_qt});
            this.dataGridView_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Data.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.ReadOnly = true;
            this.dataGridView_Data.Size = new System.Drawing.Size(1139, 158);
            this.dataGridView_Data.TabIndex = 4;
            // 
            // DataGridViewData_Column_time
            // 
            this.DataGridViewData_Column_time.HeaderText = "обр\\врем";
            this.DataGridViewData_Column_time.Name = "DataGridViewData_Column_time";
            this.DataGridViewData_Column_time.ReadOnly = true;
            // 
            // DataGridViewData_Column_m_r
            // 
            this.DataGridViewData_Column_m_r.HeaderText = "m, г";
            this.DataGridViewData_Column_m_r.Name = "DataGridViewData_Column_m_r";
            this.DataGridViewData_Column_m_r.ReadOnly = true;
            // 
            // DataGridViewData_Column_A
            // 
            this.DataGridViewData_Column_A.HeaderText = "A";
            this.DataGridViewData_Column_A.Name = "DataGridViewData_Column_A";
            this.DataGridViewData_Column_A.ReadOnly = true;
            // 
            // DataGridViewData_Column_C_ml
            // 
            this.DataGridViewData_Column_C_ml.HeaderText = "С,мкг/мл";
            this.DataGridViewData_Column_C_ml.Name = "DataGridViewData_Column_C_ml";
            this.DataGridViewData_Column_C_ml.ReadOnly = true;
            // 
            // DataGridViewData_Column_qt_r
            // 
            this.DataGridViewData_Column_qt_r.HeaderText = "qt, мкг/г";
            this.DataGridViewData_Column_qt_r.Name = "DataGridViewData_Column_qt_r";
            this.DataGridViewData_Column_qt_r.ReadOnly = true;
            // 
            // DataGridViewData_Column_qt_ml
            // 
            this.DataGridViewData_Column_qt_ml.HeaderText = "qt, μмоль/г";
            this.DataGridViewData_Column_qt_ml.Name = "DataGridViewData_Column_qt_ml";
            this.DataGridViewData_Column_qt_ml.ReadOnly = true;
            // 
            // DataGridViewData_Column_proc
            // 
            this.DataGridViewData_Column_proc.HeaderText = "%";
            this.DataGridViewData_Column_proc.Name = "DataGridViewData_Column_proc";
            this.DataGridViewData_Column_proc.ReadOnly = true;
            // 
            // DataGridViewData_Column_qe_qt
            // 
            this.DataGridViewData_Column_qe_qt.HeaderText = "qe-qt";
            this.DataGridViewData_Column_qe_qt.Name = "DataGridViewData_Column_qe_qt";
            this.DataGridViewData_Column_qe_qt.ReadOnly = true;
            // 
            // DataGridViewData_Column_log_qe_qt
            // 
            this.DataGridViewData_Column_log_qe_qt.HeaderText = "log(qe-qt)";
            this.DataGridViewData_Column_log_qe_qt.Name = "DataGridViewData_Column_log_qe_qt";
            this.DataGridViewData_Column_log_qe_qt.ReadOnly = true;
            // 
            // DataGridViewData_Column_t_qt
            // 
            this.DataGridViewData_Column_t_qt.HeaderText = "t\\qt";
            this.DataGridViewData_Column_t_qt.Name = "DataGridViewData_Column_t_qt";
            this.DataGridViewData_Column_t_qt.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_Recalculate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_AddSubstance, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 598);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1145, 46);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // button_Recalculate
            // 
            this.button_Recalculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Recalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Recalculate.Location = new System.Drawing.Point(575, 3);
            this.button_Recalculate.Name = "button_Recalculate";
            this.button_Recalculate.Size = new System.Drawing.Size(567, 40);
            this.button_Recalculate.TabIndex = 5;
            this.button_Recalculate.Text = "Пересчитать";
            this.button_Recalculate.UseVisualStyleBackColor = true;
            this.button_Recalculate.Click += new System.EventHandler(this.button_Recalculate_Click);
            // 
            // button_AddSubstance
            // 
            this.button_AddSubstance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_AddSubstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AddSubstance.Location = new System.Drawing.Point(3, 3);
            this.button_AddSubstance.Name = "button_AddSubstance";
            this.button_AddSubstance.Size = new System.Drawing.Size(566, 40);
            this.button_AddSubstance.TabIndex = 6;
            this.button_AddSubstance.Text = "Добавить";
            this.button_AddSubstance.UseVisualStyleBackColor = true;
            this.button_AddSubstance.Click += new System.EventHandler(this.button_AddSubstance_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel_ExprData
            // 
            this.tableLayoutPanel_ExprData.ColumnCount = 1;
            this.tableLayoutPanel_ExprData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ExprData.Controls.Add(this.tableLayoutPanel_ExprDataParam, 0, 0);
            this.tableLayoutPanel_ExprData.Controls.Add(this.tableLayoutPanel_ExprDataButtons, 0, 2);
            this.tableLayoutPanel_ExprData.Controls.Add(this.tableLayoutPanel_ExprDataTable, 0, 1);
            this.tableLayoutPanel_ExprData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_ExprData.Location = new System.Drawing.Point(3, 173);
            this.tableLayoutPanel_ExprData.Name = "tableLayoutPanel_ExprData";
            this.tableLayoutPanel_ExprData.RowCount = 3;
            this.tableLayoutPanel_ExprData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_ExprData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ExprData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_ExprData.Size = new System.Drawing.Size(1145, 249);
            this.tableLayoutPanel_ExprData.TabIndex = 6;
            // 
            // tableLayoutPanel_ExprDataParam
            // 
            this.tableLayoutPanel_ExprDataParam.ColumnCount = 4;
            this.tableLayoutPanel_ExprDataParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_ExprDataParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_ExprDataParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_ExprDataParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_ExprDataParam.Controls.Add(this.textBox_OpticDens, 3, 0);
            this.tableLayoutPanel_ExprDataParam.Controls.Add(this.label_OpticDens, 2, 0);
            this.tableLayoutPanel_ExprDataParam.Controls.Add(this.textBox_SubstanceName, 1, 0);
            this.tableLayoutPanel_ExprDataParam.Controls.Add(this.label_SubstanceName, 0, 0);
            this.tableLayoutPanel_ExprDataParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_ExprDataParam.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_ExprDataParam.Name = "tableLayoutPanel_ExprDataParam";
            this.tableLayoutPanel_ExprDataParam.RowCount = 1;
            this.tableLayoutPanel_ExprDataParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ExprDataParam.Size = new System.Drawing.Size(1139, 24);
            this.tableLayoutPanel_ExprDataParam.TabIndex = 0;
            // 
            // tableLayoutPanel_ExprDataButtons
            // 
            this.tableLayoutPanel_ExprDataButtons.ColumnCount = 2;
            this.tableLayoutPanel_ExprDataButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_ExprDataButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_ExprDataButtons.Controls.Add(this.button_FillFromFileExprData, 0, 0);
            this.tableLayoutPanel_ExprDataButtons.Controls.Add(this.button_SaveExprData, 1, 0);
            this.tableLayoutPanel_ExprDataButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_ExprDataButtons.Location = new System.Drawing.Point(3, 212);
            this.tableLayoutPanel_ExprDataButtons.Name = "tableLayoutPanel_ExprDataButtons";
            this.tableLayoutPanel_ExprDataButtons.RowCount = 1;
            this.tableLayoutPanel_ExprDataButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_ExprDataButtons.Size = new System.Drawing.Size(1139, 34);
            this.tableLayoutPanel_ExprDataButtons.TabIndex = 6;
            // 
            // tableLayoutPanel_ExprDataTable
            // 
            this.tableLayoutPanel_ExprDataTable.ColumnCount = 1;
            this.tableLayoutPanel_ExprDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ExprDataTable.Controls.Add(this.label_ExprData, 0, 0);
            this.tableLayoutPanel_ExprDataTable.Controls.Add(this.dataGridView_ExprData, 0, 1);
            this.tableLayoutPanel_ExprDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_ExprDataTable.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel_ExprDataTable.Name = "tableLayoutPanel_ExprDataTable";
            this.tableLayoutPanel_ExprDataTable.RowCount = 2;
            this.tableLayoutPanel_ExprDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_ExprDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ExprDataTable.Size = new System.Drawing.Size(1139, 173);
            this.tableLayoutPanel_ExprDataTable.TabIndex = 7;
            // 
            // button_SaveExprData
            // 
            this.button_SaveExprData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_SaveExprData.Location = new System.Drawing.Point(572, 5);
            this.button_SaveExprData.Name = "button_SaveExprData";
            this.button_SaveExprData.Size = new System.Drawing.Size(564, 24);
            this.button_SaveExprData.TabIndex = 7;
            this.button_SaveExprData.Text = "Сохранить данные";
            this.button_SaveExprData.UseVisualStyleBackColor = true;
            this.button_SaveExprData.Click += new System.EventHandler(this.button_SaveExprData_Click);
            // 
            // AddSubstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 647);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Name = "AddSubstanceForm";
            this.Text = "AddSubstance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddSubstance_FormClosed);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExprData)).EndInit();
            this.tableLayoutPanel_Graduation.ResumeLayout(false);
            this.tableLayoutPanel_Graduation.PerformLayout();
            this.tableLayoutPanel_Graph.ResumeLayout(false);
            this.tableLayoutPanel_Graph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel_Data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel_ExprData.ResumeLayout(false);
            this.tableLayoutPanel_ExprDataParam.ResumeLayout(false);
            this.tableLayoutPanel_ExprDataParam.PerformLayout();
            this.tableLayoutPanel_ExprDataButtons.ResumeLayout(false);
            this.tableLayoutPanel_ExprDataTable.ResumeLayout(false);
            this.tableLayoutPanel_ExprDataTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_ml;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_A;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Graph;
        private System.Windows.Forms.TextBox textBox_Coef;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label_Coef;
        private System.Windows.Forms.Label label_Detr;
        private System.Windows.Forms.TextBox textBox_Detr;
        private System.Windows.Forms.Label label_SubstanceName;
        private System.Windows.Forms.TextBox textBox_SubstanceName;
        private System.Windows.Forms.Label label_OpticDens;
        private System.Windows.Forms.TextBox textBox_OpticDens;
        private System.Windows.Forms.Label label_ExprData;
        private System.Windows.Forms.DataGridView dataGridView_ExprData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_m_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridView_ExprData_Column_A;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.Button button_FillFromFileExprData;
        private System.Windows.Forms.Button button_Recalculate;
        private System.Windows.Forms.Button button_AddSubstance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Graduation;
        private System.Windows.Forms.Label label_Graduation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Data;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox_Graduation;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_m_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_C_ml;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_qt_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_qt_ml;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_proc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_qe_qt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_log_qe_qt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewData_Column_t_qt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ExprData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ExprDataParam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ExprDataButtons;
        private System.Windows.Forms.Button button_SaveExprData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ExprDataTable;
    }
}