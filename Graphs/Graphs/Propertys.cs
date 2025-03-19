using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs
{
    public partial class Propertys: Form
    {
        public Propertys(Substance substance)
        {
            InitializeComponent();
            for (int i = 0; i < substance.data.Count; i++)
            {
                string[] row = {substance.data[i].concentration.ToString(), substance.data[i].A_src.ToString(), 
                    substance.data[i].m_r.ToString(), substance.data[i].A.ToString(), 
                    substance.data[i].C_mkmol_l_src.ToString(), substance.data[i].C_mkmol_l.ToString(), 
                    substance.data[i].Q_ml.ToString()};
                dataGridView.Rows.Add(row);
            }
        }

        public Propertys()
        {
            InitializeComponent();
        }
    }
}
