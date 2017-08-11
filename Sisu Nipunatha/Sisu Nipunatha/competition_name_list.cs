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
    public partial class competition_name_list : Form
    {
        public competition_name_list()
        {
            InitializeComponent();
        }
        private static competition_name_list inst9;

        public static competition_name_list getInstance()
        {
            if (inst9 == null || inst9.IsDisposed)
            {
                inst9 = new competition_name_list();
                return inst9;
            }
            else
            {
                return inst9;
            }
        }

        private void competition_name_list_Load(object sender, EventArgs e)
        {

        }
        
    }
}
