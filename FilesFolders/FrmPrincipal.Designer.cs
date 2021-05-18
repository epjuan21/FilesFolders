
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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ediciónToolStripMenuItem,
            this.utilidadesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1097, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
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
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rIPSMasivoToolStripMenuItem,
            this.rIPSEABPToolStripMenuItem});
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ediciónToolStripMenuItem.Text = "Edición";
            // 
            // rIPSMasivoToolStripMenuItem
            // 
            this.rIPSMasivoToolStripMenuItem.Name = "rIPSMasivoToolStripMenuItem";
            this.rIPSMasivoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rIPSMasivoToolStripMenuItem.Text = "RIPS Masivo";
            this.rIPSMasivoToolStripMenuItem.Click += new System.EventHandler(this.rIPSMasivoToolStripMenuItem_Click);
            // 
            // rIPSEABPToolStripMenuItem
            // 
            this.rIPSEABPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambioEstructuraToolStripMenuItem,
            this.comprimirArchivoToolStripMenuItem});
            this.rIPSEABPToolStripMenuItem.Name = "rIPSEABPToolStripMenuItem";
            this.rIPSEABPToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            // utilidadesToolStripMenuItem
            // 
            this.utilidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sURAToolStripMenuItem,
            this.nuevaEPSToolStripMenuItem});
            this.utilidadesToolStripMenuItem.Name = "utilidadesToolStripMenuItem";
            this.utilidadesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.utilidadesToolStripMenuItem.Text = "Utilidades";
            // 
            // sURAToolStripMenuItem
            // 
            this.sURAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarNombresDeSoportesToolStripMenuItem});
            this.sURAToolStripMenuItem.Name = "sURAToolStripMenuItem";
            this.sURAToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.sURAToolStripMenuItem.Text = "SURA";
            // 
            // modificarNombresDeSoportesToolStripMenuItem
            // 
            this.modificarNombresDeSoportesToolStripMenuItem.Name = "modificarNombresDeSoportesToolStripMenuItem";
            this.modificarNombresDeSoportesToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.modificarNombresDeSoportesToolStripMenuItem.Text = "Modificar Nombres de Soportes";
            this.modificarNombresDeSoportesToolStripMenuItem.Click += new System.EventHandler(this.modificarNombresDeSoportesToolStripMenuItem_Click);
            // 
            // nuevaEPSToolStripMenuItem
            // 
            this.nuevaEPSToolStripMenuItem.Name = "nuevaEPSToolStripMenuItem";
            this.nuevaEPSToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.nuevaEPSToolStripMenuItem.Text = "Nueva EPS";
            this.nuevaEPSToolStripMenuItem.Click += new System.EventHandler(this.nuevaEPSToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 594);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RIPS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}