namespace IOL
{
    partial class Ruedas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ruedas));
            this.Calendario = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFeriados = new System.Windows.Forms.DataGridView();
            this.tspMenu = new System.Windows.Forms.ToolStrip();
            this.tsbAgregar = new System.Windows.Forms.ToolStripButton();
            this.tsbModificar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbDetalle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrimero = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbSiguiente = new System.Windows.Forms.ToolStripButton();
            this.tsbUltimo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotalRuedas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.btnFeriados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeriados)).BeginInit();
            this.tspMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // Calendario
            // 
            this.Calendario.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Calendario.BoldedDates = new System.DateTime[] {
        new System.DateTime(2020, 3, 22, 0, 0, 0, 0),
        new System.DateTime(2020, 3, 21, 0, 0, 0, 0)};
            this.Calendario.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendario.Location = new System.Drawing.Point(5, 57);
            this.Calendario.MaxSelectionCount = 31;
            this.Calendario.Name = "Calendario";
            this.Calendario.TabIndex = 153;
            this.Calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendario_DateChanged);
            this.Calendario.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.Calendario_DateSelected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Georgia", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(5, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 22);
            this.label2.TabIndex = 159;
            this.label2.Text = "Listado de Feriados";
            // 
            // dgvFeriados
            // 
            this.dgvFeriados.AllowUserToAddRows = false;
            this.dgvFeriados.AllowUserToDeleteRows = false;
            this.dgvFeriados.AllowUserToOrderColumns = true;
            this.dgvFeriados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeriados.Location = new System.Drawing.Point(4, 255);
            this.dgvFeriados.Name = "dgvFeriados";
            this.dgvFeriados.ReadOnly = true;
            this.dgvFeriados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeriados.Size = new System.Drawing.Size(250, 162);
            this.dgvFeriados.TabIndex = 158;
            // 
            // tspMenu
            // 
            this.tspMenu.AutoSize = false;
            this.tspMenu.BackColor = System.Drawing.Color.Linen;
            this.tspMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAgregar,
            this.tsbModificar,
            this.tsbEliminar,
            this.tsbDetalle,
            this.toolStripSeparator1,
            this.tsbPrimero,
            this.tsbAnterior,
            this.tsbSiguiente,
            this.tsbUltimo,
            this.toolStripSeparator2});
            this.tspMenu.Location = new System.Drawing.Point(0, 0);
            this.tspMenu.Name = "tspMenu";
            this.tspMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tspMenu.Size = new System.Drawing.Size(782, 52);
            this.tspMenu.Stretch = true;
            this.tspMenu.TabIndex = 160;
            this.tspMenu.Text = "Menu Principal";
            // 
            // tsbAgregar
            // 
            this.tsbAgregar.AutoSize = false;
            this.tsbAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAgregar.Image = ((System.Drawing.Image)(resources.GetObject("tsbAgregar.Image")));
            this.tsbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAgregar.Name = "tsbAgregar";
            this.tsbAgregar.Size = new System.Drawing.Size(50, 50);
            this.tsbAgregar.Text = "Agregar";
            this.tsbAgregar.Click += new System.EventHandler(this.tsbAgregar_Click);
            // 
            // tsbModificar
            // 
            this.tsbModificar.AutoSize = false;
            this.tsbModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbModificar.Image = ((System.Drawing.Image)(resources.GetObject("tsbModificar.Image")));
            this.tsbModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificar.Name = "tsbModificar";
            this.tsbModificar.Size = new System.Drawing.Size(50, 50);
            this.tsbModificar.Text = "Modificar";
            this.tsbModificar.Click += new System.EventHandler(this.tsbModificar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.AutoSize = false;
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(50, 50);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tsbDetalle
            // 
            this.tsbDetalle.AutoSize = false;
            this.tsbDetalle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDetalle.Image = ((System.Drawing.Image)(resources.GetObject("tsbDetalle.Image")));
            this.tsbDetalle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDetalle.Name = "tsbDetalle";
            this.tsbDetalle.Size = new System.Drawing.Size(50, 50);
            this.tsbDetalle.Text = "Detalle";
            this.tsbDetalle.Click += new System.EventHandler(this.tsbDetalle_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // tsbPrimero
            // 
            this.tsbPrimero.AutoSize = false;
            this.tsbPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrimero.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.tsbPrimero.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrimero.Image")));
            this.tsbPrimero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrimero.Name = "tsbPrimero";
            this.tsbPrimero.Size = new System.Drawing.Size(50, 50);
            this.tsbPrimero.Text = "Primero";
            this.tsbPrimero.Click += new System.EventHandler(this.tsbPrimero_Click);
            // 
            // tsbAnterior
            // 
            this.tsbAnterior.AutoSize = false;
            this.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnterior.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.tsbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("tsbAnterior.Image")));
            this.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnterior.Name = "tsbAnterior";
            this.tsbAnterior.Size = new System.Drawing.Size(50, 50);
            this.tsbAnterior.Text = "Anterior";
            this.tsbAnterior.Click += new System.EventHandler(this.tsbAnterior_Click);
            // 
            // tsbSiguiente
            // 
            this.tsbSiguiente.AutoSize = false;
            this.tsbSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSiguiente.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.tsbSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("tsbSiguiente.Image")));
            this.tsbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSiguiente.Name = "tsbSiguiente";
            this.tsbSiguiente.Size = new System.Drawing.Size(50, 50);
            this.tsbSiguiente.Text = "Siguiente";
            this.tsbSiguiente.Click += new System.EventHandler(this.tsbSiguiente_Click);
            // 
            // tsbUltimo
            // 
            this.tsbUltimo.AutoSize = false;
            this.tsbUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUltimo.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.tsbUltimo.Image = ((System.Drawing.Image)(resources.GetObject("tsbUltimo.Image")));
            this.tsbUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUltimo.Name = "tsbUltimo";
            this.tsbUltimo.Size = new System.Drawing.Size(50, 50);
            this.tsbUltimo.Text = "Ultimo";
            this.tsbUltimo.Click += new System.EventHandler(this.tsbUltimo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // lblTotalRuedas
            // 
            this.lblTotalRuedas.AutoSize = true;
            this.lblTotalRuedas.BackColor = System.Drawing.Color.Silver;
            this.lblTotalRuedas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalRuedas.Font = new System.Drawing.Font("Georgia", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRuedas.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalRuedas.Location = new System.Drawing.Point(264, 392);
            this.lblTotalRuedas.Name = "lblTotalRuedas";
            this.lblTotalRuedas.Size = new System.Drawing.Size(203, 22);
            this.lblTotalRuedas.TabIndex = 163;
            this.lblTotalRuedas.Text = "Total de Ruedas: 000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Georgia", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(264, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 22);
            this.label1.TabIndex = 162;
            this.label1.Text = "Listado de Ruedas";
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(263, 83);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(507, 306);
            this.dgvListado.TabIndex = 161;
            // 
            // btnFeriados
            // 
            this.btnFeriados.AutoSize = true;
            this.btnFeriados.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeriados.Location = new System.Drawing.Point(190, 228);
            this.btnFeriados.Name = "btnFeriados";
            this.btnFeriados.Size = new System.Drawing.Size(64, 25);
            this.btnFeriados.TabIndex = 164;
            this.btnFeriados.Text = "Feriados";
            this.btnFeriados.UseVisualStyleBackColor = true;
            this.btnFeriados.Click += new System.EventHandler(this.btnFeriados_Click);
            // 
            // Ruedas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImage = global::IOL.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(782, 419);
            this.Controls.Add(this.btnFeriados);
            this.Controls.Add(this.lblTotalRuedas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.tspMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvFeriados);
            this.Controls.Add(this.Calendario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ruedas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Ruedas";
            this.Load += new System.EventHandler(this.Ruedas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeriados)).EndInit();
            this.tspMenu.ResumeLayout(false);
            this.tspMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar Calendario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFeriados;
        private System.Windows.Forms.ToolStrip tspMenu;
        private System.Windows.Forms.ToolStripButton tsbAgregar;
        private System.Windows.Forms.ToolStripButton tsbModificar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbDetalle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbPrimero;
        private System.Windows.Forms.ToolStripButton tsbAnterior;
        private System.Windows.Forms.ToolStripButton tsbSiguiente;
        private System.Windows.Forms.ToolStripButton tsbUltimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblTotalRuedas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Button btnFeriados;
    }
}