namespace FilesFolders
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carpetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rIPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalUS = new System.Windows.Forms.Label();
            this.lblTotalAT = new System.Windows.Forms.Label();
            this.lblTotalAM = new System.Windows.Forms.Label();
            this.lblTotalAP = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalAC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAC = new System.Windows.Forms.Button();
            this.prgBarAP = new System.Windows.Forms.ProgressBar();
            this.btnAP = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnRuta = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.prgBarAC = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.carpetasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(698, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.ShortcutKeyDisplayString = "A";
            this.archivoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::FilesFolders.Properties.Resources.Shutdown_48px;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // carpetasToolStripMenuItem
            // 
            this.carpetasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rIPSToolStripMenuItem});
            this.carpetasToolStripMenuItem.Name = "carpetasToolStripMenuItem";
            this.carpetasToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.carpetasToolStripMenuItem.Text = "Edición";
            // 
            // rIPSToolStripMenuItem
            // 
            this.rIPSToolStripMenuItem.Name = "rIPSToolStripMenuItem";
            this.rIPSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rIPSToolStripMenuItem.Text = "RIPS";
            this.rIPSToolStripMenuItem.Click += new System.EventHandler(this.rIPSToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.prgBarAC);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.btnAC);
            this.panel1.Controls.Add(this.prgBarAP);
            this.panel1.Controls.Add(this.btnAP);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Controls.Add(this.btnRuta);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 257);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Image = global::FilesFolders.Properties.Resources.Shutdown_32px;
            this.button1.Location = new System.Drawing.Point(640, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 40);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalUS);
            this.groupBox1.Controls.Add(this.lblTotalAT);
            this.groupBox1.Controls.Add(this.lblTotalAM);
            this.groupBox1.Controls.Add(this.lblTotalAP);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTotalAC);
            this.groupBox1.Location = new System.Drawing.Point(580, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 152);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total Archivos";
            // 
            // lblTotalUS
            // 
            this.lblTotalUS.AutoSize = true;
            this.lblTotalUS.Location = new System.Drawing.Point(37, 123);
            this.lblTotalUS.Name = "lblTotalUS";
            this.lblTotalUS.Size = new System.Drawing.Size(14, 13);
            this.lblTotalUS.TabIndex = 18;
            this.lblTotalUS.Text = "#";
            // 
            // lblTotalAT
            // 
            this.lblTotalAT.AutoSize = true;
            this.lblTotalAT.Location = new System.Drawing.Point(37, 98);
            this.lblTotalAT.Name = "lblTotalAT";
            this.lblTotalAT.Size = new System.Drawing.Size(14, 13);
            this.lblTotalAT.TabIndex = 17;
            this.lblTotalAT.Text = "#";
            // 
            // lblTotalAM
            // 
            this.lblTotalAM.AutoSize = true;
            this.lblTotalAM.Location = new System.Drawing.Point(37, 73);
            this.lblTotalAM.Name = "lblTotalAM";
            this.lblTotalAM.Size = new System.Drawing.Size(14, 13);
            this.lblTotalAM.TabIndex = 16;
            this.lblTotalAM.Text = "#";
            // 
            // lblTotalAP
            // 
            this.lblTotalAP.AutoSize = true;
            this.lblTotalAP.Location = new System.Drawing.Point(37, 48);
            this.lblTotalAP.Name = "lblTotalAP";
            this.lblTotalAP.Size = new System.Drawing.Size(14, 13);
            this.lblTotalAP.TabIndex = 15;
            this.lblTotalAP.Text = "#";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "AC:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "US:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "AT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "AM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "AP:";
            // 
            // lblTotalAC
            // 
            this.lblTotalAC.AutoSize = true;
            this.lblTotalAC.Location = new System.Drawing.Point(37, 23);
            this.lblTotalAC.Name = "lblTotalAC";
            this.lblTotalAC.Size = new System.Drawing.Size(14, 13);
            this.lblTotalAC.TabIndex = 3;
            this.lblTotalAC.Text = "#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "____________________________________________________________________";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(433, 102);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Progreso";
            // 
            // btnAC
            // 
            this.btnAC.Location = new System.Drawing.Point(12, 68);
            this.btnAC.Name = "btnAC";
            this.btnAC.Size = new System.Drawing.Size(75, 23);
            this.btnAC.TabIndex = 6;
            this.btnAC.Text = "Corregir AC";
            this.btnAC.UseVisualStyleBackColor = true;
            this.btnAC.Click += new System.EventHandler(this.btnAC_Click);
            // 
            // prgBarAP
            // 
            this.prgBarAP.Location = new System.Drawing.Point(96, 97);
            this.prgBarAP.Name = "prgBarAP";
            this.prgBarAP.Size = new System.Drawing.Size(331, 23);
            this.prgBarAP.TabIndex = 5;
            // 
            // btnAP
            // 
            this.btnAP.Location = new System.Drawing.Point(12, 97);
            this.btnAP.Name = "btnAP";
            this.btnAP.Size = new System.Drawing.Size(75, 23);
            this.btnAP.TabIndex = 4;
            this.btnAP.Text = "Corregir AP";
            this.btnAP.UseVisualStyleBackColor = true;
            this.btnAP.Click += new System.EventHandler(this.btnAP_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Enabled = false;
            this.txtRuta.Location = new System.Drawing.Point(93, 21);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(474, 20);
            this.txtRuta.TabIndex = 1;
            // 
            // btnRuta
            // 
            this.btnRuta.Location = new System.Drawing.Point(12, 19);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(75, 23);
            this.btnRuta.TabIndex = 0;
            this.btnRuta.Text = "Ruta";
            this.btnRuta.UseVisualStyleBackColor = true;
            this.btnRuta.Click += new System.EventHandler(this.button1_Click);
            // 
            // prgBarAC
            // 
            this.prgBarAC.Location = new System.Drawing.Point(96, 68);
            this.prgBarAC.Name = "prgBarAC";
            this.prgBarAC.Size = new System.Drawing.Size(331, 23);
            this.prgBarAC.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 296);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Corrección RIPS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carpetasToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnRuta;
        private System.Windows.Forms.ToolStripMenuItem rIPSToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblTotalAC;
        private System.Windows.Forms.Button btnAP;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar prgBarAP;
        private System.Windows.Forms.Button btnAC;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalAP;
        private System.Windows.Forms.Label lblTotalAM;
        private System.Windows.Forms.Label lblTotalAT;
        private System.Windows.Forms.Label lblTotalUS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar prgBarAC;
    }
}

