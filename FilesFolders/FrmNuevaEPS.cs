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

            // Limpiamos la Etiqueta Status
            lblStatus.Visible = false;
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            // Ubicación de la Carpeta con los RIPS
            if (fbdNueva.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = fbdNueva.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = fbdNueva.SelectedPath;

                // Habilitamos el Boton
                btnIniciar.Enabled = true;

                prgBarNE.Maximum = dirPath.Length;
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
    }
}
