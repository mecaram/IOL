namespace IOL
{
    partial class Menuppal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menuppal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.sslFechaActual = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tbcMenuppal = new System.Windows.Forms.TabControl();
            this.tbpArchivos = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbCuentas = new System.Windows.Forms.ToolStripButton();
            this.tsbAcciones = new System.Windows.Forms.ToolStripButton();
            this.tsbFeriados = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.tbpProcesoDiario = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbRuedas = new System.Windows.Forms.ToolStripButton();
            this.tsbSimulador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tbpConsultaseInformes = new System.Windows.Forms.TabPage();
            this.tspConsultasEInformes = new System.Windows.Forms.ToolStrip();
            this.tsbInformeFinal = new System.Windows.Forms.ToolStripButton();
            this.tsbConsultaDeRuedas = new System.Windows.Forms.ToolStripButton();
            this.tsbConsultaDePaneles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbpMantenimiento = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAcercaDe = new System.Windows.Forms.ToolStripButton();
            this.tsbCopiaDeSeguridad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tbcMenuppal.SuspendLayout();
            this.tbpArchivos.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tbpProcesoDiario.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tbpConsultaseInformes.SuspendLayout();
            this.tspConsultasEInformes.SuspendLayout();
            this.tbpMantenimiento.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1211, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(66, 20);
            this.windowsMenu.Text = "&Ventanas";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.newWindowToolStripMenuItem.Text = "&Nueva ventana";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascada";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileVerticalToolStripMenuItem.Text = "Mosaico &vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Mosaico &horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.closeAllToolStripMenuItem.Text = "C&errar todo";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Organizar iconos";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslFechaActual});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1211, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // sslFechaActual
            // 
            this.sslFechaActual.Name = "sslFechaActual";
            this.sslFechaActual.Size = new System.Drawing.Size(81, 17);
            this.sslFechaActual.Text = "Fecha Actual: ";
            // 
            // tbcMenuppal
            // 
            this.tbcMenuppal.Controls.Add(this.tbpArchivos);
            this.tbcMenuppal.Controls.Add(this.tbpProcesoDiario);
            this.tbcMenuppal.Controls.Add(this.tbpConsultaseInformes);
            this.tbcMenuppal.Controls.Add(this.tbpMantenimiento);
            this.tbcMenuppal.Location = new System.Drawing.Point(0, 27);
            this.tbcMenuppal.Name = "tbcMenuppal";
            this.tbcMenuppal.SelectedIndex = 0;
            this.tbcMenuppal.Size = new System.Drawing.Size(1199, 96);
            this.tbcMenuppal.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tbcMenuppal.TabIndex = 4;
            // 
            // tbpArchivos
            // 
            this.tbpArchivos.Controls.Add(this.toolStrip);
            this.tbpArchivos.Controls.Add(this.lblEmpresa);
            this.tbpArchivos.Location = new System.Drawing.Point(4, 22);
            this.tbpArchivos.Name = "tbpArchivos";
            this.tbpArchivos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpArchivos.Size = new System.Drawing.Size(1191, 70);
            this.tbpArchivos.TabIndex = 0;
            this.tbpArchivos.Text = "Archivos";
            this.tbpArchivos.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.Linen;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCuentas,
            this.tsbAcciones,
            this.tsbFeriados,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(3, 3);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1185, 82);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "ToolStrip";
            // 
            // tsbCuentas
            // 
            this.tsbCuentas.AutoSize = false;
            this.tsbCuentas.Image = ((System.Drawing.Image)(resources.GetObject("tsbCuentas.Image")));
            this.tsbCuentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCuentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCuentas.Name = "tsbCuentas";
            this.tsbCuentas.Size = new System.Drawing.Size(80, 67);
            this.tsbCuentas.Text = "Cuentas";
            this.tsbCuentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCuentas.Click += new System.EventHandler(this.tsbCuentas_Click);
            // 
            // tsbAcciones
            // 
            this.tsbAcciones.AutoSize = false;
            this.tsbAcciones.Image = ((System.Drawing.Image)(resources.GetObject("tsbAcciones.Image")));
            this.tsbAcciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAcciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAcciones.Name = "tsbAcciones";
            this.tsbAcciones.Size = new System.Drawing.Size(80, 60);
            this.tsbAcciones.Text = "Acciones";
            this.tsbAcciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAcciones.Click += new System.EventHandler(this.tsbAcciones_Click);
            // 
            // tsbFeriados
            // 
            this.tsbFeriados.AutoSize = false;
            this.tsbFeriados.Image = ((System.Drawing.Image)(resources.GetObject("tsbFeriados.Image")));
            this.tsbFeriados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFeriados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFeriados.Name = "tsbFeriados";
            this.tsbFeriados.Size = new System.Drawing.Size(80, 60);
            this.tsbFeriados.Text = "Feriados";
            this.tsbFeriados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFeriados.Click += new System.EventHandler(this.tsbFeriados_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 82);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEmpresa.Font = new System.Drawing.Font("Times New Roman", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(582, 250);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(134, 35);
            this.lblEmpresa.TabIndex = 101;
            this.lblEmpresa.Text = "Empresa:";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbpProcesoDiario
            // 
            this.tbpProcesoDiario.Controls.Add(this.toolStrip2);
            this.tbpProcesoDiario.Location = new System.Drawing.Point(4, 22);
            this.tbpProcesoDiario.Name = "tbpProcesoDiario";
            this.tbpProcesoDiario.Size = new System.Drawing.Size(1191, 70);
            this.tbpProcesoDiario.TabIndex = 5;
            this.tbpProcesoDiario.Text = "Proceso Diario";
            this.tbpProcesoDiario.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Linen;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRuedas,
            this.tsbSimulador,
            this.toolStripSeparator10});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1191, 70);
            this.toolStrip2.Stretch = true;
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "ToolStrip";
            // 
            // tsbRuedas
            // 
            this.tsbRuedas.AutoSize = false;
            this.tsbRuedas.Enabled = false;
            this.tsbRuedas.Image = ((System.Drawing.Image)(resources.GetObject("tsbRuedas.Image")));
            this.tsbRuedas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRuedas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRuedas.Name = "tsbRuedas";
            this.tsbRuedas.Size = new System.Drawing.Size(80, 60);
            this.tsbRuedas.Text = "Ruedas";
            this.tsbRuedas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRuedas.Visible = false;
            this.tsbRuedas.Click += new System.EventHandler(this.tsbRuedas_Click);
            // 
            // tsbSimulador
            // 
            this.tsbSimulador.Image = ((System.Drawing.Image)(resources.GetObject("tsbSimulador.Image")));
            this.tsbSimulador.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSimulador.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbSimulador.Name = "tsbSimulador";
            this.tsbSimulador.Size = new System.Drawing.Size(65, 67);
            this.tsbSimulador.Text = "Simulador";
            this.tsbSimulador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSimulador.Click += new System.EventHandler(this.tsbSimulador_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 70);
            // 
            // tbpConsultaseInformes
            // 
            this.tbpConsultaseInformes.Controls.Add(this.tspConsultasEInformes);
            this.tbpConsultaseInformes.Location = new System.Drawing.Point(4, 22);
            this.tbpConsultaseInformes.Name = "tbpConsultaseInformes";
            this.tbpConsultaseInformes.Size = new System.Drawing.Size(1191, 70);
            this.tbpConsultaseInformes.TabIndex = 3;
            this.tbpConsultaseInformes.Text = "Consultas e Informes";
            this.tbpConsultaseInformes.UseVisualStyleBackColor = true;
            // 
            // tspConsultasEInformes
            // 
            this.tspConsultasEInformes.AutoSize = false;
            this.tspConsultasEInformes.BackColor = System.Drawing.Color.Linen;
            this.tspConsultasEInformes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbInformeFinal,
            this.tsbConsultaDeRuedas,
            this.tsbConsultaDePaneles,
            this.toolStripSeparator2});
            this.tspConsultasEInformes.Location = new System.Drawing.Point(0, 0);
            this.tspConsultasEInformes.Name = "tspConsultasEInformes";
            this.tspConsultasEInformes.Size = new System.Drawing.Size(1191, 72);
            this.tspConsultasEInformes.Stretch = true;
            this.tspConsultasEInformes.TabIndex = 4;
            this.tspConsultasEInformes.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tspConsultasEInformes_ItemClicked);
            // 
            // tsbInformeFinal
            // 
            this.tsbInformeFinal.Image = ((System.Drawing.Image)(resources.GetObject("tsbInformeFinal.Image")));
            this.tsbInformeFinal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbInformeFinal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInformeFinal.Name = "tsbInformeFinal";
            this.tsbInformeFinal.Size = new System.Drawing.Size(81, 69);
            this.tsbInformeFinal.Text = "Informe Final";
            this.tsbInformeFinal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbInformeFinal.Click += new System.EventHandler(this.tsbInformeFinal_Click);
            // 
            // tsbConsultaDeRuedas
            // 
            this.tsbConsultaDeRuedas.Image = ((System.Drawing.Image)(resources.GetObject("tsbConsultaDeRuedas.Image")));
            this.tsbConsultaDeRuedas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbConsultaDeRuedas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConsultaDeRuedas.Name = "tsbConsultaDeRuedas";
            this.tsbConsultaDeRuedas.Size = new System.Drawing.Size(115, 69);
            this.tsbConsultaDeRuedas.Text = "Consulta de Ruedas";
            this.tsbConsultaDeRuedas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbConsultaDeRuedas.Click += new System.EventHandler(this.tsbConsultaDeRuedas_Click);
            // 
            // tsbConsultaDePaneles
            // 
            this.tsbConsultaDePaneles.Image = ((System.Drawing.Image)(resources.GetObject("tsbConsultaDePaneles.Image")));
            this.tsbConsultaDePaneles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbConsultaDePaneles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConsultaDePaneles.Name = "tsbConsultaDePaneles";
            this.tsbConsultaDePaneles.Size = new System.Drawing.Size(117, 69);
            this.tsbConsultaDePaneles.Text = "Consulta de Paneles";
            this.tsbConsultaDePaneles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbConsultaDePaneles.Click += new System.EventHandler(this.tsbConsultaDePaneles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 72);
            // 
            // tbpMantenimiento
            // 
            this.tbpMantenimiento.Controls.Add(this.toolStrip1);
            this.tbpMantenimiento.Location = new System.Drawing.Point(4, 22);
            this.tbpMantenimiento.Name = "tbpMantenimiento";
            this.tbpMantenimiento.Size = new System.Drawing.Size(1191, 70);
            this.tbpMantenimiento.TabIndex = 4;
            this.tbpMantenimiento.Text = "Mantenimiento";
            this.tbpMantenimiento.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Linen;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAcercaDe,
            this.tsbCopiaDeSeguridad,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1191, 74);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "ToolStrip";
            // 
            // tsbAcercaDe
            // 
            this.tsbAcercaDe.AutoSize = false;
            this.tsbAcercaDe.Image = ((System.Drawing.Image)(resources.GetObject("tsbAcercaDe.Image")));
            this.tsbAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAcercaDe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAcercaDe.Name = "tsbAcercaDe";
            this.tsbAcercaDe.Size = new System.Drawing.Size(70, 60);
            this.tsbAcercaDe.Text = "Acerca de...";
            this.tsbAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAcercaDe.Click += new System.EventHandler(this.tsbAcercaDe_Click);
            // 
            // tsbCopiaDeSeguridad
            // 
            this.tsbCopiaDeSeguridad.AutoSize = false;
            this.tsbCopiaDeSeguridad.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopiaDeSeguridad.Image")));
            this.tsbCopiaDeSeguridad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCopiaDeSeguridad.Name = "tsbCopiaDeSeguridad";
            this.tsbCopiaDeSeguridad.Size = new System.Drawing.Size(120, 60);
            this.tsbCopiaDeSeguridad.Text = "Copia de Seguridad";
            this.tsbCopiaDeSeguridad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCopiaDeSeguridad.Click += new System.EventHandler(this.tsbCopiaDeSeguridad_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 74);
            // 
            // Menuppal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 453);
            this.Controls.Add(this.tbcMenuppal);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Menuppal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Trading Intradiario - InvertirOnline";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menuppal_FormClosing);
            this.Load += new System.EventHandler(this.Menuppal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tbcMenuppal.ResumeLayout(false);
            this.tbpArchivos.ResumeLayout(false);
            this.tbpArchivos.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tbpProcesoDiario.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tbpConsultaseInformes.ResumeLayout(false);
            this.tspConsultasEInformes.ResumeLayout(false);
            this.tspConsultasEInformes.PerformLayout();
            this.tbpMantenimiento.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel sslFechaActual;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabControl tbcMenuppal;
        private System.Windows.Forms.TabPage tbpArchivos;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TabPage tbpConsultaseInformes;
        private System.Windows.Forms.TabPage tbpMantenimiento;
        private System.Windows.Forms.TabPage tbpProcesoDiario;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbSimulador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAcercaDe;
        private System.Windows.Forms.ToolStripButton tsbCopiaDeSeguridad;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbCuentas;
        private System.Windows.Forms.ToolStripButton tsbAcciones;
        private System.Windows.Forms.ToolStripButton tsbFeriados;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRuedas;
        private System.Windows.Forms.ToolStrip tspConsultasEInformes;
        private System.Windows.Forms.ToolStripButton tsbConsultaDeRuedas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbConsultaDePaneles;
        private System.Windows.Forms.ToolStripButton tsbInformeFinal;
    }
}



