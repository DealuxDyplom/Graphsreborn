using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Graphs
{
    public partial class IsothermModelTableForm : Window
    {
        private readonly MainWindow parent;

        public IsothermModelTableForm(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();
            Height = Math.Min(850, Math.Max(230, 120 + Databank.isotherms.Count * 58));

            for (int i = 0; i < Databank.isotherms.Count; i++)
            {
                var series = Databank.isotherms[i];
                try
                {
                    IsothermModelFitter.FitLangmuir(series);
                    AddRow(i, series, FormatEquation(series.langmuir.a, series.langmuir.b),
                        series.langmuir.qMax, series.langmuir.kL,
                        series.langmuir.determination,
                        series.langmuir.isPhysicallyValid ? "применима" : "неприменима",
                        series.langmuir.fitNote, true);
                }
                catch (ArgumentException error)
                {
                    AddRow(i, series, "Недостаточно корректных данных", double.NaN,
                        double.NaN, double.NaN, "нет расчёта", error.Message, false);
                }
            }
        }

        private void AddRow(int row, IsothermSeries series, string equation,
            double qMax, double kL, double rSquared, string status,
            string fitNote, bool hasRegression)
        {
            Grid_LangmuirParam.RowDefinitions.Add(new RowDefinition
            {
                Height = GridLength.Auto,
                MinHeight = 58
            });

            for (int column = 0; column < 6; column++)
            {
                var border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1, 0, 0, 1),
                    MinHeight = 58
                };
                Grid.SetColumn(border, column);
                Grid.SetRow(border, row);
                Grid_LangmuirParam.Children.Add(border);
            }

            Control sample;
            if (hasRegression)
            {
                var sampleButton = new Button
                {
                    Content = CreateText(series.name),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Padding = new Thickness(6),
                    Background = Brushes.Transparent,
                    BorderThickness = new Thickness(0),
                    Cursor = Cursors.Hand
                };
                sampleButton.Click += ShowLangmuirGraph;
                sample = sampleButton;
            }
            else
            {
                sample = CreateLabel(series.name);
            }
            sample.ToolTip = fitNote;
            AddCell(sample, row, 0);
            AddCell(CreateLabel(equation), row, 1);
            AddCell(CreateLabel(FormatNumber(qMax)), row, 2);
            AddCell(CreateLabel(FormatNumber(kL)), row, 3);
            AddCell(CreateLabel(FormatNumber(rSquared)), row, 4);
            var statusLabel = CreateLabel(status);
            statusLabel.ToolTip = fitNote;
            statusLabel.Foreground = status == "применима" ? Brushes.DarkGreen : Brushes.DarkRed;
            AddCell(statusLabel, row, 5);
        }

        private static Label CreateLabel(string text)
        {
            return new Label
            {
                Content = CreateText(text),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Padding = new Thickness(6)
            };
        }

        private static TextBlock CreateText(string text)
        {
            return new TextBlock
            {
                Text = text,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center
            };
        }

        private static string FormatNumber(double value)
        {
            return double.IsNaN(value) || double.IsInfinity(value) ? "—" : value.ToString("G6");
        }

        private static string FormatEquation(double intercept, double slope)
        {
            return "y = " + FormatNumber(intercept)
                + (slope < 0 ? " − " : " + ")
                + FormatNumber(Math.Abs(slope)) + "·x";
        }

        private void AddCell(UIElement element, int row, int column)
        {
            Grid.SetRow(element, row);
            Grid.SetColumn(element, column);
            Grid_LangmuirParam.Children.Add(element);
        }

        private void ShowLangmuirGraph(object sender, RoutedEventArgs e)
        {
            string name = ((TextBlock)((ContentControl)sender).Content).Text;
            foreach (var series in Databank.isotherms)
            {
                if (series.name != name) continue;
                new IsothermGraphForm(series, this).Show();
                break;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Show();
        }
    }
}
