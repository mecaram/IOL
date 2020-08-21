using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using IOL.Servicios;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace IOL
{
    public partial class frmAcciones : Form
    {
        public int comitente = 0;
        private readonly ServiciosAccion _service = new ServiciosAccion();

        string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

        public frmAcciones()
        {
            InitializeComponent();
        }


        private void frmAcciones_Load(object sender, EventArgs e)
        {
            ContextMenu MenuContextual = new ContextMenu();
            MenuItem MenuActualizar = new MenuItem("&Actualizar Grilla", tsbActualizar_Click, Shortcut.Alt1);
            MenuItem MenuSeparador1 = new MenuItem("-");
            MenuItem MenuBuscar = new MenuItem("&Buscar...", tsbBuscar_Click, Shortcut.Alt5);

            MenuContextual.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { MenuActualizar, MenuSeparador1, MenuBuscar });
            ContextMenu = MenuContextual;

            var lstAcciones = _service.GetAll();

            if (lstAcciones != null)
            {
                lblTotalAcciones.Text = string.Format("Total listado: {0}", lstAcciones.Count);

                dgvListado.DataSource = lstAcciones;
                DataGridViewCellStyle EstiloEncabezadoColumna = new DataGridViewCellStyle();

                EstiloEncabezadoColumna.BackColor = Color.Green;
                EstiloEncabezadoColumna.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                dgvListado.ColumnHeadersDefaultCellStyle = EstiloEncabezadoColumna;

                DataGridViewCellStyle EstiloColumnas = new DataGridViewCellStyle();
                EstiloColumnas.BackColor = Color.AliceBlue;
                EstiloColumnas.Font = new Font("Times New Roman", 12);
                dgvListado.RowsDefaultCellStyle = EstiloColumnas;

                dgvListado.Columns["Simbolo"].HeaderText = "Símbolo";
                dgvListado.Columns["Descripcion"].HeaderText = "Descripción";
                dgvListado.Columns["Mercado"].HeaderText = "Mercado";
                dgvListado.Columns["Plazo"].HeaderText = "Plazo";

                dgvListado.Columns["Simbolo"].Width = 100;
                dgvListado.Columns["Descripcion"].Width = 240;
                dgvListado.Columns["Mercado"].Width = 80;
                dgvListado.Columns["Plazo"].Width = 80;

                dgvListado.Columns["Simbolo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Mercado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Plazo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.Columns["Simbolo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Mercado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvListado.Columns["Plazo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvListado.RefreshEdit();
                dgvListado.Enabled = true;
            }
            else
            {
                dgvListado.DataSource = null;
                dgvListado.RefreshEdit();
                lblTotalAcciones.Text = "Total listado: 0";
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea actualizar la grilla ?", "Pregunta del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlConnection conexion = new MySqlConnection(cone);
                string sentencia = string.Format("Select Usuario, CAST(AES_DECRYPT(Contrasenia,'Miguel2020') AS Char(1000) Character Set utf8) as Contrasenia From Comitentes Where Comitente = {0}", comitente);
                MySqlDataAdapter da = new MySqlDataAdapter(sentencia, cone);
                DataTable dt = new DataTable();
                int registros = da.Fill(dt);
                if (registros > 0)
                {
                    Token tkn1 = new Token(dt.Rows[0]["Usuario"].ToString(), dt.Rows[0]["Contrasenia"].ToString());
                    if (tkn1.ObtenerToken())
                    {
                        Operaciones panel1 = new Operaciones();
                        PanelModel Acciones = panel1.ObtenerPanel(tkn1.access_token);

                        int toti = 0, almacenadas = 0;
                        if (Acciones != null)
                        {
                            _service.DeleteAll();

                            foreach (var item in Acciones.titulos)
                            {
                                toti++;
                                Clases.TituloModel DatosAccion = panel1.ObtenerDatosTitulo(tkn1.access_token, item.mercado.ToString().Trim(), item.simbolo.ToString().Trim());
                                if (DatosAccion != null)
                                {
                                    var accion = new EntityFrameWork.Acciones();
                                    accion.Simbolo = DatosAccion.simbolo;
                                    accion.Descripcion = DatosAccion.descripcion;
                                    accion.Pais = DatosAccion.pais;
                                    accion.Mercado = DatosAccion.mercado;
                                    accion.Tipo = DatosAccion.tipo;
                                    accion.Plazo = DatosAccion.plazo;
                                    accion.Moneda = DatosAccion.moneda;

                                    _service.Register(accion);
                                }
                            }
                        }
                        if (toti == almacenadas && toti > 0)
                        {
                            frmAcciones_Load(sender, e);
                            MessageBox.Show("Grilla de acciones actualizadas con éxito", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al actualizar la grilla...intente mas tarde", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta...intente mas tarde", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                fBuscar.Text = "Busqueda de Acciones";
                fBuscar.lblTitulo.Text = "Buscar Acción";
                fBuscar.cboBuscar.Items.Add("Símbolo");
                fBuscar.cboBuscar.Items.Add("Descripción");
                fBuscar.cboBuscar.Text = "Símbolo";
                fBuscar.rctBuscar.Focus();
                fBuscar.ShowDialog(this);
                if (fBuscar.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    List<EntityFrameWork.Acciones> lstAcciones = null;

                    string tipobusqueda = fBuscar.cboBuscar.Text.Trim();
                    string cBuscar = fBuscar.rctBuscar.Text.Trim();

                    if (cBuscar.Length > 0)
                    {
                        switch (tipobusqueda)
                        {
                            case "Símbolo":
                                lstAcciones = _service.GetByDescription(cBuscar);
                                break;
                            case "Descripción":
                                lstAcciones = _service.GetByDescription(cBuscar);
                                break;
                        }
                    }

                    if (lstAcciones != null)
                    {
                        dgvListado.DataSource = lstAcciones;
                        dgvListado.RefreshEdit();
                        lblTotalAcciones.Text = string.Format("Total listado: {0}", lstAcciones.Count);
                    }
                    else
                    {
                        MessageBox.Show("Acción Inexistente", "Información del Sistema", MessageBoxButtons.OK);
                        frmAcciones_Load(sender, e);
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
            frmAcciones_Load(sender, e);
        }
    }
}
