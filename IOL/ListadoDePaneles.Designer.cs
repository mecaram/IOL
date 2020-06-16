namespace IOL
{
    partial class ListadoDePaneles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoDePaneles));
            this.dgvPaneles = new System.Windows.Forms.DataGridView();
            this.dgvRuedas = new System.Windows.Forms.DataGridView();
            this.lblPanel = new System.Windows.Forms.Label();
            this.lblRuedas = new System.Windows.Forms.Label();
            this.btnExportarAExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaneles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRuedas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPaneles
            // 
            this.dgvPaneles.AllowUserToAddRows = false;
            this.dgvPaneles.AllowUserToDeleteRows = false;
            this.dgvPaneles.AllowUserToOrderColumns = true;
            this.dgvPaneles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaneles.Location = new System.Drawing.Point(270, 37);
            this.dgvPaneles.Name = "dgvPaneles";
            this.dgvPaneles.ReadOnly = true;
            this.dgvPaneles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaneles.Size = new System.Drawing.Size(673, 365);
            this.dgvPaneles.TabIndex = 196;
            this.dgvPaneles.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPaneles_DataBindingComplete);
            // 
            // dgvRuedas
            // 
            this.dgvRuedas.AllowUserToAddRows = false;
            this.dgvRuedas.AllowUserToDeleteRows = false;
            this.dgvRuedas.AllowUserToOrderColumns = true;
            this.dgvRuedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRuedas.Location = new System.Drawing.Point(10, 37);
            this.dgvRuedas.Name = "dgvRuedas";
            this.dgvRuedas.ReadOnly = true;
            this.dgvRuedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRuedas.Size = new System.Drawing.Size(253, 365);
            this.dgvRuedas.TabIndex = 197;
            this.dgvRuedas.SelectionChanged += new System.EventHandler(this.dgvRuedas_SelectionChanged);
            // 
            // lblPanel
            // 
            this.lblPanel.AutoSize = true;
            this.lblPanel.BackColor = System.Drawing.Color.SeaShell;
            this.lblPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPanel.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPanel.Location = new System.Drawing.Point(270, 9);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(163, 25);
            this.lblPanel.TabIndex = 198;
            this.lblPanel.Text = "Panel Principal";
            // 
            // lblRuedas
            // 
            this.lblRuedas.AutoSize = true;
            this.lblRuedas.BackColor = System.Drawing.Color.SeaShell;
            this.lblRuedas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRuedas.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuedas.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRuedas.Location = new System.Drawing.Point(10, 10);
            this.lblRuedas.Name = "lblRuedas";
            this.lblRuedas.Size = new System.Drawing.Size(85, 25);
            this.lblRuedas.TabIndex = 199;
            this.lblRuedas.Text = "Ruedas";
            // 
            // btnExportarAExcel
            // 
            this.btnExportarAExcel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnExportarAExcel.Location = new System.Drawing.Point(778, 408);
            this.btnExportarAExcel.Name = "btnExportarAExcel";
            this.btnExportarAExcel.Size = new System.Drawing.Size(165, 34);
            this.btnExportarAExcel.TabIndex = 200;
            this.btnExportarAExcel.Text = "Exportar a Excel";
            this.btnExportarAExcel.UseVisualStyleBackColor = true;
            this.btnExportarAExcel.Click += new System.EventHandler(this.btnExportarAExcel_Click);
            // 
            // ListadoDePaneles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImage = global::IOL.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(952, 450);
            this.Controls.Add(this.btnExportarAExcel);
            this.Controls.Add(this.lblRuedas);
            this.Controls.Add(this.lblPanel);
            this.Controls.Add(this.dgvRuedas);
            this.Controls.Add(this.dgvPaneles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoDePaneles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Paneles";
            this.Load += new System.EventHandler(this.ListadoDePaneles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaneles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRuedas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPaneles;
        private System.Windows.Forms.DataGridView dgvRuedas;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.Label lblRuedas;
        private System.Windows.Forms.Button btnExportarAExcel;
    }
}