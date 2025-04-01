namespace Graphs
{
    partial class EditSubstanceForm
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
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.dataGridView_Data_Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Data_Column_m_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Data_Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Data_Column_C_mkmol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Data_Column_qt_mr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Data_Column_qt_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Data_Column_proc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Data_Column_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Data_Column_log_qe_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Data_Column_t_qt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel_Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.button_SaveEdits = new System.Windows.Forms.Button();
            this.tableLayoutPanel_ListSubstances = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.tableLayoutPanel_Buttons.SuspendLayout();
            this.tableLayoutPanel_ListSubstances.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.dataGridView_Data, 0, 1);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Buttons, 0, 2);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_ListSubstances, 0, 0);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 3;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(801, 362);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridView_Data_Column_time,
            this.dataGridView_Data_Column_m_r,
            this.dataGridView_Data_Column_A,
            this.dataGridView_Data_Column_C_mkmol,
            this.dataGridView_Data_Column_qt_mr,
            this.dataGridView_Data_Column_qt_ml,
            this.dataGridView_Data_Column_proc,
            this.dataGridView_Data_Column_qe_qt,
            this.dataGridView_Data_Column_log_qe_qt,
            this.dataGridView_Data_Column_t_qt});
            this.dataGridView_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Data.Location = new System.Drawing.Point(3, 33);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.Size = new System.Drawing.Size(795, 276);
            this.dataGridView_Data.TabIndex = 1;
            // 
            // dataGridView_Data_Column_time
            // 
            this.dataGridView_Data_Column_time.HeaderText = "обр/врем";
            this.dataGridView_Data_Column_time.Name = "dataGridView_Data_Column_time";
            // 
            // dataGridView_Data_Column_m_r
            // 
            this.dataGridView_Data_Column_m_r.HeaderText = "m, г";
            this.dataGridView_Data_Column_m_r.Name = "dataGridView_Data_Column_m_r";
            // 
            // dataGridView_Data_Column_A
            // 
            this.dataGridView_Data_Column_A.HeaderText = "A";
            this.dataGridView_Data_Column_A.Name = "dataGridView_Data_Column_A";
            // 
            // dataGridView_Data_Column_C_mkmol
            // 
            this.dataGridView_Data_Column_C_mkmol.HeaderText = "С,мкг/мл";
            this.dataGridView_Data_Column_C_mkmol.Name = "dataGridView_Data_Column_C_mkmol";
            // 
            // dataGridView_Data_Column_qt_mr
            // 
            this.dataGridView_Data_Column_qt_mr.HeaderText = "qt, мкг/г";
            this.dataGridView_Data_Column_qt_mr.Name = "dataGridView_Data_Column_qt_mr";
            // 
            // dataGridView_Data_Column_qt_ml
            // 
            this.dataGridView_Data_Column_qt_ml.HeaderText = "qt, μмоль/г";
            this.dataGridView_Data_Column_qt_ml.Name = "dataGridView_Data_Column_qt_ml";
            // 
            // dataGridView_Data_Column_proc
            // 
            this.dataGridView_Data_Column_proc.HeaderText = "%";
            this.dataGridView_Data_Column_proc.Name = "dataGridView_Data_Column_proc";
            // 
            // dataGridView_Data_Column_qe_qt
            // 
            this.dataGridView_Data_Column_qe_qt.HeaderText = "qe-qt";
            this.dataGridView_Data_Column_qe_qt.Name = "dataGridView_Data_Column_qe_qt";
            // 
            // dataGridView_Data_Column_log_qe_qt
            // 
            this.dataGridView_Data_Column_log_qe_qt.HeaderText = "log(qe-qt)";
            this.dataGridView_Data_Column_log_qe_qt.Name = "dataGridView_Data_Column_log_qe_qt";
            // 
            // dataGridView_Data_Column_t_qt
            // 
            this.dataGridView_Data_Column_t_qt.HeaderText = "t\\qt";
            this.dataGridView_Data_Column_t_qt.Name = "dataGridView_Data_Column_t_qt";
            // 
            // tableLayoutPanel_Buttons
            // 
            this.tableLayoutPanel_Buttons.ColumnCount = 1;
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_SaveEdits, 0, 0);
            this.tableLayoutPanel_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Buttons.Location = new System.Drawing.Point(3, 315);
            this.tableLayoutPanel_Buttons.Name = "tableLayoutPanel_Buttons";
            this.tableLayoutPanel_Buttons.RowCount = 1;
            this.tableLayoutPanel_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Buttons.Size = new System.Drawing.Size(795, 44);
            this.tableLayoutPanel_Buttons.TabIndex = 2;
            // 
            // button_SaveEdits
            // 
            this.button_SaveEdits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_SaveEdits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SaveEdits.Location = new System.Drawing.Point(300, 3);
            this.button_SaveEdits.Name = "button_SaveEdits";
            this.button_SaveEdits.Size = new System.Drawing.Size(195, 38);
            this.button_SaveEdits.TabIndex = 0;
            this.button_SaveEdits.Text = " Сохранить изменения";
            this.button_SaveEdits.UseVisualStyleBackColor = true;
            this.button_SaveEdits.Click += new System.EventHandler(this.button_SaveEdits_Click);
            // 
            // tableLayoutPanel_ListSubstances
            // 
            this.tableLayoutPanel_ListSubstances.ColumnCount = 2;
            this.tableLayoutPanel_ListSubstances.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_ListSubstances.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ListSubstances.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel_ListSubstances.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel_ListSubstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_ListSubstances.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_ListSubstances.Name = "tableLayoutPanel_ListSubstances";
            this.tableLayoutPanel_ListSubstances.RowCount = 1;
            this.tableLayoutPanel_ListSubstances.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ListSubstances.Size = new System.Drawing.Size(795, 24);
            this.tableLayoutPanel_ListSubstances.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(153, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(271, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите раствор:";
            // 
            // EditSubstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 362);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Name = "EditSubstanceForm";
            this.Text = "EditSubstance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditSubstanceForm_FormClosed);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.tableLayoutPanel_Buttons.ResumeLayout(false);
            this.tableLayoutPanel_ListSubstances.ResumeLayout(false);
            this.tableLayoutPanel_ListSubstances.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Buttons;
        private System.Windows.Forms.Button button_SaveEdits;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ListSubstances;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_m_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_C_mkmol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_qt_mr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_qt_ml;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_proc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_qe_qt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_log_qe_qt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_Data_Column_t_qt;
    }
}