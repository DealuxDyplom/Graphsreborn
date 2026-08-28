using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    public static class ChartAxisHelper
    {
        public static void ConfigureFromZero(Axis axis, double dataMaximum,
            int desiredIntervals)
        {
            double safeMaximum = IsFinite(dataMaximum) && dataMaximum > 0
                ? dataMaximum : 1.0;
            int intervals = Math.Max(2, desiredIntervals);
            double interval = NiceInterval(safeMaximum / intervals);
            double maximum = Math.Ceiling(safeMaximum / interval) * interval;

            axis.Minimum = 0.0;
            axis.Maximum = Math.Max(interval, maximum);
            axis.Interval = interval;
            axis.IsStartedFromZero = true;
            axis.IsMarginVisible = false;
            axis.LabelStyle.Format = "0.#####";
        }

        private static double NiceInterval(double rawInterval)
        {
            if (!IsFinite(rawInterval) || rawInterval <= 0) return 1.0;

            double exponent = Math.Floor(Math.Log10(rawInterval));
            double magnitude = Math.Pow(10.0, exponent);
            double fraction = rawInterval / magnitude;
            double niceFraction;

            if (fraction <= 1.0) niceFraction = 1.0;
            else if (fraction <= 2.0) niceFraction = 2.0;
            else if (fraction <= 2.5) niceFraction = 2.5;
            else if (fraction <= 5.0) niceFraction = 5.0;
            else niceFraction = 10.0;

            return niceFraction * magnitude;
        }

        private static bool IsFinite(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }
    }
}
