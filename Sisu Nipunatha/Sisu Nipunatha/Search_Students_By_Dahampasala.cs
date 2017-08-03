using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisu_Nipunatha
{
    public partial class Search_Students_By_Dahampasala : Form
    {
        public Search_Students_By_Dahampasala()
        {
            InitializeComponent();
        }

        private void Search_Students_By_Dahampasala_Load(object sender, EventArgs e)
        {

        }
        private static Search_Students_By_Dahampasala inst6;

        public static Search_Students_By_Dahampasala getInstance()
        {
            if (inst6 == null || inst6.IsDisposed)
            {
                inst6 = new Search_Students_By_Dahampasala();
                return inst6;
            }
            else
            {
                return inst6;
            }
        }
    }
}
