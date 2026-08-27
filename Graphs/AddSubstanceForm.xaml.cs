using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.LinkLabel;
using System.Windows.Forms;

namespace Graphs
{
    /// <summary>
    /// Логика взаимодействия для AddSubstanceForm.xaml
    /// </summary>

    public partial class AddSubstanceForm
    {
        public ObservableCollection<ExprData_Row> exprData_Row_List;
        public ObservableCollection<Graduation_Row> graduation_Row_List;
        public ObservableCollection<Data_Row> data_Row_List;

        MainWindow parent;
        bool Recalulate_done = false;
        double Grad_K;
        Substance substance;
        public AddSubstanceForm(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();
            
            //initialize dataGrid tables
            exprData_Row_List = new ObservableCollection<ExprData_Row>();
            graduation_Row_List = new ObservableCollection<Graduation_Row>();
            data_Row_List = new ObservableCollection<Data_Row>();
            DataGrid_ExprData.ItemsSource = exprData_Row_List;
            DataGrid_Graduation.ItemsSource = graduation_Row_List;
            DataGrid_Data.ItemsSource = data_Row_List;

            //initialize ComboBox_Graduation and DataGrid_Graduation
            for (int i = 0; i < Databank.graduations.Count; i++)
            {
                ComboBox_Graduation.Items.Add(Databank.graduations[i].name);
            }
            if (Databank.graduations.Count > 0)
            {
                ComboBox_Graduation.Text = Databank.graduations[0].name.ToString();
                for (int i = 0; i < Databank.graduations[0].data.Count; i++)
                {
                    Graduation_Row graduation_Row = new Graduation_Row();
                    graduation_Row.C_mkmol = Databank.graduations[0].data[i].C_mkmol;
                    graduation_Row.A = Databank.graduations[0].data[i].A;
                    graduation_Row_List.Add(graduation_Row);
                }
            }

            //initialize Graduation_Graph
            ChartArea graduationGraph_ChartArea = new ChartArea();
            graduationGraph_ChartArea.AxisX.IsStartedFromZero = false;
            graduationGraph_ChartArea.AxisX.MajorGrid.Enabled = false;
            graduationGraph_ChartArea.AxisY.IsStartedFromZero = false;
            graduationGraph_ChartArea.AxisY.MajorGrid.Enabled = false;
            graduationGraph_ChartArea.AxisX.Title = "С,мкг/мл";
            graduationGraph_ChartArea.AxisY.Title = "А";
            Chart_Graduation.ChartAreas.Add(graduationGraph_ChartArea);

            Series graduationGraph_SeriesPoints = new Series();
            graduationGraph_SeriesPoints.ChartType = SeriesChartType.Point;
            graduationGraph_SeriesPoints.Name = "Градуировка";
            for (int i = 0; i < graduation_Row_List.Count; i++)
            {
                graduationGraph_SeriesPoints.Points.AddXY(graduation_Row_List[i].C_mkmol, graduation_Row_List[i].A);
            }
            for (int j = 0; j < graduationGraph_SeriesPoints.Points.Count; j++)
            {
                graduationGraph_SeriesPoints.Points[j].MarkerSize = 10;
                graduationGraph_SeriesPoints.Points[j].MarkerBorderColor = System.Drawing.Color.Black;
                graduationGraph_SeriesPoints.Points[j].MarkerStyle = MarkerStyle.Circle;
            }

            //create trendline
            Series graduationGraph_SeriesLine = new Series();
            graduationGraph_SeriesLine.ChartType = SeriesChartType.Line;
            graduationGraph_SeriesLine.Name = "Линия тренда";
            graduationGraph_SeriesLine.BorderWidth = 3;
            Chart_Graduation.Series.Add(graduationGraph_SeriesLine);
            Chart_Graduation.Series.Add(graduationGraph_SeriesPoints);
            double y_sum = 0;
            double x_sum = 0;
            double x_2_sum = 0;
            double xy_sum = 0;
            for (int i = 0; i < graduationGraph_SeriesPoints.Points.Count; i++)
            {
                y_sum += graduationGraph_SeriesPoints.Points[i].YValues[0];
                x_sum += graduationGraph_SeriesPoints.Points[i].XValue;
                x_2_sum += graduationGraph_SeriesPoints.Points[i].XValue * graduationGraph_SeriesPoints.Points[i].XValue;
                xy_sum += graduationGraph_SeriesPoints.Points[i].YValues[0] * graduationGraph_SeriesPoints.Points[i].XValue;
            }

            double y_srd = y_sum / graduationGraph_SeriesPoints.Points.Count;
            double x_srd = x_sum / graduationGraph_SeriesPoints.Points.Count;
            double x_2_srd = x_2_sum / graduationGraph_SeriesPoints.Points.Count;
            double xy_srd = xy_sum / graduationGraph_SeriesPoints.Points.Count;

            double k = (xy_sum) / x_2_sum;
            Grad_K = k;

            double x1_trendline = graduationGraph_SeriesPoints.Points[0].XValue;
            double y1_trendline = k * x1_trendline;
            graduationGraph_SeriesLine.Points.AddXY(x1_trendline, y1_trendline);
            double x2_trendline = graduationGraph_SeriesPoints.Points[graduationGraph_SeriesPoints.Points.Count - 1].XValue;
            double y2_trendline = k * x2_trendline;
            graduationGraph_SeriesLine.Points.AddXY(x2_trendline, y2_trendline);

            TextBox_Coef.Text = k.ToString();

            //find out determination
            double SS_tot = 0;
            double SS_res = 0;
            double SS_reg = 0;
            for (int i = 0; i < graduationGraph_SeriesPoints.Points.Count; i++)
            {
                double y_res = k * graduationGraph_SeriesPoints.Points[i].XValue;
                SS_res += (graduationGraph_SeriesPoints.Points[i].YValues[0] - y_res) * (graduationGraph_SeriesPoints.Points[i].YValues[0] - y_res);
                SS_reg += (y_res - y_srd) * (y_res - y_srd);
            }

            SS_tot = SS_reg + SS_res;

            double determination = SS_reg / SS_tot;
            TextBox_Detr.Text = determination.ToString();

            Chart_Graduation.Titles.Add(new Title("Градуировка"));
            Chart_Graduation.Legends.Add(new Legend());
        }

