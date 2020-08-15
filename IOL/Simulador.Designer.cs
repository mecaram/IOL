namespace IOL
{
    partial class Simulador
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulador));
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tmrActualizarToken = new System.Windows.Forms.Timer(this.components);
            this.tmrActualizarCotizacion = new System.Windows.Forms.Timer(this.components);
            this.tbcDatosRueda = new System.Windows.Forms.TabControl();
            this.tbpDatosRueda = new System.Windows.Forms.TabPage();
            this.btnCerrarRueda = new System.Windows.Forms.Button();
            this.btnActualizarRueda = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtPorcPuntaVendedora = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtPorcPuntaCompradora = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPorcComisionIOL = new System.Windows.Forms.Label();
            this.txtPorcComisionIOL = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPorcVenta = new System.Windows.Forms.Label();
            this.txtPorcVenta = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPorcCompra = new System.Windows.Forms.TextBox();
            this.lblPorcCompra = new System.Windows.Forms.Label();
            this.txtIdRueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.tbpDatosSimulador = new System.Windows.Forms.TabPage();
            this.btnActualizarSimulador = new System.Windows.Forms.Button();
            this.dgvAcciones = new System.Windows.Forms.DataGridView();
            this.lblAcciones = new System.Windows.Forms.Label();
            this.lblOperar = new System.Windows.Forms.Label();
            this.nudSimulador = new System.Windows.Forms.NumericUpDown();
            this.lnkEstrategia = new System.Windows.Forms.LinkLabel();
            this.lblTotales = new System.Windows.Forms.Label();
            this.txtTotalAccionesCompradas = new System.Windows.Forms.TextBox();
            this.txtTotalCantidadCompradas = new System.Windows.Forms.TextBox();
            this.txtTotalImporteCompra = new System.Windows.Forms.TextBox();
            this.txtTotalVariacionEnPesosComp = new System.Windows.Forms.TextBox();
            this.txtTotalVariacionEnPorcentajesCompra = new System.Windows.Forms.TextBox();
            this.lblTotalAcciones = new System.Windows.Forms.Label();
            this.lblTotalCantidad = new System.Windows.Forms.Label();
            this.lblTotalImporte = new System.Windows.Forms.Label();
            this.lblVariacionEnPesos = new System.Windows.Forms.Label();
            this.lblVariacionEnPorcentajes = new System.Windows.Forms.Label();
            this.lblImporteComision = new System.Windows.Forms.Label();
            this.txtImporteComisionCompradas = new System.Windows.Forms.TextBox();
            this.txtImporteComisionVendidas = new System.Windows.Forms.TextBox();
            this.txtTotalVariacionEnPorcentajesVenta = new System.Windows.Forms.TextBox();
            this.txtTotalVariacionEnPesosVent = new System.Windows.Forms.TextBox();
            this.txtTotalImporteVenta = new System.Windows.Forms.TextBox();
            this.txtTotalCantidadVendidas = new System.Windows.Forms.TextBox();
            this.txtTotalAccionesVendidas = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.dgvListado = new System.Windows.Forms.DataGridView();
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
            this.tbcDatosRueda.SuspendLayout();
            this.tbpDatosRueda.SuspendLayout();
            this.tbpDatosSimulador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimulador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            // 
            // tmrActualizarToken
            // 
            this.tmrActualizarToken.Enabled = true;
            this.tmrActualizarToken.Interval = 840000;
            this.tmrActualizarToken.Tick += new System.EventHandler(this.tmrActualizarToken_Tick);
            // 
            // tmrActualizarCotizacion
            // 
            this.tmrActualizarCotizacion.Enabled = true;
            this.tmrActualizarCotizacion.Interval = 30000;
            this.tmrActualizarCotizacion.Tick += new System.EventHandler(this.tmrActualizarCotizacion_Tick);
            // 
            // tbcDatosRueda
            // 
            this.tbcDatosRueda.Controls.Add(this.tbpDatosRueda);
            this.tbcDatosRueda.Controls.Add(this.tbpDatosSimulador);
            this.tbcDatosRueda.Location = new System.Drawing.Point(3, 8);
            this.tbcDatosRueda.Name = "tbcDatosRueda";
            this.tbcDatosRueda.SelectedIndex = 0;
            this.tbcDatosRueda.Size = new System.Drawing.Size(247, 507);
            this.tbcDatosRueda.TabIndex = 0;
            // 
            // tbpDatosRueda
            // 
            this.tbpDatosRueda.Controls.Add(this.btnCerrarRueda);
            this.tbpDatosRueda.Controls.Add(this.btnActualizarRueda);
            this.tbpDatosRueda.Controls.Add(this.label26);
            this.tbpDatosRueda.Controls.Add(this.label27);
            this.tbpDatosRueda.Controls.Add(this.txtPorcPuntaVendedora);
            this.tbpDatosRueda.Controls.Add(this.label24);
            this.tbpDatosRueda.Controls.Add(this.txtPorcPuntaCompradora);
            this.tbpDatosRueda.Controls.Add(this.label25);
            this.tbpDatosRueda.Controls.Add(this.label4);
            this.tbpDatosRueda.Controls.Add(this.lblPorcComisionIOL);
            this.tbpDatosRueda.Controls.Add(this.txtPorcComisionIOL);
            this.tbpDatosRueda.Controls.Add(this.label11);
            this.tbpDatosRueda.Controls.Add(this.lblPorcVenta);
            this.tbpDatosRueda.Controls.Add(this.txtPorcVenta);
            this.tbpDatosRueda.Controls.Add(this.label10);
            this.tbpDatosRueda.Controls.Add(this.txtPorcCompra);
            this.tbpDatosRueda.Controls.Add(this.lblPorcCompra);
            this.tbpDatosRueda.Controls.Add(this.txtIdRueda);
            this.tbpDatosRueda.Controls.Add(this.label2);
            this.tbpDatosRueda.Controls.Add(this.label30);
            this.tbpDatosRueda.Controls.Add(this.txtEstado);
            this.tbpDatosRueda.Controls.Add(this.txtFecha);
            this.tbpDatosRueda.Controls.Add(this.label1);
            this.tbpDatosRueda.Controls.Add(this.label29);
            this.tbpDatosRueda.Controls.Add(this.txtHora);
            this.tbpDatosRueda.Location = new System.Drawing.Point(4, 22);
            this.tbpDatosRueda.Name = "tbpDatosRueda";
            this.tbpDatosRueda.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDatosRueda.Size = new System.Drawing.Size(239, 457);
            this.tbpDatosRueda.TabIndex = 0;
            this.tbpDatosRueda.Text = "Datos Rueda";
            this.tbpDatosRueda.UseVisualStyleBackColor = true;
            // 
            // btnCerrarRueda
            // 
            this.btnCerrarRueda.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarRueda.Location = new System.Drawing.Point(19, 372);
            this.btnCerrarRueda.Name = "btnCerrarRueda";
            this.btnCerrarRueda.Size = new System.Drawing.Size(198, 26);
            this.btnCerrarRueda.TabIndex = 225;
            this.btnCerrarRueda.Text = "Cerrar Rueda";
            this.btnCerrarRueda.UseVisualStyleBackColor = true;
            this.btnCerrarRueda.Click += new System.EventHandler(this.btnCerrarRueda_Click);
            // 
            // btnActualizarRueda
            // 
            this.btnActualizarRueda.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarRueda.Location = new System.Drawing.Point(19, 334);
            this.btnActualizarRueda.Name = "btnActualizarRueda";
            this.btnActualizarRueda.Size = new System.Drawing.Size(198, 28);
            this.btnActualizarRueda.TabIndex = 223;
            this.btnActualizarRueda.Text = "Actualizar Rueda";
            this.btnActualizarRueda.UseVisualStyleBackColor = true;
            this.btnActualizarRueda.Click += new System.EventHandler(this.btnActualizarRueda_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(180, 299);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(26, 21);
            this.label26.TabIndex = 222;
            this.label26.Text = "%";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.Color.Red;
            this.label27.Location = new System.Drawing.Point(15, 298);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 22);
            this.label27.TabIndex = 221;
            this.label27.Text = "P. Vend.:";
            // 
            // txtPorcPuntaVendedora
            // 
            this.txtPorcPuntaVendedora.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcPuntaVendedora.Location = new System.Drawing.Point(97, 294);
            this.txtPorcPuntaVendedora.Name = "txtPorcPuntaVendedora";
            this.txtPorcPuntaVendedora.Size = new System.Drawing.Size(79, 29);
            this.txtPorcPuntaVendedora.TabIndex = 9;
            this.txtPorcPuntaVendedora.Click += new System.EventHandler(this.txtPorcPuntaVendedora_Click);
            this.txtPorcPuntaVendedora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcPuntaVendedora_KeyPress);
            this.txtPorcPuntaVendedora.Leave += new System.EventHandler(this.txtPorcPuntaVendedora_Leave);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label24.ForeColor = System.Drawing.Color.Green;
            this.label24.Location = new System.Drawing.Point(181, 264);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 21);
            this.label24.TabIndex = 219;
            this.label24.Text = "%";
            // 
            // txtPorcPuntaCompradora
            // 
            this.txtPorcPuntaCompradora.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcPuntaCompradora.Location = new System.Drawing.Point(97, 259);
            this.txtPorcPuntaCompradora.Name = "txtPorcPuntaCompradora";
            this.txtPorcPuntaCompradora.Size = new System.Drawing.Size(79, 29);
            this.txtPorcPuntaCompradora.TabIndex = 8;
            this.txtPorcPuntaCompradora.Click += new System.EventHandler(this.txtPorcPuntaCompradora_Click);
            this.txtPorcPuntaCompradora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcPuntaCompradora_KeyPress);
            this.txtPorcPuntaCompradora.Leave += new System.EventHandler(this.txtPorcPuntaCompradora_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Green;
            this.label25.Location = new System.Drawing.Point(6, 263);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(89, 22);
            this.label25.TabIndex = 218;
            this.label25.Text = "P. Comp.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label4.Location = new System.Drawing.Point(180, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 21);
            this.label4.TabIndex = 216;
            this.label4.Text = "%";
            // 
            // lblPorcComisionIOL
            // 
            this.lblPorcComisionIOL.AutoSize = true;
            this.lblPorcComisionIOL.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblPorcComisionIOL.Location = new System.Drawing.Point(9, 233);
            this.lblPorcComisionIOL.Name = "lblPorcComisionIOL";
            this.lblPorcComisionIOL.Size = new System.Drawing.Size(86, 21);
            this.lblPorcComisionIOL.TabIndex = 215;
            this.lblPorcComisionIOL.Text = "Comisión:";
            // 
            // txtPorcComisionIOL
            // 
            this.txtPorcComisionIOL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcComisionIOL.Location = new System.Drawing.Point(97, 224);
            this.txtPorcComisionIOL.Name = "txtPorcComisionIOL";
            this.txtPorcComisionIOL.Size = new System.Drawing.Size(79, 29);
            this.txtPorcComisionIOL.TabIndex = 7;
            this.txtPorcComisionIOL.Click += new System.EventHandler(this.txtPorcComisionIOL_Click);
            this.txtPorcComisionIOL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcComisionIOL_KeyPress);
            this.txtPorcComisionIOL.Leave += new System.EventHandler(this.txtPorcComisionIOL_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(180, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 21);
            this.label11.TabIndex = 213;
            this.label11.Text = "%";
            // 
            // lblPorcVenta
            // 
            this.lblPorcVenta.AutoSize = true;
            this.lblPorcVenta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPorcVenta.ForeColor = System.Drawing.Color.Red;
            this.lblPorcVenta.Location = new System.Drawing.Point(22, 193);
            this.lblPorcVenta.Name = "lblPorcVenta";
            this.lblPorcVenta.Size = new System.Drawing.Size(72, 22);
            this.lblPorcVenta.TabIndex = 212;
            this.lblPorcVenta.Text = "Vender:";
            // 
            // txtPorcVenta
            // 
            this.txtPorcVenta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcVenta.Location = new System.Drawing.Point(97, 189);
            this.txtPorcVenta.Name = "txtPorcVenta";
            this.txtPorcVenta.Size = new System.Drawing.Size(79, 29);
            this.txtPorcVenta.TabIndex = 6;
            this.txtPorcVenta.Click += new System.EventHandler(this.txtPorcVenta_Click);
            this.txtPorcVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcVenta_KeyPress);
            this.txtPorcVenta.Leave += new System.EventHandler(this.txtPorcVenta_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(180, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 21);
            this.label10.TabIndex = 210;
            this.label10.Text = "%";
            // 
            // txtPorcCompra
            // 
            this.txtPorcCompra.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPorcCompra.Location = new System.Drawing.Point(97, 154);
            this.txtPorcCompra.Name = "txtPorcCompra";
            this.txtPorcCompra.Size = new System.Drawing.Size(79, 29);
            this.txtPorcCompra.TabIndex = 5;
            this.txtPorcCompra.Click += new System.EventHandler(this.txtPorcCompra_Click);
            this.txtPorcCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcCompra_KeyPress);
            this.txtPorcCompra.Leave += new System.EventHandler(this.txtPorcCompra_Leave);
            // 
            // lblPorcCompra
            // 
            this.lblPorcCompra.AutoSize = true;
            this.lblPorcCompra.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPorcCompra.ForeColor = System.Drawing.Color.Green;
            this.lblPorcCompra.Location = new System.Drawing.Point(4, 158);
            this.lblPorcCompra.Name = "lblPorcCompra";
            this.lblPorcCompra.Size = new System.Drawing.Size(90, 22);
            this.lblPorcCompra.TabIndex = 209;
            this.lblPorcCompra.Text = "Comprar:";
            // 
            // txtIdRueda
            // 
            this.txtIdRueda.Enabled = false;
            this.txtIdRueda.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdRueda.Location = new System.Drawing.Point(97, 15);
            this.txtIdRueda.Name = "txtIdRueda";
            this.txtIdRueda.Size = new System.Drawing.Size(79, 29);
            this.txtIdRueda.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label2.Location = new System.Drawing.Point(26, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 203;
            this.label2.Text = "Estado:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label30.Location = new System.Drawing.Point(4, 23);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(88, 21);
            this.label30.TabIndex = 199;
            this.label30.Text = "Id. Rueda:";
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(97, 120);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(109, 29);
            this.txtEstado.TabIndex = 3;
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(97, 50);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(109, 29);
            this.txtFecha.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label1.Location = new System.Drawing.Point(41, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 201;
            this.label1.Text = "Hora:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label29.Location = new System.Drawing.Point(33, 58);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 21);
            this.label29.TabIndex = 198;
            this.label29.Text = "Fecha:";
            // 
            // txtHora
            // 
            this.txtHora.Enabled = false;
            this.txtHora.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(97, 85);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(109, 29);
            this.txtHora.TabIndex = 2;
            // 
            // tbpDatosSimulador
            // 
            this.tbpDatosSimulador.Controls.Add(this.txtEstrategia);
            this.tbpDatosSimulador.Controls.Add(this.label46);
            this.tbpDatosSimulador.Controls.Add(this.label45);
            this.tbpDatosSimulador.Controls.Add(this.label16);
            this.tbpDatosSimulador.Controls.Add(this.label13);
            this.tbpDatosSimulador.Controls.Add(this.label8);
            this.tbpDatosSimulador.Controls.Add(this.txtPorcCompraSimulador);
            this.tbpDatosSimulador.Controls.Add(this.label3);
            this.tbpDatosSimulador.Controls.Add(this.txtIdSimulador);
            this.tbpDatosSimulador.Controls.Add(this.txtPorcVentaSimulador);
            this.tbpDatosSimulador.Controls.Add(this.label44);
            this.tbpDatosSimulador.Controls.Add(this.dgvListado);
            this.tbpDatosSimulador.Controls.Add(this.btnActualizarSimulador);
            this.tbpDatosSimulador.Location = new System.Drawing.Point(4, 22);
            this.tbpDatosSimulador.Name = "tbpDatosSimulador";
            this.tbpDatosSimulador.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDatosSimulador.Size = new System.Drawing.Size(239, 481);
            this.tbpDatosSimulador.TabIndex = 1;
            this.tbpDatosSimulador.Text = "Datos Simulador";
            this.tbpDatosSimulador.UseVisualStyleBackColor = true;
            // 
            // btnActualizarSimulador
            // 
            this.btnActualizarSimulador.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarSimulador.Location = new System.Drawing.Point(20, 424);
            this.btnActualizarSimulador.Name = "btnActualizarSimulador";
            this.btnActualizarSimulador.Size = new System.Drawing.Size(198, 28);
            this.btnActualizarSimulador.TabIndex = 217;
            this.btnActualizarSimulador.Text = "Actualizar Simulador";
            this.btnActualizarSimulador.UseVisualStyleBackColor = true;
            this.btnActualizarSimulador.Click += new System.EventHandler(this.btnActualizarSimulador_Click);
            // 
            // dgvAcciones
            // 
            this.dgvAcciones.AllowUserToAddRows = false;
            this.dgvAcciones.AllowUserToDeleteRows = false;
            this.dgvAcciones.AllowUserToOrderColumns = true;
            this.dgvAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcciones.Location = new System.Drawing.Point(250, 37);
            this.dgvAcciones.Name = "dgvAcciones";
            this.dgvAcciones.ReadOnly = true;
            this.dgvAcciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAcciones.Size = new System.Drawing.Size(994, 368);
            this.dgvAcciones.TabIndex = 190;
            this.dgvAcciones.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAccionesCompradas_DataBindingComplete);
            this.dgvAcciones.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvAcciones_RowPrePaint);
            // 
            // lblAcciones
            // 
            this.lblAcciones.AutoSize = true;
            this.lblAcciones.BackColor = System.Drawing.Color.SeaShell;
            this.lblAcciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAcciones.Font = new System.Drawing.Font("Georgia", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcciones.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAcciones.Location = new System.Drawing.Point(248, 8);
            this.lblAcciones.Name = "lblAcciones";
            this.lblAcciones.Size = new System.Drawing.Size(189, 22);
            this.lblAcciones.TabIndex = 191;
            this.lblAcciones.Text = "Listado de Acciones";
            // 
            // lblOperar
            // 
            this.lblOperar.AutoSize = true;
            this.lblOperar.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lblOperar.Location = new System.Drawing.Point(454, 10);
            this.lblOperar.Name = "lblOperar";
            this.lblOperar.Size = new System.Drawing.Size(90, 21);
            this.lblOperar.TabIndex = 193;
            this.lblOperar.Text = "Simulador:";
            // 
            // nudSimulador
            // 
            this.nudSimulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSimulador.Location = new System.Drawing.Point(548, 6);
            this.nudSimulador.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSimulador.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSimulador.Name = "nudSimulador";
            this.nudSimulador.Size = new System.Drawing.Size(46, 29);
            this.nudSimulador.TabIndex = 194;
            this.nudSimulador.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSimulador.ValueChanged += new System.EventHandler(this.nudSimulador_ValueChanged);
            // 
            // lnkEstrategia
            // 
            this.lnkEstrategia.AutoSize = true;
            this.lnkEstrategia.Font = new System.Drawing.Font("Georgia", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lnkEstrategia.LinkColor = System.Drawing.SystemColors.Highlight;
            this.lnkEstrategia.Location = new System.Drawing.Point(600, 11);
            this.lnkEstrategia.Name = "lnkEstrategia";
            this.lnkEstrategia.Size = new System.Drawing.Size(143, 20);
            this.lnkEstrategia.TabIndex = 195;
            this.lnkEstrategia.TabStop = true;
            this.lnkEstrategia.Text = "Estrategia Uno";
            // 
            // lblTotales
            // 
            this.lblTotales.AutoSize = true;
            this.lblTotales.BackColor = System.Drawing.Color.SeaShell;
            this.lblTotales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotales.Font = new System.Drawing.Font("Georgia", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotales.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotales.Location = new System.Drawing.Point(263, 451);
            this.lblTotales.Name = "lblTotales";
            this.lblTotales.Size = new System.Drawing.Size(192, 22);
            this.lblTotales.TabIndex = 196;
            this.lblTotales.Text = "Total Simulador 00:";
            // 
            // txtTotalAccionesCompradas
            // 
            this.txtTotalAccionesCompradas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalAccionesCompradas.ForeColor = System.Drawing.Color.Green;
            this.txtTotalAccionesCompradas.Location = new System.Drawing.Point(461, 431);
            this.txtTotalAccionesCompradas.Name = "txtTotalAccionesCompradas";
            this.txtTotalAccionesCompradas.ReadOnly = true;
            this.txtTotalAccionesCompradas.Size = new System.Drawing.Size(83, 29);
            this.txtTotalAccionesCompradas.TabIndex = 197;
            this.txtTotalAccionesCompradas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalCantidadCompradas
            // 
            this.txtTotalCantidadCompradas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalCantidadCompradas.ForeColor = System.Drawing.Color.Green;
            this.txtTotalCantidadCompradas.Location = new System.Drawing.Point(547, 431);
            this.txtTotalCantidadCompradas.Name = "txtTotalCantidadCompradas";
            this.txtTotalCantidadCompradas.ReadOnly = true;
            this.txtTotalCantidadCompradas.Size = new System.Drawing.Size(83, 29);
            this.txtTotalCantidadCompradas.TabIndex = 198;
            this.txtTotalCantidadCompradas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalImporteCompra
            // 
            this.txtTotalImporteCompra.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalImporteCompra.ForeColor = System.Drawing.Color.Green;
            this.txtTotalImporteCompra.Location = new System.Drawing.Point(746, 431);
            this.txtTotalImporteCompra.Name = "txtTotalImporteCompra";
            this.txtTotalImporteCompra.ReadOnly = true;
            this.txtTotalImporteCompra.Size = new System.Drawing.Size(110, 29);
            this.txtTotalImporteCompra.TabIndex = 199;
            this.txtTotalImporteCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalVariacionEnPesosComp
            // 
            this.txtTotalVariacionEnPesosComp.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalVariacionEnPesosComp.ForeColor = System.Drawing.Color.Green;
            this.txtTotalVariacionEnPesosComp.Location = new System.Drawing.Point(859, 431);
            this.txtTotalVariacionEnPesosComp.Name = "txtTotalVariacionEnPesosComp";
            this.txtTotalVariacionEnPesosComp.ReadOnly = true;
            this.txtTotalVariacionEnPesosComp.Size = new System.Drawing.Size(110, 29);
            this.txtTotalVariacionEnPesosComp.TabIndex = 200;
            this.txtTotalVariacionEnPesosComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalVariacionEnPorcentajesCompra
            // 
            this.txtTotalVariacionEnPorcentajesCompra.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalVariacionEnPorcentajesCompra.ForeColor = System.Drawing.Color.Green;
            this.txtTotalVariacionEnPorcentajesCompra.Location = new System.Drawing.Point(972, 431);
            this.txtTotalVariacionEnPorcentajesCompra.Name = "txtTotalVariacionEnPorcentajesCompra";
            this.txtTotalVariacionEnPorcentajesCompra.ReadOnly = true;
            this.txtTotalVariacionEnPorcentajesCompra.Size = new System.Drawing.Size(110, 29);
            this.txtTotalVariacionEnPorcentajesCompra.TabIndex = 201;
            this.txtTotalVariacionEnPorcentajesCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotalVariacionEnPorcentajesCompra.TextChanged += new System.EventHandler(this.txtTotalVariacionEnPorcentajes_TextChanged);
            // 
            // lblTotalAcciones
            // 
            this.lblTotalAcciones.AutoSize = true;
            this.lblTotalAcciones.BackColor = System.Drawing.Color.SeaShell;
            this.lblTotalAcciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalAcciones.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAcciones.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalAcciones.Location = new System.Drawing.Point(464, 410);
            this.lblTotalAcciones.Name = "lblTotalAcciones";
            this.lblTotalAcciones.Size = new System.Drawing.Size(76, 18);
            this.lblTotalAcciones.TabIndex = 202;
            this.lblTotalAcciones.Text = "Acciones";
            // 
            // lblTotalCantidad
            // 
            this.lblTotalCantidad.AutoSize = true;
            this.lblTotalCantidad.BackColor = System.Drawing.Color.SeaShell;
            this.lblTotalCantidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalCantidad.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCantidad.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalCantidad.Location = new System.Drawing.Point(551, 410);
            this.lblTotalCantidad.Name = "lblTotalCantidad";
            this.lblTotalCantidad.Size = new System.Drawing.Size(75, 18);
            this.lblTotalCantidad.TabIndex = 203;
            this.lblTotalCantidad.Text = "Cantidad";
            // 
            // lblTotalImporte
            // 
            this.lblTotalImporte.AutoSize = true;
            this.lblTotalImporte.BackColor = System.Drawing.Color.SeaShell;
            this.lblTotalImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalImporte.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalImporte.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalImporte.Location = new System.Drawing.Point(764, 410);
            this.lblTotalImporte.Name = "lblTotalImporte";
            this.lblTotalImporte.Size = new System.Drawing.Size(75, 18);
            this.lblTotalImporte.TabIndex = 204;
            this.lblTotalImporte.Text = "Importe.";
            // 
            // lblVariacionEnPesos
            // 
            this.lblVariacionEnPesos.AutoSize = true;
            this.lblVariacionEnPesos.BackColor = System.Drawing.Color.SeaShell;
            this.lblVariacionEnPesos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVariacionEnPesos.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariacionEnPesos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblVariacionEnPesos.Location = new System.Drawing.Point(868, 410);
            this.lblVariacionEnPesos.Name = "lblVariacionEnPesos";
            this.lblVariacionEnPesos.Size = new System.Drawing.Size(93, 18);
            this.lblVariacionEnPesos.TabIndex = 205;
            this.lblVariacionEnPesos.Text = "Variacion $";
            // 
            // lblVariacionEnPorcentajes
            // 
            this.lblVariacionEnPorcentajes.AutoSize = true;
            this.lblVariacionEnPorcentajes.BackColor = System.Drawing.Color.SeaShell;
            this.lblVariacionEnPorcentajes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVariacionEnPorcentajes.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariacionEnPorcentajes.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblVariacionEnPorcentajes.Location = new System.Drawing.Point(979, 410);
            this.lblVariacionEnPorcentajes.Name = "lblVariacionEnPorcentajes";
            this.lblVariacionEnPorcentajes.Size = new System.Drawing.Size(96, 18);
            this.lblVariacionEnPorcentajes.TabIndex = 206;
            this.lblVariacionEnPorcentajes.Text = "Variacion %";
            // 
            // lblImporteComision
            // 
            this.lblImporteComision.AutoSize = true;
            this.lblImporteComision.BackColor = System.Drawing.Color.SeaShell;
            this.lblImporteComision.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblImporteComision.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteComision.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblImporteComision.Location = new System.Drawing.Point(648, 410);
            this.lblImporteComision.Name = "lblImporteComision";
            this.lblImporteComision.Size = new System.Drawing.Size(80, 18);
            this.lblImporteComision.TabIndex = 208;
            this.lblImporteComision.Text = "Comisión";
            // 
            // txtImporteComisionCompradas
            // 
            this.txtImporteComisionCompradas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtImporteComisionCompradas.ForeColor = System.Drawing.Color.Green;
            this.txtImporteComisionCompradas.Location = new System.Drawing.Point(633, 431);
            this.txtImporteComisionCompradas.Name = "txtImporteComisionCompradas";
            this.txtImporteComisionCompradas.ReadOnly = true;
            this.txtImporteComisionCompradas.Size = new System.Drawing.Size(110, 29);
            this.txtImporteComisionCompradas.TabIndex = 207;
            this.txtImporteComisionCompradas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtImporteComisionVendidas
            // 
            this.txtImporteComisionVendidas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtImporteComisionVendidas.ForeColor = System.Drawing.Color.Red;
            this.txtImporteComisionVendidas.Location = new System.Drawing.Point(633, 462);
            this.txtImporteComisionVendidas.Name = "txtImporteComisionVendidas";
            this.txtImporteComisionVendidas.ReadOnly = true;
            this.txtImporteComisionVendidas.Size = new System.Drawing.Size(110, 29);
            this.txtImporteComisionVendidas.TabIndex = 214;
            this.txtImporteComisionVendidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalVariacionEnPorcentajesVenta
            // 
            this.txtTotalVariacionEnPorcentajesVenta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalVariacionEnPorcentajesVenta.ForeColor = System.Drawing.Color.Red;
            this.txtTotalVariacionEnPorcentajesVenta.Location = new System.Drawing.Point(972, 462);
            this.txtTotalVariacionEnPorcentajesVenta.Name = "txtTotalVariacionEnPorcentajesVenta";
            this.txtTotalVariacionEnPorcentajesVenta.ReadOnly = true;
            this.txtTotalVariacionEnPorcentajesVenta.Size = new System.Drawing.Size(110, 29);
            this.txtTotalVariacionEnPorcentajesVenta.TabIndex = 213;
            this.txtTotalVariacionEnPorcentajesVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalVariacionEnPesosVent
            // 
            this.txtTotalVariacionEnPesosVent.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalVariacionEnPesosVent.ForeColor = System.Drawing.Color.Red;
            this.txtTotalVariacionEnPesosVent.Location = new System.Drawing.Point(859, 462);
            this.txtTotalVariacionEnPesosVent.Name = "txtTotalVariacionEnPesosVent";
            this.txtTotalVariacionEnPesosVent.ReadOnly = true;
            this.txtTotalVariacionEnPesosVent.Size = new System.Drawing.Size(110, 29);
            this.txtTotalVariacionEnPesosVent.TabIndex = 212;
            this.txtTotalVariacionEnPesosVent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalImporteVenta
            // 
            this.txtTotalImporteVenta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalImporteVenta.ForeColor = System.Drawing.Color.Red;
            this.txtTotalImporteVenta.Location = new System.Drawing.Point(746, 462);
            this.txtTotalImporteVenta.Name = "txtTotalImporteVenta";
            this.txtTotalImporteVenta.ReadOnly = true;
            this.txtTotalImporteVenta.Size = new System.Drawing.Size(110, 29);
            this.txtTotalImporteVenta.TabIndex = 211;
            this.txtTotalImporteVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalCantidadVendidas
            // 
            this.txtTotalCantidadVendidas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalCantidadVendidas.ForeColor = System.Drawing.Color.Red;
            this.txtTotalCantidadVendidas.Location = new System.Drawing.Point(547, 462);
            this.txtTotalCantidadVendidas.Name = "txtTotalCantidadVendidas";
            this.txtTotalCantidadVendidas.ReadOnly = true;
            this.txtTotalCantidadVendidas.Size = new System.Drawing.Size(83, 29);
            this.txtTotalCantidadVendidas.TabIndex = 210;
            this.txtTotalCantidadVendidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalAccionesVendidas
            // 
            this.txtTotalAccionesVendidas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalAccionesVendidas.ForeColor = System.Drawing.Color.Red;
            this.txtTotalAccionesVendidas.Location = new System.Drawing.Point(461, 462);
            this.txtTotalAccionesVendidas.Name = "txtTotalAccionesVendidas";
            this.txtTotalAccionesVendidas.ReadOnly = true;
            this.txtTotalAccionesVendidas.Size = new System.Drawing.Size(83, 29);
            this.txtTotalAccionesVendidas.TabIndex = 209;
            this.txtTotalAccionesVendidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.SeaShell;
            this.label44.Font = new System.Drawing.Font("Georgia", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label44.Location = new System.Drawing.Point(24, 7);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(190, 31);
            this.label44.TabIndex = 249;
            this.label44.Text = "Simuladores";
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(5, 43);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(228, 258);
            this.dgvListado.TabIndex = 248;
            // 
            // txtEstrategia
            // 
            this.txtEstrategia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtEstrategia.Location = new System.Drawing.Point(198, 308);
            this.txtEstrategia.Name = "txtEstrategia";
            this.txtEstrategia.Size = new System.Drawing.Size(35, 26);
            this.txtEstrategia.TabIndex = 260;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label46.Location = new System.Drawing.Point(118, 315);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(83, 19);
            this.label46.TabIndex = 259;
            this.label46.Text = "Estrategia:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(6, 315);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(81, 19);
            this.label45.TabIndex = 258;
            this.label45.Text = "Simulador:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label16.Location = new System.Drawing.Point(187, 386);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 21);
            this.label16.TabIndex = 257;
            this.label16.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label13.Location = new System.Drawing.Point(188, 354);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 21);
            this.label13.TabIndex = 256;
            this.label13.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(26, 385);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 22);
            this.label8.TabIndex = 255;
            this.label8.Text = "Vender:";
            // 
            // txtPorcCompraSimulador
            // 
            this.txtPorcCompraSimulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcCompraSimulador.Location = new System.Drawing.Point(104, 346);
            this.txtPorcCompraSimulador.Name = "txtPorcCompraSimulador";
            this.txtPorcCompraSimulador.Size = new System.Drawing.Size(81, 29);
            this.txtPorcCompraSimulador.TabIndex = 252;
            this.txtPorcCompraSimulador.Click += new System.EventHandler(this.txtPorcCompraSimulador_Click);
            this.txtPorcCompraSimulador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcCompraSimulador_KeyPress);
            this.txtPorcCompraSimulador.Leave += new System.EventHandler(this.txtPorcCompraSimulador_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(8, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 254;
            this.label3.Text = "Comprar:";
            // 
            // txtIdSimulador
            // 
            this.txtIdSimulador.Enabled = false;
            this.txtIdSimulador.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtIdSimulador.Location = new System.Drawing.Point(87, 308);
            this.txtIdSimulador.Name = "txtIdSimulador";
            this.txtIdSimulador.Size = new System.Drawing.Size(29, 26);
            this.txtIdSimulador.TabIndex = 251;
            // 
            // txtPorcVentaSimulador
            // 
            this.txtPorcVentaSimulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcVentaSimulador.Location = new System.Drawing.Point(104, 378);
            this.txtPorcVentaSimulador.Name = "txtPorcVentaSimulador";
            this.txtPorcVentaSimulador.Size = new System.Drawing.Size(81, 29);
            this.txtPorcVentaSimulador.TabIndex = 253;
            this.txtPorcVentaSimulador.Click += new System.EventHandler(this.txtPorcVentaSimulador_Click);
            this.txtPorcVentaSimulador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcVentaSimulador_KeyPress);
            this.txtPorcVentaSimulador.Leave += new System.EventHandler(this.txtPorcVentaSimulador_Leave);
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImage = global::IOL.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(1253, 496);
            this.Controls.Add(this.txtImporteComisionVendidas);
            this.Controls.Add(this.txtTotalVariacionEnPorcentajesVenta);
            this.Controls.Add(this.txtTotalVariacionEnPesosVent);
            this.Controls.Add(this.txtTotalImporteVenta);
            this.Controls.Add(this.txtTotalCantidadVendidas);
            this.Controls.Add(this.txtTotalAccionesVendidas);
            this.Controls.Add(this.lblImporteComision);
            this.Controls.Add(this.txtImporteComisionCompradas);
            this.Controls.Add(this.lblVariacionEnPorcentajes);
            this.Controls.Add(this.lblVariacionEnPesos);
            this.Controls.Add(this.lblTotalImporte);
            this.Controls.Add(this.lblTotalCantidad);
            this.Controls.Add(this.lblTotalAcciones);
            this.Controls.Add(this.txtTotalVariacionEnPorcentajesCompra);
            this.Controls.Add(this.txtTotalVariacionEnPesosComp);
            this.Controls.Add(this.txtTotalImporteCompra);
            this.Controls.Add(this.txtTotalCantidadCompradas);
            this.Controls.Add(this.txtTotalAccionesCompradas);
            this.Controls.Add(this.lblTotales);
            this.Controls.Add(this.lnkEstrategia);
            this.Controls.Add(this.nudSimulador);
            this.Controls.Add(this.lblOperar);
            this.Controls.Add(this.lblAcciones);
            this.Controls.Add(this.tbcDatosRueda);
            this.Controls.Add(this.dgvAcciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Simulador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador";
            this.Load += new System.EventHandler(this.Simulador_Load);
            this.tbcDatosRueda.ResumeLayout(false);
            this.tbpDatosRueda.ResumeLayout(false);
            this.tbpDatosRueda.PerformLayout();
            this.tbpDatosSimulador.ResumeLayout(false);
            this.tbpDatosSimulador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimulador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Timer tmrActualizarToken;
        private System.Windows.Forms.Timer tmrActualizarCotizacion;
        private System.Windows.Forms.TabControl tbcDatosRueda;
        private System.Windows.Forms.TabPage tbpDatosRueda;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lblPorcVenta;
        public System.Windows.Forms.TextBox txtPorcVenta;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtPorcCompra;
        public System.Windows.Forms.Label lblPorcCompra;
        public System.Windows.Forms.TextBox txtIdRueda;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label30;
        public System.Windows.Forms.TextBox txtEstado;
        public System.Windows.Forms.TextBox txtFecha;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label29;
        public System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TabPage tbpDatosSimulador;
        private System.Windows.Forms.DataGridView dgvAcciones;
        private System.Windows.Forms.Label lblAcciones;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblPorcComisionIOL;
        public System.Windows.Forms.TextBox txtPorcComisionIOL;
        public System.Windows.Forms.Label lblOperar;
        private System.Windows.Forms.Button btnActualizarSimulador;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.TextBox txtPorcPuntaCompradora;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label label27;
        public System.Windows.Forms.TextBox txtPorcPuntaVendedora;
        private System.Windows.Forms.NumericUpDown nudSimulador;
        private System.Windows.Forms.LinkLabel lnkEstrategia;
        private System.Windows.Forms.Label lblTotales;
        private System.Windows.Forms.Button btnActualizarRueda;
        private System.Windows.Forms.Button btnCerrarRueda;
        public System.Windows.Forms.TextBox txtTotalAccionesCompradas;
        public System.Windows.Forms.TextBox txtTotalCantidadCompradas;
        public System.Windows.Forms.TextBox txtTotalImporteCompra;
        public System.Windows.Forms.TextBox txtTotalVariacionEnPesosComp;
        public System.Windows.Forms.TextBox txtTotalVariacionEnPorcentajesCompra;
        private System.Windows.Forms.Label lblTotalAcciones;
        private System.Windows.Forms.Label lblTotalCantidad;
        private System.Windows.Forms.Label lblTotalImporte;
        private System.Windows.Forms.Label lblVariacionEnPesos;
        private System.Windows.Forms.Label lblVariacionEnPorcentajes;
        private System.Windows.Forms.Label lblImporteComision;
        public System.Windows.Forms.TextBox txtImporteComisionCompradas;
        public System.Windows.Forms.TextBox txtImporteComisionVendidas;
        public System.Windows.Forms.TextBox txtTotalVariacionEnPorcentajesVenta;
        public System.Windows.Forms.TextBox txtTotalVariacionEnPesosVent;
        public System.Windows.Forms.TextBox txtTotalImporteVenta;
        public System.Windows.Forms.TextBox txtTotalCantidadVendidas;
        public System.Windows.Forms.TextBox txtTotalAccionesVendidas;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.DataGridView dgvListado;
        public System.Windows.Forms.TextBox txtEstrategia;
        public System.Windows.Forms.Label label46;
        public System.Windows.Forms.Label label45;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtPorcCompraSimulador;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtIdSimulador;
        public System.Windows.Forms.TextBox txtPorcVentaSimulador;
    }
}