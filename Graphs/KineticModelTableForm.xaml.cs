using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Graphs
{
    /// <summary>
    /// Displays parameters obtained from the product's linearized kinetic models.
    /// </summary>
    public partial class KineticModelTableForm : Window
    {
        private readonly MainWindow parent;

        public KineticModelTableForm(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();

            for (int i = 0; i < Databank.substances.Count; i++)
            {
                var substance = Databank.substances[i];
                try
                {
                    KineticModelFitter.Fit(substance);
                }
                catch (ArgumentException error)
                {
                    AddModelRow(Grid_Psevdo_1_Param, i, substance, "Недостаточно корректных данных", double.NaN, double.NaN, double.NaN, false, error.Message);
                    AddModelRow(Grid_Psevdo_2_Param, i, substance, "Недостаточно корректных данных", double.NaN, double.NaN, double.NaN, false, error.Message);
                    continue;
                }

                AddModelRow(
                    Grid_Psevdo_1_Param,
                    i,
                    substance,
                    FormatEquation(substance.psevdo_1_data.a, substance.psevdo_1_data.b),
                    substance.psevdo_1_data.Qe1,
                    substance.psevdo_1_data.k1,
                    substance.psevdo_1_data.determination,
                    substance.psevdo_1_data.rateConstantIdentifiable,
                    substance.psevdo_1_data.fitNote);

                AddModelRow(
                    Grid_Psevdo_2_Param,
                    i,
                    substance,
                    FormatEquation(substance.psevdo_2_data.a, substance.psevdo_2_data.b),
                    substance.psevdo_2_data.Qe2,
                    substance.psevdo_2_data.k2,
                    substance.psevdo_2_data.determination,
                    substance.psevdo_2_data.rateConstantIdentifiable,
                    substance.psevdo_2_data.fitNote);
            }
        }

        private void AddModelRow(
            Grid grid,
            int row,
            Substance substance,
            string equation,
            double qe,
            double rateConstant,
            double rSquared,
            bool rateConstantIdentifiable,
            string fitNote)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            for (int column = 0; column < 5; column++)
            {
                var border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1, 0, column == 4 ? 1 : 0, 1),
                    MinHeight = 54
                };
                Grid.SetColumn(border, column);
                Grid.SetRow(border, row);
                grid.Children.Add(border);
            }

            var sampleName = CreateLabel(substance.name);
            if (!double.IsNaN(qe))
            {
                sampleName.MouseEnter += paintLabel;
                sampleName.MouseLeave += paintLabel;
                sampleName.MouseDown += showPsevdoGraphForm;
                sampleName.Cursor = Cursors.Hand;
            }
            else
            {
                sampleName.ToolTip = fitNote;
            }
            AddCell(grid, sampleName, row, 0);
            AddCell(grid, CreateLabel(equation), row, 1);
            AddCell(grid, CreateLabel(FormatNumber(qe)), row, 2);
            var rateLabel = CreateLabel(rateConstantIdentifiable ? FormatNumber(rateConstant) : "не определяется");
            rateLabel.ToolTip = fitNote;
            AddCell(grid, rateLabel, row, 3);
            AddCell(grid, CreateLabel(FormatNumber(rSquared)), row, 4);
        }

        private static Label CreateLabel(string text)
        {
            return new Label
            {
                Content = new TextBlock
                {
                    Text = text,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center
                },
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Padding = new Thickness(6)
            };
        }

        private static void AddCell(Grid grid, UIElement element, int row, int column)
        {
            Grid.SetRow(element, row);
            Grid.SetColumn(element, column);
            grid.Children.Add(element);
        }

        private static string FormatNumber(double value)
        {
            return double.IsNaN(value) || double.IsInfinity(value) ? "—" : value.ToString("G6");
        }

        private static string FormatEquation(double intercept, double slope)
        {
            if (double.IsNaN(intercept) || double.IsInfinity(intercept)
                || double.IsNaN(slope) || double.IsInfinity(slope)) return "—";
            return "y = " + intercept.ToString("G6")
                + (slope < 0 ? " − " : " + ")
                + Math.Abs(slope).ToString("G6") + "·x";
        }

        private void paintLabel(object sender, RoutedEventArgs e)
        {
            var label = (Label)sender;
            label.Background = e.RoutedEvent == MouseEnterEvent
                ? new SolidColorBrush(Color.FromRgb(225, 235, 245))
                : Brushes.Transparent;
        }

        private void showPsevdoGraphForm(object sender, RoutedEventArgs e)
        {
            var label = (Label)sender;
            var grid = (Grid)VisualTreeHelper.GetParent(label);
            int model = grid.Name == "Grid_Psevdo_1_Param" ? 1 : 2;
            string substanceName = ((TextBlock)label.Content).Text;

            foreach (var substance in Databank.substances)
            {
                if (substance.name != substanceName) continue;
                new PsevdoGraphForm(substance, model, this).Show();
                break;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Show();
        }
    }
}
