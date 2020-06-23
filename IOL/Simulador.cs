using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace IOL
{
    public partial class Simulador : Form
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();
        public int comitente = 0;  // Nro. de Comitente
        bool estado = false;  // Estado de la Rueda: Abierta o Cerrada. 
        bool comprar = false;  // Comprar establece si se puede seguir comprando
        const int simulaciones = 11;

        Token permisoIOL = null; // Token para acceder a IOL

        // El Vector vSimuladores contiene Porcentajes de Simulacion para la Compra y Venta, SaldoSimulador, Activos Valorizados y Total Tenencia
        double[,] vSimuladores = new double[simulaciones, 5];

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

        private void ActualizarSimuladores()
        {
            vSimuladores[1, 0] = Convert.ToDouble(txtPorcCompra1.Text.Trim());
            vSimuladores[1, 1] = Convert.ToDouble(txtPorcVenta1.Text.Trim());

            vSimuladores[2, 0] = Convert.ToDouble(txtPorcCompra2.Text.Trim());
            vSimuladores[2, 1] = Convert.ToDouble(txtPorcVenta2.Text.Trim());

            vSimuladores[3, 0] = Convert.ToDouble(txtPorcCompra3.Text.Trim());
            vSimuladores[3, 1] = Convert.ToDouble(txtPorcVenta3.Text.Trim());

            vSimuladores[4, 0] = Convert.ToDouble(txtPorcCompra4.Text.Trim());
            vSimuladores[4, 1] = Convert.ToDouble(txtPorcVenta4.Text.Trim());

            vSimuladores[5, 0] = Convert.ToDouble(txtPorcCompra5.Text.Trim());
            vSimuladores[5, 1] = Convert.ToDouble(txtPorcVenta5.Text.Trim());

            vSimuladores[6, 0] = Convert.ToDouble(txtPorcCompra6.Text.Trim());
            vSimuladores[6, 1] = Convert.ToDouble(txtPorcVenta6.Text.Trim());

            vSimuladores[7, 0] = Convert.ToDouble(txtPorcCompra7.Text.Trim());
            vSimuladores[7, 1] = Convert.ToDouble(txtPorcVenta7.Text.Trim());

            vSimuladores[8, 0] = Convert.ToDouble(txtPorcCompra8.Text.Trim());
            vSimuladores[8, 1] = Convert.ToDouble(txtPorcVenta8.Text.Trim());

            vSimuladores[9, 0] = Convert.ToDouble(txtPorcCompra9.Text.Trim());
            vSimuladores[9, 1] = Convert.ToDouble(txtPorcVenta9.Text.Trim());

            vSimuladores[10, 0] = Convert.ToDouble(txtPorcCompra10.Text.Trim());
            vSimuladores[10, 1] = Convert.ToDouble(txtPorcVenta10.Text.Trim());
        }

        private void ActualizarLoad(object sender, EventArgs e)
        {
            string sentencia = string.Empty;
            double total = 100000;

            using (MySqlConnection cone = new MySqlConnection(conexion))
            {
                sentencia = string.Format("Select * From TenenciaSimulador Order By IdSimulacion");
                MySqlDataAdapter daSimulador = new MySqlDataAdapter(sentencia, cone);
                DataTable dsSimulador = new DataTable();
                int nSimuladores = daSimulador.Fill(dsSimulador);
                if (nSimuladores > 0)
                {
                    foreach (DataRow fila in dsSimulador.Rows)
                    {
                        double disponible = Convert.ToDouble(fila["DisponibleParaOperar"]);
                        double activos = Convert.ToDouble(fila["DisponibleParaOperar"]);
                        double totaltenencia = Convert.ToDouble(fila["DisponibleParaOperar"]);
                        if (totaltenencia < total)
                        {
                            disponible = total - totaltenencia;
                            totaltenencia = disponible + activos;
                        }
                        int nIdSimulador = 0;
                        try { nIdSimulador = Convert.ToInt32(fila["IdSimulacion"]); }
                        catch { nIdSimulador = 0; }

                        if (nIdSimulador != 0)
                        {
                            vSimuladores[nIdSimulador, 2] = disponible;
                            vSimuladores[nIdSimulador, 3] = activos;
                            vSimuladores[nIdSimulador, 4] = totaltenencia;
                        }
                    }

                }
                else
                {
                    for (int indice = 1; indice < simulaciones; indice++)
                    {
                        vSimuladores[indice, 2] = total;
                        vSimuladores[indice, 3] = 0;
                        vSimuladores[indice, 4] = total;
                    }
                }

                cone.Close();
            }

            using (MySqlConnection coneSimulador = new MySqlConnection(conexion))
            {
                for (int i = 1; i < simulaciones; i++)
                {
                    double disponible = vSimuladores[i, 2];
                    double activos = vSimuladores[i, 3];
                    double totaltenencia = vSimuladores[i, 4];

                    sentencia = string.Format("Update TenenciaSimulador Set DisponibleParaOperar = {0}, ActivosValorizados = {1}," +
                        " TotalTenencia = {2}, Fecha = Now() Where IdSimulacion = {3}", disponible, activos, totaltenencia, i);
                    coneSimulador.Open();
                    MySqlCommand comando = new MySqlCommand(sentencia, coneSimulador);
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    coneSimulador.Close();
                }
            }

            MySqlConnection coneRuedas = new MySqlConnection(conexion);
            DateTime? fecha = DateTime.Now.Date;
            sentencia = string.Format("Select * From Ruedas Where Date_format(fechaRueda,'%y-%m-%d') = str_to_date('{0}','%d/%m/%y') And Comitente = {1}", fecha.Value.Date.ToShortDateString(), comitente);
            MySqlDataAdapter daRuedas = new MySqlDataAdapter(sentencia, coneRuedas);
            DataTable dsRuedas = new DataTable();
            daRuedas.Fill(dsRuedas);
            if (dsRuedas.Rows.Count > 0)
            {
                DataRow Fila = dsRuedas.Rows[0];
                txtIdRueda.Text = Fila["IdRueda"].ToString();
                txtFecha.Text = fecha.Value.Date.ToShortDateString();
                txtHora.Text = string.Format("{0:00}:{1:00}", DateTime.Now.Hour, DateTime.Now.Minute);
                txtEstado.Text = (estado) ? "Abierto" : "Cerrado";
                this.Refresh();
                AgregarAccesoIOL();
                txtPorcCompra.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra"]));
                txtPorcVenta.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta"]));
                txtPorcComisionIOL.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcComisionIOL"]));
                txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcPuntaCompradora"]));
                txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcPuntaVendedora"]));

                txtPorcCompra1.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra1"]));
                txtPorcCompra2.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra2"]));
                txtPorcCompra3.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra3"]));
                txtPorcCompra4.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra4"]));
                txtPorcCompra5.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra5"]));
                txtPorcCompra6.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra6"]));
                txtPorcCompra7.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra7"]));
                txtPorcCompra8.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra8"]));
                txtPorcCompra9.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra9"]));
                txtPorcCompra10.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcCompra10"]));

                txtPorcVenta1.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta1"]));
                txtPorcVenta2.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta2"]));
                txtPorcVenta3.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta3"]));
                txtPorcVenta4.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta4"]));
                txtPorcVenta5.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta5"]));
                txtPorcVenta6.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta6"]));
                txtPorcVenta7.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta7"]));
                txtPorcVenta8.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta8"]));
                txtPorcVenta9.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta9"]));
                txtPorcVenta10.Text = string.Format("{0:00.00}", Convert.ToDecimal(Fila["PorcVenta10"]));

                tmrActualizarToken_Tick(sender,e);
                ActualizarSimuladores();
                ActualizarAccionesCompradas();
            }
        }
        private void Simulador_Load(object sender, EventArgs e)
        {
            string sentencia = string.Empty;

            MySqlConnection coneRuedas = new MySqlConnection(conexion);
            DateTime? fecha = DateTime.Now.Date;
            sentencia = string.Format("Select * From Ruedas Where Date_format(fechaRueda,'%y-%m-%d') = str_to_date('{0}','%d/%m/%y') And Comitente = {1}", fecha.Value.Date.ToShortDateString(), comitente);
            MySqlDataAdapter daRuedas = new MySqlDataAdapter(sentencia, coneRuedas);
            DataTable dsRuedas = new DataTable();
            daRuedas.Fill(dsRuedas);
            if (dsRuedas.Rows.Count > 0)
            {
                ActualizarLoad(sender,e);
            }
            else
            {
                fecha = DateTime.Now.Date;
                DayOfWeek nrodia = fecha.Value.DayOfWeek;
                if (nrodia == DayOfWeek.Saturday || nrodia == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Sábado/Domingo y Feriados NO opera la bolsa", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    sentencia = string.Format("Select * From Feriados Where Date_format(fecha,'%y-%m-%d') = str_to_date('{0}','%d/%m/%y')", fecha.Value.Date.ToShortDateString());
                    MySqlConnection coneFeriados = new MySqlConnection(conexion);
                    MySqlDataAdapter daFeriados = new MySqlDataAdapter(sentencia, coneFeriados);
                    DataTable dsFeriados = new DataTable();
                    daFeriados.Fill(dsFeriados);

                    if (dsFeriados.Rows.Count > 0)
                    {
                        string mensaje = string.Format("Sábado/Domingo y Feriados NO opera la bolsa. Dia {0} Feriado: '{1}'",
                                                        fecha.Value.Date.ToShortDateString(), dsFeriados.Rows[0]["Motivo"].ToString());
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
            sentencia = string.Format("Update Ruedas Set AccesosIOL = AccesosIOL + 1 Where IdRueda = {0}", txtIdRueda.Text.Trim());
            cone.Open();
            MySqlCommand comando = new MySqlCommand(sentencia, cone);
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            cone.Close();

            sentencia = string.Format("Select * From Ruedas Where IdRueda = {0}", txtIdRueda.Text.Trim());
            MySqlConnection coneRuedas = new MySqlConnection(conexion);
            MySqlDataAdapter daRuedas = new MySqlDataAdapter(sentencia, coneRuedas);
            DataTable dsRuedas = new DataTable();
            daRuedas.Fill(dsRuedas);
            if (dsRuedas.Rows.Count > 0)
                return Convert.ToInt32((dsRuedas.Rows[0]["AccesosIOL"] is DBNull) ? 0 : dsRuedas.Rows[0]["AccesosIOL"]);
            else
                return 0;
        }

        private void ActualizarAccionesCompradas()
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            int IdSimulacion = 0;
            try { IdSimulacion = Convert.ToInt32(nudSimulador.Value); }
            catch { IdSimulacion = 0; }

            if (IdSimulacion > 0 && txtIdRueda.Text.Trim().Length > 0)
            {
                using (MySqlConnection coneDetalle = new MySqlConnection(cone))
                {
                    string sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0} And Estado = 'Comprado' And IdSimulacion = {1}", txtIdRueda.Text.Trim(), IdSimulacion);

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia, coneDetalle);
                    DataTable ds = new DataTable();
                    da.Fill(ds);

                    if (ds.Rows.Count > 0)
                    {
                        dgvAccionesCompradas.DataSource = ds;

                        DataGridViewCellStyle EstiloEncabezadoColumna = new DataGridViewCellStyle();

                        EstiloEncabezadoColumna.BackColor = Color.Green;
                        EstiloEncabezadoColumna.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                        dgvAccionesCompradas.ColumnHeadersDefaultCellStyle = EstiloEncabezadoColumna;

                        DataGridViewCellStyle EstiloColumnas = new DataGridViewCellStyle();
                        EstiloColumnas.BackColor = Color.AliceBlue;
                        EstiloColumnas.Font = new Font("Times New Roman", 12);
                        dgvAccionesCompradas.RowsDefaultCellStyle = EstiloColumnas;

                        dgvAccionesCompradas.Columns["Simbolo"].HeaderText = "Símbolo";
                        dgvAccionesCompradas.Columns["FechaCompra"].HeaderText = "Fecha Compra";
                        dgvAccionesCompradas.Columns["Cantidad"].HeaderText = "Cantidad";
                        dgvAccionesCompradas.Columns["PrecioCompra"].HeaderText = "Precio Compra";
                        dgvAccionesCompradas.Columns["ImporteCompra"].HeaderText = "Importe";
                        dgvAccionesCompradas.Columns["UltimoPrecio"].HeaderText = "Ultimo Precio";
                        dgvAccionesCompradas.Columns["FechaUltimoPrecio"].HeaderText = "Fecha Precio";
                        dgvAccionesCompradas.Columns["VariacionEnPesos"].HeaderText = "Variación$";
                        dgvAccionesCompradas.Columns["VariacionEnPorcentajes"].HeaderText = "Variación%";

                        dgvAccionesCompradas.Columns["Simbolo"].Width = 100;
                        dgvAccionesCompradas.Columns["FechaCompra"].Width = 120;
                        dgvAccionesCompradas.Columns["Cantidad"].Width = 90;
                        dgvAccionesCompradas.Columns["PrecioCompra"].Width = 120;
                        dgvAccionesCompradas.Columns["ImporteCompra"].Width = 100;
                        dgvAccionesCompradas.Columns["UltimoPrecio"].Width = 120;
                        dgvAccionesCompradas.Columns["FechaUltimoPrecio"].Width = 120;
                        dgvAccionesCompradas.Columns["VariacionEnPesos"].Width = 90;
                        dgvAccionesCompradas.Columns["VariacionEnPorcentajes"].Width = 100;

                        dgvAccionesCompradas.Columns["Simbolo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["FechaCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["ImporteCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["UltimoPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["FechaUltimoPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["VariacionEnPesos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["VariacionEnPorcentajes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        dgvAccionesCompradas.Columns["PrecioCompra"].DefaultCellStyle.Format = "$ #00.00";
                        dgvAccionesCompradas.Columns["Cantidad"].DefaultCellStyle.Format = "#00.00";
                        dgvAccionesCompradas.Columns["ImporteCompra"].DefaultCellStyle.Format = "$ #00.00";
                        dgvAccionesCompradas.Columns["UltimoPrecio"].DefaultCellStyle.Format = "$ #00.00";
                        dgvAccionesCompradas.Columns["VariacionEnPesos"].DefaultCellStyle.Format = "$ #00.00";
                        dgvAccionesCompradas.Columns["VariacionEnPorcentajes"].DefaultCellStyle.Format = "#00.00";

                        dgvAccionesCompradas.Columns["Simbolo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["FechaCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["PrecioCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["ImporteCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["UltimoPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["FechaUltimoPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["VariacionEnPesos"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAccionesCompradas.Columns["VariacionEnPorcentajes"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        dgvAccionesCompradas.RefreshEdit();
                        dgvAccionesCompradas.Enabled = true;
                    }
                    else
                    {
                        dgvAccionesCompradas.DataSource = null;
                        dgvAccionesCompradas.RefreshEdit();
                    }
                    lblTotalAccionesCompradas.Text = string.Format("Total de Acciones Compradas: {0:00}", ds.Rows.Count);
                }
            }
            else
            {
                dgvAccionesCompradas.DataSource = null;
                foreach (Control controles in this.Controls)
                    controles.Enabled = false;
                foreach (Control controles in tbpDatosRueda.Controls)
                    controles.Enabled = false;
                foreach (Control controles in tbpDatosSimulador.Controls)
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
            estado = false;

            if (idrueda > 0)
            {
                // Verificamos que este en horario Bursatil
                if (HoraActual >= 11 && HoraActual < 17)
                {
                    // La variable comprar nos indica si estamos en horario para comprar
                    comprar = (HoraActual >= 16 && HoraActual < 17) ? false : true;
                    //comprar = true;  // OJO BORRAR

                    // Verificamos se realizo la apertura de la rueda
                    if (estado == false)
                    {
                        estado = true;
                        txtEstado.Text = (estado) ? "Abierto" : "Cerrado";

                        // Almacenamos la apertura de la rueda
                        using (MySqlConnection cone = new MySqlConnection(conexion))
                        {
                            sentencia = "Update Ruedas Set Estado = 1 ";
                            sentencia += string.Format("Where Ruedas.IdRueda = {0}", idrueda);
                            cone.Open();
                            MySqlCommand comandoApertura = new MySqlCommand(sentencia, cone);
                            comandoApertura.ExecuteNonQuery();
                            cone.Close();
                        }

                        // Almacenamos todas las acciones compradas de la rueda del dia anterior
                        // a la rueda actual
                        using (MySqlConnection coneAperturaRueda = new MySqlConnection(conexion))
                        {
                            sentencia = "UPDATE RuedasDetalleSimulador ";
                            sentencia += string.Format("SET IdRuedaActual = {0} ", idrueda);
                            sentencia += string.Format("Where Estado = 'Comprado' And IdRuedaActual != {0} And IdRuedaActual = IdRuedaCompra ", idrueda);
                            coneAperturaRueda.Open();
                            MySqlCommand comandoAperturaRueda = new MySqlCommand(sentencia, coneAperturaRueda);
                            comandoAperturaRueda.ExecuteNonQuery();
                            coneAperturaRueda.Close();
                        }
                    }

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
                                    sentencia = string.Format("Update RuedasDetalleSimulador Set UltimoPrecio = {0}," +
                                                              " FechaUltimoPrecio = str_to_date('{1}','%d/%m/%Y %H:%i:%s') " +
                                                              " Where IdRuedaActual = {2} And Simbolo = '{3}' And Estado = 'Comprado'",
                                                                UltimoPrecio,
                                                                DateTime.Now,
                                                                idrueda, simbolo);
                                    MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                    comando.CommandType = CommandType.Text;
                                    comando.ExecuteNonQuery();
                                    cone.Close();
                                }
                            }

                            using (MySqlConnection cone = new MySqlConnection(conexion))
                            {
                                cone.Open();
                                sentencia = string.Format("Update RuedasDetalleSimulador Set " +
                                                          "VariacionenPesos = (UltimoPrecio - PrecioCompra) * cantidad," +
                                                          "VariacionenPorcentajes = ((UltimoPrecio / preciocompra) - 1) * 100 " +
                                                          "Where IdRuedaActual = {0} And Estado = 'Comprado' And UltimoPrecio > 0", idrueda);
                                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                cone.Close();
                            }

                            using (MySqlConnection cone = new MySqlConnection(conexion))
                            {
                                cone.Open();
                                sentencia = string.Format("Update RuedasDetalleSimulador Set " +
                                                          "VariacionenPesos = 0, " +
                                                          "VariacionenPorcentajes = 0 " +
                                                          "Where IdRuedaActual = {0} And Estado = 'Comprado' And Simbolo = '{1}' And UltimoPrecio = 0", idrueda, simbolo);
                                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                cone.Close();
                            }

                            using (MySqlConnection cone = new MySqlConnection(conexion))
                            {
                                cone.Open();
                                sentencia = string.Format("Update RuedasDetalleSimulador Set " +
                                                          "VariacionenPesos = (PrecioVenta - PrecioCompra) * cantidad," +
                                                          "VariacionenPorcentajes = ((PrecioVenta / PrecioCompra) - 1) * 100 " +
                                                          "Where IdRuedaActual = {0} And Estado = 'Vendido'", idrueda);
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
                                sentencia = string.Format("Insert Into PanelPrincipal(IdRueda, Simbolo," +
                                                          "VariacionPorcentual, Apertura, Maximo, Minimo," +
                                                          "UltimoCierre, Volumen, CantidadDeOperaciones, Fecha," +
                                                          "mercado, Moneda," +
                                                          "PuntaCompradoraP, PuntaVendedoraP," +
                                                          "PuntaCompradoraC, PuntaVendedoraC, UltimoPrecio, IdPanel)" +
                                                          " Values ({0}, '{1}'," +
                                                          "{2}, {3}, {4}, {5}," +
                                                          "{6}, {7}, {8},'{9}'," +
                                                          "'{10}', '{11}'," +
                                                          "{12}, {13}," +
                                                          "{14}, {15}, {16}, {17})",
                                                          idrueda, simbolo,
                                                          _VariacionPorcentual, _Apertura, _Maximo, _Minimo,
                                                          _UltimoCierre, _Volumen, _CantidadOperaciones, _Fecha,
                                                          _Mercado, _Moneda,
                                                          _PrecioCompra, _PrecioVenta,
                                                          _CantidadCompra, _CantidadVenta, _UltimoPrecio, nIdPanel);
                                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                cone.Close();
                            }

                        }
                    }
                    ActualizarAccionesCompradas(); // Actualiza la grilla de acciones compradas
                }
                else
                if (HoraActual >= 17)
                {
                    MySqlConnection coneRuedaFinalizada = new MySqlConnection(conexion);
                    sentencia = string.Format("Select * From Ruedas Where IdRueda = {0} And Estado = 1", idrueda);
                    MySqlDataAdapter daRuedaFinalizada = new MySqlDataAdapter(sentencia, coneRuedaFinalizada);
                    DataTable dsRuedaFinalizada = new DataTable();
                    int regRuedaFinalizada = daRuedaFinalizada.Fill(dsRuedaFinalizada);
                    coneRuedaFinalizada.Close();
                    if (regRuedaFinalizada == 1)
                    {
                        // Almacenamos el cierre de la rueda
                        using (MySqlConnection cone = new MySqlConnection(conexion))
                        {
                            sentencia = string.Format("Update Ruedas Set Estado = 2 Where IdRueda = {0}", idrueda);
                            cone.Open();
                            MySqlCommand comandoApertura = new MySqlCommand(sentencia, cone);
                            comandoApertura.ExecuteNonQuery();
                            cone.Close();
                        }

                        // Borrar tabla de InformeDeSimuladores
                        using (MySqlConnection coneEliminar = new MySqlConnection(conexion))
                        {
                            sentencia = "Delete From InformeFinal";
                            coneEliminar.Open();
                            MySqlCommand comando = new MySqlCommand(sentencia, coneEliminar);
                            comando.CommandType = CommandType.Text;
                            comando.ExecuteNonQuery();
                            coneEliminar.Close();
                        }

                        // Cargo todas las acciones
                        sentencia = string.Format("Select Simbolo From Acciones Order By Simbolo");
                        MySqlConnection coneAcciones = new MySqlConnection(conexion);
                        MySqlDataAdapter daAcciones = new MySqlDataAdapter(sentencia, coneAcciones);
                        DataTable dsAcciones = new DataTable();
                        daAcciones.Fill(dsAcciones);

                        if (dsAcciones.Rows.Count > 0)
                        {
                            foreach (DataRow fila in dsAcciones.Rows)
                            {
                                string simbolo = fila["Simbolo"].ToString();

                                using (MySqlConnection coneActualizar = new MySqlConnection(conexion))
                                {
                                    sentencia = String.Format("Insert Into InformeFinal (Simbolo, IdRueda) Values('{0}',{1})", simbolo, idrueda);
                                    coneActualizar.Open();
                                    MySqlCommand comando = new MySqlCommand(sentencia, coneActualizar);
                                    comando.CommandType = CommandType.Text;
                                    comando.ExecuteNonQuery();
                                    coneActualizar.Close();
                                }
                            }
                        }

                        // Cargo toda la info de la rueda
                        sentencia = string.Format("Select * From RuedasDetalleSimulador Where IdRuedaActual = {0} And Estado = 'Vendido'", idrueda);
                        MySqlConnection coneRuedas = new MySqlConnection(conexion);
                        MySqlDataAdapter daRuedas = new MySqlDataAdapter(sentencia, coneRuedas);
                        DataTable dsRuedas = new DataTable();
                        daRuedas.Fill(dsRuedas);

                        if (dsRuedas.Rows.Count > 0)
                        {
                            foreach (DataRow fila in dsRuedas.Rows)
                            {
                                string simbolo = fila["Simbolo"].ToString();
                                int simulador = Convert.ToInt16(fila["IdSimulacion"]);
                                decimal variacion = Convert.ToDecimal(fila["VariacionEnPorcentajes"]);

                                using (MySqlConnection coneActualizar = new MySqlConnection(conexion))
                                {
                                    sentencia = String.Format("Update InformeFinal Set Variacion{0}Diaria = Variacion{0}Diaria + {1} " +
                                        " Where IdRueda = {2} And Simbolo = '{3}'",
                                        simulador, variacion, idrueda, simbolo);
                                    coneActualizar.Open();
                                    MySqlCommand comando = new MySqlCommand(sentencia, coneActualizar);
                                    comando.CommandType = CommandType.Text;
                                    comando.ExecuteNonQuery();
                                    coneActualizar.Close();
                                }
                            }
                        }
                    }
                }
            }
            txtEstado.Text = (estado) ? "Abierto" : "Cerrado";
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
                double resultado = 0, cantidadvendida = 0;

                resultado = PrecioCompra + (PrecioCompra * vSimuladores[Simulador, 1] / 100);

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
                            sentencia = string.Format("Update RuedasDetalleSimulador Set " +
                                                      " PrecioVenta = {0}, ImporteVenta = {1}, FechaVenta = str_to_date('{2}','%d/%m/%Y %H:%i:%s') , Estado = 'Vendido'," +
                                                      "UltimoPrecio = {3}, FechaUltimoPrecio = str_to_date('{4}','%d/%m/%Y %H:%i:%s')," +
                                                      "IdRuedaVenta = {5}  Where IdRuedaDetalle = {6}",
                                                      precioventa, Importe, DateTime.Now,
                                                      precioventa, DateTime.Now,
                                                      IdRueda, iddetalle);
                            MySqlCommand comando = new MySqlCommand(sentencia, cone);
                            comando.CommandType = CommandType.Text;
                            comando.ExecuteNonQuery();
                            cone.Close();
                        }

                        vSimuladores[Simulador, 2] += Importe;
                        vSimuladores[Simulador, 4] += Importe;

                        using (MySqlConnection coneSimulador = new MySqlConnection(conexion))
                        {
                            double disponible = vSimuladores[Simulador, 2];
                            double activos = vSimuladores[Simulador, 3];
                            double totaltenencia = vSimuladores[Simulador, 4];

                            sentencia = string.Format("Update TenenciaSimulador Set DisponibleParaOperar = {0}, ActivosValorizados = {1}," +
                                " TotalTenencia = {2}, Fecha = Now() Where IdSimulacion = {3}", disponible, activos, totaltenencia, Simulador);
                            coneSimulador.Open();
                            MySqlCommand comando = new MySqlCommand(sentencia, coneSimulador);
                            comando.CommandType = CommandType.Text;
                            comando.ExecuteNonQuery();
                            coneSimulador.Close();
                        }
                    }
                }
            }
            else // Ultima Operacion fue la venta de acciones o ninguna acción.
            {
                if (comprar) // Si esta en horario de compra de acciones
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
                        promedio2 = (suma / 3) * vSimuladores[Simulador, 0] / 100;
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
                                double importe = vSimuladores[Simulador, 2] * 1 / CantRestantes;

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
                                        sentencia = string.Format("Insert Into RuedasDetalleSimulador(IdRuedaActual, IdRuedaCompra, IdSimulacion, " +
                                                                  "FechaCompra, Simbolo, Cantidad, " +
                                                                  "PrecioCompra, ImporteCompra, UltimoPrecio," +
                                                                  "FechaUltimoPrecio," +
                                                                  "Estado, PorcComisionIOL, ImporteComisionIOL, IdPanel) " +
                                                                  "Values({0}, {1}, {2}, " +
                                                                  "str_to_date('{3}','%d/%m/%Y %H:%i:%s'),'{4}',{5}, " +
                                                                  "{6},{7},{8}," +
                                                                  "str_to_date('{9}','%d/%m/%Y %H:%i:%s')," +
                                                                  "'{10}',{11},{12},{13})",
                                                                   IdRueda, IdRueda, Simulador,
                                                                   DateTime.Now, Simbolo, cantidadcomprada,
                                                                   preciocompra, importe, precioactual,
                                                                   DateTime.Now,
                                                                   "Comprado", txtPorcComisionIOL.Text.Trim(), comisionIOL, IdPanel);
                                        MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                        comando.CommandType = CommandType.Text;
                                        comando.ExecuteNonQuery();
                                        cone.Close();
                                    }
                                    vSimuladores[Simulador, 2] -= (importe + comisionIOL);
                                    vSimuladores[Simulador, 4] -= (importe + comisionIOL);

                                    using (MySqlConnection coneSimulador = new MySqlConnection(conexion))
                                    {
                                        double disponible = vSimuladores[Simulador, 2];
                                        double activos = vSimuladores[Simulador, 3];
                                        double totaltenencia = vSimuladores[Simulador, 4];

                                        sentencia = string.Format("Update TenenciaSimulador Set DisponibleParaOperar = {0}, ActivosValorizados = {1}," +
                                            " TotalTenencia = {2}, Fecha = Now() Where IdSimulacion = {3}", disponible, activos, totaltenencia, Simulador);
                                        coneSimulador.Open();
                                        MySqlCommand comando = new MySqlCommand(sentencia, coneSimulador);
                                        comando.CommandType = CommandType.Text;
                                        comando.ExecuteNonQuery();
                                        coneSimulador.Close();
                                    }
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

            double precioanterior = 0, precioanteriorA = 0, precioanteriorAA = 0, resultado1 = 0, resultado2 = 0, resultado3 = 0;
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

                    resultado1 = PrecioCompra + (PrecioCompra * .0007);
                    resultado2 = precioanterior - (precioanterior * vSimuladores[Simulador, 1] / 100);
                    resultado3 = precioanteriorA - (precioanteriorA * vSimuladores[Simulador, 1] / 100);

                    bool lvender1 = precioactual > resultado1 && precioactual < resultado2 && precioanterior > precioanteriorA;
                    bool lvender2 = precioactual > resultado1 && precioactual < resultado3 && precioanteriorA > precioanteriorAA;

                    if (lvender1 || lvender2) // Vendemos
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
                        Importe = (PrecioActualVenta + (PrecioActualVenta * porcincremento / 100)) * CantidadVendida;

                        if (CantidadVendida > 0)
                        {
                            using (MySqlConnection cone = new MySqlConnection(conexion))
                            {
                                cone.Open();
                                sentencia = string.Format("Update RuedasDetalleSimulador Set " +
                                                          " PrecioVenta = {0}, ImporteVenta = {1}, FechaVenta = str_to_date('{2}','%d/%m/%Y %H:%i:%s') , Estado = 'Vendido'," +
                                                          "UltimoPrecio = {3}, FechaUltimoPrecio = str_to_date('{4}','%d/%m/%Y %H:%i:%s')," +
                                                          "IdRuedaVenta = {5}  Where IdRuedaDetalle = {6}",
                                                          precioventa, Importe, DateTime.Now,
                                                          precioventa, DateTime.Now,
                                                          IdRueda, iddetalle);
                                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                cone.Close();
                            }

                            vSimuladores[Simulador, 2] += Importe;
                            vSimuladores[Simulador, 4] += Importe;

                            using (MySqlConnection coneSimulador = new MySqlConnection(conexion))
                            {
                                double disponible = vSimuladores[Simulador, 2];
                                double activos = vSimuladores[Simulador, 3];
                                double totaltenencia = vSimuladores[Simulador, 4];

                                sentencia = string.Format("Update TenenciaSimulador Set DisponibleParaOperar = {0}, ActivosValorizados = {1}," +
                                    " TotalTenencia = {2}, Fecha = Now() Where IdSimulacion = {3}", disponible, activos, totaltenencia, Simulador);
                                coneSimulador.Open();
                                MySqlCommand comando = new MySqlCommand(sentencia, coneSimulador);
                                comando.CommandType = CommandType.Text;
                                comando.ExecuteNonQuery();
                                coneSimulador.Close();
                            }
                        }
                    }
                }
            }
            else // Ultima Operacion fue la venta de acciones o ninguna acción.
            {
                if (comprar) // Si esta en horario de compra de acciones
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

                        resultado1 = precioanterior + (precioanterior * vSimuladores[Simulador, 0] / 100);
                        resultado2 = precioanteriorA + (precioanteriorA * vSimuladores[Simulador, 0] / 100);

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
                                double importe = vSimuladores[Simulador, 2] * 1 / CantRestantes;

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
                                        sentencia = string.Format("Insert Into RuedasDetalleSimulador(IdRuedaActual, IdRuedaCompra, IdSimulacion, " +
                                                                  "FechaCompra, Simbolo, Cantidad, " +
                                                                  "PrecioCompra, ImporteCompra, UltimoPrecio," +
                                                                  "FechaUltimoPrecio," +
                                                                  "Estado, PorcComisionIOL, ImporteComisionIOL, IdPanel) " +
                                                                  "Values({0}, {1}, {2}, " +
                                                                  "str_to_date('{3}','%d/%m/%Y %H:%i:%s'),'{4}',{5}, " +
                                                                  "{6},{7},{8}," +
                                                                  "str_to_date('{9}','%d/%m/%Y %H:%i:%s')," +
                                                                  "'{10}',{11},{12},{13})",
                                                                   IdRueda, IdRueda, Simulador,
                                                                   DateTime.Now, Simbolo, cantidadcomprada,
                                                                   preciocompra, importe, precioactual,
                                                                   DateTime.Now,
                                                                   "Comprado", txtPorcComisionIOL.Text.Trim(), comisionIOL, IdPanel);
                                        MySqlCommand comando = new MySqlCommand(sentencia, cone);
                                        comando.CommandType = CommandType.Text;
                                        comando.ExecuteNonQuery();
                                        cone.Close();
                                    }
                                    vSimuladores[Simulador, 2] -= (importe + comisionIOL);
                                    vSimuladores[Simulador, 4] -= (importe + comisionIOL);

                                    using (MySqlConnection coneSimulador = new MySqlConnection(conexion))
                                    {
                                        double disponible = vSimuladores[Simulador, 2];
                                        double activos = vSimuladores[Simulador, 3];
                                        double totaltenencia = vSimuladores[Simulador, 4];

                                        sentencia = string.Format("Update TenenciaSimulador Set DisponibleParaOperar = {0}, ActivosValorizados = {1}," +
                                            " TotalTenencia = {2}, Fecha = Now() Where IdSimulacion = {3}", disponible, activos, totaltenencia, Simulador);
                                        coneSimulador.Open();
                                        MySqlCommand comando = new MySqlCommand(sentencia, coneSimulador);
                                        comando.CommandType = CommandType.Text;
                                        comando.ExecuteNonQuery();
                                        coneSimulador.Close();
                                    }
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
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

 
        private void txtPorcCompra1_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta1_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra2_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta2_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra3_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta3_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra4_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta4_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra5_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta5_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void btnDatosSimulador_Click(object sender, EventArgs e)
        {
            bool lValidado = true;
            string Mensaje = string.Empty;

            string sentencia = string.Empty;

            decimal porccompra1 = 0,
                    porccompra2 = 0,
                    porccompra3 = 0,
                    porccompra4 = 0,
                    porccompra5 = 0,
                    porccompra6 = 0,
                    porccompra7 = 0,
                    porccompra8 = 0,
                    porccompra9 = 0,
                    porccompra10 = 0,
                    porcventa1 = 0,
                    porcventa2 = 0,
                    porcventa3 = 0,
                    porcventa4 = 0,
                    porcventa5 = 0,
                    porcventa6 = 0,
                    porcventa7 = 0,
                    porcventa8 = 0,
                    porcventa9 = 0,
                    porcventa10 = 0;

            try
            { porccompra1 = Convert.ToDecimal(txtPorcCompra1.Text.Trim()); }
            catch
            { porccompra1 = 0; }

            try
            { porccompra2 = Convert.ToDecimal(txtPorcCompra2.Text.Trim()); }
            catch
            { porccompra2 = 0; }

            try
            { porccompra3 = Convert.ToDecimal(txtPorcCompra3.Text.Trim()); }
            catch
            { porccompra3 = 0; }

            try
            { porccompra4 = Convert.ToDecimal(txtPorcCompra4.Text.Trim()); }
            catch
            { porccompra4 = 0; }

            try
            { porccompra5 = Convert.ToDecimal(txtPorcCompra5.Text.Trim()); }
            catch
            { porccompra5 = 0; }

            try
            { porccompra6 = Convert.ToDecimal(txtPorcCompra6.Text.Trim()); }
            catch
            { porccompra6 = 0; }

            try
            { porccompra7 = Convert.ToDecimal(txtPorcCompra7.Text.Trim()); }
            catch
            { porccompra7 = 0; }

            try
            { porccompra8 = Convert.ToDecimal(txtPorcCompra8.Text.Trim()); }
            catch
            { porccompra8 = 0; }

            try
            { porccompra9 = Convert.ToDecimal(txtPorcCompra9.Text.Trim()); }
            catch
            { porccompra9 = 0; }

            try
            { porccompra10 = Convert.ToDecimal(txtPorcCompra10.Text.Trim()); }
            catch
            { porccompra10 = 0; }

            try
            { porcventa1 = Convert.ToDecimal(txtPorcVenta1.Text.Trim()); }
            catch
            { porcventa1 = 0; }

            try
            { porcventa2 = Convert.ToDecimal(txtPorcVenta2.Text.Trim()); }
            catch
            { porcventa2 = 0; }

            try
            { porcventa3 = Convert.ToDecimal(txtPorcVenta3.Text.Trim()); }
            catch
            { porcventa3 = 0; }

            try
            { porcventa4 = Convert.ToDecimal(txtPorcVenta4.Text.Trim()); }
            catch
            { porcventa4 = 0; }

            try
            { porcventa5 = Convert.ToDecimal(txtPorcVenta5.Text.Trim()); }
            catch
            { porcventa5 = 0; }

            try
            { porcventa6 = Convert.ToDecimal(txtPorcVenta6.Text.Trim()); }
            catch
            { porcventa6 = 0; }

            try
            { porcventa7 = Convert.ToDecimal(txtPorcVenta7.Text.Trim()); }
            catch
            { porcventa7 = 0; }

            try
            { porcventa8 = Convert.ToDecimal(txtPorcVenta8.Text.Trim()); }
            catch
            { porcventa8 = 0; }

            try
            { porcventa9 = Convert.ToDecimal(txtPorcVenta9.Text.Trim()); }
            catch
            { porcventa9 = 0; }

            try
            { porcventa10 = Convert.ToDecimal(txtPorcVenta10.Text.Trim()); }
            catch
            { porcventa10 = 0; }

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
                    sentencia = string.Format("Update Ruedas Set PorcCompra1 =  @PorcCompra1," +
                                                                "PorcVenta1 =   @PorcVenta1," +
                                                                "PorcCompra2 =  @PorcCompra2," +
                                                                "PorcVenta2 =   @PorcVenta2," +
                                                                "PorcCompra3 =  @PorcCompra3," +
                                                                "PorcVenta3 =   @PorcVenta3," +
                                                                "PorcCompra4 =  @PorcCompra4," +
                                                                "PorcVenta4 =   @PorcVenta4," +
                                                                "PorcCompra5 =  @PorcCompra5," +
                                                                "PorcVenta5 =   @PorcVenta5," +
                                                                "PorcCompra6 =  @PorcCompra6," +
                                                                "PorcVenta6 =   @PorcVenta6, " +
                                                                "PorcCompra7 =  @PorcCompra7," +
                                                                "PorcVenta7 =   @PorcVenta7," +
                                                                "PorcCompra8 =  @PorcCompra8," +
                                                                "PorcVenta8 =   @PorcVenta8," +
                                                                "PorcCompra9 =  @PorcCompra9," +
                                                                "PorcVenta9 =   @PorcVenta9," +
                                                                "PorcCompra10 = @PorcCompra10," +
                                                                "PorcVenta10 =  @PorcVenta10 " +
                                                                " Where IdRueda = @IdRueda");

                    MySqlCommand comando = new MySqlCommand(sentencia, cone);
                    comando.Parameters.AddWithValue("@PorcCompra1", porccompra1);
                    comando.Parameters.AddWithValue("@PorcVenta1", porcventa1);
                    comando.Parameters.AddWithValue("@PorcCompra2", porccompra2);
                    comando.Parameters.AddWithValue("@PorcVenta2", porcventa2);
                    comando.Parameters.AddWithValue("@PorcCompra3", porccompra3);
                    comando.Parameters.AddWithValue("@PorcVenta3", porcventa3);
                    comando.Parameters.AddWithValue("@PorcCompra4", porccompra4);
                    comando.Parameters.AddWithValue("@PorcVenta4", porcventa4);
                    comando.Parameters.AddWithValue("@PorcCompra5", porccompra5);
                    comando.Parameters.AddWithValue("@PorcVenta5", porcventa5);
                    comando.Parameters.AddWithValue("@PorcCompra6", porccompra6);
                    comando.Parameters.AddWithValue("@PorcVenta6", porcventa6);
                    comando.Parameters.AddWithValue("@PorcCompra7", porccompra7);
                    comando.Parameters.AddWithValue("@PorcVenta7", porcventa7);
                    comando.Parameters.AddWithValue("@PorcCompra8", porccompra8);
                    comando.Parameters.AddWithValue("@PorcVenta8", porcventa8);
                    comando.Parameters.AddWithValue("@PorcCompra9", porccompra9);
                    comando.Parameters.AddWithValue("@PorcVenta9", porcventa9);
                    comando.Parameters.AddWithValue("@PorcCompra10", porccompra10);
                    comando.Parameters.AddWithValue("@PorcVenta10", porcventa10);
                    comando.Parameters.AddWithValue("@IdRueda", txtIdRueda.Text.Trim());
                    comando.ExecuteNonQuery();
                    cone.Close();
                    MessageBox.Show("Simulador Actualizado con Exito", "Información del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex )
            {
                MessageBox.Show(ex.Message + " - " + ex.ErrorCode.ToString(), "Informe de Errores", MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            ActualizarSimuladores();
        }

        private void dgvAccionesCompradas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAccionesCompradas.Columns["IdRuedaActual"].Visible = false;
            dgvAccionesCompradas.Columns["IdPanel"].Visible = false;
            dgvAccionesCompradas.Columns["PrecioVenta"].Visible = false;
            dgvAccionesCompradas.Columns["ImporteVenta"].Visible = false;
            dgvAccionesCompradas.Columns["IdRuedaDetalle"].Visible = false;
            dgvAccionesCompradas.Columns["IdRuedaCompra"].Visible = false;
            dgvAccionesCompradas.Columns["IdRuedaVenta"].Visible = false;
            dgvAccionesCompradas.Columns["IdSimulacion"].Visible = false;
            dgvAccionesCompradas.Columns["FechaVenta"].Visible = false;
            dgvAccionesCompradas.Columns["Estado"].Visible = false;
            dgvAccionesCompradas.Columns["PorcComisionIOL"].Visible = false;
            dgvAccionesCompradas.Columns["ImporteComisionIOL"].Visible = false;
        }

        private void btnCancelarRueda_Click_1(object sender, EventArgs e)
        {

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
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra6_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra7_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra8_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra9_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra10_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta6_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta7_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta8_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta9_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta10_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void nudSimulador_ValueChanged(object sender, EventArgs e)
        {
            ActualizarAccionesCompradas();
            int simulacion = 0;
            try { simulacion = Convert.ToInt32(nudSimulador.Value); }
            catch { simulacion = 0; }

            if (simulacion >= 1 && simulacion <= 5)
                lnkEstrategia.Text = "Estrategia Uno";
            else
                lnkEstrategia.Text = "Estrategia Dos";
        }
    }
}

