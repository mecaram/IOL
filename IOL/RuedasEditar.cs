using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using IOL.EntityFrameWork;
using IOL.Servicios;
using System.Runtime.Serialization;

namespace IOL
{
    public partial class RuedasEditar : Form
    {
        private readonly ServiciosRueda _service = new ServiciosRueda();
        private readonly ServiciosFeriado _serviceFeriado = new ServiciosFeriado();
        private readonly ServiciosDatosSimulador _serviceDatoSimulador = new ServiciosDatosSimulador();
        private readonly ServiciosTenenciaSimulador _serviceTenenciaSimulador = new ServiciosTenenciaSimulador();
        private readonly ServiciosRuedasDetalleSimulador _serviceRuedasDetalleSimulador = new ServiciosRuedasDetalleSimulador();
        BD Bd = new BD();

        public int operacion = 0;
        public int comitente = 0;

        public RuedasEditar()
        {
            InitializeComponent();
        }

        private void RuedasEditar_Load(object sender, EventArgs e)
        {
            switch (operacion)
            {
                case 1: //Agregar

                    tsbEliminar.Visible = false;
                    this.Text = "Agregar Rueda";

                    DateTime? fecha = null;
                    try { fecha = Convert.ToDateTime(txtFecha.Text.Trim()); }
                    catch { fecha = null; }

                    var RuedaAnterior = _service.GetLast();
                    if (RuedaAnterior != null)
                    {
                        nupCantAcciones.Value = RuedaAnterior.CantAcciones;
                        txtPorcComisionIOL.Text = string.Format("{0:00.00}", RuedaAnterior.PorcComisionIOL);
                        txtPorcCompra.Text = string.Format("{0:00.00}", RuedaAnterior.PorcCompra);
                        txtPorcVenta.Text = string.Format("{0:00.00}", RuedaAnterior.PorcVenta);
                        txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", RuedaAnterior.PorcPuntaCompradora);
                        txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", RuedaAnterior.PorcPuntaVendedora);
                        nudComprarHasta.Value = RuedaAnterior.ComprarHasta;

                        chkSi.Checked = RuedaAnterior.Operar ? true : false;
                        chkNo.Checked = !chkSi.Checked;
                    }
                    else
                    {
                        txtSaldoARetirar.Text = string.Format("{0:00.00}", 0);
                        nupCantAcciones.Value = 5;
                        txtPorcComisionIOL.Text = string.Format("{0:00.00}", 0.70m);
                        txtPorcCompra.Text = string.Format("{0:00.00}", 0.55m);
                        txtPorcVenta.Text = string.Format("{0:00.00}", 0.70m);
                        txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", 0m);
                        txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", 0m);
                        nudComprarHasta.Value = 16;
                        chkSi.Checked = true;
                    }

                    txtSaldoARetirar.Focus();
                    break;
                case 2: //Modificar
                    tsbEliminar.Visible = false;

                    ActualizarRueda();

                    this.Text = "Modificar Rueda";
                    txtFecha.Enabled = false;
                    txtSaldoARetirar.Focus();
                    break;
                case 3: // Elmininar
                    tsbEliminar.Visible = false;

                    ActualizarRueda();
                    this.Text = "Eliminar Rueda";

                    txtIdRueda.Enabled = false;
                    txtFecha.Enabled = false;
                    txtSaldoARetirar.Enabled = false;
                    nupCantAcciones.Enabled = false;
                    txtPorcComisionIOL.Enabled = false;
                    txtPorcCompra.Enabled = false;
                    txtPorcVenta.Enabled = false;
                    txtPorcPuntaCompradora.Enabled = false;
                    txtPorcPuntaVendedora.Enabled = false;
                    nudComprarHasta.Enabled = false;

                    DesactivarPorcentajesSimulador();

                    chkNo.Enabled = false;
                    chkSi.Enabled = false;

                    tsbGuardar.Visible = false;
                    tsbEliminar.Visible = true;
                    tsbEliminar.Enabled = true;
                    break;
                case 4: //Detalle
                    tsbEliminar.Visible = false;

                    ActualizarRueda();

                    txtIdRueda.Enabled = false;
                    txtFecha.Enabled = false;
                    txtSaldoARetirar.Enabled = false;
                    nupCantAcciones.Enabled = false;
                    txtPorcComisionIOL.Enabled = false;
                    txtPorcCompra.Enabled = false;
                    txtPorcVenta.Enabled = false;
                    txtPorcPuntaCompradora.Enabled = false;
                    txtPorcPuntaVendedora.Enabled = false;
                    nudComprarHasta.Enabled = false;

                    DesactivarPorcentajesSimulador();

                    chkNo.Enabled = false;
                    chkSi.Enabled = false;

                    this.Text = "Detalle Rueda";

                    tsbGuardar.Visible = false;
                    tsbEliminar.Visible = false;

                    tsbCancelar.Visible = true;
                    tsbCancelar.Text = "&Aceptar";
                    tsbCancelar.Image = tsbGuardar.Image;
                    break;
            }
            ActualizarDatosSimulador();
        }


        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            bool lValidado = true;
            string Mensaje = string.Empty;

