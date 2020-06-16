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
    public partial class ListadodeRuedas : Form
    {
        public ListadodeRuedas()
        {
            InitializeComponent();
        }

        private void ListadodeRuedas_Load(object sender, EventArgs e)
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

                dgvRuedas.Columns["IdRueda"].Width = 80;
                dgvRuedas.Columns["FechaRueda"].Width = 130;

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

        private void btnExportarAExcel_Click(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            string rueda = dgvRuedas.CurrentRow.Cells["IdRueda"].Value.ToString();
            string sentencia = string.Empty;

            int IdSimulacion = 0;
            try { IdSimulacion = Convert.ToInt32(nudSimulador.Value); }
            catch { IdSimulacion = 0; }

            var wb = new XLWorkbook();
            MySqlConnection conexion = new MySqlConnection(cone);
            if (IdSimulacion > 0)
                sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0} And IdSimulacion = {1}", rueda, IdSimulacion);
            else
                sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0}", rueda);

            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, conexion);
            DataTable ds = new DataTable();
            da.Fill(ds);

            wb.Worksheets.Add(ds, "Hoja1");

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

        private void dgvRuedas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarSimulador();
        }

        private void chk00_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarSimulador();
        }

        private void ActualizarSimulador()
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            string rueda = dgvRuedas.CurrentRow.Cells["IdRueda"].Value.ToString();
            string sentencia = string.Empty;

            int IdSimulacion = 0;
            try { IdSimulacion = Convert.ToInt32(nudSimulador.Value); }
            catch { IdSimulacion = 0; }

            using (MySqlConnection coneDetalle = new MySqlConnection(cone))
            {
                if (IdSimulacion > 0)
                    sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0} And IdSimulacion = {1}", rueda, IdSimulacion);
                else
                    sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0}", rueda);

                MySqlDataAdapter da = new MySqlDataAdapter(sentencia, coneDetalle);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    dgvSimuladores.DataSource = ds;

                    DataGridViewCellStyle EstiloEncabezadoColumna = new DataGridViewCellStyle();

                    EstiloEncabezadoColumna.BackColor = Color.Green;
                    EstiloEncabezadoColumna.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                    dgvSimuladores.ColumnHeadersDefaultCellStyle = EstiloEncabezadoColumna;

                    DataGridViewCellStyle EstiloColumnas = new DataGridViewCellStyle();
                    EstiloColumnas.BackColor = Color.AliceBlue;
                    EstiloColumnas.Font = new Font("Times New Roman", 12);
                    dgvSimuladores.RowsDefaultCellStyle = EstiloColumnas;

                    dgvSimuladores.Columns["Simbolo"].HeaderText = "Símbolo";
                    dgvSimuladores.Columns["IdSimulacion"].HeaderText = "Nro.";
                    dgvSimuladores.Columns["FechaCompra"].HeaderText = "Fecha Compra";
                    dgvSimuladores.Columns["Cantidad"].HeaderText = "Cant.";
                    dgvSimuladores.Columns["PrecioCompra"].HeaderText = "Precio Compra";
                    dgvSimuladores.Columns["ImporteCompra"].HeaderText = "Importe";
                    dgvSimuladores.Columns["UltimoPrecio"].HeaderText = "Ultimo Precio";
                    dgvSimuladores.Columns["FechaUltimoPrecio"].HeaderText = "Fecha Precio";
                    dgvSimuladores.Columns["VariacionEnPesos"].HeaderText = "Variación$";
                    dgvSimuladores.Columns["VariacionEnPorcentajes"].HeaderText = "Variación%";

                    dgvSimuladores.Columns["Simbolo"].Width = 100;
                    dgvSimuladores.Columns["IdSimulacion"].Width = 60;
                    dgvSimuladores.Columns["FechaCompra"].Width = 120;
                    dgvSimuladores.Columns["Cantidad"].Width = 75;
                    dgvSimuladores.Columns["PrecioCompra"].Width = 120;
                    dgvSimuladores.Columns["ImporteCompra"].Width = 90;
                    dgvSimuladores.Columns["UltimoPrecio"].Width = 120;
                    dgvSimuladores.Columns["FechaUltimoPrecio"].Width = 120;
                    dgvSimuladores.Columns["VariacionEnPesos"].Width = 90;
                    dgvSimuladores.Columns["VariacionEnPorcentajes"].Width = 100;

                    dgvSimuladores.Columns["Simbolo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["IdSimulacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["FechaCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["ImporteCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["UltimoPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["FechaUltimoPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["VariacionEnPesos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["VariacionEnPorcentajes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvSimuladores.Columns["Cantidad"].DefaultCellStyle.Format = "#00";
                    dgvSimuladores.Columns["PrecioCompra"].DefaultCellStyle.Format = "$ #00.00";
                    dgvSimuladores.Columns["ImporteCompra"].DefaultCellStyle.Format = "$ #00.00";
                    dgvSimuladores.Columns["UltimoPrecio"].DefaultCellStyle.Format = "$ #00.00";
                    dgvSimuladores.Columns["VariacionEnPesos"].DefaultCellStyle.Format = "$ #00.00";
                    dgvSimuladores.Columns["VariacionEnPorcentajes"].DefaultCellStyle.Format = "#00.00";

                    dgvSimuladores.Columns["Simbolo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["IdSimulacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["FechaCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["PrecioCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["ImporteCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["UltimoPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["FechaUltimoPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["VariacionEnPesos"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["VariacionEnPorcentajes"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvSimuladores.RefreshEdit();
                    dgvSimuladores.Enabled = true;
                }
                else
                {
                    dgvSimuladores.DataSource = null;
                    dgvSimuladores.RefreshEdit();
                }
            }
        }

        private void dgvSimuladores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSimuladores.Columns["IdRuedaActual"].Visible = false;
            dgvSimuladores.Columns["IdPanel"].Visible = false;
            dgvSimuladores.Columns["PrecioVenta"].Visible = false;
            dgvSimuladores.Columns["ImporteVenta"].Visible = false;
            dgvSimuladores.Columns["IdRuedaDetalle"].Visible = false;
            dgvSimuladores.Columns["IdRuedaCompra"].Visible = false;
            dgvSimuladores.Columns["IdRuedaVenta"].Visible = false;
            dgvSimuladores.Columns["FechaVenta"].Visible = false;
            dgvSimuladores.Columns["Estado"].Visible = false;
            dgvSimuladores.Columns["PorcComisionIOL"].Visible = false;
            dgvSimuladores.Columns["ImporteComisionIOL"].Visible = false;
        }

        private void nudSimulador_ValueChanged(object sender, EventArgs e)
        {
            ActualizarSimulador();
        }
    }
}
