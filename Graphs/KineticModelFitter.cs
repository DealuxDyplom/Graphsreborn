using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    /// <summary>
    /// Calculates the linearized PFO and PSO representations used by the UI.
    /// R² is calculated in the displayed transformed coordinates.
    /// </summary>
    public static class KineticModelFitter
    {
        // Compatibility with the original presentation: place the PFO equilibrium
        // estimate slightly above the fitted plateau so log10(qe - qt) is usable.
        private const double PfoEquilibriumMargin = 1.02;

        public static void Fit(Substance substance)
        {
            if (substance == null) throw new ArgumentNullException(nameof(substance));
            if (substance.data == null) throw new ArgumentException("Экспериментальные данные отсутствуют.", nameof(substance));

            var points = substance.data
                .Where(row => IsFinite(row.time) && IsFinite(row.qt_ml) && row.time >= 0 && row.qt_ml >= 0)
                .OrderBy(row => row.time)
                .ToList();
            if (points.Count < 3)
                throw new ArgumentException("Для расчёта необходимо не менее трёх корректных точек.", nameof(substance));

            double qeForPfo = EstimatePfoEquilibrium(points) * PfoEquilibriumMargin;
            foreach (var point in substance.data)
            {
                point.Qe1 = qeForPfo;
                point.qe_qt = qeForPfo - point.qt_ml;
                point.log_qe_qt = point.qe_qt > 0 ? Math.Log10(point.qe_qt) : double.NaN;
                point.t_qt = point.qt_ml > 0 ? point.time / point.qt_ml : double.NaN;
            }

            var pfo = LinearRegression(points
                .Select(row => new RegressionPoint(row.time, row.log_qe_qt))
                .Where(row => IsFinite(row.Y)).ToList(), "PFO");
            double k1 = -pfo.Slope * Math.Log(10.0);
            substance.psevdo_1_data = new Psevdo_1_Data
            {
                a = pfo.Intercept, b = pfo.Slope, Qe1 = qeForPfo, k1 = k1,
                determination = pfo.RSquared,
                rateConstantIdentifiable = IsFinite(k1) && k1 > 0,
                fitNote = "Линейная форма PFO: log₁₀(qₑ − qₜ) = a + b·t; R² рассчитан в этих координатах."
            };

            var pso = LinearRegression(points.Where(row => row.qt_ml > 0)
                .Select(row => new RegressionPoint(row.time, row.t_qt))
                .Where(row => IsFinite(row.Y)).ToList(), "PSO");
            double qeForPso = pso.Slope > 0 ? 1.0 / pso.Slope : double.NaN;
            double k2 = pso.Intercept > 0 && IsFinite(qeForPso)
                ? 1.0 / (pso.Intercept * qeForPso * qeForPso)
                : double.NaN;
            substance.psevdo_2_data = new Psevdo_2_Data
            {
                a = pso.Intercept, b = pso.Slope, Qe2 = qeForPso, k2 = k2,
                determination = pso.RSquared,
                rateConstantIdentifiable = IsFinite(k2) && k2 > 0,
                fitNote = "Линейная форма PSO: t/qₜ = a + b·t; R² рассчитан в этих координатах."
            };
        }

        public static double PredictPseudoFirstOrder(double time, double qe, double k1)
        {
            return qe * (1.0 - Math.Exp(-k1 * Math.Max(0.0, time)));
        }

        public static double PredictPseudoSecondOrder(double time, double qe, double k2)
        {
            double safeTime = Math.Max(0.0, time);
            return k2 * qe * qe * safeTime / (1.0 + k2 * qe * safeTime);
        }

        private static double EstimatePfoEquilibrium(IReadOnlyList<SubstanceData> points)
        {
            double timeScale = Math.Max(points.Max(row => row.time), 1.0);
            Func<double, double> error = logRate =>
            {
                double rate = Math.Exp(logRate) / timeScale;
                double numerator = 0.0, denominator = 0.0;
                foreach (var point in points)
                {
                    double factor = 1.0 - Math.Exp(-rate * point.time);
                    numerator += point.qt_ml * factor;
                    denominator += factor * factor;
                }
                double qe = denominator > 0 ? numerator / denominator : 0.0;
                return points.Sum(point => Square(point.qt_ml - qe * (1.0 - Math.Exp(-rate * point.time))));
            };

            double left = -12.0, right = 12.0;
            const double goldenPart = 0.6180339887498948482;
            double x1 = right - goldenPart * (right - left);
            double x2 = left + goldenPart * (right - left);
            double f1 = error(x1), f2 = error(x2);
            for (int i = 0; i < 300 && right - left > 1e-10; i++)
            {
                if (f1 <= f2)
                {
                    right = x2; x2 = x1; f2 = f1;
                    x1 = right - goldenPart * (right - left); f1 = error(x1);
                }
                else
                {
                    left = x1; x1 = x2; f1 = f2;
                    x2 = left + goldenPart * (right - left); f2 = error(x2);
                }
            }

            double rateAtMinimum = Math.Exp((left + right) / 2.0) / timeScale;
            double qeNumerator = 0.0, qeDenominator = 0.0;
            foreach (var point in points)
            {
                double factor = 1.0 - Math.Exp(-rateAtMinimum * point.time);
                qeNumerator += point.qt_ml * factor;
                qeDenominator += factor * factor;
            }
            return qeDenominator > 0 ? qeNumerator / qeDenominator : points.Max(row => row.qt_ml);
        }

        private static RegressionResult LinearRegression(IReadOnlyList<RegressionPoint> points, string modelName)
        {
            if (points.Count < 2)
                throw new ArgumentException("Недостаточно корректных точек для линеаризации " + modelName + ".");
            double meanX = points.Average(point => point.X);
            double meanY = points.Average(point => point.Y);
            double xx = points.Sum(point => Square(point.X - meanX));
            if (xx <= 0)
                throw new ArgumentException("Для линеаризации " + modelName + " нужны различные значения времени.");
            double slope = points.Sum(point => (point.X - meanX) * (point.Y - meanY)) / xx;
            double intercept = meanY - slope * meanX;
            double total = points.Sum(point => Square(point.Y - meanY));
            double residual = points.Sum(point => Square(point.Y - (intercept + slope * point.X)));
            return new RegressionResult(intercept, slope, total > 0 ? 1.0 - residual / total : double.NaN);
        }

        private static bool IsFinite(double value) { return !double.IsNaN(value) && !double.IsInfinity(value); }
        private static double Square(double value) { return value * value; }

        private sealed class RegressionPoint
        {
            public RegressionPoint(double x, double y) { X = x; Y = y; }
            public double X { get; private set; }
            public double Y { get; private set; }
        }

        private sealed class RegressionResult
        {
            public RegressionResult(double intercept, double slope, double rSquared)
            { Intercept = intercept; Slope = slope; RSquared = rSquared; }
            public double Intercept { get; private set; }
            public double Slope { get; private set; }
            public double RSquared { get; private set; }
        }
    }
}
