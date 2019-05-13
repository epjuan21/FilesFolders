﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class FrmComprimir : Form
    {
        public FrmComprimir()
        {
            InitializeComponent();
        }

        #region Variables
        string dirPath;
        string FileName;
        #endregion

        private void FrmComprimir_Load(object sender, EventArgs e)
        {
            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnComprimir.Enabled = false;

            // Inhabilitar Campos de Texto Hasta Seleccionar Ruta
            txtFechaCorte.Enabled = false;
            txtNumeroIdEntidad.Enabled = false;
            txtConsecutivo.Enabled = false;

            cmbTipoIdEntidad.Enabled = false;
            cmbRegimen.Enabled = false;
            cmbExtension.Enabled = false;

            // EABP

            // Comprimir Archivo

            // Cargar Valores Predeterminados en TextBox

            txtModuloInformacion.Enabled = false;
            txtModuloInformacion.Text = "RIP";

            txtTipoFuente.Enabled = false;
            txtTipoFuente.Text = "170";

            txtTema.Enabled = false;
            txtTema.Text = "RIPS";

            // Combo Box No Editable
            cmbTipoIdEntidad.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbRegimen.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbTipoIdEntidad.SelectedIndex = 0;

            txtNumeroIdEntidad.Text = "";

            cmbRegimen.SelectedIndex = 2;

            txtConsecutivo.Text = "01";

            cmbExtension.SelectedIndex = 0;

            // Nombre Archvio Comprimido EAPB

            txtFechaCorte.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            cmbTipoIdEntidad.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            txtNumeroIdEntidad.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            cmbRegimen.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            txtConsecutivo.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            cmbExtension.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);

            lblNombreArchivo.Text = txtModuloInformacion.Text + txtTipoFuente.Text + txtTema.Text + txtFechaCorte.Text + cmbTipoIdEntidad.Text + txtNumeroIdEntidad.Text + cmbRegimen.Text + txtConsecutivo.Text + cmbExtension.Text;
        }

        private void btnRutaEAPB_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaEAPB.Text = folderBrowserDialog1.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = folderBrowserDialog1.SelectedPath;

                // Habilitar Boton de Comprimir
                btnComprimir.Enabled = true;

                // Habilitar Campos de Texto
                txtFechaCorte.Enabled = true;
                txtNumeroIdEntidad.Enabled = true;
                txtConsecutivo.Enabled = true;

                cmbTipoIdEntidad.Enabled = true;
                cmbRegimen.Enabled = true;
                cmbExtension.Enabled = true;
            }
        }

        private void txtFechaCorte_TextChanged(object sender, EventArgs e)
        {
            // Obtenemos la candidad de digitos en el Campo Numero Id Entidad
            int charCount = txtNumeroIdEntidad.Text.Length;

            //Etablecemos la Cantidad Maxima de Digitos Permitidos
            const int charIdEntidad = 12;

            // Variable para establecer los digitos faltantes en el campo
            int charLeft = charIdEntidad - charCount;

            string ceros = "0";

            if (charLeft > 0 && charLeft < 12)
            {
                for (int i = 1; i < charLeft; i++)
                {
                    ceros = ceros + "0";
                }
            }

            FileName = txtModuloInformacion.Text + txtTipoFuente.Text + txtTema.Text + txtFechaCorte.Text + cmbTipoIdEntidad.Text + ceros + txtNumeroIdEntidad.Text + cmbRegimen.Text + txtConsecutivo.Text + cmbExtension.Text;
            lblNombreArchivo.Text = FileName;
        }

        private void ZipDirFile(string dir)
        {
            string parent = Path.GetDirectoryName(dir);
            Process.Start(parent);
            //string name = Path.GetFileName(dir);
            string fileName = Path.Combine(parent, FileName);
            ZipFile.CreateFromDirectory(dir, fileName, CompressionLevel.Fastest, false);
        }

        private void btnComprimir_Click(object sender, EventArgs e)
        {
            ZipDirFile(dirPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
