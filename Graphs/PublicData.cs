using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class ExprData_Row
    {
        public double time { get; set; }
        public double m_r { get; set; }
        public double A { get; set; }
    }

    public class Graduation_Row
    {
        public double C_mkmol { get; set; }
        public double A { get; set; }
    }

    public class Data_Row
    {
        public double time { get; set; }
        public double m_r { get; set; }
        public double A { get; set; }
        public double C_mkmol { get; set; }
        public double qt_mr { get; set; }
        public double qt_ml { get; set; }
        public double proc { get; set; }
        public double qe_qt { get; set; }
        public double log_qe_qt { get; set; }
        public double t_qt { get; set; }
    }

    public class Psevdo_1_Data
    {
        public double a;
        public double b;
        public double determination;
        public double Qe1;
        public double k1;
        public bool rateConstantIdentifiable;
        public string fitNote;
    }

    public class Psevdo_2_Data
    {
        public double a;
        public double b;
        public double determination;
        public double Qe2;
        public double k2;
        public bool rateConstantIdentifiable;
        public string fitNote;
    }
    public class Substance
    {
        public string name;
        public double OpticDens;
        public double k;
        public double solutionVolumeMl;
        public double molarMassGPerMol;
        public Psevdo_1_Data psevdo_1_data;
        public Psevdo_2_Data psevdo_2_data;
        public List<SubstanceData> data;
    }

    public class SubstanceData
    {
        public double time;
        public double m_r;
        public double A;
        public double C_mkmol;
        public double qt_mr;
        public double qt_ml;
        public double proc;

        public double Qe1;
        public double qe_qt;
        public double log_qe_qt;
        public double t_qt;
    }

    public class Graduation
    {
        public string name;
        public List<GraduationData> data;
    }

    public class GraduationData
    {
        public double C_mkmol;
        public double A;
    }

    public class IsothermPoint
    {
        public double Ce { get; set; }
        public double Qe { get; set; }
        public double LinearX { get; set; }
        public double LinearY { get; set; }
    }

    public class LangmuirResult
    {
        public double a;
        public double b;
        public double qMax;
        public double kL;
        public double determination;
        public bool isPhysicallyValid;
        public string fitNote;
    }

    public class IsothermSeries
    {
        public string name;
        public double temperatureC;
        public string concentrationUnit = "мкмоль/л";
        public string capacityUnit = "мкмоль/г";
        public List<IsothermPoint> data;
        public LangmuirResult langmuir;
    }

    static public class Databank
    {
        static public List<Substance> substances;
        static public List<Graduation> graduations;
        static public List<IsothermSeries> isotherms;
    }
}
