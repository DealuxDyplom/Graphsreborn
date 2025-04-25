using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;

//using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MathNet.Numerics.Optimization;

namespace Graphs
{
    /// <summary>
    /// Логика взаимодействия для EditSubstanceForm.xaml
    /// </summary>
    public partial class EditSubstanceForm : Window
    {
        MainWindow parent;
        public ObservableCollection<Data_Row> data_Row_List;
        Substance substance;
        ChartArea substancesGraph_ChartArea;
        Series substanceGraph_SeriesLine;
        Series substanceGraph_SeriesPoints;
        int PointIndexMouseDown = -1;
        bool MouseDownOnPointOnGraph = false;
        double Qe1;
        public EditSubstanceForm(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();

            Graph_Substance.Legends.Add(new Legend());

            data_Row_List = new ObservableCollection<Data_Row>();
            DataGrid_Substance.ItemsSource = data_Row_List;

            for (int i = 0; i < Databank.substances.Count; i++)
            {
                ComboBox_SubstanceName.Items.Add(Databank.substances[i].name);
            }
        }

        private void ComboBox_SubstanceName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            data_Row_List.Clear();
            Graph_Substance.Series.Clear();
            Graph_Substance.ChartAreas.Clear();
            for (int i = 0; i < Databank.substances.Count; i++)
            {
                if (Databank.substances[i].name == ((ComboBox)sender).SelectedValue.ToString())
                {
                    substance = Databank.substances[i];
                    Qe1 = Databank.substances[i].data[0].Qe1;
                    //fill dataGrid
                    for (int j = 0; j < Databank.substances[i].data.Count; j++)
                    {
                        Data_Row data_Row = new Data_Row();
                        data_Row.time = Databank.substances[i].data[j].time;
                        data_Row.m_r = Databank.substances[i].data[j].m_r;
                        data_Row.A = Databank.substances[i].data[j].A;
                        data_Row.C_mkmol = Databank.substances[i].data[j].C_mkmol;
                        data_Row.qt_mr = Databank.substances[i].data[j].qt_mr;
                        data_Row.qt_ml = Databank.substances[i].data[j].qt_ml;
                        data_Row.proc = Databank.substances[i].data[j].proc;
                        data_Row.qe_qt = Databank.substances[i].data[j].qe_qt;
                        data_Row.log_qe_qt = Databank.substances[i].data[j].log_qe_qt;
                        data_Row.t_qt = Databank.substances[i].data[j].t_qt;

                        data_Row_List.Add(data_Row);
                    }

                    //paint graph
                    substancesGraph_ChartArea = new ChartArea();
                    substancesGraph_ChartArea.AxisX.IsStartedFromZero = false;
                    substancesGraph_ChartArea.AxisX.MajorGrid.Enabled = false;
                    substancesGraph_ChartArea.AxisY.IsStartedFromZero = false;
                    substancesGraph_ChartArea.AxisY.MajorGrid.Enabled = false;
                    substancesGraph_ChartArea.AxisX.IsStartedFromZero = true;
                    substancesGraph_ChartArea.AxisY.IsStartedFromZero = true;
                    substancesGraph_ChartArea.AlignmentOrientation = AreaAlignmentOrientations.All;
                    substancesGraph_ChartArea.AxisX.Title = "обр/врем";
                    substancesGraph_ChartArea.AxisY.Title = "qt, μмоль/г";
                    Graph_Substance.ChartAreas.Add(substancesGraph_ChartArea);

                    Random rand = new Random();

                    substanceGraph_SeriesLine = new Series();
                    substanceGraph_SeriesLine.ChartType = SeriesChartType.Spline;
                    substanceGraph_SeriesLine.Name = Databank.substances[i].name.ToString() + "_Line";
                    substanceGraph_SeriesLine.SetCustomProperty("LineTension", "0.2");
                    substanceGraph_SeriesLine.BorderWidth = 3;
                    substanceGraph_SeriesLine.Color = System.Drawing.Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                    substanceGraph_SeriesLine.Points.AddXY(0, 0);
                    for (int j = 0; j < Databank.substances[i].data.Count; j++)
                    {
                        double x = Databank.substances[i].data[j].time;
                        double y = Databank.substances[i].data[j].qt_ml;
                        substanceGraph_SeriesLine.Points.AddXY(x, y);
                    }

                    substanceGraph_SeriesPoints = new Series();
                    substanceGraph_SeriesPoints.ChartType = SeriesChartType.Point;
                    substanceGraph_SeriesPoints.Name = Databank.substances[i].name.ToString() + "_Point";
                    substanceGraph_SeriesPoints.Color = substanceGraph_SeriesLine.Color;
                    substanceGraph_SeriesPoints.Points.AddXY(0, 0);
                    for (int j = 0; j < Databank.substances[i].data.Count; j++)
                    {
                        double x = Databank.substances[i].data[j].time;
                        double y = Databank.substances[i].data[j].qt_ml;
                        substanceGraph_SeriesPoints.Points.AddXY(x, y);
                    }

                    for (int j = 0; j < substanceGraph_SeriesPoints.Points.Count; j++)
                    {
                        substanceGraph_SeriesPoints.Points[j].MarkerSize = 10;
                        substanceGraph_SeriesPoints.Points[j].MarkerBorderColor = System.Drawing.Color.Black;
                        substanceGraph_SeriesPoints.Points[j].MarkerStyle = MarkerStyle.Circle;
                    }

                    Graph_Substance.Series.Add(substanceGraph_SeriesLine);
                    Graph_Substance.Series.Add(substanceGraph_SeriesPoints);

                    break;
                }
            }
        }

