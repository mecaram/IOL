namespace IOL
{
    partial class ListadodeRuedas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadodeRuedas));
            this.btnExportarAExcel = new System.Windows.Forms.Button();
            this.lblRuedas = new System.Windows.Forms.Label();
            this.lblSimuladores = new System.Windows.Forms.Label();
            this.dgvRuedas = new System.Windows.Forms.DataGridView();
            this.dgvSimuladores = new System.Windows.Forms.DataGridView();
            this.chk00 = new System.Windows.Forms.CheckBox();
            this.nudSimulador = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRuedas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimuladores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimulador)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportarAExcel
            // 
            this.btnExportarAExcel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnExportarAExcel.Location = new System.Drawing.Point(1116, 410);
            this.btnExportarAExcel.Name = "btnExportarAExcel";
            this.btnExportarAExcel.Size = new System.Drawing.Size(165, 34);
            this.btnExportarAExcel.TabIndex = 205;
            this.btnExportarAExcel.Text = "Exportar a Excel";
            this.btnExportarAExcel.UseVisualStyleBackColor = true;
            this.btnExportarAExcel.Click += new System.EventHandler(this.btnExportarAExcel_Click);
            // 
            // lblRuedas
            // 
            this.lblRuedas.AutoSize = true;
            this.lblRuedas.BackColor = System.Drawing.Color.SeaShell;
            this.lblRuedas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRuedas.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuedas.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRuedas.Location = new System.Drawing.Point(-3, 10);
            this.lblRuedas.Name = "lblRuedas";
            this.lblRuedas.Size = new System.Drawing.Size(85, 25);
            this.lblRuedas.TabIndex = 204;
            this.lblRuedas.Text = "Ruedas";
            // 
            // lblSimuladores
            // 
            this.lblSimuladores.AutoSize = true;
            this.lblSimuladores.BackColor = System.Drawing.Color.SeaShell;
            this.lblSimuladores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSimuladores.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimuladores.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSimuladores.Location = new System.Drawing.Point(238, 9);
            this.lblSimuladores.Name = "lblSimuladores";
            this.lblSimuladores.Size = new System.Drawing.Size(137, 25);
            this.lblSimuladores.TabIndex = 203;
            this.lblSimuladores.Text = "Simuladores";
            // 
            // dgvRuedas
            // 
            this.dgvRuedas.AllowUserToAddRows = false;
            this.dgvRuedas.AllowUserToDeleteRows = false;
            this.dgvRuedas.AllowUserToOrderColumns = true;
            this.dgvRuedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRuedas.Location = new System.Drawing.Point(-3, 37);
            this.dgvRuedas.Name = "dgvRuedas";
            this.dgvRuedas.ReadOnly = true;
            this.dgvRuedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRuedas.Size = new System.Drawing.Size(237, 365);
            this.dgvRuedas.TabIndex = 202;
            this.dgvRuedas.SelectionChanged += new System.EventHandler(this.dgvRuedas_SelectionChanged);
            // 
            // dgvSimuladores
            // 
            this.dgvSimuladores.AllowUserToAddRows = false;
            this.dgvSimuladores.AllowUserToDeleteRows = false;
            this.dgvSimuladores.AllowUserToOrderColumns = true;
            this.dgvSimuladores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimuladores.Location = new System.Drawing.Point(239, 37);
            this.dgvSimuladores.Name = "dgvSimuladores";
            this.dgvSimuladores.ReadOnly = true;
            this.dgvSimuladores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSimuladores.Size = new System.Drawing.Size(1042, 365);
            this.dgvSimuladores.TabIndex = 201;
            this.dgvSimuladores.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSimuladores_DataBindingComplete);
            // 
            // chk00
            // 
            this.chk00.AutoSize = true;
            this.chk00.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk00.Location = new System.Drawing.Point(433, 7);
            this.chk00.Name = "chk00";
            this.chk00.Size = new System.Drawing.Size(78, 26);
            this.chk00.TabIndex = 4;
            this.chk00.Text = "Todos";
            this.chk00.UseVisualStyleBackColor = true;
            this.chk00.CheckedChanged += new System.EventHandler(this.chk00_CheckedChanged);
            // 
            // nudSimulador
            // 
            this.nudSimulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSimulador.Location = new System.Drawing.Point(381, 6);
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
            this.nudSimulador.TabIndex = 207;
            this.nudSimulador.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSimulador.ValueChanged += new System.EventHandler(this.nudSimulador_ValueChanged);
            // 
            // ListadodeRuedas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImage = global::IOL.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(1284, 450);
            this.Controls.Add(this.chk00);
            this.Controls.Add(this.nudSimulador);
            this.Controls.Add(this.btnExportarAExcel);
            this.Controls.Add(this.lblRuedas);
            this.Controls.Add(this.lblSimuladores);
            this.Controls.Add(this.dgvRuedas);
            this.Controls.Add(this.dgvSimuladores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadodeRuedas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Ruedas";
            this.Load += new System.EventHandler(this.ListadodeRuedas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRuedas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimuladores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimulador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportarAExcel;
        private System.Windows.Forms.Label lblRuedas;
        private System.Windows.Forms.Label lblSimuladores;
        private System.Windows.Forms.DataGridView dgvRuedas;
        private System.Windows.Forms.DataGridView dgvSimuladores;
        private System.Windows.Forms.CheckBox chk00;
        private System.Windows.Forms.NumericUpDown nudSimulador;
    }
}