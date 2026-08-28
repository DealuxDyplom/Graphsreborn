using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Graphs
{
    public partial class IsothermDataForm : Window
    {
        private readonly MainWindow parent;
        private readonly IsothermSeries original;
        private readonly ObservableCollection<IsothermPoint> points;

        public IsothermDataForm(MainWindow owner, IsothermSeries existing = null)
        {
            parent = owner;
            original = existing;
            InitializeComponent();

            points = new ObservableCollection<IsothermPoint>();
            if (existing != null)
            {
                TextBox_Name.Text = existing.name;
                TextBox_Temperature.Text = existing.temperatureC.ToString("G", CultureInfo.CurrentCulture);
                foreach (var point in existing.data ?? Enumerable.Empty<IsothermPoint>())
                    points.Add(new IsothermPoint { Ce = point.Ce, Qe = point.Qe });
            }
            DataGrid_Points.ItemsSource = points;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_Points.CommitEdit(DataGridEditingUnit.Cell, true);
            DataGrid_Points.CommitEdit(DataGridEditingUnit.Row, true);

            string name = TextBox_Name.Text.Trim();
            if (name.Length == 0)
            {
                ShowError("Введите название образца.");
                return;
            }

            double temperature;
            if (!TryParseNumber(TextBox_Temperature.Text, out temperature))
            {
                ShowError("Температура должна быть числом.");
                return;
            }

            if (points.Any(point => (point.Ce > 0 && point.Qe <= 0)
                || (point.Qe > 0 && point.Ce <= 0)))
            {
                ShowError("В каждой строке одновременно укажите положительные Ce и qe.");
                return;
            }

            var validPoints = points
                .Where(point => IsFinite(point.Ce) && IsFinite(point.Qe)
                    && point.Ce > 0 && point.Qe > 0)
                .OrderBy(point => point.Ce)
                .Select(point => new IsothermPoint { Ce = point.Ce, Qe = point.Qe })
                .ToList();
            if (validPoints.Count < 3)
            {
                ShowError("Для изотермы необходимо не менее трёх корректных точек Ce–qe.");
                return;
            }

            bool duplicate = Databank.isotherms.Any(item =>
                !ReferenceEquals(item, original)
                && string.Equals(item.name, name, StringComparison.CurrentCultureIgnoreCase));
            if (duplicate)
            {
                ShowError("Изотерма с таким названием уже существует.");
                return;
            }

            IsothermSeries target = original ?? new IsothermSeries();
            target.name = name;
            target.temperatureC = temperature;
            target.concentrationUnit = "мкмоль/л";
            target.capacityUnit = "мкмоль/г";
            target.data = validPoints;
            target.langmuir = null;
            if (original == null) Databank.isotherms.Add(target);

            parent.SelectIsotherm(name);
            Close();
        }

        private static bool TryParseNumber(string text, out double value)
        {
            return double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value)
                || double.TryParse(text.Replace(',', '.'), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out value);
        }

        private static bool IsFinite(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Данные изотермы", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.RefreshCurrentModeView();
            parent.Show();
        }
    }
}
