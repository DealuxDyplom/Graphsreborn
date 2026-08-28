using System;
using System.Linq;

namespace Graphs
{
    public static class IsothermCalculator
    {
        public static void FitCalibration(Graduation graduation, out double k, out double determination)
        {
            if (graduation == null || graduation.data == null || graduation.data.Count < 2)
                throw new ArgumentException("Градуировка должна содержать не менее двух точек.");

            double sumX2 = graduation.data.Sum(point => point.C_mkmol * point.C_mkmol);
            if (sumX2 <= 0) throw new ArgumentException("Концентрации градуировки должны быть положительными.");
            k = graduation.data.Sum(point => point.C_mkmol * point.A) / sumX2;
            double fittedK = k;

            double meanY = graduation.data.Average(point => point.A);
            double residual = graduation.data.Sum(point =>
                Math.Pow(point.A - fittedK * point.C_mkmol, 2));
            double total = graduation.data.Sum(point => Math.Pow(point.A - meanY, 2));
            determination = total > 0 ? 1.0 - residual / total : 1.0;
        }

        public static IsothermPoint Calculate(double initialOpticalDensity,
            double sorbentMassG, double equilibriumOpticalDensity,
            double calibrationK, double solutionVolumeMl, double molarMassGPerMol)
        {
            if (calibrationK <= 0 || solutionVolumeMl <= 0 || molarMassGPerMol <= 0
                || initialOpticalDensity <= 0 || sorbentMassG <= 0
                || equilibriumOpticalDensity < 0
                || equilibriumOpticalDensity >= initialOpticalDensity)
                throw new ArgumentException("Проверьте Aисх, массу и Aравн: требуется 0 ≤ Aравн < Aисх.");

            double initialMassConcentration = initialOpticalDensity / calibrationK;
            double equilibriumMassConcentration = equilibriumOpticalDensity / calibrationK;
            double capacityUgG = (initialMassConcentration - equilibriumMassConcentration)
                * solutionVolumeMl / sorbentMassG;

            return new IsothermPoint
            {
                InitialOpticalDensity = initialOpticalDensity,
                SorbentMassG = sorbentMassG,
                EquilibriumOpticalDensity = equilibriumOpticalDensity,
                InitialConcentrationUmolL = initialMassConcentration / molarMassGPerMol * 1000.0,
                Ce = equilibriumMassConcentration / molarMassGPerMol * 1000.0,
                CapacityUgG = capacityUgG,
                Qe = capacityUgG / molarMassGPerMol,
                RemovalPercent = (initialMassConcentration - equilibriumMassConcentration)
                    / initialMassConcentration * 100.0
            };
        }

        public static void UpdateFromQe(IsothermPoint point, IsothermSeries series, double qe)
        {
            if (point == null || series == null || qe < 0) return;

            bool hasStoredInitialConcentration = point.InitialConcentrationUmolL > 0;
            bool hasOpticalInitialConcentration = point.InitialOpticalDensity > 0
                && series.calibrationK > 0;
            if (point.SorbentMassG <= 0 || series.solutionVolumeMl <= 0
                || series.molarMassGPerMol <= 0
                || (!hasStoredInitialConcentration && !hasOpticalInitialConcentration))
            {
                point.Qe = qe;
                return;
            }

            // C0 is the fixed experimental condition of the vial. Use the
            // stored value as the source of truth while qe is edited. This is
            // important for imported workbooks where C0 and A0 may have been
            // calculated with slightly different calibration coefficients.
            double initialMassConcentration = hasStoredInitialConcentration
                ? point.InitialConcentrationUmolL * series.molarMassGPerMol / 1000.0
                : point.InitialOpticalDensity / series.calibrationK;
            double maximumQe = initialMassConcentration * series.solutionVolumeMl
                / point.SorbentMassG / series.molarMassGPerMol;
            qe = Math.Min(qe, maximumQe);
            double capacityUgG = qe * series.molarMassGPerMol;
            double equilibriumMassConcentration = initialMassConcentration
                - capacityUgG * point.SorbentMassG / series.solutionVolumeMl;
            equilibriumMassConcentration = Math.Max(0.0, equilibriumMassConcentration);

            if (series.calibrationK > 0)
                point.EquilibriumOpticalDensity = equilibriumMassConcentration * series.calibrationK;
            if (point.InitialConcentrationUmolL <= 0)
                point.InitialConcentrationUmolL = initialMassConcentration
                    / series.molarMassGPerMol * 1000.0;
            point.Ce = equilibriumMassConcentration / series.molarMassGPerMol * 1000.0;
            point.CapacityUgG = (initialMassConcentration - equilibriumMassConcentration)
                * series.solutionVolumeMl / point.SorbentMassG;
            point.Qe = point.CapacityUgG / series.molarMassGPerMol;
            point.RemovalPercent = (initialMassConcentration - equilibriumMassConcentration)
                / initialMassConcentration * 100.0;
        }

        public static double GetEditorConcentration(IsothermPoint point, IsothermSeries series)
        {
            if (point == null) return double.NaN;
            if (IsFinite(point.InitialConcentrationUmolL)
                && point.InitialConcentrationUmolL > 0)
                return point.InitialConcentrationUmolL;

            if (series != null && point.InitialOpticalDensity > 0
                && series.calibrationK > 0 && series.molarMassGPerMol > 0)
            {
                point.InitialConcentrationUmolL = point.InitialOpticalDensity
                    / series.calibrationK / series.molarMassGPerMol * 1000.0;
                return point.InitialConcentrationUmolL;
            }

            if (series != null && IsFinite(point.Ce) && IsFinite(point.Qe)
                && point.Ce >= 0 && point.Qe >= 0 && point.SorbentMassG > 0
                && series.solutionVolumeMl > 0)
            {
                point.InitialConcentrationUmolL = point.Ce
                    + point.Qe * point.SorbentMassG * 1000.0 / series.solutionVolumeMl;
                return point.InitialConcentrationUmolL;
            }

            // In legacy files without the experimental inputs Ce is the only
            // available stable horizontal coordinate. UpdateFromQe leaves it
            // unchanged, so dragging remains vertical and reversible.
            return IsFinite(point.Ce) && point.Ce >= 0 ? point.Ce : double.NaN;
        }

        public static IsothermPoint Clone(IsothermPoint source)
        {
            return new IsothermPoint
            {
                InitialOpticalDensity = source.InitialOpticalDensity,
                SorbentMassG = source.SorbentMassG,
                EquilibriumOpticalDensity = source.EquilibriumOpticalDensity,
                InitialConcentrationUmolL = source.InitialConcentrationUmolL,
                Ce = source.Ce,
                CapacityUgG = source.CapacityUgG,
                Qe = source.Qe,
                RemovalPercent = source.RemovalPercent,
                LinearX = source.LinearX,
                LinearY = source.LinearY
            };
        }

        private static bool IsFinite(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }
    }
}
