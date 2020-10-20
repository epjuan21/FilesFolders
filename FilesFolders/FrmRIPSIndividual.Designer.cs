namespace FilesFolders
{
    partial class FrmRIPSIndividual
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
            this.pnlRIPSIndividual = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLineasAU = new System.Windows.Forms.Label();
            this.lblLineasAT = new System.Windows.Forms.Label();
            this.lblLineasAN = new System.Windows.Forms.Label();
            this.lblLineasAM = new System.Windows.Forms.Label();
            this.lblLineasAP = new System.Windows.Forms.Label();
            this.lblLineasAH = new System.Windows.Forms.Label();
            this.lblLineasAC = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblLineasUS = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRutaIndividual = new System.Windows.Forms.TextBox();
            this.btnRutaIndividual = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlRIPSIndividual.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRIPSIndividual
            // 
            this.pnlRIPSIndividual.Controls.Add(this.btnSalir);
            this.pnlRIPSIndividual.Controls.Add(this.label14);
            this.pnlRIPSIndividual.Controls.Add(this.lblTitulo);
            this.pnlRIPSIndividual.Controls.Add(this.groupBox2);
            this.pnlRIPSIndividual.Controls.Add(this.label11);
            this.pnlRIPSIndividual.Controls.Add(this.txtRutaIndividual);
            this.pnlRIPSIndividual.Controls.Add(this.btnRutaIndividual);
            this.pnlRIPSIndividual.Location = new System.Drawing.Point(3, 2);
            this.pnlRIPSIndividual.Name = "pnlRIPSIndividual";
            this.pnlRIPSIndividual.Size = new System.Drawing.Size(618, 207);
            this.pnlRIPSIndividual.TabIndex = 13;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(526, 169);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(312, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Seleccione una Carpeta que solo contenga un paquete de RIPS";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitulo.Location = new System.Drawing.Point(11, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(402, 20);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Seleccione la ruta donde se encuentran los archivos RIPS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLineasAU);
            this.groupBox2.Controls.Add(this.lblLineasAT);
            this.groupBox2.Controls.Add(this.lblLineasAN);
            this.groupBox2.Controls.Add(this.lblLineasAM);
            this.groupBox2.Controls.Add(this.lblLineasAP);
            this.groupBox2.Controls.Add(this.lblLineasAH);
            this.groupBox2.Controls.Add(this.lblLineasAC);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblLineasUS);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(588, 69);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lineas";
            // 
            // lblLineasAU
            // 
            this.lblLineasAU.AutoSize = true;
            this.lblLineasAU.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineasAU.Location = new System.Drawing.Point(549, 33);
            this.lblLineasAU.Name = "lblLineasAU";
            this.lblLineasAU.Size = new System.Drawing.Size(16, 17);
            this.lblLineasAU.TabIndex = 18;
            this.lblLineasAU.Text = "#";
            // 
            // lblLineasAT
            // 
            this.lblLineasAT.AutoSize = true;
            this.lblLineasAT.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineasAT.Location = new System.Drawing.Point(476, 33);
            this.lblLineasAT.Name = "lblLineasAT";
            this.lblLineasAT.Size = new System.Drawing.Size(16, 17);
            this.lblLineasAT.TabIndex = 17;
            this.lblLineasAT.Text = "#";
            // 
            // lblLineasAN
            // 
            this.lblLineasAN.AutoSize = true;
            this.lblLineasAN.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineasAN.Location = new System.Drawing.Point(406, 33);
            this.lblLineasAN.Name = "lblLineasAN";
            this.lblLineasAN.Size = new System.Drawing.Size(16, 17);
            this.lblLineasAN.TabIndex = 16;
            this.lblLineasAN.Text = "#";
            // 
            // lblLineasAM
            // 
            this.lblLineasAM.AutoSize = true;
            this.lblLineasAM.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineasAM.Location = new System.Drawing.Point(332, 33);
            this.lblLineasAM.Name = "lblLineasAM";
            this.lblLineasAM.Size = new System.Drawing.Size(16, 17);
            this.lblLineasAM.TabIndex = 15;
            this.lblLineasAM.Text = "#";
            // 
            // lblLineasAP
            // 
            this.lblLineasAP.AutoSize = true;
            this.lblLineasAP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineasAP.Location = new System.Drawing.Point(255, 33);
            this.lblLineasAP.Name = "lblLineasAP";
            this.lblLineasAP.Size = new System.Drawing.Size(16, 17);
            this.lblLineasAP.TabIndex = 14;
            this.lblLineasAP.Text = "#";
            // 
            // lblLineasAH
            // 
            this.lblLineasAH.AutoSize = true;
            this.lblLineasAH.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineasAH.Location = new System.Drawing.Point(183, 33);
            this.lblLineasAH.Name = "lblLineasAH";
            this.lblLineasAH.Size = new System.Drawing.Size(16, 17);
            this.lblLineasAH.TabIndex = 13;
            this.lblLineasAH.Text = "#";
            // 
            // lblLineasAC
            // 
            this.lblLineasAC.AutoSize = true;
            this.lblLineasAC.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineasAC.Location = new System.Drawing.Point(110, 34);
            this.lblLineasAC.Name = "lblLineasAC";
            this.lblLineasAC.Size = new System.Drawing.Size(16, 17);
            this.lblLineasAC.TabIndex = 12;
            this.lblLineasAC.Text = "#";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label21.Location = new System.Drawing.Point(514, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 19);
            this.label21.TabIndex = 11;
            this.label21.Text = "AU";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label20.Location = new System.Drawing.Point(444, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 19);
            this.label20.TabIndex = 10;
            this.label20.Text = "AT";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label19.Location = new System.Drawing.Point(221, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 19);
            this.label19.TabIndex = 9;
            this.label19.Text = "AP";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label18.Location = new System.Drawing.Point(370, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 19);
            this.label18.TabIndex = 8;
            this.label18.Text = "AN";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label17.Location = new System.Drawing.Point(293, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 19);
            this.label17.TabIndex = 7;
            this.label17.Text = "AM";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label16.Location = new System.Drawing.Point(148, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 19);
            this.label16.TabIndex = 6;
            this.label16.Text = "AH";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label15.Location = new System.Drawing.Point(77, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 19);
            this.label15.TabIndex = 5;
            this.label15.Text = "AC";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLineasUS
            // 
            this.lblLineasUS.AutoSize = true;
            this.lblLineasUS.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineasUS.Location = new System.Drawing.Point(32, 34);
            this.lblLineasUS.Name = "lblLineasUS";
            this.lblLineasUS.Size = new System.Drawing.Size(16, 17);
            this.lblLineasUS.TabIndex = 4;
            this.lblLineasUS.Text = "#";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label12.Location = new System.Drawing.Point(6, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 19);
            this.label12.TabIndex = 3;
            this.label12.Text = "US";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Lineas Archivos";
            // 
            // txtRutaIndividual
            // 
            this.txtRutaIndividual.Location = new System.Drawing.Point(93, 65);
            this.txtRutaIndividual.Name = "txtRutaIndividual";
            this.txtRutaIndividual.Size = new System.Drawing.Size(508, 20);
            this.txtRutaIndividual.TabIndex = 1;
            // 
            // btnRutaIndividual
            // 
            this.btnRutaIndividual.Location = new System.Drawing.Point(12, 63);
            this.btnRutaIndividual.Name = "btnRutaIndividual";
            this.btnRutaIndividual.Size = new System.Drawing.Size(75, 23);
            this.btnRutaIndividual.TabIndex = 0;
            this.btnRutaIndividual.Text = "Ruta";
            this.btnRutaIndividual.UseVisualStyleBackColor = true;
            this.btnRutaIndividual.Click += new System.EventHandler(this.BtnRutaIndividual_Click);
            // 
            // FrmRIPSIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 221);
            this.Controls.Add(this.pnlRIPSIndividual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmRIPSIndividual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RIPS Individual";
            this.pnlRIPSIndividual.ResumeLayout(false);
            this.pnlRIPSIndividual.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRIPSIndividual;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLineasAU;
        private System.Windows.Forms.Label lblLineasAT;
        private System.Windows.Forms.Label lblLineasAN;
        private System.Windows.Forms.Label lblLineasAM;
        private System.Windows.Forms.Label lblLineasAP;
        private System.Windows.Forms.Label lblLineasAH;
        private System.Windows.Forms.Label lblLineasAC;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblLineasUS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRutaIndividual;
        private System.Windows.Forms.Button btnRutaIndividual;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSalir;
    }
}