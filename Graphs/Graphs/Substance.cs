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
    }

    static public class Databank
    {
        static public List<Substance> substances;
    }
}
