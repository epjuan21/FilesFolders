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
    public partial class FrmArchivosCoosalud : Form
    {
        public FrmArchivosCoosalud()
        {
            InitializeComponent();
        }

        private void FrmArchivosCoosalud_Load(object sender, EventArgs e)
        {
            // Limpiamos la Etiqueta Status
            lblStatus.Visible = false;
        }

        #region Variables
        string dirPath;
        long progressValue;
        int numeroArchivos;
        string separadorCarpeta;
        string directoryName;
        string fullDirectoryName;
        string numeroFactura;
        string nombreArchivo;
        string extensionArchivo;
        string nombreAnteriorArchivo;
        string nombreNuevoArchivo;

        readonly CArchivos Lista = new CArchivos();
        public List<string> ListaArchivosFullNameRecursive { get; private set; }
        public List<string> ListaCarpetas { get; private set; }


        readonly CWork bgwArchivo = new CWork();

        #endregion

        private void btnRuta_Click(object sender, EventArgs e)
        {
            // Ubicacion de la carpeta de Soportes de COOSALUD
            if (fbdArchivosCoosalud.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = fbdArchivosCoosalud.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = fbdArchivosCoosalud.SelectedPath;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            bgwArchivo.ODoWorker(BgwSuraArchivos_DoWork, BgwSuraArchivos_ProgressChanged, BgwSuraArchivos_RunWorkerCompleted);
        }

        private void BgwSuraArchivos_DoWork(object sender, DoWorkEventArgs e)
        {
            // Inicializamos el valor de la Barra de Progreso en 0
            progressValue = 0;

            // Almacenamos los nombres de los archivos incluyendo sus rutas
            ListaArchivosFullNameRecursive = Lista.ListarArchivosFullNameRecursive(dirPath, "*.pdf");

            // Obtenemos el Numero de Archivos
            numeroArchivos = ListaArchivosFullNameRecursive.Count();

            // Almacenamos en la variable Tipo Lista los nombres de la Subcarpetas del la Carpeta Principal
            ListaCarpetas = Lista.ListarNombresCarpetas(dirPath);

            // Separador Carpetas
            separadorCarpeta = "\\";

            foreach (var item in ListaArchivosFullNameRecursive)
            {
                // Incrementamos el valor de la barra de progreso
                progressValue++;

                // Obtenemos nombre de la carpeta que contiene los archivos
                directoryName = Path.GetFileName(Path.GetDirectoryName(item));

                // Obtenemos la ruta completa
                fullDirectoryName = Path.GetDirectoryName(item);

                // Extaemos el Número de la Factura
                string numeroFactura = ExtractNumber(directoryName);

                // Obtenemos el Nombre del Archivo
                nombreArchivo = Path.GetFileName(item);

                // Obtenemos la Extensión del archivo
                extensionArchivo = Path.GetExtension(nombreArchivo);

                // Establecemos el prefijo para el nombre del archivo
                string prefijo = "FE";
                string carpetaFactura = "Factura";
                string carpetaSoportes = "Soportes";

                if (nombreArchivo.StartsWith("FE"))
                {
                    // Establecer el Nombre Anterior del Archivo
                    nombreAnteriorArchivo = string.Format("{0}{1}{2}", fullDirectoryName, separadorCarpeta, nombreArchivo);              

                    // Establere Nombre y Ruta Completa de la Nueva Carpeta para la Factura
                    string nuevaCarpeta = string.Format("{0}\\{1}", fullDirectoryName, carpetaFactura);

                    Directory.CreateDirectory(nuevaCarpeta);

                    // Establecer el Nombre Nuevo del Archivo
                    nombreNuevoArchivo = string.Format("{0}{1}{2}{3}{4}", nuevaCarpeta, separadorCarpeta, prefijo, numeroFactura, extensionArchivo);

                    // Renombrar archvios
                    File.Move(nombreAnteriorArchivo, nombreNuevoArchivo);

                }
                else if (nombreArchivo.StartsWith("SOPOR"))
                {
                    // Establecer el Nombre Anterior del Archivo
                    nombreAnteriorArchivo = string.Format("{0}{1}{2}", fullDirectoryName, separadorCarpeta, nombreArchivo);

                    // Establere Nombre y Ruta Completa de la Nueva Carpeta para la Factura
                    string nuevaCarpeta = string.Format("{0}\\{1}", fullDirectoryName, carpetaSoportes);

                    Directory.CreateDirectory(nuevaCarpeta);

                    // Establecer el Nombre Nuevo del Archivo
                    nombreNuevoArchivo = string.Format("{0}{1}{2}{3}{4}", nuevaCarpeta, separadorCarpeta, prefijo, numeroFactura, extensionArchivo);

                    // Renombrar archvios
                    File.Move(nombreAnteriorArchivo, nombreNuevoArchivo);
                }

                // Actualizar Barra de Progreso
                bgwArchivo.ReportProgress((int)progressValue);

            }
        }

        private void BgwSuraArchivos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Visible = true;
            prgBar.Maximum = numeroArchivos;
            prgBar.Value = e.ProgressPercentage;
            prgBar.Update();
            lblStatus.Text = "Procesando...... " + prgBar.Value.ToString() + "%";
        }

        private void BgwSuraArchivos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Finalizado";
        }
        public string ExtractNumber(string original)
        {
            return new string(original.Where(c => Char.IsDigit(c)).ToArray());
        }

    }
}
