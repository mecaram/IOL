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
    public partial class Feriados : Form
    {
        public Feriados()
        {
            InitializeComponent();
        }

        private void Feriados_Load(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            MySqlConnection coneFeriados = new MySqlConnection(cone);
            int Mes = Calendario.SelectionStart.Date.Month;
            string sentencia = string.Format("Select IdFeriado, Fecha, Motivo From Feriados Where Month(Fecha) = {0} Order By Fecha", Mes);
            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, coneFeriados);
            DataTable ds = new DataTable();
            da.Fill(ds);

            lblTotalFeriados.Text = string.Format("Total listado: {0}", ds.Rows.Count);
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

                dgvListado.Columns["IdFeriado"].HeaderText = "Id.Feriado";
                dgvListado.Columns["Fecha"].HeaderText = "Fecha";
                dgvListado.Columns["Motivo"].HeaderText = "Motivo";

                dgvListado.Columns["IdFeriado"].Width = 100;
                dgvListado.Columns["Fecha"].Width = 100;
                dgvListado.Columns["Motivo"].Width = 160;

                dgvListado.Columns["IdFeriado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Motivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.Columns["IdFeriado"].DefaultCellStyle.Format = "000";

                dgvListado.Columns["IdFeriado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Motivo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.RefreshEdit();
                dgvListado.Enabled = true;
            }
            else
            {
                dgvListado.DataSource = null;
                dgvListado.RefreshEdit();
            }
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            FeriadosEditar formulario = new FeriadosEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 1;
            formulario.txtFecha.Text = Calendario.SelectionStart.Date.ToShortDateString();
            formulario.txtFecha.Enabled = false;
            formulario.ShowDialog();
            tsbVerTodos_Click(sender, e);
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            FeriadosEditar formulario = new FeriadosEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 2;

            if (dgvListado.RowCount > 0)
            {
                string feriado = dgvListado.CurrentRow.Cells["IdFeriado"].Value.ToString();
                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);
                MySqlDataAdapter da = new MySqlDataAdapter("Select * From Feriados Where IdFeriado = " + feriado, cone);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    formulario.txtIdFeriado.Text = dt.Rows[0]["IdFeriado"].ToString();
                    formulario.txtFecha.Text = dt.Rows[0]["Fecha"].ToString();
                }
                formulario.ShowDialog();
                tsbVerTodos_Click(sender, e);
                if (fila < dgvListado.Rows.Count)
                    dgvListado.CurrentCell = dgvListado[0, fila];
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            FeriadosEditar formulario = new FeriadosEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 3;

            if (dgvListado.RowCount > 0)
            {
                string feriado = dgvListado.CurrentRow.Cells["IdFeriado"].Value.ToString();
                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                MySqlDataAdapter da = new MySqlDataAdapter("Select * From Feriados Where IdFeriado = " + feriado, cone);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    formulario.txtIdFeriado.Text = dt.Rows[0]["IdFeriado"].ToString();

                    formulario.ShowDialog();
                    tsbVerTodos_Click(sender, e);
                    if (fila < dgvListado.Rows.Count)
                        dgvListado.CurrentCell = dgvListado[0, fila];
                }
            }
        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            FeriadosEditar formulario = new FeriadosEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 4;


            if (dgvListado.RowCount > 0)
            {
                string feriado = dgvListado.CurrentRow.Cells["IdFeriado"].Value.ToString();
                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                MySqlDataAdapter da = new MySqlDataAdapter("Select * From Feriados Where IdFeriado = " + feriado, cone);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    formulario.txtIdFeriado.Text = dt.Rows[0]["IdFeriado"].ToString();

                    formulario.ShowDialog();
                    tsbVerTodos_Click(sender, e);
                    if (fila < dgvListado.Rows.Count)
                        dgvListado.CurrentCell = dgvListado[0, fila];
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
            if (dgvListado.RowCount > 0)
            {
                string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();
                Buscar fBuscar = new Buscar();
                fBuscar.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                fBuscar.Text = "Busqueda de Feriados";
                fBuscar.lblTitulo.Text = "Buscar Feriado";
                fBuscar.cboBuscar.Items.Add("Id.Feriado");
                fBuscar.cboBuscar.Items.Add("Fecha");
                fBuscar.cboBuscar.Items.Add("Motivo");
                fBuscar.cboBuscar.Text = "Feriado";
                fBuscar.rctBuscar.Focus();
                fBuscar.ShowDialog(this);
                if (fBuscar.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    string cWhere = "";

                    string tipobusqueda = fBuscar.cboBuscar.Text.Trim();
                    string cBuscar = fBuscar.rctBuscar.Text.Trim();

                    if (cBuscar.Length > 0)
                    {
                        switch (tipobusqueda)
                        {
                            case "Id.Feriado":
                                cWhere += " Where IdFeriado = " + cBuscar;
                                break;
                            case "Fecha":
                                cWhere += " Where Date_format(fecha,'%y-%m-%d') = str_to_date('" + cBuscar + "','%d/%m/%y') ";
                                break;
                            case "Motivo":
                                cWhere += " Where Motivo Like '%" + cBuscar + "%' Order By Motivo";
                                break;
                        }
                    }
                    MySqlConnection coneCuentas = new MySqlConnection(cone);
                    string sqlComando = "Select IdFeriado, Feriado, Motivo From Feriados ";
                    sqlComando += cWhere;
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlComando, coneCuentas);
                    DataTable ds = new DataTable();
                    da.Fill(ds);

                    lblTotalFeriados.Text = string.Format("Total listado: {0}", ds.Rows.Count);
                    if (ds.Rows.Count > 0)
                    {
                        dgvListado.DataSource = ds;
                        dgvListado.RefreshEdit();
                    }
                    else
                    {
                        MessageBox.Show("Feriado Inexistente", "Información del Sistema", MessageBoxButtons.OK);
                        Feriados_Load(sender, e);
                    }
                }
            }
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
            Feriados_Load(sender, e);

        }

        private void Calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            DateTime Fecha = Calendario.SelectionStart;
            string sentencia = string.Format("Select * From Feriados Where Date_format(fecha,'%y-%m-%d') = str_to_date('{0}','%d/%m/%y')", Fecha.Date.ToShortDateString());
            MySqlDataAdapter da = new MySqlDataAdapter(sentencia, cone);
            DataTable dt = new DataTable();
            int registros = da.Fill(dt);
            if (registros > 0)
            {
                tsbModificar_Click(sender, e);
            }
            else
            {
                if (Fecha >= DateTime.Now.Date)
                {
                    FeriadosEditar formulario = new FeriadosEditar();
                    formulario.StartPosition = FormStartPosition.CenterScreen;
                    formulario.operacion = 1;
                    formulario.txtFecha.Text = Fecha.Date.ToShortDateString();
                    formulario.txtFecha.Enabled = false;
                    formulario.ShowDialog();
                    tsbVerTodos_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Fecha anterior a la Actual", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void Calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            Feriados_Load(sender, e);
        }
    }
}
