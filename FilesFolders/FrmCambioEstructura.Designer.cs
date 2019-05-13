namespace FilesFolders
{
    partial class FrmCambioEstructura
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
            this.pnlCambioEsctuctura = new System.Windows.Forms.Panel();
            this.txtCodigoMunicipio = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lblEstatusEAPB = new System.Windows.Forms.Label();
            this.prgBarEAPB = new System.Windows.Forms.ProgressBar();
            this.btnProcesarEAPB = new System.Windows.Forms.Button();
            this.lblTituloEAPB = new System.Windows.Forms.Label();
            this.txtRuraCarpetaEAPB = new System.Windows.Forms.TextBox();
            this.btnRutaCarpetaEAPB = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlCambioEsctuctura.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCambioEsctuctura
            // 
            this.pnlCambioEsctuctura.Controls.Add(this.btnSalir);
            this.pnlCambioEsctuctura.Controls.Add(this.txtCodigoMunicipio);
            this.pnlCambioEsctuctura.Controls.Add(this.label26);
            this.pnlCambioEsctuctura.Controls.Add(this.lblEstatusEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.prgBarEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.btnProcesarEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.lblTituloEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.txtRuraCarpetaEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.btnRutaCarpetaEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.label10);
            this.pnlCambioEsctuctura.Location = new System.Drawing.Point(12, 8);
            this.pnlCambioEsctuctura.Name = "pnlCambioEsctuctura";
            this.pnlCambioEsctuctura.Size = new System.Drawing.Size(490, 244);
            this.pnlCambioEsctuctura.TabIndex = 16;
            // 
            // txtCodigoMunicipio
            // 
            this.txtCodigoMunicipio.Location = new System.Drawing.Point(108, 84);
            this.txtCodigoMunicipio.Name = "txtCodigoMunicipio";
            this.txtCodigoMunicipio.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoMunicipio.TabIndex = 16;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(14, 87);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 13);
            this.label26.TabIndex = 15;
            this.label26.Text = "Código Municipio";
            // 
            // lblEstatusEAPB
            // 
            this.lblEstatusEAPB.AutoSize = true;
            this.lblEstatusEAPB.Location = new System.Drawing.Point(90, 181);
            this.lblEstatusEAPB.Name = "lblEstatusEAPB";
            this.lblEstatusEAPB.Size = new System.Drawing.Size(42, 13);
            this.lblEstatusEAPB.TabIndex = 14;
            this.lblEstatusEAPB.Text = "Estatus";
            // 
            // prgBarEAPB
            // 
            this.prgBarEAPB.Location = new System.Drawing.Point(93, 155);
            this.prgBarEAPB.Name = "prgBarEAPB";
            this.prgBarEAPB.Size = new System.Drawing.Size(387, 23);
            this.prgBarEAPB.TabIndex = 13;
            // 
            // btnProcesarEAPB
            // 
            this.btnProcesarEAPB.Image = global::FilesFolders.Properties.Resources.icons8_Play32_32;
            this.btnProcesarEAPB.Location = new System.Drawing.Point(12, 155);
            this.btnProcesarEAPB.Name = "btnProcesarEAPB";
            this.btnProcesarEAPB.Size = new System.Drawing.Size(75, 23);
            this.btnProcesarEAPB.TabIndex = 12;
            this.btnProcesarEAPB.UseVisualStyleBackColor = true;
            this.btnProcesarEAPB.Click += new System.EventHandler(this.btnProcesarEAPB_Click);
            // 
            // lblTituloEAPB
            // 
            this.lblTituloEAPB.AutoSize = true;
            this.lblTituloEAPB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEAPB.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTituloEAPB.Location = new System.Drawing.Point(14, 17);
            this.lblTituloEAPB.Name = "lblTituloEAPB";
            this.lblTituloEAPB.Size = new System.Drawing.Size(299, 20);
            this.lblTituloEAPB.TabIndex = 8;
            this.lblTituloEAPB.Text = "Cambio de Estructura de RIPS IPS A EAPB";
            // 
            // txtRuraCarpetaEAPB
            // 
            this.txtRuraCarpetaEAPB.Enabled = false;
            this.txtRuraCarpetaEAPB.Location = new System.Drawing.Point(93, 117);
            this.txtRuraCarpetaEAPB.Name = "txtRuraCarpetaEAPB";
            this.txtRuraCarpetaEAPB.Size = new System.Drawing.Size(387, 20);
            this.txtRuraCarpetaEAPB.TabIndex = 10;
            // 
            // btnRutaCarpetaEAPB
            // 
            this.btnRutaCarpetaEAPB.Location = new System.Drawing.Point(12, 115);
            this.btnRutaCarpetaEAPB.Name = "btnRutaCarpetaEAPB";
            this.btnRutaCarpetaEAPB.Size = new System.Drawing.Size(75, 23);
            this.btnRutaCarpetaEAPB.TabIndex = 9;
            this.btnRutaCarpetaEAPB.Text = "Ruta";
            this.btnRutaCarpetaEAPB.UseVisualStyleBackColor = true;
            this.btnRutaCarpetaEAPB.Click += new System.EventHandler(this.btnRutaCarpetaEAPB_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(375, 26);
            this.label10.TabIndex = 11;
            this.label10.Text = "Se cambiará la estructura de los RIPS contenidos en la carpeta seleccionada.\r\nSe " +
    "cambia de estructura IPS a EABP según la resolucion 3374 de 2000";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(404, 200);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmCambioEstructura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 264);
            this.Controls.Add(this.pnlCambioEsctuctura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCambioEstructura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio Estructura";
            this.Load += new System.EventHandler(this.FrmCambioEstructura_Load);
            this.pnlCambioEsctuctura.ResumeLayout(false);
            this.pnlCambioEsctuctura.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCambioEsctuctura;
        private System.Windows.Forms.TextBox txtCodigoMunicipio;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblEstatusEAPB;
        private System.Windows.Forms.ProgressBar prgBarEAPB;
        private System.Windows.Forms.Button btnProcesarEAPB;
        private System.Windows.Forms.Label lblTituloEAPB;
        private System.Windows.Forms.TextBox txtRuraCarpetaEAPB;
        private System.Windows.Forms.Button btnRutaCarpetaEAPB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}