using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using IOL.EntityFrameWork;
using IOL.Servicios;
using System.Linq;
using System.Configuration;

namespace IOL
{
    public partial class Simulador : Form
    {
        private readonly ServiciosRueda _service = new ServiciosRueda();
        private readonly ServiciosFeriado _serviceFeriado = new ServiciosFeriado();
        private readonly ServiciosDatosSimulador _serviceDatoSimulador = new ServiciosDatosSimulador();
        private readonly ServiciosTenenciaSimulador _serviceTenenciaSimulador = new ServiciosTenenciaSimulador();
        private readonly ServiciosRuedasDetalleSimulador _serviceRuedasDetalleSimulador = new ServiciosRuedasDetalleSimulador();
        private readonly ServiciosPanelPrincipal _servicePanelPrincipal = new ServiciosPanelPrincipal();
        private readonly ServiciosAccion _serviceAcciones = new ServiciosAccion();
        private readonly ServiciosInformeFinal _serviceInformeFinal = new ServiciosInformeFinal();
        BD Databases = new BD();

        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();
        public int comitente = 0;  // Nro. de Comitente

        Token permisoIOL = null; // Token para acceder a IOL
        public Simulador()
        {
            InitializeComponent();
        }

        private void tmrActualizarToken_Tick(object sender, EventArgs e)
        {
            MySqlConnection cone = new MySqlConnection(conexion);
            string sentencia = string.Format("Select Usuario, CAST(AES_DECRYPT(Contrasenia,'Miguel2020') AS Char(1000) Character Set utf8) as Contrasenia From Comitentes Where Comitente = {0}", comitente);
            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, cone);
            DataTable dt = new DataTable();
            int registros = da.Fill(dt);
            if (registros > 0)
            {
                permisoIOL = new Token(dt.Rows[0]["Usuario"].ToString(), dt.Rows[0]["Contrasenia"].ToString());
                if (permisoIOL.ObtenerToken() == true)
                {
                    AgregarAccesoIOL();
                }
            }
        }
        private void ActualizarLoad(object sender, EventArgs e)
        {
            var ruedaactual = _service.GetByDate(DateTime.Now.Date, comitente);
            if (ruedaactual != null)
            {
                txtIdRueda.Text = ruedaactual.IdRueda.ToString();
                txtFecha.Text = DateTime.Now.Date.ToShortDateString();
                txtHora.Text = string.Format("{0:00}:{1:00}", DateTime.Now.Hour, DateTime.Now.Minute);
                txtEstado.Text = _service.GetEstadoRueda(Convert.ToInt32(txtIdRueda.Text.Trim()));
                this.Refresh();
                AgregarAccesoIOL();
                txtPorcCompra.Text = string.Format("{0:00.00}", ruedaactual.PorcCompra);
                txtPorcVenta.Text = string.Format("{0:00.00}", ruedaactual.PorcVenta);
                txtPorcComisionIOL.Text = string.Format("{0:00.00}", ruedaactual.PorcComisionIOL);
                txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", ruedaactual.PorcPuntaCompradora);
                txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", ruedaactual.PorcPuntaVendedora);

                tmrActualizarToken_Tick(sender, e);
                ActualizarAcciones();
            }
        }
        private void Simulador_Load(object sender, EventArgs e)
        {
            DateTime? fecha = DateTime.Now.Date;

            var ruedaactual = _service.GetByDate(DateTime.Now.Date, comitente);
            if (ruedaactual != null)
            {
                ActualizarLoad(sender, e);
            }
            else
            {
                DayOfWeek nrodia = fecha.Value.DayOfWeek;
                if (nrodia == DayOfWeek.Saturday || nrodia == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Sábado/Domingo y Feriados NO opera la bolsa", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var feriado = _serviceFeriado.GetByDate(DateTime.Now.Date);
                    if (feriado != null)
                    {
                        string mensaje = string.Format("Sábado/Domingo y Feriados NO opera la bolsa. Dia {0} Feriado: '{1}'",
                                                        fecha.Value.Date.ToShortDateString(), feriado.Motivo);
                        MessageBox.Show(mensaje, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        RuedasEditar formulario = new RuedasEditar();
                        formulario.StartPosition = FormStartPosition.CenterScreen;
                        formulario.operacion = 1;
                        formulario.comitente = comitente;
                        formulario.txtFecha.Text = fecha.Value.Date.ToShortDateString();
                        formulario.txtFecha.Enabled = false;
                        formulario.ShowDialog();

                        ActualizarLoad(sender, e);
                    }
                }
            }
        }
        private int AgregarAccesoIOL()
        {
            int idRueda = Convert.ToInt32(txtIdRueda.Text);
            return _service.InsertAccess(idRueda);
        }
        private void ActualizarAcciones()
        {
            int IdSimulacion = 0;
            try { IdSimulacion = Convert.ToInt32(nudSimulador.Value); }
            catch { IdSimulacion = 0; }

            if (IdSimulacion > 0 && txtIdRueda.Text.Trim().Length > 0)
            {
                var detalleRuedaSimulacion = _serviceRuedasDetalleSimulador.GetByIdSimulacion(Convert.ToInt32(txtIdRueda.Text.Trim()), IdSimulacion);
                if (detalleRuedaSimulacion != null)
                {
                    lblTotales.Text = string.Format("Total Simulador {0:00}:", IdSimulacion);

                    dgvAcciones.DataSource = detalleRuedaSimulacion;

                    DataGridViewCellStyle EstiloEncabezadoColumna = new DataGridViewCellStyle();

                    EstiloEncabezadoColumna.BackColor = System.Drawing.Color.Green;
                    EstiloEncabezadoColumna.Font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);
                    dgvAcciones.ColumnHeadersDefaultCellStyle = EstiloEncabezadoColumna;

                    DataGridViewCellStyle EstiloColumnas = new DataGridViewCellStyle();
                    EstiloColumnas.BackColor = System.Drawing.Color.AliceBlue;
                    EstiloColumnas.Font = new System.Drawing.Font("Times New Roman", 12);
                    dgvAcciones.RowsDefaultCellStyle = EstiloColumnas;

                    dgvAcciones.Columns["Simbolo"].HeaderText = "Símbolo";
                    dgvAcciones.Columns["FechaCompra"].HeaderText = "Fecha Compra";
                    dgvAcciones.Columns["Cantidad"].HeaderText = "Cantidad";
                    dgvAcciones.Columns["PrecioCompra"].HeaderText = "Precio Compra";
                    dgvAcciones.Columns["ImporteComisionIOL"].HeaderText = "Comisión$";
                    dgvAcciones.Columns["ImporteCompra"].HeaderText = "Importe";
                    dgvAcciones.Columns["UltimoPrecio"].HeaderText = "Ultimo Precio";
                    dgvAcciones.Columns["FechaUltimoPrecio"].HeaderText = "Fecha Precio";
                    dgvAcciones.Columns["VariacionEnPesos"].HeaderText = "Variación$";
                    dgvAcciones.Columns["VariacionEnPorcentajes"].HeaderText = "Variación%";
                    dgvAcciones.Columns["Estado"].HeaderText = "Estado";

                    dgvAcciones.Columns["Simbolo"].Width = 100;
                    dgvAcciones.Columns["FechaCompra"].Width = 150;
                    dgvAcciones.Columns["Cantidad"].Width = 90;
                    dgvAcciones.Columns["PrecioCompra"].Width = 120;
                    dgvAcciones.Columns["ImporteComisionIOL"].Width = 120;
                    dgvAcciones.Columns["ImporteCompra"].Width = 100;
                    dgvAcciones.Columns["UltimoPrecio"].Width = 120;
                    dgvAcciones.Columns["FechaUltimoPrecio"].Width = 150;
                    dgvAcciones.Columns["VariacionEnPesos"].Width = 90;
                    dgvAcciones.Columns["VariacionEnPorcentajes"].Width = 100;
                    dgvAcciones.Columns["Estado"].Width = 100;

                    dgvAcciones.Columns["Simbolo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["FechaCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["ImporteComisionIOL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["ImporteCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["UltimoPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["FechaUltimoPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["VariacionEnPesos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["VariacionEnPorcentajes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvAcciones.Columns["PrecioCompra"].DefaultCellStyle.Format = "$ #00.00";
                    dgvAcciones.Columns["Cantidad"].DefaultCellStyle.Format = "#00.00";
                    dgvAcciones.Columns["ImporteCompra"].DefaultCellStyle.Format = "$ #00.00";
                    dgvAcciones.Columns["ImporteComisionIOL"].DefaultCellStyle.Format = "$ #00.00";
                    dgvAcciones.Columns["UltimoPrecio"].DefaultCellStyle.Format = "$ #00.00";
                    dgvAcciones.Columns["VariacionEnPesos"].DefaultCellStyle.Format = "$ #00.00";
                    dgvAcciones.Columns["VariacionEnPorcentajes"].DefaultCellStyle.Format = "#00.00";

                    dgvAcciones.Columns["Simbolo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["FechaCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["PrecioCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["ImporteComisionIOL"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["ImporteCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["UltimoPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["FechaUltimoPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["VariacionEnPesos"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["VariacionEnPorcentajes"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAcciones.Columns["Estado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvAcciones.RefreshEdit();
                    dgvAcciones.Enabled = true;

                    int totalAccionesCompradas = detalleRuedaSimulacion.Where(x => x.Estado == "Comprado").ToList().Count;
                    decimal totalCantidadCompradas = detalleRuedaSimulacion.Where(x => x.Estado == "Comprado").Sum(x => x.Cantidad);
                    decimal totalImporteComisionCompradas = detalleRuedaSimulacion.Where(x => x.Estado == "Comprado").Sum(x => x.ImporteComisionIOL);
                    decimal totalImporteCompra = detalleRuedaSimulacion.Where(x => x.Estado == "Comprado").Sum(x => x.ImporteCompra);
                    decimal totalVariacionEnPesosCompradas = detalleRuedaSimulacion.Where(x => x.Estado == "Comprado").Sum(x => x.Variacionenpesos);
                    decimal totalVariacionEnPorcentajesCompradas = detalleRuedaSimulacion.Where(x => x.Estado == "Comprado").Sum(x => x.Variacionenporcentajes);

                    int totalAccionesVendidas = detalleRuedaSimulacion.Where(x => x.Estado == "Vendido").ToList().Count;
                    decimal totalCantidadVendidas = detalleRuedaSimulacion.Where(x => x.Estado == "Vendido").Sum(x => x.Cantidad);
                    decimal totalImporteComisionVentas = detalleRuedaSimulacion.Where(x => x.Estado == "Vendido").Sum(x => x.ImporteComisionIOL); ;
                    decimal totalImporteVentas = detalleRuedaSimulacion.Where(x => x.Estado == "Vendido").Sum(x => x.ImporteVenta);
                    decimal totalVariacionEnPesosVendidas = detalleRuedaSimulacion.Where(x => x.Estado == "Vendido").Sum(x => x.Variacionenpesos);
                    decimal totalVariacionEnPorcentajesVendidas = detalleRuedaSimulacion.Where(x => x.Estado == "Vendido").Sum(x => x.Variacionenporcentajes);

                    txtTotalAccionesCompradas.Text = string.Format("{0:000}", totalAccionesCompradas);
                    txtTotalCantidadCompradas.Text = string.Format("{0:000}", totalCantidadCompradas);
                    txtImporteComisionCompradas.Text = string.Format("$ {0:#00.00}", totalImporteComisionCompradas);
                    txtTotalImporteCompra.Text = string.Format("$ {0:#00.00}", totalImporteCompra);
                    txtTotalVariacionEnPesosComp.Text = string.Format("$ {0:#00.00}", totalVariacionEnPesosCompradas);
                    txtTotalVariacionEnPorcentajesCompra.Text = string.Format("{0:#00.00}", totalVariacionEnPorcentajesCompradas);
                    txtTotalAccionesVendidas.Text = string.Format("{0:000}", totalAccionesVendidas);
                    txtTotalCantidadVendidas.Text = string.Format("{0:000}", totalCantidadVendidas);
                    txtImporteComisionVendidas.Text = string.Format("$ {0:#00.00}", totalImporteComisionVentas);
                    txtTotalImporteVenta.Text = string.Format("$ {0:#00.00}", totalImporteVentas);
                    txtTotalVariacionEnPesosVent.Text = string.Format("$ {0:#00.00}", totalVariacionEnPesosVendidas);
                    txtTotalVariacionEnPorcentajesVenta.Text = string.Format("{0:#00.00}", totalVariacionEnPorcentajesVendidas);
                }
            }
            else
            {
                dgvAcciones.DataSource = null;
                foreach (System.Windows.Forms.Control controles in this.Controls)
                    controles.Enabled = false;
                foreach (System.Windows.Forms.Control controles in tbpDatosRueda.Controls)
                    controles.Enabled = false;
                foreach (System.Windows.Forms.Control controles in tbpDatosSimulador.Controls)
                    controles.Enabled = false;
            }
        }
        private void tmrActualizarCotizacion_Tick(object sender, EventArgs e)
        {
            // Obtenemos la fecha y hora actual
            // para luego verificar que estemos en horario Bursatil
            DateTime FechaActual = DateTime.Now;
            int HoraActual = FechaActual.Hour;
            int MinutoActual = FechaActual.Minute;
            txtHora.Text = string.Format("{0:00}:{1:00}", FechaActual.Hour, FechaActual.Minute);

            // Obtenemos el nro. de rueda
            // para luego verificar que exista la rueda.
            int idrueda = 0;
            try { idrueda = Convert.ToInt32(txtIdRueda.Text.Trim()); }
            catch { idrueda = 0; }

            if (idrueda > 0)
            {
                // Verificamos que este en horario Bursatil
                if (HoraActual >= 11 && HoraActual < 17)
                {
                    // Verificamos se realizo la apertura de la rueda
                    if (_service.GetEstadoRueda(idrueda).Trim().Length == 0)
                    {
                        // Almacenamos todas las acciones compradas de la rueda del dia anterior a la rueda actual
                        _serviceRuedasDetalleSimulador.RegisterActionsYesterday(idrueda);
                    }

                    _service.SetAbrirRueda(idrueda);
                    txtEstado.Text = _service.GetEstadoRueda(idrueda);

                    // Obtengo el Panel Principal de Acciones con las correspondientes puntas
                    // y las almaceno en un vector de paneles
                    Operaciones Operar = new Operaciones();
                    PanelModel Panel = Operar.ObtenerPanel(permisoIOL.access_token);

                    // Recorro todo el panel de acciones obtenido en el codigo anterior
                    // Para verificar si puedo comprar o vender
                    // y almacenarlos en la Base de Datos
                    string simbolo = string.Empty;
                    double PrecioActualVenta = 0;
                    double PrecioActualCompra = 0;
                    double UltimoPrecio = 0;

                    if (Panel != null && Panel.titulos != null)
                    {
                        int nIdPanel = _servicePanelPrincipal.GetNextId(idrueda);
                        foreach (var registro in Panel.titulos)
                        {
                            simbolo = registro.simbolo.ToString();

                            try { PrecioActualCompra = Convert.ToDouble(registro.puntas.precioVenta); }
                            catch { PrecioActualCompra = 0; }

                            try { PrecioActualVenta = Convert.ToDouble(registro.puntas.precioCompra); }
                            catch { PrecioActualVenta = 0; }

                            try { UltimoPrecio = Convert.ToDouble(registro.ultimoprecio); }
                            catch { UltimoPrecio = 0; }

                            for (int indiceEstrategia1 = 1; indiceEstrategia1 <= 5; indiceEstrategia1++)
                            {
                                OperarEstrategiaUno(idrueda, indiceEstrategia1, simbolo, nIdPanel, PrecioActualCompra, PrecioActualVenta);
                            }

                            for (int indiceEstrategia2 = 6; indiceEstrategia2 <= 10; indiceEstrategia2++)
                            {
                                OperarEstrategiaDos(idrueda, indiceEstrategia2, simbolo, nIdPanel, PrecioActualCompra, PrecioActualVenta);
                            }

                            if (UltimoPrecio > 0)
                                _serviceRuedasDetalleSimulador.RegisterActionsPrice(idrueda, simbolo, (decimal)UltimoPrecio);

                            _serviceRuedasDetalleSimulador.UpdateVariations(idrueda);

                            double? _VariacionPorcentual = 0, _Apertura = 0, _Maximo = 0, _Minimo = 0,
                                   _UltimoCierre = 0, _Volumen = 0, _CantidadOperaciones = 0;
                            string _Fecha = string.Empty, _Mercado = string.Empty, _Moneda = string.Empty;
                            double? _PrecioCompra = 0, _PrecioVenta = 0, _CantidadCompra = 0, _CantidadVenta = 0, _UltimoPrecio = 0;

                            try { _VariacionPorcentual = registro.variacionPorcentual; } catch { _VariacionPorcentual = 0; }
                            try { _Apertura = registro.apertura; } catch { _Apertura = 0; }
                            try { _Maximo = registro.maximo; } catch { _Maximo = 0; }
                            try { _Minimo = registro.minimo; } catch { _Minimo = 0; }
                            try { _UltimoCierre = registro.ultimoCierre; } catch { _UltimoCierre = 0; }
                            try { _Volumen = registro.volumen; } catch { _Volumen = 0; }
                            try { _CantidadOperaciones = registro.cantidadOperaciones; } catch { _CantidadOperaciones = 0; }
                            try { _Fecha = registro.fecha; } catch { _Fecha = string.Empty; }
                            try { _Mercado = registro.mercado; } catch { _Mercado = string.Empty; }
                            try { _Moneda = registro.moneda; } catch { _Moneda = string.Empty; }
                            try { _PrecioCompra = registro.puntas.precioCompra; } catch { _PrecioCompra = 0; }
                            try { _PrecioVenta = registro.puntas.precioVenta; } catch { _PrecioVenta = 0; }
                            try { _CantidadCompra = registro.puntas.cantidadCompra; } catch { _CantidadCompra = 0; }
                            try { _CantidadVenta = registro.puntas.cantidadVenta; } catch { _CantidadVenta = 0; }
                            try { _UltimoPrecio = registro.ultimoprecio; } catch { _UltimoPrecio = 0; }

                            PanelPrincipal panel = new PanelPrincipal();
                            panel.IdRueda = idrueda;
                            panel.Simbolo = simbolo;
                            panel.VariacionPorcentual = _VariacionPorcentual.Value;
                            panel.Apertura = _Apertura.Value;
                            panel.Maximo = _Maximo.Value;
                            panel.Minimo = _Minimo.Value;
                            panel.UltimoCierre = _UltimoCierre.Value;
                            panel.Volumen = _Volumen.Value;
                            panel.CantidadDeOperaciones = _CantidadOperaciones.Value;
                            panel.Fecha = _Fecha;
                            panel.Mercado = _Mercado;
                            panel.Moneda = _Moneda;
                            panel.PuntaCompradoraP = _PrecioCompra.Value;
                            panel.PuntaVendedoraP = _PrecioVenta.Value;
                            panel.PuntaCompradoraC = _CantidadCompra.Value;
                            panel.PuntaVendedoraC = _CantidadVenta.Value;
                            panel.UltimoPrecio = _UltimoPrecio.Value;
                            panel.IdPanel = nIdPanel;

                            _servicePanelPrincipal.Register(panel);
                        }
                    }
                    ActualizarAcciones(); // Actualiza la grilla de acciones compradas
                }
            }
            txtEstado.Text = _service.GetEstadoRueda(idrueda);
            this.Refresh();
        }
        private void OperarEstrategiaUno(int IdRueda, int Simulador, string Simbolo, int IdPanel, double PrecioActualCompra, double PrecioActualVenta)
        {
            // Verifico cual fue mi ultima Operacion
            // Si estoy comprado o ya vendi mis posiciones

            int iddetalle = 0;
            double PrecioCompra = 0, CantidadComprada = 0, Importe = 0;

            RuedasDetalleSimulador regUltimaCompra = _serviceRuedasDetalleSimulador.GetLastPurchase(IdRueda, Simulador, Simbolo);
            if (regUltimaCompra != null)
            {
                iddetalle = regUltimaCompra.IdRuedaDetalle;
                PrecioCompra = (double)regUltimaCompra.PrecioCompra;
                CantidadComprada = (double)regUltimaCompra.Cantidad;
            }

            if (regUltimaCompra.Estado == "Compra") // Ultima operacion fue la compra de acciones
            {
                // Calcular
                // SI(PrecioCompra+(PrecioCompra*0,7%) < PrecioActual;"VENTA";"NEUTRO")
                double cantidadvendida = CantidadComprada;

                double resultado = PrecioCompra + (PrecioCompra * _serviceDatoSimulador.GetPorcVentaSimulador(IdRueda, Simulador) / 100);

                if (resultado < PrecioActualVenta)  // Vendemos
                {
                    // VENDER
                    // VENDER
                    // VENDER

                    // Obtener el porcentaje de incremento para la Venta
                    double porcincremento = 0;
                    try { porcincremento = Convert.ToDouble(txtPorcPuntaVendedora.Text); }
                    catch { porcincremento = 0; }

                    // Calcular el precio de la accion a vender con el incremento
                    double precioventa = PrecioActualVenta + (PrecioActualVenta * porcincremento / 100);

                    // Calcular el importe total a vender
                    Importe = (PrecioActualVenta + (PrecioActualVenta * porcincremento / 100)) * cantidadvendida;

                    if (cantidadvendida > 0)
                    {
                        _serviceRuedasDetalleSimulador.RegisterSale(iddetalle, IdRueda, precioventa, Importe);
                        _serviceTenenciaSimulador.SetActualizarTenenciaPorVenta(Simulador, Convert.ToDecimal(Importe));
                    }
                }
            }
            else // Ultima Operacion fue la venta de acciones o ninguna acción.
            {
                if (SeguirComprando(Convert.ToInt32(txtIdRueda.Text)))  // Si esta en horario de compra de acciones
                {
                    // Calcular
                    // =+SI(PROMEDIO(Ultimos tres precios)-(PROMEDIO(Ultimos tres precios)* SimuladorCompra%) > PrecioActual;"COMPRA";"NEUTRO")
                    double suma = 0, promedio1 = 0, promedio2 = 0, resultado = 0, precioactual = 0;

                    var regUltimosPrecios = _servicePanelPrincipal.GetLastThreeSeelingTip(IdRueda, Simbolo);
                    if (regUltimosPrecios != null && regUltimosPrecios.Count == 3)
                    {
                        foreach (double precio in regUltimosPrecios)
                        {
                            suma += precio;
                        }

                        promedio1 = suma / 3;
                        promedio2 = (suma / 3) * _serviceDatoSimulador.GetPorcCompraSimulador(IdRueda, Simulador) / 100;
                        resultado = promedio1 - promedio2;
                        precioactual = PrecioActualCompra;
                        if (resultado > precioactual)
                        {
                            // Obtener la cantidad de acciones compradas
                            int cantCompradas = _serviceRuedasDetalleSimulador.GetPurchasedAmount(IdRueda, Simulador);

                            // Calcular las acciones que quedan por comprar
                            int CantRestantes = 20 - cantCompradas;

                            // Si las acciones que quedan por comprar es mayor a cero
                            // calculo la cantidad a comprar
                            if (CantRestantes > 0)
                            {
                                // COMPRAR
                                // COMPRAR
                                // COMPRAR
                                // Obtener el porcentaje de Comision de IOL por compra
                                double porcomisionIOL = 0;
                                try { porcomisionIOL = Convert.ToDouble(txtPorcComisionIOL.Text); }
                                catch { porcomisionIOL = 0; }

                                // Calcular el Importe total para comprar acciones incluyendo Comision
                                double importe = _serviceTenenciaSimulador.GetDisponibleParaOperar(Simulador) / CantRestantes;

                                // Calcular la comision de Invertir Online
                                double comisionIOL = importe * porcomisionIOL / 100;

                                // Calcular el Importe total para comprar acciones sin la Comision de IOL
                                importe -= comisionIOL;

                                // Obtener el porcentaje de descuento para la compra
                                double porcdescuento = 0;
                                try { porcdescuento = Convert.ToDouble(txtPorcPuntaCompradora.Text); }
                                catch { porcdescuento = 0; }

                                // Calcular el precio de la accion a comprar con el descuento
                                double preciocompra = precioactual - (precioactual * porcdescuento / 100);

                                // Calcular la cantidad de acciones compradas
                                double cantidadcomprada = (int)(importe / preciocompra);

                                if (cantidadcomprada > 0)
                                {
                                    RuedasDetalleSimulador rueda = new RuedasDetalleSimulador();
                                    rueda.IdRuedaActual = IdRueda;
                                    rueda.IdRuedaCompra = IdRueda;
                                    rueda.IdSimulacion = Simulador;
                                    rueda.FechaCompra = DateTime.Now;
                                    rueda.Simbolo = Simbolo;
                                    rueda.Cantidad = (decimal)cantidadcomprada;
                                    rueda.PrecioCompra = (decimal)preciocompra;
                                    rueda.ImporteCompra = (decimal)importe;
                                    rueda.UltimoPrecio = (decimal)precioactual;
                                    rueda.FechaUltimoPrecio = DateTime.Now;
                                    rueda.Estado = "Comprado";
                                    rueda.PorcComisionIOL = Convert.ToDecimal(txtPorcComisionIOL.Text.Trim());
                                    rueda.ImporteComisionIOL = (decimal)comisionIOL;
                                    rueda.IdPanel = IdPanel;

                                    _serviceRuedasDetalleSimulador.Register(rueda);
                                    _serviceTenenciaSimulador.SetActualizarTenenciaPorCompra(Simulador, Convert.ToDecimal(Importe));
                                }
                            }
                        }
                    }
                }
            }
        }
        private void OperarEstrategiaDos(int IdRueda, int Simulador, string Simbolo, int IdPanel, double PrecioActualCompra, double PrecioActualVenta)
        {
            // Verifico cual fue mi ultima Operacion
            // Si estoy comprado o ya vendi mis posiciones

            int iddetalle = 0;
            string ultimaoperacion = string.Empty;
            double PrecioCompra = 0, CantidadVendida = 0, Importe = 0;

            double precioanterior, precioanteriorA, precioanteriorAA, resultado1, resultado2, resultado3;
            double precioactual = 0;

            RuedasDetalleSimulador regUltimaCompra = _serviceRuedasDetalleSimulador.GetLastPurchase(IdRueda, Simulador, Simbolo);
            if (regUltimaCompra != null)
            {
                iddetalle = regUltimaCompra.IdRuedaDetalle;
                PrecioCompra = (double)regUltimaCompra.PrecioCompra;
                CantidadVendida = (double)regUltimaCompra.Cantidad;
            }

            if (ultimaoperacion == "Compra") // Ultima operacion fue la compra de acciones
            {
                precioactual = PrecioActualVenta;
                // Calcular
                // =+SI(O(Y(D14>$B$4+($B$4*0.7%);D14<D13-(D13*0.25%);D13>D12);Y(D14>$B$4+($B$4*0.7%);D14<D12-(D12*0.25%);D12>D11));"VENTA";"NEUTRO")
                // SI (PrecioActual > PrecioCompra + (PrecioCompra * 0.7 %); PrecioActual < PrecioAnterior - (PrecioAnterior * 0.25 %); PrecioAnterior > PrecioAnteriorA) ENTONCES VENDER
                // SINO SI (PrecioActual > PrecioCompra + (PrecioCompra *0.7%); PrecioActual < PrecioAnteriorA - (PrecioAnteriorA * 0.25%);PrecioAnteriorA > PrecioAnteriorAA)) ENTONCES VENDER

                var ultimosPrecios = _servicePanelPrincipal.GetLastThreeBuyingTip(IdRueda, Simbolo);
                if (ultimosPrecios != null && ultimosPrecios.Count == 3)
                {
                    try { precioanterior = ultimosPrecios[2]; }
                    catch { precioanterior = 0; }

                    try { precioanteriorA = ultimosPrecios[1]; }
                    catch { precioanteriorA = 0; }

                    try { precioanteriorAA = ultimosPrecios[0]; }
                    catch { precioanteriorAA = 0; }

                    resultado1 = PrecioCompra + (PrecioCompra * 0.7 / 100);
                    resultado2 = precioanterior - (precioanterior * _serviceDatoSimulador.GetPorcVentaSimulador(IdRueda, Simulador) / 100);
                    resultado3 = precioanteriorA - (precioanteriorA * _serviceDatoSimulador.GetPorcVentaSimulador(IdRueda, Simulador) / 100);

                    bool lvender1 = precioactual > resultado1 && precioactual < resultado2 && precioanterior > precioanteriorA;
                    bool lvender2 = precioactual > resultado1 && precioactual < resultado3 && precioanteriorA > precioanteriorAA;

                    if (lvender1 || lvender2) // Vendemos
                    {
                        // VENDER
                        // VENDER
                        // VENDER

                        // Obtener el porcentaje de incremento para la Venta
                        double porcincremento;
                        try { porcincremento = Convert.ToDouble(txtPorcPuntaVendedora.Text); }
                        catch { porcincremento = 0; }

                        // Calcular el precio de la accion a vender con el incremento
                        double precioventa = PrecioActualVenta + (PrecioActualVenta * porcincremento / 100);

                        // Calcular el importe total a vender
                        Importe = (PrecioActualVenta + (PrecioActualVenta * porcincremento / 100)) * CantidadVendida;

                        if (CantidadVendida > 0)
                        {
                            _serviceRuedasDetalleSimulador.RegisterSale(iddetalle, IdRueda, precioventa, Importe);
                            _serviceTenenciaSimulador.SetActualizarTenenciaPorVenta(Simulador, Convert.ToDecimal(Importe));
                        }
                    }
                }
            }
            else // Ultima Operacion fue la venta de acciones o ninguna acción.
            {
                if (SeguirComprando(IdRueda)) // Si esta en horario de compra de acciones
                {
                    // Calcular
                    // SI PrecioActual > (PrecioAnterior + (PrecioAnterior * 0.05%)) Y (PrecioActual < PrecioAnterior) Entonces COMPRAR
                    // SINO SI(PrecioActual > (PrecioAnteriorA + (PrecioAnteriorA * 0.05%)) Y (PrecioAnteriorA < PrecioAnteriorAA) Entonces COMPRAR
                    // =+SI(Y(B4>B3+(B3*0.05%);B3<B2);"COMPRA";+SI(Y(B4>B2+(B2*0.05%);B2<B1);"COMPRA";"NEUTRO"))

                    var ultimosPrecios = _servicePanelPrincipal.GetLastThreeSeelingTip(IdRueda, Simbolo);
                    if (ultimosPrecios != null && ultimosPrecios.Count == 3)
                    {
                        precioactual = PrecioActualCompra;
                        try { precioanterior = ultimosPrecios[2]; }
                        catch { precioanterior = 0; }

                        try { precioanteriorA = ultimosPrecios[1]; }
                        catch { precioanteriorA = 0; }

                        try { precioanteriorAA = ultimosPrecios[0]; }
                        catch { precioanteriorAA = 0; }

                        resultado1 = precioanterior + (precioanterior * _serviceDatoSimulador.GetPorcCompraSimulador(IdRueda, Simulador) / 100);
                        resultado2 = precioanteriorA + (precioanteriorA * _serviceDatoSimulador.GetPorcCompraSimulador(IdRueda, Simulador) / 100);

                        bool lComprar1 = precioactual > resultado1 && precioactual < precioanterior;
                        bool lComprar2 = precioactual > resultado2 && precioanteriorA < precioanteriorAA;

                        if (lComprar1 || lComprar2) // COMPRAMOS
                        {
                            // Obtener la cantidad de acciones compradas
                            int cantCompradas = _serviceRuedasDetalleSimulador.GetPurchasedAmount(IdRueda, Simulador);

                            // Calcular las acciones que quedan por comprar
                            int CantRestantes = 20 - cantCompradas;

                            // Si las acciones que quedan por comprar es mayor a cero
                            // calculo la cantidad a comprar
                            if (CantRestantes > 0)
                            {
                                // COMPRAR
                                // COMPRAR
                                // COMPRAR
                                // Obtener el porcentaje de Comision de IOL por compra
                                double porcomisionIOL = 0;
                                try { porcomisionIOL = Convert.ToDouble(txtPorcComisionIOL.Text); }
                                catch { porcomisionIOL = 0; }

                                // Calcular el Importe total para comprar acciones incluyendo Comision
                                double importe = _serviceTenenciaSimulador.GetDisponibleParaOperar(Simulador) / CantRestantes;

                                // Calcular la comision de Invertir Online
                                double comisionIOL = importe * porcomisionIOL / 100;

                                // Calcular el Importe total para comprar acciones sin la Comision de IOL
                                importe -= comisionIOL;

                                // Obtener el porcentaje de descuento para la compra
                                double porcdescuento = 0;
                                try { porcdescuento = Convert.ToDouble(txtPorcPuntaCompradora.Text); }
                                catch { porcdescuento = 0; }

                                // Calcular el precio de la accion a comprar con el descuento
                                double preciocompra = precioactual - (precioactual * porcdescuento / 100);

                                // Calcular la cantidad de acciones compradas
                                double cantidadcomprada = (int)(importe / preciocompra);

                                if (cantidadcomprada > 0)
                                {
                                    RuedasDetalleSimulador rueda = new RuedasDetalleSimulador();
                                    rueda.IdRuedaActual = IdRueda;
                                    rueda.IdRuedaCompra = IdRueda;
                                    rueda.IdSimulacion = Simulador;
                                    rueda.FechaCompra = DateTime.Now;
                                    rueda.Simbolo = Simbolo;
                                    rueda.Cantidad = (decimal)cantidadcomprada;
                                    rueda.PrecioCompra = (decimal)preciocompra;
                                    rueda.ImporteCompra = (decimal)importe;
                                    rueda.UltimoPrecio = (decimal)precioactual;
                                    rueda.FechaUltimoPrecio = DateTime.Now;
                                    rueda.Estado = "Comprado";
                                    rueda.PorcComisionIOL = Convert.ToDecimal(txtPorcComisionIOL.Text.Trim());
                                    rueda.ImporteComisionIOL = (decimal)comisionIOL;
                                    rueda.IdPanel = IdPanel;

                                    _serviceRuedasDetalleSimulador.Register(rueda);
                                    _serviceTenenciaSimulador.SetActualizarTenenciaPorCompra(Simulador, Convert.ToDecimal(Importe));
                                }
                            }
                        }
                    }
                }
            }
        }
        private void txtInversionTotalSimulador_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtInversionTotalSimulador_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Inversion = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("$ {0:00.00}", Inversion);
        }
        private void txtInversionTotalSimulador_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void SeleccionarTexto(Object sender)
        {
            TextBox control = (TextBox)sender;
            control.SelectionStart = 0;
            control.SelectionLength = control.MaxLength;
        }
        private void dgvAccionesCompradas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAcciones.Columns["IdRuedaActual"].Visible = false;
            dgvAcciones.Columns["IdPanel"].Visible = false;
            dgvAcciones.Columns["PrecioVenta"].Visible = false;
            dgvAcciones.Columns["ImporteVenta"].Visible = false;
            dgvAcciones.Columns["IdRuedaDetalle"].Visible = false;
            dgvAcciones.Columns["IdRuedaCompra"].Visible = false;
            dgvAcciones.Columns["IdRuedaVenta"].Visible = false;
            dgvAcciones.Columns["IdSimulacion"].Visible = false;
            dgvAcciones.Columns["FechaVenta"].Visible = false;
            dgvAcciones.Columns["PorcComisionIOL"].Visible = false;
        }
        private void FormatoPorcentaje(object sender)
        {
            TextBox control = (TextBox)sender;

            decimal Porcentaje = 0;
            try { Porcentaje = Convert.ToDecimal(control.Text.Trim()); }
            catch { Porcentaje = 0; }

            control.Text = string.Format("{0:00.00}", Porcentaje);
        }
        private void nudSimulador_ValueChanged(object sender, EventArgs e)
        {
            ActualizarAcciones();
            int simulacion = 0;
            try { simulacion = Convert.ToInt32(nudSimulador.Value); }
            catch { simulacion = 0; }

            if (simulacion >= 1 && simulacion <= 5)
                lnkEstrategia.Text = "Estrategia Uno";
            else
                lnkEstrategia.Text = "Estrategia Dos";
        }
        private void btnActualizarSimulador_Click(object sender, EventArgs e)
        {
            bool lValidado = true;
            string Mensaje = string.Empty;

            int idRueda = 0;
            try { idRueda = Convert.ToInt32(txtIdRueda.Text.Trim()); }
            catch { idRueda = 0; }

            int idSimulador = 0;
            try { idSimulador = Convert.ToInt32(txtIdSimulador.Text.Trim()); }
            catch { idSimulador = 0; }

            decimal porccompra;
            try { porccompra = Convert.ToDecimal(txtPorcCompra.Text.Trim()); }
            catch { porccompra = 0; }

            decimal porcventa;
            try { porcventa = Convert.ToDecimal(txtPorcVenta.Text.Trim()); }
            catch { porcventa = 0; }

            if (idRueda > 0)
            {
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
                if (lValidado == false)
                {
                    MessageBox.Show(Mensaje, "Solicitud del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (MessageBox.Show("Datos Correctos ?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                try
                {
                    RuedasDatosSimulador ruedasDatosSimulador = new RuedasDatosSimulador();
                    ruedasDatosSimulador.IdRuedaSimulador = _serviceDatoSimulador.GetByIdSimulador(idRueda, idSimulador).IdRuedaSimulador;
                    ruedasDatosSimulador.IdRueda = idRueda;
                    ruedasDatosSimulador.IdSimulador = idSimulador;
                    ruedasDatosSimulador.PorcCompra = porccompra;
                    ruedasDatosSimulador.PorcVenta = porcventa;
                    _serviceDatoSimulador.Register(ruedasDatosSimulador);
                    Databases.SaveChanges();
                    MessageBox.Show("Simulador Actualizado con Exito", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " - " + ex.ToString(), "Informe de Errores", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void btnCerrarRueda_Click(object sender, EventArgs e)
        {
            int IdRueda = 0;
            try { IdRueda = Convert.ToInt32(txtIdRueda.Text.Trim()); }
            catch { IdRueda = 0; }
            if (IdRueda > 0)
            {
                if (MessageBox.Show("Desea Realizar el Cierre de la Rueda", "Pregunta del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string Estado = _service.GetEstadoRueda(IdRueda);
                    if (Estado == "Abierto")
                    {
                        _service.SetCerrarRueda(IdRueda);

                        // Calcular Variacion diaria
                        var acciones = _serviceAcciones.GetAll();
                        for (int simul = 1; simul < 11; simul++)
                            foreach (EntityFrameWork.Acciones regAcciones in acciones)
                            {
                                EntityFrameWork.InformeFinal informeFinal = new EntityFrameWork.InformeFinal();
                                informeFinal.IdFormeFinal = 0;
                                informeFinal.IdRueda = IdRueda;
                                informeFinal.Simulador = simul;
                                informeFinal.Simbolo = regAcciones.Simbolo;
                                informeFinal.VariacionDiaria = _serviceRuedasDetalleSimulador.GetDailyVariationPercentage(IdRueda, simul, regAcciones.Simbolo);
                                _serviceInformeFinal.Register(informeFinal);
                            }

                        // Eliminar Ruedas posteriores a las ultimas cinco
                        var regRuedas = _service.GetAll();
                        for (int x = 0; x < regRuedas.Count; x++)
                            if (x > 4)
                                _service.Delete(regRuedas[x].IdRueda);

                        // Cerrar Informe Final
                        _serviceInformeFinal.SetBestDailyVariation(IdRueda);
                        _serviceInformeFinal.SetBestweeklyVariation();
                        MessageBox.Show("Rueda cerrada Exitosamente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
        }
        private void ValidacionNumerica(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }
        private void txtPorcCompra_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcVenta_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcComisionIOL_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcPuntaCompradora_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcPuntaVendedora_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcCompra_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcComisionIOL_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcPuntaCompradora_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcPuntaVendedora_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcComisionIOL_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcPuntaCompradora_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcPuntaVendedora_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtTotalVariacionEnPorcentajes_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvAcciones_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow fila in dgvAcciones.Rows)
            {
                if (fila.Cells["Estado"].Value.ToString().Trim().ToUpper() == "COMPRADO")
                    fila.DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
                else
                    fila.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void btnActualizarRueda_Click(object sender, EventArgs e)
        {
            bool lValidado = true;
            string Mensaje = string.Empty;

            string sentencia = string.Empty;

            decimal porcCompra, porcVenta, porcComisionIOL, porcPuntaCompradora, porcPuntaVendedora;

            int IdRueda = 0;
            try { IdRueda = Convert.ToInt32(txtIdRueda.Text.Trim()); }
            catch { IdRueda = 0; }

            if (IdRueda > 0)
            {
                try { porcCompra = Convert.ToDecimal(txtPorcCompra.Text.Trim()); }
                catch { porcCompra = 0; }

                try { porcVenta = Convert.ToDecimal(txtPorcVenta.Text.Trim()); }
                catch { porcVenta = 0; }

                try { porcComisionIOL = Convert.ToDecimal(txtPorcComisionIOL.Text.Trim()); }
                catch { porcComisionIOL = 0; }

                try { porcPuntaCompradora = Convert.ToDecimal(txtPorcPuntaCompradora.Text.Trim()); }
                catch { porcPuntaCompradora = 0; }

                try { porcPuntaVendedora = Convert.ToDecimal(txtPorcPuntaVendedora.Text.Trim()); }
                catch { porcPuntaVendedora = 0; }

                if (porcCompra < 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Compra \r");
                    lValidado = false;
                }

                if (porcVenta < 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Venta \r");
                    lValidado = false;
                }

                if (porcComisionIOL < 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Comisión IOL \r");
                    lValidado = false;
                }

                if (porcPuntaCompradora < 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Punta Compradora \r");
                    lValidado = false;
                }

                if (porcPuntaVendedora < 0)
                {
                    Mensaje += String.Format("Ingrese Porcentaje de Punta Vendedora \r");
                    lValidado = false;
                }

                if (lValidado == false)
                {
                    MessageBox.Show(Mensaje, "Solicitud del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Datos Correctos ?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                try
                {
                    using (MySqlConnection cone = new MySqlConnection(conexion))
                    {
                        cone.Open();
                        sentencia = $"Update Ruedas Set PorcCompra = {porcCompra}, PorcVenta =  {porcVenta}, PorcComisionIOL = {porcComisionIOL}," +
                                                                    $"PorcPuntaCompradora = {porcPuntaCompradora}, PorcPuntaVendedora = {porcPuntaVendedora} " +
                                                                    $" Where IdRueda = {IdRueda}";

                        MySqlCommand comando = new MySqlCommand(sentencia, cone);
                        comando.ExecuteNonQuery();
                        cone.Close();
                        MessageBox.Show("Simulador Actualizado con Exito", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message + " - " + ex.ErrorCode.ToString(), "Informe de Errores", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private bool SeguirComprando(int rueda)
        {
            int horaActual = DateTime.Now.Hour;
            int horaHasta = Databases.Ruedas.Where(x => x.IdRueda == rueda).SingleOrDefault().ComprarHasta;
            return horaActual >= 11 && horaActual < horaHasta;
        }
        private void txtPorcCompraSimulador_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcVentaSimulador_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcCompraSimulador_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVentaSimulador_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompraSimulador_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVentaSimulador_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
    }
}

