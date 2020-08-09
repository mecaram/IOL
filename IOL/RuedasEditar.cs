using System;
using System.Drawing;
using System.Windows.Forms;
using IOL.EntityFrameWork;
using IOL.Servicios;

namespace IOL
{
    public partial class RuedasEditar : Form
    {
        private readonly ServiciosRueda _service = new ServiciosRueda();
        private readonly ServiciosFeriado _serviceFeriado = new ServiciosFeriado();
        private readonly ServiciosDatosSimulador _serviceDatoSimulador = new ServiciosDatosSimulador();
        private readonly ServiciosTenenciaSimulador _serviceTenenciaSimulador = new ServiciosTenenciaSimulador();
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
                        //                    ActualizarDatosSimulador();
                    }
                    else
                    {
                        txtSaldoARetirar.Text = string.Format("$ {0:00.00}", 10000);
                        nupCantAcciones.Value = 5;

                        txtPorcComisionIOL.Text = string.Format("{0:00.00}", 0.70m);
                        txtPorcCompra.Text = string.Format("{0:00.00}", 0.55m);
                        txtPorcVenta.Text = string.Format("{0:00.00}", 0.70m);
                        txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", 0m);
                        txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", 0m);
                        nudComprarHasta.Value = 16;

                        chkSi.Checked = true;

                        txtPorcCompra1.Text = string.Format("{0:00.00}", 0.58m);
                        txtPorcCompra2.Text = string.Format("{0:00.00}", 0.55m);
                        txtPorcCompra3.Text = string.Format("{0:00.00}", 0.60m);
                        txtPorcCompra4.Text = string.Format("{0:00.00}", 0.59m);
                        txtPorcCompra5.Text = string.Format("{0:00.00}", 0.60m);
                        txtPorcCompra6.Text = string.Format("{0:00.00}", 0.01m);
                        txtPorcCompra7.Text = string.Format("{0:00.00}", 0.05m);
                        txtPorcCompra8.Text = string.Format("{0:00.00}", 0.01m);
                        txtPorcCompra9.Text = string.Format("{0:00.00}", 0.01m);
                        txtPorcCompra10.Text = string.Format("{0:00.00}", 0.05m);

                        txtPorcVenta1.Text = string.Format("{0:00.00}", 1.0m);
                        txtPorcVenta2.Text = string.Format("{0:00.00}", 0.70m);
                        txtPorcVenta3.Text = string.Format("{0:00.00}", 0.75m);
                        txtPorcVenta4.Text = string.Format("{0:00.00}", 1.00m);
                        txtPorcVenta5.Text = string.Format("{0:00.00}", 1.00m);
                        txtPorcVenta6.Text = string.Format("{0:00.00}", 0.15m);
                        txtPorcVenta7.Text = string.Format("{0:00.00}", 0.20m);
                        txtPorcVenta8.Text = string.Format("{0:00.00}", 0.25m);
                        txtPorcVenta9.Text = string.Format("{0:00.00}", 0.30m);
                        txtPorcVenta10.Text = string.Format("{0:00.00}", 0.36m);
                    }

                    txtSaldoARetirar.Focus();
                    break;
                case 2: //Modificar
                    tsbEliminar.Visible = false;

                    ActualizarRueda();
                    ActualizarDatosSimulador();

                    this.Text = "Modificar Rueda";
                    txtFecha.Enabled = false;
                    txtSaldoARetirar.Focus();
                    break;
                case 3: // Elmininar
                    tsbEliminar.Visible = false;

                    ActualizarRueda();
                    ActualizarDatosSimulador();
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
                    ActualizarDatosSimulador();

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
                try { saldoaretirar = Convert.ToDecimal(txtSaldoARetirar.Text.Trim().Replace("$", "")); }
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

            decimal porccompra1 = 0, porccompra2 = 0, porccompra3 = 0, porccompra4 = 0, porccompra5 = 0,
                    porccompra6 = 0, porccompra7 = 0, porccompra8 = 0, porccompra9 = 0, porccompra10 = 0,
                    porcventa1 = 0, porcventa2 = 0, porcventa3 = 0, porcventa4 = 0, porcventa5 = 0,
                    porcventa6 = 0, porcventa7 = 0, porcventa8 = 0, porcventa9 = 0, porcventa10 = 0;

            try { porccompra1 = Convert.ToDecimal(txtPorcCompra1.Text.Trim()); }
            catch { porccompra1 = 0; }

            try { porccompra2 = Convert.ToDecimal(txtPorcCompra2.Text.Trim()); }
            catch { porccompra2 = 0; }

            try { porccompra3 = Convert.ToDecimal(txtPorcCompra3.Text.Trim()); }
            catch { porccompra3 = 0; }

            try { porccompra4 = Convert.ToDecimal(txtPorcCompra4.Text.Trim()); }
            catch { porccompra4 = 0; }

            try { porccompra5 = Convert.ToDecimal(txtPorcCompra5.Text.Trim()); }
            catch { porccompra5 = 0; }

