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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;

namespace Graphs
{
    /// <summary>
    /// Логика взаимодействия для AddGraduationForm.xaml
    /// </summary>
    public partial class AddGraduationForm : Window
    {
        GraduationsListForm parent;
        public ObservableCollection<Graduation_Row> graduation_Row_List;
        public AddGraduationForm(GraduationsListForm owner)
        {
            parent = owner;
            InitializeComponent();
            graduation_Row_List = new ObservableCollection<Graduation_Row>();
            DataGrid_Graduation.ItemsSource = graduation_Row_List;
        }

        private void Button_FillFromFileGraduation_Click(object sender, RoutedEventArgs e)
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
                    Graduation_Row graduation_Row = new Graduation_Row();
                    graduation_Row.C_mkmol = Convert.ToDouble(columns[0]);
                    graduation_Row.A = Convert.ToDouble(columns[1]);
                    graduation_Row_List.Add(graduation_Row);
                }
            }
        }

        private void Button_AddGraduation_Click(object sender, RoutedEventArgs e)
        {
            //error handler
            if (TextBox_GraduationName.Text.Replace(" ", "") == "")
            {
                System.Windows.Forms.MessageBox.Show("Укажите название раствора", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Graduation graduation = new Graduation();
            graduation.data = new List<GraduationData>();
            graduation.name = TextBox_GraduationName.Text;

            for (int i = 0; i < graduation_Row_List.Count; i++)
            {
                GraduationData graduationData = new GraduationData();
                graduationData.A = graduation_Row_List[i].A;
                graduationData.C_mkmol = graduation_Row_List[i].C_mkmol;
                graduation.data.Add(graduationData);
            }
            Databank.graduations.Add(graduation);

            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.fillWrapPanelGraduations();
            parent.Show();
        }
    }
}
