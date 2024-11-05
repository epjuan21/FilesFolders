namespace FilesFolders
{
    partial class FrmUnirRIPS
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnRuta = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.prgBarNE = new System.Windows.Forms.ProgressBar();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.fbdUnir = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRutaDestino = new System.Windows.Forms.Button();
            this.txtRutaDestino = new System.Windows.Forms.TextBox();
            this.fbdRutaDestino = new System.Windows.Forms.FolderBrowserDialog();
            this.txtNombreArchivos = new System.Windows.Forms.TextBox();
            this.lblNombreArchivos = new System.Windows.Forms.Label();
            this.lblCodigoHabilitacion = new System.Windows.Forms.Label();
            this.txtCodigoHabilitacion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unir Archivos de RIPS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Une cada tipo de archivo en uno solo";
            // 
            // btnRuta
            // 
            this.btnRuta.Location = new System.Drawing.Point(13, 68);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(86, 23);
            this.btnRuta.TabIndex = 3;
            this.btnRuta.Text = "Ruta";
            this.btnRuta.UseVisualStyleBackColor = true;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuta.Location = new System.Drawing.Point(108, 71);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(330, 20);
            this.txtRuta.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(105, 281);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status";
            // 
            // prgBarNE
            // 
            this.prgBarNE.Location = new System.Drawing.Point(159, 277);
            this.prgBarNE.Name = "prgBarNE";
            this.prgBarNE.Size = new System.Drawing.Size(279, 23);
            this.prgBarNE.TabIndex = 10;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 271);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(84, 23);
            this.btnIniciar.TabIndex = 9;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnRutaDestino
            // 
            this.btnRutaDestino.Location = new System.Drawing.Point(15, 112);
            this.btnRutaDestino.Name = "btnRutaDestino";
            this.btnRutaDestino.Size = new System.Drawing.Size(84, 23);
            this.btnRutaDestino.TabIndex = 12;
            this.btnRutaDestino.Text = "Ruta Destino";
            this.btnRutaDestino.UseVisualStyleBackColor = true;
            this.btnRutaDestino.Click += new System.EventHandler(this.btnRutaDestino_Click);
            // 
            // txtRutaDestino
            // 
            this.txtRutaDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRutaDestino.Location = new System.Drawing.Point(108, 115);
            this.txtRutaDestino.Name = "txtRutaDestino";
            this.txtRutaDestino.ReadOnly = true;
            this.txtRutaDestino.Size = new System.Drawing.Size(330, 20);
            this.txtRutaDestino.TabIndex = 13;
            // 
            // txtNombreArchivos
            // 
            this.txtNombreArchivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreArchivos.Location = new System.Drawing.Point(127, 155);
            this.txtNombreArchivos.Name = "txtNombreArchivos";
            this.txtNombreArchivos.Size = new System.Drawing.Size(122, 20);
            this.txtNombreArchivos.TabIndex = 14;
            // 
            // lblNombreArchivos
            // 
            this.lblNombreArchivos.AutoSize = true;
            this.lblNombreArchivos.Location = new System.Drawing.Point(21, 157);
            this.lblNombreArchivos.Name = "lblNombreArchivos";
            this.lblNombreArchivos.Size = new System.Drawing.Size(44, 13);
            this.lblNombreArchivos.TabIndex = 15;
            this.lblNombreArchivos.Text = "Nombre";
            // 
            // lblCodigoHabilitacion
            // 
            this.lblCodigoHabilitacion.AutoSize = true;
            this.lblCodigoHabilitacion.Location = new System.Drawing.Point(21, 191);
            this.lblCodigoHabilitacion.Name = "lblCodigoHabilitacion";
            this.lblCodigoHabilitacion.Size = new System.Drawing.Size(98, 13);
            this.lblCodigoHabilitacion.TabIndex = 16;
            this.lblCodigoHabilitacion.Text = "Código Habiltiación";
            // 
            // txtCodigoHabilitacion
            // 
            this.txtCodigoHabilitacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoHabilitacion.Location = new System.Drawing.Point(127, 189);
            this.txtCodigoHabilitacion.Name = "txtCodigoHabilitacion";
            this.txtCodigoHabilitacion.Size = new System.Drawing.Size(122, 20);
            this.txtCodigoHabilitacion.TabIndex = 17;
            // 
            // FrmUnirRIPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 306);
            this.Controls.Add(this.txtCodigoHabilitacion);
            this.Controls.Add(this.lblCodigoHabilitacion);
            this.Controls.Add(this.lblNombreArchivos);
            this.Controls.Add(this.txtNombreArchivos);
            this.Controls.Add(this.txtRutaDestino);
            this.Controls.Add(this.btnRutaDestino);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.prgBarNE);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmUnirRIPS";
            this.Text = "Unir RIPS";
            this.Load += new System.EventHandler(this.FrmUnirRIPS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRuta;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar prgBarNE;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.FolderBrowserDialog fbdUnir;
        private System.Windows.Forms.Button btnRutaDestino;
        private System.Windows.Forms.TextBox txtRutaDestino;
        private System.Windows.Forms.FolderBrowserDialog fbdRutaDestino;
        private System.Windows.Forms.TextBox txtNombreArchivos;
        private System.Windows.Forms.Label lblNombreArchivos;
        private System.Windows.Forms.Label lblCodigoHabilitacion;
        private System.Windows.Forms.TextBox txtCodigoHabilitacion;
    }
}