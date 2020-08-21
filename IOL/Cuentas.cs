using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using IOL.Servicios;

namespace IOL
{
    public partial class frmCuentas : Form
    {
        private readonly ServiciosComitente _service = new ServiciosComitente();
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
            frmCuentas_Load(sender, e);
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            frmCuentasEditar formulario = new frmCuentasEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 2;

            if (dgvListado.RowCount > 0)
            {
                int idCuenta = Convert.ToInt32(dgvListado.CurrentRow.Cells["Comitente"].Value);
                var lstComitentes = _service.GetById(idCuenta);

                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                if (lstComitentes != null)
                {
                    formulario.txtComitente.Text = lstComitentes.Comitente.ToString();
                }
                formulario.ShowDialog();
                frmCuentas_Load(sender, e);
                if (fila < dgvListado.Rows.Count)
                    dgvListado.CurrentCell = dgvListado[0, fila];
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            frmCuentasEditar formulario = new frmCuentasEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 3;

            if (dgvListado.RowCount > 0)
            {
                int idCuenta = Convert.ToInt32(dgvListado.CurrentRow.Cells["Comitente"].Value);
                var lstComitentes = _service.GetById(idCuenta);

                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                if (lstComitentes != null)
                {
                    formulario.txtComitente.Text = lstComitentes.Comitente.ToString();
                    formulario.ShowDialog();
                    frmCuentas_Load(sender, e);
                    if (fila < dgvListado.Rows.Count)
                        dgvListado.CurrentCell = dgvListado[0, fila];
                }
            }
        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            frmCuentasEditar formulario = new frmCuentasEditar();
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.operacion = 4;


            if (dgvListado.RowCount > 0)
            {
                int idCuenta = Convert.ToInt32(dgvListado.CurrentRow.Cells["Comitente"].Value);
                var lstComitentes = _service.GetById(idCuenta);
                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                if (lstComitentes != null)
                {
                    formulario.txtComitente.Text = lstComitentes.Comitente.ToString();

                    formulario.ShowDialog();
                    frmCuentas_Load(sender, e);
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
                    List<EntityFrameWork.Comitentes> lstComitentes = null;
                    string tipobusqueda = fBuscar.cboBuscar.Text.Trim();
                    string cBuscar = fBuscar.rctBuscar.Text.Trim();

                    if (cBuscar.Length > 0)
                    {
                        switch (tipobusqueda)
                        {
                            case "Comitente":
                                int id = Convert.ToInt32(cBuscar);
                                lstComitentes.Add(_service.GetById(id));
                                break;
                            case "Apellido":
                                lstComitentes = _service.GetByName(cBuscar);
                                break;
                            case "Usuario":
                                lstComitentes = _service.GetByUser(cBuscar);
                                break;
                        }
                    }
                    if (lstComitentes != null)
                    {
                        dgvListado.DataSource = lstComitentes;
                        dgvListado.RefreshEdit();
                        lblTotalCuentas.Text = string.Format("Total listado: {0}", lstComitentes.Count);
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
            ContextMenu MenuContextual = new ContextMenu();
            MenuItem MenuAgregar = new MenuItem("&Agregar", tsbAgregar_Click, Shortcut.Alt1);
            MenuItem MenuModificar = new MenuItem("&Modificar", tsbModificar_Click, Shortcut.Alt2);
            MenuItem MenuEliminar = new MenuItem("&Eliminar", tsbEliminar_Click, Shortcut.Alt3);
            MenuItem MenuSeparador1 = new MenuItem("-");
            MenuItem MenuDetalle = new MenuItem("&Detalle", tsbDetalle_Click, Shortcut.Alt4);
            MenuItem MenuBuscar = new MenuItem("&Buscar...", tsbBuscar_Click, Shortcut.Alt5);

            MenuContextual.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { MenuAgregar, MenuModificar, MenuEliminar, MenuSeparador1, MenuDetalle, MenuBuscar });
            ContextMenu = MenuContextual;

            var lstComitentes = _service.GetAll();

            if (lstComitentes != null)
            {
                dgvListado.DataSource = lstComitentes;
                lblTotalCuentas.Text = string.Format("Total listado: {0}", lstComitentes.Count);

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
                lblTotalCuentas.Text = "Total listado: 0";
            }

        }

        private void dgvListado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvListado.Columns["Contrasenia"].Visible = false;
            dgvListado.Columns["CorreoPrincipal"].Visible = false;
            dgvListado.Columns["CorreoAlternativo"].Visible = false;
            dgvListado.Columns["TelefonoCelular"].Visible = false;
        }
    }
}
