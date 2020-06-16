namespace IOL
{
    partial class FeriadosEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeriadosEditar));
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.lblApellido = new System.Windows.Forms.Label();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.txtIdFeriado = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblIdComitente = new System.Windows.Forms.Label();
            this.tbpDatosFeriado = new System.Windows.Forms.TabPage();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.tbcDatosFeriado = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.tbpDatosFeriado.SuspendLayout();
            this.tbcDatosFeriado.SuspendLayout();
            this.SuspendLayout();
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
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblApellido.Location = new System.Drawing.Point(40, 74);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(59, 21);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Fecha:";
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.AutoSize = false;
            this.tsbGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardar.ForeColor = System.Drawing.Color.Coral;
            this.tsbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardar.Image")));
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(50, 50);
            this.tsbGuardar.Text = "Guardar";
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Linen;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardar,
            this.tsbEliminar,
            this.tsbCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(390, 60);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 152;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbCancelar
            // 
            this.tsbCancelar.AutoSize = false;
            this.tsbCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelar.Image")));
            this.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelar.Name = "tsbCancelar";
            this.tsbCancelar.Size = new System.Drawing.Size(50, 50);
            this.tsbCancelar.Text = "Cancelar";
            this.tsbCancelar.Click += new System.EventHandler(this.tsbCancelar_Click);
            // 
            // txtIdFeriado
            // 
            this.txtIdFeriado.Enabled = false;
            this.txtIdFeriado.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdFeriado.Location = new System.Drawing.Point(101, 20);
            this.txtIdFeriado.Name = "txtIdFeriado";
            this.txtIdFeriado.Size = new System.Drawing.Size(115, 29);
            this.txtIdFeriado.TabIndex = 0;
            this.txtIdFeriado.Click += new System.EventHandler(this.txtIdFeriado_Click);
            this.txtIdFeriado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdFeriado_KeyPress);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtMotivo.Location = new System.Drawing.Point(101, 114);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(264, 29);
            this.txtMotivo.TabIndex = 2;
            this.txtMotivo.Click += new System.EventHandler(this.txtMotivo_Click);
            this.txtMotivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMotivo_KeyPress);
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblNombres.Location = new System.Drawing.Point(31, 122);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(68, 21);
            this.lblNombres.TabIndex = 4;
            this.lblNombres.Text = "Motivo:";
            // 
            // lblIdComitente
            // 
            this.lblIdComitente.AutoSize = true;
            this.lblIdComitente.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblIdComitente.Location = new System.Drawing.Point(2, 28);
            this.lblIdComitente.Name = "lblIdComitente";
            this.lblIdComitente.Size = new System.Drawing.Size(97, 21);
            this.lblIdComitente.TabIndex = 33;
            this.lblIdComitente.Text = "Id. Feriado:";
            // 
            // tbpDatosFeriado
            // 
            this.tbpDatosFeriado.BackColor = System.Drawing.Color.SeaShell;
            this.tbpDatosFeriado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpDatosFeriado.Controls.Add(this.lblApellido);
            this.tbpDatosFeriado.Controls.Add(this.txtIdFeriado);
            this.tbpDatosFeriado.Controls.Add(this.txtMotivo);
            this.tbpDatosFeriado.Controls.Add(this.txtFecha);
            this.tbpDatosFeriado.Controls.Add(this.lblNombres);
            this.tbpDatosFeriado.Controls.Add(this.lblIdComitente);
            this.tbpDatosFeriado.Location = new System.Drawing.Point(4, 22);
            this.tbpDatosFeriado.Name = "tbpDatosFeriado";
            this.tbpDatosFeriado.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDatosFeriado.Size = new System.Drawing.Size(374, 159);
            this.tbpDatosFeriado.TabIndex = 0;
            this.tbpDatosFeriado.Text = "Datos del Feriado";
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(101, 67);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(115, 29);
            this.txtFecha.TabIndex = 1;
            this.txtFecha.Click += new System.EventHandler(this.txtFeriado_Click);
            this.txtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFeriado_KeyPress);
            // 
            // tbcDatosFeriado
            // 
            this.tbcDatosFeriado.Controls.Add(this.tbpDatosFeriado);
            this.tbcDatosFeriado.Location = new System.Drawing.Point(6, 63);
            this.tbcDatosFeriado.Name = "tbcDatosFeriado";
            this.tbcDatosFeriado.SelectedIndex = 0;
            this.tbcDatosFeriado.Size = new System.Drawing.Size(382, 185);
            this.tbcDatosFeriado.TabIndex = 151;
            // 
            // FeriadosEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IOL.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(390, 251);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbcDatosFeriado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FeriadosEditar";
            this.Text = "FeriadosEditar";
            this.Load += new System.EventHandler(this.FeriadosEditar_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tbpDatosFeriado.ResumeLayout(false);
            this.tbpDatosFeriado.PerformLayout();
            this.tbcDatosFeriado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        public System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        public System.Windows.Forms.TextBox txtIdFeriado;
        public System.Windows.Forms.TextBox txtMotivo;
        public System.Windows.Forms.Label lblNombres;
        public System.Windows.Forms.Label lblIdComitente;
        public System.Windows.Forms.TabPage tbpDatosFeriado;
        public System.Windows.Forms.TextBox txtFecha;
        public System.Windows.Forms.TabControl tbcDatosFeriado;
    }
}