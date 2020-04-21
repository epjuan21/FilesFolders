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
            this.rIPSFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rIPSNuevaEPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rIPSEABPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioEstructuraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprimirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tltDocLong = new System.Windows.Forms.ToolTip(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Regimen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.entidadSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entidadSetBindingSource)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
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
            this.rIPSFacturaToolStripMenuItem,
            this.rIPSNuevaEPSToolStripMenuItem});
            this.carpetasToolStripMenuItem.Name = "carpetasToolStripMenuItem";
            this.carpetasToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.carpetasToolStripMenuItem.Text = "Edición";
            // 
            // rIPSToolStripMenuItem
            // 
            this.rIPSToolStripMenuItem.Name = "rIPSToolStripMenuItem";
            this.rIPSToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.rIPSToolStripMenuItem.Text = "RIPS Masivo";
            this.rIPSToolStripMenuItem.Click += new System.EventHandler(this.rIPSToolStripMenuItem_Click);
            // 
            // rIPSIndividualToolStripMenuItem
            // 
            this.rIPSIndividualToolStripMenuItem.Name = "rIPSIndividualToolStripMenuItem";
            this.rIPSIndividualToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.rIPSIndividualToolStripMenuItem.Text = "RIPS Individual";
            this.rIPSIndividualToolStripMenuItem.Click += new System.EventHandler(this.rIPSIndividualToolStripMenuItem_Click);
            // 
            // rIPSCarpetasToolStripMenuItem
            // 
            this.rIPSCarpetasToolStripMenuItem.Name = "rIPSCarpetasToolStripMenuItem";
            this.rIPSCarpetasToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.rIPSCarpetasToolStripMenuItem.Text = "RIPS Carpetas";
            this.rIPSCarpetasToolStripMenuItem.Click += new System.EventHandler(this.rIPSCarpetasToolStripMenuItem_Click);
            // 
            // rIPSFacturaToolStripMenuItem
            // 
            this.rIPSFacturaToolStripMenuItem.Name = "rIPSFacturaToolStripMenuItem";
            this.rIPSFacturaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.rIPSFacturaToolStripMenuItem.Text = "RIPS Factura";
            this.rIPSFacturaToolStripMenuItem.Click += new System.EventHandler(this.rIPSFacturaToolStripMenuItem_Click);
            // 
            // rIPSNuevaEPSToolStripMenuItem
            // 
            this.rIPSNuevaEPSToolStripMenuItem.Name = "rIPSNuevaEPSToolStripMenuItem";
            this.rIPSNuevaEPSToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.rIPSNuevaEPSToolStripMenuItem.Text = "RIPS Nueva EPS";
            this.rIPSNuevaEPSToolStripMenuItem.Click += new System.EventHandler(this.rIPSNuevaEPSToolStripMenuItem_Click);
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
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(610, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 40);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 486);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corrección RIPS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entidadSetBindingSource)).EndInit();
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip tltDocLong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regimen;
        private System.Windows.Forms.ToolStripMenuItem rIPSIndividualToolStripMenuItem;
        private System.Windows.Forms.BindingSource entidadSetBindingSource;
        private System.Windows.Forms.ToolStripMenuItem rIPSCarpetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rIPSEABPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioEstructuraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprimirArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rIPSFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rIPSNuevaEPSToolStripMenuItem;
    }
}