        private void Graph_Substance_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //когда нажата ЛКМ, определяется индекс точки
            PointIndexMouseDown = Graph_Substance.HitTest(e.X, e.Y).PointIndex;
            if (PointIndexMouseDown == -1) { return; }
            //если ЛКМ нажата на точку, то её края окрашиваются в желтый

            substanceGraph_SeriesPoints.Points[PointIndexMouseDown].MarkerBorderColor = System.Drawing.Color.Yellow;

            MouseDownOnPointOnGraph = true;
        }

        private void Graph_Substance_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //если мышь двигается, и до этого ЛКМ была нажата на точку, то координаты точки меняются
            if (MouseDownOnPointOnGraph)
            {
                double xValue = substancesGraph_ChartArea.AxisX.PixelPositionToValue(e.X);
                double yValue = substancesGraph_ChartArea.AxisY.PixelPositionToValue(e.Y);

                //меняем координаты самой точки
                substanceGraph_SeriesPoints.Points[PointIndexMouseDown].XValue = substanceGraph_SeriesPoints.Points[PointIndexMouseDown].XValue;
                substanceGraph_SeriesPoints.Points[PointIndexMouseDown].YValues[0] = yValue;

                //меняем координаты опорной точки Spline
                substanceGraph_SeriesLine.Points[PointIndexMouseDown].XValue = substanceGraph_SeriesLine.Points[PointIndexMouseDown].XValue;
                substanceGraph_SeriesLine.Points[PointIndexMouseDown].YValues[0] = yValue;

                //пишем в toolStripStatusLabel координаты точки
                //toolStripStatusLabel_Y.Text = "Y = " + yValue.ToString();
            }
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


        private void Graph_Substance_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //когда мышь отпущена, края всех точек окрашиваются в черный
            for (int i = 0; i < substanceGraph_SeriesPoints.Points.Count; i++)
            {
                substanceGraph_SeriesPoints.Points[i].MarkerBorderColor = System.Drawing.Color.Black;
            }

            //пересчитываем таблицу со значениями
            double k = substance.k;
            double OpticDens = substance.OpticDens;
            double C_from_OpticDens = OpticDens / k;

            for (int i = 0; i < data_Row_List.Count; i++)
            {
                data_Row_List[i].qt_ml = substanceGraph_SeriesPoints.Points[i + 1].YValues[0];
                data_Row_List[i].qt_mr = data_Row_List[i].qt_ml * 1355;

                //если меняется A
                data_Row_List[i].C_mkmol = C_from_OpticDens - ((data_Row_List[i].qt_mr * data_Row_List[i].m_r) / 20);
                data_Row_List[i].A = data_Row_List[i].C_mkmol * k;
                
                //если меняется m, г
                //data_Row_List[i].C_mkmol = data_Row_List[i].A / k;
                //data_Row_List[i].m_r = (C_from_OpticDens - data_Row_List[i].C_mkmol) * 20 / data_Row_List[i].qt_mr;
                
                data_Row_List[i].proc = (C_from_OpticDens - data_Row_List[i].C_mkmol) / C_from_OpticDens * 100;
            }

            //find out Qe1
            double[] time = new double[data_Row_List.Count];
            double[] qt_exp = new double[data_Row_List.Count];
            for (int i = 0; i < data_Row_List.Count; i++)
            {
                time[i] = data_Row_List[i].time;
                qt_exp[i] = data_Row_List[i].qt_ml;
            }
            Qe1 = getQe(time, qt_exp);

            for (int i = 0; i < data_Row_List.Count; i++)
            {
                data_Row_List[i].qe_qt = Qe1 - data_Row_List[i].qt_ml;
                data_Row_List[i].log_qe_qt = Math.Log10(data_Row_List[i].qe_qt);

                if (data_Row_List[i].qt_ml != 0)
                {
                    data_Row_List[i].t_qt = data_Row_List[i].time / data_Row_List[i].qt_ml;
                }
                else
                {
                    data_Row_List[i].t_qt = 0;
                }
            }

            PointIndexMouseDown = -1;
            MouseDownOnPointOnGraph = false;
            DataGrid_Substance.Items.Refresh();
            //toolStripStatusLabel_Y.Text = "";
        }

        private void Button_SaveEditSubstance_Click(object sender, RoutedEventArgs e)
        {
            substance.data = new List<SubstanceData>();
            for (int i = 0; i < data_Row_List.Count; i++)
            {
                SubstanceData substanceData = new SubstanceData();
                substanceData.time = data_Row_List[i].time;
                substanceData.m_r = data_Row_List[i].m_r;
                substanceData.A = data_Row_List[i].A;
                substanceData.C_mkmol = data_Row_List[i].C_mkmol;
                substanceData.qt_mr = data_Row_List[i].qt_mr;
                substanceData.qt_ml = data_Row_List[i].qt_ml;
                substanceData.Qe1 = Qe1;
                substanceData.proc = data_Row_List[i].proc;
                substanceData.qe_qt = data_Row_List[i].qe_qt;
                substanceData.log_qe_qt = data_Row_List[i].log_qe_qt;
                substanceData.t_qt = data_Row_List[i].t_qt;

                substance.data.Add(substanceData);
            }

            for (int i = 0; i < Databank.substances.Count; i++)
            {
                if (Databank.substances[i].name == ComboBox_SubstanceName.Text)
                {
                    Databank.substances[i] = substance;
                }
            }

            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.updateGroupBoxSubstances();
            parent.Show();
        }
    }
}
