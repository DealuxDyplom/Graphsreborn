using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Substance
    {
        public string name;
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

    static public class Databank
    {
        static public List<Substance> substances;
        static public List<Graduation> graduations;
    }
}
