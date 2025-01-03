﻿using System;
using System.Reflection;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rIPSMasivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRIPS frmRIPS = new FrmRIPS();
            frmRIPS.ShowDialog();
        }

        private void modificarNombresDeSoportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArchivosSura FrmArchivosSura = new FrmArchivosSura();
            FrmArchivosSura.ShowDialog();
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

        private void nuevaEPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaEPS frmNuevaEPS = new FrmNuevaEPS();
            frmNuevaEPS.ShowDialog();
        }

        private void soportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArchivosCoosalud FrmArchivosCoosalud = new FrmArchivosCoosalud();
            FrmArchivosCoosalud.ShowDialog();
        }

        private void resumenRIPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRIPSIndividual frmRIPSIndividual = new FrmRIPSIndividual();
            frmRIPSIndividual.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            tsslVersion.Text = version.ToString();
        }

        private void unirRIPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnirRIPS frmUnirRIPS = new FrmUnirRIPS();
            frmUnirRIPS.ShowDialog();
        }
    }
}
