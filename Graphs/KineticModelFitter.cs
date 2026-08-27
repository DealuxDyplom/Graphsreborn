using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    /// <summary>
    /// Fits kinetic models directly to q(t), without linearizing the experimental data.
    /// </summary>
    public static class KineticModelFitter
    {
        private const double MinLogRate = -12.0;
        private const double MaxLogRate = 12.0;

        public static void Fit(Substance substance)
        {
            if (substance == null) throw new ArgumentNullException(nameof(substance));
            if (substance.data == null) throw new ArgumentException("Experimental data are missing.", nameof(substance));

            var points = substance.data
                .Where(row => IsFinite(row.time) && IsFinite(row.qt_ml) && row.time >= 0 && row.qt_ml >= 0)
                .OrderBy(row => row.time)
                .ToList();

            if (points.Count < 3)
                throw new ArgumentException("At least three valid kinetic points are required.", nameof(substance));

            double timeScale = Math.Max(points.Max(row => row.time), 1.0);
            double meanQt = points.Average(row => row.qt_ml);
            double totalSumOfSquares = points.Sum(row => Square(row.qt_ml - meanQt));

            var pfo = FitOneParameterShape(points, timeScale, totalSumOfSquares, PseudoFirstOrderShape);
            substance.psevdo_1_data = new Psevdo_1_Data
            {
                Qe1 = pfo.Qe,
                k1 = pfo.ShapeRate,
                determination = pfo.RSquared,
                a = double.NaN,
                b = double.NaN,
                rateConstantIdentifiable = pfo.RateConstantIdentifiable,
                fitNote = pfo.RateConstantIdentifiable
                    ? "Параметры определены прямой нелинейной аппроксимацией."
                    : "k₁ не идентифицируется: необходимы более ранние точки до выхода на плато."
            };

            var pso = FitOneParameterShape(points, timeScale, totalSumOfSquares, PseudoSecondOrderShape);
            substance.psevdo_2_data = new Psevdo_2_Data
            {
                Qe2 = pso.Qe,
                k2 = pso.ShapeRate / pso.Qe,
                determination = pso.RSquared,
                a = double.NaN,
                b = double.NaN,
                rateConstantIdentifiable = pso.RateConstantIdentifiable,
                fitNote = pso.RateConstantIdentifiable
                    ? "Параметры определены прямой нелинейной аппроксимацией."
                    : "k₂ не идентифицируется в выбранном диапазоне параметров."
            };
        }

        public static double PredictPseudoFirstOrder(double time, double qe, double k1)
        {
            return qe * (1.0 - Math.Exp(-k1 * Math.Max(0.0, time)));
        }

        public static double PredictPseudoSecondOrder(double time, double qe, double k2)
        {
            double safeTime = Math.Max(0.0, time);
            double numerator = k2 * qe * qe * safeTime;
            return numerator / (1.0 + k2 * qe * safeTime);
        }

        private static FitResult FitOneParameterShape(
            IReadOnlyList<SubstanceData> points,
            double timeScale,
            double totalSumOfSquares,
            Func<double, double, double> shape)
        {
            Func<double, double> errorForLogRate = logRate =>
            {
                double shapeRate = Math.Exp(logRate) / timeScale;
                double qe = BestQe(points, shapeRate, shape);
                return SumSquaredErrors(points, qe, shapeRate, shape);
            };

            double fittedLogRate = FindBoundedMinimum(errorForLogRate, MinLogRate, MaxLogRate);
            double fittedShapeRate = Math.Exp(fittedLogRate) / timeScale;
            double fittedQe = BestQe(points, fittedShapeRate, shape);
            double residualSumOfSquares = SumSquaredErrors(points, fittedQe, fittedShapeRate, shape);
            double rSquared = totalSumOfSquares > 0
                ? 1.0 - residualSumOfSquares / totalSumOfSquares
                : double.NaN;

            // Practical profile check: if changing the rate by one order of magnitude
            // barely changes SSE, the available sampling times do not identify that rate.
            const double profileStep = 2.302585092994046;
            double profileTolerance = Math.Max(
                Math.Max(residualSumOfSquares * 0.05, totalSumOfSquares * 1e-6),
                1e-14);
            bool lowerSideIsFlat = errorForLogRate(Math.Max(MinLogRate, fittedLogRate - profileStep))
                <= residualSumOfSquares + profileTolerance;
            bool upperSideIsFlat = errorForLogRate(Math.Min(MaxLogRate, fittedLogRate + profileStep))
                <= residualSumOfSquares + profileTolerance;
            bool identifiable = fittedLogRate > MinLogRate + 1e-4
                && fittedLogRate < MaxLogRate - 1e-4
                && !lowerSideIsFlat
                && !upperSideIsFlat;
            return new FitResult(fittedQe, fittedShapeRate, rSquared, identifiable);
        }

        private static double FindBoundedMinimum(Func<double, double> function, double lower, double upper)
        {
            const double goldenRatioPart = 0.6180339887498948482;
            double left = lower;
            double right = upper;
            double x1 = right - goldenRatioPart * (right - left);
            double x2 = left + goldenRatioPart * (right - left);
            double f1 = function(x1);
            double f2 = function(x2);

            for (int iteration = 0; iteration < 300 && right - left > 1e-10; iteration++)
            {
                if (f1 <= f2)
                {
                    right = x2;
                    x2 = x1;
                    f2 = f1;
                    x1 = right - goldenRatioPart * (right - left);
                    f1 = function(x1);
                }
                else
                {
                    left = x1;
                    x1 = x2;
                    f1 = f2;
                    x2 = left + goldenRatioPart * (right - left);
                    f2 = function(x2);
                }
            }

            return (left + right) / 2.0;
        }

        private static double BestQe(
            IEnumerable<SubstanceData> points,
            double shapeRate,
            Func<double, double, double> shape)
        {
            double numerator = 0.0;
            double denominator = 0.0;
            foreach (var point in points)
            {
                double factor = shape(point.time, shapeRate);
                numerator += point.qt_ml * factor;
                denominator += factor * factor;
            }

            return denominator > 0 ? Math.Max(numerator / denominator, double.Epsilon) : double.Epsilon;
        }

        private static double SumSquaredErrors(
            IEnumerable<SubstanceData> points,
            double qe,
            double shapeRate,
            Func<double, double, double> shape)
        {
            double sum = 0.0;
            foreach (var point in points)
                sum += Square(point.qt_ml - qe * shape(point.time, shapeRate));
            return sum;
        }

        private static double PseudoFirstOrderShape(double time, double k1)
        {
            return 1.0 - Math.Exp(-k1 * Math.Max(0.0, time));
        }

        // h = k2 * qe. For a fixed h, q(t) is linear with respect to qe.
        private static double PseudoSecondOrderShape(double time, double h)
        {
            double safeTime = Math.Max(0.0, time);
            return h * safeTime / (1.0 + h * safeTime);
        }

        private static bool IsFinite(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        private static double Square(double value)
        {
            return value * value;
        }

        private sealed class FitResult
        {
            public FitResult(double qe, double shapeRate, double rSquared, bool rateConstantIdentifiable)
            {
                Qe = qe;
                ShapeRate = shapeRate;
                RSquared = rSquared;
                RateConstantIdentifiable = rateConstantIdentifiable;
            }

            public double Qe { get; }
            public double ShapeRate { get; }
            public double RSquared { get; }
            public bool RateConstantIdentifiable { get; }
        }
    }
}
