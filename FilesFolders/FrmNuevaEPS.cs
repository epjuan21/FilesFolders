using FilesFolders.ManejoArchivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class FrmNuevaEPS : Form
    {
        public FrmNuevaEPS()
        {
            InitializeComponent();
        }

        #region Variables

        readonly CWork bgwNuevaEPS = new CWork();

        string dirPath;

        string TipoArchivo;
        string ExtensionArchivo;
        string NombreAnteriorArchivo;
        string NombreNuevoArchivo;
        string NombreArchivoComprimido;
        string PeriodoArchivo;
        string SeparadorCarpeta;
        string SeparadorNombre;
        long ProgressValue;

        public List<string> ListaArchivos { get; private set; }
        public List<string> ListaArchivosFullName { get; private set; }

        readonly CArchivos Lista = new CArchivos();
        #endregion

        private void FrmNuevaEPS_Load(object sender, EventArgs e)
        {
            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnIniciar.Enabled = false;
            btnComprimir.Enabled = false;

            // Botones inhabilitados por defecto
            txtTipo.Enabled = false;
            txtCodigoHabilitacion.Enabled = false;
            txtPeriodo.Enabled = false;
            txtExtension.Enabled = false;

            // Limpiamos la Etiqueta Status
            lblStatus.Visible = false;

            // Carga de Valores Predeterminados
            txtTipo.Text = "RIPS";
            txtCodigoHabilitacion.Text = "050910457201";
            txtExtension.Text = ".zip";

            // Establecemos Separador
            SeparadorNombre = "_";

            // Establecemos el Nombre del Archivo
            txtPeriodo.TextChanged += new System.EventHandler(this.TxtPeriodo_TextChanged);
            lblNombre.Text = txtTipo.Text + SeparadorNombre + txtCodigoHabilitacion.Text + txtPeriodo.Text + txtExtension.Text;
        }

        private void BtnRuta_Click(object sender, EventArgs e)
        {
            // Ubicación de la Carpeta con los RIPS
            if (fbdNueva.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = fbdNueva.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = fbdNueva.SelectedPath;

                // Habilitamos los Botones
                btnIniciar.Enabled = true;
                btnComprimir.Enabled = true;

                // Habilitamos Campos de Text
                txtTipo.Enabled = true;
                txtCodigoHabilitacion.Enabled = true;
                txtPeriodo.Enabled = true;
                txtExtension.Enabled = true;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            if (txtNombreArchivo.Text == "")
            {
                MessageBox.Show("Debe Digitar el Nombre del Archivo");
                txtNombreArchivo.Focus();
            }
            else
            {
                bgwNuevaEPS.ODoWorker(BgwNuevaEPS_DoWork, BgwNuevaEPS_ProgressChanged, BgwNuevaEPS_RunWorkerCompleted);
            }
        }

        private void BgwNuevaEPS_DoWork(object sender, DoWorkEventArgs e)
        {
            // Inicializamos el valor de la Barra de Progreso en 0
            ProgressValue = 0;

            // Almacenamos en la variable Tipo Lista los nombres de los archivos
            ListaArchivos = Lista.ListarArchivosName(dirPath, "*.txt");

            // Almacenamos los nombres completos de los archivos en la variable ListaArchivosFullName
            ListaArchivosFullName = Lista.ListarArchivosFullName(dirPath, "*.txt");

            System.IO.FileInfo[] files = new System.IO.DirectoryInfo(dirPath).GetFiles();

            PeriodoArchivo = txtNombreArchivo.Text;
            SeparadorCarpeta = "\\";

            // Cambiar Nombres de Archivos
            foreach (var item in files)
            {
                // Incrementamos el valor de la barra de progreso
                ProgressValue++;

                // Obtenemos el Tipo de archivo
                TipoArchivo = item.Name.Substring(0, 2);

                // Obtenemos la Extensión del archivo
                ExtensionArchivo = Path.GetExtension(item.Name);

                // Establecer el Nombre Anterior del Archivo
                NombreAnteriorArchivo = string.Format("{0}{1}{2}", dirPath, SeparadorCarpeta, item.Name);

                // Establecer el Nombre Nuevo del Archivo
                NombreNuevoArchivo = string.Format("{0}{1}{2}{3}{4}", dirPath, SeparadorCarpeta, TipoArchivo, PeriodoArchivo, ExtensionArchivo);

                // Renombrar archvios
                File.Move(NombreAnteriorArchivo, NombreNuevoArchivo);

                // Actualizar Barra de Progreso
                bgwNuevaEPS.ReportProgress((int)ProgressValue);
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
                                string NuevoNombre = txtNombreArchivo.Text;

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

            for (int i = 1; i <= ProgressValue; i++)
            {
                bgwNuevaEPS.ReportProgress(Convert.ToInt32(i * 100 / ProgressValue));
                System.Threading.Thread.Sleep(100);
            }
        }

        private void BgwNuevaEPS_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Visible = true;
            prgBarNE.Value = e.ProgressPercentage;
            prgBarNE.Update();
            lblStatus.Text = "Procesando...... " + prgBarNE.Value.ToString() + "%";
        }

        private void BgwNuevaEPS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Finalizado";
        }
        private void BtnComprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPeriodo.Text))
            {
                MessageBox.Show("Se debe especificar el oeriodo del archivo", "Advertencia");
            }
            else
            {
                ZipDirFile(dirPath);
            }
        }

        private void TxtPeriodo_TextChanged(object sender, EventArgs e)
        {
            NombreArchivoComprimido = txtTipo.Text + SeparadorNombre + txtCodigoHabilitacion.Text + SeparadorNombre + txtPeriodo.Text + txtExtension.Text;
            lblNombre.Text = NombreArchivoComprimido;
        }

        private void ZipDirFile(string dir)
        {
            string parent = Path.GetDirectoryName(dir);
            Process.Start(parent);
            //string name = Path.GetFileName(dir);
            string fileName = Path.Combine(parent, NombreArchivoComprimido);
            ZipFile.CreateFromDirectory(dir, fileName, CompressionLevel.Fastest, false);
        }
    }
}