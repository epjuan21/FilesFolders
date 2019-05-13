namespace FilesFolders
{
    partial class FrmNuevaEPS
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRuta = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.fbdNueva = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.prgBarNE = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adaptar Estructura de RIPS para Nueva EPS";
            // 
            // btnRuta
            // 
            this.btnRuta.Location = new System.Drawing.Point(16, 62);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(75, 23);
            this.btnRuta.TabIndex = 1;
            this.btnRuta.Text = "Ruta";
            this.btnRuta.UseVisualStyleBackColor = true;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(97, 64);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(331, 20);
            this.txtRuta.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(352, 220);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(16, 138);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Location = new System.Drawing.Point(16, 101);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(75, 20);
            this.txtNombreArchivo.TabIndex = 5;
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(94, 104);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(82, 13);
            this.lblNombreArchivo.TabIndex = 6;
            this.lblNombreArchivo.Text = "Nombre archivo";
            // 
            // prgBarNE
            // 
            this.prgBarNE.Location = new System.Drawing.Point(97, 138);
            this.prgBarNE.Name = "prgBarNE";
            this.prgBarNE.Size = new System.Drawing.Size(330, 23);
            this.prgBarNE.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(390, 177);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            // 
            // FrmNuevaEPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 261);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.prgBarNE);
            this.Controls.Add(this.lblNombreArchivo);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNuevaEPS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevaEPS";
            this.Load += new System.EventHandler(this.FrmNuevaEPS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRuta;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.FolderBrowserDialog fbdNueva;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtNombreArchivo;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.ProgressBar prgBarNE;
        private System.Windows.Forms.Label lblStatus;
    }
}