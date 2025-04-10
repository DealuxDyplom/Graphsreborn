namespace Graphs
{
    partial class KineticModelTableForm
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
            this.tableLayoutPanel_ModelKin = new System.Windows.Forms.TableLayoutPanel();
            this.label_ModelKin = new System.Windows.Forms.Label();
            this.label_Sample = new System.Windows.Forms.Label();
            this.label_Equation = new System.Windows.Forms.Label();
            this.label_qe_mkmol = new System.Windows.Forms.Label();
            this.label_K1 = new System.Windows.Forms.Label();
            this.label_R2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.tableLayoutPanel_ModelKin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_ModelKin, 0, 0);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 1;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(773, 295);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // tableLayoutPanel_ModelKin
            // 
            this.tableLayoutPanel_ModelKin.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel_ModelKin.ColumnCount = 6;
            this.tableLayoutPanel_ModelKin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_ModelKin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_ModelKin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_ModelKin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_ModelKin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_ModelKin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_ModelKin.Controls.Add(this.label_ModelKin, 0, 0);
            this.tableLayoutPanel_ModelKin.Controls.Add(this.label_Sample, 1, 0);
            this.tableLayoutPanel_ModelKin.Controls.Add(this.label_Equation, 2, 0);
            this.tableLayoutPanel_ModelKin.Controls.Add(this.label_qe_mkmol, 3, 0);
            this.tableLayoutPanel_ModelKin.Controls.Add(this.label_K1, 4, 0);
            this.tableLayoutPanel_ModelKin.Controls.Add(this.label_R2, 5, 0);
            this.tableLayoutPanel_ModelKin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_ModelKin.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_ModelKin.Name = "tableLayoutPanel_ModelKin";
            this.tableLayoutPanel_ModelKin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel_ModelKin.RowCount = 1;
            this.tableLayoutPanel_ModelKin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_ModelKin.Size = new System.Drawing.Size(767, 289);
            this.tableLayoutPanel_ModelKin.TabIndex = 0;
            // 
            // label_ModelKin
            // 
            this.label_ModelKin.AutoSize = true;
            this.label_ModelKin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ModelKin.Location = new System.Drawing.Point(4, 1);
            this.label_ModelKin.Name = "label_ModelKin";
            this.label_ModelKin.Size = new System.Drawing.Size(120, 287);
            this.label_ModelKin.TabIndex = 0;
            this.label_ModelKin.Text = "Модель кинетики";
            this.label_ModelKin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Sample
            // 
            this.label_Sample.AutoSize = true;
            this.label_Sample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Sample.Location = new System.Drawing.Point(131, 1);
            this.label_Sample.Name = "label_Sample";
            this.label_Sample.Size = new System.Drawing.Size(120, 287);
            this.label_Sample.TabIndex = 1;
            this.label_Sample.Text = "Образец";
            this.label_Sample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Equation
            // 
            this.label_Equation.AutoSize = true;
            this.label_Equation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Equation.Location = new System.Drawing.Point(258, 1);
            this.label_Equation.Name = "label_Equation";
            this.label_Equation.Size = new System.Drawing.Size(120, 287);
            this.label_Equation.TabIndex = 2;
            this.label_Equation.Text = "Уравнение аппроксимации";
            this.label_Equation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_qe_mkmol
            // 
            this.label_qe_mkmol.AutoSize = true;
            this.label_qe_mkmol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_qe_mkmol.Location = new System.Drawing.Point(385, 1);
            this.label_qe_mkmol.Name = "label_qe_mkmol";
            this.label_qe_mkmol.Size = new System.Drawing.Size(120, 287);
            this.label_qe_mkmol.TabIndex = 3;
            this.label_qe_mkmol.Text = "qe, (мкмоль/г)";
            this.label_qe_mkmol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_K1
            // 
            this.label_K1.AutoSize = true;
            this.label_K1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_K1.Location = new System.Drawing.Point(512, 1);
            this.label_K1.Name = "label_K1";
            this.label_K1.Size = new System.Drawing.Size(120, 287);
            this.label_K1.TabIndex = 4;
            this.label_K1.Text = "K1, (мин^-1)";
            this.label_K1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_R2
            // 
            this.label_R2.AutoSize = true;
            this.label_R2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_R2.Location = new System.Drawing.Point(639, 1);
            this.label_R2.Name = "label_R2";
            this.label_R2.Size = new System.Drawing.Size(124, 287);
            this.label_R2.TabIndex = 5;
            this.label_R2.Text = "R^2";
            this.label_R2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KineticModelTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 295);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Name = "KineticModelTableForm";
            this.Text = "KineticModelTableForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KineticModelTableForm_FormClosed);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.tableLayoutPanel_ModelKin.ResumeLayout(false);
            this.tableLayoutPanel_ModelKin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ModelKin;
        private System.Windows.Forms.Label label_ModelKin;
        private System.Windows.Forms.Label label_Sample;
        private System.Windows.Forms.Label label_Equation;
        private System.Windows.Forms.Label label_qe_mkmol;
        private System.Windows.Forms.Label label_K1;
        private System.Windows.Forms.Label label_R2;
    }
}