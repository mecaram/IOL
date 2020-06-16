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
    public partial class frmAcciones : Form
    {
        public int comitente = 0;
        string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

        public frmAcciones()
        {
            InitializeComponent();
        }


        private void frmAcciones_Load(object sender, EventArgs e)
        {
            string cone = ConfigurationManager.ConnectionStrings["conexion"].ToString();

            ContextMenu MenuContextual = new ContextMenu();
            MenuItem MenuActualizar = new MenuItem("&Actualizar Grilla", tsbActualizar_Click, Shortcut.Alt1);
            MenuItem MenuSeparador1 = new MenuItem("-");
            MenuItem MenuBuscar = new MenuItem("&Buscar...", tsbBuscar_Click, Shortcut.Alt5);

            MenuContextual.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { MenuActualizar, MenuSeparador1, MenuBuscar });
            ContextMenu = MenuContextual;

            MySqlConnection coneAcciones = new MySqlConnection(cone);
            MySqlDataAdapter da = new MySqlDataAdapter("Select Simbolo, Descripcion, Mercado, Plazo From Acciones Order By Simbolo", coneAcciones);
            DataTable ds = new DataTable();
            da.Fill(ds);

            lblTotalAcciones.Text = string.Format("Total listado: {0}", ds.Rows.Count);
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
                            MySqlConnection conexionEliminar = null;
                            try
                            {
                                conexionEliminar = new MySqlConnection(cone);
                                conexionEliminar.Open();

                                string sentenciaEliminar = string.Format("Delete From Acciones");
                                using (var comandoEliminar = new MySqlCommand(sentenciaEliminar, conexionEliminar))
                                {
                                    comandoEliminar.CommandType = CommandType.Text;
                                    int nRegistros = comandoEliminar.ExecuteNonQuery();
                                    conexionEliminar.Close();
                                }
                            }
                            catch (Exception error)
                            {
                                conexionEliminar.Close();
                            }
                            finally
                            {
                                conexionEliminar.Close();
                            }

                            foreach (var item in Acciones.titulos)
                            {
                                toti++;
                                Clases.TituloModel DatosAccion = panel1.ObtenerDatosTitulo(tkn1.access_token, item.mercado.ToString().Trim(), item.simbolo.ToString().Trim());
                                if (DatosAccion != null)
                                {
                                    MySqlConnection conexionInsertar = null;
                                    try
                                    {
                                        conexionInsertar = new MySqlConnection(cone);
                                        conexionInsertar.Open();

                                        string sentenciaInsertar = string.Format("Insert Into Acciones(Simbolo, Descripcion, Pais, Mercado, Tipo, Plazo, Moneda) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", DatosAccion.simbolo.ToString().Trim(), DatosAccion.descripcion.ToString().Trim(), DatosAccion.pais.ToString().Trim(), DatosAccion.mercado.ToString().Trim(), DatosAccion.tipo.ToString().Trim(), DatosAccion.plazo.ToString().Trim(), DatosAccion.moneda.ToString().Trim());
                                        using (var comandoInsertar = new MySqlCommand(sentenciaInsertar, conexionInsertar))
                                        {
                                            comandoInsertar.CommandType = CommandType.Text;
                                            int nRegistros = comandoInsertar.ExecuteNonQuery();
                                            if (nRegistros > 0)
                                            {
                                                almacenadas++;
                                            }
                                            conexionInsertar.Close();
                                        }
                                    }
                                    catch (Exception error)
                                    {
                                        conexionInsertar.Close();
                                    }
                                    finally
                                    {
                                        conexionInsertar.Close();
                                    }
                                    
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
                    string cWhere = "";

                    string tipobusqueda = fBuscar.cboBuscar.Text.Trim();
                    string cBuscar = fBuscar.rctBuscar.Text.Trim();

                    if (cBuscar.Length > 0)
                    {
                        switch (tipobusqueda)
                        {
                            case "Símbolo":
                                cWhere += " Where Simbolo = " + cBuscar;
                                break;
                            case "Descripción":
                                cWhere += " Where Descripcion '%" + cBuscar + "%' Order By Descripcion";
                                break;
                        }
                    }
                    MySqlConnection coneAcciones = new MySqlConnection(cone);
                    string sqlComando = "Select Simbolo, Descripcion, Mercado, Plazo From Acciones ";
                    sqlComando += cWhere;
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlComando, coneAcciones);
                    DataTable ds = new DataTable();
                    da.Fill(ds);

                    lblTotalAcciones.Text = string.Format("Total listado: {0}", ds.Rows.Count);
                    if (ds.Rows.Count > 0)
                    {
                        dgvListado.DataSource = ds;
                        dgvListado.RefreshEdit();
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
