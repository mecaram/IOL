using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;

namespace IOL
{
    public partial class Copia : Form
    {
        FolderBrowserDialog Carpeta = new FolderBrowserDialog();

        public Copia()
        {
            InitializeComponent();
        }

        private void btnSeleccionarCarpeta_Click(object sender, EventArgs e)
        {
            if (Carpeta.ShowDialog() == DialogResult.OK)
            {
                rctCarpetaDestino.Text = Carpeta.SelectedPath;
                btnRealizarCopiaDeSeguridad.Enabled = true;
            }
        }

        private void Copia_Load(object sender, EventArgs e)
        {
            btnRealizarCopiaDeSeguridad.Enabled = false;
        }

        private void btnRealizarCopiaDeSeguridad_Click(object sender, EventArgs e)
        {
            btnRealizarCopiaDeSeguridad.Enabled = false;

            bool copiar = false;
            string carpeta = rctCarpetaDestino.Text.Trim();
            string archivo = string.Format("CopiaDeSeguridad__{0}-{1}-{2}__{3}{4}{5}.bak", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            string archivocompleto = carpeta + "\\" + archivo;

            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@carpeta))
            {
                if (File.Exists(@archivocompleto))
                {
                    if (MessageBox.Show(@"Ya habia un respaldo anteriormente ¿desea remplazarlo?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(@archivocompleto);
                        copiar = true;
                    }
                }
                else
                    copiar = true;
            }
            else
                MessageBox.Show("Seleccione Carpeta", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            if (copiar)
            {
                try
                {
                    MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
                    conexion.Open();

                    string datos = string.Format("backup database {0} to disk ='{1}' with init,stats=10", ConfigurationManager.AppSettings["Conexion"].ToString(), archivocompleto);
                    MySqlCommand comando = new MySqlCommand(@datos, conexion);
                    comando.ExecuteNonQuery();

                    conexion.Close();
                    MessageBox.Show("La Copia de Seguridad de la base de datos fue realizada satisfactoriamente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string mensaje = " Error en la conexion, intente mas tarde...";
                    mensaje += "\n Mensaje: " + ex.Message;
                    mensaje += "\n Error nro.:" + ex.ErrorCode;

                    MessageBox.Show(mensaje, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