            bool operar = chkSi.Checked;

            decimal saldoaretirar = 0,
                    porccomisionIOL = 0,
                    porccompra = 0,
                    porcventa = 0,
                    porcpuntacompradora = 0,
                    porcpuntavendedora = 0,
                    cantacciones = 0;
            int comprarhasta = 0;

            if (operar)
            {
                try { saldoaretirar = Convert.ToDecimal(txtSaldoARetirar.Text); }
                catch { saldoaretirar = 0; }

                try { cantacciones = Convert.ToDecimal(nupCantAcciones.Value); }
                catch { cantacciones = 0; }

                try { porccomisionIOL = Convert.ToDecimal(txtPorcComisionIOL.Text.Trim()); }
                catch { porccomisionIOL = 0; }

                try { porccompra = Convert.ToDecimal(txtPorcCompra.Text.Trim()); }
                catch { porccompra = 0; }

                try { porcventa = Convert.ToDecimal(txtPorcVenta.Text.Trim()); }
                catch { porcventa = 0; }

                try { comprarhasta = Convert.ToInt16(nudComprarHasta.Value); }
                catch { comprarhasta = 0; }

                try { porcpuntacompradora = Convert.ToDecimal(txtPorcPuntaCompradora.Text.Trim()); }
                catch { porcpuntacompradora = 0; }

                try { porcpuntavendedora = Convert.ToDecimal(txtPorcPuntaVendedora.Text.Trim()); }
                catch { porcpuntavendedora = 0; }

                if (saldoaretirar < 0)
                {
                    Mensaje += String.Format("Ingrese Saldo a Retirar \r");
                    lValidado = false;
                }

                if (cantacciones <= 0 && cantacciones > 20)
                {
                    Mensaje += String.Format("La Cantidad de Acciones a Operar debe ser entre 1 y 20 \r");
                    lValidado = false;
                }

                if (porccomisionIOL <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Comisión IOL \r");
                    lValidado = false;
                }

                if (porccompra <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Compra \r");
                    lValidado = false;
                }

                if (porcventa <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta \r");
                    lValidado = false;
                }

                if (comprarhasta == 0)
                {
                    Mensaje += String.Format("Ingrese Horario Limite para Comprar \r");
                    lValidado = false;
                }
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

            int diarueda = fecha.Value.Day;

            EntityFrameWork.Ruedas rueda = new EntityFrameWork.Ruedas();
            RuedasDatosSimulador ruedasDatosSimulador = new RuedasDatosSimulador();

            try { rueda.IdRueda = Convert.ToInt32(txtIdRueda.Text.Trim()); }
            catch { rueda.IdRueda = 0;}
            rueda.DiaRueda = diarueda;
            rueda.SaldoARetirar = saldoaretirar;
            rueda.Estado = string.Empty;
            rueda.PorcComisionIOL = porccomisionIOL;
            rueda.Operar = operar;
            rueda.PorcCompra = porccompra;
            rueda.PorcVenta = porcventa;
            rueda.CantAcciones = Convert.ToInt32(cantacciones);
            rueda.PorcPuntaCompradora = porcpuntacompradora;
            rueda.PorcPuntaVendedora = porcpuntavendedora;
            rueda.ComprarHasta = comprarhasta;
            rueda.Comitente = comitente;

            _service.Register(rueda);
            int idRueda = _service.GetLast().IdRueda;

            for (int x = 0; x < dgvListado.Rows.Count; x++)
            {
                int idSimulacion = Convert.ToInt32(dgvListado.Rows[x].Cells["IdSimulador"].Value);
                ruedasDatosSimulador.IdRuedaSimulador = Convert.ToInt32(dgvListado.Rows[x].Cells["IdRuedaSimulador"].Value);
                ruedasDatosSimulador.IdSimulador = idSimulacion;
                ruedasDatosSimulador.IdRueda = idRueda;
                ruedasDatosSimulador.InversionTotalSimulador = Convert.ToDecimal(dgvListado.Rows[x].Cells["InversionTotalSimulador"].Value);
                ruedasDatosSimulador.PorcCompra = Convert.ToDecimal(dgvListado.Rows[x].Cells["PorcCompra"].Value);
                ruedasDatosSimulador.PorcVenta = Convert.ToDecimal(dgvListado.Rows[x].Cells["PorcVenta"].Value);
                _serviceDatoSimulador.Register(ruedasDatosSimulador);
            }


            RuedasDetalleSimulador ruedaDetalleSimulador = new RuedasDetalleSimulador();
            for (int x = 1; x < 11; x++)
            {
                TenenciaSimuladores tenenciaSimulador = new TenenciaSimuladores();

                int idSimulacion = x;
                tenenciaSimulador = _serviceTenenciaSimulador.GetById(idSimulacion);
                if (tenenciaSimulador != null)
                {
                    tenenciaSimulador.Fecha = DateTime.Now.Date;
                    tenenciaSimulador.ActivosValorizados = Convert.ToDecimal(_serviceTenenciaSimulador.GetActivosValorizados(idSimulacion));
                    tenenciaSimulador.DisponibleParaOperar = tenenciaSimulador.TotalTenencia - tenenciaSimulador.ActivosValorizados;
                    if (tenenciaSimulador.DisponibleParaOperar < 0)
                    {
                        tenenciaSimulador.TotalTenencia = 100000;
                        tenenciaSimulador.DisponibleParaOperar = tenenciaSimulador.TotalTenencia - tenenciaSimulador.ActivosValorizados;
                    }
                }
                else
                {
                    tenenciaSimulador.IdSimulacion = idSimulacion;
                    tenenciaSimulador.Fecha = DateTime.Now.Date;
                    tenenciaSimulador.DisponibleParaOperar = 100000;
                    tenenciaSimulador.ActivosValorizados = 0;
                    tenenciaSimulador.TotalTenencia = tenenciaSimulador.DisponibleParaOperar;
                }
                _serviceTenenciaSimulador.Register(tenenciaSimulador);
            }

            Bd.SaveChanges();
            Close();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea realmente dar de baja esta Rueda ?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                int IdRueda = Convert.ToInt32(txtIdRueda.Text.Trim());
                var rueda = _service.GetById(IdRueda);

                if (rueda != null)
                {
                    Bd.Ruedas.Remove(rueda);
                    Bd.SaveChanges();
                }
                Close();
            }
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DesactivarPorcentajesSimulador()
        {
            txtPorcCompraSimulador.Enabled = false;
            txtPorcVentaSimulador.Enabled = false;
        }
        private void ActualizarRueda()
        {
            int idRueda = Convert.ToInt32(txtIdRueda.Text.Trim());
            var rueda = _service.GetById(idRueda);

            if (rueda != null)
            {
                txtSaldoARetirar.Text = string.Format("{0:00.00}", rueda.SaldoARetirar);
                nupCantAcciones.Value = rueda.CantAcciones;
                txtPorcComisionIOL.Text = string.Format("{0:00.00}", rueda.PorcComisionIOL);
                txtPorcCompra.Text = string.Format("{0:00.00}", rueda.PorcCompra);
                txtPorcVenta.Text = string.Format("{0:00.00}", rueda.PorcVenta);
                txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", rueda.PorcPuntaCompradora);
                txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", rueda.PorcPuntaVendedora);
                nudComprarHasta.Value = rueda.ComprarHasta;

                chkSi.Checked = rueda.Operar ? true : false;
                chkNo.Checked = !chkSi.Checked;
            }
        }

