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
    public partial class FeriadosEditar : Form
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();
        public int operacion = 0;

        public FeriadosEditar()
        {
            InitializeComponent();
        }

        private void FeriadosEditar_Load(object sender, EventArgs e)
        {
            switch (operacion)
            {
                case 1: //Agregar

                    tsbEliminar.Visible = false;
                    this.Text = "Agregar Feriado";

                    txtFecha.Focus();
                    break;
                case 2: //Modificar
                    tsbEliminar.Visible = false;

                    MySqlConnection coneModificar = new MySqlConnection(conexion);
                    MySqlDataAdapter daModificar = new MySqlDataAdapter("Select * from Feriados Where IdFeriado = " + txtIdFeriado.Text.Trim(), coneModificar);
                    DataTable dsModificar = new DataTable();
                    daModificar.Fill(dsModificar);
                    if (dsModificar.Rows.Count > 0)
                    {
                        txtIdFeriado.Text = dsModificar.Rows[0]["IdFeriado"].ToString();
                        txtFecha.Text = dsModificar.Rows[0]["Fecha"].ToString();
                        txtMotivo.Text = dsModificar.Rows[0]["Motivo"].ToString();

                        this.Text = "Modificar Feriado";
                        txtFecha.Focus();
                    }
                    txtFecha.Enabled = false;
                    txtMotivo.Focus();
                    break;
                case 3: //Eliminar
                    tsbEliminar.Visible = false;

                    MySqlConnection coneEliminar = new MySqlConnection(conexion);
                    MySqlDataAdapter daEliminar = new MySqlDataAdapter("Select * from Feriados Where IdFeriado = " + txtIdFeriado.Text.Trim(), coneEliminar);
                    DataTable dsEliminar = new DataTable();
                    daEliminar.Fill(dsEliminar);
                    if (dsEliminar.Rows.Count > 0)
                    {
                        txtIdFeriado.Text = dsEliminar.Rows[0]["IdFeriado"].ToString();
                        txtFecha.Text = dsEliminar.Rows[0]["Fecha"].ToString();
                        txtMotivo.Text = dsEliminar.Rows[0]["Motivo"].ToString();

                        this.Text = "Eliminar Feriado";

                        txtIdFeriado.Enabled = false;
                        txtFecha.Enabled = false;
                        txtMotivo.Enabled = false;

                        tsbGuardar.Visible = false;
                        tsbEliminar.Visible = true;
                        tsbEliminar.Enabled = true;
                    }
                    break;
                case 4: //Detalle
                    tsbEliminar.Visible = false;

                    MySqlConnection coneDetalle = new MySqlConnection(conexion);
                    MySqlDataAdapter daDetalle = new MySqlDataAdapter("Select * from Feriados Where IdFeriado = " + txtIdFeriado.Text.Trim(), coneDetalle);
                    DataTable dsDetalle = new DataTable();
                    daDetalle.Fill(dsDetalle);
                    if (dsDetalle.Rows.Count > 0)
                    {
                        txtIdFeriado.Text = dsDetalle.Rows[0]["IdFeriado"].ToString();
                        txtFecha.Text = dsDetalle.Rows[0]["Fecha"].ToString();
                        txtMotivo.Text = dsDetalle.Rows[0]["Motivo"].ToString();

                        this.Text = "Detalle Feriado";

                        tsbGuardar.Visible = false;
                        tsbEliminar.Visible = false;

                        tsbCancelar.Visible = true;
                        tsbCancelar.Text = "&Aceptar";
                        tsbCancelar.Image = tsbGuardar.Image;
                    }
                    break;
            }
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            bool lValidado = true;
            string Mensaje = string.Empty;

            MySqlConnection cone = new MySqlConnection(conexion);
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

                sentencia = string.Format("Select IdFeriado From Feriados Where Date_format(fecha,'%d-%m-%y') = str_to_date('{0}','%d/%m/%y')", fecha.Value.ToString("dd/MM/yy"));
                MySqlDataAdapter da = new MySqlDataAdapter(sentencia, cone);
                DataTable dt = new DataTable();
                int registros = da.Fill(dt);
                if (registros > 0)
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


            cone.Open();
            if (operacion == 1)
            {
                sentencia = string.Format("Insert Into Feriados(Fecha, Motivo) Values(str_to_date('{0}','%d/%m/%y'),'{1}')", fecha.Value.ToString("dd/MM/yy"), txtMotivo.Text.Trim());
                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                cone.Close();
            }
            else
            {
                sentencia = string.Format("Update Feriados Set Motivo = '{0}' Where IdFeriado = {1}", txtMotivo.Text.Trim(), txtIdFeriado.Text.Trim());
                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                comando.CommandType = CommandType.Text;

                comando.ExecuteNonQuery();
                cone.Close();
            }
            Close();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea realmente dar de baja este Feriado ?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                MySqlConnection coneEliminar = new MySqlConnection(conexion);
                coneEliminar.Open();

                string sentencia = string.Format("Delete From Feriados Where IdFeriado = {0}", txtIdFeriado.Text.Trim());
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
