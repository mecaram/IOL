using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using IOL.EntityFrameWork;
using IOL.Servicios;

namespace IOL
{
    public partial class FeriadosEditar : Form
    {
        private readonly ServiciosFeriado _service = new ServiciosFeriado();

        public int operacion = 0;

        public FeriadosEditar()
        {
            InitializeComponent();
        }

        private void FeriadosEditar_Load(object sender, EventArgs e)
        {
            int id;
            try { id = Convert.ToInt32(txtIdFeriado.Text.Trim()); }
            catch { id = 0; }

            var feriado = _service.GetById(id);

            if (feriado != null)
            {
                txtIdFeriado.Text = feriado.IdFeriado.ToString();
                txtFecha.Text = feriado.Fecha.ToShortDateString();
                txtMotivo.Text = feriado.Motivo.Trim();
            }
            else
            {
                txtIdFeriado.Text = "0";
                txtFecha.Text = DateTime.Now.ToShortDateString();
                txtMotivo.Text = string.Empty;
            }

            switch (operacion)
            {
                case 1: //Agregar
                    tsbEliminar.Visible = false;
                    this.Text = "Agregar Feriado";
                    txtFecha.Focus();
                    break;
                case 2: //Modificar
                    tsbEliminar.Visible = false;
                    txtFecha.Focus();
                    txtFecha.Enabled = false;
                    txtMotivo.Focus();
                    break;
                case 3: //Eliminar
                    tsbEliminar.Visible = false;
                    this.Text = "Eliminar Feriado";
                    txtIdFeriado.Enabled = false;
                    txtFecha.Enabled = false;
                    txtMotivo.Enabled = false;

                    tsbGuardar.Visible = false;
                    tsbEliminar.Visible = true;
                    tsbEliminar.Enabled = true;
                    break;
                case 4: //Detalle
                    tsbEliminar.Visible = false;
                    this.Text = "Detalle Feriado";

                    tsbGuardar.Visible = false;
                    tsbEliminar.Visible = false;

                    tsbCancelar.Visible = true;
                    tsbCancelar.Text = "&Aceptar";
                    tsbCancelar.Image = tsbGuardar.Image;
                    break;
            }
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            bool lValidado = true;
            string Mensaje = string.Empty;

            string sentencia = string.Empty;

            if (txtFecha.Text.Trim().Length == 0)
            {
                Mensaje += String.Format("Ingrese Fecha \r");
                lValidado = false;
            }

            if (txtMotivo.Text.Trim().Length == 0)
            {
                Mensaje += String.Format("Ingrese Motivo \r");
                lValidado = false;
            }

            DateTime? fecha = null;
            try
            { fecha = Convert.ToDateTime(txtFecha.Text.Trim()); }
            catch
            { fecha = null; }

            if (operacion == 1)
            {
                if (fecha != null && fecha < DateTime.Now.Date)
                {
                    Mensaje += String.Format("Fecha anterior a la Actual \r");
                    lValidado = false;
                }

                var feriadoexistente = _service.GetByFecha(fecha.Value); // Date_format(fecha,'%d-%m-%y')
                if (feriadoexistente != null)
                {
                    Mensaje += String.Format("Feriado Existente \r");
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

            var feriado = new EntityFrameWork.Feriados();

            feriado.IdFeriado = Convert.ToInt32(txtIdFeriado.Text);
            feriado.Fecha = (DateTime)fecha;
            feriado.Motivo = txtMotivo.Text.Trim();

            if (_service.Register(feriado))
            {
                MessageBox.Show("Feriado actualizado con éxito", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Feriado actualizado con éxito", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea realmente dar de baja este Feriado ?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                int Id;
                try { Id = Convert.ToInt32(txtIdFeriado.Text); }
                catch { Id = 0; }

                _service.Delete(Id);
                Close();
            }
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtIdFeriado_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
        }

        private void txtFeriado_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;
        }

        private void txtMotivo_Click(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = 80;

        }

        private void txtIdFeriado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
        }

        private void txtFeriado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
        }

        private void txtMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
                e.Handled = false;
            else
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
        }
    }
}
