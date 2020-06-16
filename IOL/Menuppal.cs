using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace IOL
{
    public partial class Menuppal : Form
    {

        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();

        private int childFormNumber = 0;
        const int altura = 80;

        public int comitente = 0;
        public int idsesion = 0;

        public Menuppal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            //childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            //childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Menuppal_Load(object sender, EventArgs e)
        {
        }

        private void Menuppal_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void tsbCopiaDeSeguridad_Click(object sender, EventArgs e)
        {

        }

        private void tsbAcercaDe_Click(object sender, EventArgs e)
        {
            AcercaDe formulario = new AcercaDe();
            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point((this.Width / 2) - (formulario.Width / 2), tbcMenuppal.Location.Y + altura);
            formulario.Show();
        }

        private void tsbCuentas_Click(object sender, EventArgs e)
        {
            frmCuentas formulario = new frmCuentas();
            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point((this.Width / 2) - (formulario.Width / 2), tbcMenuppal.Location.Y + altura);
            formulario.Show();
        }

        private void tsbAcciones_Click(object sender, EventArgs e)
        {
            frmAcciones formulario = new frmAcciones();
            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point((this.Width / 2) - (formulario.Width / 2), tbcMenuppal.Location.Y + altura);
            formulario.comitente = comitente;
            formulario.Show();
        }

        private void tsbRuedas_Click(object sender, EventArgs e)
        {
            Ruedas formulario = new Ruedas();
            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point((this.Width / 2) - (formulario.Width / 2), tbcMenuppal.Location.Y + altura);
            formulario.comitente = comitente;
            formulario.Show();
        }

        private void tsbFeriados_Click(object sender, EventArgs e)
        {
            Feriados formulario = new Feriados();
            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point((this.Width / 2) - (formulario.Width / 2), tbcMenuppal.Location.Y + altura);
            formulario.Show();
        }

        private void tsbCopiaSeguridad_Click(object sender, EventArgs e)
        {

        }

        private void tsbSimulador_Click(object sender, EventArgs e)
        {
            Simulador formulario = new Simulador();
            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point((this.Width / 2) - (formulario.Width / 2), tbcMenuppal.Location.Y + altura);
            formulario.comitente = comitente;
            formulario.Show();
        }

        private void tsbConsultaDeRuedas_Click(object sender, EventArgs e)
        {
            ListadodeRuedas formulario = new ListadodeRuedas();
            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point((this.Width / 2) - (formulario.Width / 2), tbcMenuppal.Location.Y + altura);
            formulario.Show();
        }

        private void tsbConsultaDePaneles_Click(object sender, EventArgs e)
        {
            ListadoDePaneles formulario = new ListadoDePaneles();
            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point((this.Width / 2) - (formulario.Width / 2), tbcMenuppal.Location.Y + altura);
            formulario.Show();
        }

        private void tspConsultasEInformes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbInformeFinal_Click(object sender, EventArgs e)
        {
            InformeFinal formulario = new InformeFinal();
            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point((this.Width / 2) - (formulario.Width / 2), tbcMenuppal.Location.Y + altura);
            formulario.Show();
        }
    }
}
