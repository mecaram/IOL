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
    public partial class frmCuentas : Form
    {
        public frmCuentas()
        {
            InitializeComponent();
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmCuentasEditar formulario = new frmCuentasEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 1;
            formulario.ShowDialog();
            tsbVerTodos_Click(sender, e);
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            frmCuentasEditar formulario = new frmCuentasEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 2;

            if (dgvListado.RowCount > 0)
            {
                string cuenta = dgvListado.CurrentRow.Cells["Comitente"].Value.ToString();
                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);
                MySqlDataAdapter da = new MySqlDataAdapter("Select * From Comitentes Where Comitente = " + cuenta, cone);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    formulario.txtComitente.Text = dt.Rows[0]["Comitente"].ToString();
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

            frmCuentasEditar formulario = new frmCuentasEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 3;

            if (dgvListado.RowCount > 0)
            {
                string cuenta = dgvListado.CurrentRow.Cells["Comitente"].Value.ToString();
                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                MySqlDataAdapter da = new MySqlDataAdapter("Select * From Comitentes Where Comitente = " + cuenta, cone);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    formulario.txtComitente.Text = dt.Rows[0]["Comitente"].ToString();

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

            frmCuentasEditar formulario = new frmCuentasEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 4;


            if (dgvListado.RowCount > 0)
            {
                string cuenta = dgvListado.CurrentRow.Cells["Comitente"].Value.ToString();
                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                MySqlDataAdapter da = new MySqlDataAdapter("Select * From Comitentes Where Comitente = " + cuenta, cone);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    formulario.txtComitente.Text = dt.Rows[0]["Comitente"].ToString();

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
                fBuscar.Text = "Busqueda de Cuentas";
                fBuscar.lblTitulo.Text = "Buscar Cuenta";
                fBuscar.cboBuscar.Items.Add("Comitente");
                fBuscar.cboBuscar.Items.Add("Apellido");
                fBuscar.cboBuscar.Items.Add("Usuario");
                fBuscar.cboBuscar.Text = "Apellido";
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
                            case "Comitente":
                                cWhere += " Where Comitente = " + cBuscar;
                                break;
                            case "Apellido":
                                cWhere += " Where Apellido like '%" + cBuscar + "%' Order By Apellido";
                                break;
                            case "Usuario":
                                cWhere += " Where Usuario Like '%" + cBuscar + "%' Order By Usuario";
                                break;
                        }
                    }
                    MySqlConnection coneCuentas = new MySqlConnection(cone);
                    string sqlComando = "Select Comitente, Apellido, Nombres, Usuario From Comitentes ";
                    sqlComando += cWhere;
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlComando, coneCuentas);
                    DataTable ds = new DataTable();
                    da.Fill(ds);

                    lblTotalCuentas.Text = string.Format("Total listado: {0}", ds.Rows.Count);
                    if (ds.Rows.Count > 0)
                    {
                        dgvListado.DataSource = ds;
                        dgvListado.RefreshEdit();
                    }
                    else
                    {
                        MessageBox.Show("Cuenta Inexistente", "Información del Sistema", MessageBoxButtons.OK);
                        frmCuentas_Load(sender, e);
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
            frmCuentas_Load(sender, e);
        }

        private void frmCuentas_Load(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            ContextMenu MenuContextual = new ContextMenu();
            MenuItem MenuAgregar = new MenuItem("&Agregar", tsbAgregar_Click, Shortcut.Alt1);
            MenuItem MenuModificar = new MenuItem("&Modificar", tsbModificar_Click, Shortcut.Alt2);
            MenuItem MenuEliminar = new MenuItem("&Eliminar", tsbEliminar_Click, Shortcut.Alt3);
            MenuItem MenuSeparador1 = new MenuItem("-");
            MenuItem MenuDetalle = new MenuItem("&Detalle", tsbDetalle_Click, Shortcut.Alt4);
            MenuItem MenuBuscar = new MenuItem("&Buscar...", tsbBuscar_Click, Shortcut.Alt5);

            MenuContextual.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { MenuAgregar, MenuModificar, MenuEliminar, MenuSeparador1, MenuDetalle, MenuBuscar });
            ContextMenu = MenuContextual;

            MySqlConnection coneCuentas = new MySqlConnection(cone);
            MySqlDataAdapter da = new MySqlDataAdapter("Select Comitente, Apellido, Nombres, Usuario From Comitentes Order By Comitente", coneCuentas);
            DataTable ds = new DataTable();
            da.Fill(ds);

            lblTotalCuentas.Text = string.Format("Total listado: {0}", ds.Rows.Count);
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

                dgvListado.Columns["Comitente"].HeaderText = "Comitente";
                dgvListado.Columns["Apellido"].HeaderText = "Apellido";
                dgvListado.Columns["Nombres"].HeaderText = "Nombres";
                dgvListado.Columns["Usuario"].HeaderText = "Usuario";

                dgvListado.Columns["Comitente"].Width = 120;
                dgvListado.Columns["Apellido"].Width = 120;
                dgvListado.Columns["Nombres"].Width = 120;
                dgvListado.Columns["Usuario"].Width = 150;

                dgvListado.Columns["Comitente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Apellido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Nombres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.Columns["Comitente"].DefaultCellStyle.Format = "0000";

                dgvListado.Columns["Comitente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Apellido"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Nombres"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Usuario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.RefreshEdit();
                dgvListado.Enabled = true;
            }
            else
            {
                dgvListado.DataSource = null;
                dgvListado.RefreshEdit();
            }

        }
    }
}