            try { porccompra6 = Convert.ToDecimal(txtPorcCompra6.Text.Trim()); }
            catch { porccompra6 = 0; }

            try { porccompra7 = Convert.ToDecimal(txtPorcCompra7.Text.Trim()); }
            catch { porccompra7 = 0; }

            try { porccompra8 = Convert.ToDecimal(txtPorcCompra8.Text.Trim()); }
            catch { porccompra8 = 0; }

            try { porccompra9 = Convert.ToDecimal(txtPorcCompra9.Text.Trim()); }
            catch { porccompra9 = 0; }

            try { porccompra10 = Convert.ToDecimal(txtPorcCompra10.Text.Trim()); }
            catch { porccompra10 = 0; }

            try { porcventa1 = Convert.ToDecimal(txtPorcVenta1.Text.Trim()); }
            catch { porcventa1 = 0; }

            try { porcventa2 = Convert.ToDecimal(txtPorcVenta2.Text.Trim()); }
            catch { porcventa2 = 0; }

            try { porcventa3 = Convert.ToDecimal(txtPorcVenta3.Text.Trim()); }
            catch { porcventa3 = 0; }

            try { porcventa4 = Convert.ToDecimal(txtPorcVenta4.Text.Trim()); }
            catch { porcventa4 = 0; }

            try { porcventa5 = Convert.ToDecimal(txtPorcVenta5.Text.Trim()); }
            catch { porcventa5 = 0; }

            try { porcventa6 = Convert.ToDecimal(txtPorcVenta6.Text.Trim()); }
            catch { porcventa6 = 0; }

            try { porcventa7 = Convert.ToDecimal(txtPorcVenta7.Text.Trim()); }
            catch { porcventa7 = 0; }

            try { porcventa8 = Convert.ToDecimal(txtPorcVenta8.Text.Trim()); }
            catch { porcventa8 = 0; }

            try { porcventa9 = Convert.ToDecimal(txtPorcVenta9.Text.Trim()); }
            catch { porcventa9 = 0; }

            try { porcventa10 = Convert.ToDecimal(txtPorcVenta10.Text.Trim()); }
            catch { porcventa10 = 0; }

            if (porccompra1 <= 0)
            {
                Mensaje += String.Format("Ingrese Porcentaje de Compra 1 \r");
                lValidado = false;
            }

            if (porcventa1 <= 0)
            {
                Mensaje += String.Format("Ingrese Porcentaje de Venta 1 \r");
                lValidado = false;
            }

            if (porccompra2 > 0)
                if (porcventa2 <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta 2 \r");
                    lValidado = false;
                }

            if (porccompra3 > 0)
                if (porcventa3 <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta 3 \r");
                    lValidado = false;
                }

            if (porccompra4 > 0)
                if (porcventa4 <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta 4 \r");
                    lValidado = false;
                }

            if (porccompra5 > 0)
                if (porcventa5 <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta 5 \r");
                    lValidado = false;
                }

            if (porccompra6 > 0)
                if (porcventa6 <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta 6 \r");
                    lValidado = false;
                }

            if (porccompra7 > 0)
                if (porcventa7 <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta 7 \r");
                    lValidado = false;
                }

            if (porccompra8 > 0)
                if (porcventa8 <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta 8 \r");
                    lValidado = false;
                }

            if (porccompra9 > 0)
                if (porcventa9 <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta 9 \r");
                    lValidado = false;
                }

