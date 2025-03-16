using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    struct Substance
    {
        public float time;
        public float m_r;
        public float A;
        public float C;
        public float qt_mk;
        public float qt_ml;
        public float proc;
    };
    static class Data
    {
        public static List<Substance> ListOfSubstance;
    }
}
