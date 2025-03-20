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
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            Databank.substances = new List<Substance>();
        }

        #region [ Kinetics ]
        private void button_AddSubstance_Click(object sender, EventArgs e)
        {
            AddSubstance addSubstanceForm = new AddSubstance();
            addSubstanceForm.ShowDialog();
            MessageBox.Show("Имя добавленного раствора: " + Databank.substances[0].name);
        }

        #endregion
    }
}
