using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace IOL
{
    public partial class Buscar : Form
    {

        public Buscar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

        }

        private void rctBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboBuscar_SelectedValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }
    }
}
