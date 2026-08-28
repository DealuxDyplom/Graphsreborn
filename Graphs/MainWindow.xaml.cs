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
        private readonly HashSet<string> selectedKineticNames = new HashSet<string>();
        private readonly HashSet<string> selectedIsothermNames = new HashSet<string>();
        private readonly Dictionary<string, System.Drawing.Color> seriesColors =
            new Dictionary<string, System.Drawing.Color>(StringComparer.CurrentCultureIgnoreCase);
        private readonly System.Drawing.Color[] colorPalette =
        {
            System.Drawing.Color.SteelBlue,
            System.Drawing.Color.SeaGreen,
            System.Drawing.Color.DarkOrange,
            System.Drawing.Color.MediumVioletRed,
            System.Drawing.Color.MediumPurple,
            System.Drawing.Color.Teal,
            System.Drawing.Color.Firebrick,
            System.Drawing.Color.OliveDrab
        };
        private bool isIsothermMode;

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
            RefreshCurrentModeView();
        }

        private void LoadStartupTestDataIfRequested()
        {
            string[] arguments = Environment.GetCommandLineArgs();
            string kineticFile = GetArgumentValue(arguments, "--kinetics");
            string isothermFile = GetArgumentValue(arguments, "--isotherms");
            bool openFirstIsothermGraph = arguments.Any(argument =>
                string.Equals(argument, "--open-first", StringComparison.OrdinalIgnoreCase));
            bool keepMainWindow = arguments.Any(argument =>
                string.Equals(argument, "--main", StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(kineticFile) && File.Exists(kineticFile))
                LoadSubstances(kineticFile);
            if (!string.IsNullOrWhiteSpace(isothermFile) && File.Exists(isothermFile))
                LoadIsotherms(isothermFile);

            if (!string.IsNullOrWhiteSpace(isothermFile) && File.Exists(isothermFile))
            {
                ModeTabs.SelectedIndex = 1;
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

            if (!string.IsNullOrWhiteSpace(kineticFile) && File.Exists(kineticFile))
            {
                ModeTabs.SelectedIndex = 0;
                if (keepMainWindow) return;

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var kineticModelTableForm = new KineticModelTableForm(this);
                    kineticModelTableForm.Show();
                    Hide();
                }));
                return;
            }

            string legacyFile = arguments.Length >= 2 ? arguments[1] : null;
            if (!string.IsNullOrWhiteSpace(legacyFile) && File.Exists(legacyFile))
                LoadSubstances(legacyFile);
        }

        private static string GetArgumentValue(string[] arguments, string name)
        {
            for (int i = 1; i < arguments.Length - 1; i++)
            {
                if (string.Equals(arguments[i], name, StringComparison.OrdinalIgnoreCase))
                    return arguments[i + 1];
            }
            return null;
        }

        private void LoadIsotherms(string fileName)
        {
            string json = File.ReadAllText(fileName);
            Databank.isotherms = JsonConvert.DeserializeObject<List<IsothermSeries>>(json)
                ?? new List<IsothermSeries>();
            selectedIsothermNames.RemoveWhere(name =>
                !Databank.isotherms.Any(item => item.name == name));
            if (isIsothermMode) RefreshCurrentModeView();
        }

        private void LoadSubstances(string fileName)
        {
            string json = File.ReadAllText(fileName);
            Databank.substances = JsonConvert.DeserializeObject<List<Substance>>(json)
                ?? new List<Substance>();
            selectedKineticNames.RemoveWhere(name =>
                !Databank.substances.Any(item => item.name == name));
            if (!isIsothermMode) RefreshCurrentModeView();
        }

        private void ModeTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source != ModeTabs || checkBoxes_Substances_List == null
                || Databank.substances == null || Databank.isotherms == null) return;

            SaveVisibleSelection();
            isIsothermMode = ModeTabs.SelectedIndex == 1;
            RefreshCurrentModeView();
        }

        private void SaveVisibleSelection()
        {
            HashSet<string> selected = isIsothermMode
                ? selectedIsothermNames
                : selectedKineticNames;
            selected.Clear();
            foreach (var checkbox in checkBoxes_Substances_List)
            {
                if (checkbox.IsChecked == true)
                    selected.Add(checkbox.Content.ToString());
            }
        }

        public void RefreshCurrentModeView()
        {
            if (checkBoxes_Substances_List == null || Databank.substances == null
                || Databank.isotherms == null) return;

            isIsothermMode = ModeTabs.SelectedIndex == 1;
            Button_AddSubstanceForm.Content = isIsothermMode
                ? "Добавить изотерму"
                : "Добавить новый раствор";
            GroupBox_Series.Header = isIsothermMode
                ? "Экспериментальные изотермы"
                : "Кинетические ряды";
            Button_EditSubstanceForm.Content = isIsothermMode
                ? "Редактировать изотерму"
                : "Редактировать раствор";
            Button_GraduationForm.IsEnabled = !isIsothermMode;
            Button_PsevdoGraphs.IsEnabled = !isIsothermMode;
            Button_Isotherms.IsEnabled = isIsothermMode;

            Graphs_Substances.Series.Clear();
            Graphs_Substances.ChartAreas.Clear();
            Graphs_Substances.Titles.Clear();
            if (isIsothermMode)
                Graphs_Substances.Titles.Add("Изотерма сорбции");
            if (isIsothermMode)
                fillGroupBoxIsothermCheckboxes();
            else
                fillGroupBoxSubstancesCheckboxes();

            foreach (var checkbox in checkBoxes_Substances_List.Where(item => item.IsChecked == true))
            {
                if (isIsothermMode)
                    paintIsothermGraphFromCheckbox(checkbox, new RoutedEventArgs());
                else
                    paintGraphFromCheckbox(checkbox, new RoutedEventArgs());
            }

            if (Graphs_Substances.ChartAreas.Count == 0)
            {
                var area = new ChartArea();
                area.AxisX.Title = isIsothermMode ? "C0, мкмоль/л" : "t, мин";
                area.AxisY.Title = isIsothermMode ? "qe, мкмоль/г" : "qt, мкмоль/г";
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.Enabled = false;
                Graphs_Substances.ChartAreas.Add(area);
            }
        }

        public void SelectIsotherm(string name)
        {
            selectedIsothermNames.RemoveWhere(selectedName =>
                !Databank.isotherms.Any(item => item.name == selectedName));
            selectedIsothermNames.Add(name);
            if (ModeTabs.SelectedIndex != 1)
                ModeTabs.SelectedIndex = 1;
        }

        private void Button_AddSubstanceForm_Click(object sender, RoutedEventArgs e)
        {
            if (isIsothermMode)
            {
                new AddIsothermForm(this).Show();
                Hide();
                return;
            }
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
                checkbox_Substance.IsChecked = selectedKineticNames.Contains(Databank.substances[i].name);
                checkbox_Substance.Checked += paintGraphFromCheckbox;
                checkbox_Substance.Unchecked += clearGraphFromCheckbox;
                WrapPanel_Substances.Children.Add(checkbox_Substance);
                checkBoxes_Substances_List.Add(checkbox_Substance);
            }
        }

        public void updateGroupBoxSubstances()
        {
            RefreshCurrentModeView();
        }

        private void paintGraphFromCheckbox(object sender, RoutedEventArgs e)
        {
            string selectedName = ((System.Windows.Controls.CheckBox)sender).Content.ToString();
            selectedKineticNames.Add(selectedName);
            RemoveSeries(selectedName);
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
                    Series substanceGraph_SeriesLine = new Series();
                    substanceGraph_SeriesLine.ChartType = SeriesChartType.Spline;
                    substanceGraph_SeriesLine.Name = ((System.Windows.Controls.CheckBox)sender).Content.ToString() + "_Line";
                    substanceGraph_SeriesLine.SetCustomProperty("LineTension", "0.2");
                    substanceGraph_SeriesLine.BorderWidth = 3;
                    substanceGraph_SeriesLine.Color = GetSeriesColor(selectedName);
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
            string name = ((System.Windows.Controls.CheckBox)sender).Content.ToString();
            if (isIsothermMode)
                selectedIsothermNames.Remove(name);
            else
                selectedKineticNames.Remove(name);
            RemoveSeries(name);
        }

        private void RemoveSeries(string name)
        {
            Series line = Graphs_Substances.Series.FindByName(name + "_Line");
            if (line != null) Graphs_Substances.Series.Remove(line);
            Series points = Graphs_Substances.Series.FindByName(name + "_Point");
            if (points != null) Graphs_Substances.Series.Remove(points);
        }

        private void paintIsothermGraphFromCheckbox(object sender, RoutedEventArgs e)
        {
            var checkbox = (System.Windows.Controls.CheckBox)sender;
            string name = checkbox.Content.ToString();
            selectedIsothermNames.Add(name);
            RemoveSeries(name);
            IsothermSeries isotherm = Databank.isotherms.FirstOrDefault(item => item.name == name);
            if (isotherm == null || isotherm.data == null) return;

            Graphs_Substances.ChartAreas.Clear();
            var area = new ChartArea();
            area.AxisX.IsStartedFromZero = true;
            area.AxisY.IsStartedFromZero = true;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AlignmentOrientation = AreaAlignmentOrientations.All;
            area.AxisX.Title = "C0, " + isotherm.concentrationUnit;
            area.AxisY.Title = "qe, " + isotherm.capacityUnit;
            area.AxisX.LabelStyle.Format = "0.#####";
            area.AxisY.LabelStyle.Format = "0.#####";
            Graphs_Substances.ChartAreas.Add(area);

            System.Drawing.Color color = GetSeriesColor(name);

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

            var displayPoints = isotherm.data
                .Select(point => new
                {
                    Point = point,
                    InitialConcentration = IsothermCalculator.GetEditorConcentration(point, isotherm)
                })
                .Where(item => !double.IsNaN(item.InitialConcentration)
                    && !double.IsInfinity(item.InitialConcentration)
                    && item.InitialConcentration >= 0
                    && !double.IsNaN(item.Point.Qe)
                    && !double.IsInfinity(item.Point.Qe)
                    && item.Point.Qe >= 0)
                .OrderBy(item => item.InitialConcentration);

            foreach (var item in displayPoints)
            {
                line.Points.AddXY(item.InitialConcentration, item.Point.Qe);
                points.Points.AddXY(item.InitialConcentration, item.Point.Qe);
            }

            Graphs_Substances.Series.Add(line);
            Graphs_Substances.Series.Add(points);
        }

        public System.Drawing.Color GetSeriesColor(string name)
        {
            System.Drawing.Color color;
            if (seriesColors.TryGetValue(name ?? string.Empty, out color)) return color;

            color = colorPalette[seriesColors.Count % colorPalette.Length];
            seriesColors[name ?? string.Empty] = color;
            return color;
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
                ModeTabs.SelectedIndex = 0;
            }
        }

        private void Menu_SaveIsotherms_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.FileName = "Изотермы.txt";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text documents (.txt)|*.txt";
            if (saveFileDialog.ShowDialog() != true) return;
            File.WriteAllText(saveFileDialog.FileName,
                JsonConvert.SerializeObject(Databank.isotherms));
        }

        private void Menu_LoadIsotherms_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text documents (.txt)|*.txt";
            if (openFileDialog.ShowDialog() != true) return;
            LoadIsotherms(openFileDialog.FileName);
            ModeTabs.SelectedIndex = 1;
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
                    Margin = new System.Windows.Thickness(3),
                    IsChecked = selectedIsothermNames.Contains(isotherm.name)
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

                RefreshCurrentModeView();
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
            if (isIsothermMode)
            {
                if (Databank.isotherms.Count == 0)
                {
                    System.Windows.MessageBox.Show(
                        "Сначала добавьте или загрузите изотерму.",
                        "Редактирование изотерм",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    return;
                }
                var selected = checkBoxes_Substances_List.FirstOrDefault(item => item.IsChecked == true);
                IsothermSeries series = selected == null ? Databank.isotherms[0]
                    : Databank.isotherms.FirstOrDefault(item => item.name == selected.Content.ToString());
                new IsothermDataForm(this, series).Show();
                Hide();
                return;
            }
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
