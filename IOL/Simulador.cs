using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using IOL.EntityFrameWork;
using IOL.Servicios;
using System.Linq;

namespace IOL
{
    public partial class Simulador : Form
    {
        private readonly ServiciosRueda _service = new ServiciosRueda();
        private readonly ServiciosFeriado _serviceFeriado = new ServiciosFeriado();
        private readonly ServiciosDatosSimulador _serviceDatoSimulador = new ServiciosDatosSimulador();
        private readonly ServiciosTenenciaSimulador _serviceTenenciaSimulador = new ServiciosTenenciaSimulador();
        private readonly ServiciosRuedasDetalleSimulador _serviceRuedasDetalleSimulador = new ServiciosRuedasDetalleSimulador();
        BD Bd = new BD();

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

                txtPorcCompra1.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda,1));
                txtPorcCompra2.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda, 2));
                txtPorcCompra3.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda, 3));
                txtPorcCompra4.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda, 4));
                txtPorcCompra5.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda, 5));
                txtPorcCompra6.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda, 6));
                txtPorcCompra7.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda, 7));
                txtPorcCompra8.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda, 8));
                txtPorcCompra9.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda, 9));
                txtPorcCompra10.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcCompraSimulador(ruedaactual.IdRueda, 10));

                txtPorcVenta1.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 1));
                txtPorcVenta2.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 2));
                txtPorcVenta3.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 3));
                txtPorcVenta4.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 4));
                txtPorcVenta5.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 5));
                txtPorcVenta6.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 6));
                txtPorcVenta7.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 7));
                txtPorcVenta8.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 8));
                txtPorcVenta9.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 9));
                txtPorcVenta10.Text = string.Format("{0:00.00}", _serviceDatoSimulador.GetPorcVentaSimulador(ruedaactual.IdRueda, 10));

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
            MySqlConnection cone = new MySqlConnection(conexion);
            string sentencia = string.Empty;
            sentencia = $"Update Ruedas Set AccesosIOL = AccesosIOL + 1 Where IdRueda = {txtIdRueda.Text.Trim()}";
            cone.Open();
            MySqlCommand comando = new MySqlCommand(sentencia, cone);
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            cone.Close();

            sentencia = $"Select * From Ruedas Where IdRueda = {txtIdRueda.Text.Trim()}";
            MySqlConnection coneRuedas = new MySqlConnection(conexion);
            MySqlDataAdapter daRuedas = new MySqlDataAdapter(sentencia, coneRuedas);
            DataTable dsRuedas = new DataTable();
            daRuedas.Fill(dsRuedas);
            if (dsRuedas.Rows.Count > 0)
                return Convert.ToInt32((dsRuedas.Rows[0]["AccesosIOL"] is DBNull) ? 0 : dsRuedas.Rows[0]["AccesosIOL"]);
            else
                return 0;
        }

        private void ActualizarAcciones()
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

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
            string sentencia = string.Empty;

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

                        int nIdPanel = 0;
                        MySqlConnection coneUltimoIndicePanel = new MySqlConnection(conexion);
                        sentencia = string.Format("Select Max(IdPanel) as UltimoIdPanel From PanelPrincipal Where IdRueda = {0} ", idrueda);
                        MySqlDataAdapter daUltimoIndicePanel = new MySqlDataAdapter(sentencia, coneUltimoIndicePanel);
                        DataTable dsUltimoIndicePanel = new DataTable();
                        int regUltimoIndicePanel = daUltimoIndicePanel.Fill(dsUltimoIndicePanel);
                        coneUltimoIndicePanel.Close();
                        if (regUltimoIndicePanel > 0)
                        {
                            try { nIdPanel = Convert.ToInt32(dsUltimoIndicePanel.Rows[0]["UltimoIdPanel"]) + 1; }
                            catch { nIdPanel = 1; }
                        }
                        else
                            nIdPanel = 1;


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
                            {
                                using (MySqlConnection cone = new MySqlConnection(conexion))
                                {
                                    cone.Open();
                                    sentencia = $"Update RuedasDetalleSimulador Set UltimoPrecio = {UltimoPrecio}," +
                                                              $" FechaUltimoPrecio = str_to_date('{DateTime.Now}','%d/%m/%Y %H:%i:%s') " +
                                                              $" Where IdRuedaActual = {idrueda} And Simbolo = '{simbolo}' And Estado = 'Comprado'";
                                    MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                    comando.CommandType = CommandType.Text;
                                    comando.ExecuteNonQuery();
                                    cone.Close();
                                }
                            }

                            using (MySqlConnection cone = new MySqlConnection(conexion))
                            {
                                cone.Open();
                                sentencia = $"Update RuedasDetalleSimulador Set " +
                                            $"VariacionenPesos = (UltimoPrecio - PrecioCompra) * cantidad," +
                                            $"VariacionenPorcentajes = ((UltimoPrecio / preciocompra) - 1) * 100 " +
                                            $"Where IdRuedaActual = {idrueda} And Estado = 'Comprado' And UltimoPrecio > 0";

                                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                cone.Close();
                            }

                            using (MySqlConnection cone = new MySqlConnection(conexion))
                            {
                                cone.Open();
                                sentencia = $"Update RuedasDetalleSimulador Set " +
                                            $"VariacionenPesos = 0, " +
                                            $"VariacionenPorcentajes = 0 " +
                                            $"Where IdRuedaActual = {idrueda} And Estado = 'Comprado' And Simbolo = '{simbolo}' And UltimoPrecio = 0";
                                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                cone.Close();
                            }

                            using (MySqlConnection cone = new MySqlConnection(conexion))
                            {
                                cone.Open();
                                sentencia = $"Update RuedasDetalleSimulador Set " +
                                            $"VariacionenPesos = (PrecioVenta - PrecioCompra) * cantidad," +
                                            $"VariacionenPorcentajes = ((PrecioVenta / PrecioCompra) - 1) * 100 " +
                                            $" Where IdRuedaActual = {idrueda} And Estado = 'Vendido'";
                                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                cone.Close();
                            }

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

                            using (MySqlConnection cone = new MySqlConnection(conexion))
                            {
                                cone.Open();
                                sentencia = $"Insert Into PanelPrincipal(IdRueda, Simbolo," +
                                                          $"VariacionPorcentual, Apertura, Maximo, Minimo," +
                                                          $"UltimoCierre, Volumen, CantidadDeOperaciones, Fecha," +
                                                          $"mercado, Moneda," +
                                                          $"PuntaCompradoraP, PuntaVendedoraP," +
                                                          $"PuntaCompradoraC, PuntaVendedoraC, UltimoPrecio, IdPanel)" +
                                                          $" Values ({idrueda}, '{simbolo}'," +
                                                          $"{_VariacionPorcentual}, {_Apertura}, {_Maximo}, {_Minimo}," +
                                                          $"{_UltimoCierre}, {_Volumen}, {_CantidadOperaciones},'{_Fecha}'," +
                                                          $"'{_Mercado}', '{_Moneda}'," +
                                                          $"{_PrecioCompra}, {_PrecioVenta}," +
                                                          $"{_CantidadCompra}, {_CantidadVenta}, {_UltimoPrecio}, {nIdPanel})";
                                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                cone.Close();
                            }

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
            string ultimaoperacion = string.Empty;
            double PrecioCompra = 0, CantidadComprada = 0, Importe = 0;

            MySqlConnection coneUltimaOperacion = new MySqlConnection(conexion);
            string sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0} ", IdRueda);
            sentencia += string.Format(" And IdSimulacion = {0} And Estado = 'Comprado' And Simbolo = '{1}' ", Simulador, Simbolo);
            MySqlDataAdapter daUltimaOperacion = new MySqlDataAdapter(sentencia, coneUltimaOperacion);
            DataTable dsUltimoOperacion = new DataTable();
            int regUltimaOperacion = daUltimaOperacion.Fill(dsUltimoOperacion);
            coneUltimaOperacion.Close();
            if (regUltimaOperacion > 0)
            {
                ultimaoperacion = "Compra";
                iddetalle = Convert.ToInt32(dsUltimoOperacion.Rows[0]["IdRuedaDetalle"]);
                PrecioCompra = Convert.ToDouble(dsUltimoOperacion.Rows[0]["PrecioCompra"]);
                CantidadComprada = Convert.ToDouble(dsUltimoOperacion.Rows[0]["Cantidad"]);
            }

            if (ultimaoperacion == "Compra") // Ultima operacion fue la compra de acciones
            {
                // Calcular
                // SI(PrecioCompra+(PrecioCompra*0,7%) < PrecioActual;"VENTA";"NEUTRO")
                double resultado = 0, cantidadvendida = CantidadComprada;

                resultado = PrecioCompra + (PrecioCompra * _serviceDatoSimulador.GetPorcVentaSimulador(IdRueda, Simulador) / 100);

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
                        using (MySqlConnection cone = new MySqlConnection(conexion))
                        {
                            cone.Open();
                            sentencia = $"Update RuedasDetalleSimulador Set " +
                                        $" PrecioVenta = {precioventa}, ImporteVenta = {Importe}, FechaVenta = str_to_date('{DateTime.Now}','%d/%m/%Y %H:%i:%s') , Estado = 'Vendido'," +
                                        $"UltimoPrecio = {precioventa}, FechaUltimoPrecio = str_to_date('{DateTime.Now}','%d/%m/%Y %H:%i:%s')," +
                                        $"IdRuedaVenta = {IdRueda}  Where IdRuedaDetalle = {iddetalle}";
                            MySqlCommand comando = new MySqlCommand(sentencia, cone);
                            comando.CommandType = CommandType.Text;
                            comando.ExecuteNonQuery();
                            cone.Close();
                        }
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

                    MySqlConnection coneUltimosPrecios = new MySqlConnection(conexion);
                    sentencia = string.Format("Select Distinct PuntaVendedoraP as PuntaVendedora From PanelPrincipal Where IdRueda = {0} And IdPanel < {1} And Simbolo = '{2}' Order By IdPanel Desc Limit 3 ", IdRueda, IdPanel, Simbolo);
                    MySqlDataAdapter daUltimosPrecios = new MySqlDataAdapter(sentencia, coneUltimosPrecios);
                    DataTable dsUltimosPrecios = new DataTable();
                    int regUltimosPrecios = daUltimosPrecios.Fill(dsUltimosPrecios);
                    coneUltimosPrecios.Close();
                    if (regUltimosPrecios == 3)
                    {
                        foreach (DataRow Fila in dsUltimosPrecios.Rows)
                        {
                            suma += Convert.ToDouble(Fila["PuntaVendedora"]);
                        }
                    }

                    if (regUltimosPrecios == 3)
                    {
                        promedio1 = suma / 3;
                        promedio2 = (suma / 3) * _serviceDatoSimulador.GetPorcCompraSimulador(IdRueda, Simulador) / 100;
                        resultado = promedio1 - promedio2;
                        precioactual = PrecioActualCompra;
                        if (resultado > precioactual)
                        {
                            // Obtener la cantidad de acciones compradas
                            int cantCompradas = 0;

                            MySqlConnection coneAccionesCompradas = new MySqlConnection(conexion);
                            sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0} And Estado = 'Comprado'" +
                                " And IdSimulacion = {1}", IdRueda, Simulador);
                            MySqlDataAdapter daAccionesCompradas = new MySqlDataAdapter(sentencia, coneAccionesCompradas);
                            DataTable dsAccionesCompradas = new DataTable();
                            cantCompradas = daAccionesCompradas.Fill(dsAccionesCompradas);

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
                                    using (MySqlConnection cone = new MySqlConnection(conexion))
                                    {
                                        cone.Open();
                                        sentencia = $"Insert Into RuedasDetalleSimulador(IdRuedaActual, IdRuedaCompra, IdSimulacion, " +
                                                                  $"FechaCompra, Simbolo, Cantidad, " +
                                                                  $"PrecioCompra, ImporteCompra, UltimoPrecio," +
                                                                  $"FechaUltimoPrecio," +
                                                                  $"Estado, PorcComisionIOL, ImporteComisionIOL, IdPanel) " +
                                                                  $"Values({IdRueda}, {IdRueda}, {Simulador}, " +
                                                                  $"str_to_date('{DateTime.Now}','%d/%m/%Y %H:%i:%s'),'{Simbolo}',{cantidadcomprada}, " +
                                                                  $"{preciocompra},{importe},{precioactual}," +
                                                                  $"str_to_date('{DateTime.Now}','%d/%m/%Y %H:%i:%s')," +
                                                                  $"'Comprado',{txtPorcComisionIOL.Text.Trim()},{comisionIOL},{IdPanel})";
                                        MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                        comando.CommandType = CommandType.Text;
                                        comando.ExecuteNonQuery();
                                        cone.Close();
                                    }
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

            MySqlConnection coneUltimaOperacion = new MySqlConnection(conexion);
            string sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0} ", IdRueda);
            sentencia += string.Format(" And IdSimulacion = {0} And Estado = 'Comprado' And Simbolo = '{1}' ", Simulador, Simbolo);
            MySqlDataAdapter daUltimaOperacion = new MySqlDataAdapter(sentencia, coneUltimaOperacion);
            DataTable dsUltimoOperacion = new DataTable();
            int regUltimaOperacion = daUltimaOperacion.Fill(dsUltimoOperacion);
            coneUltimaOperacion.Close();
            if (regUltimaOperacion > 0)
            {
                ultimaoperacion = "Compra";
                iddetalle = Convert.ToInt32(dsUltimoOperacion.Rows[0]["IdRuedaDetalle"]);
                PrecioCompra = Convert.ToDouble(dsUltimoOperacion.Rows[0]["PrecioCompra"]);
                CantidadVendida = Convert.ToDouble(dsUltimoOperacion.Rows[0]["Cantidad"]);
            }

            if (ultimaoperacion == "Compra") // Ultima operacion fue la compra de acciones
            {
                precioactual = PrecioActualVenta;
                // Calcular
                // =+SI(O(Y(D14>$B$4+($B$4*0.7%);D14<D13-(D13*0.25%);D13>D12);Y(D14>$B$4+($B$4*0.7%);D14<D12-(D12*0.25%);D12>D11));"VENTA";"NEUTRO")
                // SI (PrecioActual > PrecioCompra + (PrecioCompra * 0.7 %); PrecioActual < PrecioAnterior - (PrecioAnterior * 0.25 %); PrecioAnterior > PrecioAnteriorA) ENTONCES VENDER
                // SINO SI (PrecioActual > PrecioCompra + (PrecioCompra *0.7%); PrecioActual < PrecioAnteriorA - (PrecioAnteriorA * 0.25%);PrecioAnteriorA > PrecioAnteriorAA)) ENTONCES VENDER

                MySqlConnection coneUltimosPreciosVenta = new MySqlConnection(conexion);
                sentencia = string.Format("Select Distinct PuntaCompradoraP as Precio From PanelPrincipal Where IdRueda = {0} And Simbolo = '{1}' Order By IdPanel Desc Limit 3", IdRueda, Simbolo);
                MySqlDataAdapter daUltimosPreciosVenta = new MySqlDataAdapter(sentencia, coneUltimosPreciosVenta);
                DataTable dsUltimosPreciosVenta = new DataTable();
                int regUltimosPreciosVenta = daUltimosPreciosVenta.Fill(dsUltimosPreciosVenta);
                coneUltimosPreciosVenta.Close();

                if (regUltimosPreciosVenta == 3)
                {
                    try { precioanterior = Convert.ToDouble(dsUltimosPreciosVenta.Rows[2]["Precio"]); }
                    catch { precioanterior = 0; }

                    try { precioanteriorA = Convert.ToDouble(dsUltimosPreciosVenta.Rows[1]["Precio"]); }
                    catch { precioanteriorA = 0; }

                    try { precioanteriorAA = Convert.ToDouble(dsUltimosPreciosVenta.Rows[0]["Precio"]); }
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
                            using (MySqlConnection cone = new MySqlConnection(conexion))
                            {
                                cone.Open();
                                sentencia = $"Update RuedasDetalleSimulador Set " +
                                                    $" PrecioVenta = {precioventa}, ImporteVenta = {Importe}, FechaVenta = str_to_date('{DateTime.Now}','%d/%m/%Y %H:%i:%s') , Estado = 'Vendido'," +
                                                    $"UltimoPrecio = {precioventa}, FechaUltimoPrecio = str_to_date('{DateTime.Now}','%d/%m/%Y %H:%i:%s')," +
                                                    $"IdRuedaVenta = {IdRueda}  Where IdRuedaDetalle = {iddetalle}";

                                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                cone.Close();
                            }

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

                    MySqlConnection coneUltimosPrecios = new MySqlConnection(conexion);
                    sentencia = string.Format("Select Distinct PuntaVendedoraP as Precio From PanelPrincipal Where IdRueda = {0} And Simbolo = '{1}' Order By IdPanel Desc Limit 3 ", IdRueda, Simbolo);
                    MySqlDataAdapter daUltimosPrecios = new MySqlDataAdapter(sentencia, coneUltimosPrecios);
                    DataTable dsUltimosPrecios = new DataTable();
                    int regUltimosPrecios = daUltimosPrecios.Fill(dsUltimosPrecios);
                    coneUltimosPrecios.Close();
                    if (regUltimosPrecios == 3)
                    {
                        precioactual = PrecioActualCompra;
                        try { precioanterior = Convert.ToDouble(dsUltimosPrecios.Rows[2]["Precio"]); }
                        catch { precioanterior = 0; }

                        try { precioanteriorA = Convert.ToDouble(dsUltimosPrecios.Rows[1]["Precio"]); }
                        catch { precioanteriorA = 0; }

                        try { precioanteriorAA = Convert.ToDouble(dsUltimosPrecios.Rows[0]["Precio"]); }
                        catch { precioanteriorAA = 0; }

                        resultado1 = precioanterior + (precioanterior * _serviceDatoSimulador.GetPorcCompraSimulador(IdRueda, Simulador) / 100);
                        resultado2 = precioanteriorA + (precioanteriorA * _serviceDatoSimulador.GetPorcCompraSimulador(IdRueda, Simulador) / 100);

                        bool lComprar1 = precioactual > resultado1 && precioactual < precioanterior;
                        bool lComprar2 = precioactual > resultado2 && precioanteriorA < precioanteriorAA;

                        if (lComprar1 || lComprar2) // COMPRAMOS
                        {
                            // Obtener la cantidad de acciones compradas
                            int cantCompradas = 0;

                            MySqlConnection coneAccionesCompradas = new MySqlConnection(conexion);
                            sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0} And Estado = 'Comprado'" +
                                " And IdSimulacion = {1}", IdRueda, Simulador);
                            MySqlDataAdapter daAccionesCompradas = new MySqlDataAdapter(sentencia, coneAccionesCompradas);
                            DataTable dsAccionesCompradas = new DataTable();
                            cantCompradas = daAccionesCompradas.Fill(dsAccionesCompradas);

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
                                    using (MySqlConnection cone = new MySqlConnection(conexion))
                                    {
                                        cone.Open();
                                        sentencia = $"Insert Into RuedasDetalleSimulador(IdRuedaActual, IdRuedaCompra, IdSimulacion, " +
                                                                  $"FechaCompra, Simbolo, Cantidad, " +
                                                                  $"PrecioCompra, ImporteCompra, UltimoPrecio," +
                                                                  $"FechaUltimoPrecio," +
                                                                  $"Estado, PorcComisionIOL, ImporteComisionIOL, IdPanel) " +
                                                                  $"Values({IdRueda}, {IdRueda}, {Simulador}, " +
                                                                  $"str_to_date('{DateTime.Now}','%d/%m/%Y %H:%i:%s'),'{Simbolo}',{cantidadcomprada}, " +
                                                                  $"{preciocompra},{importe},{precioactual}," +
                                                                  $"str_to_date('{DateTime.Now}','%d/%m/%Y %H:%i:%s')," +
                                                                  $"'Comprado',{txtPorcComisionIOL.Text.Trim()},{comisionIOL},{IdPanel})";

                                        MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                        comando.CommandType = CommandType.Text;
                                        comando.ExecuteNonQuery();
                                        cone.Close();
                                    }
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
        private void txtPorcCompra1_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcVenta1_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcCompra2_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcVenta2_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcCompra3_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcVenta3_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcCompra4_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcVenta4_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcCompra5_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcVenta5_Click(object sender, EventArgs e)
        {
            SeleccionarTexto(sender);
        }
        private void txtPorcCompra1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompra2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompra3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompra4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompra5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompra1_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta1_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcCompra2_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta2_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcCompra3_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta3_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcCompra4_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta4_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcCompra5_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta5_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
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
            ValidacionNumerica(e);
        }
        private void txtPorcCompra7_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompra8_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompra9_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompra10_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta6_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta7_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta8_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta9_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcVenta10_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionNumerica(e);
        }
        private void txtPorcCompra6_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcCompra7_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcCompra8_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcCompra9_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcCompra10_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta6_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta7_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta8_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta9_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void txtPorcVenta10_Leave(object sender, EventArgs e)
        {
            FormatoPorcentaje(sender);
        }
        private void FormatoPorcentaje(object sender)
        {
            TextBox control = (TextBox)sender;

            decimal Porcentaje = 0;
            try { Porcentaje = Convert.ToDecimal(control.Text.Trim()); }
            catch { Porcentaje = 0;}

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

            string sentencia = string.Empty;

            decimal porccompra1, porccompra2, porccompra3, porccompra4, porccompra5, porccompra6, porccompra7,
                    porccompra8, porccompra9, porccompra10, porcventa1, porcventa2, porcventa3, porcventa4,
                    porcventa5, porcventa6, porcventa7, porcventa8, porcventa9, porcventa10;

            int IdRueda = 0;
            try { IdRueda = Convert.ToInt32(txtIdRueda.Text.Trim()); }
            catch { IdRueda = 0; }

            if (IdRueda > 0)
            {

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
                        sentencia = $"Update Ruedas Set PorcCompra1 =  {porccompra1}, PorcVenta1 =   {porcventa1}, PorcCompra2 =  {porccompra2}," +
                                                                    $"PorcVenta2 =   {porcventa2}, PorcCompra3 =  {porccompra3}, PorcVenta3 =   {porcventa3}," +
                                                                    $"PorcCompra4 =  {porccompra4}, PorcVenta4 =  {porcventa4}, PorcCompra5 =  {porccompra5}," +
                                                                    $"PorcVenta5 =   {porcventa5}, PorcCompra6 =  {porccompra6}, PorcVenta6 =   {porcventa6}, " +
                                                                    $"PorcCompra7 =  {porccompra7}, PorcVenta7 =   {porcventa7}, PorcCompra8 =  {porccompra8}," +
                                                                    $"PorcVenta8 =   {porcventa8}, PorcCompra9 =  {porccompra9}, PorcVenta9 =  {porcventa9}," +
                                                                    $"PorcCompra10 = {porccompra10}, PorcVenta10 =  {porcventa10} " +
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
        private void btnCerrarRueda_Click(object sender, EventArgs e)
        {
            int IdRueda = 0;
            try { IdRueda = Convert.ToInt32(txtIdRueda.Text.Trim()); }
            catch { IdRueda = 0; }
            if (IdRueda > 0)
            {
                if (MessageBox.Show("Desea Realizar el Cierre de la Rueda", "Pregunta del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    MySqlConnection coneRuedaFinalizada = new MySqlConnection(conexion);
                    string sentencia = string.Format("Select * From Ruedas Where IdRueda = {0} And Estado = 'Abierto'", txtIdRueda.Text.Trim());
                    MySqlDataAdapter daRuedaFinalizada = new MySqlDataAdapter(sentencia, coneRuedaFinalizada);
                    DataTable dsRuedaFinalizada = new DataTable();
                    int regRuedaFinalizada = daRuedaFinalizada.Fill(dsRuedaFinalizada);
                    coneRuedaFinalizada.Close();
                    if (regRuedaFinalizada == 1)
                    {

                        _service.SetCerrarRueda(IdRueda);

                        // Agregar Informe Final
                        sentencia = "InformeFinalAgregar";
                        using (MySqlConnection coneAcciones = new MySqlConnection(conexion))
                        {
                            coneAcciones.Open();
                            var comandoAcciones = new MySqlCommand(sentencia, coneAcciones);
                            comandoAcciones.CommandType = CommandType.StoredProcedure;
                            comandoAcciones.Parameters.AddWithValue("Rueda", IdRueda);
                            comandoAcciones.ExecuteNonQuery();
                            coneAcciones.Close();
                        }

                        // Calcular Variacion diaria
                        MySqlConnection coneVariacionDiaria = new MySqlConnection(conexion);
                        sentencia = string.Format("Select * From InformeFinal Where IdRueda = {0}", txtIdRueda.Text.Trim());
                        MySqlDataAdapter daVariacionDiaria = new MySqlDataAdapter(sentencia, coneVariacionDiaria);
                        DataTable dsVariacionDiaria = new DataTable();
                        int regVariacionDiaria = daVariacionDiaria.Fill(dsVariacionDiaria);
                        coneVariacionDiaria.Close();
                        if (regVariacionDiaria > 1)
                        {
                            foreach (DataRow filaInforme in dsVariacionDiaria.Rows)
                            {
                                for (int sim = 1; sim < 11; sim++)
                                {
                                    sentencia = $"Update InformeFinal Set Variacion{sim}Diaria = (Select Sum(variacionenporcentajes) " +
                                                $" From RuedasDetalleSimulador " +
                                                $" Where RuedasDetalleSimulador.IdRuedaVenta = {Convert.ToInt32(filaInforme["IdRueda"])} " +
                                                $" And RuedasDetalleSimulador.Simbolo = '{filaInforme["Simbolo"].ToString()}'" +
                                                $" And RuedasDetalleSimulador.IdRuedaVenta = {Convert.ToInt32(filaInforme["IdRueda"])} " +
                                                $" And RuedasDetalleSimulador.Estado = 'Vendido' " +
                                                $" And RuedasDetalleSimulador.IdSimulacion = {sim}) " +
                                                $" Where InformeFinal.IdRueda = {Convert.ToInt32(filaInforme["IdRueda"])} And InformeFinal.Simbolo = '{filaInforme["Simbolo"].ToString()}'";

                                    using (MySqlConnection coneActualizarInforme = new MySqlConnection(conexion))
                                    {
                                        coneActualizarInforme.Open();
                                        var comandoActualizarInforme = new MySqlCommand(sentencia, coneActualizarInforme);
                                        comandoActualizarInforme.CommandType = CommandType.Text;
                                        comandoActualizarInforme.ExecuteNonQuery();
                                        coneActualizarInforme.Close();
                                    }
                                }
                            }
                        }
                        //
                        // Eliminar Ruedas
                        using (MySqlConnection coneMostrarRuedas = new MySqlConnection(conexion))
                        {
                            sentencia = "Select IdRueda From Ruedas Order By IdRueda Desc";
                            MySqlDataAdapter daMostrarRuedas = new MySqlDataAdapter(sentencia, coneMostrarRuedas);
                            DataTable dsMostrarRuedas = new DataTable();
                            int regUltimasRuedas = daMostrarRuedas.Fill(dsMostrarRuedas);
                            coneMostrarRuedas.Close();
                            if (regUltimasRuedas > 5)
                            {
                                for (int x = 5; x < dsMostrarRuedas.Rows.Count; x++)
                                {
                                    DataRow fila = dsMostrarRuedas.Rows[x];
                                    sentencia = "EliminarRuedas";
                                    using (MySqlConnection coneEliminarRuedas = new MySqlConnection(conexion))
                                    {
                                        coneEliminarRuedas.Open();
                                        var comandoEliminarRuedas = new MySqlCommand(sentencia, coneEliminarRuedas);
                                        comandoEliminarRuedas.CommandType = CommandType.StoredProcedure;
                                        comandoEliminarRuedas.Parameters.AddWithValue("Rueda", Convert.ToInt32(fila["IdRueda"]));
                                        comandoEliminarRuedas.ExecuteNonQuery();
                                        coneEliminarRuedas.Close();
                                    }
                                }
                            }

                            // Cerrar Informe Final
                            using (MySqlConnection coneMostrarInforme = new MySqlConnection(conexion))
                            {
                                sentencia = $"Select IdRueda, Variacion1Diaria, Variacion2Diaria, Variacion3Diaria," +
                                    $" Variacion4Diaria,Variacion5Diaria,Variacion6Diaria," +
                                    $"Variacion7Diaria,Variacion8Diaria,Variacion9Diaria," +
                                    $"Variacion10Diaria, Simbolo From InformeFinal Where IdRueda = {IdRueda}";
                                MySqlDataAdapter daMostrarInforme = new MySqlDataAdapter(sentencia, coneMostrarInforme);
                                DataTable dsMostrarInforme = new DataTable();
                                int regInformes = daMostrarInforme.Fill(dsMostrarInforme);
                                coneMostrarInforme.Close();
                                foreach (DataRow fila in dsMostrarInforme.Rows)
                                {
                                    string simbolo = fila["Simbolo"].ToString();
                                    
                                    decimal var1;
                                    try { var1 = Convert.ToDecimal(fila[1]);}
                                    catch { var1 = 0; }

                                    decimal var2;
                                    try { var2 = Convert.ToDecimal(fila[2]); }
                                    catch { var2 = 0; }

                                    decimal var3;
                                    try { var3 = Convert.ToDecimal(fila[3]); }
                                    catch { var3 = 0; }

                                    decimal var4;
                                    try { var4 = Convert.ToDecimal(fila[4]); }
                                    catch { var4 = 0; }

                                    decimal var5;
                                    try { var5 = Convert.ToDecimal(fila[5]); }
                                    catch { var5 = 0; }

                                    decimal var6;
                                    try { var6 = Convert.ToDecimal(fila[6]); }
                                    catch { var6 = 0; }

                                    decimal var7;
                                    try { var7 = Convert.ToDecimal(fila[7]); }
                                    catch { var7 = 0; }

                                    decimal var8;
                                    try { var8 = Convert.ToDecimal(fila[8]); }
                                    catch { var8 = 0; }

                                    decimal var9;
                                    try { var9 = Convert.ToDecimal(fila[9]); }
                                    catch { var9 = 0; }

                                    decimal var10;
                                    try { var10 = Convert.ToDecimal(fila[10]); }
                                    catch { var10 = 0; }

                                    decimal[] Variacion = { 0 , var1, var2, var3,
                                                                var4, var5, var6,
                                                                var7, var8, var9, var10 };
                                    decimal maxVariacion = Variacion[1];
                                    int maxSimulador = 1;
                                    for (int x = 2; x < Variacion.Length; x++)
                                    {
                                        if (Variacion[x] > maxVariacion)
                                        {
                                            maxVariacion = Variacion[x];
                                            maxSimulador = x;
                                        }
                                    }

                                    sentencia = $"Update InformeFinal Set MejorVariacionDiaria = {maxVariacion}, MejorVariacionDiariaSimulador = {maxSimulador} " +
                                                $" Where IdRueda = {IdRueda} And Simbolo = '{simbolo}'";
                                    using (MySqlConnection coneCerrarInformeFinal = new MySqlConnection(conexion))
                                    {
                                        coneCerrarInformeFinal.Open();
                                        var comandoCerrarInformeFinal = new MySqlCommand(sentencia, coneCerrarInformeFinal);
                                        comandoCerrarInformeFinal.ExecuteNonQuery();
                                        coneCerrarInformeFinal.Close();
                                    }
                                }

                                // Cerrar Informe Final
                                using (MySqlConnection coneCerrarInforme = new MySqlConnection(conexion))
                                {
                                    sentencia = "Select* From" +
                                                " (Select simbolo," +
                                                " MejorVariacionDiariaSimulador as Simulador," +
                                                " ROW_NUMBER() Over(Partition By Simbolo Order By MejorVariacionDiariaSimulador desc) as orden," +
                                                " Count(MejorVariacionDiariaSimulador) as MejorVariacionSemanalSimulador," +
                                                " Sum(MejorVariacionDiaria) / Count(MejorVariacionDiariaSimulador) as MejorVariacionSimuladorPromedio" +
                                                " From bdiol.informefinal" +
                                                " group by Simbolo, MejorVariacionDiariaSimulador) T1" +
                                                " Where orden = 1";

                                    MySqlDataAdapter daCerrarInforme = new MySqlDataAdapter(sentencia, coneCerrarInforme);
                                    DataTable dsCerrarInforme = new DataTable();
                                    int regCerrarInformes = daCerrarInforme.Fill(dsCerrarInforme);
                                    coneCerrarInforme.Close();

                                    if (regCerrarInformes > 0)
                                    {
                                        foreach (DataRow fila in dsCerrarInforme.Rows)
                                        {
                                            string simbolo = fila["Simbolo"].ToString().Trim();
                                            int simulacion = Convert.ToInt32(fila["Simulador"]);
                                            decimal variacion = Convert.ToInt32(fila["MejorVariacionSemanalSimulador"]);

                                            sentencia = $"Update InformeFinal Set MejorVariacionSemanal = {variacion}, MejorVariacionSemanalSimulador = {simulacion} " +
                                                        $" Where IdRueda = {IdRueda} And Simbolo = '{simbolo}'";
                                            using (MySqlConnection coneCerrar = new MySqlConnection(conexion))
                                            {
                                                coneCerrar.Open();
                                                var comandoCerrarInformeFinal = new MySqlCommand(sentencia, coneCerrar);
                                                comandoCerrarInformeFinal.ExecuteNonQuery();
                                                coneCerrar.Close();
                                            }
                                        }
                                    }
                                }
                                MessageBox.Show("Rueda cerrada Exitosamente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                        }
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
            int horaHasta = Bd.Ruedas.Where(x => x.IdRueda == rueda).SingleOrDefault().ComprarHasta;
            return horaActual >= 11 && horaActual < horaHasta;
        }
    }
}

