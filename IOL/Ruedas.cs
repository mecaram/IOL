using System;
using System.Drawing;
using System.Windows.Forms;
using IOL.EntityFrameWork;
using IOL.Servicios;

namespace IOL
{
    public partial class Ruedas : Form
    {
        private readonly ServiciosRueda _service = new ServiciosRueda();
        private readonly ServiciosFeriado _serviceFeriado = new ServiciosFeriado();

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
            var lstRuedas = _service.GetByDate(fecha.Value, comitente);
            if (lstRuedas != null)
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
                    var lstFeriados = _serviceFeriado.GetByDate(fecha.Value);
                    if (lstRuedas != null)
                    {
                        string mensaje = string.Format("Sábado/Domingo y Feriados NO opera la bolsa. Dia {0} Feriado: '{1}'",
                                                        fecha.Value.Date.ToShortDateString(), lstFeriados.Motivo.ToString());
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
            int id;
            try { id = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdRueda"].Value); }
            catch { id = 0; }

            EntityFrameWork.Ruedas rueda = _service.GetById(id);
            if (rueda != null)
            {
                DateTime? fecha = rueda.FechaRueda;
                RuedasEditar formulario = new RuedasEditar();
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.operacion = 2;
                formulario.comitente = comitente;
                formulario.txtIdRueda.Text = id.ToString();
                formulario.txtFecha.Text = fecha.Value.Date.ToShortDateString();
                formulario.txtFecha.Enabled = false;
                formulario.ShowDialog();
                tsbVerTodos_Click(sender, e);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id;
            try { id = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdRueda"].Value); }
            catch { id = 0; }

            EntityFrameWork.Ruedas rueda = _service.GetById(id);
            if (rueda != null)
            {
                RuedasEditar formulario = new RuedasEditar();
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.operacion = 3;
                formulario.txtIdRueda.Text = id.ToString();
                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);

                formulario.ShowDialog();
                tsbVerTodos_Click(sender, e);
                if (fila < dgvListado.Rows.Count)
                    dgvListado.CurrentCell = dgvListado[0, fila];
            }
        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            int id;
            try { id = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdRueda"].Value); }
            catch { id = 0; }

            EntityFrameWork.Ruedas rueda = _service.GetById(id);
            if (rueda != null)
            {
                RuedasEditar formulario = new RuedasEditar();
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.operacion = 4;
                int fila = Convert.ToUInt16(dgvListado.CurrentRow.Index);
                formulario.txtIdRueda.Text = id.ToString();
                formulario.ShowDialog();

                tsbVerTodos_Click(sender, e);
                if (fila < dgvListado.Rows.Count)
                    dgvListado.CurrentCell = dgvListado[0, fila];
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
            var lstRuedas = _service.GetByDate(Calendario.SelectionStart.Date, comitente);
            if (lstRuedas != null)
            {
                RuedasEditar formulario = new RuedasEditar();
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.operacion = 2;
                formulario.comitente = comitente;
                formulario.txtIdRueda.Text = lstRuedas.IdRueda.ToString();
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
                    var lstFeriados = _serviceFeriado.GetByDate(fecha.Value);
                    if (lstFeriados != null)
                    {
                        string mensaje = string.Format("Sábado/Domingo y Feriados NO opera la bolsa. Dia {0} Feriado: '{1}'",
                                                        fecha.Value.Date.ToShortDateString(), lstFeriados.Motivo.ToString());
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
            var lstFeriados = _serviceFeriado.GetByMonth(Calendario.SelectionStart.Date);
            if (lstFeriados != null)
            {
                dgvFeriados.DataSource = lstFeriados;

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
            var lstFeriados = _serviceFeriado.GetByMonth(Calendario.SelectionStart.Date);
            if (lstFeriados != null)
            {
                dgvFeriados.DataSource = lstFeriados;

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
