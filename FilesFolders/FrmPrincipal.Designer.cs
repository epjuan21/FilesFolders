
namespace FilesFolders
{
    partial class FrmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rIPSMasivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rIPSEABPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioEstructuraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprimirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sURAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarNombresDeSoportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaEPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOOSALUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenRIPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stVersion = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.unirRIPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.stVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ediciónToolStripMenuItem,
            this.utilidadesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1646, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(147, 34);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rIPSMasivoToolStripMenuItem,
            this.rIPSEABPToolStripMenuItem});
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.ediciónToolStripMenuItem.Text = "Edición";
            // 
            // rIPSMasivoToolStripMenuItem
            // 
            this.rIPSMasivoToolStripMenuItem.Name = "rIPSMasivoToolStripMenuItem";
            this.rIPSMasivoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.rIPSMasivoToolStripMenuItem.Text = "RIPS Masivo";
            this.rIPSMasivoToolStripMenuItem.Click += new System.EventHandler(this.rIPSMasivoToolStripMenuItem_Click);
            // 
            // rIPSEABPToolStripMenuItem
            // 
            this.rIPSEABPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambioEstructuraToolStripMenuItem,
            this.comprimirArchivoToolStripMenuItem});
            this.rIPSEABPToolStripMenuItem.Name = "rIPSEABPToolStripMenuItem";
            this.rIPSEABPToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.rIPSEABPToolStripMenuItem.Text = "RIPS EABP";
            // 
            // cambioEstructuraToolStripMenuItem
            // 
            this.cambioEstructuraToolStripMenuItem.Name = "cambioEstructuraToolStripMenuItem";
            this.cambioEstructuraToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.cambioEstructuraToolStripMenuItem.Text = "Cambio Estructura";
            this.cambioEstructuraToolStripMenuItem.Click += new System.EventHandler(this.cambioEstructuraToolStripMenuItem_Click);
            // 
            // comprimirArchivoToolStripMenuItem
            // 
            this.comprimirArchivoToolStripMenuItem.Name = "comprimirArchivoToolStripMenuItem";
            this.comprimirArchivoToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.comprimirArchivoToolStripMenuItem.Text = "Comprimir Archivo";
            this.comprimirArchivoToolStripMenuItem.Click += new System.EventHandler(this.comprimirArchivoToolStripMenuItem_Click);
            // 
            // utilidadesToolStripMenuItem
            // 
            this.utilidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sURAToolStripMenuItem,
            this.nuevaEPSToolStripMenuItem,
            this.cOOSALUDToolStripMenuItem,
            this.resumenRIPSToolStripMenuItem,
            this.unirRIPSToolStripMenuItem});
            this.utilidadesToolStripMenuItem.Name = "utilidadesToolStripMenuItem";
            this.utilidadesToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.utilidadesToolStripMenuItem.Text = "Utilidades";
            // 
            // sURAToolStripMenuItem
            // 
            this.sURAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarNombresDeSoportesToolStripMenuItem});
            this.sURAToolStripMenuItem.Name = "sURAToolStripMenuItem";
            this.sURAToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.sURAToolStripMenuItem.Text = "SURA";
            // 
            // modificarNombresDeSoportesToolStripMenuItem
            // 
            this.modificarNombresDeSoportesToolStripMenuItem.Name = "modificarNombresDeSoportesToolStripMenuItem";
            this.modificarNombresDeSoportesToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
            this.modificarNombresDeSoportesToolStripMenuItem.Text = "Modificar Nombres de Soportes";
            this.modificarNombresDeSoportesToolStripMenuItem.Click += new System.EventHandler(this.modificarNombresDeSoportesToolStripMenuItem_Click);
            // 
            // nuevaEPSToolStripMenuItem
            // 
            this.nuevaEPSToolStripMenuItem.Name = "nuevaEPSToolStripMenuItem";
            this.nuevaEPSToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.nuevaEPSToolStripMenuItem.Text = "Nueva EPS";
            this.nuevaEPSToolStripMenuItem.Click += new System.EventHandler(this.nuevaEPSToolStripMenuItem_Click);
            // 
            // cOOSALUDToolStripMenuItem
            // 
            this.cOOSALUDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soportesToolStripMenuItem});
            this.cOOSALUDToolStripMenuItem.Name = "cOOSALUDToolStripMenuItem";
            this.cOOSALUDToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.cOOSALUDToolStripMenuItem.Text = "COOSALUD";
            // 
            // soportesToolStripMenuItem
            // 
            this.soportesToolStripMenuItem.Name = "soportesToolStripMenuItem";
            this.soportesToolStripMenuItem.Size = new System.Drawing.Size(186, 34);
            this.soportesToolStripMenuItem.Text = "Soportes";
            this.soportesToolStripMenuItem.Click += new System.EventHandler(this.soportesToolStripMenuItem_Click);
            // 
            // resumenRIPSToolStripMenuItem
            // 
            this.resumenRIPSToolStripMenuItem.Name = "resumenRIPSToolStripMenuItem";
            this.resumenRIPSToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.resumenRIPSToolStripMenuItem.Text = "Resumen RIPS";
            this.resumenRIPSToolStripMenuItem.Click += new System.EventHandler(this.resumenRIPSToolStripMenuItem_Click);
            // 
            // stVersion
            // 
            this.stVersion.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.stVersion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslVersion});
            this.stVersion.Location = new System.Drawing.Point(0, 882);
            this.stVersion.Name = "stVersion";
            this.stVersion.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.stVersion.Size = new System.Drawing.Size(1646, 32);
            this.stVersion.TabIndex = 3;
            this.stVersion.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 25);
            // 
            // tsslVersion
            // 
            this.tsslVersion.Name = "tsslVersion";
            this.tsslVersion.Size = new System.Drawing.Size(179, 25);
            this.tsslVersion.Text = "toolStripStatusLabel2";
            // 
            // unirRIPSToolStripMenuItem
            // 
            this.unirRIPSToolStripMenuItem.Name = "unirRIPSToolStripMenuItem";
            this.unirRIPSToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.unirRIPSToolStripMenuItem.Text = "Unir RIPS";
            this.unirRIPSToolStripMenuItem.Click += new System.EventHandler(this.unirRIPSToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1646, 914);
            this.Controls.Add(this.stVersion);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RIPS";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.stVersion.ResumeLayout(false);
            this.stVersion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ediciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rIPSMasivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sURAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarNombresDeSoportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rIPSEABPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioEstructuraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprimirArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaEPSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOOSALUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumenRIPSToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslVersion;
        private System.Windows.Forms.ToolStripMenuItem unirRIPSToolStripMenuItem;
    }
}