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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace IOL   
{
    public partial class frmCuentasEditar : Form
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();
        public int operacion = 0;

        public frmCuentasEditar()
        {
            InitializeComponent();
        }

        private void frmCobradoresEditar_Load(object sender, EventArgs e)
        {
            switch (operacion)
            {
                case 1: //Agregar

                    tsbEliminar.Visible = false;
                    this.Text = "Agregar Cuenta";

                    txtComitente.Focus();
                    break;
                case 2: //Modificar
                    tsbEliminar.Visible = false;

                    MySqlConnection coneModificar = new MySqlConnection(conexion);
                    MySqlDataAdapter daModificar = new MySqlDataAdapter("Select * from Comitentes Where Comitente = " + txtComitente.Text.Trim(), coneModificar);
                    DataTable dsModificar = new DataTable();
                    daModificar.Fill(dsModificar);
                    if (dsModificar.Rows.Count > 0)
                    {
                        txtComitente.Text = dsModificar.Rows[0]["Comitente"].ToString();
                        txtApellido.Text = dsModificar.Rows[0]["Apellido"].ToString();
                        txtNombres.Text = dsModificar.Rows[0]["Nombres"].ToString();
                        txtTelefonoCelular.Text = dsModificar.Rows[0]["TelefonoCelular"].ToString();
                        txtCorreoElectronico.Text = dsModificar.Rows[0]["correoPrincipal"].ToString();
                        txtCorreoAlternativo.Text = dsModificar.Rows[0]["correoAlternativo"].ToString();

                        this.Text = "Modificar Cuenta";
                        txtComitente.Enabled = false;
                        txtApellido.Focus();
                    }
                    break;
                case 3: //Eliminar
                    tsbEliminar.Visible = false;

                    MySqlConnection coneEliminar = new MySqlConnection(conexion);
                    MySqlDataAdapter daEliminar = new MySqlDataAdapter("Select * from Comitentes Where Comitente = " + txtComitente.Text.Trim(), coneEliminar);
                    DataTable dsEliminar = new DataTable();
                    daEliminar.Fill(dsEliminar);
                    if (dsEliminar.Rows.Count > 0)
                    {
                        txtComitente.Text = dsEliminar.Rows[0]["Comitente"].ToString();
                        txtApellido.Text = dsEliminar.Rows[0]["Apellido"].ToString();
                        txtNombres.Text = dsEliminar.Rows[0]["Nombres"].ToString();
                        txtTelefonoCelular.Text = dsEliminar.Rows[0]["TelefonoCelular"].ToString();
                        txtCorreoElectronico.Text = dsEliminar.Rows[0]["correoPrincipal"].ToString();
                        txtCorreoAlternativo.Text = dsEliminar.Rows[0]["correoAlternativo"].ToString();

                        this.Text = "Eliminar Cuenta";

                        txtComitente.Enabled = false;
                        txtNombres.Enabled = false;
                        txtApellido.Enabled = false;

                        tsbGuardar.Visible = false;
                        tsbEliminar.Visible = true;
                        tsbEliminar.Enabled = true;

                        txtTelefonoCelular.Enabled = false;
                        txtCorreoElectronico.Enabled = false;
                        txtCorreoAlternativo.Enabled = false;
                    }
                    break;
                case 4: //Detalle
                    tsbEliminar.Visible = false;

                    MySqlConnection coneDetalle = new MySqlConnection(conexion);
                    MySqlDataAdapter daDetalle = new MySqlDataAdapter("Select * from Comitentes Where Comitente = " + txtComitente.Text.Trim(), coneDetalle);
                    DataTable dsDetalle = new DataTable();
                    daDetalle.Fill(dsDetalle);
                    if (dsDetalle.Rows.Count > 0)
                    {
                        txtComitente.Text = dsDetalle.Rows[0]["Comitente"].ToString();
                        txtApellido.Text = dsDetalle.Rows[0]["Apellido"].ToString();
                        txtNombres.Text = dsDetalle.Rows[0]["Nombres"].ToString();
                        txtTelefonoCelular.Text = dsDetalle.Rows[0]["TelefonoCelular"].ToString();
                        txtCorreoElectronico.Text = dsDetalle.Rows[0]["correoPrincipal"].ToString();
                        txtCorreoAlternativo.Text = dsDetalle.Rows[0]["correoAlternativo"].ToString();

                        this.Text = "Detalle Cuenta";

                        txtComitente.Enabled = false;
                        txtNombres.Enabled = false;
                        txtApellido.Enabled = false;

                        tsbGuardar.Visible = false;
                        tsbEliminar.Visible = false;

                        tsbCancelar.Visible = true;
                        tsbCancelar.Text = "&Aceptar";
                        tsbCancelar.Image = tsbGuardar.Image;

                        txtTelefonoCelular.Enabled = false;
                        txtCorreoElectronico.Enabled = false;
                        txtCorreoAlternativo.Enabled = false;
                    }
                    break;
            }

        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    SendKeys.Send("{Tab}");
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    SendKeys.Send("{Tab}");
        }

        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    SendKeys.Send("{Tab}");
        }

        private void txtTelefonoCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    SendKeys.Send("{Tab}");
        }

        private void txtCorreoElectronico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    SendKeys.Send("{Tab}");
        }

        private void txtCorreoAlternativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    SendKeys.Send("{Tab}");
        }


        private void tsbGuardar_Click(object sender, EventArgs e)
        {

            Correo CorreoPrincipal = new Correo(txtCorreoElectronico.Text.Trim());
            Correo CorreoAlternativo = new Correo(txtCorreoAlternativo.Text.Trim());
            bool lValidado = true;
            string Mensaje = string.Empty;

            MySqlConnection cone = new MySqlConnection(conexion);
            string sentencia = string.Empty;

            if (operacion == 1)
            {
                sentencia = string.Format("Select Comitente From Comitentes Where Comitente = {0}", txtComitente.Text.Trim());
                MySqlDataAdapter da = new MySqlDataAdapter(sentencia, cone);
                DataTable dt = new DataTable();
                int registros = da.Fill(dt);
                if (registros > 0)
                {
                    Mensaje += String.Format("Cuenta Comitente Existente \r");
                    lValidado = false;
                }
            }
            if (txtApellido.Text.Trim().Length == 0)
            {
                Mensaje += String.Format("Ingrese Apellido \r");
                lValidado = false;
            }

            if (!string.IsNullOrEmpty(txtCorreoElectronico.Text.Trim()))
            {
                if (!CorreoPrincipal.ValidarCorreo())
                {
                    Mensaje += "Correo Principal Incorrecto \r";
                    lValidado = false;
                }
            }

            if (!string.IsNullOrEmpty(txtCorreoAlternativo.Text.Trim()))
            {
                if (!CorreoAlternativo.ValidarCorreo())
                {
                    Mensaje += "Correo Alternativo Incorrecto \r";
                    lValidado = false;
                }
            }

            if (lValidado == false)
            {
                MessageBox.Show(Mensaje, "Solicitud del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (operacion == 1 || operacion == 2)
            {
                if (MessageBox.Show("Datos Correctos ?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }


            cone.Open();
            if (operacion == 1)
            {
                sentencia = string.Format("Insert Into Comitentes (Comitente, Apellido, Nombres, TelefonoCelular, CorreoPrincipal, CorreoAlternativo) Values({0},'{1}','{2}','{3}','{4}','{5}')", txtComitente.Text.Trim(), txtApellido.Text.Trim(), txtNombres.Text.Trim(), txtTelefonoCelular.Text.Trim(), txtCorreoElectronico.Text.Trim(), txtCorreoAlternativo.Text.Trim());
                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                cone.Close();
            }
            else
            {
                sentencia = string.Format("Update Comitentes Set Apellido = '{0}', Nombres = '{1}', TelefonoCelular = '{2}',  CorreoPrincipal = '{3}', CorreoAlternativo = '{4}'  Where Comitente = {5}", txtApellido.Text.Trim(), txtNombres.Text.Trim(), txtTelefonoCelular.Text.Trim(), txtCorreoElectronico.Text.Trim(), txtCorreoAlternativo.Text.Trim(), txtComitente.Text.Trim());
                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                comando.CommandType = CommandType.Text;

                comando.ExecuteNonQuery();
                cone.Close();
            }
            Close();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea realmente dar de baja esta cuenta ?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                MySqlConnection coneEliminar = new MySqlConnection(conexion);
                coneEliminar.Open();

                string sentencia = string.Format("Delete From Comitentes Where Comitente = {0}",txtComitente.Text.Trim());
                MySqlCommand comando = new MySqlCommand(sentencia, coneEliminar);
                comando.CommandType = CommandType.Text;

                comando.ExecuteNonQuery();
                coneEliminar.Close();
                Close();
            }
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

       private void txtApellido_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
        }

        private void txtComitente_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
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

        private void txtNombres_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
        }

        private void txtTelefonoCelular_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
        }

        private void txtCorreoElectronico_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
        }

        private void txtCorreoAlternativo_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
        }
    }
}
