namespace Graphs
{
    partial class GraduationForm
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
            this.groupBox_GraduationList = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel_GraduationData = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_GraduationData = new System.Windows.Forms.DataGridView();
            this.dataGridView_GraduationData_Column_C_mkmol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_GraduationData_Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel_Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.button_AddGraduation = new System.Windows.Forms.Button();
            this.button_EditGraduation = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.groupBox_GraduationList.SuspendLayout();
            this.tableLayoutPanel_GraduationData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GraduationData)).BeginInit();
            this.tableLayoutPanel_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.groupBox_GraduationList, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_GraduationData, 0, 1);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Buttons, 0, 2);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 3;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // groupBox_GraduationList
            // 
            this.groupBox_GraduationList.Controls.Add(this.flowLayoutPanel1);
            this.groupBox_GraduationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_GraduationList.Location = new System.Drawing.Point(3, 3);
            this.groupBox_GraduationList.Name = "groupBox_GraduationList";
            this.groupBox_GraduationList.Size = new System.Drawing.Size(794, 144);
            this.groupBox_GraduationList.TabIndex = 0;
            this.groupBox_GraduationList.TabStop = false;
            this.groupBox_GraduationList.Text = "Градуировки";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(788, 125);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel_GraduationData
            // 
            this.tableLayoutPanel_GraduationData.ColumnCount = 1;
            this.tableLayoutPanel_GraduationData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_GraduationData.Controls.Add(this.dataGridView_GraduationData, 0, 0);
            this.tableLayoutPanel_GraduationData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_GraduationData.Location = new System.Drawing.Point(3, 153);
            this.tableLayoutPanel_GraduationData.Name = "tableLayoutPanel_GraduationData";
            this.tableLayoutPanel_GraduationData.RowCount = 1;
            this.tableLayoutPanel_GraduationData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_GraduationData.Size = new System.Drawing.Size(794, 144);
            this.tableLayoutPanel_GraduationData.TabIndex = 1;
            // 
            // dataGridView_GraduationData
            // 
            this.dataGridView_GraduationData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_GraduationData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_GraduationData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridView_GraduationData_Column_C_mkmol,
            this.dataGridView_GraduationData_Column_A});
            this.dataGridView_GraduationData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_GraduationData.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_GraduationData.Name = "dataGridView_GraduationData";
            this.dataGridView_GraduationData.Size = new System.Drawing.Size(788, 138);
            this.dataGridView_GraduationData.TabIndex = 0;
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
            // tableLayoutPanel_Buttons
            // 
            this.tableLayoutPanel_Buttons.ColumnCount = 2;
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_AddGraduation, 0, 0);
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_EditGraduation, 1, 0);
            this.tableLayoutPanel_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Buttons.Location = new System.Drawing.Point(3, 303);
            this.tableLayoutPanel_Buttons.Name = "tableLayoutPanel_Buttons";
            this.tableLayoutPanel_Buttons.RowCount = 1;
            this.tableLayoutPanel_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Buttons.Size = new System.Drawing.Size(794, 144);
            this.tableLayoutPanel_Buttons.TabIndex = 2;
            // 
            // button_AddGraduation
            // 
            this.button_AddGraduation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_AddGraduation.Location = new System.Drawing.Point(69, 43);
            this.button_AddGraduation.Name = "button_AddGraduation";
            this.button_AddGraduation.Size = new System.Drawing.Size(259, 58);
            this.button_AddGraduation.TabIndex = 0;
            this.button_AddGraduation.Text = "Добавить градуировку";
            this.button_AddGraduation.UseVisualStyleBackColor = true;
            this.button_AddGraduation.Click += new System.EventHandler(this.button_AddGraduation_Click);
            // 
            // button_EditGraduation
            // 
            this.button_EditGraduation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_EditGraduation.Location = new System.Drawing.Point(490, 46);
            this.button_EditGraduation.Name = "button_EditGraduation";
            this.button_EditGraduation.Size = new System.Drawing.Size(211, 51);
            this.button_EditGraduation.TabIndex = 1;
            this.button_EditGraduation.Text = "Редактировать";
            this.button_EditGraduation.UseVisualStyleBackColor = true;
            this.button_EditGraduation.Click += new System.EventHandler(this.button_EditGraduation_Click);
            // 
            // GraduationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Name = "GraduationForm";
            this.Text = "Graduation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraduationForm_FormClosed);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.groupBox_GraduationList.ResumeLayout(false);
            this.tableLayoutPanel_GraduationData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GraduationData)).EndInit();
            this.tableLayoutPanel_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.GroupBox groupBox_GraduationList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_GraduationData;
        private System.Windows.Forms.DataGridView dataGridView_GraduationData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Buttons;
        private System.Windows.Forms.Button button_AddGraduation;
        private System.Windows.Forms.Button button_EditGraduation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_GraduationData_Column_C_mkmol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridView_GraduationData_Column_A;
    }
}