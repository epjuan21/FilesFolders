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

        #region Variables

        CArchivos LineasUS = new CArchivos();
        CArchivos LineasAC = new CArchivos();
        CArchivos Lista = new CArchivos();
        #endregion

        #region FormLoad
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Menu
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rIPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRIPS frmRIPS = new FrmRIPS();
            frmRIPS.ShowDialog();
        }

        private void rIPSIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRIPSIndividual frmRIPSIndividual = new FrmRIPSIndividual();
            frmRIPSIndividual.ShowDialog();
        }

        private void rIPSCarpetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCarpetas frmCarpetas = new FrmCarpetas();
            frmCarpetas.ShowDialog();
        }

        private void rIPSEAPBToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void cambioEstructuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCambioEstructura frmCambioEstructura = new FrmCambioEstructura();
            frmCambioEstructura.ShowDialog();
        }

        private void comprimirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComprimir frmComprimir = new FrmComprimir();
            frmComprimir.ShowDialog();
        }

        private void rIPSFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactura frmFactura = new FrmFactura();
            frmFactura.ShowDialog();
        }

        private void rIPSNuevaEPSToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}