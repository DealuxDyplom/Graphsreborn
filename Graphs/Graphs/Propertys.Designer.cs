namespace Graphs
{
    partial class Propertys
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_A_src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_m_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_mkmol_l_src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_mkmol_l = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Q_mk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_time,
            this.Column_A_src,
            this.Column_m_r,
            this.Column_A,
            this.Column_C_mkmol_l_src,
            this.Column_C_mkmol_l,
            this.Column_Q_mk});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(720, 255);
            this.dataGridView.TabIndex = 0;
            // 
            // Column_time
            // 
            this.Column_time.HeaderText = "обр/время";
            this.Column_time.Name = "Column_time";
            // 
            // Column_A_src
            // 
            this.Column_A_src.HeaderText = "А, исх";
            this.Column_A_src.Name = "Column_A_src";
            // 
            // Column_m_r
            // 
            this.Column_m_r.HeaderText = "m, г";
            this.Column_m_r.Name = "Column_m_r";
            // 
            // Column_A
            // 
            this.Column_A.HeaderText = "A";
            this.Column_A.Name = "Column_A";
            // 
            // Column_C_mkmol_l_src
            // 
            this.Column_C_mkmol_l_src.HeaderText = "С, мкмоль/л, исх";
            this.Column_C_mkmol_l_src.Name = "Column_C_mkmol_l_src";
            // 
            // Column_C_mkmol_l
            // 
            this.Column_C_mkmol_l.HeaderText = "С, мкмоль/л";
            this.Column_C_mkmol_l.Name = "Column_C_mkmol_l";
            // 
            // Column_Q_mk
            // 
            this.Column_Q_mk.HeaderText = "Q, мкмоль/г";
            this.Column_Q_mk.Name = "Column_Q_mk";
            // 
            // Propertys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 255);
            this.Controls.Add(this.dataGridView);
            this.Name = "Propertys";
            this.Text = "Propertys";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_A_src;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_m_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_mkmol_l_src;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_mkmol_l;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Q_mk;
    }
}