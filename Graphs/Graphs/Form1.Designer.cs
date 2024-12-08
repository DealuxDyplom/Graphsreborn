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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label_Title = new System.Windows.Forms.Label();
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
			this.Column_Kin_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_log_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_t_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Kin_qt_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel_Bentonit_La3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bentonit_La3)).BeginInit();
			this.tableLayoutPanel_Kinetika_Sorb_La3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Kinetika_Sorb_La3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel_Bentonit_La3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel_Kinetika_Sorb_La3, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 547);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label_Title
			// 
			this.label_Title.AutoSize = true;
			this.label_Title.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label_Title.Location = new System.Drawing.Point(3, 0);
			this.label_Title.Name = "label_Title";
			this.label_Title.Size = new System.Drawing.Size(878, 25);
			this.label_Title.TabIndex = 0;
			this.label_Title.Text = "Graphs";
			this.label_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			this.tableLayoutPanel_Bentonit_La3.Size = new System.Drawing.Size(518, 267);
			this.tableLayoutPanel_Bentonit_La3.TabIndex = 1;
			// 
			// label_Bent
			// 
			this.label_Bent.AutoSize = true;
			this.label_Bent.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Bent.Location = new System.Drawing.Point(3, 0);
			this.label_Bent.Name = "label_Bent";
			this.label_Bent.Size = new System.Drawing.Size(512, 13);
			this.label_Bent.TabIndex = 0;
			this.label_Bent.Text = "Бентонит La3+";
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
			this.dataGridView_Bentonit_La3.Size = new System.Drawing.Size(512, 248);
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
			this.tableLayoutPanel_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 276);
			this.tableLayoutPanel_Kinetika_Sorb_La3.Name = "tableLayoutPanel_Kinetika_Sorb_La3";
			this.tableLayoutPanel_Kinetika_Sorb_La3.RowCount = 2;
			this.tableLayoutPanel_Kinetika_Sorb_La3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel_Kinetika_Sorb_La3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_Kinetika_Sorb_La3.Size = new System.Drawing.Size(518, 268);
			this.tableLayoutPanel_Kinetika_Sorb_La3.TabIndex = 2;
			// 
			// label_Kinetika_Sorb_La3
			// 
			this.label_Kinetika_Sorb_La3.AutoSize = true;
			this.label_Kinetika_Sorb_La3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 0);
			this.label_Kinetika_Sorb_La3.Name = "label_Kinetika_Sorb_La3";
			this.label_Kinetika_Sorb_La3.Size = new System.Drawing.Size(512, 13);
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
            this.Column_Kin_qe_qt,
            this.Column_Kin_log_qe_qt,
            this.Column_Kin_t_qt,
            this.Column_Kin_qt_ml});
			this.dataGridView_Kinetika_Sorb_La3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_Kinetika_Sorb_La3.Location = new System.Drawing.Point(3, 16);
			this.dataGridView_Kinetika_Sorb_La3.Name = "dataGridView_Kinetika_Sorb_La3";
			this.dataGridView_Kinetika_Sorb_La3.Size = new System.Drawing.Size(512, 249);
			this.dataGridView_Kinetika_Sorb_La3.TabIndex = 1;
			// 
			// Column_Kin_time
			// 
			this.Column_Kin_time.HeaderText = "обр\\врем";
			this.Column_Kin_time.Name = "Column_Kin_time";
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
			// Column_Kin_qt_ml
			// 
			this.Column_Kin_qt_ml.HeaderText = "qt, μмоль/г";
			this.Column_Kin_qt_ml.Name = "Column_Kin_qt_ml";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 28);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.chart1);
			this.splitContainer1.Size = new System.Drawing.Size(878, 547);
			this.splitContainer1.SplitterDistance = 524;
			this.splitContainer1.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.label_Title, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(884, 578);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(41, 95);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(300, 300);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 578);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.tableLayoutPanel1.ResumeLayout(false);
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
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_time;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_qe_qt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_log_qe_qt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_t_qt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kin_qt_ml;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
	}
}

