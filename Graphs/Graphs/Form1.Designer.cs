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
			dataGridView_Bentonit_La3 = new DataGridView();
			Column_time = new DataGridViewTextBoxColumn();
			Column_m_r = new DataGridViewTextBoxColumn();
			Column_A = new DataGridViewTextBoxColumn();
			Column_C = new DataGridViewTextBoxColumn();
			Column_qt = new DataGridViewTextBoxColumn();
			Column_qt_ml = new DataGridViewTextBoxColumn();
			Column_proc = new DataGridViewTextBoxColumn();
			groupBox1 = new GroupBox();
			((System.ComponentModel.ISupportInitialize)dataGridView_Bentonit_La3).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// label_Title
			// 
			label_Title.Anchor = AnchorStyles.Top;
			label_Title.AutoSize = true;
			label_Title.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label_Title.Location = new Point(541, 9);
			label_Title.Name = "label_Title";
			label_Title.Size = new Size(88, 32);
			label_Title.TabIndex = 0;
			label_Title.Text = "Graphs";
			// 
			// dataGridView_Bentonit_La3
			// 
			dataGridView_Bentonit_La3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_Bentonit_La3.Columns.AddRange(new DataGridViewColumn[] { Column_time, Column_m_r, Column_A, Column_C, Column_qt, Column_qt_ml, Column_proc });
			dataGridView_Bentonit_La3.Dock = DockStyle.Fill;
			dataGridView_Bentonit_La3.Location = new Point(3, 19);
			dataGridView_Bentonit_La3.Name = "dataGridView_Bentonit_La3";
			dataGridView_Bentonit_La3.Size = new Size(961, 314);
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
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top;
			groupBox1.AutoSize = true;
			groupBox1.Controls.Add(dataGridView_Bentonit_La3);
			groupBox1.ImeMode = ImeMode.NoControl;
			groupBox1.Location = new Point(91, 79);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(967, 336);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Enter += groupBox1_Enter;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(96F, 96F);
			AutoScaleMode = AutoScaleMode.Dpi;
			ClientSize = new Size(1176, 488);
			Controls.Add(groupBox1);
			Controls.Add(label_Title);
			Name = "Form1";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)dataGridView_Bentonit_La3).EndInit();
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label_Title;
		private DataGridView dataGridView_Bentonit_La3;
		private DataGridViewTextBoxColumn Column_time;
		private DataGridViewTextBoxColumn Column_m_r;
		private DataGridViewTextBoxColumn Column_A;
		private DataGridViewTextBoxColumn Column_C;
		private DataGridViewTextBoxColumn Column_qt;
		private DataGridViewTextBoxColumn Column_qt_ml;
		private DataGridViewTextBoxColumn Column_proc;
		private GroupBox groupBox1;
	}
}
