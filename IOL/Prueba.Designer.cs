namespace IOL
{
    partial class Prueba
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prueba));
            this.btnObtenerToken = new System.Windows.Forms.Button();
            this.btnRefrescarToken = new System.Windows.Forms.Button();
            this.btnPanel = new System.Windows.Forms.Button();
            this.btnObtenerCotizacion = new System.Windows.Forms.Button();
            this.btnObtenerDatosTitulo = new System.Windows.Forms.Button();
            this.btnObtenerSerieHistorica = new System.Windows.Forms.Button();
            this.btnGuardarCompra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnObtenerToken
            // 
            this.btnObtenerToken.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtenerToken.Location = new System.Drawing.Point(-4, 10);
            this.btnObtenerToken.Name = "btnObtenerToken";
            this.btnObtenerToken.Size = new System.Drawing.Size(133, 49);
            this.btnObtenerToken.TabIndex = 0;
            this.btnObtenerToken.Text = "Obtener Token";
            this.btnObtenerToken.UseVisualStyleBackColor = true;
            this.btnObtenerToken.Click += new System.EventHandler(this.btnObtenerToken_Click);
            // 
            // btnRefrescarToken
            // 
            this.btnRefrescarToken.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescarToken.Location = new System.Drawing.Point(132, 10);
            this.btnRefrescarToken.Name = "btnRefrescarToken";
            this.btnRefrescarToken.Size = new System.Drawing.Size(133, 49);
            this.btnRefrescarToken.TabIndex = 1;
            this.btnRefrescarToken.Text = "Refrescar Token";
            this.btnRefrescarToken.UseVisualStyleBackColor = true;
            this.btnRefrescarToken.Click += new System.EventHandler(this.btnRefrescarToken_Click);
            // 
            // btnPanel
            // 
            this.btnPanel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanel.Location = new System.Drawing.Point(268, 10);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(133, 49);
            this.btnPanel.TabIndex = 2;
            this.btnPanel.Text = "Panel";
            this.btnPanel.UseVisualStyleBackColor = true;
            this.btnPanel.Click += new System.EventHandler(this.btnPanel_Click);
            // 
            // btnObtenerCotizacion
            // 
            this.btnObtenerCotizacion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtenerCotizacion.Location = new System.Drawing.Point(407, 10);
            this.btnObtenerCotizacion.Name = "btnObtenerCotizacion";
            this.btnObtenerCotizacion.Size = new System.Drawing.Size(133, 49);
            this.btnObtenerCotizacion.TabIndex = 3;
            this.btnObtenerCotizacion.Text = "Obtener Cotizacion Aluar";
            this.btnObtenerCotizacion.UseVisualStyleBackColor = true;
            this.btnObtenerCotizacion.Click += new System.EventHandler(this.btnObtenerCotizacion_Click);
            // 
            // btnObtenerDatosTitulo
            // 
            this.btnObtenerDatosTitulo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtenerDatosTitulo.Location = new System.Drawing.Point(546, 10);
            this.btnObtenerDatosTitulo.Name = "btnObtenerDatosTitulo";
            this.btnObtenerDatosTitulo.Size = new System.Drawing.Size(133, 49);
            this.btnObtenerDatosTitulo.TabIndex = 4;
            this.btnObtenerDatosTitulo.Text = "Obtener Datos Aluar";
            this.btnObtenerDatosTitulo.UseVisualStyleBackColor = true;
            this.btnObtenerDatosTitulo.Click += new System.EventHandler(this.btnObtenerDatosTitulo_Click);
            // 
            // btnObtenerSerieHistorica
            // 
            this.btnObtenerSerieHistorica.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtenerSerieHistorica.Location = new System.Drawing.Point(685, 10);
            this.btnObtenerSerieHistorica.Name = "btnObtenerSerieHistorica";
            this.btnObtenerSerieHistorica.Size = new System.Drawing.Size(133, 49);
            this.btnObtenerSerieHistorica.TabIndex = 5;
            this.btnObtenerSerieHistorica.Text = "Obtener Serie Historica Aluar";
            this.btnObtenerSerieHistorica.UseVisualStyleBackColor = true;
            this.btnObtenerSerieHistorica.Click += new System.EventHandler(this.btnObtenerSerieHistorica_Click);
            // 
            // btnGuardarCompra
            // 
            this.btnGuardarCompra.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCompra.Location = new System.Drawing.Point(824, 10);
            this.btnGuardarCompra.Name = "btnGuardarCompra";
            this.btnGuardarCompra.Size = new System.Drawing.Size(133, 49);
            this.btnGuardarCompra.TabIndex = 6;
            this.btnGuardarCompra.Text = "Guardar Compra";
            this.btnGuardarCompra.UseVisualStyleBackColor = true;
            this.btnGuardarCompra.Click += new System.EventHandler(this.btnGuardarCompra_Click);
            // 
            // Prueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImage = global::IOL.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(958, 69);
            this.Controls.Add(this.btnGuardarCompra);
            this.Controls.Add(this.btnObtenerSerieHistorica);
            this.Controls.Add(this.btnObtenerDatosTitulo);
            this.Controls.Add(this.btnObtenerCotizacion);
            this.Controls.Add(this.btnPanel);
            this.Controls.Add(this.btnRefrescarToken);
            this.Controls.Add(this.btnObtenerToken);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Prueba";
            this.Text = "Formulario de Prueba";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnObtenerToken;
        private System.Windows.Forms.Button btnRefrescarToken;
        private System.Windows.Forms.Button btnPanel;
        private System.Windows.Forms.Button btnObtenerCotizacion;
        private System.Windows.Forms.Button btnObtenerDatosTitulo;
        private System.Windows.Forms.Button btnObtenerSerieHistorica;
        private System.Windows.Forms.Button btnGuardarCompra;
    }
}

