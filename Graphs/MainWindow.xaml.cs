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
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;

namespace Graphs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<System.Windows.Controls.CheckBox> checkBoxes_Substances_List;

        public MainWindow()
        {
            InitializeComponent();

            checkBoxes_Substances_List = new List<System.Windows.Controls.CheckBox>();
            Databank.substances = new List<Substance>();
            Databank.graduations = new List<Graduation>();

            Graduation graduation = new Graduation();
            graduation.data = new List<GraduationData>();

            GraduationData graduationData = new GraduationData();
            graduationData.C_mkmol = 5;
            graduationData.A = 0.089;
            graduation.data.Add(graduationData);

            graduationData = new GraduationData();
            graduationData.C_mkmol = 10;
            graduationData.A = 0.165;
            graduation.data.Add(graduationData);

            graduationData = new GraduationData();
            graduationData.C_mkmol = 20;
            graduationData.A = 0.318;
            graduation.data.Add(graduationData);

            graduationData = new GraduationData();
            graduationData.C_mkmol = 30;
            graduationData.A = 0.471;
            graduation.data.Add(graduationData);

            graduation.name = "Градуировка В12/H2O";

            Databank.graduations.Add(graduation);
        }

        private void Button_AddSubstanceForm_Click(object sender, RoutedEventArgs e)
        {
            AddSubstanceForm addSubstanceForm = new AddSubstanceForm(this);
            addSubstanceForm.Show();
        }

        public void fillGroupBoxSubstancesCheckboxes()
        {
            WrapPanel_Substances.Children.Clear();
            for (int i = 0; i < Databank.substances.Count; i++)
            {
                System.Windows.Controls.CheckBox checkbox_Substance = new System.Windows.Controls.CheckBox();
                checkbox_Substance.Content = Databank.substances[i].name;
                checkbox_Substance.Margin = new System.Windows.Thickness(3); //отступ чекбоксов друг от друга
                WrapPanel_Substances.Children.Add(checkbox_Substance);
                checkBoxes_Substances_List.Add(checkbox_Substance);
            }
        }

        public void updateGroupBoxSubstances()
        {
            fillGroupBoxSubstancesCheckboxes();
        }

        #region [ Menu ]
        private void Menu_SaveSubstances_Click(object sender, RoutedEventArgs e)
        {
            var json = JsonConvert.SerializeObject(Databank.substances);

            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.FileName = "Растворы.txt";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text documents (.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine(json);
                }
            }
        }

        private void Menu_LoadSubstances_Click(object sender, RoutedEventArgs e) 
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text documents (.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                string json = reader.ReadToEnd();
                Databank.substances.Clear();
                Databank.substances = JsonConvert.DeserializeObject<List<Substance>>(json);

                //add new checkboxes
                fillGroupBoxSubstancesCheckboxes();
            }
        }

        private void Menu_LoadGraduations_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text documents (.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                string json = reader.ReadToEnd();
                Databank.graduations.Clear();
                Databank.graduations = JsonConvert.DeserializeObject<List<Graduation>>(json);

                //add new checkboxes
                fillGroupBoxSubstancesCheckboxes();
            }
        }

        private void Menu_SaveGraduations_Click(object sender, RoutedEventArgs e)
        {
            var json = JsonConvert.SerializeObject(Databank.graduations);

            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.FileName = "Градуировки.txt";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text documents (.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine(json);
                }
            }
        }
        #endregion

    }
}
