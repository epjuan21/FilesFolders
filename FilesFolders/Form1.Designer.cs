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
            this.rIPSIndividualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rIPSCarpetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rIPSEABPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioEstructuraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprimirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
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
            this.pnlRIPSIndividual = new System.Windows.Forms.Panel();
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tltDocLong = new System.Windows.Forms.ToolTip(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Regimen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlComprimirArchivo = new System.Windows.Forms.Panel();
            this.txtRutaEAPB = new System.Windows.Forms.TextBox();
            this.btnRutaEAPB = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnComprimir = new System.Windows.Forms.Button();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbExtension = new System.Windows.Forms.ComboBox();
            this.cmbRegimen = new System.Windows.Forms.ComboBox();
            this.cmbTipoIdEntidad = new System.Windows.Forms.ComboBox();
            this.txtConsecutivo = new System.Windows.Forms.TextBox();
            this.txtNumeroIdEntidad = new System.Windows.Forms.TextBox();
            this.txtFechaCorte = new System.Windows.Forms.TextBox();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.txtTipoFuente = new System.Windows.Forms.TextBox();
            this.lblExtension = new System.Windows.Forms.Label();
            this.lblConsecutivo = new System.Windows.Forms.Label();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.lblNumeroIdEntidad = new System.Windows.Forms.Label();
            this.lblTipoIdEntidad = new System.Windows.Forms.Label();
            this.lblFechaCorte = new System.Windows.Forms.Label();
            this.lblTema = new System.Windows.Forms.Label();
            this.lblTipoFuente = new System.Windows.Forms.Label();
            this.lblModuloInformacion = new System.Windows.Forms.Label();
            this.txtModuloInformacion = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.entidadSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.btnRutaCarpetaEAPB = new System.Windows.Forms.Button();
            this.txtRuraCarpetaEAPB = new System.Windows.Forms.TextBox();
            this.lblTituloEAPB = new System.Windows.Forms.Label();
            this.btnProcesarEAPB = new System.Windows.Forms.Button();
            this.prgBarEAPB = new System.Windows.Forms.ProgressBar();
            this.lblEstatusEAPB = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtCodigoMunicipio = new System.Windows.Forms.TextBox();
            this.pnlCambioEsctuctura = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRutaCarpeta = new System.Windows.Forms.Button();
            this.txtRutaCarpeta = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.pnlRIPSCarpetas = new System.Windows.Forms.Panel();
            this.rIPSFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlRIPSIndividual.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlComprimirArchivo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entidadSetBindingSource)).BeginInit();
            this.pnlCambioEsctuctura.SuspendLayout();
            this.pnlRIPSCarpetas.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.carpetasToolStripMenuItem,
            this.rIPSEABPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(783, 24);
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
            this.rIPSToolStripMenuItem,
            this.rIPSIndividualToolStripMenuItem,
            this.rIPSCarpetasToolStripMenuItem,
            this.rIPSFacturaToolStripMenuItem});
            this.carpetasToolStripMenuItem.Name = "carpetasToolStripMenuItem";
            this.carpetasToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.carpetasToolStripMenuItem.Text = "Edición";
            // 
            // rIPSToolStripMenuItem
            // 
            this.rIPSToolStripMenuItem.Name = "rIPSToolStripMenuItem";
            this.rIPSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rIPSToolStripMenuItem.Text = "RIPS Masivo";
            this.rIPSToolStripMenuItem.Click += new System.EventHandler(this.rIPSToolStripMenuItem_Click);
            // 
            // rIPSIndividualToolStripMenuItem
            // 
            this.rIPSIndividualToolStripMenuItem.Name = "rIPSIndividualToolStripMenuItem";
            this.rIPSIndividualToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rIPSIndividualToolStripMenuItem.Text = "RIPS Individual";
            this.rIPSIndividualToolStripMenuItem.Click += new System.EventHandler(this.rIPSIndividualToolStripMenuItem_Click);
            // 
            // rIPSCarpetasToolStripMenuItem
            // 
            this.rIPSCarpetasToolStripMenuItem.Name = "rIPSCarpetasToolStripMenuItem";
            this.rIPSCarpetasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rIPSCarpetasToolStripMenuItem.Text = "RIPS Carpetas";
            this.rIPSCarpetasToolStripMenuItem.Click += new System.EventHandler(this.rIPSCarpetasToolStripMenuItem_Click);
            // 
            // rIPSEABPToolStripMenuItem
            // 
            this.rIPSEABPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambioEstructuraToolStripMenuItem,
            this.comprimirArchivoToolStripMenuItem});
            this.rIPSEABPToolStripMenuItem.Name = "rIPSEABPToolStripMenuItem";
            this.rIPSEABPToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.rIPSEABPToolStripMenuItem.Text = "RIPS EABP";
            // 
            // cambioEstructuraToolStripMenuItem
            // 
            this.cambioEstructuraToolStripMenuItem.Name = "cambioEstructuraToolStripMenuItem";
            this.cambioEstructuraToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cambioEstructuraToolStripMenuItem.Text = "Cambio Estructura";
            this.cambioEstructuraToolStripMenuItem.Click += new System.EventHandler(this.cambioEstructuraToolStripMenuItem_Click);
            // 
            // comprimirArchivoToolStripMenuItem
            // 
            this.comprimirArchivoToolStripMenuItem.Name = "comprimirArchivoToolStripMenuItem";
            this.comprimirArchivoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.comprimirArchivoToolStripMenuItem.Text = "Comprimir Archivo";
            this.comprimirArchivoToolStripMenuItem.Click += new System.EventHandler(this.comprimirArchivoToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label27);
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
            this.groupBox1.Location = new System.Drawing.Point(273, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 190);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total Archivos";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(0, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 23);
            this.label27.TabIndex = 1;
            // 
            // lblTotalAU
            // 
            this.lblTotalAU.Location = new System.Drawing.Point(0, 0);
            this.lblTotalAU.Name = "lblTotalAU";
            this.lblTotalAU.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAU.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            // 
            // lblTotalUS
            // 
            this.lblTotalUS.Location = new System.Drawing.Point(0, 0);
            this.lblTotalUS.Name = "lblTotalUS";
            this.lblTotalUS.Size = new System.Drawing.Size(100, 23);
            this.lblTotalUS.TabIndex = 4;
            // 
            // lblTotalAT
            // 
            this.lblTotalAT.Location = new System.Drawing.Point(0, 0);
            this.lblTotalAT.Name = "lblTotalAT";
            this.lblTotalAT.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAT.TabIndex = 5;
            // 
            // lblTotalAM
            // 
            this.lblTotalAM.Location = new System.Drawing.Point(0, 0);
            this.lblTotalAM.Name = "lblTotalAM";
            this.lblTotalAM.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAM.TabIndex = 6;
            // 
            // lblTotalAP
            // 
            this.lblTotalAP.Location = new System.Drawing.Point(0, 0);
            this.lblTotalAP.Name = "lblTotalAP";
            this.lblTotalAP.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAP.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 12;
            // 
            // lblTotalAC
            // 
            this.lblTotalAC.Location = new System.Drawing.Point(0, 0);
            this.lblTotalAC.Name = "lblTotalAC";
            this.lblTotalAC.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAC.TabIndex = 13;
            // 
            // pnlRIPSIndividual
            // 
            this.pnlRIPSIndividual.Controls.Add(this.label14);
            this.pnlRIPSIndividual.Controls.Add(this.lblTitulo);
            this.pnlRIPSIndividual.Controls.Add(this.groupBox2);
            this.pnlRIPSIndividual.Controls.Add(this.label11);
            this.pnlRIPSIndividual.Controls.Add(this.txtRutaIndividual);
            this.pnlRIPSIndividual.Controls.Add(this.btnRutaIndividual);
            this.pnlRIPSIndividual.Location = new System.Drawing.Point(693, 427);
            this.pnlRIPSIndividual.Name = "pnlRIPSIndividual";
            this.pnlRIPSIndividual.Size = new System.Drawing.Size(655, 207);
            this.pnlRIPSIndividual.TabIndex = 12;
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
            this.btnRutaIndividual.Click += new System.EventHandler(this.btnRutaIndividual_Click);
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
            // pnlComprimirArchivo
            // 
            this.pnlComprimirArchivo.Controls.Add(this.txtRutaEAPB);
            this.pnlComprimirArchivo.Controls.Add(this.btnRutaEAPB);
            this.pnlComprimirArchivo.Controls.Add(this.groupBox3);
            this.pnlComprimirArchivo.Controls.Add(this.label25);
            this.pnlComprimirArchivo.Location = new System.Drawing.Point(24, 362);
            this.pnlComprimirArchivo.Name = "pnlComprimirArchivo";
            this.pnlComprimirArchivo.Size = new System.Drawing.Size(612, 424);
            this.pnlComprimirArchivo.TabIndex = 14;
            // 
            // txtRutaEAPB
            // 
            this.txtRutaEAPB.Enabled = false;
            this.txtRutaEAPB.Location = new System.Drawing.Point(97, 37);
            this.txtRutaEAPB.Name = "txtRutaEAPB";
            this.txtRutaEAPB.Size = new System.Drawing.Size(504, 20);
            this.txtRutaEAPB.TabIndex = 14;
            // 
            // btnRutaEAPB
            // 
            this.btnRutaEAPB.Location = new System.Drawing.Point(16, 35);
            this.btnRutaEAPB.Name = "btnRutaEAPB";
            this.btnRutaEAPB.Size = new System.Drawing.Size(75, 23);
            this.btnRutaEAPB.TabIndex = 13;
            this.btnRutaEAPB.Text = "Ruta";
            this.btnRutaEAPB.UseVisualStyleBackColor = true;
            this.btnRutaEAPB.Click += new System.EventHandler(this.btnRutaEAPB_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnComprimir);
            this.groupBox3.Controls.Add(this.lblNombreArchivo);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.cmbExtension);
            this.groupBox3.Controls.Add(this.cmbRegimen);
            this.groupBox3.Controls.Add(this.cmbTipoIdEntidad);
            this.groupBox3.Controls.Add(this.txtConsecutivo);
            this.groupBox3.Controls.Add(this.txtNumeroIdEntidad);
            this.groupBox3.Controls.Add(this.txtFechaCorte);
            this.groupBox3.Controls.Add(this.txtTema);
            this.groupBox3.Controls.Add(this.txtTipoFuente);
            this.groupBox3.Controls.Add(this.lblExtension);
            this.groupBox3.Controls.Add(this.lblConsecutivo);
            this.groupBox3.Controls.Add(this.lblRegimen);
            this.groupBox3.Controls.Add(this.lblNumeroIdEntidad);
            this.groupBox3.Controls.Add(this.lblTipoIdEntidad);
            this.groupBox3.Controls.Add(this.lblFechaCorte);
            this.groupBox3.Controls.Add(this.lblTema);
            this.groupBox3.Controls.Add(this.lblTipoFuente);
            this.groupBox3.Controls.Add(this.lblModuloInformacion);
            this.groupBox3.Controls.Add(this.txtModuloInformacion);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(12, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(589, 337);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Comprimir Archivo";
            // 
            // btnComprimir
            // 
            this.btnComprimir.Image = global::FilesFolders.Properties.Resources.icons8_Archive_Folder_32;
            this.btnComprimir.Location = new System.Drawing.Point(523, 290);
            this.btnComprimir.Name = "btnComprimir";
            this.btnComprimir.Size = new System.Drawing.Size(50, 30);
            this.btnComprimir.TabIndex = 24;
            this.btnComprimir.UseVisualStyleBackColor = true;
            this.btnComprimir.Click += new System.EventHandler(this.btnComprimir_Click);
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNombreArchivo.Location = new System.Drawing.Point(117, 307);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(103, 13);
            this.lblNombreArchivo.TabIndex = 23;
            this.lblNombreArchivo.Text = "NOMBREARCHIVO";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(6, 307);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(93, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "Nombre Archivo";
            // 
            // cmbExtension
            // 
            this.cmbExtension.FormattingEnabled = true;
            this.cmbExtension.Items.AddRange(new object[] {
            ".DAT",
            ".zip"});
            this.cmbExtension.Location = new System.Drawing.Point(9, 271);
            this.cmbExtension.Name = "cmbExtension";
            this.cmbExtension.Size = new System.Drawing.Size(102, 21);
            this.cmbExtension.TabIndex = 21;
            // 
            // cmbRegimen
            // 
            this.cmbRegimen.FormattingEnabled = true;
            this.cmbRegimen.Items.AddRange(new object[] {
            "C",
            "S",
            "O"});
            this.cmbRegimen.Location = new System.Drawing.Point(9, 214);
            this.cmbRegimen.Name = "cmbRegimen";
            this.cmbRegimen.Size = new System.Drawing.Size(102, 21);
            this.cmbRegimen.TabIndex = 20;
            // 
            // cmbTipoIdEntidad
            // 
            this.cmbTipoIdEntidad.FormattingEnabled = true;
            this.cmbTipoIdEntidad.Items.AddRange(new object[] {
            "MU",
            "DE",
            "DI",
            "NI"});
            this.cmbTipoIdEntidad.Location = new System.Drawing.Point(9, 159);
            this.cmbTipoIdEntidad.Name = "cmbTipoIdEntidad";
            this.cmbTipoIdEntidad.Size = new System.Drawing.Size(102, 21);
            this.cmbTipoIdEntidad.TabIndex = 19;
            // 
            // txtConsecutivo
            // 
            this.txtConsecutivo.Location = new System.Drawing.Point(9, 241);
            this.txtConsecutivo.Name = "txtConsecutivo";
            this.txtConsecutivo.Size = new System.Drawing.Size(102, 22);
            this.txtConsecutivo.TabIndex = 17;
            // 
            // txtNumeroIdEntidad
            // 
            this.txtNumeroIdEntidad.Location = new System.Drawing.Point(9, 186);
            this.txtNumeroIdEntidad.Name = "txtNumeroIdEntidad";
            this.txtNumeroIdEntidad.Size = new System.Drawing.Size(102, 22);
            this.txtNumeroIdEntidad.TabIndex = 15;
            // 
            // txtFechaCorte
            // 
            this.txtFechaCorte.Location = new System.Drawing.Point(9, 131);
            this.txtFechaCorte.Name = "txtFechaCorte";
            this.txtFechaCorte.Size = new System.Drawing.Size(102, 22);
            this.txtFechaCorte.TabIndex = 13;
            this.txtFechaCorte.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(9, 103);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(50, 22);
            this.txtTema.TabIndex = 12;
            // 
            // txtTipoFuente
            // 
            this.txtTipoFuente.Location = new System.Drawing.Point(9, 75);
            this.txtTipoFuente.Name = "txtTipoFuente";
            this.txtTipoFuente.Size = new System.Drawing.Size(50, 22);
            this.txtTipoFuente.TabIndex = 11;
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtension.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblExtension.Location = new System.Drawing.Point(117, 274);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(116, 13);
            this.lblExtension.TabIndex = 10;
            this.lblExtension.Text = "Extensión del archivo";
            // 
            // lblConsecutivo
            // 
            this.lblConsecutivo.AutoSize = true;
            this.lblConsecutivo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsecutivo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblConsecutivo.Location = new System.Drawing.Point(117, 244);
            this.lblConsecutivo.Name = "lblConsecutivo";
            this.lblConsecutivo.Size = new System.Drawing.Size(126, 13);
            this.lblConsecutivo.TabIndex = 9;
            this.lblConsecutivo.Text = "Consecutivo de archivo";
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegimen.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblRegimen.Location = new System.Drawing.Point(117, 217);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(52, 13);
            this.lblRegimen.TabIndex = 8;
            this.lblRegimen.Text = "Régimen";
            // 
            // lblNumeroIdEntidad
            // 
            this.lblNumeroIdEntidad.AutoSize = true;
            this.lblNumeroIdEntidad.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroIdEntidad.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblNumeroIdEntidad.Location = new System.Drawing.Point(117, 192);
            this.lblNumeroIdEntidad.Name = "lblNumeroIdEntidad";
            this.lblNumeroIdEntidad.Size = new System.Drawing.Size(269, 13);
            this.lblNumeroIdEntidad.TabIndex = 7;
            this.lblNumeroIdEntidad.Text = "Número de Identificación de la Entidad Reportante";
            // 
            // lblTipoIdEntidad
            // 
            this.lblTipoIdEntidad.AutoSize = true;
            this.lblTipoIdEntidad.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoIdEntidad.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTipoIdEntidad.Location = new System.Drawing.Point(117, 162);
            this.lblTipoIdEntidad.Name = "lblTipoIdEntidad";
            this.lblTipoIdEntidad.Size = new System.Drawing.Size(189, 13);
            this.lblTipoIdEntidad.TabIndex = 6;
            this.lblTipoIdEntidad.Text = "Tipo de Identificación de la Entidad";
            // 
            // lblFechaCorte
            // 
            this.lblFechaCorte.AutoSize = true;
            this.lblFechaCorte.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCorte.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFechaCorte.Location = new System.Drawing.Point(117, 137);
            this.lblFechaCorte.Name = "lblFechaCorte";
            this.lblFechaCorte.Size = new System.Drawing.Size(84, 13);
            this.lblFechaCorte.TabIndex = 5;
            this.lblFechaCorte.Text = "Fecha de Corte";
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTema.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTema.Location = new System.Drawing.Point(65, 106);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(113, 13);
            this.lblTema.TabIndex = 4;
            this.lblTema.Text = "Tema de Información";
            // 
            // lblTipoFuente
            // 
            this.lblTipoFuente.AutoSize = true;
            this.lblTipoFuente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFuente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTipoFuente.Location = new System.Drawing.Point(65, 78);
            this.lblTipoFuente.Name = "lblTipoFuente";
            this.lblTipoFuente.Size = new System.Drawing.Size(84, 13);
            this.lblTipoFuente.TabIndex = 3;
            this.lblTipoFuente.Text = "Tipo de Fuente";
            // 
            // lblModuloInformacion
            // 
            this.lblModuloInformacion.AutoSize = true;
            this.lblModuloInformacion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuloInformacion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblModuloInformacion.Location = new System.Drawing.Point(65, 50);
            this.lblModuloInformacion.Name = "lblModuloInformacion";
            this.lblModuloInformacion.Size = new System.Drawing.Size(129, 13);
            this.lblModuloInformacion.TabIndex = 2;
            this.lblModuloInformacion.Text = "Módulo de Información";
            // 
            // txtModuloInformacion
            // 
            this.txtModuloInformacion.Location = new System.Drawing.Point(9, 47);
            this.txtModuloInformacion.Name = "txtModuloInformacion";
            this.txtModuloInformacion.Size = new System.Drawing.Size(50, 22);
            this.txtModuloInformacion.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label23.Location = new System.Drawing.Point(6, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(567, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Estructura del Nombre del Archivo según Resolución 1531 de 2014 del Ministerio de" +
    " Salud y Protección Social";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label25.Location = new System.Drawing.Point(12, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(402, 20);
            this.label25.TabIndex = 6;
            this.label25.Text = "Seleccione la ruta donde se encuentran los archivos RIPS";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(642, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 40);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
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
            // txtRuraCarpetaEAPB
            // 
            this.txtRuraCarpetaEAPB.Enabled = false;
            this.txtRuraCarpetaEAPB.Location = new System.Drawing.Point(93, 117);
            this.txtRuraCarpetaEAPB.Name = "txtRuraCarpetaEAPB";
            this.txtRuraCarpetaEAPB.Size = new System.Drawing.Size(387, 20);
            this.txtRuraCarpetaEAPB.TabIndex = 10;
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
            // prgBarEAPB
            // 
            this.prgBarEAPB.Location = new System.Drawing.Point(93, 155);
            this.prgBarEAPB.Name = "prgBarEAPB";
            this.prgBarEAPB.Size = new System.Drawing.Size(387, 23);
            this.prgBarEAPB.TabIndex = 13;
            // 
            // lblEstatusEAPB
            // 
            this.lblEstatusEAPB.AutoSize = true;
            this.lblEstatusEAPB.Location = new System.Drawing.Point(486, 161);
            this.lblEstatusEAPB.Name = "lblEstatusEAPB";
            this.lblEstatusEAPB.Size = new System.Drawing.Size(42, 13);
            this.lblEstatusEAPB.TabIndex = 14;
            this.lblEstatusEAPB.Text = "Estatus";
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
            // txtCodigoMunicipio
            // 
            this.txtCodigoMunicipio.Location = new System.Drawing.Point(108, 84);
            this.txtCodigoMunicipio.Name = "txtCodigoMunicipio";
            this.txtCodigoMunicipio.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoMunicipio.TabIndex = 16;
            // 
            // pnlCambioEsctuctura
            // 
            this.pnlCambioEsctuctura.Controls.Add(this.txtCodigoMunicipio);
            this.pnlCambioEsctuctura.Controls.Add(this.label26);
            this.pnlCambioEsctuctura.Controls.Add(this.lblEstatusEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.prgBarEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.btnProcesarEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.lblTituloEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.txtRuraCarpetaEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.btnRutaCarpetaEAPB);
            this.pnlCambioEsctuctura.Controls.Add(this.label10);
            this.pnlCambioEsctuctura.Location = new System.Drawing.Point(693, 187);
            this.pnlCambioEsctuctura.Name = "pnlCambioEsctuctura";
            this.pnlCambioEsctuctura.Size = new System.Drawing.Size(566, 222);
            this.pnlCambioEsctuctura.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(7, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(236, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Generación de carpetas por RIPS";
            // 
            // btnRutaCarpeta
            // 
            this.btnRutaCarpeta.Location = new System.Drawing.Point(11, 97);
            this.btnRutaCarpeta.Name = "btnRutaCarpeta";
            this.btnRutaCarpeta.Size = new System.Drawing.Size(75, 23);
            this.btnRutaCarpeta.TabIndex = 8;
            this.btnRutaCarpeta.Text = "Ruta";
            this.btnRutaCarpeta.UseVisualStyleBackColor = true;
            this.btnRutaCarpeta.Click += new System.EventHandler(this.btnRutaCarpeta_Click);
            // 
            // txtRutaCarpeta
            // 
            this.txtRutaCarpeta.Enabled = false;
            this.txtRutaCarpeta.Location = new System.Drawing.Point(92, 99);
            this.txtRutaCarpeta.Name = "txtRutaCarpeta";
            this.txtRutaCarpeta.Size = new System.Drawing.Size(508, 20);
            this.txtRutaCarpeta.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 33);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(455, 39);
            this.label22.TabIndex = 10;
            this.label22.Text = resources.GetString("label22.Text");
            // 
            // pnlRIPSCarpetas
            // 
            this.pnlRIPSCarpetas.Controls.Add(this.label22);
            this.pnlRIPSCarpetas.Controls.Add(this.txtRutaCarpeta);
            this.pnlRIPSCarpetas.Controls.Add(this.btnRutaCarpeta);
            this.pnlRIPSCarpetas.Controls.Add(this.label13);
            this.pnlRIPSCarpetas.Location = new System.Drawing.Point(693, 0);
            this.pnlRIPSCarpetas.Name = "pnlRIPSCarpetas";
            this.pnlRIPSCarpetas.Size = new System.Drawing.Size(609, 181);
            this.pnlRIPSCarpetas.TabIndex = 13;
            // 
            // rIPSFacturaToolStripMenuItem
            // 
            this.rIPSFacturaToolStripMenuItem.Name = "rIPSFacturaToolStripMenuItem";
            this.rIPSFacturaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rIPSFacturaToolStripMenuItem.Text = "RIPS Factura";
            this.rIPSFacturaToolStripMenuItem.Click += new System.EventHandler(this.rIPSFacturaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 565);
            this.Controls.Add(this.pnlRIPSCarpetas);
            this.Controls.Add(this.pnlCambioEsctuctura);
            this.Controls.Add(this.pnlComprimirArchivo);
            this.Controls.Add(this.pnlRIPSIndividual);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corrección RIPS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.pnlRIPSIndividual.ResumeLayout(false);
            this.pnlRIPSIndividual.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlComprimirArchivo.ResumeLayout(false);
            this.pnlComprimirArchivo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entidadSetBindingSource)).EndInit();
            this.pnlCambioEsctuctura.ResumeLayout(false);
            this.pnlCambioEsctuctura.PerformLayout();
            this.pnlRIPSCarpetas.ResumeLayout(false);
            this.pnlRIPSCarpetas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carpetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rIPSToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblTotalAC;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
        private System.Windows.Forms.Label lblTotalAU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip tltDocLong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regimen;
        private System.Windows.Forms.ToolStripMenuItem rIPSIndividualToolStripMenuItem;
        private System.Windows.Forms.BindingSource entidadSetBindingSource;
        private System.Windows.Forms.Panel pnlRIPSIndividual;
        private System.Windows.Forms.TextBox txtRutaIndividual;
        private System.Windows.Forms.Button btnRutaIndividual;
        private System.Windows.Forms.Label lblLineasUS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblLineasAU;
        private System.Windows.Forms.Label lblLineasAT;
        private System.Windows.Forms.Label lblLineasAN;
        private System.Windows.Forms.Label lblLineasAM;
        private System.Windows.Forms.Label lblLineasAP;
        private System.Windows.Forms.Label lblLineasAH;
        private System.Windows.Forms.Label lblLineasAC;
        private System.Windows.Forms.Panel pnlComprimirArchivo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtModuloInformacion;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtConsecutivo;
        private System.Windows.Forms.TextBox txtNumeroIdEntidad;
        private System.Windows.Forms.TextBox txtFechaCorte;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.TextBox txtTipoFuente;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.Label lblConsecutivo;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.Label lblNumeroIdEntidad;
        private System.Windows.Forms.Label lblTipoIdEntidad;
        private System.Windows.Forms.Label lblFechaCorte;
        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.Label lblTipoFuente;
        private System.Windows.Forms.Label lblModuloInformacion;
        private System.Windows.Forms.ComboBox cmbTipoIdEntidad;
        private System.Windows.Forms.ComboBox cmbRegimen;
        private System.Windows.Forms.ComboBox cmbExtension;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ToolStripMenuItem rIPSCarpetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rIPSEABPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioEstructuraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprimirArchivoToolStripMenuItem;
        private System.Windows.Forms.TextBox txtRutaEAPB;
        private System.Windows.Forms.Button btnRutaEAPB;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnComprimir;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnRutaCarpetaEAPB;
        private System.Windows.Forms.TextBox txtRuraCarpetaEAPB;
        private System.Windows.Forms.Label lblTituloEAPB;
        private System.Windows.Forms.Button btnProcesarEAPB;
        private System.Windows.Forms.ProgressBar prgBarEAPB;
        private System.Windows.Forms.Label lblEstatusEAPB;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtCodigoMunicipio;
        private System.Windows.Forms.Panel pnlCambioEsctuctura;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRutaCarpeta;
        private System.Windows.Forms.TextBox txtRutaCarpeta;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel pnlRIPSCarpetas;
        private System.Windows.Forms.ToolStripMenuItem rIPSFacturaToolStripMenuItem;
    }
}

