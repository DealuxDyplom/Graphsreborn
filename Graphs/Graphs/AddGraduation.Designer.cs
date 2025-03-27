namespace Graphs
{
    partial class AddGraduation
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_GraduationName = new System.Windows.Forms.Label();
            this.textBox_GraduationName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.button_FillFromFile = new System.Windows.Forms.Button();
            this.button_AddGraduation = new System.Windows.Forms.Button();
            this.dataGridView_GraduationData = new System.Windows.Forms.DataGridView();
            this.dataGridView_GraduationData_Column_C_mkmol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_GraduationData_Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GraduationData)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Buttons, 0, 2);
            this.tableLayoutPanel_Main.Controls.Add(this.dataGridView_GraduationData, 0, 1);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 3;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(794, 313);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_GraduationName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_GraduationName, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(788, 24);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_GraduationName
            // 
            this.label_GraduationName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_GraduationName.AutoSize = true;
            this.label_GraduationName.Location = new System.Drawing.Point(20, 5);
            this.label_GraduationName.Name = "label_GraduationName";
            this.label_GraduationName.Size = new System.Drawing.Size(127, 13);
            this.label_GraduationName.TabIndex = 0;
            this.label_GraduationName.Text = "Название градуировки:";
            // 
            // textBox_GraduationName
            // 
            this.textBox_GraduationName.Location = new System.Drawing.Point(153, 3);
            this.textBox_GraduationName.Name = "textBox_GraduationName";
            this.textBox_GraduationName.Size = new System.Drawing.Size(229, 20);
            this.textBox_GraduationName.TabIndex = 1;
            // 
            // tableLayoutPanel_Buttons
            // 
            this.tableLayoutPanel_Buttons.ColumnCount = 1;
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_FillFromFile, 0, 0);
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_AddGraduation, 0, 1);
            this.tableLayoutPanel_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Buttons.Location = new System.Drawing.Point(3, 216);
            this.tableLayoutPanel_Buttons.Name = "tableLayoutPanel_Buttons";
            this.tableLayoutPanel_Buttons.RowCount = 2;
            this.tableLayoutPanel_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Buttons.Size = new System.Drawing.Size(788, 94);
            this.tableLayoutPanel_Buttons.TabIndex = 1;
            // 
            // button_FillFromFile
            // 
            this.button_FillFromFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_FillFromFile.Location = new System.Drawing.Point(316, 8);
            this.button_FillFromFile.Name = "button_FillFromFile";
            this.button_FillFromFile.Size = new System.Drawing.Size(156, 30);
            this.button_FillFromFile.TabIndex = 0;
            this.button_FillFromFile.Text = "Заполнить из файла";
            this.button_FillFromFile.UseVisualStyleBackColor = true;
            this.button_FillFromFile.Click += new System.EventHandler(this.button_FillFromFile_Click);
            // 
            // button_AddGraduation
            // 
            this.button_AddGraduation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_AddGraduation.Location = new System.Drawing.Point(306, 56);
            this.button_AddGraduation.Name = "button_AddGraduation";
            this.button_AddGraduation.Size = new System.Drawing.Size(175, 28);
            this.button_AddGraduation.TabIndex = 1;
            this.button_AddGraduation.Text = "Добавить градуировку";
            this.button_AddGraduation.UseVisualStyleBackColor = true;
            this.button_AddGraduation.Click += new System.EventHandler(this.button_AddGraduation_Click);
            // 
            // dataGridView_GraduationData
            // 
            this.dataGridView_GraduationData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_GraduationData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_GraduationData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridView_GraduationData_Column_C_mkmol,
            this.dataGridView_GraduationData_Column_A});
            this.dataGridView_GraduationData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_GraduationData.Location = new System.Drawing.Point(3, 33);
            this.dataGridView_GraduationData.Name = "dataGridView_GraduationData";
            this.dataGridView_GraduationData.Size = new System.Drawing.Size(788, 177);
            this.dataGridView_GraduationData.TabIndex = 2;
            // 
            // dataGridView_GraduationData_Column_C_mkmol
            // 
            this.dataGridView_GraduationData_Column_C_mkmol.HeaderText = "С,мкг/мл";
            this.dataGridView_GraduationData_Column_C_mkmol.Name = "dataGridView_GraduationData_Column_C_mkmol";
            // 
            // dataGridView_GraduationData_Column_A
            // 
            this.dataGridView_GraduationData_Column_A.HeaderText = "A";
            this.dataGridView_GraduationData_Column_A.Name = "dataGridView_GraduationData_Column_A";
            // 
            // AddGraduation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 313);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Name = "AddGraduation";
            this.Text = "AddGraduation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddGraduation_FormClosed);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel_Buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GraduationData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_GraduationName;
        private System.Windows.Forms.TextBox textBox_GraduationName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Buttons;
        private System.Windows.Forms.Button button_FillFromFile;
        private System.Windows.Forms.Button button_AddGraduation;
        private System.Windows.Forms.DataGridView dataGridView_GraduationData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_GraduationData_Column_C_mkmol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_GraduationData_Column_A;
    }
}