        private static bool TryParseNumber(string text, out double value)
        {
            return double.TryParse(text, out value)
                || double.TryParse(
                    text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out value);
        }

        private void Button_FillExprDataFromFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            if (dialog.ShowDialog() == true)
            {
                string[] rows = File.ReadAllLines(dialog.FileName);

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split('|');
                    ExprData_Row exprData_Row = new ExprData_Row();
                    exprData_Row.time = Convert.ToDouble(columns[0]);
                    exprData_Row.m_r = Convert.ToDouble(columns[1]);
                    exprData_Row.A = Convert.ToDouble(columns[2]);
                    exprData_Row_List.Add(exprData_Row);
                }
            }
        }

        private void Button_SaveExprDataIntoFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Экспериментальные данные";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            if (dialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(dialog.FileName))
                {
                    string row_header = "обр/врем|m,г|A";
                    writer.WriteLine(row_header);
                    for (int i = 0; i < exprData_Row_List.Count; i++)
                    {
                        string row = exprData_Row_List[i].time.ToString() + "|"
                            + exprData_Row_List[i].m_r.ToString() + "|"
                            + exprData_Row_List[i].A.ToString();
                        writer.WriteLine(row);
                    }
                }
            }
        }

        private void Button_Recalculate_Click(object sender, RoutedEventArgs e)
        {
            //error handling
            if (TextBox_OpticDens.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Оптическая плотность раствора не указана", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double OpticDens;
            if (!TryParseNumber(TextBox_OpticDens.Text, out OpticDens) || OpticDens <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Оптическая плотность должна быть положительным числом", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TextBox_SubstanceName.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Название раствора не указано", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (graduation_Row_List.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Градуировка не заполнена", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (exprData_Row_List.Count < 3)
            {
                System.Windows.Forms.MessageBox.Show("Для аппроксимации необходимо не менее трёх экспериментальных точек", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double solutionVolumeMl;
            if (!TryParseNumber(TextBox_SolutionVolume.Text, out solutionVolumeMl) || solutionVolumeMl <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Объём раствора должен быть положительным числом", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double molarMassGPerMol;
            if (!TryParseNumber(TextBox_MolarMass.Text, out molarMassGPerMol) || molarMassGPerMol <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Молярная масса должна быть положительным числом", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (exprData_Row_List.Any(row => row.time < 0 || row.m_r <= 0 || row.A < 0))
            {
                System.Windows.Forms.MessageBox.Show("Проверьте данные: t и A не могут быть отрицательными, масса должна быть больше нуля", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            data_Row_List.Clear();

            double C_from_OpticDens = OpticDens / Grad_K;

            substance = new Substance();
            substance.data = new List<SubstanceData>();
            substance.k = Grad_K;
            substance.OpticDens = OpticDens;
            substance.solutionVolumeMl = solutionVolumeMl;
            substance.molarMassGPerMol = molarMassGPerMol;
            for (int i = 0; i < exprData_Row_List.Count; i++)
            {
                double C_mkmol = exprData_Row_List[i].A / Grad_K;
                double qt_mr = (C_from_OpticDens - C_mkmol) * solutionVolumeMl / exprData_Row_List[i].m_r;
                double qt_ml = qt_mr / molarMassGPerMol;
                double proc = (C_from_OpticDens - C_mkmol) / C_from_OpticDens * 100;

                SubstanceData substanceData = new SubstanceData();
                substanceData.time = exprData_Row_List[i].time;
                substanceData.m_r = exprData_Row_List[i].m_r;
                substanceData.A = exprData_Row_List[i].A;
                substanceData.C_mkmol = C_mkmol;
                substanceData.qt_mr = qt_mr;
                substanceData.qt_ml = qt_ml;
                substanceData.proc = proc;

                substance.data.Add(substanceData);
            }

            if (substance.data.Any(row => row.qt_ml < 0 || double.IsNaN(row.qt_ml) || double.IsInfinity(row.qt_ml)))
            {
                System.Windows.Forms.MessageBox.Show(
                    "Получено отрицательное или некорректное qₜ. Проверьте исходную оптическую плотность, массы и экспериментальные A.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            KineticModelFitter.Fit(substance);
            double Qe1 = substance.psevdo_1_data.Qe1;
            for (int i = 0; i < substance.data.Count; i++)
            {
                substance.data[i].Qe1 = Qe1;

                substance.data[i].qe_qt = substance.data[i].Qe1 - substance.data[i].qt_ml;
                substance.data[i].log_qe_qt = substance.data[i].qe_qt > 0
                    ? Math.Log10(substance.data[i].qe_qt)
                    : double.NaN;
                if (substance.data[i].qt_ml != 0)
                {
                    substance.data[i].t_qt = substance.data[i].time / substance.data[i].qt_ml;
                }
                else
                {
                    substance.data[i].t_qt = 0;
                }

                Data_Row data_Row = new Data_Row();
                data_Row.time = exprData_Row_List[i].time;
                data_Row.m_r = exprData_Row_List[i].m_r;
                data_Row.A = exprData_Row_List[i].A;
                data_Row.C_mkmol = substance.data[i].C_mkmol;
                data_Row.qt_mr = substance.data[i].qt_mr;
                data_Row.qt_ml = substance.data[i].qt_ml;
                data_Row.proc = substance.data[i].proc;
                data_Row.qe_qt = substance.data[i].qe_qt;
                data_Row.log_qe_qt = substance.data[i].log_qe_qt;
                data_Row.t_qt = substance.data[i].t_qt;

                data_Row_List.Add(data_Row);
            }
            Recalulate_done = true;
        }

        private void Button_AddSubstance_Click(object sender, RoutedEventArgs e)
        {
            //error handling
            if (TextBox_SubstanceName.Text.Replace(" ", "") == "")
            {
                System.Windows.Forms.MessageBox.Show("Введите название раствора", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Recalulate_done)
            {
                System.Windows.Forms.MessageBox.Show("Выполните перерасчет", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < Databank.substances.Count; i++)
            {
                if (Databank.substances[i].name == TextBox_SubstanceName.Text)
                {
                    System.Windows.Forms.MessageBox.Show("Раствор с таким названием уже есть", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //add substance to list
            substance.name = TextBox_SubstanceName.Text;
            Databank.substances.Add(substance);
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.updateGroupBoxSubstances();
            parent.Show();
        }
    }
}
