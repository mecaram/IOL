﻿using System;
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
    public partial class Ruedas : Form
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();
        public int comitente = 0;
        public Ruedas()
        {
            InitializeComponent();
        }

        private void Ruedas_Load(object sender, EventArgs e)
        {
            ActualizarFeriados();
            ActualizarRuedas();

        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            DateTime? fecha = Calendario.SelectionStart.Date;
            string sentencia = string.Format("Select * From Ruedas Where Date_format(fechaRueda,'%y-%m-%d') = str_to_date('{0}','%d/%m/%y')", fecha.Value.Date.ToShortDateString());
            MySqlConnection coneRuedas = new MySqlConnection(conexion);
            MySqlDataAdapter daRuedas = new MySqlDataAdapter(sentencia, coneRuedas);
            DataTable dsRuedas = new DataTable();
            daRuedas.Fill(dsRuedas);
            if (dsRuedas.Rows.Count > 0)
            {
                MessageBox.Show("Rueda Registrada Anteriormente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                DayOfWeek nrodia = Calendario.SelectionStart.Date.DayOfWeek;
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
                        if (fecha < DateTime.Now.Date)
                        {
                            MessageBox.Show("La Fecha Seleccionada debe ser igual o mayor a la Actual", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                            tsbVerTodos_Click(sender, e);
                        }
                    }
                }
            }
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            string rueda = dgvListado.CurrentRow.Cells["IdRueda"].Value.ToString();
            if (rueda != null)
            {
                string sentencia = string.Format("Select * From Ruedas Where IdRueda = {0}", rueda);
                MySqlConnection coneRuedas = new MySqlConnection(conexion);
                MySqlDataAdapter daRuedas = new MySqlDataAdapter(sentencia, coneRuedas);
                DataTable dsRuedas = new DataTable();
                daRuedas.Fill(dsRuedas);
                if (dsRuedas.Rows.Count > 0)
                {
                    DateTime? fecha = Convert.ToDateTime(dsRuedas.Rows[0]["FechaRueda"]);
                    RuedasEditar formulario = new RuedasEditar();
                    formulario.StartPosition = FormStartPosition.CenterScreen;
                    formulario.operacion = 2;
                    formulario.comitente = comitente;
                    formulario.txtIdRueda.Text = rueda;
                    formulario.txtFecha.Text = fecha.Value.Date.ToShortDateString();
                    formulario.txtFecha.Enabled = false;
                    formulario.ShowDialog();
                    tsbVerTodos_Click(sender, e);
                }
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            string rueda = dgvListado.CurrentRow.Cells["IdRueda"].Value.ToString();
            if (rueda != null)
            {
                RuedasEditar formulario = new RuedasEditar();
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.operacion = 3;

                if (dgvListado.RowCount > 0)
                {
                    int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                    string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select * From Ruedas Where IdRueda = " + rueda, cone);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        formulario.txtIdRueda.Text = dt.Rows[0]["IdRueda"].ToString();

                        formulario.ShowDialog();
                        tsbVerTodos_Click(sender, e);
                        if (fila < dgvListado.Rows.Count)
                            dgvListado.CurrentCell = dgvListado[0, fila];
                    }
                }
            }
        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            string rueda = dgvListado.CurrentRow.Cells["IdRueda"].Value.ToString();

            if (rueda != null)
            {
                RuedasEditar formulario = new RuedasEditar();
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.operacion = 4;


                if (dgvListado.RowCount > 0)
                {
                    int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                    string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select * From Ruedas Where IdRueda = " + rueda, cone);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        formulario.txtIdRueda.Text = dt.Rows[0]["IdRueda"].ToString();

                        formulario.ShowDialog();
                        tsbVerTodos_Click(sender, e);
                        if (fila < dgvListado.Rows.Count)
                            dgvListado.CurrentCell = dgvListado[0, fila];
                    }
                }
            }
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
                dgvListado.CurrentCell = dgvListado[0, 0];
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            if (dgvListado.RowCount > 0)
            {
                int nReg = Convert.ToUInt16(dgvListado.CurrentRow.Index);
                if (nReg < (dgvListado.RowCount + 1) && (nReg > 0))
                    dgvListado.CurrentCell = dgvListado[0, nReg - 1];
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {

        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            if (dgvListado.RowCount > 0)
            {
                int nReg = Convert.ToUInt16(dgvListado.CurrentRow.Index);
                if (nReg < (dgvListado.RowCount - 1))
                    dgvListado.CurrentCell = dgvListado[0, nReg + 1];
            }
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int contar = dgvListado.Rows.Count;
                if (contar > 0)
                    dgvListado.CurrentCell = dgvListado[0, contar - 1];
            }
        }

        private void tsbVerTodos_Click(object sender, EventArgs e)
        {
            Ruedas_Load(sender, e);
        }

        private void Calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime? fecha = Calendario.SelectionStart.Date;
            string sentencia = string.Format("Select * From Ruedas Where Date_format(fechaRueda,'%y-%m-%d') = str_to_date('{0}','%d/%m/%y')", fecha.Value.Date.ToShortDateString());
            MySqlConnection coneRuedas = new MySqlConnection(conexion);
            MySqlDataAdapter daRuedas = new MySqlDataAdapter(sentencia, coneRuedas);
            DataTable dsRuedas = new DataTable();
            daRuedas.Fill(dsRuedas);
            if (dsRuedas.Rows.Count > 0)
            {
                RuedasEditar formulario = new RuedasEditar();
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.operacion = 2;
                formulario.comitente = comitente;
                formulario.txtIdRueda.Text = dsRuedas.Rows[0]["IdRueda"].ToString();
                formulario.txtFecha.Text = fecha.Value.Date.ToShortDateString();
                formulario.txtFecha.Enabled = false;
                formulario.ShowDialog();
                tsbVerTodos_Click(sender, e);
            }
            else
            {
                DayOfWeek nrodia = Calendario.SelectionStart.Date.DayOfWeek;
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
                        if (fecha < DateTime.Now.Date)
                        {
                            MessageBox.Show("La Fecha Seleccionada debe ser igual o mayor a la Actual", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                            tsbVerTodos_Click(sender, e);
                        }
                    }
                }
            }
        }

        private void Calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            ActualizarFeriados();
            ActualizarRuedas();
        }

        private void ActualizarFeriados()
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            int Mes = Calendario.SelectionStart.Date.Month;
            string sentencia = string.Format("Select Fecha, Motivo From Feriados Where Month(Fecha) = {0} Order By Fecha Desc", Mes);
            MySqlConnection coneFeriados = new MySqlConnection(cone);
            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, coneFeriados);
            DataTable ds = new DataTable();
            da.Fill(ds);

            if (ds.Rows.Count > 0)
            {
                dgvFeriados.DataSource = ds;

                DataGridViewCellStyle EstiloEncabezadoColumna = new DataGridViewCellStyle();

                EstiloEncabezadoColumna.BackColor = Color.Green;
                EstiloEncabezadoColumna.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                dgvFeriados.ColumnHeadersDefaultCellStyle = EstiloEncabezadoColumna;

                DataGridViewCellStyle EstiloColumnas = new DataGridViewCellStyle();
                EstiloColumnas.BackColor = Color.AliceBlue;
                EstiloColumnas.Font = new Font("Times New Roman", 12);
                dgvFeriados.RowsDefaultCellStyle = EstiloColumnas;

                dgvFeriados.Columns["Fecha"].HeaderText = "Fecha";
                dgvFeriados.Columns["Motivo"].HeaderText = "Motivo";

                dgvFeriados.Columns["Fecha"].Width = 100;
                dgvFeriados.Columns["Motivo"].Width = 100;

                dgvFeriados.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvFeriados.Columns["Motivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvFeriados.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvFeriados.Columns["Motivo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvFeriados.RefreshEdit();
                dgvFeriados.Enabled = true;
            }
            else
            {
                dgvFeriados.DataSource = null;
                dgvFeriados.RefreshEdit();
            }
        }

        private void ActualizarRuedas()
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            int Mes = Calendario.SelectionStart.Date.Month;
            string sentencia = string.Format("Select IdRueda, FechaRueda, CantAcciones, PorcCompra, PorcVenta, if(Operar=1,'SI','NO') as Operar From Ruedas Where Month(FechaRueda) = {0} Order By FechaRueda", Mes);
            MySqlConnection coneRuedas = new MySqlConnection(cone);
            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, coneRuedas);
            DataTable ds = new DataTable();
            da.Fill(ds);

            if (ds.Rows.Count > 0)
            {
                dgvListado.DataSource = ds;

                DataGridViewCellStyle EstiloEncabezadoColumna = new DataGridViewCellStyle();

                EstiloEncabezadoColumna.BackColor = Color.Green;
                EstiloEncabezadoColumna.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                dgvListado.ColumnHeadersDefaultCellStyle = EstiloEncabezadoColumna;

                DataGridViewCellStyle EstiloColumnas = new DataGridViewCellStyle();
                EstiloColumnas.BackColor = Color.AliceBlue;
                EstiloColumnas.Font = new Font("Times New Roman", 12);
                dgvListado.RowsDefaultCellStyle = EstiloColumnas;

                dgvListado.Columns["IdRueda"].HeaderText = "Id.Rueda";
                dgvListado.Columns["FechaRueda"].HeaderText = "Fecha";
                dgvListado.Columns["CantAcciones"].HeaderText = "Acciones";
                dgvListado.Columns["PorcCompra"].HeaderText = "Porc.Compra";
                dgvListado.Columns["PorcVenta"].HeaderText = "Porc.Venta";
                dgvListado.Columns["Operar"].HeaderText = "Operar";

                dgvListado.Columns["IdRueda"].Width = 80;
                dgvListado.Columns["FechaRueda"].Width = 80;
                dgvListado.Columns["CantAcciones"].Width = 100;
                dgvListado.Columns["PorcCompra"].Width = 110;
                dgvListado.Columns["PorcVenta"].Width = 110;
                dgvListado.Columns["Operar"].Width = 80;

                dgvListado.Columns["IdRueda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["FechaRueda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["CantAcciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["PorcCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["PorcVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Operar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.Columns["IdRueda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["FechaRueda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["CantAcciones"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["PorcCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["PorcVenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Operar"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.RefreshEdit();
                dgvListado.Enabled = true;
            }
            else
            {
                dgvListado.DataSource = null;
                dgvListado.RefreshEdit();
            }
        }

        private void btnFeriados_Click(object sender, EventArgs e)
        {
            Feriados formulario = new Feriados();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            ActualizarFeriados();
            Refresh();
        }
    }
}