        private void ActualizarDatosSimulador()
        {
            RuedasDatosSimulador datosSimulador = new RuedasDatosSimulador();
            List<IOL.EntityFrameWork.RuedasDatosSimulador> lstDatosSimulador = new List<RuedasDatosSimulador>();

            decimal[] porcCompra = { 0, 0.58m, 0.55m, 0.60m, 0.59m, 0.60m, 0.01m, 0.05m, 0.01m, 0.01m, 0.05m };
            decimal[] porcVenta = { 0, 1.00m, 0.70m, 0.75m, 1.00m, 1.00m, 0.15m, 0.20m, 0.25m, 0.30m, 0.05m };

            int idRueda;
            try { idRueda = Convert.ToInt32(txtIdRueda.Text); }
            catch { idRueda = 0; }

            if (idRueda == 0)
                for (int idSimulador = 1; idSimulador < 11; idSimulador++)
                {
                    datosSimulador.IdRuedaSimulador = 0;
                    datosSimulador.IdSimulador = idSimulador;
                    datosSimulador.InversionTotalSimulador = 100000m;
                    datosSimulador.PorcCompra = porcCompra[idSimulador];
                    datosSimulador.PorcVenta = porcVenta[idSimulador];
                    lstDatosSimulador.Add(datosSimulador);
                }
            else
                lstDatosSimulador = _serviceDatoSimulador.GetByIdRueda(idRueda);

            if (lstDatosSimulador != null && lstDatosSimulador.Count > 0)
            {
                dgvListado.DataSource = lstDatosSimulador;

                DataGridViewCellStyle EstiloEncabezadoColumna = new DataGridViewCellStyle();

                EstiloEncabezadoColumna.BackColor = Color.Green;
                EstiloEncabezadoColumna.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                dgvListado.ColumnHeadersDefaultCellStyle = EstiloEncabezadoColumna;

                DataGridViewCellStyle EstiloColumnas = new DataGridViewCellStyle();
                EstiloColumnas.BackColor = Color.AliceBlue;
                EstiloColumnas.Font = new Font("Times New Roman", 12);
                dgvListado.RowsDefaultCellStyle = EstiloColumnas;

                dgvListado.Columns["IdSimulador"].HeaderText = "Simulador";
                dgvListado.Columns["PorcCompra"].HeaderText = "Porc.Compra";
                dgvListado.Columns["PorcVenta"].HeaderText = "Porc.Venta";

                dgvListado.Columns["IdSimulador"].Width = 80;
                dgvListado.Columns["PorcCompra"].Width = 110;
                dgvListado.Columns["PorcVenta"].Width = 110;

                dgvListado.Columns["IdSimulador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["PorcCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["PorcVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.Columns["IdSimulador"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["PorcCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["PorcVenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.RefreshEdit();
                dgvListado.Enabled = true;
            }
            else
            {
                dgvListado.DataSource = null;
                dgvListado.RefreshEdit();
            }
        }

        private void txtInversionTotal_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcComision_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void chkSi_CheckedChanged(object sender, EventArgs e)
        {
            chkNo.Checked = !chkSi.Checked;
        }

        private void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            chkSi.Checked = !chkNo.Checked;
        }

        private void txtPorcCompra_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtInversionTotal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPorcComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void ValidarFormatoNumerico(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void SeleccionarTexto(Object sender)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = control.MaxLength;

        }

        private void EventoLeave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void txtPorcComision_Leave(object sender, EventArgs e)
        {
            EventoLeave( sender, e);
        }

        private void txtPorcCompra_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void nupCantAcciones_Click(object sender, EventArgs e)
        {
        }

        private void nupCantAcciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtSaldoARetirar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcPuntaCompradora_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcPuntaVendedora_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcPuntaCompradora_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcPuntaVendedora_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcPuntaCompradora_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcPuntaVendedora_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void nudComprarHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtInversionTotalSimulador_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtInversionTotalSimulador_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtInversionTotalSimulador_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta8_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta9_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta10_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra6_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcCompra7_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcCompra8_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcCompra9_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcCompra10_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta6_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta7_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta8_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta9_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta10_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcCompraSimulador_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompraSimulador_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompraSimulador_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVentaSimulador_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVentaSimulador_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVentaSimulador_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void btnGuardarSimulador_Click(object sender, EventArgs e)
        {

            int idRueda, idSimulador, idRuedaSimulador;
            decimal porcCompra, porcVenta, inversionTotalSimulador;

            try { idRuedaSimulador = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdRuedaSimulador"].Value); }
            catch { idRuedaSimulador = 0; }

            try { idRueda = Convert.ToInt32(txtIdRueda.Text); }
            catch { idRueda = 0; }

            try { idSimulador = Convert.ToInt32(txtIdSimulador.Text); }
            catch { idSimulador = 0; }

            try { inversionTotalSimulador = Convert.ToDecimal(dgvListado.CurrentRow.Cells["InversionTotalSimulador"].Value); }
            catch { inversionTotalSimulador = 0; }

            try { porcCompra = Convert.ToDecimal(txtPorcCompra.Text); }
            catch { porcCompra = 0; }

            try { porcVenta = Convert.ToDecimal(txtPorcVenta.Text); }
            catch { porcVenta = 0; }

            if (idRueda > 0 && idSimulador > 0)
            {
                RuedasDatosSimulador datosSimulador = null;

                datosSimulador.IdRuedaSimulador = idRuedaSimulador;
                datosSimulador.IdRueda = idRueda;
                datosSimulador.IdSimulador = idSimulador;
                datosSimulador.InversionTotalSimulador = inversionTotalSimulador;
                datosSimulador.PorcCompra = porcCompra;
                datosSimulador.PorcVenta = porcVenta;
            }
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            int idSimulador;
            decimal porcCompra, porcVenta;

            try { idSimulador = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdSimulador"].Value); }
            catch { idSimulador = 0; }

            try { porcCompra = Convert.ToDecimal(dgvListado.CurrentRow.Cells["PorcCompra"].Value); }
            catch { porcCompra = 0; }

            try { porcVenta = Convert.ToDecimal(dgvListado.CurrentRow.Cells["PorcVenta"].Value); }
            catch { porcVenta = 0; }

            txtIdSimulador.Text = string.Format("{0:0}", idSimulador);
            txtEstrategia.Text = idSimulador < 6 ? "Uno" : "Dos";
            txtPorcCompraSimulador.Text = string.Format("{0:00.00}", porcCompra);
            txtPorcVentaSimulador.Text = string.Format("{0:00.00}", porcVenta);
        }

        private void txtSaldoARetirar_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void dgvListado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvListado.Columns["IdRueda"].Visible = false;
            dgvListado.Columns["IdRuedaSimulador"].Visible = false;
            dgvListado.Columns["InversionTotalSimulador"].Visible = false;
        }
    }
}