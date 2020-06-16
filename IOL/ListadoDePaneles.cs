using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using ClosedXML.Excel;

namespace IOL
{
    public partial class ListadoDePaneles : Form
    {
        public ListadoDePaneles()
        {
            InitializeComponent();
        }

        private void ListadoDePaneles_Load(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            string sentencia = string.Format("Select IdRueda, FechaRueda From Ruedas Order By FechaRueda Desc");
            MySqlConnection coneRuedas = new MySqlConnection(cone);
            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, coneRuedas);
            DataTable ds = new DataTable();
            da.Fill(ds);

            if (ds.Rows.Count > 0)
            {
                dgvRuedas.DataSource = ds;

                DataGridViewCellStyle EstiloEncabezadoColumna = new DataGridViewCellStyle();

                EstiloEncabezadoColumna.BackColor = Color.Green;
                EstiloEncabezadoColumna.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                dgvRuedas.ColumnHeadersDefaultCellStyle = EstiloEncabezadoColumna;

                DataGridViewCellStyle EstiloColumnas = new DataGridViewCellStyle();
                EstiloColumnas.BackColor = Color.AliceBlue;
                EstiloColumnas.Font = new Font("Times New Roman", 12);
                dgvRuedas.RowsDefaultCellStyle = EstiloColumnas;

                dgvRuedas.Columns["IdRueda"].HeaderText = "Id.Rueda";
                dgvRuedas.Columns["FechaRueda"].HeaderText = "Fecha";

                dgvRuedas.Columns["IdRueda"].Width = 100;
                dgvRuedas.Columns["FechaRueda"].Width = 110;

                dgvRuedas.Columns["IdRueda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRuedas.Columns["FechaRueda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvRuedas.Columns["IdRueda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRuedas.Columns["FechaRueda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvRuedas.RefreshEdit();
                dgvRuedas.Enabled = true;
            }
            else
            {
                dgvRuedas.DataSource = null;
                dgvRuedas.RefreshEdit();
            }
        }

        private void dgvRuedas_SelectionChanged(object sender, EventArgs e)
        {
            string rueda = dgvRuedas.CurrentRow.Cells["IdRueda"].Value.ToString();

            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            string sentencia = string.Format("Select IdRueda, Simbolo, Fecha, UltimoPrecio, Volumen, CantidadDeOperaciones From PanelPrincipal Where IdRueda = {0} Order By Simbolo, Fecha", rueda);
            MySqlConnection coneRuedas = new MySqlConnection(cone);
            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, coneRuedas);
            DataTable ds = new DataTable();
            da.Fill(ds);

            if (ds.Rows.Count > 0)
            {
                dgvPaneles.DataSource = ds;

                DataGridViewCellStyle EstiloEncabezadoColumna = new DataGridViewCellStyle();

                EstiloEncabezadoColumna.BackColor = Color.Green;
                EstiloEncabezadoColumna.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                dgvPaneles.ColumnHeadersDefaultCellStyle = EstiloEncabezadoColumna;

                DataGridViewCellStyle EstiloColumnas = new DataGridViewCellStyle();
                EstiloColumnas.BackColor = Color.AliceBlue;
                EstiloColumnas.Font = new Font("Times New Roman", 12);
                dgvPaneles.RowsDefaultCellStyle = EstiloColumnas;

                dgvPaneles.Columns["IdRueda"].HeaderText = "Id.Rueda";
                dgvPaneles.Columns["Fecha"].HeaderText = "Fecha";
                dgvPaneles.Columns["Simbolo"].HeaderText = "Simbolo";
                dgvPaneles.Columns["UltimoPrecio"].HeaderText = "Precio";
                dgvPaneles.Columns["Volumen"].HeaderText = "Volumen";
                dgvPaneles.Columns["CantidadDeOperaciones"].HeaderText = "Operaciones";

                dgvPaneles.Columns["IdRueda"].Width = 80;
                dgvPaneles.Columns["Fecha"].Width = 180;
                dgvPaneles.Columns["Simbolo"].Width = 80;
                dgvPaneles.Columns["UltimoPrecio"].Width = 130;
                dgvPaneles.Columns["Volumen"].Width = 110;
                dgvPaneles.Columns["CantidadDeOperaciones"].Width = 110;

                dgvPaneles.Columns["IdRueda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["Simbolo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["UltimoPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["Volumen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["CantidadDeOperaciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvPaneles.Columns["IdRueda"].DefaultCellStyle.Format = "0000";
                dgvPaneles.Columns["UltimoPrecio"].DefaultCellStyle.Format = "$ #00.00";

                dgvPaneles.Columns["IdRueda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["Simbolo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["UltimoPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["Volumen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPaneles.Columns["CantidadDeOperaciones"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvPaneles.RefreshEdit();
                dgvPaneles.Enabled = true;
            }
            else
            {
                dgvPaneles.DataSource = null;
                dgvPaneles.RefreshEdit();
            }
        }

        private void btnExportarAExcel_Click(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            var wb = new XLWorkbook();
            using (var conexion = new MySqlConnection(cone))
            {
                string rueda = dgvRuedas.CurrentRow.Cells["IdRueda"].Value.ToString();
                string sentencia = string.Format("Select IdRueda, IdPanel, Simbolo, Fecha, UltimoPrecio, VariacionPorcentual, Apertura, Maximo, Minimo, UltimoCierre, Volumen, CantidadDeOperaciones, PuntaCompradoraP, PuntaVendedoraP, PuntaCompradoraC, PuntaVendedoraC From PanelPrincipal Where IdRueda = {0} Order By Simbolo, Fecha", rueda);
                MySqlDataAdapter da = new MySqlDataAdapter(sentencia, conexion);
                DataTable ds = new DataTable();
                da.Fill(ds);

                wb.Worksheets.Add(ds,"Hoja1");

                SaveFileDialog sfdGuardar = new SaveFileDialog();
                sfdGuardar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                sfdGuardar.Title = "Guarde el archivo de Excel";
                sfdGuardar.CheckFileExists = false;
                sfdGuardar.CheckPathExists = true;
                sfdGuardar.DefaultExt = "txt";
                sfdGuardar.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                sfdGuardar.FilterIndex = 1;
                sfdGuardar.RestoreDirectory = true;
                if (sfdGuardar.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(sfdGuardar.FileName);
                    MessageBox.Show("El archivo " + sfdGuardar.FileName + " se almacenó correctamente", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvPaneles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPaneles.Columns["IdRueda"].Visible = false;

        }
    }
}
