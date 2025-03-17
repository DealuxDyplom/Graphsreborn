using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    struct SubstanceData
    {
        public double time;
        public double concentration;
        public double m_r;
        public double A;
        public double A_src;
        public double C_mkmol_l_src;
        public double C_mkmol_l;
        public double Q_mr;
        public double Q_ml;
        public double proc;
    }
    struct Substance
    {
        public string name;
        public List<SubstanceData> data;
    };
    static class DataBank
    {
        public static List<Substance> ListOfSubstance;
    }
}
