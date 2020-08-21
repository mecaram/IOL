namespace IOL
{
    partial class RuedasEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuedasEditar));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tbcDatosRueda = new System.Windows.Forms.TabControl();
            this.tbpDatosRueda = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.nudComprarHasta = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtPorcPuntaCompradora = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtPorcPuntaVendedora = new System.Windows.Forms.TextBox();
            this.nupCantAcciones = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPorcComisionIOL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPorcCompra = new System.Windows.Forms.TextBox();
            this.lblOperar = new System.Windows.Forms.Label();
            this.lblPorcCompra = new System.Windows.Forms.Label();
            this.lblPorcVenta = new System.Windows.Forms.Label();
            this.txtPorcVenta = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtIdRueda = new System.Windows.Forms.TextBox();
            this.txtSaldoARetirar = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblInversionTotal = new System.Windows.Forms.Label();
            this.lblIdComitente = new System.Windows.Forms.Label();
            this.gpbOperar = new System.Windows.Forms.GroupBox();
            this.chkNo = new System.Windows.Forms.CheckBox();
            this.chkSi = new System.Windows.Forms.CheckBox();
            this.tbpSimulador = new System.Windows.Forms.TabPage();
            this.btnGuardarSimulador = new System.Windows.Forms.Button();
            this.txtEstrategia = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPorcCompraSimulador = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdSimulador = new System.Windows.Forms.TextBox();
            this.txtPorcVentaSimulador = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tbcDatosRueda.SuspendLayout();
            this.tbpDatosRueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprarHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCantAcciones)).BeginInit();
            this.gpbOperar.SuspendLayout();
            this.tbpSimulador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(738, 60);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 151;
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
            // tbcDatosRueda
            // 
            this.tbcDatosRueda.Controls.Add(this.tbpDatosRueda);
            this.tbcDatosRueda.Controls.Add(this.tbpSimulador);
            this.tbcDatosRueda.Location = new System.Drawing.Point(12, 63);
            this.tbcDatosRueda.Name = "tbcDatosRueda";
            this.tbcDatosRueda.SelectedIndex = 0;
            this.tbcDatosRueda.Size = new System.Drawing.Size(714, 427);
            this.tbcDatosRueda.TabIndex = 0;
            // 
            // tbpDatosRueda
            // 
            this.tbpDatosRueda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpDatosRueda.Controls.Add(this.label2);
            this.tbpDatosRueda.Controls.Add(this.label28);
            this.tbpDatosRueda.Controls.Add(this.nudComprarHasta);
            this.tbpDatosRueda.Controls.Add(this.label27);
            this.tbpDatosRueda.Controls.Add(this.label23);
            this.tbpDatosRueda.Controls.Add(this.label24);
            this.tbpDatosRueda.Controls.Add(this.txtPorcPuntaCompradora);
            this.tbpDatosRueda.Controls.Add(this.label25);
            this.tbpDatosRueda.Controls.Add(this.label26);
            this.tbpDatosRueda.Controls.Add(this.txtPorcPuntaVendedora);
            this.tbpDatosRueda.Controls.Add(this.nupCantAcciones);
            this.tbpDatosRueda.Controls.Add(this.label22);
            this.tbpDatosRueda.Controls.Add(this.label11);
            this.tbpDatosRueda.Controls.Add(this.label10);
            this.tbpDatosRueda.Controls.Add(this.label9);
            this.tbpDatosRueda.Controls.Add(this.txtPorcComisionIOL);
            this.tbpDatosRueda.Controls.Add(this.label1);
            this.tbpDatosRueda.Controls.Add(this.txtPorcCompra);
            this.tbpDatosRueda.Controls.Add(this.lblOperar);
            this.tbpDatosRueda.Controls.Add(this.lblPorcCompra);
            this.tbpDatosRueda.Controls.Add(this.lblPorcVenta);
            this.tbpDatosRueda.Controls.Add(this.txtPorcVenta);
            this.tbpDatosRueda.Controls.Add(this.lblFecha);
            this.tbpDatosRueda.Controls.Add(this.txtIdRueda);
            this.tbpDatosRueda.Controls.Add(this.txtSaldoARetirar);
            this.tbpDatosRueda.Controls.Add(this.txtFecha);
            this.tbpDatosRueda.Controls.Add(this.lblInversionTotal);
            this.tbpDatosRueda.Controls.Add(this.lblIdComitente);
            this.tbpDatosRueda.Controls.Add(this.gpbOperar);
            this.tbpDatosRueda.Location = new System.Drawing.Point(4, 22);
            this.tbpDatosRueda.Name = "tbpDatosRueda";
            this.tbpDatosRueda.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDatosRueda.Size = new System.Drawing.Size(706, 401);
            this.tbpDatosRueda.TabIndex = 0;
            this.tbpDatosRueda.Text = "Datos de la Rueda";
            this.tbpDatosRueda.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label28.Location = new System.Drawing.Point(243, 319);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(55, 21);
            this.label28.TabIndex = 172;
            this.label28.Text = "Horas";
            // 
            // nudComprarHasta
            // 
            this.nudComprarHasta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.nudComprarHasta.Location = new System.Drawing.Point(174, 311);
            this.nudComprarHasta.Maximum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.nudComprarHasta.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.nudComprarHasta.Name = "nudComprarHasta";
            this.nudComprarHasta.Size = new System.Drawing.Size(63, 29);
            this.nudComprarHasta.TabIndex = 9;
            this.nudComprarHasta.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudComprarHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudComprarHasta_KeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.Color.Green;
            this.label27.Location = new System.Drawing.Point(5, 318);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(167, 22);
            this.label27.TabIndex = 171;
            this.label27.Text = "Comprar hasta las:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label23.Location = new System.Drawing.Point(510, 276);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 21);
            this.label23.TabIndex = 170;
            this.label23.Text = "%";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label24.Location = new System.Drawing.Point(253, 276);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 21);
            this.label24.TabIndex = 169;
            this.label24.Text = "%";
            // 
            // txtPorcPuntaCompradora
            // 
            this.txtPorcPuntaCompradora.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcPuntaCompradora.Location = new System.Drawing.Point(137, 268);
            this.txtPorcPuntaCompradora.Name = "txtPorcPuntaCompradora";
            this.txtPorcPuntaCompradora.Size = new System.Drawing.Size(115, 29);
            this.txtPorcPuntaCompradora.TabIndex = 7;
            this.txtPorcPuntaCompradora.Click += new System.EventHandler(this.txtPorcPuntaCompradora_Click);
            this.txtPorcPuntaCompradora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcPuntaCompradora_KeyPress);
            this.txtPorcPuntaCompradora.Leave += new System.EventHandler(this.txtPorcPuntaCompradora_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Green;
            this.label25.Location = new System.Drawing.Point(10, 273);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(122, 22);
            this.label25.TabIndex = 167;
            this.label25.Text = "Punta Comp.:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(281, 275);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(113, 22);
            this.label26.TabIndex = 168;
            this.label26.Text = "Punta Vend.:";
            // 
            // txtPorcPuntaVendedora
            // 
            this.txtPorcPuntaVendedora.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcPuntaVendedora.Location = new System.Drawing.Point(395, 268);
            this.txtPorcPuntaVendedora.Name = "txtPorcPuntaVendedora";
            this.txtPorcPuntaVendedora.Size = new System.Drawing.Size(115, 29);
            this.txtPorcPuntaVendedora.TabIndex = 8;
            this.txtPorcPuntaVendedora.Click += new System.EventHandler(this.txtPorcPuntaVendedora_Click);
            this.txtPorcPuntaVendedora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcPuntaVendedora_KeyPress);
            this.txtPorcPuntaVendedora.Leave += new System.EventHandler(this.txtPorcPuntaVendedora_Leave);
            // 
            // nupCantAcciones
            // 
            this.nupCantAcciones.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.nupCantAcciones.Location = new System.Drawing.Point(137, 148);
            this.nupCantAcciones.Name = "nupCantAcciones";
            this.nupCantAcciones.Size = new System.Drawing.Size(58, 29);
            this.nupCantAcciones.TabIndex = 3;
            this.nupCantAcciones.Click += new System.EventHandler(this.nupCantAcciones_Click);
            this.nupCantAcciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupCantAcciones_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label22.Location = new System.Drawing.Point(4, 156);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(128, 21);
            this.label22.TabIndex = 164;
            this.label22.Text = "Cant. Acciones:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label11.Location = new System.Drawing.Point(510, 234);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 21);
            this.label11.TabIndex = 162;
            this.label11.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label10.Location = new System.Drawing.Point(253, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 21);
            this.label10.TabIndex = 161;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label9.Location = new System.Drawing.Point(253, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 21);
            this.label9.TabIndex = 160;
            this.label9.Text = "%";
            // 
            // txtPorcComisionIOL
            // 
            this.txtPorcComisionIOL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcComisionIOL.Location = new System.Drawing.Point(137, 187);
            this.txtPorcComisionIOL.Name = "txtPorcComisionIOL";
            this.txtPorcComisionIOL.Size = new System.Drawing.Size(115, 29);
            this.txtPorcComisionIOL.TabIndex = 4;
            this.txtPorcComisionIOL.Click += new System.EventHandler(this.txtPorcComision_Click);
            this.txtPorcComisionIOL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcComision_KeyPress);
            this.txtPorcComisionIOL.Leave += new System.EventHandler(this.txtPorcComision_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label1.Location = new System.Drawing.Point(10, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 158;
            this.label1.Text = "Comisión IOL:";
            // 
            // txtPorcCompra
            // 
            this.txtPorcCompra.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcCompra.Location = new System.Drawing.Point(137, 226);
            this.txtPorcCompra.Name = "txtPorcCompra";
            this.txtPorcCompra.Size = new System.Drawing.Size(115, 29);
            this.txtPorcCompra.TabIndex = 5;
            this.txtPorcCompra.Click += new System.EventHandler(this.txtPorcCompra_Click);
            this.txtPorcCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcCompra_KeyPress);
            this.txtPorcCompra.Leave += new System.EventHandler(this.txtPorcCompra_Leave);
            // 
            // lblOperar
            // 
            this.lblOperar.AutoSize = true;
            this.lblOperar.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblOperar.Location = new System.Drawing.Point(66, 74);
            this.lblOperar.Name = "lblOperar";
            this.lblOperar.Size = new System.Drawing.Size(66, 21);
            this.lblOperar.TabIndex = 150;
            this.lblOperar.Text = "Operar:";
            // 
            // lblPorcCompra
            // 
            this.lblPorcCompra.AutoSize = true;
            this.lblPorcCompra.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPorcCompra.ForeColor = System.Drawing.Color.Green;
            this.lblPorcCompra.Location = new System.Drawing.Point(42, 231);
            this.lblPorcCompra.Name = "lblPorcCompra";
            this.lblPorcCompra.Size = new System.Drawing.Size(90, 22);
            this.lblPorcCompra.TabIndex = 152;
            this.lblPorcCompra.Text = "Comprar:";
            // 
            // lblPorcVenta
            // 
            this.lblPorcVenta.AutoSize = true;
            this.lblPorcVenta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPorcVenta.ForeColor = System.Drawing.Color.Red;
            this.lblPorcVenta.Location = new System.Drawing.Point(319, 233);
            this.lblPorcVenta.Name = "lblPorcVenta";
            this.lblPorcVenta.Size = new System.Drawing.Size(72, 22);
            this.lblPorcVenta.TabIndex = 154;
            this.lblPorcVenta.Text = "Vender:";
            // 
            // txtPorcVenta
            // 
            this.txtPorcVenta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcVenta.Location = new System.Drawing.Point(395, 226);
            this.txtPorcVenta.Name = "txtPorcVenta";
            this.txtPorcVenta.Size = new System.Drawing.Size(115, 29);
            this.txtPorcVenta.TabIndex = 6;
            this.txtPorcVenta.Click += new System.EventHandler(this.txtPorcVenta_Click);
            this.txtPorcVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcVenta_KeyPress);
            this.txtPorcVenta.Leave += new System.EventHandler(this.txtPorcVenta_Leave);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblFecha.Location = new System.Drawing.Point(291, 28);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(59, 21);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtIdRueda
            // 
            this.txtIdRueda.Enabled = false;
            this.txtIdRueda.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdRueda.Location = new System.Drawing.Point(136, 21);
            this.txtIdRueda.Name = "txtIdRueda";
            this.txtIdRueda.Size = new System.Drawing.Size(115, 29);
            this.txtIdRueda.TabIndex = 0;
            // 
            // txtSaldoARetirar
            // 
            this.txtSaldoARetirar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtSaldoARetirar.Location = new System.Drawing.Point(137, 108);
            this.txtSaldoARetirar.Name = "txtSaldoARetirar";
            this.txtSaldoARetirar.Size = new System.Drawing.Size(115, 29);
            this.txtSaldoARetirar.TabIndex = 2;
            this.txtSaldoARetirar.Click += new System.EventHandler(this.txtSaldoARetirar_Click);
            this.txtSaldoARetirar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaldoARetirar_KeyPress);
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(355, 20);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(115, 29);
            this.txtFecha.TabIndex = 1;
            // 
            // lblInversionTotal
            // 
            this.lblInversionTotal.AutoSize = true;
            this.lblInversionTotal.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblInversionTotal.Location = new System.Drawing.Point(7, 116);
            this.lblInversionTotal.Name = "lblInversionTotal";
            this.lblInversionTotal.Size = new System.Drawing.Size(125, 21);
            this.lblInversionTotal.TabIndex = 4;
            this.lblInversionTotal.Text = "Saldo a Retirar:";
            // 
            // lblIdComitente
            // 
            this.lblIdComitente.AutoSize = true;
            this.lblIdComitente.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblIdComitente.Location = new System.Drawing.Point(44, 29);
            this.lblIdComitente.Name = "lblIdComitente";
            this.lblIdComitente.Size = new System.Drawing.Size(88, 21);
            this.lblIdComitente.TabIndex = 33;
            this.lblIdComitente.Text = "Id. Rueda:";
            // 
            // gpbOperar
            // 
            this.gpbOperar.Controls.Add(this.chkNo);
            this.gpbOperar.Controls.Add(this.chkSi);
            this.gpbOperar.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.gpbOperar.Location = new System.Drawing.Point(137, 49);
            this.gpbOperar.Name = "gpbOperar";
            this.gpbOperar.Size = new System.Drawing.Size(114, 47);
            this.gpbOperar.TabIndex = 2;
            this.gpbOperar.TabStop = false;
            // 
            // chkNo
            // 
            this.chkNo.AutoSize = true;
            this.chkNo.Location = new System.Drawing.Point(54, 18);
            this.chkNo.Name = "chkNo";
            this.chkNo.Size = new System.Drawing.Size(56, 25);
            this.chkNo.TabIndex = 0;
            this.chkNo.Text = "NO";
            this.chkNo.UseVisualStyleBackColor = true;
            this.chkNo.CheckedChanged += new System.EventHandler(this.chkNo_CheckedChanged);
            // 
            // chkSi
            // 
            this.chkSi.AutoSize = true;
            this.chkSi.Location = new System.Drawing.Point(2, 18);
            this.chkSi.Name = "chkSi";
            this.chkSi.Size = new System.Drawing.Size(46, 25);
            this.chkSi.TabIndex = 0;
            this.chkSi.Text = "SI";
            this.chkSi.UseVisualStyleBackColor = true;
            this.chkSi.CheckedChanged += new System.EventHandler(this.chkSi_CheckedChanged);
            // 
            // tbpSimulador
            // 
            this.tbpSimulador.Controls.Add(this.btnGuardarSimulador);
            this.tbpSimulador.Controls.Add(this.txtEstrategia);
            this.tbpSimulador.Controls.Add(this.label46);
            this.tbpSimulador.Controls.Add(this.label45);
            this.tbpSimulador.Controls.Add(this.label16);
            this.tbpSimulador.Controls.Add(this.label13);
            this.tbpSimulador.Controls.Add(this.label8);
            this.tbpSimulador.Controls.Add(this.txtPorcCompraSimulador);
            this.tbpSimulador.Controls.Add(this.label3);
            this.tbpSimulador.Controls.Add(this.txtIdSimulador);
            this.tbpSimulador.Controls.Add(this.txtPorcVentaSimulador);
            this.tbpSimulador.Controls.Add(this.label44);
            this.tbpSimulador.Controls.Add(this.dgvListado);
            this.tbpSimulador.Location = new System.Drawing.Point(4, 22);
            this.tbpSimulador.Name = "tbpSimulador";
            this.tbpSimulador.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSimulador.Size = new System.Drawing.Size(706, 401);
            this.tbpSimulador.TabIndex = 1;
            this.tbpSimulador.Text = "Datos Simulador";
            this.tbpSimulador.UseVisualStyleBackColor = true;
            // 
            // btnGuardarSimulador
            // 
            this.btnGuardarSimulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardarSimulador.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarSimulador.Location = new System.Drawing.Point(524, 255);
            this.btnGuardarSimulador.Name = "btnGuardarSimulador";
            this.btnGuardarSimulador.Size = new System.Drawing.Size(122, 46);
            this.btnGuardarSimulador.TabIndex = 251;
            this.btnGuardarSimulador.Text = "Guardar";
            this.btnGuardarSimulador.UseVisualStyleBackColor = true;
            this.btnGuardarSimulador.Click += new System.EventHandler(this.btnGuardarSimulador_Click);
            // 
            // txtEstrategia
            // 
            this.txtEstrategia.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstrategia.Location = new System.Drawing.Point(565, 124);
            this.txtEstrategia.Name = "txtEstrategia";
            this.txtEstrategia.Size = new System.Drawing.Size(46, 29);
            this.txtEstrategia.TabIndex = 250;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label46.Location = new System.Drawing.Point(460, 131);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(100, 22);
            this.label46.TabIndex = 249;
            this.label46.Text = "Estrategia:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label45.Location = new System.Drawing.Point(461, 90);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(99, 22);
            this.label45.TabIndex = 248;
            this.label45.Text = "Simulador:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label16.Location = new System.Drawing.Point(648, 214);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 21);
            this.label16.TabIndex = 185;
            this.label16.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label13.Location = new System.Drawing.Point(649, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 21);
            this.label13.TabIndex = 181;
            this.label13.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(487, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 22);
            this.label8.TabIndex = 179;
            this.label8.Text = "Vender:";
            // 
            // txtPorcCompraSimulador
            // 
            this.txtPorcCompraSimulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcCompraSimulador.Location = new System.Drawing.Point(565, 165);
            this.txtPorcCompraSimulador.Name = "txtPorcCompraSimulador";
            this.txtPorcCompraSimulador.Size = new System.Drawing.Size(81, 29);
            this.txtPorcCompraSimulador.TabIndex = 1;
            this.txtPorcCompraSimulador.Click += new System.EventHandler(this.txtPorcCompraSimulador_Click);
            this.txtPorcCompraSimulador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcCompraSimulador_KeyPress);
            this.txtPorcCompraSimulador.Leave += new System.EventHandler(this.txtPorcCompraSimulador_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(469, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 173;
            this.label3.Text = "Comprar:";
            // 
            // txtIdSimulador
            // 
            this.txtIdSimulador.Enabled = false;
            this.txtIdSimulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdSimulador.Location = new System.Drawing.Point(565, 83);
            this.txtIdSimulador.Name = "txtIdSimulador";
            this.txtIdSimulador.Size = new System.Drawing.Size(46, 29);
            this.txtIdSimulador.TabIndex = 0;
            // 
            // txtPorcVentaSimulador
            // 
            this.txtPorcVentaSimulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcVentaSimulador.Location = new System.Drawing.Point(565, 206);
            this.txtPorcVentaSimulador.Name = "txtPorcVentaSimulador";
            this.txtPorcVentaSimulador.Size = new System.Drawing.Size(81, 29);
            this.txtPorcVentaSimulador.TabIndex = 2;
            this.txtPorcVentaSimulador.Click += new System.EventHandler(this.txtPorcVentaSimulador_Click);
            this.txtPorcVentaSimulador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcVentaSimulador_KeyPress);
            this.txtPorcVentaSimulador.Leave += new System.EventHandler(this.txtPorcVentaSimulador_Leave);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.SeaShell;
            this.label44.Font = new System.Drawing.Font("Georgia", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label44.Location = new System.Drawing.Point(23, 14);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(190, 31);
            this.label44.TabIndex = 247;
            this.label44.Text = "Simuladores";
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(22, 47);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(430, 292);
            this.dgvListado.TabIndex = 246;
            this.dgvListado.SelectionChanged += new System.EventHandler(this.dgvListado_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label2.Location = new System.Drawing.Point(258, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 21);
            this.label2.TabIndex = 173;
            this.label2.Text = "$";
            // 
            // RuedasEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImage = global::IOL.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(738, 492);
            this.Controls.Add(this.tbcDatosRueda);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RuedasEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RuedasEditar";
            this.Load += new System.EventHandler(this.RuedasEditar_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tbcDatosRueda.ResumeLayout(false);
            this.tbpDatosRueda.ResumeLayout(false);
            this.tbpDatosRueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprarHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCantAcciones)).EndInit();
            this.gpbOperar.ResumeLayout(false);
            this.gpbOperar.PerformLayout();
            this.tbpSimulador.ResumeLayout(false);
            this.tbpSimulador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        public System.Windows.Forms.TabControl tbcDatosRueda;
        public System.Windows.Forms.TabPage tbpDatosRueda;
        public System.Windows.Forms.TextBox txtPorcCompra;
        public System.Windows.Forms.Label lblPorcCompra;
        public System.Windows.Forms.Label lblPorcVenta;
        public System.Windows.Forms.TextBox txtPorcVenta;
        public System.Windows.Forms.Label lblFecha;
        public System.Windows.Forms.TextBox txtIdRueda;
        public System.Windows.Forms.TextBox txtSaldoARetirar;
        public System.Windows.Forms.TextBox txtFecha;
        public System.Windows.Forms.Label lblInversionTotal;
        public System.Windows.Forms.Label lblIdComitente;
        private System.Windows.Forms.GroupBox gpbOperar;
        private System.Windows.Forms.CheckBox chkNo;
        private System.Windows.Forms.CheckBox chkSi;
        public System.Windows.Forms.Label lblOperar;
        public System.Windows.Forms.TextBox txtPorcComisionIOL;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbpSimulador;
        public System.Windows.Forms.TextBox txtIdSimulador;
        public System.Windows.Forms.TextBox txtPorcVentaSimulador;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtPorcCompraSimulador;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nupCantAcciones;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.TextBox txtPorcPuntaCompradora;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.TextBox txtPorcPuntaVendedora;
        public System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown nudComprarHasta;
        public System.Windows.Forms.Label label28;
        public System.Windows.Forms.TextBox txtEstrategia;
        public System.Windows.Forms.Label label46;
        public System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Button btnGuardarSimulador;
        public System.Windows.Forms.Label label2;
    }
}