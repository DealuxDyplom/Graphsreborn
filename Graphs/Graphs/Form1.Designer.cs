namespace Graphs
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label_Title = new Label();
			tableLayoutPanel1 = new TableLayoutPanel();
			dataGridView_Bentonit_La3 = new DataGridView();
			Column_time = new DataGridViewTextBoxColumn();
			Column_m_r = new DataGridViewTextBoxColumn();
			Column_A = new DataGridViewTextBoxColumn();
			Column_C = new DataGridViewTextBoxColumn();
			Column_qt = new DataGridViewTextBoxColumn();
			Column_qt_ml = new DataGridViewTextBoxColumn();
			Column_proc = new DataGridViewTextBoxColumn();
			tableLayoutPanel2 = new TableLayoutPanel();
			label_Table_2 = new Label();
			dataGridView_Kinetika_Sorb_La3 = new DataGridView();
			Column_Kin_time = new DataGridViewTextBoxColumn();
			Column_Kin_qt_ml = new DataGridViewTextBoxColumn();
			Column_Kin_qe_qt = new DataGridViewTextBoxColumn();
			Column_Kin_log_qe_qt = new DataGridViewTextBoxColumn();
			Column_Kin_t_qt = new DataGridViewTextBoxColumn();
			splitContainer1 = new SplitContainer();
			pictureBox_Graphic = new PictureBox();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView_Bentonit_La3).BeginInit();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView_Kinetika_Sorb_La3).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_Graphic).BeginInit();
			SuspendLayout();
			// 
			// label_Title
			// 
			label_Title.AutoSize = true;
			label_Title.BackColor = SystemColors.Control;
			label_Title.Dock = DockStyle.Top;
			label_Title.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label_Title.Location = new Point(3, 0);
			label_Title.Name = "label_Title";
			label_Title.Size = new Size(868, 32);
			label_Title.TabIndex = 0;
			label_Title.Text = "Graphs";
			label_Title.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(dataGridView_Bentonit_La3, 0, 1);
			tableLayoutPanel1.Controls.Add(label_Title, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 230F));
			tableLayoutPanel1.Size = new Size(874, 607);
			tableLayoutPanel1.TabIndex = 3;
			// 
			// dataGridView_Bentonit_La3
			// 
			dataGridView_Bentonit_La3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView_Bentonit_La3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridView_Bentonit_La3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_Bentonit_La3.Columns.AddRange(new DataGridViewColumn[] { Column_time, Column_m_r, Column_A, Column_C, Column_qt, Column_qt_ml, Column_proc });
			dataGridView_Bentonit_La3.Dock = DockStyle.Fill;
			dataGridView_Bentonit_La3.Location = new Point(3, 35);
			dataGridView_Bentonit_La3.Name = "dataGridView_Bentonit_La3";
			dataGridView_Bentonit_La3.Size = new Size(868, 339);
			dataGridView_Bentonit_La3.TabIndex = 1;
			dataGridView_Bentonit_La3.CellContentClick += dataGridView1_CellContentClick;
			// 
			// Column_time
			// 
			Column_time.HeaderText = "обр\\врем";
			Column_time.Name = "Column_time";
			// 
			// Column_m_r
			// 
			Column_m_r.HeaderText = "m, г";
			Column_m_r.Name = "Column_m_r";
			// 
			// Column_A
			// 
			Column_A.HeaderText = "A";
			Column_A.Name = "Column_A";
			// 
			// Column_C
			// 
			Column_C.HeaderText = "С,мкг/мл";
			Column_C.Name = "Column_C";
			Column_C.ReadOnly = true;
			// 
			// Column_qt
			// 
			Column_qt.HeaderText = "qt, мкг/г";
			Column_qt.Name = "Column_qt";
			Column_qt.ReadOnly = true;
			// 
			// Column_qt_ml
			// 
			Column_qt_ml.HeaderText = "qt, μмоль/г";
			Column_qt_ml.Name = "Column_qt_ml";
			Column_qt_ml.ReadOnly = true;
			// 
			// Column_proc
			// 
			Column_proc.HeaderText = "%";
			Column_proc.Name = "Column_proc";
			Column_proc.ReadOnly = true;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Controls.Add(label_Table_2, 0, 0);
			tableLayoutPanel2.Controls.Add(dataGridView_Kinetika_Sorb_La3, 0, 1);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(3, 380);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new Size(868, 224);
			tableLayoutPanel2.TabIndex = 2;
			// 
			// label_Table_2
			// 
			label_Table_2.AutoSize = true;
			label_Table_2.Dock = DockStyle.Fill;
			label_Table_2.Location = new Point(3, 0);
			label_Table_2.Name = "label_Table_2";
			label_Table_2.Size = new Size(862, 15);
			label_Table_2.TabIndex = 0;
			label_Table_2.Text = "Кинетика сорбции La3+ 0,7 (20°C) мкг/мл";
			label_Table_2.TextAlign = ContentAlignment.TopCenter;
			// 
			// dataGridView_Kinetika_Sorb_La3
			// 
			dataGridView_Kinetika_Sorb_La3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView_Kinetika_Sorb_La3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridView_Kinetika_Sorb_La3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_Kinetika_Sorb_La3.Columns.AddRange(new DataGridViewColumn[] { Column_Kin_time, Column_Kin_qt_ml, Column_Kin_qe_qt, Column_Kin_log_qe_qt, Column_Kin_t_qt });
			dataGridView_Kinetika_Sorb_La3.Dock = DockStyle.Fill;
			dataGridView_Kinetika_Sorb_La3.Location = new Point(3, 18);
			dataGridView_Kinetika_Sorb_La3.Name = "dataGridView_Kinetika_Sorb_La3";
			dataGridView_Kinetika_Sorb_La3.Size = new Size(862, 203);
			dataGridView_Kinetika_Sorb_La3.TabIndex = 1;
			// 
			// Column_Kin_time
			// 
			Column_Kin_time.HeaderText = "обр\\врем";
			Column_Kin_time.Name = "Column_Kin_time";
			// 
			// Column_Kin_qt_ml
			// 
			Column_Kin_qt_ml.HeaderText = "qt, μмоль/г";
			Column_Kin_qt_ml.Name = "Column_Kin_qt_ml";
			// 
			// Column_Kin_qe_qt
			// 
			Column_Kin_qe_qt.HeaderText = "qe-qt";
			Column_Kin_qe_qt.Name = "Column_Kin_qe_qt";
			// 
			// Column_Kin_log_qe_qt
			// 
			Column_Kin_log_qe_qt.HeaderText = "log(qe-qt)";
			Column_Kin_log_qe_qt.Name = "Column_Kin_log_qe_qt";
			// 
			// Column_Kin_t_qt
			// 
			Column_Kin_t_qt.HeaderText = "t\\qt";
			Column_Kin_t_qt.Name = "Column_Kin_t_qt";
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(pictureBox_Graphic);
			splitContainer1.Panel2.RightToLeft = RightToLeft.No;
			splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
			splitContainer1.Size = new Size(1265, 607);
			splitContainer1.SplitterDistance = 874;
			splitContainer1.TabIndex = 4;
			// 
			// pictureBox_Graphic
			// 
			pictureBox_Graphic.BackColor = SystemColors.ActiveCaption;
			pictureBox_Graphic.Location = new Point(45, 89);
			pictureBox_Graphic.Name = "pictureBox_Graphic";
			pictureBox_Graphic.Size = new Size(274, 391);
			pictureBox_Graphic.TabIndex = 0;
			pictureBox_Graphic.TabStop = false;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(96F, 96F);
			AutoScaleMode = AutoScaleMode.Dpi;
			ClientSize = new Size(1265, 607);
			Controls.Add(splitContainer1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView_Bentonit_La3).EndInit();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView_Kinetika_Sorb_La3).EndInit();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox_Graphic).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Label label_Title;
		private TableLayoutPanel tableLayoutPanel1;
		private DataGridView dataGridView_Bentonit_La3;
		private DataGridViewTextBoxColumn Column_time;
		private DataGridViewTextBoxColumn Column_m_r;
		private DataGridViewTextBoxColumn Column_A;
		private DataGridViewTextBoxColumn Column_C;
		private DataGridViewTextBoxColumn Column_qt;
		private DataGridViewTextBoxColumn Column_qt_ml;
		private DataGridViewTextBoxColumn Column_proc;
		private TableLayoutPanel tableLayoutPanel2;
		private Label label_Table_2;
		private DataGridView dataGridView_Kinetika_Sorb_La3;
		private DataGridViewTextBoxColumn Column_Kin_time;
		private DataGridViewTextBoxColumn Column_Kin_qt_ml;
		private DataGridViewTextBoxColumn Column_Kin_qe_qt;
		private DataGridViewTextBoxColumn Column_Kin_log_qe_qt;
		private DataGridViewTextBoxColumn Column_Kin_t_qt;
		private SplitContainer splitContainer1;
		private PictureBox pictureBox_Graphic;
	}
}
