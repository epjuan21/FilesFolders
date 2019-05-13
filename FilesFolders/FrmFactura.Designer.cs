namespace FilesFolders
{
    partial class FrmFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFactura));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRuta = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnNumFac = new System.Windows.Forms.Button();
            this.prgBarNumFac = new System.Windows.Forms.ProgressBar();
            this.lblStatusNumFac = new System.Windows.Forms.Label();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.txtNumFac = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Establecer Número de Factura Consolidada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Se establece el mismo número de factura consolidada en todos los archivos RIPS";
            // 
            // btnRuta
            // 
            this.btnRuta.Location = new System.Drawing.Point(16, 62);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(75, 23);
            this.btnRuta.TabIndex = 2;
            this.btnRuta.Text = "Ruta";
            this.btnRuta.UseVisualStyleBackColor = true;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(97, 64);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(331, 20);
            this.txtRuta.TabIndex = 3;
            // 
            // btnNumFac
            // 
            this.btnNumFac.Image = ((System.Drawing.Image)(resources.GetObject("btnNumFac.Image")));
            this.btnNumFac.Location = new System.Drawing.Point(15, 132);
            this.btnNumFac.Name = "btnNumFac";
            this.btnNumFac.Size = new System.Drawing.Size(76, 23);
            this.btnNumFac.TabIndex = 18;
            this.btnNumFac.UseVisualStyleBackColor = true;
            this.btnNumFac.Click += new System.EventHandler(this.btnNumFac_Click);
            // 
            // prgBarNumFac
            // 
            this.prgBarNumFac.Location = new System.Drawing.Point(97, 132);
            this.prgBarNumFac.Name = "prgBarNumFac";
            this.prgBarNumFac.Size = new System.Drawing.Size(331, 23);
            this.prgBarNumFac.TabIndex = 19;
            // 
            // lblStatusNumFac
            // 
            this.lblStatusNumFac.AutoSize = true;
            this.lblStatusNumFac.Location = new System.Drawing.Point(94, 168);
            this.lblStatusNumFac.Name = "lblStatusNumFac";
            this.lblStatusNumFac.Size = new System.Drawing.Size(49, 13);
            this.lblStatusNumFac.TabIndex = 20;
            this.lblStatusNumFac.Text = "Progreso";
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Location = new System.Drawing.Point(8, 101);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(83, 13);
            this.lblNumeroFactura.TabIndex = 21;
            this.lblNumeroFactura.Text = "Número Factura";
            // 
            // txtNumFac
            // 
            this.txtNumFac.Location = new System.Drawing.Point(97, 98);
            this.txtNumFac.Name = "txtNumFac";
            this.txtNumFac.Size = new System.Drawing.Size(100, 20);
            this.txtNumFac.TabIndex = 22;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(353, 183);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 218);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtNumFac);
            this.Controls.Add(this.lblNumeroFactura);
            this.Controls.Add(this.lblStatusNumFac);
            this.Controls.Add(this.prgBarNumFac);
            this.Controls.Add(this.btnNumFac);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura Consolidada";
            this.Load += new System.EventHandler(this.FrmFactura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRuta;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnNumFac;
        private System.Windows.Forms.ProgressBar prgBarNumFac;
        private System.Windows.Forms.Label lblStatusNumFac;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.TextBox txtNumFac;
        private System.Windows.Forms.Button btnSalir;
    }
}