using System;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class FrmRIPSIndividual : Form
    {
        public FrmRIPSIndividual()
        {
            InitializeComponent();
        }

        #region Ruta Cargue Individual
        private void BtnRutaIndividual_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaIndividual.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        #endregion

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
