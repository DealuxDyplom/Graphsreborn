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
using System.Drawing;
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
            Databank.isotherms = new List<IsothermSeries>();

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

            ChartArea substancesGraph_ChartArea = new ChartArea();
            substancesGraph_ChartArea.AxisX.IsStartedFromZero = false;
            substancesGraph_ChartArea.AxisX.MajorGrid.Enabled = false;
            substancesGraph_ChartArea.AxisY.IsStartedFromZero = false;
            substancesGraph_ChartArea.AxisY.MajorGrid.Enabled = false;
            substancesGraph_ChartArea.AxisX.IsStartedFromZero = true;
            substancesGraph_ChartArea.AxisY.IsStartedFromZero = true;
            substancesGraph_ChartArea.AlignmentOrientation = AreaAlignmentOrientations.All;
            Graphs_Substances.ChartAreas.Add(substancesGraph_ChartArea);

            LoadStartupTestDataIfRequested();
        }

        private void LoadStartupTestDataIfRequested()
        {
            string[] arguments = Environment.GetCommandLineArgs();
            bool openKineticModels = arguments.Length >= 3
                && string.Equals(arguments[1], "--kinetics", StringComparison.OrdinalIgnoreCase);
            bool openIsotherms = arguments.Length >= 3
                && string.Equals(arguments[1], "--isotherms", StringComparison.OrdinalIgnoreCase);
            bool openFirstIsothermGraph = arguments.Any(argument =>
                string.Equals(argument, "--open-first", StringComparison.OrdinalIgnoreCase));
            string dataFile = openKineticModels || openIsotherms
                ? arguments[2]
                : arguments.Length >= 2 ? arguments[1] : null;

            if (string.IsNullOrWhiteSpace(dataFile) || !File.Exists(dataFile)) return;

            if (openIsotherms)
            {
                LoadIsotherms(dataFile);
                if (openFirstIsothermGraph)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var isothermTable = new IsothermModelTableForm(this);
                        isothermTable.Show();
                        if (Databank.isotherms.Count > 0)
                            new IsothermGraphForm(Databank.isotherms[0], isothermTable).Show();
                        Hide();
                    }));
                }
                return;
            }

            LoadSubstances(dataFile);
            if (!openKineticModels) return;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                var kineticModelTableForm = new KineticModelTableForm(this);
                kineticModelTableForm.Show();
                Hide();
            }));
        }

        private void LoadIsotherms(string fileName)
        {
            string json = File.ReadAllText(fileName);
            Databank.isotherms = JsonConvert.DeserializeObject<List<IsothermSeries>>(json)
                ?? new List<IsothermSeries>();
            fillGroupBoxIsothermCheckboxes();
        }

        private void LoadSubstances(string fileName)
        {
            string json = File.ReadAllText(fileName);
            Databank.substances = JsonConvert.DeserializeObject<List<Substance>>(json)
                ?? new List<Substance>();
            fillGroupBoxSubstancesCheckboxes();
        }

        private void Button_AddSubstanceForm_Click(object sender, RoutedEventArgs e)
        {
            AddSubstanceForm addSubstanceForm = new AddSubstanceForm(this);
            addSubstanceForm.Show();

            this.Hide();
        }

        public void fillGroupBoxSubstancesCheckboxes()
        {
            WrapPanel_Substances.Children.Clear();
            checkBoxes_Substances_List.Clear();
            for (int i = 0; i < Databank.substances.Count; i++)
            {
                System.Windows.Controls.CheckBox checkbox_Substance = new System.Windows.Controls.CheckBox();
                checkbox_Substance.Content = Databank.substances[i].name;
                checkbox_Substance.Margin = new System.Windows.Thickness(3); //отступ чекбоксов друг от друга
                checkbox_Substance.Checked += paintGraphFromCheckbox;
                checkbox_Substance.Unchecked += clearGraphFromCheckbox;
                WrapPanel_Substances.Children.Add(checkbox_Substance);
                checkBoxes_Substances_List.Add(checkbox_Substance);
            }
        }

        public void updateGroupBoxSubstances()
        {
            fillGroupBoxSubstancesCheckboxes();
            Graphs_Substances.ChartAreas.Clear();
            Graphs_Substances.Series.Clear();
        }

        private void paintGraphFromCheckbox(object sender, RoutedEventArgs e)
        {
            Graphs_Substances.ChartAreas.Clear();
            ChartArea substancesGraph_ChartArea = new ChartArea();
            substancesGraph_ChartArea.AxisX.IsStartedFromZero = false;
            substancesGraph_ChartArea.AxisX.MajorGrid.Enabled = false;
            substancesGraph_ChartArea.AxisY.IsStartedFromZero = false;
            substancesGraph_ChartArea.AxisY.MajorGrid.Enabled = false;
            substancesGraph_ChartArea.AxisX.IsStartedFromZero = true;
            substancesGraph_ChartArea.AxisY.IsStartedFromZero = true;
            substancesGraph_ChartArea.AlignmentOrientation = AreaAlignmentOrientations.All;
            substancesGraph_ChartArea.AxisX.Title = "t, мин";
            substancesGraph_ChartArea.AxisY.Title = "qt, μмоль/г";
            Graphs_Substances.ChartAreas.Add(substancesGraph_ChartArea);
            for (int i = 0; i < Databank.substances.Count; i++)
            {
                if (Databank.substances[i].name == ((System.Windows.Controls.CheckBox)sender).Content.ToString())
                {
                    Random rand = new Random();

                    Series substanceGraph_SeriesLine = new Series();
                    substanceGraph_SeriesLine.ChartType = SeriesChartType.Spline;
                    substanceGraph_SeriesLine.Name = ((System.Windows.Controls.CheckBox)sender).Content.ToString() + "_Line";
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

                    Series substanceGraph_SeriesPoints = new Series();
                    substanceGraph_SeriesPoints.ChartType = SeriesChartType.Point;
                    substanceGraph_SeriesPoints.Name = ((System.Windows.Controls.CheckBox)sender).Content.ToString() + "_Point";
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

                    Graphs_Substances.Series.Add(substanceGraph_SeriesLine);
                    Graphs_Substances.Series.Add(substanceGraph_SeriesPoints);
                    break;
                }
            }
        }

        private void clearGraphFromCheckbox(object sender, RoutedEventArgs e)
        {
            Series substanceGraph_SeriesLine = Graphs_Substances.Series.FindByName(((System.Windows.Controls.CheckBox)sender).Content.ToString() + "_Line");
            if (substanceGraph_SeriesLine != null)
                Graphs_Substances.Series.Remove(substanceGraph_SeriesLine);
            Series substanceGraph_SeriesPoint = Graphs_Substances.Series.FindByName(((System.Windows.Controls.CheckBox)sender).Content.ToString() + "_Point");
            if (substanceGraph_SeriesPoint != null)
                Graphs_Substances.Series.Remove(substanceGraph_SeriesPoint);
        }

        private void paintIsothermGraphFromCheckbox(object sender, RoutedEventArgs e)
        {
            var checkbox = (System.Windows.Controls.CheckBox)sender;
            string name = checkbox.Content.ToString();
            IsothermSeries isotherm = Databank.isotherms.FirstOrDefault(item => item.name == name);
            if (isotherm == null || isotherm.data == null) return;

            Graphs_Substances.ChartAreas.Clear();
            var area = new ChartArea();
            area.AxisX.IsStartedFromZero = true;
            area.AxisY.IsStartedFromZero = true;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AlignmentOrientation = AreaAlignmentOrientations.All;
            area.AxisX.Title = "Ce, " + isotherm.concentrationUnit;
            area.AxisY.Title = "qe, " + isotherm.capacityUnit;
            area.AxisX.LabelStyle.Format = "0.#####";
            area.AxisY.LabelStyle.Format = "0.#####";
            Graphs_Substances.ChartAreas.Add(area);

            int index = Databank.isotherms.IndexOf(isotherm);
            System.Drawing.Color[] colors =
            {
                System.Drawing.Color.SeaGreen,
                System.Drawing.Color.SteelBlue,
                System.Drawing.Color.DarkOrange,
                System.Drawing.Color.MediumVioletRed
            };
            System.Drawing.Color color = colors[Math.Abs(index) % colors.Length];

            var line = new Series(name + "_Line")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3,
                Color = color
            };
            line.SetCustomProperty("LineTension", "0.2");

            var points = new Series(name + "_Point")
            {
                ChartType = SeriesChartType.Point,
                Color = color,
                MarkerSize = 10,
                MarkerBorderColor = System.Drawing.Color.Black,
                MarkerStyle = MarkerStyle.Circle
            };

            foreach (var point in isotherm.data
                .Where(item => item.Ce >= 0 && item.Qe >= 0)
                .OrderBy(item => item.Ce))
            {
                line.Points.AddXY(point.Ce, point.Qe);
                points.Points.AddXY(point.Ce, point.Qe);
            }

            Graphs_Substances.Series.Add(line);
            Graphs_Substances.Series.Add(points);
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
                LoadSubstances(openFileDialog.FileName);
            }
        }

        private void fillGroupBoxIsothermCheckboxes()
        {
            WrapPanel_Substances.Children.Clear();
            checkBoxes_Substances_List.Clear();
            foreach (var isotherm in Databank.isotherms)
            {
                var checkbox = new System.Windows.Controls.CheckBox
                {
                    Content = isotherm.name,
                    Margin = new System.Windows.Thickness(3)
                };
                checkbox.Checked += paintIsothermGraphFromCheckbox;
                checkbox.Unchecked += clearGraphFromCheckbox;
                WrapPanel_Substances.Children.Add(checkbox);
                checkBoxes_Substances_List.Add(checkbox);
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

        private void Button_EditSubstanceForm_Click(object sender, RoutedEventArgs e)
        {
            EditSubstanceForm editSubstanceForm = new EditSubstanceForm(this);
            editSubstanceForm.Show();

            this.Hide();
        }

        private void Button_GraduationForm_Click(object sender, RoutedEventArgs e)
        {
            GraduationsListForm graduationsListForm = new GraduationsListForm(this);
            graduationsListForm.Show();

            this.Hide();
        }

        private void Button_PsevdoGraphs_Click(object sender, RoutedEventArgs e)
        {
            KineticModelTableForm kineticModelTableForm = new KineticModelTableForm(this);
            kineticModelTableForm.Show();

            this.Hide();
        }

        private void Button_Isotherms_Click(object sender, RoutedEventArgs e)
        {
            IsothermModelTableForm isothermModelTableForm = new IsothermModelTableForm(this);
            isothermModelTableForm.Show();

            this.Hide();
        }
    }
}
