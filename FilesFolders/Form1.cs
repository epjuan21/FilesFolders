using System;
using System.Windows.Forms;
using FilesFolders.ManejoArchivos;

namespace FilesFolders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Menu
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RIPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRIPS frmRIPS = new FrmRIPS();
            frmRIPS.ShowDialog();
        }

        private void RIPSIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRIPSIndividual frmRIPSIndividual = new FrmRIPSIndividual();
            frmRIPSIndividual.ShowDialog();
        }

        private void RIPSCarpetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCarpetas frmCarpetas = new FrmCarpetas();
            frmCarpetas.ShowDialog();
        }

        private void CambioEstructuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCambioEstructura frmCambioEstructura = new FrmCambioEstructura();
            frmCambioEstructura.ShowDialog();
        }

        private void ComprimirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComprimir frmComprimir = new FrmComprimir();
            frmComprimir.ShowDialog();
        }

        private void RIPSFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactura frmFactura = new FrmFactura();
            frmFactura.ShowDialog();
        }

        private void RIPSNuevaEPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaEPS frmNuevaEPS = new FrmNuevaEPS();
            frmNuevaEPS.ShowDialog();
        }

        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void coosaludToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArchivosCoosalud FrmArchivosCoosalud = new FrmArchivosCoosalud();
            FrmArchivosCoosalud.ShowDialog();
        }
    }
}