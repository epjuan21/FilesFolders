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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carpetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rIPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRIPS = new System.Windows.Forms.Panel();
            this.chkBoxLonDoc = new System.Windows.Forms.CheckBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tltDocLong = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEntidades = new System.Windows.Forms.Panel();
            this.btnBorrarEntidad = new System.Windows.Forms.Button();
            this.txtIdEntidad = new System.Windows.Forms.TextBox();
            this.lblIdEntidad = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.cbRegimenEntidad = new System.Windows.Forms.ComboBox();
            this.txtCodigoEntidad = new System.Windows.Forms.TextBox();
            this.txtNombreEntidad = new System.Windows.Forms.TextBox();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Regimen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.pnlRIPS.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlEntidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.carpetasToolStripMenuItem,
            this.parametrosToolStripMenuItem});
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
            // parametrosToolStripMenuItem
            // 
            this.parametrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entidadesToolStripMenuItem});
            this.parametrosToolStripMenuItem.Name = "parametrosToolStripMenuItem";
            this.parametrosToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.parametrosToolStripMenuItem.Text = "Parametros";
            // 
            // entidadesToolStripMenuItem
            // 
            this.entidadesToolStripMenuItem.Name = "entidadesToolStripMenuItem";
            this.entidadesToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.entidadesToolStripMenuItem.Text = "Entidades";
            this.entidadesToolStripMenuItem.Click += new System.EventHandler(this.entidadesToolStripMenuItem_Click);
            // 
            // pnlRIPS
            // 
            this.pnlRIPS.Controls.Add(this.chkBoxLonDoc);
            this.pnlRIPS.Controls.Add(this.lblStatusAU);
            this.pnlRIPS.Controls.Add(this.prgBarAU);
            this.pnlRIPS.Controls.Add(this.btnAU);
            this.pnlRIPS.Controls.Add(this.lblAU);
            this.pnlRIPS.Controls.Add(this.lblStatusAT);
            this.pnlRIPS.Controls.Add(this.prgBarAT);
            this.pnlRIPS.Controls.Add(this.btnAT);
            this.pnlRIPS.Controls.Add(this.lblAT);
            this.pnlRIPS.Controls.Add(this.lblStatusDoc);
            this.pnlRIPS.Controls.Add(this.prgBarDoc);
            this.pnlRIPS.Controls.Add(this.label9);
            this.pnlRIPS.Controls.Add(this.label8);
            this.pnlRIPS.Controls.Add(this.lblAP);
            this.pnlRIPS.Controls.Add(this.lblAC);
            this.pnlRIPS.Controls.Add(this.lblTitle);
            this.pnlRIPS.Controls.Add(this.lblUS);
            this.pnlRIPS.Controls.Add(this.btnDoc);
            this.pnlRIPS.Controls.Add(this.lblStatusUS);
            this.pnlRIPS.Controls.Add(this.prgBarUS);
            this.pnlRIPS.Controls.Add(this.btnUS);
            this.pnlRIPS.Controls.Add(this.lblStatusAC);
            this.pnlRIPS.Controls.Add(this.prgBarAC);
            this.pnlRIPS.Controls.Add(this.groupBox1);
            this.pnlRIPS.Controls.Add(this.label1);
            this.pnlRIPS.Controls.Add(this.lblStatusAP);
            this.pnlRIPS.Controls.Add(this.btnAC);
            this.pnlRIPS.Controls.Add(this.prgBarAP);
            this.pnlRIPS.Controls.Add(this.btnAP);
            this.pnlRIPS.Controls.Add(this.txtRuta);
            this.pnlRIPS.Controls.Add(this.btnRuta);
            this.pnlRIPS.Location = new System.Drawing.Point(0, 27);
            this.pnlRIPS.Name = "pnlRIPS";
            this.pnlRIPS.Size = new System.Drawing.Size(695, 359);
            this.pnlRIPS.TabIndex = 1;
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
            this.btnAU.Image = ((System.Drawing.Image)(resources.GetObject("btnAU.Image")));
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
            this.btnAT.Image = ((System.Drawing.Image)(resources.GetObject("btnAT.Image")));
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
            this.btnDoc.Image = ((System.Drawing.Image)(resources.GetObject("btnDoc.Image")));
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
            this.btnUS.Image = ((System.Drawing.Image)(resources.GetObject("btnUS.Image")));
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
            this.btnAC.Image = ((System.Drawing.Image)(resources.GetObject("btnAC.Image")));
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
            this.btnAP.Image = ((System.Drawing.Image)(resources.GetObject("btnAP.Image")));
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
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(640, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 40);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // pnlEntidades
            // 
            this.pnlEntidades.Controls.Add(this.btnBorrarEntidad);
            this.pnlEntidades.Controls.Add(this.txtIdEntidad);
            this.pnlEntidades.Controls.Add(this.lblIdEntidad);
            this.pnlEntidades.Controls.Add(this.btnGrabar);
            this.pnlEntidades.Controls.Add(this.cbRegimenEntidad);
            this.pnlEntidades.Controls.Add(this.txtCodigoEntidad);
            this.pnlEntidades.Controls.Add(this.txtNombreEntidad);
            this.pnlEntidades.Controls.Add(this.lblRegimen);
            this.pnlEntidades.Controls.Add(this.lblCodigo);
            this.pnlEntidades.Controls.Add(this.lblNombre);
            this.pnlEntidades.Controls.Add(this.label10);
            this.pnlEntidades.Controls.Add(this.dataGridView1);
            this.pnlEntidades.Location = new System.Drawing.Point(0, 27);
            this.pnlEntidades.Name = "pnlEntidades";
            this.pnlEntidades.Size = new System.Drawing.Size(697, 291);
            this.pnlEntidades.TabIndex = 2;
            this.pnlEntidades.Visible = false;
            // 
            // btnBorrarEntidad
            // 
            this.btnBorrarEntidad.Location = new System.Drawing.Point(11, 260);
            this.btnBorrarEntidad.Name = "btnBorrarEntidad";
            this.btnBorrarEntidad.Size = new System.Drawing.Size(100, 23);
            this.btnBorrarEntidad.TabIndex = 11;
            this.btnBorrarEntidad.Text = "Borrar";
            this.btnBorrarEntidad.UseVisualStyleBackColor = true;
            this.btnBorrarEntidad.Click += new System.EventHandler(this.btnBorrarEntidad_Click);
            // 
            // txtIdEntidad
            // 
            this.txtIdEntidad.Enabled = false;
            this.txtIdEntidad.Location = new System.Drawing.Point(11, 34);
            this.txtIdEntidad.Name = "txtIdEntidad";
            this.txtIdEntidad.Size = new System.Drawing.Size(100, 20);
            this.txtIdEntidad.TabIndex = 10;
            // 
            // lblIdEntidad
            // 
            this.lblIdEntidad.AutoSize = true;
            this.lblIdEntidad.Location = new System.Drawing.Point(12, 17);
            this.lblIdEntidad.Name = "lblIdEntidad";
            this.lblIdEntidad.Size = new System.Drawing.Size(16, 13);
            this.lblIdEntidad.TabIndex = 9;
            this.lblIdEntidad.Text = "Id";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(11, 230);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(100, 23);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cbRegimenEntidad
            // 
            this.cbRegimenEntidad.FormattingEnabled = true;
            this.cbRegimenEntidad.Items.AddRange(new object[] {
            "CONTRIBUTIVO",
            "SUBSIDIADO",
            "VINCULADO",
            "PARTICULAR",
            "OTRO"});
            this.cbRegimenEntidad.Location = new System.Drawing.Point(11, 180);
            this.cbRegimenEntidad.Name = "cbRegimenEntidad";
            this.cbRegimenEntidad.Size = new System.Drawing.Size(100, 21);
            this.cbRegimenEntidad.TabIndex = 7;
            // 
            // txtCodigoEntidad
            // 
            this.txtCodigoEntidad.Location = new System.Drawing.Point(11, 130);
            this.txtCodigoEntidad.Name = "txtCodigoEntidad";
            this.txtCodigoEntidad.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoEntidad.TabIndex = 6;
            // 
            // txtNombreEntidad
            // 
            this.txtNombreEntidad.Location = new System.Drawing.Point(11, 80);
            this.txtNombreEntidad.Name = "txtNombreEntidad";
            this.txtNombreEntidad.Size = new System.Drawing.Size(182, 20);
            this.txtNombreEntidad.TabIndex = 5;
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Location = new System.Drawing.Point(12, 164);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(88, 13);
            this.lblRegimen.TabIndex = 4;
            this.lblRegimen.Text = "Régimen Entidad";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(12, 114);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(79, 13);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código Entidad";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 63);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(83, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre Entidad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(220, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Entidades";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Codigo,
            this.Regimen});
            this.dataGridView1.Location = new System.Drawing.Point(223, 33);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(462, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Id
            // 
            this.Id.FillWeight = 27.36041F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 110F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Codigo
            // 
            this.Codigo.FillWeight = 54.72083F;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Regimen
            // 
            this.Regimen.FillWeight = 54.72083F;
            this.Regimen.HeaderText = "Regimen";
            this.Regimen.Name = "Regimen";
            this.Regimen.ReadOnly = true;
            this.Regimen.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 462);
            this.Controls.Add(this.pnlRIPS);
            this.Controls.Add(this.pnlEntidades);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Corrección RIPS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlRIPS.ResumeLayout(false);
            this.pnlRIPS.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlEntidades.ResumeLayout(false);
            this.pnlEntidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carpetasToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem parametrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entidadesToolStripMenuItem;
        private System.Windows.Forms.Panel pnlRIPS;
        private System.Windows.Forms.Panel pnlEntidades;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ComboBox cbRegimenEntidad;
        private System.Windows.Forms.TextBox txtCodigoEntidad;
        private System.Windows.Forms.TextBox txtNombreEntidad;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdEntidad;
        private System.Windows.Forms.Label lblIdEntidad;
        private System.Windows.Forms.Button btnBorrarEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regimen;
    }
}

