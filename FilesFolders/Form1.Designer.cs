﻿namespace FilesFolders
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carpetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rIPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatusAU = new System.Windows.Forms.Label();
            this.prgBarAU = new System.Windows.Forms.ProgressBar();
            this.btnAU = new System.Windows.Forms.Button();
            this.lblAU = new System.Windows.Forms.Label();
            this.lblStatusAT = new System.Windows.Forms.Label();
            this.prgBarAT = new System.Windows.Forms.ProgressBar();
            this.btnAT = new System.Windows.Forms.Button();
            this.lblAT = new System.Windows.Forms.Label();
            this.lblStatusDoc = new System.Windows.Forms.Label();
            this.prgBarDoc = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAP = new System.Windows.Forms.Label();
            this.lblAC = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUS = new System.Windows.Forms.Label();
            this.btnDoc = new System.Windows.Forms.Button();
            this.lblStatusUS = new System.Windows.Forms.Label();
            this.prgBarUS = new System.Windows.Forms.ProgressBar();
            this.btnUS = new System.Windows.Forms.Button();
            this.lblStatusAC = new System.Windows.Forms.Label();
            this.prgBarAC = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalAU = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.lblStatusAP = new System.Windows.Forms.Label();
            this.btnAC = new System.Windows.Forms.Button();
            this.prgBarAP = new System.Windows.Forms.ProgressBar();
            this.btnAP = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnRuta = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chkBoxLonDoc = new System.Windows.Forms.CheckBox();
            this.tltDocLong = new System.Windows.Forms.ToolTip(this.components);
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
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
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
            this.rIPSToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.rIPSToolStripMenuItem.Text = "RIPS";
            this.rIPSToolStripMenuItem.Click += new System.EventHandler(this.rIPSToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkBoxLonDoc);
            this.panel1.Controls.Add(this.lblStatusAU);
            this.panel1.Controls.Add(this.prgBarAU);
            this.panel1.Controls.Add(this.btnAU);
            this.panel1.Controls.Add(this.lblAU);
            this.panel1.Controls.Add(this.lblStatusAT);
            this.panel1.Controls.Add(this.prgBarAT);
            this.panel1.Controls.Add(this.btnAT);
            this.panel1.Controls.Add(this.lblAT);
            this.panel1.Controls.Add(this.lblStatusDoc);
            this.panel1.Controls.Add(this.prgBarDoc);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblAP);
            this.panel1.Controls.Add(this.lblAC);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblUS);
            this.panel1.Controls.Add(this.btnDoc);
            this.panel1.Controls.Add(this.lblStatusUS);
            this.panel1.Controls.Add(this.prgBarUS);
            this.panel1.Controls.Add(this.btnUS);
            this.panel1.Controls.Add(this.lblStatusAC);
            this.panel1.Controls.Add(this.prgBarAC);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblStatusAP);
            this.panel1.Controls.Add(this.btnAC);
            this.panel1.Controls.Add(this.prgBarAP);
            this.panel1.Controls.Add(this.btnAP);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Controls.Add(this.btnRuta);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 399);
            this.panel1.TabIndex = 1;
            // 
            // lblStatusAU
            // 
            this.lblStatusAU.AutoSize = true;
            this.lblStatusAU.Location = new System.Drawing.Point(433, 218);
            this.lblStatusAU.Name = "lblStatusAU";
            this.lblStatusAU.Size = new System.Drawing.Size(49, 13);
            this.lblStatusAU.TabIndex = 32;
            this.lblStatusAU.Text = "Progreso";
            // 
            // prgBarAU
            // 
            this.prgBarAU.Location = new System.Drawing.Point(96, 213);
            this.prgBarAU.Name = "prgBarAU";
            this.prgBarAU.Size = new System.Drawing.Size(331, 23);
            this.prgBarAU.TabIndex = 31;
            // 
            // btnAU
            // 
            this.btnAU.Image = global::FilesFolders.Properties.Resources.icons8_Play32_32;
            this.btnAU.Location = new System.Drawing.Point(51, 213);
            this.btnAU.Name = "btnAU";
            this.btnAU.Size = new System.Drawing.Size(36, 23);
            this.btnAU.TabIndex = 30;
            this.btnAU.UseVisualStyleBackColor = true;
            this.btnAU.Click += new System.EventHandler(this.btnAU_Click);
            // 
            // lblAU
            // 
            this.lblAU.AutoSize = true;
            this.lblAU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAU.Location = new System.Drawing.Point(15, 218);
            this.lblAU.Name = "lblAU";
            this.lblAU.Size = new System.Drawing.Size(24, 13);
            this.lblAU.TabIndex = 29;
            this.lblAU.Text = "AU";
            // 
            // lblStatusAT
            // 
            this.lblStatusAT.AutoSize = true;
            this.lblStatusAT.Location = new System.Drawing.Point(433, 189);
            this.lblStatusAT.Name = "lblStatusAT";
            this.lblStatusAT.Size = new System.Drawing.Size(49, 13);
            this.lblStatusAT.TabIndex = 28;
            this.lblStatusAT.Text = "Progreso";
            // 
            // prgBarAT
            // 
            this.prgBarAT.Location = new System.Drawing.Point(96, 184);
            this.prgBarAT.Name = "prgBarAT";
            this.prgBarAT.Size = new System.Drawing.Size(331, 23);
            this.prgBarAT.TabIndex = 27;
            // 
            // btnAT
            // 
            this.btnAT.Image = global::FilesFolders.Properties.Resources.icons8_Play32_32;
            this.btnAT.Location = new System.Drawing.Point(51, 184);
            this.btnAT.Name = "btnAT";
            this.btnAT.Size = new System.Drawing.Size(36, 23);
            this.btnAT.TabIndex = 26;
            this.btnAT.UseVisualStyleBackColor = true;
            this.btnAT.Click += new System.EventHandler(this.btnAT_Click);
            // 
            // lblAT
            // 
            this.lblAT.AutoSize = true;
            this.lblAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAT.Location = new System.Drawing.Point(15, 189);
            this.lblAT.Name = "lblAT";
            this.lblAT.Size = new System.Drawing.Size(23, 13);
            this.lblAT.TabIndex = 25;
            this.lblAT.Text = "AT";
            // 
            // lblStatusDoc
            // 
            this.lblStatusDoc.AutoSize = true;
            this.lblStatusDoc.Location = new System.Drawing.Point(433, 320);
            this.lblStatusDoc.Name = "lblStatusDoc";
            this.lblStatusDoc.Size = new System.Drawing.Size(49, 13);
            this.lblStatusDoc.TabIndex = 24;
            this.lblStatusDoc.Text = "Progreso";
            // 
            // prgBarDoc
            // 
            this.prgBarDoc.Location = new System.Drawing.Point(96, 315);
            this.prgBarDoc.Name = "prgBarDoc";
            this.prgBarDoc.Size = new System.Drawing.Size(331, 23);
            this.prgBarDoc.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkGreen;
            this.label9.Location = new System.Drawing.Point(14, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "Corregir Documentos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "DOC";
            // 
            // lblAP
            // 
            this.lblAP.AutoSize = true;
            this.lblAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAP.Location = new System.Drawing.Point(14, 160);
            this.lblAP.Name = "lblAP";
            this.lblAP.Size = new System.Drawing.Size(23, 13);
            this.lblAP.TabIndex = 20;
            this.lblAP.Text = "AP";
            // 
            // lblAC
            // 
            this.lblAC.AutoSize = true;
            this.lblAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAC.Location = new System.Drawing.Point(14, 131);
            this.lblAC.Name = "lblAC";
            this.lblAC.Size = new System.Drawing.Size(23, 13);
            this.lblAC.TabIndex = 19;
            this.lblAC.Text = "AC";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTitle.Location = new System.Drawing.Point(13, 62);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(223, 21);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.Text = "Corregir Estructura Archivos";
            // 
            // lblUS
            // 
            this.lblUS.AutoSize = true;
            this.lblUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUS.Location = new System.Drawing.Point(14, 102);
            this.lblUS.Name = "lblUS";
            this.lblUS.Size = new System.Drawing.Size(24, 13);
            this.lblUS.TabIndex = 17;
            this.lblUS.Text = "US";
            // 
            // btnDoc
            // 
            this.btnDoc.Image = global::FilesFolders.Properties.Resources.icons8_Play32_32;
            this.btnDoc.Location = new System.Drawing.Point(51, 315);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(36, 23);
            this.btnDoc.TabIndex = 16;
            this.btnDoc.UseVisualStyleBackColor = true;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // lblStatusUS
            // 
            this.lblStatusUS.AutoSize = true;
            this.lblStatusUS.Location = new System.Drawing.Point(433, 101);
            this.lblStatusUS.Name = "lblStatusUS";
            this.lblStatusUS.Size = new System.Drawing.Size(49, 13);
            this.lblStatusUS.TabIndex = 15;
            this.lblStatusUS.Text = "Progreso";
            // 
            // prgBarUS
            // 
            this.prgBarUS.Location = new System.Drawing.Point(96, 97);
            this.prgBarUS.Name = "prgBarUS";
            this.prgBarUS.Size = new System.Drawing.Size(331, 23);
            this.prgBarUS.TabIndex = 14;
            // 
            // btnUS
            // 
            this.btnUS.Image = global::FilesFolders.Properties.Resources.icons8_Play32_32;
            this.btnUS.Location = new System.Drawing.Point(51, 97);
            this.btnUS.Name = "btnUS";
            this.btnUS.Size = new System.Drawing.Size(36, 23);
            this.btnUS.TabIndex = 13;
            this.btnUS.UseVisualStyleBackColor = true;
            this.btnUS.Click += new System.EventHandler(this.btnUS_Click);
            // 
            // lblStatusAC
            // 
            this.lblStatusAC.AutoSize = true;
            this.lblStatusAC.Location = new System.Drawing.Point(433, 130);
            this.lblStatusAC.Name = "lblStatusAC";
            this.lblStatusAC.Size = new System.Drawing.Size(49, 13);
            this.lblStatusAC.TabIndex = 12;
            this.lblStatusAC.Text = "Progreso";
            // 
            // prgBarAC
            // 
            this.prgBarAC.Location = new System.Drawing.Point(96, 126);
            this.prgBarAC.Name = "prgBarAC";
            this.prgBarAC.Size = new System.Drawing.Size(331, 23);
            this.prgBarAC.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Image = global::FilesFolders.Properties.Resources.Shutdown_32px;
            this.button1.Location = new System.Drawing.Point(640, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 40);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalAU);
            this.groupBox1.Controls.Add(this.label2);
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
            this.groupBox1.Size = new System.Drawing.Size(105, 187);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total Archivos";
            // 
            // lblTotalAU
            // 
            this.lblTotalAU.AutoSize = true;
            this.lblTotalAU.Location = new System.Drawing.Point(36, 119);
            this.lblTotalAU.Name = "lblTotalAU";
            this.lblTotalAU.Size = new System.Drawing.Size(14, 13);
            this.lblTotalAU.TabIndex = 20;
            this.lblTotalAU.Text = "#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "AU:";
            // 
            // lblTotalUS
            // 
            this.lblTotalUS.AutoSize = true;
            this.lblTotalUS.Location = new System.Drawing.Point(36, 143);
            this.lblTotalUS.Name = "lblTotalUS";
            this.lblTotalUS.Size = new System.Drawing.Size(14, 13);
            this.lblTotalUS.TabIndex = 18;
            this.lblTotalUS.Text = "#";
            // 
            // lblTotalAT
            // 
            this.lblTotalAT.AutoSize = true;
            this.lblTotalAT.Location = new System.Drawing.Point(36, 95);
            this.lblTotalAT.Name = "lblTotalAT";
            this.lblTotalAT.Size = new System.Drawing.Size(14, 13);
            this.lblTotalAT.TabIndex = 17;
            this.lblTotalAT.Text = "#";
            // 
            // lblTotalAM
            // 
            this.lblTotalAM.AutoSize = true;
            this.lblTotalAM.Location = new System.Drawing.Point(36, 71);
            this.lblTotalAM.Name = "lblTotalAM";
            this.lblTotalAM.Size = new System.Drawing.Size(14, 13);
            this.lblTotalAM.TabIndex = 16;
            this.lblTotalAM.Text = "#";
            // 
            // lblTotalAP
            // 
            this.lblTotalAP.AutoSize = true;
            this.lblTotalAP.Location = new System.Drawing.Point(36, 47);
            this.lblTotalAP.Name = "lblTotalAP";
            this.lblTotalAP.Size = new System.Drawing.Size(14, 13);
            this.lblTotalAP.TabIndex = 15;
            this.lblTotalAP.Text = "#";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "AC:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "US:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "AT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "AM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "AP:";
            // 
            // lblTotalAC
            // 
            this.lblTotalAC.AutoSize = true;
            this.lblTotalAC.Location = new System.Drawing.Point(36, 23);
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
            // lblStatusAP
            // 
            this.lblStatusAP.AutoSize = true;
            this.lblStatusAP.Location = new System.Drawing.Point(433, 159);
            this.lblStatusAP.Name = "lblStatusAP";
            this.lblStatusAP.Size = new System.Drawing.Size(49, 13);
            this.lblStatusAP.TabIndex = 7;
            this.lblStatusAP.Text = "Progreso";
            // 
            // btnAC
            // 
            this.btnAC.Image = global::FilesFolders.Properties.Resources.icons8_Play32_32;
            this.btnAC.Location = new System.Drawing.Point(51, 126);
            this.btnAC.Name = "btnAC";
            this.btnAC.Size = new System.Drawing.Size(36, 23);
            this.btnAC.TabIndex = 6;
            this.btnAC.UseVisualStyleBackColor = true;
            this.btnAC.Click += new System.EventHandler(this.btnAC_Click);
            // 
            // prgBarAP
            // 
            this.prgBarAP.Location = new System.Drawing.Point(96, 155);
            this.prgBarAP.Name = "prgBarAP";
            this.prgBarAP.Size = new System.Drawing.Size(331, 23);
            this.prgBarAP.TabIndex = 5;
            // 
            // btnAP
            // 
            this.btnAP.Image = global::FilesFolders.Properties.Resources.icons8_Play32_32;
            this.btnAP.Location = new System.Drawing.Point(51, 155);
            this.btnAP.Name = "btnAP";
            this.btnAP.Size = new System.Drawing.Size(36, 23);
            this.btnAP.TabIndex = 4;
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
            // chkBoxLonDoc
            // 
            this.chkBoxLonDoc.AutoSize = true;
            this.chkBoxLonDoc.Location = new System.Drawing.Point(18, 288);
            this.chkBoxLonDoc.Name = "chkBoxLonDoc";
            this.chkBoxLonDoc.Size = new System.Drawing.Size(232, 17);
            this.chkBoxLonDoc.TabIndex = 33;
            this.chkBoxLonDoc.Text = "Incluir Documentos de Longitud Mayor a 10";
            this.tltDocLong.SetToolTip(this.chkBoxLonDoc, resources.GetString("chkBoxLonDoc.ToolTip"));
            this.chkBoxLonDoc.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label lblStatusAP;
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
        private System.Windows.Forms.Label lblStatusAC;
        private System.Windows.Forms.Label lblStatusUS;
        private System.Windows.Forms.ProgressBar prgBarUS;
        private System.Windows.Forms.Button btnUS;
        private System.Windows.Forms.Button btnDoc;
        private System.Windows.Forms.Label lblAC;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblStatusDoc;
        private System.Windows.Forms.ProgressBar prgBarDoc;
        private System.Windows.Forms.Label lblAT;
        private System.Windows.Forms.Label lblStatusAT;
        private System.Windows.Forms.ProgressBar prgBarAT;
        private System.Windows.Forms.Button btnAT;
        private System.Windows.Forms.Label lblStatusAU;
        private System.Windows.Forms.ProgressBar prgBarAU;
        private System.Windows.Forms.Button btnAU;
        private System.Windows.Forms.Label lblAU;
        private System.Windows.Forms.Label lblTotalAU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBoxLonDoc;
        private System.Windows.Forms.ToolTip tltDocLong;
    }
}

