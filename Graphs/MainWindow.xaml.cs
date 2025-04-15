using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Graphs_Substances.ChartAreas.Add(new ChartArea());
            //Series added_series = new Series();
            //Graphs_Substances.Series.Add(added_series);
            //added_series.ChartType = SeriesChartType.Point;
            //added_series.Points.AddXY(1, 1);
            //added_series.Points.AddXY(2, 2);
        }

        private void Button_AddSubstanceForm_Click(object sender, RoutedEventArgs e)
        {
            AddSubstanceForm addSubstanceForm = new AddSubstanceForm();
            addSubstanceForm.Show();
        }
    }
}
