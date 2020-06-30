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
    public partial class RuedasEditar : Form
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();
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
                    try
                    { fecha = Convert.ToDateTime(txtFecha.Text.Trim()); }
                    catch
                    { fecha = null; }

                    MySqlConnection coneAgregar = new MySqlConnection(conexion);
                    string sentencia = string.Format("Select * From Ruedas Where Date_format(FechaRueda, '%d-%m-%y') < str_to_date('{0}', '%d/%m/%y')", fecha.Value.ToString("dd/MM/yy"));
                    MySqlDataAdapter daAgregar = new MySqlDataAdapter(sentencia, coneAgregar);
                    DataTable dsAgregar = new DataTable();
                    daAgregar.Fill(dsAgregar);
                    if (dsAgregar.Rows.Count > 0)
                    {
                        nupCantAcciones.Value = Convert.ToDecimal(dsAgregar.Rows[0]["CantAcciones"]);
                        txtPorcComisionIOL.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcComisionIOL"]));
                        txtPorcCompra.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra"]));
                        txtPorcVenta.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta"]));
                        txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcPuntaCompradora"]));
                        txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcPuntaVendedora"]));
                        nudComprarHasta.Value = Convert.ToInt32(dsAgregar.Rows[0]["ComprarHasta"]);

                        int operar = Convert.ToInt16(dsAgregar.Rows[0]["Operar"]);
                        if (operar == 0)
                        {
                            chkNo.Checked = true;
                        }
                        else
                        {
                            chkSi.Checked = true;
                        }

                        txtPorcCompra1.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra1"]));
                        txtPorcCompra2.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra2"]));
                        txtPorcCompra3.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra3"]));
                        txtPorcCompra4.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra4"]));
                        txtPorcCompra5.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra5"]));
                        txtPorcCompra6.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra6"]));
                        txtPorcCompra7.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra7"]));
                        txtPorcCompra8.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra8"]));
                        txtPorcCompra9.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra9"]));
                        txtPorcCompra10.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcCompra10"]));

                        txtPorcVenta1.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta1"]));
                        txtPorcVenta2.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta2"]));
                        txtPorcVenta3.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta3"]));
                        txtPorcVenta4.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta4"]));
                        txtPorcVenta5.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta5"]));
                        txtPorcVenta6.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta6"]));
                        txtPorcVenta7.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta7"]));
                        txtPorcVenta8.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta8"]));
                        txtPorcVenta9.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta9"]));
                        txtPorcVenta10.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsAgregar.Rows[0]["PorcVenta10"]));
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

                    MySqlConnection coneModificar = new MySqlConnection(conexion);
                    MySqlDataAdapter da = new MySqlDataAdapter("Select * from Ruedas Where IdRueda = " + txtIdRueda.Text.Trim(), coneModificar);
                    DataTable dsModificar = new DataTable();
                    da.Fill(dsModificar);
                    if (dsModificar.Rows.Count > 0)
                    {
                        txtIdRueda.Text = dsModificar.Rows[0]["IdRueda"].ToString();
                        decimal inversiontotal = 0;
                        try { inversiontotal = Convert.ToDecimal(dsModificar.Rows[0]["InversionTotal"]); }
                        catch { inversiontotal = 0; }

                        txtSaldoARetirar.Text = string.Format("$ {0:00.00}", inversiontotal);
                        nupCantAcciones.Value = Convert.ToDecimal(dsModificar.Rows[0]["CantAcciones"]);
                        txtPorcComisionIOL.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcComisionIOL"]));
                        txtPorcCompra.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra"]));
                        txtPorcVenta.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta"]));
                        txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcPuntaCompradora"]));
                        txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcPuntaVendedora"]));
                        nudComprarHasta.Value = Convert.ToInt32(dsModificar.Rows[0]["ComprarHasta"]);

                        int operar = Convert.ToInt16(dsModificar.Rows[0]["Operar"]);
                        if (operar == 0)
                        {
                            chkNo.Checked = true;
                        }
                        else
                        {
                            chkSi.Checked = true;
                        }

                        txtPorcCompra1.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra1"]));
                        txtPorcCompra2.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra2"]));
                        txtPorcCompra3.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra3"]));
                        txtPorcCompra4.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra4"]));
                        txtPorcCompra5.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra5"]));
                        txtPorcCompra6.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra6"]));
                        txtPorcCompra7.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra7"]));
                        txtPorcCompra8.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra8"]));
                        txtPorcCompra9.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra9"]));
                        txtPorcCompra10.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcCompra10"]));

                        txtPorcVenta1.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta1"]));
                        txtPorcVenta2.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta2"]));
                        txtPorcVenta3.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta3"]));
                        txtPorcVenta4.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta4"]));
                        txtPorcVenta5.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta5"]));
                        txtPorcVenta6.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta6"]));
                        txtPorcVenta7.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta7"]));
                        txtPorcVenta8.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta8"]));
                        txtPorcVenta9.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta9"]));
                        txtPorcVenta10.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsModificar.Rows[0]["PorcVenta10"]));

                        this.Text = "Modificar Rueda";
                    }
                    txtFecha.Enabled = false;
                    txtSaldoARetirar.Focus();
                    break;
                case 3: //Eliminar
                    tsbEliminar.Visible = false;

                    MySqlConnection coneEliminar = new MySqlConnection(conexion);
                    MySqlDataAdapter daEliminar = new MySqlDataAdapter("Select * from Ruedas Where IdRueda = " + txtIdRueda.Text.Trim(), coneEliminar);
                    DataTable dsEliminar = new DataTable();
                    daEliminar.Fill(dsEliminar);
                    if (dsEliminar.Rows.Count > 0)
                    {
                        txtIdRueda.Text = dsEliminar.Rows[0]["IdRueda"].ToString();
                        txtFecha.Text = dsEliminar.Rows[0]["FechaRueda"].ToString().Substring(0,10);
                        decimal inversiontotal = 0;
                        try { inversiontotal = Convert.ToDecimal(dsEliminar.Rows[0]["InversionTotal"]); }
                        catch { inversiontotal = 0; }

                        txtSaldoARetirar.Text = string.Format("$ {0:00.00}", inversiontotal);
                        nupCantAcciones.Value = Convert.ToDecimal(dsEliminar.Rows[0]["CantAcciones"]);
                        txtPorcComisionIOL.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcComisionIOL"]));
                        txtPorcCompra.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra"]));
                        txtPorcVenta.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta"]));
                        txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcPuntaCompradora"]));
                        txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcPuntaVendedora"]));
                        nudComprarHasta.Value = Convert.ToInt32(dsEliminar.Rows[0]["ComprarHasta"]);

                        int operar = Convert.ToInt16(dsEliminar.Rows[0]["Operar"]);
                        if (operar == 0)
                        {
                            chkNo.Checked = true;
                        }
                        else
                        {
                            chkSi.Checked = true;
                        }

                        txtPorcCompra1.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra1"]));
                        txtPorcCompra2.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra2"]));
                        txtPorcCompra3.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra3"]));
                        txtPorcCompra4.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra4"]));
                        txtPorcCompra5.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra5"]));
                        txtPorcCompra6.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra6"]));
                        txtPorcCompra7.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra7"]));
                        txtPorcCompra8.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra8"]));
                        txtPorcCompra9.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra9"]));
                        txtPorcCompra10.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcCompra10"]));

                        txtPorcVenta1.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta1"]));
                        txtPorcVenta2.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta2"]));
                        txtPorcVenta3.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta3"]));
                        txtPorcVenta4.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta4"]));
                        txtPorcVenta5.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta5"]));
                        txtPorcVenta6.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta6"]));
                        txtPorcVenta7.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta7"]));
                        txtPorcVenta8.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta8"]));
                        txtPorcVenta9.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta9"]));
                        txtPorcVenta10.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsEliminar.Rows[0]["PorcVenta10"]));

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

                        chkNo.Enabled = false;
                        chkSi.Enabled = false;

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

                        tsbGuardar.Visible = false;
                        tsbEliminar.Visible = true;
                        tsbEliminar.Enabled = true;
                    }
                    break;
                case 4: //Detalle
                    tsbEliminar.Visible = false;

                    MySqlConnection coneDetalle = new MySqlConnection(conexion);
                    MySqlDataAdapter daDetalle = new MySqlDataAdapter("Select * from Ruedas Where IdRueda = " + txtIdRueda.Text.Trim(), coneDetalle);
                    DataTable dsDetalle = new DataTable();
                    daDetalle.Fill(dsDetalle);
                    if (dsDetalle.Rows.Count > 0)
                    {
                        txtIdRueda.Text = dsDetalle.Rows[0]["IdRueda"].ToString();
                        txtFecha.Text = dsDetalle.Rows[0]["FechaRueda"].ToString().Substring(0, 10);
                        decimal inversiontotal = 0;
                        try { inversiontotal = Convert.ToDecimal(dsDetalle.Rows[0]["InversionTotal"]); }
                        catch { inversiontotal = 0; }

                        txtSaldoARetirar.Text = string.Format("$ {0:00.00}", inversiontotal);
                        nupCantAcciones.Value = Convert.ToDecimal(dsDetalle.Rows[0]["CantAcciones"]);
                        txtPorcComisionIOL.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcComisionIOL"]));
                        txtPorcCompra.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra"]));
                        txtPorcVenta.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta"]));
                        txtPorcPuntaCompradora.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcPuntaCompradora"]));
                        txtPorcPuntaVendedora.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcPuntaVendedora"]));
                        nudComprarHasta.Value = Convert.ToInt32(dsDetalle.Rows[0]["ComprarHasta"]);

                        int operar = Convert.ToInt16(dsDetalle.Rows[0]["Operar"]);
                        if (operar == 0)
                        {
                            chkNo.Checked = true;
                        }
                        else
                        {
                            chkSi.Checked = true;
                        }

                        txtPorcCompra1.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra1"]));
                        txtPorcCompra2.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra2"]));
                        txtPorcCompra3.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra3"]));
                        txtPorcCompra4.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra4"]));
                        txtPorcCompra5.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra5"]));
                        txtPorcCompra6.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra6"]));
                        txtPorcCompra7.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra7"]));
                        txtPorcCompra8.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra8"]));
                        txtPorcCompra9.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra9"]));
                        txtPorcCompra10.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcCompra10"]));

                        txtPorcVenta1.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta1"]));
                        txtPorcVenta2.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta2"]));
                        txtPorcVenta3.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta3"]));
                        txtPorcVenta4.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta4"]));
                        txtPorcVenta5.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta5"]));
                        txtPorcVenta6.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta6"]));
                        txtPorcVenta7.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta7"]));
                        txtPorcVenta8.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta8"]));
                        txtPorcVenta9.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta9"]));
                        txtPorcVenta10.Text = string.Format("{0:00.00}", Convert.ToDecimal(dsDetalle.Rows[0]["PorcVenta10"]));

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

                        chkNo.Enabled = false;
                        chkSi.Enabled = false;

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

                        this.Text = "Detalle Rueda";

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

            int operar = 0;
            if (chkSi.Checked)
            {
                operar = 1;
            }

            decimal cantacciones = 0,
                    saldoaretirar = 0,
                    porccomisionIOL = 0,
                    porccompra = 0,
                    porcventa = 0,
                    porcpuntacompradora = 0,
                    porcpuntavendedora = 0,
                    comprarhasta = 0;

            if (operar == 1)
            {
                try
                { saldoaretirar = Convert.ToDecimal(txtSaldoARetirar.Text.Trim().Replace("$", "")); }
                catch
                { saldoaretirar = 0; }

                try
                { cantacciones = Convert.ToDecimal(nupCantAcciones.Value); }
                catch
                { cantacciones = 0; }

                try
                { porccomisionIOL = Convert.ToDecimal(txtPorcComisionIOL.Text.Trim()); }
                catch
                { porccomisionIOL = 0; }

                try
                { porccompra = Convert.ToDecimal(txtPorcCompra.Text.Trim()); }
                catch
                { porccompra = 0; }

                try
                { porcventa = Convert.ToDecimal(txtPorcVenta.Text.Trim()); }
                catch
                { porcventa = 0; }

                try
                { comprarhasta = Convert.ToInt16(nudComprarHasta.Value); }
                catch
                { comprarhasta = 0; }

                try
                { porcpuntacompradora = Convert.ToDecimal(txtPorcPuntaCompradora.Text.Trim()); }
                catch
                { porcpuntacompradora = 0; }

                try
                { porcpuntavendedora = Convert.ToDecimal(txtPorcPuntaVendedora.Text.Trim()); }
                catch
                { porcpuntavendedora = 0; }

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
            cone.Open();
            if (operacion == 1)
            {
                sentencia = string.Format("Insert Into Ruedas(FechaRueda, DiaRueda, SaldoARetirar," +
                                          "PorcComisionIOL, Operar, PorcCompra, PorcVenta, PorcCompra1, PorcVenta1," +
                                          "PorcCompra2, PorcVenta2, PorcCompra3, PorcVenta3," +
                                          "PorcCompra4, PorcVenta4, PorcCompra5, PorcVenta5," +
                                          "PorcCompra6, PorcVenta6, PorcCompra7, PorcVenta7," +
                                          "PorcCompra8, PorcVenta8, PorcCompra9, PorcVenta9," +
                                          "PorcCompra10, PorcVenta10," +
                                          "CantAcciones, PorcPuntaCompradora, PorcPuntaVendedora, ComprarHasta, Comitente)" +
                                          " Values(str_to_date('{0}','%d/%m/%y'),{1},{2}," +
                                          "{3},{4},{5},{6},{7},{8}," +
                                          "{9},{10},{11},{12}," +
                                          "{13},{14},{15},{16}," +
                                          "{17},{18},{19},{20}," +
                                          "{21},{22}," +
                                          "{23},{24},{25},{26},{27},{28},{29},{30},{31})",
                                          fecha.Value.ToString("dd/MM/yy"), diarueda, saldoaretirar,
                                          porccomisionIOL, operar, porccompra, porcventa, porccompra1, porcventa1,
                                          porccompra2, porcventa2, porccompra3, porcventa3,
                                          porccompra4, porcventa4, porccompra5, porcventa5,
                                          porccompra6, porcventa6, porccompra7, porcventa7,
                                          porccompra8, porcventa8, porccompra9, porcventa9,
                                          porccompra10, porcventa10,
                                          cantacciones, porcpuntacompradora, porcpuntavendedora, comprarhasta, comitente);
                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                cone.Close();

                MySqlConnection coneUltimaRueda = new MySqlConnection(conexion);
                MySqlDataAdapter daUltimaRueda = new MySqlDataAdapter("Select * from Ruedas Order By IdRueda Desc", coneUltimaRueda);
                DataTable dsUltimaRueda = new DataTable();
                int regRueda = daUltimaRueda.Fill(dsUltimaRueda);
                if (regRueda > 0)
                {
                    txtIdRueda.Text = Convert.ToString(dsUltimaRueda.Rows[0]["IdRueda"]);
                }
            }
            else
            {
                sentencia = string.Format("Update Ruedas Set SaldoARetirar = {0}," +
                                                            "PorcComisionIOL =  {1}," +
                                                            "Operar =  {2}," +
                                                            "PorcCompra =  {3}," +
                                                            "PorcVenta =  {4}," +
                                                            "PorcCompra1 =  {5}," +
                                                            "PorcVenta1 =  {6}," +
                                                            "PorcCompra2 =  {7}," +
                                                            "PorcVenta2 =  {8}," +
                                                            "PorcCompra3 =  {9}," +
                                                            "PorcVenta3 =  {10}," +
                                                            "PorcCompra4 =  {11}," +
                                                            "PorcVenta4 =  {12}," +
                                                            "PorcCompra5 =  {13}," +
                                                            "PorcVenta5 =  {14}," +
                                                            "PorcCompra6 =  {15}," +
                                                            "PorcVenta6 =  {16}," +
                                                            "PorcCompra7 =  {17}," +
                                                            "PorcVenta7 =  {18}," +
                                                            "PorcCompra8 =  {19}," +
                                                            "PorcVenta8 =  {20}," +
                                                            "PorcCompra9 =  {21}," +
                                                            "PorcVenta9 =  {22}," +
                                                            "PorcCompra10 =  {23}," +
                                                            "PorcVenta10 =  {24}," +
                                                            "CantAcciones =  {25}," +
                                                            "PorcPuntaCompradora =  {26}," +
                                                            "PorcPuntaVendedora =  {27}," +
                                                            "ComprarHasta =  {28}," +
                                                            "Comitente =  {29} " +
                                                            " Where IdRueda = {30}",
                                                            saldoaretirar,
                                                            porccomisionIOL,
                                                            operar,
                                                            porccompra,
                                                            porcventa,
                                                            porccompra1,
                                                            porcventa1,
                                                            porccompra2,
                                                            porcventa2,
                                                            porccompra3,
                                                            porcventa3,
                                                            porccompra4,
                                                            porcventa4,
                                                            porccompra5,
                                                            porcventa5,
                                                            porccompra6,
                                                            porcventa6,
                                                            porccompra7,
                                                            porcventa7,
                                                            porccompra8,
                                                            porcventa8,
                                                            porccompra9,
                                                            porcventa9,
                                                            porccompra10,
                                                            porcventa10,
                                                            cantacciones,
                                                            porcpuntacompradora,
                                                            porcpuntavendedora,
                                                            comprarhasta,
                                                            comitente,
                                                            txtIdRueda.Text.Trim());
                MySqlCommand comando = new MySqlCommand(sentencia, cone);
                comando.CommandType = CommandType.Text;

                comando.ExecuteNonQuery();
                cone.Close();
            }

            using (MySqlConnection ConeActualizarSimulador = new MySqlConnection(conexion))
            {
                sentencia = "ActualizarTenenciasSimulador";
                ConeActualizarSimulador.Open();
                MySqlCommand comandoSimulador = new MySqlCommand(sentencia, ConeActualizarSimulador);
                comandoSimulador.CommandType = CommandType.StoredProcedure;
                comandoSimulador.Parameters.AddWithValue("rueda", txtIdRueda.Text.Trim());
                comandoSimulador.ExecuteNonQuery();
                ConeActualizarSimulador.Close();
            }
            Close();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea realmente dar de baja esta Rueda ?", "Solicitud del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                MySqlConnection coneEliminar = new MySqlConnection(conexion);
                coneEliminar.Open();

                string sentencia = string.Format("Delete From Ruedas Where IdRueda = {0}", txtIdRueda.Text.Trim());
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
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
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

        private void txtPorcCompra2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPorcCompra4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPorcVenta1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPorcVenta3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPorcVenta5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void txtPorcComision_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcVenta_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcCompra1_Leave(object sender, EventArgs e)
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

        private void txtPorcCompra3_Leave(object sender, EventArgs e)
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

        private void txtPorcCompra5_Leave(object sender, EventArgs e)
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

        private void txtPorcVenta3_Leave(object sender, EventArgs e)
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

        private void txtPorcVenta5_Leave(object sender, EventArgs e)
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

        private void txtPorcCompra1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcVenta1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcVenta2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcCompra2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcCompra3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcVenta3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcVenta4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcVenta5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcCompra5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcCompra4_TextChanged(object sender, EventArgs e)
        {

        }

        private void nupCantAcciones_Click(object sender, EventArgs e)
        {
        }

        private void nupCantAcciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtSaldoARetirar_Leave(object sender, EventArgs e)
        {
            decimal SaldoARetirar = Convert.ToDecimal(txtSaldoARetirar.Text.Replace("$", ""));
            txtSaldoARetirar.Text = string.Format("$ {0:00.00}", SaldoARetirar);
        }

        private void txtSaldoARetirar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
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
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcPuntaVendedora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
        }

        private void txtPorcPuntaCompradora_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void txtPorcPuntaVendedora_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            decimal Porcentaje = Convert.ToDecimal(control.Text.Trim());
            control.Text = string.Format("{0:00.00}", Porcentaje);
        }

        private void nudComprarHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SendKeys.Send("{Tab}");
            else
                e.Handled = true;
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
    }
}
