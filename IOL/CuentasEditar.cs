using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using IOL.Servicios;
using IOL.EntityFrameWork;
using System.Linq.Expressions;

namespace IOL   
{
    public partial class frmCuentasEditar : Form
    {
        private readonly ServiciosComitente _service = new ServiciosComitente();
        public int operacion = 0;

        public frmCuentasEditar()
        {
            InitializeComponent();
        }

        private void frmCobradoresEditar_Load(object sender, EventArgs e)
        {
            EntityFrameWork.Comitentes lstComitente = null;

            int id;
            try { id = Convert.ToInt32(txtComitente.Text); }
            catch { id = 0; }
            if (id > 0)
                lstComitente = _service.GetById(id);

            if (lstComitente != null)
            {
                txtComitente.Text = lstComitente.Comitente.ToString();
                txtApellido.Text = lstComitente.Apellido.ToString();
                txtNombres.Text = lstComitente.Nombres.ToString();
                txtTelefonoCelular.Text = lstComitente.TelefonoCelular.ToString();
                txtCorreoElectronico.Text = lstComitente.CorreoPrincipal.ToString();
                txtCorreoAlternativo.Text = lstComitente.CorreoAlternativo.ToString();
            }

            switch (operacion)
            {
                case 1: //Agregar

                    tsbEliminar.Visible = false;
                    this.Text = "Agregar Cuenta";

                    txtComitente.Focus();
                    break;
                case 2: //Modificar
                    tsbEliminar.Visible = false;

                    this.Text = "Modificar Cuenta";
                    txtComitente.Enabled = false;
                    txtApellido.Focus();
                    break;
                case 3: //Eliminar
                    tsbEliminar.Visible = false;

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
                    break;
                case 4: //Detalle
                    tsbEliminar.Visible = false;

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
            Comitentes comitente = null;

            int id;
            try { id = Convert.ToInt32(txtComitente.Text.Trim()); }
            catch { id = 0; }

            if (operacion == 1)
            {
                comitente = _service.GetById(id);
                if (comitente != null)
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

            comitente.Comitente = id;
            comitente.Apellido = txtApellido.Text.Trim();
            comitente.Nombres = txtNombres.Text.Trim();
            comitente.TelefonoCelular = txtTelefonoCelular.Text.Trim();
            comitente.CorreoPrincipal = txtCorreoElectronico.Text.Trim();
            comitente.CorreoAlternativo = txtCorreoAlternativo.Text.Trim();
            _service.Register(comitente);

            Close();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea realmente dar de baja esta cuenta ?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                int id;
                try { id = Convert.ToInt32(txtComitente.Text.Trim()); }
                catch { id = 0; }
                _service.Delete(id);
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