            if (porccompra10 > 0)
                if (porcventa10 <= 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta 10 \r");
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

            int idSimulador = 1;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra1;
            ruedasDatosSimulador.PorcVenta = porcventa1;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            idSimulador = 2;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra2;
            ruedasDatosSimulador.PorcVenta = porcventa2;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            idSimulador = 3;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra3;
            ruedasDatosSimulador.PorcVenta = porcventa3;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            idSimulador = 4;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra4;
            ruedasDatosSimulador.PorcVenta = porcventa4;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            idSimulador = 5;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra5;
            ruedasDatosSimulador.PorcVenta = porcventa5;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            idSimulador = 6;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra6;
            ruedasDatosSimulador.PorcVenta = porcventa6;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            idSimulador = 7;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra7;
            ruedasDatosSimulador.PorcVenta = porcventa7;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            idSimulador = 8;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra8;
            ruedasDatosSimulador.PorcVenta = porcventa8;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            idSimulador = 9;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra9;
            ruedasDatosSimulador.PorcVenta = porcventa9;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            idSimulador = 10;
            ruedasDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(rueda.IdRueda, idSimulador);
            ruedasDatosSimulador.IdSimulador = idSimulador;
            ruedasDatosSimulador.IdRueda = rueda.IdRueda;
            ruedasDatosSimulador.PorcCompra = porccompra10;
            ruedasDatosSimulador.PorcVenta = porcventa10;
            _serviceDatoSimulador.Register(ruedasDatosSimulador);

            TenenciaSimuladores tenenciaSimulador = new TenenciaSimuladores();
            for (int x = 1; x < 11; x++)
            {
                idSimulador = 1;
                tenenciaSimulador = _serviceTenenciaSimulador.GetById(idSimulador);
                if (tenenciaSimulador != null)
                {
                    //   To Do 
                    //   Update TenenciaSimulador Set ActivosValorizados = ifnull((Select Sum(ImporteCompra) From RuedasDetalleSimulador
                    //   Where IdRuedaActual = rueda And IdSimulacion = Simulacion  And Estado = "Comprado"),0)
                    //   Where IdSimulacion = Simulacion;
                    //   Update TenenciaSimulador Set DisponibleParaOperar = TotalTenencia - ActivosValorizados Where IdSimulacion = Simulacion;

                    //decimal activosvalorizado = _serviceTenenciaSimulador
                    tenenciaSimulador.DisponibleParaOperar = 100000;
                    tenenciaSimulador.ActivosValorizados = 0;
                    tenenciaSimulador.Fecha = DateTime.Now.Date;
                    tenenciaSimulador.TotalTenencia = tenenciaSimulador.DisponibleParaOperar;
                }
                else
                {
                    tenenciaSimulador.IdSimulador = idSimulador;
                    tenenciaSimulador.DisponibleParaOperar = 100000;
                    tenenciaSimulador.ActivosValorizados = 0;
                    tenenciaSimulador.Fecha = DateTime.Now.Date;
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
            txtPorcCompra1.Enabled = false;
            txtPorcCompra2.Enabled = false;
            txtPorcCompra3.Enabled = false;
            txtPorcCompra4.Enabled = false;
            txtPorcCompra5.Enabled = false;
            txtPorcCompra6.Enabled = false;
            txtPorcCompra7.Enabled = false;
            txtPorcCompra8.Enabled = false;
            txtPorcCompra9.Enabled = false;
            txtPorcCompra10.Enabled = false;

            txtPorcVenta1.Enabled = false;
            txtPorcVenta2.Enabled = false;
            txtPorcVenta3.Enabled = false;
            txtPorcVenta4.Enabled = false;
            txtPorcVenta5.Enabled = false;
            txtPorcVenta6.Enabled = false;
            txtPorcVenta7.Enabled = false;
            txtPorcVenta8.Enabled = false;
            txtPorcVenta9.Enabled = false;
            txtPorcVenta10.Enabled = false;
        }
        private void ActualizarRueda()
        {
            int idRueda = Convert.ToInt32(txtIdRueda.Text.Trim());
            var rueda = _service.GetById(idRueda);

            if (rueda != null)
            {
                txtSaldoARetirar.Text = string.Format("$ {0:00.00}", rueda.SaldoARetirar);
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
            int idRueda = Convert.ToInt32(txtIdRueda.Text.Trim());
            var RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 1);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra1.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta1.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
            }

            RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 2);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra2.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta2.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
            }

            RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 3);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra3.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta3.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
            }

            RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 4);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra4.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta4.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
            }

            RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 5);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra5.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta5.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
            }

            RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 6);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra6.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta6.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
            }

            RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 7);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra7.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta7.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
            }

            RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 8);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra8.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta8.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
            }

            RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 9);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra9.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta9.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
            }

            RuedaDatosSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, 10);
            if (RuedaDatosSimulador != null)
            {
                txtPorcCompra10.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcCompra);
                txtPorcVenta10.Text = string.Format("{0:00.00}", RuedaDatosSimulador.PorcVenta);
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

        private void txtPorcCompra1_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompra2_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompra3_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompra4_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompra5_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta1_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta2_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta3_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta4_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta5_Click(object sender, EventArgs e)
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

        private void txtPorcCompra1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPorcCompra1_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcCompra2_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcCompra3_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcCompra4_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcCompra5_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta1_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta3_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta2_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta5_Leave(object sender, EventArgs e)
        {
            EventoLeave(sender, e);
        }

        private void txtPorcVenta4_Leave(object sender, EventArgs e)
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

        private void txtSaldoARetirar_Leave(object sender, EventArgs e)
        {
            decimal SaldoARetirar = Convert.ToDecimal(txtSaldoARetirar.Text.Replace("$", ""));
            txtSaldoARetirar.Text = string.Format("$ {0:00.00}", SaldoARetirar);
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

        private void txtPorcCompra6_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompra7_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompra8_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompra9_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompra10_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta6_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta7_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta8_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta9_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcVenta10_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }

        private void txtPorcCompra6_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra7_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra8_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra9_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcCompra10_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta6_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarFormatoNumerico(sender, e);
        }

        private void txtPorcVenta7_KeyPress(object sender, KeyPressEventArgs e)
        {
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
    }
}