using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using ClosedXML.Excel;

namespace IOL
{
    public partial class InformeFinal : Form
    {
        public InformeFinal()
        {
            InitializeComponent();
        }

        private void btnExportarAExcel_Click(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            string rueda = dgvRuedas.CurrentRow.Cells["IdRueda"].Value.ToString();
            string sentencia = string.Empty;

            var wb = new XLWorkbook();
            using (var conexion = new MySqlConnection(cone))
            {
                sentencia = string.Format("Select * From InformeFinal Where IdRueda = {0} ", rueda);

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
        }

        private void dgvRuedas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarSimulador();
        }

        private void ActualizarSimulador()
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            string sentencia = string.Empty;
            string rueda = dgvRuedas.CurrentRow.Cells["IdRueda"].Value.ToString();

            using (MySqlConnection coneDetalle = new MySqlConnection(cone))
            {
                sentencia = string.Format("Select * From InformeFinal Where IdRueda = {0}", rueda);

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

                    dgvSimuladores.Columns["Variacion1Diaria"].HeaderText = "VarD1";
                    dgvSimuladores.Columns["Variacion2Diaria"].HeaderText = "VarD2";
                    dgvSimuladores.Columns["Variacion3Diaria"].HeaderText = "VarD3";
                    dgvSimuladores.Columns["Variacion4Diaria"].HeaderText = "VarD4";
                    dgvSimuladores.Columns["Variacion5Diaria"].HeaderText = "VarD5";
                    dgvSimuladores.Columns["Variacion6Diaria"].HeaderText = "VarD6";
                    dgvSimuladores.Columns["Variacion7Diaria"].HeaderText = "VarD7";
                    dgvSimuladores.Columns["Variacion8Diaria"].HeaderText = "VarD8";
                    dgvSimuladores.Columns["Variacion9Diaria"].HeaderText = "VarD9";
                    dgvSimuladores.Columns["Variacion10Diaria"].HeaderText = "VarD10";
                    dgvSimuladores.Columns["MejorVariacionDiaria"].HeaderText = "VarMD";
                    dgvSimuladores.Columns["MejorVariacionDiariaSimulador"].HeaderText = "VarMD#";
                    dgvSimuladores.Columns["VariacionSemanal"].HeaderText = "VarMS";
                    dgvSimuladores.Columns["MejorVariacionSemanalSimulador"].HeaderText = "VarMS#";

                    dgvSimuladores.Columns["Variacion1Diaria"].Width = 100;
                    dgvSimuladores.Columns["Variacion2Diaria"].Width = 100;
                    dgvSimuladores.Columns["Variacion3Diaria"].Width = 100;
                    dgvSimuladores.Columns["Variacion4Diaria"].Width = 100;
                    dgvSimuladores.Columns["Variacion5Diaria"].Width = 100;
                    dgvSimuladores.Columns["Variacion6Diaria"].Width = 100;
                    dgvSimuladores.Columns["Variacion7Diaria"].Width = 100;
                    dgvSimuladores.Columns["Variacion8Diaria"].Width = 100;
                    dgvSimuladores.Columns["Variacion9Diaria"].Width = 100;
                    dgvSimuladores.Columns["Variacion10Diaria"].Width = 100;
                    dgvSimuladores.Columns["MejorVariacionDiaria"].Width = 100;
                    dgvSimuladores.Columns["MejorVariacionDiariaSimulador"].Width = 100;
                    dgvSimuladores.Columns["VariacionSemanal"].Width = 100;
                    dgvSimuladores.Columns["MejorVariacionSemanalSimulador"].Width = 100;

                    dgvSimuladores.Columns["Variacion1Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion2Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion3Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion4Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion5Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion6Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion7Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion8Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion9Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion10Diaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["MejorVariacionDiaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["MejorVariacionDiariaSimulador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["VariacionSemanal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["MejorVariacionSemanalSimulador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvSimuladores.Columns["Variacion1Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["Variacion2Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["Variacion3Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["Variacion4Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["Variacion5Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["Variacion6Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["Variacion7Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["Variacion8Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["Variacion9Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["Variacion10Diaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["MejorVariacionDiaria"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["MejorVariacionDiariaSimulador"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["VariacionSemanal"].DefaultCellStyle.Format = "#00.00 %";
                    dgvSimuladores.Columns["MejorVariacionSemanalSimulador"].DefaultCellStyle.Format = "00";

                    dgvSimuladores.Columns["Variacion1Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion2Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion3Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion4Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion5Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion6Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion7Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion8Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion9Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["Variacion10Diaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["MejorVariacionDiaria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["MejorVariacionDiariaSimulador"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["VariacionSemanal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSimuladores.Columns["MejorVariacionSemanalSimulador"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


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

        private void InformeFinal_Load(object sender, EventArgs e)
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
    }
}
