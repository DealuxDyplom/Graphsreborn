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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.button_Compare = new System.Windows.Forms.Button();
            this.button_AddSubstance = new System.Windows.Forms.Button();
            this.button_EditSubstance = new System.Windows.Forms.Button();
            this.button_GraduationList = new System.Windows.Forms.Button();
            this.button_PsevdoGraphs = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Graphs = new System.Windows.Forms.TableLayoutPanel();
            this.chart_Graphs = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьГрадуировкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьГрадуировкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.tableLayoutPanel_Buttons.SuspendLayout();
            this.tableLayoutPanel_Graphs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Graphs)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(911, 520);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel_Main);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(903, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Кинетика";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.flowLayoutPanel, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Buttons, 0, 1);
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Graphs, 0, 2);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 3;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(897, 488);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // flowLayoutPanel
            // 
            this.tableLayoutPanel_Main.SetColumnSpan(this.flowLayoutPanel, 2);
            this.flowLayoutPanel.Controls.Add(this.label1);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(891, 94);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список растворов:";
            // 
            // tableLayoutPanel_Buttons
            // 
            this.tableLayoutPanel_Buttons.ColumnCount = 5;
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22223F));
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_Compare, 0, 0);
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_AddSubstance, 1, 0);
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_EditSubstance, 2, 0);
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_GraduationList, 3, 0);
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_PsevdoGraphs, 4, 0);
            this.tableLayoutPanel_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Buttons.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel_Buttons.Name = "tableLayoutPanel_Buttons";
            this.tableLayoutPanel_Buttons.RowCount = 1;
            this.tableLayoutPanel_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Buttons.Size = new System.Drawing.Size(891, 64);
            this.tableLayoutPanel_Buttons.TabIndex = 4;
            // 
            // button_Compare
            // 
            this.button_Compare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Compare.Location = new System.Drawing.Point(3, 10);
            this.button_Compare.Name = "button_Compare";
            this.button_Compare.Size = new System.Drawing.Size(125, 44);
            this.button_Compare.TabIndex = 2;
            this.button_Compare.Text = "Сравнить";
            this.button_Compare.UseVisualStyleBackColor = true;
            this.button_Compare.Click += new System.EventHandler(this.button_Compare_Click);
            // 
            // button_AddSubstance
            // 
            this.button_AddSubstance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_AddSubstance.Location = new System.Drawing.Point(134, 10);
            this.button_AddSubstance.Name = "button_AddSubstance";
            this.button_AddSubstance.Size = new System.Drawing.Size(125, 44);
            this.button_AddSubstance.TabIndex = 0;
            this.button_AddSubstance.Text = "Добавить новый раствор";
            this.button_AddSubstance.UseVisualStyleBackColor = true;
            this.button_AddSubstance.Click += new System.EventHandler(this.button_AddSubstance_Click);
            // 
            // button_EditSubstance
            // 
            this.button_EditSubstance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_EditSubstance.Location = new System.Drawing.Point(265, 10);
            this.button_EditSubstance.Name = "button_EditSubstance";
            this.button_EditSubstance.Size = new System.Drawing.Size(125, 44);
            this.button_EditSubstance.TabIndex = 3;
            this.button_EditSubstance.Text = "Редактировать раствор";
            this.button_EditSubstance.UseVisualStyleBackColor = true;
            this.button_EditSubstance.Click += new System.EventHandler(this.button_EditSubstance_Click);
            // 
            // button_GraduationList
            // 
            this.button_GraduationList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_GraduationList.Location = new System.Drawing.Point(396, 10);
            this.button_GraduationList.Name = "button_GraduationList";
            this.button_GraduationList.Size = new System.Drawing.Size(192, 44);
            this.button_GraduationList.TabIndex = 4;
            this.button_GraduationList.Text = "Открыть список градуировок";
            this.button_GraduationList.UseVisualStyleBackColor = true;
            this.button_GraduationList.Click += new System.EventHandler(this.button_GraduationList_Click);
            // 
            // button_PsevdoGraphs
            // 
            this.button_PsevdoGraphs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_PsevdoGraphs.Location = new System.Drawing.Point(675, 8);
            this.button_PsevdoGraphs.Name = "button_PsevdoGraphs";
            this.button_PsevdoGraphs.Size = new System.Drawing.Size(131, 47);
            this.button_PsevdoGraphs.TabIndex = 5;
            this.button_PsevdoGraphs.Text = "Показать псевдографики";
            this.button_PsevdoGraphs.UseVisualStyleBackColor = true;
            this.button_PsevdoGraphs.Click += new System.EventHandler(this.button_PsevdoGraphs_Click);
            // 
            // tableLayoutPanel_Graphs
            // 
            this.tableLayoutPanel_Graphs.ColumnCount = 1;
            this.tableLayoutPanel_Graphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Graphs.Controls.Add(this.chart_Graphs, 0, 0);
            this.tableLayoutPanel_Graphs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Graphs.Location = new System.Drawing.Point(3, 173);
            this.tableLayoutPanel_Graphs.Name = "tableLayoutPanel_Graphs";
            this.tableLayoutPanel_Graphs.RowCount = 1;
            this.tableLayoutPanel_Graphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Graphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Graphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Graphs.Size = new System.Drawing.Size(891, 312);
            this.tableLayoutPanel_Graphs.TabIndex = 5;
            // 
            // chart_Graphs
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_Graphs.ChartAreas.Add(chartArea1);
            this.chart_Graphs.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart_Graphs.Legends.Add(legend1);
            this.chart_Graphs.Location = new System.Drawing.Point(3, 3);
            this.chart_Graphs.Name = "chart_Graphs";
            this.chart_Graphs.Size = new System.Drawing.Size(885, 306);
            this.chart_Graphs.TabIndex = 3;
            this.chart_Graphs.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(903, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Изотермы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(911, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.сохранитьГрадуировкуToolStripMenuItem,
            this.загрузитьГрадуировкуToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 6);
            // 
            // сохранитьГрадуировкуToolStripMenuItem
            // 
            this.сохранитьГрадуировкуToolStripMenuItem.Name = "сохранитьГрадуировкуToolStripMenuItem";
            this.сохранитьГрадуировкуToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.сохранитьГрадуировкуToolStripMenuItem.Text = "Сохранить градуировку";
            this.сохранитьГрадуировкуToolStripMenuItem.Click += new System.EventHandler(this.сохранитьГрадуировкуToolStripMenuItem_Click);
            // 
            // загрузитьГрадуировкуToolStripMenuItem
            // 
            this.загрузитьГрадуировкуToolStripMenuItem.Name = "загрузитьГрадуировкуToolStripMenuItem";
            this.загрузитьГрадуировкуToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.загрузитьГрадуировкуToolStripMenuItem.Text = "Загрузить градуировку";
            this.загрузитьГрадуировкуToolStripMenuItem.Click += new System.EventHandler(this.загрузитьГрадуировкуToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 544);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.tableLayoutPanel_Buttons.ResumeLayout(false);
            this.tableLayoutPanel_Graphs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Graphs)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.Button button_AddSubstance;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button button_Compare;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Graphs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Buttons;
        private System.Windows.Forms.Button button_EditSubstance;
        private System.Windows.Forms.Button button_GraduationList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьГрадуировкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьГрадуировкуToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Graphs;
        private System.Windows.Forms.Button button_PsevdoGraphs;
    }
}

