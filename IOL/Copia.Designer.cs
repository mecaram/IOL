namespace IOL
{
    partial class Copia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Copia));
            this.rctCarpetaDestino = new System.Windows.Forms.RichTextBox();
            this.btnSeleccionarCarpeta = new System.Windows.Forms.Button();
            this.btnRealizarCopiaDeSeguridad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rctCarpetaDestino
            // 
            this.rctCarpetaDestino.BackColor = System.Drawing.Color.Silver;
            this.rctCarpetaDestino.Enabled = false;
            this.rctCarpetaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rctCarpetaDestino.ForeColor = System.Drawing.Color.Green;
            this.rctCarpetaDestino.Location = new System.Drawing.Point(20, 72);
            this.rctCarpetaDestino.Multiline = false;
            this.rctCarpetaDestino.Name = "rctCarpetaDestino";
            this.rctCarpetaDestino.Size = new System.Drawing.Size(502, 34);
            this.rctCarpetaDestino.TabIndex = 158;
            this.rctCarpetaDestino.Text = "";
            // 
            // btnSeleccionarCarpeta
            // 
            this.btnSeleccionarCarpeta.BackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionarCarpeta.Font = new System.Drawing.Font("Georgia", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarCarpeta.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSeleccionarCarpeta.Location = new System.Drawing.Point(117, 12);
            this.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta";
            this.btnSeleccionarCarpeta.Size = new System.Drawing.Size(309, 48);
            this.btnSeleccionarCarpeta.TabIndex = 157;
            this.btnSeleccionarCarpeta.Text = "Seleccione Carpeta Destino";
            this.btnSeleccionarCarpeta.UseVisualStyleBackColor = false;
            this.btnSeleccionarCarpeta.Click += new System.EventHandler(this.btnSeleccionarCarpeta_Click);
            // 
            // btnRealizarCopiaDeSeguridad
            // 
            this.btnRealizarCopiaDeSeguridad.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizarCopiaDeSeguridad.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnRealizarCopiaDeSeguridad.Location = new System.Drawing.Point(117, 118);
            this.btnRealizarCopiaDeSeguridad.Name = "btnRealizarCopiaDeSeguridad";
            this.btnRealizarCopiaDeSeguridad.Size = new System.Drawing.Size(309, 48);
            this.btnRealizarCopiaDeSeguridad.TabIndex = 159;
            this.btnRealizarCopiaDeSeguridad.Text = "Realizar Copia de Seguridad";
            this.btnRealizarCopiaDeSeguridad.UseVisualStyleBackColor = true;
            this.btnRealizarCopiaDeSeguridad.Click += new System.EventHandler(this.btnRealizarCopiaDeSeguridad_Click);
            // 
            // Copia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(551, 188);
            this.Controls.Add(this.btnRealizarCopiaDeSeguridad);
            this.Controls.Add(this.rctCarpetaDestino);
            this.Controls.Add(this.btnSeleccionarCarpeta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Copia";
            this.Text = "Copia de Seguridad";
            this.Load += new System.EventHandler(this.Copia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rctCarpetaDestino;
        private System.Windows.Forms.Button btnSeleccionarCarpeta;
        private System.Windows.Forms.Button btnRealizarCopiaDeSeguridad;
    }
}