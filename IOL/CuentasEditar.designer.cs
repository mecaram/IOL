namespace IOL
{
    partial class frmCuentasEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentasEditar));
            this.tbcDatosCuenta = new System.Windows.Forms.TabControl();
            this.tbpDatosCuenta = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.lblCorreoElectronico = new System.Windows.Forms.Label();
            this.lblCorreoAlternativo = new System.Windows.Forms.Label();
            this.txtCorreoAlternativo = new System.Windows.Forms.TextBox();
            this.txtTelefonoCelular = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtComitente = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblIdComitente = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tbcDatosCuenta.SuspendLayout();
            this.tbpDatosCuenta.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcDatosCuenta
            // 
            this.tbcDatosCuenta.Controls.Add(this.tbpDatosCuenta);
            this.tbcDatosCuenta.Location = new System.Drawing.Point(6, 65);
            this.tbcDatosCuenta.Name = "tbcDatosCuenta";
            this.tbcDatosCuenta.SelectedIndex = 0;
            this.tbcDatosCuenta.Size = new System.Drawing.Size(551, 326);
            this.tbcDatosCuenta.TabIndex = 0;
            // 
            // tbpDatosCuenta
            // 
            this.tbpDatosCuenta.BackColor = System.Drawing.Color.SeaShell;
            this.tbpDatosCuenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpDatosCuenta.Controls.Add(this.label1);
            this.tbpDatosCuenta.Controls.Add(this.txtCorreoElectronico);
            this.tbpDatosCuenta.Controls.Add(this.lblCelular);
            this.tbpDatosCuenta.Controls.Add(this.lblCorreoElectronico);
            this.tbpDatosCuenta.Controls.Add(this.lblCorreoAlternativo);
            this.tbpDatosCuenta.Controls.Add(this.txtCorreoAlternativo);
            this.tbpDatosCuenta.Controls.Add(this.txtTelefonoCelular);
            this.tbpDatosCuenta.Controls.Add(this.lblApellido);
            this.tbpDatosCuenta.Controls.Add(this.txtComitente);
            this.tbpDatosCuenta.Controls.Add(this.txtNombres);
            this.tbpDatosCuenta.Controls.Add(this.txtApellido);
            this.tbpDatosCuenta.Controls.Add(this.lblNombres);
            this.tbpDatosCuenta.Controls.Add(this.lblIdComitente);
            this.tbpDatosCuenta.Location = new System.Drawing.Point(4, 22);
            this.tbpDatosCuenta.Name = "tbpDatosCuenta";
            this.tbpDatosCuenta.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDatosCuenta.Size = new System.Drawing.Size(543, 300);
            this.tbpDatosCuenta.TabIndex = 0;
            this.tbpDatosCuenta.Text = "Datos de la Cuenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 15);
            this.label1.TabIndex = 156;
            this.label1.Text = "Sin guiones, ni el 0 adelante y ni el 15";
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtCorreoElectronico.Location = new System.Drawing.Point(180, 211);
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(354, 29);
            this.txtCorreoElectronico.TabIndex = 153;
            this.txtCorreoElectronico.Click += new System.EventHandler(this.txtCorreoElectronico_Click);
            this.txtCorreoElectronico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorreoElectronico_KeyPress);
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblCelular.Location = new System.Drawing.Point(39, 172);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(137, 21);
            this.lblCelular.TabIndex = 150;
            this.lblCelular.Text = "Teléfono Celular:";
            // 
            // lblCorreoElectronico
            // 
            this.lblCorreoElectronico.AutoSize = true;
            this.lblCorreoElectronico.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblCorreoElectronico.Location = new System.Drawing.Point(19, 219);
            this.lblCorreoElectronico.Name = "lblCorreoElectronico";
            this.lblCorreoElectronico.Size = new System.Drawing.Size(157, 21);
            this.lblCorreoElectronico.TabIndex = 152;
            this.lblCorreoElectronico.Text = "Correo Electronico:";
            // 
            // lblCorreoAlternativo
            // 
            this.lblCorreoAlternativo.AutoSize = true;
            this.lblCorreoAlternativo.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblCorreoAlternativo.Location = new System.Drawing.Point(24, 266);
            this.lblCorreoAlternativo.Name = "lblCorreoAlternativo";
            this.lblCorreoAlternativo.Size = new System.Drawing.Size(152, 21);
            this.lblCorreoAlternativo.TabIndex = 154;
            this.lblCorreoAlternativo.Text = "Correo Alternativo:";
            // 
            // txtCorreoAlternativo
            // 
            this.txtCorreoAlternativo.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtCorreoAlternativo.Location = new System.Drawing.Point(180, 258);
            this.txtCorreoAlternativo.Name = "txtCorreoAlternativo";
            this.txtCorreoAlternativo.Size = new System.Drawing.Size(354, 29);
            this.txtCorreoAlternativo.TabIndex = 155;
            this.txtCorreoAlternativo.Click += new System.EventHandler(this.txtCorreoAlternativo_Click);
            this.txtCorreoAlternativo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorreoAlternativo_KeyPress);
            // 
            // txtTelefonoCelular
            // 
            this.txtTelefonoCelular.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtTelefonoCelular.Location = new System.Drawing.Point(180, 164);
            this.txtTelefonoCelular.Name = "txtTelefonoCelular";
            this.txtTelefonoCelular.Size = new System.Drawing.Size(264, 29);
            this.txtTelefonoCelular.TabIndex = 151;
            this.txtTelefonoCelular.Click += new System.EventHandler(this.txtTelefonoCelular_Click);
            this.txtTelefonoCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefonoCelular_KeyPress);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblApellido.Location = new System.Drawing.Point(99, 74);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(77, 21);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtComitente
            // 
            this.txtComitente.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComitente.Location = new System.Drawing.Point(180, 20);
            this.txtComitente.Name = "txtComitente";
            this.txtComitente.Size = new System.Drawing.Size(115, 29);
            this.txtComitente.TabIndex = 0;
            this.txtComitente.Click += new System.EventHandler(this.txtComitente_Click);
            this.txtComitente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComitente_KeyPress);
            // 
            // txtNombres
            // 
            this.txtNombres.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtNombres.Location = new System.Drawing.Point(180, 114);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(264, 29);
            this.txtNombres.TabIndex = 2;
            this.txtNombres.Click += new System.EventHandler(this.txtNombres_Click);
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(180, 67);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(264, 29);
            this.txtApellido.TabIndex = 1;
            this.txtApellido.Click += new System.EventHandler(this.txtApellido_Click);
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblNombres.Location = new System.Drawing.Point(93, 122);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(83, 21);
            this.lblNombres.TabIndex = 4;
            this.lblNombres.Text = "Nombres:";
            // 
            // lblIdComitente
            // 
            this.lblIdComitente.AutoSize = true;
            this.lblIdComitente.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblIdComitente.Location = new System.Drawing.Point(29, 28);
            this.lblIdComitente.Name = "lblIdComitente";
            this.lblIdComitente.Size = new System.Drawing.Size(147, 21);
            this.lblIdComitente.TabIndex = 33;
            this.lblIdComitente.Text = "Cuenta Comitente:";
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
            this.toolStrip1.Size = new System.Drawing.Size(563, 60);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 150;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.AutoSize = false;
            this.tsbGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardar.Image")));
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(50, 50);
            this.tsbGuardar.Text = "Guardar";
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardar_Click);
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
            // frmCuentasEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IOL.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(563, 396);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbcDatosCuenta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCuentasEditar";
            this.Text = "CuentasEditar";
            this.Load += new System.EventHandler(this.frmCobradoresEditar_Load);
            this.tbcDatosCuenta.ResumeLayout(false);
            this.tbpDatosCuenta.ResumeLayout(false);
            this.tbpDatosCuenta.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tbcDatosCuenta;
        public System.Windows.Forms.TabPage tbpDatosCuenta;
        public System.Windows.Forms.Label lblApellido;
        public System.Windows.Forms.TextBox txtComitente;
        public System.Windows.Forms.TextBox txtNombres;
        public System.Windows.Forms.TextBox txtApellido;
        public System.Windows.Forms.Label lblNombres;
        public System.Windows.Forms.Label lblIdComitente;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        public System.Windows.Forms.TextBox txtCorreoElectronico;
        public System.Windows.Forms.Label lblCelular;
        public System.Windows.Forms.Label lblCorreoElectronico;
        public System.Windows.Forms.Label lblCorreoAlternativo;
        public System.Windows.Forms.TextBox txtCorreoAlternativo;
        public System.Windows.Forms.TextBox txtTelefonoCelular;
        public System.Windows.Forms.Label label1;
    }
}