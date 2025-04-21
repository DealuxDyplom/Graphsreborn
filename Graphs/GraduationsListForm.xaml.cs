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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Graphs
{
    /// <summary>
    /// Логика взаимодействия для GraduationsListForm.xaml
    /// </summary>
    public partial class GraduationsListForm : Window
    {
        MainWindow parent;
        public ObservableCollection<Graduation_Row> graduation_Row_List;
        public List<RadioButton> radiobuttons_List;
        
        public GraduationsListForm(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();
            radiobuttons_List = new List<RadioButton>();
            graduation_Row_List = new ObservableCollection<Graduation_Row>();
            DataGrid_Graduation.ItemsSource = graduation_Row_List;

            fillWrapPanelGraduations();
        }

        private void fillDataGridGraduation(object sender, RoutedEventArgs e)
        {
            graduation_Row_List.Clear();
            RadioButton radioButton = ((RadioButton)sender);
            for (int i = 0; i < Databank.graduations.Count; i++)
            {
                if (radioButton.Content.ToString() == Databank.graduations[i].name)
                {
                    for (int j = 0; j < Databank.graduations[i].data.Count; j++)
                    {
                        Graduation_Row graduation_Row = new Graduation_Row();
                        graduation_Row.A = Databank.graduations[i].data[j].A;
                        graduation_Row.C_mkmol = Databank.graduations[i].data[j].C_mkmol;
                        graduation_Row_List.Add(graduation_Row);
                    }
                }
            }
            
        }

        private void Button_SaveEdits_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < radiobuttons_List.Count; i++)
            {
                if (radiobuttons_List[i].IsChecked == true)
                {
                    for (int j = 0; j < Databank.graduations.Count; j++)
                    {
                        if (radiobuttons_List[i].Content.ToString() == Databank.graduations[j].name)
                        {
                            Databank.graduations[j].data = new List<GraduationData>();
                            for (int k = 0; k < graduation_Row_List.Count; k++)
                            {
                                GraduationData graduationData = new GraduationData();
                                graduationData.A = graduation_Row_List[k].A;
                                graduationData.C_mkmol = graduation_Row_List[k].C_mkmol;
                                Databank.graduations[j].data.Add(graduationData);
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            this.Close();
        }

        private void Button_AddGraduation_Click(object sender, RoutedEventArgs e)
        {
            AddGraduationForm addGraduationForm = new AddGraduationForm(this);
            addGraduationForm.Show();

            this.Hide();
        }

        public void fillWrapPanelGraduations()
        {
            WrapPanel_Graduations.Children.Clear();
            for (int i = 0; i < Databank.graduations.Count; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = Databank.graduations[i].name;
                radioButton.Margin = new System.Windows.Thickness(3);
                radioButton.Checked += fillDataGridGraduation;
                radiobuttons_List.Add(radioButton);
                WrapPanel_Graduations.Children.Add(radioButton);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Show();
        }
    }
}
