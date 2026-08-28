using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    public partial class AddIsothermForm : Window
    {
        private readonly MainWindow parent;
        private readonly ObservableCollection<Graduation_Row> graduationRows = new ObservableCollection<Graduation_Row>();
        private readonly ObservableCollection<IsothermInputRow> inputRows = new ObservableCollection<IsothermInputRow>();
        private readonly ObservableCollection<IsothermPoint> calculatedRows = new ObservableCollection<IsothermPoint>();
        private double calibrationK;
        private double calibrationDetermination;

        public AddIsothermForm(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();
            DataGrid_Graduation.ItemsSource = graduationRows;
            DataGrid_Input.ItemsSource = inputRows;
            DataGrid_Calculated.ItemsSource = calculatedRows;
            foreach (Graduation graduation in Databank.graduations)
                ComboBox_Graduation.Items.Add(graduation.name);
            if (ComboBox_Graduation.Items.Count > 0) ComboBox_Graduation.SelectedIndex = 0;
        }

        private void ComboBox_Graduation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Graduation graduation = Databank.graduations.FirstOrDefault(item => item.name == ComboBox_Graduation.SelectedItem as string);
            if (graduation == null) return;
            graduationRows.Clear();
            foreach (GraduationData point in graduation.data)
                graduationRows.Add(new Graduation_Row { C_mkmol = point.C_mkmol, A = point.A });
            try
            {
                IsothermCalculator.FitCalibration(graduation, out calibrationK, out calibrationDetermination);
                TextBox_Coef.Text = Format(calibrationK);
                TextBox_Determination.Text = Format(calibrationDetermination);
                DrawCalibration(graduation);
            }
            catch (ArgumentException error) { ShowError(error.Message); }
        }

        private void DrawCalibration(Graduation graduation)
        {
            Chart_Graduation.Series.Clear();
            Chart_Graduation.ChartAreas.Clear();
            Chart_Graduation.Legends.Clear();
            var area = new ChartArea();
            area.AxisX.Title = "C, мкг/мл";
            area.AxisY.Title = "A";
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            Chart_Graduation.ChartAreas.Add(area);
            Chart_Graduation.Legends.Add(new Legend());
            var line = new Series("Линия тренда") { ChartType = SeriesChartType.Line, BorderWidth = 3, Color = System.Drawing.Color.SteelBlue };
            var points = new Series("Градуировка") { ChartType = SeriesChartType.Point, MarkerSize = 9, MarkerStyle = MarkerStyle.Circle, MarkerBorderColor = System.Drawing.Color.Black, Color = System.Drawing.Color.Orange };
            foreach (GraduationData point in graduation.data)
                points.Points.AddXY(point.C_mkmol, point.A);
            double min = graduation.data.Min(point => point.C_mkmol);
            double max = graduation.data.Max(point => point.C_mkmol);
            line.Points.AddXY(min, min * calibrationK);
            line.Points.AddXY(max, max * calibrationK);
            Chart_Graduation.Series.Add(line);
            Chart_Graduation.Series.Add(points);
        }

        private bool Recalculate()
        {
            DataGrid_Input.CommitEdit(DataGridEditingUnit.Cell, true);
            DataGrid_Input.CommitEdit(DataGridEditingUnit.Row, true);
            double volume, molarMass, temperature;
            if (!TryParse(TextBox_Volume.Text, out volume) || volume <= 0
                || !TryParse(TextBox_MolarMass.Text, out molarMass) || molarMass <= 0
                || !TryParse(TextBox_Temperature.Text, out temperature))
            {
                ShowError("Проверьте температуру, объём раствора и молярную массу.");
                return false;
            }
            if (calibrationK <= 0 || inputRows.Count < 3)
            {
                ShowError("Выберите градуировку и введите не менее трёх экспериментальных строк.");
                return false;
            }

            calculatedRows.Clear();
            try
            {
                foreach (IsothermInputRow row in inputRows)
                    calculatedRows.Add(IsothermCalculator.Calculate(row.InitialOpticalDensity,
                        row.SorbentMassG, row.EquilibriumOpticalDensity,
                        calibrationK, volume, molarMass));
            }
            catch (ArgumentException error)
            {
                calculatedRows.Clear();
                ShowError(error.Message);
                return false;
            }
            return calculatedRows.Count >= 3;
        }

        private void Button_Recalculate_Click(object sender, RoutedEventArgs e) { Recalculate(); }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBox_Name.Text.Trim();
            double temperature, volume, molarMass;
            if (name.Length == 0) { ShowError("Введите название образца."); return; }
            if (Databank.isotherms.Any(item => string.Equals(item.name, name, StringComparison.CurrentCultureIgnoreCase)))
            { ShowError("Изотерма с таким названием уже существует."); return; }
            if (!Recalculate() || !TryParse(TextBox_Temperature.Text, out temperature)
                || !TryParse(TextBox_Volume.Text, out volume) || !TryParse(TextBox_MolarMass.Text, out molarMass)) return;

            var series = new IsothermSeries
            {
                name = name,
                temperatureC = temperature,
                graduationName = ComboBox_Graduation.Text,
                calibrationK = calibrationK,
                solutionVolumeMl = volume,
                molarMassGPerMol = molarMass,
                data = calculatedRows.Select(IsothermCalculator.Clone).OrderBy(point => point.Ce).ToList()
            };
            Databank.isotherms.Add(series);
            parent.SelectIsotherm(name);
            Close();
        }

        private void Button_LoadRaw_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog { DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt" };
            if (dialog.ShowDialog() != true) return;
            inputRows.Clear();
            foreach (string row in File.ReadAllLines(dialog.FileName).Skip(1))
            {
                string[] cells = row.Split('|');
                double initialA, mass, equilibriumA;
                if (cells.Length >= 3 && TryParse(cells[0], out initialA)
                    && TryParse(cells[1], out mass) && TryParse(cells[2], out equilibriumA))
                    inputRows.Add(new IsothermInputRow { InitialOpticalDensity = initialA, SorbentMassG = mass, EquilibriumOpticalDensity = equilibriumA });
            }
        }

        private void Button_SaveRaw_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog { FileName = "Экспериментальные данные изотермы", DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt" };
            if (dialog.ShowDialog() != true) return;
            using (var writer = new StreamWriter(dialog.FileName))
            {
                writer.WriteLine("Aисх|m,г|Aравн");
                foreach (IsothermInputRow row in inputRows)
                    writer.WriteLine(row.InitialOpticalDensity + "|" + row.SorbentMassG + "|" + row.EquilibriumOpticalDensity);
            }
        }

        private static bool TryParse(string text, out double value)
        {
            return double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value)
                || double.TryParse((text ?? string.Empty).Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private static string Format(double value) { return value.ToString("0.#####", CultureInfo.CurrentCulture); }
        private static void ShowError(string message) { MessageBox.Show(message, "Добавление изотермы", MessageBoxButton.OK, MessageBoxImage.Warning); }
        private void Window_Closed(object sender, EventArgs e) { parent.RefreshCurrentModeView(); parent.Show(); }
    }
}
