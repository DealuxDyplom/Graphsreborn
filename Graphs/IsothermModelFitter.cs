using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    /// <summary>
    /// Calculates the displayed linear Langmuir form Ce/qe = a + b*Ce.
    /// R² is calculated in the same transformed coordinates as the chart.
    /// </summary>
    public static class IsothermModelFitter
    {
        public static void FitLangmuir(IsothermSeries series)
        {
            if (series == null) throw new ArgumentNullException(nameof(series));
            if (series.data == null)
                throw new ArgumentException("Экспериментальные данные отсутствуют.", nameof(series));

            var points = series.data
                .Where(point => IsFinite(point.Ce) && IsFinite(point.Qe)
                    && point.Ce > 0 && point.Qe > 0)
                .OrderBy(point => point.Ce)
                .ToList();
            if (points.Count < 3)
                throw new ArgumentException("Для расчёта необходимо не менее трёх точек с Ce > 0 и qe > 0.", nameof(series));

            foreach (var point in series.data)
            {
                point.LinearX = point.Ce;
                point.LinearY = point.Ce > 0 && point.Qe > 0
                    ? point.Ce / point.Qe
                    : double.NaN;
            }

            double meanX = points.Average(point => point.LinearX);
            double meanY = points.Average(point => point.LinearY);
            double xx = points.Sum(point => Square(point.LinearX - meanX));
            if (xx <= 0)
                throw new ArgumentException("Для линеаризации нужны различные значения Ce.", nameof(series));

            double slope = points.Sum(point =>
                (point.LinearX - meanX) * (point.LinearY - meanY)) / xx;
            double intercept = meanY - slope * meanX;
            double total = points.Sum(point => Square(point.LinearY - meanY));
            double residual = points.Sum(point =>
                Square(point.LinearY - (intercept + slope * point.LinearX)));
            double rSquared = total > 0 ? 1.0 - residual / total : double.NaN;

            double qMax = slope > 0 ? 1.0 / slope : double.NaN;
            double kL = intercept > 0 && slope > 0 ? slope / intercept : double.NaN;
            bool isValid = IsFinite(qMax) && IsFinite(kL) && qMax > 0 && kL > 0;

            series.langmuir = new LangmuirResult
            {
                a = intercept,
                b = slope,
                qMax = qMax,
                kL = kL,
                determination = rSquared,
                isPhysicallyValid = isValid,
                fitNote = isValid
                    ? "Линейная форма Langmuir: Ce/qe = a + b·Ce; R² рассчитан в этих координатах."
                    : "Регрессия рассчитана, но положительные qmax и KL не определяются: модель неприменима к этому набору данных."
            };
        }

        private static bool IsFinite(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        private static double Square(double value)
        {
            return value * value;
        }
    }
}
