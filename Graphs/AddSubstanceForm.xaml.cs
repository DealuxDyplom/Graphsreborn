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
using MathNet.Numerics.Optimization;
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
            Chart_Graduation.ChartAreas.Add(graduationGraph_ChartArea);

            Series graduationGraph_SeriesPoints = new Series();
            graduationGraph_SeriesPoints.ChartType = SeriesChartType.Point;
            graduationGraph_SeriesPoints.Name = "Градуировка";
            Chart_Graduation.Series.Add(graduationGraph_SeriesPoints);
            for (int i = 0; i < graduation_Row_List.Count; i++)
            {
                graduationGraph_SeriesPoints.Points.AddXY(graduation_Row_List[i].C_mkmol, graduation_Row_List[i].A);
            }

            //create trendline
            Series graduationGraph_SeriesLine = new Series();
            graduationGraph_SeriesLine.ChartType = SeriesChartType.Line;
            graduationGraph_SeriesLine.Name = "Линия тренда";
            Chart_Graduation.Series.Add(graduationGraph_SeriesLine);
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

        // Модель псевдо-первого порядка
        static double PseudoFirstOrder(double t, double qe, double k1)
        {
            return qe * (1 - Math.Exp(-k1 * t));
        }

        // Функция сгенерирована ChatGPT
        static double getQe(double[] time, double[] qt_exp)
        {
            ////Экспериментальные данные
            //double[] time = { 0, 5, 10, 20, 40, 60 };  // Время в минутах
            //double[] qt_exp = { 0, 0.3544, 0.3509, 0.3542, 0.3617, 0.3562 };  // Экспериментальные данные

            // Функция ошибки (минимизируемая)
            Func<double, double, double> errorFunc = (qe_local, k1_local) =>
            {
                double error = 0.0;
                for (int i = 0; i < time.Length; i++)
                {
                    double model = PseudoFirstOrder(time[i], qe_local, k1_local);
                    error += Math.Pow(model - qt_exp[i], 2);
                }
                return error;
            };

            // Начальные значения
            double qe = 0.1;
            double k1 = 0.1;
            int iterations = 5; // Количество итераций поочерёдной минимизации

            var minimizer = new GoldenSectionMinimizer(1e-9, 100);

            for (int iter = 0; iter < iterations; iter++)
            {
                // Минимизация по qe (фиксируем k1)
                var resultQe = minimizer.FindMinimum(ObjectiveFunction.ScalarValue(q => errorFunc(q, k1)), 0, 1);
                qe = resultQe.MinimizingPoint;

                // Минимизация по k1 (фиксируем qe)
                var resultK1 = minimizer.FindMinimum(ObjectiveFunction.ScalarValue(k => errorFunc(qe, k)), 0, 1);
                k1 = resultK1.MinimizingPoint;
            }

            //Console.WriteLine($"Подобранные параметры: qe = {qe}, k1 = {k1}");
            return qe * 1.02;
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
            if (TextBox_OpticDens.Text.Any(c => char.IsLetter(c)))
            {
                System.Windows.Forms.MessageBox.Show("Оптическая плотность не должна содержать буквы", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (exprData_Row_List.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Экспериментальные данные не указаны", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            data_Row_List.Clear();

            double OpticDens = double.Parse(TextBox_OpticDens.Text.Replace(".", ","));
            double C_from_OpticDens = OpticDens / Grad_K;

            substance = new Substance();
            substance.data = new List<SubstanceData>();
            substance.k = Grad_K;
            substance.OpticDens = OpticDens;
            for (int i = 0; i < exprData_Row_List.Count; i++)
            {
                double C_mkmol = exprData_Row_List[i].A / Grad_K;
                double qt_mr = (C_from_OpticDens - C_mkmol) * 20 / exprData_Row_List[i].m_r;
                double qt_ml = qt_mr / 1355; //??? что такое 1355
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

            //find out Qe1
            double[] time = new double[substance.data.Count];
            double[] qt_exp = new double[substance.data.Count];
            for (int i = 0; i < substance.data.Count; i++)
            {
                time[i] = substance.data[i].time;
                qt_exp[i] = substance.data[i].qt_ml;
            }
            double Qe1 = getQe(time, qt_exp);
            for (int i = 0; i < substance.data.Count; i++)
            {
                substance.data[i].Qe1 = Qe1;

                substance.data[i].qe_qt = substance.data[i].Qe1 - substance.data[i].qt_ml;
                substance.data[i].log_qe_qt = Math.Log10(substance.data[i].qe_qt);
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
