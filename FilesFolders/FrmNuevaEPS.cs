using FilesFolders.ManejoArchivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        CWork bgwNuevaEPS = new CWork();

        string dirPath;

        string TipoArchivo;
        string ExtensionArchivo;
        string NombreAnteriorArchivo;
        string NombreNuevoArchivo;
        string PeriodoArchivo;
        string SeparadorCarpeta;
        long ProgressValue;

        // Creamos una Variable Tipo Lista para almacenar los nombres de los archivos
        List<string> ListaArchivos = new List<string>();

        // Creamos una variable tipo lista para obtener el numbre completo de cada archvio, que incluye la ruta
        List<string> ListaArchivosFullName = new List<string>();

        CArchivos Lista = new CArchivos();
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

            // Carga de Valores Predeterminados por Defecto
        }

        private void btnRuta_Click(object sender, EventArgs e)
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
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtNombreArchivo.Text == "")
            {
                MessageBox.Show("Debe Digitar el Nombre del Archivo");
                txtNombreArchivo.Focus();
            }
            else
            {
                bgwNuevaEPS.ODoWorker(bgwNuevaEPS_DoWork, bgwNuevaEPS_ProgressChanged, bgwNuevaEPS_RunWorkerCompleted);
            }
        }

        private void bgwNuevaEPS_DoWork(object sender, DoWorkEventArgs e)
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

        private void bgwNuevaEPS_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Visible = true;
            prgBarNE.Value = e.ProgressPercentage;
            prgBarNE.Update();
            lblStatus.Text = "Procesando...... " + prgBarNE.Value.ToString() + "%";
        }

        private void bgwNuevaEPS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Finalizado";
        }

        private void btnComprimir_Click(object sender, EventArgs e)
        {

        }

    }
}
