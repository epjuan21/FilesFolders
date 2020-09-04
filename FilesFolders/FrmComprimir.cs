using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
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
            // Tab Index - Orden en la Tabulaciones
            btnRutaEAPB.TabIndex = 0;
            cmbTipoFuente.TabIndex = 1;
            txtFechaCorte.TabIndex = 2;
            cmbTipoIdEntidad.TabIndex = 3;
            txtNumeroIdEntidad.TabIndex = 4;
            cmbRegimen.TabIndex = 5;
            txtConsecutivo.TabIndex = 6;
            cmbExtension.TabIndex = 7;
            btnComprimir.TabIndex = 8;
            btnSalir.TabIndex = 9;
            
            // TextBox Inhabilitados Permanentemente
            txtModuloInformacion.Enabled = false;
            txtTema.Enabled = false;

            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnComprimir.Enabled = false;

            // Inhabilitar TextBox Hasta Seleccionar Ruta
            txtFechaCorte.Enabled = false;
            txtNumeroIdEntidad.Enabled = false;
            txtConsecutivo.Enabled = false;

            // Inhabilitar ComboBox Hasta Seleccionar Ruta
            cmbTipoFuente.Enabled = false;
            cmbTipoIdEntidad.Enabled = false;
            cmbRegimen.Enabled = false;
            cmbExtension.Enabled = false;

            // Comprimir Archivo

            // Cargar Valores Predeterminados en TextBox

            txtModuloInformacion.Text = "RIP";
            txtTema.Text = "RIPS";

            // Combo Box No Editable
            cmbTipoFuente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoIdEntidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRegimen.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargar valores predeterminados en ComboBox
            cmbTipoFuente.SelectedIndex = 0;
            cmbTipoIdEntidad.SelectedIndex = 0;
            cmbRegimen.SelectedIndex = 2;
            cmbExtension.SelectedIndex = 0;

            txtNumeroIdEntidad.Text = "";
            txtConsecutivo.Text = "01";

            // Nombre Archivo Comprimido EAPB

            cmbTipoFuente.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            txtFechaCorte.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            cmbTipoIdEntidad.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            txtNumeroIdEntidad.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            cmbRegimen.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            txtConsecutivo.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            cmbExtension.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);

            lblNombreArchivo.Text = txtModuloInformacion.Text + cmbTipoFuente.Text + txtTema.Text + txtFechaCorte.Text + cmbTipoIdEntidad.Text + txtNumeroIdEntidad.Text + cmbRegimen.Text + txtConsecutivo.Text + cmbExtension.Text;
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

                cmbTipoFuente.Enabled = true;
                cmbTipoIdEntidad.Enabled = true;
                cmbRegimen.Enabled = true;
                cmbExtension.Enabled = true;

                // Focus
                cmbTipoFuente.Focus();
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

            // Obtenemos el Item Seleccinadoi en Tipo Fuente
            // Si seleccionamos el Item 2 que es 165COVI, entonces en el nombre del archvio no debe ir el Tema de Información
            int selectedIndex = cmbTipoFuente.SelectedIndex;

            if (selectedIndex == 2) 
            {
                FileName = txtModuloInformacion.Text + cmbTipoFuente.Text + txtFechaCorte.Text + cmbTipoIdEntidad.Text + ceros + txtNumeroIdEntidad.Text + cmbRegimen.Text + txtConsecutivo.Text + cmbExtension.Text;
            }
            else
            {
                FileName = txtModuloInformacion.Text + cmbTipoFuente.Text + txtTema.Text + txtFechaCorte.Text + cmbTipoIdEntidad.Text + ceros + txtNumeroIdEntidad.Text + cmbRegimen.Text + txtConsecutivo.Text + cmbExtension.Text;
            }

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
            cambiarNombreArchivos(dirPath, txtFechaCorte.Text);
            ZipDirFile(dirPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cambiarNombreArchivos(string dirPath, string periodo)
        {
            string SeparadorCarpeta;
            SeparadorCarpeta = "\\";

            string PeriodoArchivo;
            string Month = periodo.Substring(4, 2);
            string Year = periodo.Substring(0, 4);
            
            PeriodoArchivo = string.Format("{0}{1}",Month, Year);
            
            System.IO.FileInfo[] files = new System.IO.DirectoryInfo(dirPath).GetFiles();

            // Cambiar Nombres de Archivos
            foreach (var item in files)
            {
                // Obtenemos el Tipo de archivo
                string TipoArchivo;
                TipoArchivo = item.Name.Substring(0, 2);

                // Obtenemos la Extensión del archivo
                string ExtensionArchivo;
                ExtensionArchivo = Path.GetExtension(item.Name);

                // Establecer el Nombre Anterior del Archivo
                string NombreAnteriorArchivo;
                NombreAnteriorArchivo = string.Format("{0}{1}{2}", dirPath, SeparadorCarpeta, item.Name);

                // Establecer el Nombre Nuevo del Archivo
                string NombreNuevoArchivo;
                NombreNuevoArchivo = string.Format("{0}{1}{2}{3}{4}", dirPath, SeparadorCarpeta, TipoArchivo, PeriodoArchivo, ExtensionArchivo);

                // Renombrar archvios
                File.Move(NombreAnteriorArchivo, NombreNuevoArchivo);
            }

            // Cambiar Nombres de Archivos en CT

            DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (var fi in di.GetFiles("*CT*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Windows-1252")))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                #region Código del Archivo

                                // Código del Archivo - Posición 2
                                string codigoArchivo = split[2];

                                // Obtenemos el Tipo de Archivo
                                string Tipo = codigoArchivo.Substring(0, 2);

                                // Obtenemos el Nuevo Nombre de los Archivos
                                string NuevoNombre = PeriodoArchivo;

                                // Reemplazamos el Nuevo Nombre
                                split[2] = string.Format("{0}{1}", Tipo, NuevoNombre);

                                line = String.Join(",", split);

                                #endregion
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("Windows-1252")))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

        }

    }
}
