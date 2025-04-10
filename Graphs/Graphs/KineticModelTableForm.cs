using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs
{
    public partial class KineticModelTableForm: Form
    {
        Form1 parent;
        int decimalPlaces = 3; //округление значений до заданного количества знаков после запятой для таблиц
        public KineticModelTableForm(Form1 owner)
        {
            parent = owner;
            InitializeComponent();
            
            //fill by psevdo 1
            for (int i = 0; i < Databank.substances.Count; i++) { 
                Label label = new Label();
                label.Text = Databank.substances[i].name;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Font = new Font("Microsoft Sans Serif", label.Font.Size, FontStyle.Underline);
                label.Cursor = Cursors.Hand;
                label.MouseClick += label_ClickShowPsevdoGraph;

                tableLayoutPanel_ModelKin.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                tableLayoutPanel_ModelKin.Controls.Add(label, 1, i + 1);

                //create Equation
                double y_sum = 0;
                double x_sum = 0;
                double x_2_sum = 0;
                double xy_sum = 0;

                for (int j = 0; j < Databank.substances[i].data.Count; j++)
                {
                    y_sum += Databank.substances[i].data[j].log_qe_qt;
                    x_sum += Databank.substances[i].data[j].time;
                    x_2_sum += Databank.substances[i].data[j].time * Databank.substances[i].data[j].time;
                    xy_sum += Databank.substances[i].data[j].log_qe_qt * Databank.substances[i].data[j].time;
                }

                double y_srd = y_sum / Databank.substances[i].data.Count;
                double x_srd = x_sum / Databank.substances[i].data.Count;
                double x_2_srd = x_2_sum / Databank.substances[i].data.Count;
                double xy_srd = xy_sum / Databank.substances[i].data.Count;

                double b = (xy_sum - Databank.substances[i].data.Count * x_srd * y_srd) / (x_2_sum - Databank.substances[i].data.Count * x_srd * x_srd);
                double a = y_srd - b * x_srd;

                Label label_Equation_psevdo_1 = new Label();
                label_Equation_psevdo_1.Text = "y = " + Math.Round(a, decimalPlaces).ToString() + " + " + Math.Round(b, decimalPlaces).ToString() + " * x";
                label_Equation_psevdo_1.Dock = DockStyle.Fill;
                label_Equation_psevdo_1.TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel_ModelKin.Controls.Add(label_Equation_psevdo_1, 2, i + 1);

                //find out determination
                double SS_tot = 0;
                double SS_res = 0;
                double SS_reg = 0;
                for (int j = 0; j < Databank.substances[i].data.Count; j++)
                {
                    double y_res = a + b * Databank.substances[i].data[j].time;
                    SS_res += (Databank.substances[i].data[j].log_qe_qt - y_res) * (Databank.substances[i].data[j].log_qe_qt - y_res);
                    SS_reg += (y_res - y_srd) * (y_res - y_srd);
                }

                SS_tot = SS_reg + SS_res;

                double determination = SS_reg / SS_tot;

                Label label_R2_psevdo_1 = new Label();
                label_R2_psevdo_1.Text = Math.Round(determination, decimalPlaces).ToString(); ;
                label_R2_psevdo_1.Dock = DockStyle.Fill;
                label_R2_psevdo_1.TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel_ModelKin.Controls.Add(label_R2_psevdo_1, 5, i + 1);

                //find out Qe1
                Label label_qe1_psevdo_1 = new Label();
                label_qe1_psevdo_1.Text = Math.Round(Databank.substances[i].data[0].Qe1, decimalPlaces).ToString();
                label_qe1_psevdo_1.Dock = DockStyle.Fill;
                label_qe1_psevdo_1.TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel_ModelKin.Controls.Add(label_qe1_psevdo_1, 3, i + 1);

                //find out K1
                double k1 = -(b * 2.303);

                Label label_k1_psevdo_1 = new Label();
                label_k1_psevdo_1.Text = Math.Round(k1, decimalPlaces).ToString();
                label_k1_psevdo_1.Dock = DockStyle.Fill;
                label_k1_psevdo_1.TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel_ModelKin.Controls.Add(label_k1_psevdo_1, 4, i + 1);
            }

            Label label_psevdo1 = new Label();
            label_psevdo1.Text = "Псевдо-первый порядок";
            label_psevdo1.Dock = DockStyle.Fill;
            label_psevdo1.TextAlign = ContentAlignment.MiddleCenter;

            tableLayoutPanel_ModelKin.Controls.Add(label_psevdo1, 0, 1);
            tableLayoutPanel_ModelKin.SetRowSpan(label_psevdo1, Databank.substances.Count);

            //fill by psevdo 2
            for (int i = 0; i < Databank.substances.Count; i++)
            {
                Label label = new Label();
                label.Text = Databank.substances[i].name;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Font = new Font("Microsoft Sans Serif", label.Font.Size, FontStyle.Underline);
                label.Cursor = Cursors.Hand;
                label.MouseClick += label_ClickShowPsevdoGraph;

                tableLayoutPanel_ModelKin.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                tableLayoutPanel_ModelKin.Controls.Add(label, 1, (i + 1) + Databank.substances.Count);

                //create Equation
                double y_sum = 0;
                double x_sum = 0;
                double x_2_sum = 0;
                double xy_sum = 0;

                for (int j = 0; j < Databank.substances[i].data.Count; j++)
                {
                    y_sum += Databank.substances[i].data[j].t_qt;
                    x_sum += Databank.substances[i].data[j].time;
                    x_2_sum += Databank.substances[i].data[j].time * Databank.substances[i].data[j].time;
                    xy_sum += Databank.substances[i].data[j].t_qt * Databank.substances[i].data[j].time;
                }

                double y_srd = y_sum / Databank.substances[i].data.Count;
                double x_srd = x_sum / Databank.substances[i].data.Count;
                double x_2_srd = x_2_sum / Databank.substances[i].data.Count;
                double xy_srd = xy_sum / Databank.substances[i].data.Count;

                double b = (xy_sum - Databank.substances[i].data.Count * x_srd * y_srd) / (x_2_sum - Databank.substances[i].data.Count * x_srd * x_srd);
                double a = y_srd - b * x_srd;

                Label label_Equation_psevdo_2 = new Label();
                label_Equation_psevdo_2.Text = "y = " + Math.Round(a, decimalPlaces).ToString() + " + " + Math.Round(b, decimalPlaces).ToString() + " * x";
                label_Equation_psevdo_2.Dock = DockStyle.Fill;
                label_Equation_psevdo_2.TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel_ModelKin.Controls.Add(label_Equation_psevdo_2, 2, i + 1 + Databank.substances.Count);

                //find out determination
                double SS_tot = 0;
                double SS_res = 0;
                double SS_reg = 0;
                for (int j = 0; j < Databank.substances[i].data.Count; j++)
                {
                    double y_res = a + b * Databank.substances[i].data[j].time;
                    SS_res += (Databank.substances[i].data[j].t_qt - y_res) * (Databank.substances[i].data[j].t_qt - y_res);
                    SS_reg += (y_res - y_srd) * (y_res - y_srd);
                }

                SS_tot = SS_reg + SS_res;

                double determination = SS_reg / SS_tot;

                Label label_R2_psevdo_2 = new Label();
                label_R2_psevdo_2.Text = Math.Round(determination, decimalPlaces).ToString(); ;
                label_R2_psevdo_2.Dock = DockStyle.Fill;
                label_R2_psevdo_2.TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel_ModelKin.Controls.Add(label_R2_psevdo_2, 5, i + 1 + Databank.substances.Count);

                //find out Qe2
                double Qe2 = 1 / b;
                Label label_qe2_psevdo_2 = new Label();
                label_qe2_psevdo_2.Text = Math.Round(Qe2, decimalPlaces).ToString();
                label_qe2_psevdo_2.Dock = DockStyle.Fill;
                label_qe2_psevdo_2.TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel_ModelKin.Controls.Add(label_qe2_psevdo_2, 3, i + 1 + Databank.substances.Count);

                //find out K2
                double k2 = 1 / (0.16 / (1 / (Qe2 * Qe2)));

                Label label_k2_psevdo_2 = new Label();
                label_k2_psevdo_2.Text = Math.Round(k2, decimalPlaces).ToString();
                label_k2_psevdo_2.Dock = DockStyle.Fill;
                label_k2_psevdo_2.TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel_ModelKin.Controls.Add(label_k2_psevdo_2, 4, i + 1 + Databank.substances.Count);
            }

            Label label_psevdo2 = new Label();
            label_psevdo2.Text = "Псевдо-второй порядок";
            label_psevdo2.Dock = DockStyle.Fill;
            label_psevdo2.TextAlign = ContentAlignment.MiddleCenter;

            tableLayoutPanel_ModelKin.Controls.Add(label_psevdo2, 0, 1 + Databank.substances.Count);
            tableLayoutPanel_ModelKin.SetRowSpan(label_psevdo2, Databank.substances.Count);

        }

        private void label_ClickShowPsevdoGraph(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < Databank.substances.Count; i++) {
                if (Databank.substances[i].name == ((Label)sender).Text) {
                    Label label = ((Label)sender);
                    int psevdo = 0;
                    if (tableLayoutPanel_ModelKin.GetRow(label) > Databank.substances.Count)
                    {
                        psevdo = 2;
                    }
                    else {
                        psevdo = 1;
                    }
                    PsevdoGraphsSingleForm psevdoGraphsSingleForm = new PsevdoGraphsSingleForm(Databank.substances[i], psevdo, this);
                    psevdoGraphsSingleForm.Show();
                    this.Hide();
                }
            }
        }

        private void KineticModelTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }
    }
}
