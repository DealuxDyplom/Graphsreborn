namespace Graphs
{
    partial class AddSubstance
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Substance = new System.Windows.Forms.DataGridView();
            this.Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A_src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_m_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_mkmol_l_src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_mkmol_l = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Q_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Add = new System.Windows.Forms.Button();
            this.textBox_NameSubstance = new System.Windows.Forms.TextBox();
            this.button_FillFromFile = new System.Windows.Forms.Button();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Substance)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.dataGridView_Substance, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.button_Add, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.textBox_NameSubstance, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.button_FillFromFile, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.button_Calculate, 1, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1224, 550);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите данные";
            // 
            // dataGridView_Substance
            // 
            this.dataGridView_Substance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Substance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_time,
            this.A_src,
            this.Column_m_r,
            this.Column_A,
            this.Column_C_mkmol_l_src,
            this.Column_C_mkmol_l,
            this.Column_Q_ml});
            this.tableLayoutPanelMain.SetColumnSpan(this.dataGridView_Substance, 3);
            this.dataGridView_Substance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Substance.Location = new System.Drawing.Point(3, 186);
            this.dataGridView_Substance.Name = "dataGridView_Substance";
            this.dataGridView_Substance.Size = new System.Drawing.Size(1218, 177);
            this.dataGridView_Substance.TabIndex = 1;
            // 
            // Column_time
            // 
            this.Column_time.HeaderText = "обр\\врем";
            this.Column_time.Name = "Column_time";
            // 
            // A_src
            // 
            this.A_src.HeaderText = "A, исх";
            this.A_src.Name = "A_src";
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
            // Column_C_mkmol_l_src
            // 
            this.Column_C_mkmol_l_src.HeaderText = "С,мкмоль/л исх";
            this.Column_C_mkmol_l_src.Name = "Column_C_mkmol_l_src";
            // 
            // Column_C_mkmol_l
            // 
            this.Column_C_mkmol_l.HeaderText = "С,мкмоль/л";
            this.Column_C_mkmol_l.Name = "Column_C_mkmol_l";
            // 
            // Column_Q_ml
            // 
            this.Column_Q_ml.HeaderText = "Q, мкмоль/г";
            this.Column_Q_ml.Name = "Column_Q_ml";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(3, 369);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // textBox_NameSubstance
            // 
            this.textBox_NameSubstance.Location = new System.Drawing.Point(411, 3);
            this.textBox_NameSubstance.Name = "textBox_NameSubstance";
            this.textBox_NameSubstance.Size = new System.Drawing.Size(100, 20);
            this.textBox_NameSubstance.TabIndex = 4;
            // 
            // button_FillFromFile
            // 
            this.button_FillFromFile.Location = new System.Drawing.Point(819, 369);
            this.button_FillFromFile.Name = "button_FillFromFile";
            this.button_FillFromFile.Size = new System.Drawing.Size(119, 23);
            this.button_FillFromFile.TabIndex = 3;
            this.button_FillFromFile.Text = "Заполнить из файла";
            this.button_FillFromFile.UseVisualStyleBackColor = true;
            this.button_FillFromFile.Click += new System.EventHandler(this.button_FillFromFile_Click);
            // 
            // button_Calculate
            // 
            this.button_Calculate.Location = new System.Drawing.Point(411, 369);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(75, 23);
            this.button_Calculate.TabIndex = 5;
            this.button_Calculate.Text = "Расчитать";
            this.button_Calculate.UseVisualStyleBackColor = true;
            this.button_Calculate.Click += new System.EventHandler(this.button_Calculate_Click);
            // 
            // AddSubstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 550);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "AddSubstance";
            this.Text = "AddSubstance";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Substance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Substance;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_FillFromFile;
        private System.Windows.Forms.TextBox textBox_NameSubstance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn A_src;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_m_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_mkmol_l_src;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_mkmol_l;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Q_ml;
        private System.Windows.Forms.Button button_Calculate;
    }
}