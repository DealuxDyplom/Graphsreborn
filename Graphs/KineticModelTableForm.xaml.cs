using System;
using System.Collections.Generic;
using System.Drawing;
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
using MathNet.Numerics.Distributions;

namespace Graphs
{
    /// <summary>
    /// Логика взаимодействия для KineticModelTableForm.xaml
    /// </summary>
    public partial class KineticModelTableForm : Window
    {
        MainWindow parent;
        public KineticModelTableForm(MainWindow owner)
        {
            int decimalPlaces = 3;
            parent = owner;
            InitializeComponent();

            for (int i = 0; i < Databank.substances.Count; i++)
            {
                Databank.substances[i].psevdo_1_data = new Psevdo_1_Data();
                //fill psevdo_1

                //create border for cells
                for (int j = 0; j < 5; j++)
                {
                    Border border = new Border();
                    System.Windows.Media.Brush brush = new SolidColorBrush(Colors.Black);
                    border.BorderBrush = brush;
                    if (i == Databank.substances.Count - 1)
                    {
                        border.BorderThickness = new System.Windows.Thickness(1, 0, 0, 0);
                    }
                    else
                    {
                        border.BorderThickness = new System.Windows.Thickness(1, 0, 0, 1);
                    }
                    Grid_Psevdo_1_Param.Children.Add(border);
                    Grid.SetColumn(border, j);
                    Grid.SetRow(border, i);
                }

                TextBlock textBlock = new TextBlock();
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Text = Databank.substances[i].name;
                Label label_substanceName = new Label();
                label_substanceName.Content = textBlock;
                label_substanceName.HorizontalAlignment = HorizontalAlignment.Center;
                label_substanceName.VerticalAlignment = VerticalAlignment.Center;
                label_substanceName.MouseEnter += paintLabel;
                label_substanceName.MouseLeave += paintLabel;
                label_substanceName.MouseDown += showPsevdoGraphForm;
                label_substanceName.Cursor = System.Windows.Input.Cursors.Hand;

                RowDefinition rowDefinition = new RowDefinition();
                Grid_Psevdo_1_Param.RowDefinitions.Add(rowDefinition);
                Grid_Psevdo_1_Param.Children.Add(label_substanceName);
                Grid.SetColumn(label_substanceName, 0);
                Grid.SetRow(label_substanceName, i);

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

                Databank.substances[i].psevdo_1_data.a = a;
                Databank.substances[i].psevdo_1_data.b = b;

                TextBlock textBlock_Equation_psevdo_1 = new TextBlock();
                textBlock_Equation_psevdo_1.TextWrapping = TextWrapping.Wrap;
                textBlock_Equation_psevdo_1.Text = "y = " + Math.Round(a, decimalPlaces).ToString() + " + " + Math.Round(b, decimalPlaces).ToString() + " * x";
                textBlock_Equation_psevdo_1.TextAlignment = TextAlignment.Center;
                Label label_Equation_psevdo_1 = new Label();
                label_Equation_psevdo_1.Content = textBlock_Equation_psevdo_1;
                label_Equation_psevdo_1.HorizontalAlignment = HorizontalAlignment.Center;
                label_Equation_psevdo_1.VerticalAlignment = VerticalAlignment.Center;
                Grid_Psevdo_1_Param.Children.Add(label_Equation_psevdo_1);
                Grid.SetColumn(label_Equation_psevdo_1, 1);
                Grid.SetRow(label_Equation_psevdo_1, i);

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
                Databank.substances[i].psevdo_1_data.determination = determination;

                TextBlock textBlock_R2_psevdo_1 = new TextBlock();
                textBlock_R2_psevdo_1.TextWrapping = TextWrapping.Wrap;
                textBlock_R2_psevdo_1.Text = Math.Round(determination, decimalPlaces).ToString();
                textBlock_R2_psevdo_1.TextAlignment = TextAlignment.Center;
                Label label_R2_psevdo_1 = new Label();
                label_R2_psevdo_1.Content = textBlock_R2_psevdo_1;
                label_R2_psevdo_1.HorizontalAlignment = HorizontalAlignment.Center;
                label_R2_psevdo_1.VerticalAlignment = VerticalAlignment.Center;
                Grid_Psevdo_1_Param.Children.Add(label_R2_psevdo_1);
                Grid.SetColumn(label_R2_psevdo_1, 4);
                Grid.SetRow(label_R2_psevdo_1, i);

                //find out Qe1
                Databank.substances[i].psevdo_1_data.Qe1 = Databank.substances[i].data[0].Qe1;
                TextBlock textBlock_qe1_psevdo_1 = new TextBlock();
                textBlock_qe1_psevdo_1.TextWrapping = TextWrapping.Wrap;
                textBlock_qe1_psevdo_1.Text = Math.Round(Databank.substances[i].data[0].Qe1, decimalPlaces).ToString();
                textBlock_qe1_psevdo_1.TextAlignment= TextAlignment.Center;
                Label label_qe1_psevdo_1 = new Label();
                label_qe1_psevdo_1.Content= textBlock_qe1_psevdo_1;
                label_qe1_psevdo_1.HorizontalAlignment= HorizontalAlignment.Center;
                label_qe1_psevdo_1.VerticalAlignment= VerticalAlignment.Center;
                Grid_Psevdo_1_Param.Children.Add(label_qe1_psevdo_1);
                Grid.SetColumn(label_qe1_psevdo_1, 2);
                Grid.SetRow(label_qe1_psevdo_1, i);

                //find out K1
                double k1 = -(b * 2.303);
                Databank.substances[i].psevdo_1_data.k1 = k1;

                TextBlock textBlock_k1_psevdo_1 = new TextBlock();
                textBlock_k1_psevdo_1.TextWrapping = TextWrapping.Wrap;
                textBlock_k1_psevdo_1.Text = Math.Round(k1, decimalPlaces).ToString();
                textBlock_k1_psevdo_1.TextAlignment = TextAlignment.Center;

                Label label_k1_psevdo_1 = new Label();
                label_k1_psevdo_1.Content = textBlock_k1_psevdo_1;
                label_k1_psevdo_1.VerticalAlignment = VerticalAlignment.Center;
                label_k1_psevdo_1.HorizontalAlignment = HorizontalAlignment.Center;
                Grid_Psevdo_1_Param.Children.Add(label_k1_psevdo_1);
                Grid.SetColumn(label_k1_psevdo_1, 3);
                Grid.SetRow(label_k1_psevdo_1, i);

            }
            for (int i = 0; i < Databank.substances.Count; i++)
            {
                Databank.substances[i].psevdo_2_data = new Psevdo_2_Data();
                //fill psevdo_2

                //create border fo cells
                for (int j = 0; j < 5; j++)
                {
                    Border border = new Border();
                    System.Windows.Media.Brush brush = new SolidColorBrush(Colors.Black);
                    border.BorderBrush = brush;
                    if (i == Databank.substances.Count - 1)
                    {
                        border.BorderThickness = new System.Windows.Thickness(1, 0, 0, 0);
                    }
                    else
                    {
                        border.BorderThickness = new System.Windows.Thickness(1, 0, 0, 1);
                    }
                    Grid_Psevdo_2_Param.Children.Add(border);
                    Grid.SetColumn(border, j);
                    Grid.SetRow(border, i);
                }

                TextBlock textBlock = new TextBlock();
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Text = Databank.substances[i].name;
                Label label_substanceName = new Label();
                label_substanceName.Content = textBlock;
                label_substanceName.HorizontalAlignment = HorizontalAlignment.Center;
                label_substanceName.VerticalAlignment = VerticalAlignment.Center;
                label_substanceName.MouseEnter += paintLabel;
                label_substanceName.MouseLeave += paintLabel;
                label_substanceName.MouseDown += showPsevdoGraphForm;
                label_substanceName.Cursor = System.Windows.Input.Cursors.Hand;

                RowDefinition rowDefinition = new RowDefinition();
                Grid_Psevdo_2_Param.RowDefinitions.Add(rowDefinition);
                Grid_Psevdo_2_Param.Children.Add(label_substanceName);
                Grid.SetColumn(label_substanceName, 0);
                Grid.SetRow(label_substanceName, i);

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

                Databank.substances[i].psevdo_2_data.a = a;
                Databank.substances[i].psevdo_2_data.b = b;

                TextBlock textBlock_Equation_psevdo_2 = new TextBlock();
                textBlock_Equation_psevdo_2.TextWrapping = TextWrapping.Wrap;
                textBlock_Equation_psevdo_2.Text = "y = " + Math.Round(a, decimalPlaces).ToString() + " + " + Math.Round(b, decimalPlaces).ToString() + " * x";
                textBlock_Equation_psevdo_2.TextAlignment = TextAlignment.Center;
                Label label_Equation_psevdo_2 = new Label();
                label_Equation_psevdo_2.Content = textBlock_Equation_psevdo_2;
                label_Equation_psevdo_2.HorizontalAlignment = HorizontalAlignment.Center;
                label_Equation_psevdo_2.VerticalAlignment = VerticalAlignment.Center;
                Grid_Psevdo_2_Param.Children.Add(label_Equation_psevdo_2);
                Grid.SetColumn(label_Equation_psevdo_2, 1);
                Grid.SetRow(label_Equation_psevdo_2, i);

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
                Databank.substances[i].psevdo_2_data.determination = determination;

                TextBlock textBlock_R2_psevdo_2 = new TextBlock();
                textBlock_R2_psevdo_2.TextWrapping = TextWrapping.Wrap;
                textBlock_R2_psevdo_2.Text = Math.Round(determination, decimalPlaces).ToString();
                textBlock_R2_psevdo_2.TextAlignment = TextAlignment.Center;
                Label label_R2_psevdo_2 = new Label();
                label_R2_psevdo_2.Content = textBlock_R2_psevdo_2;
                label_R2_psevdo_2.HorizontalAlignment = HorizontalAlignment.Center;
                label_R2_psevdo_2.VerticalAlignment = VerticalAlignment.Center;
                Grid_Psevdo_2_Param.Children.Add(label_R2_psevdo_2);
                Grid.SetColumn(label_R2_psevdo_2, 4);
                Grid.SetRow(label_R2_psevdo_2, i);

                //find out Qe2
                double Qe2 = 1 / b;
                Databank.substances[i].psevdo_2_data.Qe2 = Qe2;
                TextBlock textBlock_Qe2_psevdo_2 = new TextBlock();
                textBlock_Qe2_psevdo_2.TextWrapping = TextWrapping.Wrap;
                textBlock_Qe2_psevdo_2.Text = Math.Round(Qe2, decimalPlaces).ToString();
                textBlock_Qe2_psevdo_2.TextAlignment = TextAlignment.Center;
                Label label_qe2_psevdo_2 = new Label();
                label_qe2_psevdo_2.Content = textBlock_Qe2_psevdo_2;
                label_qe2_psevdo_2.HorizontalAlignment = HorizontalAlignment.Center;
                label_qe2_psevdo_2.VerticalAlignment = VerticalAlignment.Center;
                Grid_Psevdo_2_Param.Children.Add(label_qe2_psevdo_2);
                Grid.SetColumn(label_qe2_psevdo_2, 2);
                Grid.SetRow(label_qe2_psevdo_2, i);

                //find out K2
                double k2 = 1 / (0.16 / (1 / (Qe2 * Qe2)));
                Databank.substances[i].psevdo_2_data.k2 = k2;

                TextBlock textBlock_k2_psevdo_2 = new TextBlock();
                textBlock_k2_psevdo_2.TextWrapping = TextWrapping.Wrap;
                textBlock_k2_psevdo_2.Text = Math.Round(k2, decimalPlaces).ToString();
                textBlock_k2_psevdo_2.TextAlignment = TextAlignment.Center;
                Label label_k2_psevdo_2 = new Label();
                label_k2_psevdo_2.Content= textBlock_k2_psevdo_2;
                label_k2_psevdo_2.HorizontalAlignment= HorizontalAlignment.Center;
                label_k2_psevdo_2.VerticalAlignment= VerticalAlignment.Center;
                Grid_Psevdo_2_Param.Children.Add(label_k2_psevdo_2);
                Grid.SetColumn(label_k2_psevdo_2, 3);
                Grid.SetRow(label_k2_psevdo_2, i);
            }
        }

        private void paintLabel(object sender, RoutedEventArgs e)
        {

            if (e.RoutedEvent == MouseLeaveEvent)
            {
                Label label = ((Label)sender);
                label.Background = new SolidColorBrush();
            }
            else if (e.RoutedEvent == MouseEnterEvent)
            {
                Label label = ((Label)sender);
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = System.Windows.Media.Color.FromRgb(200, 200, 200);
                label.Background = brush;
            }
        }

        private void showPsevdoGraphForm(object sender, RoutedEventArgs e)
        {
            Label label = ((Label)sender);

            int psevdo = 0;
            DependencyObject parent = VisualTreeHelper.GetParent(label);
            if (((Grid)parent).Name == "Grid_Psevdo_1_Param")
            {
                psevdo = 1;
            } else if (((Grid)parent).Name == "Grid_Psevdo_2_Param")
            {
                psevdo = 2;
            }

            for (int i = 0; i < Databank.substances.Count; i++)
            {
                if (Databank.substances[i].name == ((TextBlock)label.Content).Text)
                {
                    PsevdoGraphForm psevdoGraphForm = new PsevdoGraphForm(Databank.substances[i], psevdo, this);
                    psevdoGraphForm.Show();
                    break;
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Show();
        }
    }
}
