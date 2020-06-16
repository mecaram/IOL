using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace IOL
{
    public partial class InicioSesion : Form
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();
        int reintentos = 0;
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            bool lValidado = true;
            string Mensaje = string.Empty;
            if (string.IsNullOrEmpty(txtComitente.Text.Trim()))
            {
                Mensaje += String.Format("Ingrese Cuenta Comitente \r");
                lValidado = false;
            }

            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
            {
                Mensaje += "Ingrese Usuario \r";
                lValidado = false;
            }

            if (string.IsNullOrEmpty(txtClave.Text.Trim()))
            {
                Mensaje += "Ingrese Clave \r";
                lValidado = false;
            }
            if (lValidado == false)
            {
                MessageBox.Show(Mensaje, "Solicitud del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int comitente = 0;
            int idsesion = 0;
            try { comitente = Convert.ToInt32(txtComitente.Text.Trim()); }
            catch { comitente = 0; }

            string usuario;
            try { usuario = txtUsuario.Text.Trim(); }
            catch { usuario = string.Empty; }

            string contrasenia;
            try { contrasenia = txtClave.Text.Trim(); }
            catch { contrasenia = string.Empty; }

            MySqlConnection cone = new MySqlConnection(conexion);
            string sentencia = string.Format("Select Count(Comitente) as Cuentas From Comitentes Where Comitente = {0}", comitente);
            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, cone);
            DataTable dt = new DataTable();
            int registros = da.Fill(dt);
            if (Convert.ToInt32(dt.Rows[0]["Cuentas"]) > 0)
            {
                Token permisoIOL = new Token(usuario, contrasenia);
                if (permisoIOL.ObtenerToken() == true)
                {
                    MySqlConnection conexionModificar = null;
                    try
                    {
                        conexionModificar = new MySqlConnection(conexion);
                        conexionModificar.Open();

                        string sentenciaModificar = string.Format("Update Comitentes Set Usuario = '{1}', Contrasenia = AES_ENCRYPT('{2}','Miguel2020') Where Comitente = {0}", comitente, usuario, contrasenia);
                        using (var comandoModificar = new MySqlCommand(sentenciaModificar, conexionModificar))
                        {
                            comandoModificar.CommandType = CommandType.Text;
                            int nRegistros = comandoModificar.ExecuteNonQuery();
                            conexionModificar.Close();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                        conexionModificar.Close();
                    }
                    finally
                    {
                        conexionModificar.Close();
                    }

                    MySqlConnection conexionSesion = null;
                    try
                    {
                        conexionSesion = new MySqlConnection(conexion);
                        conexionSesion.Open();

                        using (var comandoSesion = new MySqlCommand("ObtenerIdSesion", conexionSesion))
                        {
                            comandoSesion.Parameters.AddWithValue("NroComitente", comitente);
                            comandoSesion.Parameters.AddWithValue("idsesion", MySqlDbType.Int32);
                            comandoSesion.Parameters["idsesion"].Direction = ParameterDirection.ReturnValue;
                            comandoSesion.CommandType = CommandType.StoredProcedure;
                            int nRegistros = comandoSesion.ExecuteNonQuery();
                            idsesion = (int)comandoSesion.Parameters["idsesion"].Value;
                            conexionSesion.Close();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                        conexionSesion.Close();
                    }
                    finally
                    {
                        conexionSesion.Close();
                    }

                    MessageBox.Show("Bienvenido " + usuario + " a nuestro simulador y...\r\nBuenas Inversiones", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menuppal menu = new Menuppal();
                    menu.Location = Screen.PrimaryScreen.WorkingArea.Location;
                    menu.Size = Screen.PrimaryScreen.WorkingArea.Size;
                    menu.comitente = comitente;
                    menu.idsesion = idsesion;
                    menu.Show();
                    menu.FormClosed += Logout;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No tuvo éxito la conexion a IOL, verifique Usuario, Clave y que la API de IOL este Activa...Intente mas tarde", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
            else
            {
                if (reintentos <= 3)
                {
                    MessageBox.Show("Comitente, Usuario y Clave no coinciden...Reintente", "Solicitud del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    reintentos++;
                }
                else
                {
                    MessageBox.Show("Esta Aplicacion se Cerrará...Demasiados Intentos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
        }


        private void txtUsuario_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 40;
        }

        private void txtClave_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 40;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
        }

        private void txtComitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtComitente_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
        }

        private void btnVerClave_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtClave.Text.Trim(), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
           Application.Exit();
        }

        private void btnAltaComitente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea dar de Alta esta Cuenta ?", "Pregunta del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool lValidado = true;
                string Mensaje = string.Empty;
                if (string.IsNullOrEmpty(txtComitente.Text.Trim()))
                {
                    Mensaje += String.Format("Ingrese Cuenta Comitente \r");
                    lValidado = false;
                }

                if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
                {
                    Mensaje += "Ingrese Usuario \r";
                    lValidado = false;
                }

                if (string.IsNullOrEmpty(txtClave.Text.Trim()))
                {
                    Mensaje += "Ingrese Clave \r";
                    lValidado = false;
                }
                if (lValidado == false)
                {
                    MessageBox.Show(Mensaje, "Solicitud del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                int comitente;
                try { comitente = Convert.ToInt32(txtComitente.Text.Trim()); }
                catch { comitente = 0; }

                string usuario;
                try { usuario = txtUsuario.Text.Trim(); }
                catch { usuario = string.Empty; }

                string contrasenia;
                try { contrasenia = txtClave.Text.Trim(); }
                catch { contrasenia = string.Empty; }

                MySqlConnection cone = new MySqlConnection(conexion);
                string sentencia = string.Format("Select Count(Comitente) as Cuentas From Comitentes Where Comitente = {0}", comitente);
                MySqlDataAdapter da = new MySqlDataAdapter(sentencia, cone);
                DataTable dt = new DataTable();
                int registros = da.Fill(dt);
                if (Convert.ToInt32(dt.Rows[0]["Cuentas"]) > 0)
                {
                    MessageBox.Show("Cuenta Comitente Existente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MySqlConnection conexionInsertar = null;
                    try
                    {
                        conexionInsertar = new MySqlConnection(conexion);
                        conexionInsertar.Open();

                        string sentenciaInsertar = string.Format("Insert Into Comitentes(Comitente,Usuario,Contrasenia) Values({0},'{1}',AES_ENCRYPT('{2}','Miguel2020'))", comitente, usuario, contrasenia);
                        using (var comandoInsertar = new MySqlCommand(sentenciaInsertar, conexionInsertar))
                        {
                            comandoInsertar.CommandType = CommandType.Text;
                            int nRegistros = comandoInsertar.ExecuteNonQuery();
                            if (nRegistros > 0)
                            {
                                MessageBox.Show("Cuenta Comitente agregada con éxito", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error al agregar la cuenta...Intente mas Tarde", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            conexionInsertar.Close();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error.Message);
                        conexionInsertar.Close();
                    }
                    finally
                    {
                        conexionInsertar.Close();
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

