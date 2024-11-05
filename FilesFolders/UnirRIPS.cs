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
    public partial class FrmUnirRIPS : Form
    {
        public FrmUnirRIPS()
        {
            InitializeComponent();
        }

        #region Variables
        string dirPath;
        string dirPathDestino;
        string nombreArchivos;
        string codigoHabilitacion;
        DateTime fechaControl = DateTime.Now; // Fecha de control
        #endregion

        private void FrmUnirRIPS_Load(object sender, EventArgs e)
        {
            btnIniciar.Enabled = false;
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            // Ubicación de la Carpeta con los RIPS
            if (fbdUnir.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = fbdUnir.SelectedPath;
                dirPath = fbdUnir.SelectedPath;
                btnIniciar.Enabled = true;
            }
        }

        private void btnRutaDestino_Click(object sender, EventArgs e)
        {
            // Ubicación de la Carpeta de Destino
            if (fbdRutaDestino.ShowDialog() == DialogResult.OK)
            {
                txtRutaDestino.Text = fbdRutaDestino.SelectedPath;
                dirPathDestino = fbdRutaDestino.SelectedPath;
                btnIniciar.Enabled = true;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Nombre Archivos
            nombreArchivos = txtNombreArchivos.Text;

            UnirArchivos();
            CrearArchivoControl();
        }

        private void UnirArchivos()
        {

            if (string.IsNullOrEmpty(dirPath) || string.IsNullOrEmpty(dirPathDestino) || string.IsNullOrEmpty(nombreArchivos))
            {
                MessageBox.Show("Por favor, completa las rutas de origen, destino y el nombre base de archivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Diccionario para almacenar el contenido unido de cada prefijo
                var archivosPorTipo = new Dictionary<string, List<string>>
                {
                    { "AC", new List<string>() }, { "AT", new List<string>() }, { "AM", new List<string>() },
                    { "AP", new List<string>() }, { "AF", new List<string>() }, { "US", new List<string>() },
                    { "AN", new List<string>() }, { "AH", new List<string>() }, { "AU", new List<string>() }
                };

                // Buscar todos los archivos .txt en la carpeta de origen de forma recursiva
                var archivosTxt = Directory.GetFiles(dirPath, "*.txt", SearchOption.AllDirectories);

                // Clasificar los archivos por prefijo
                foreach (var archivo in archivosTxt)
                {
                    string nombreArchivo = Path.GetFileName(archivo);
                    string prefijo = nombreArchivo.Substring(0, 2); // Obtener los dos primeros caracteres

                    if (archivosPorTipo.ContainsKey(prefijo))
                    {
                        // Agregar el contenido del archivo a la lista correspondiente
                        archivosPorTipo[prefijo].Add(File.ReadAllText(archivo));
                    }
                }

                // Guardar los archivos unidos en la carpeta de destino
                foreach (var tipo in archivosPorTipo.Keys)
                {
                    if (archivosPorTipo[tipo].Count > 0)
                    {
                        string rutaDestino = Path.Combine(dirPathDestino, $"{tipo}{nombreArchivos}.txt");
                        File.WriteAllText(rutaDestino, string.Join(Environment.NewLine, archivosPorTipo[tipo]));
                    }
                }

                MessageBox.Show("Archivos unidos y guardados correctamente en la ruta de destino.", "Proceso Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearArchivoControl()
        {
            // Nombre del archivo CT con el periodo en formato MMYYYY
            codigoHabilitacion = txtCodigoHabilitacion.Text;
            string periodo = fechaControl.ToString("MMyyyy");
            string nombreArchivoCT = $"CT{periodo}.txt";
            string rutaArchivoCT = Path.Combine(dirPathDestino, nombreArchivoCT);

            using (var escritorCT = new StreamWriter(rutaArchivoCT, false))
            {
                // Obtener todos los archivos en la ruta de destino que no sean el archivo CT que estamos creando
                foreach (string archivo in Directory.GetFiles(dirPathDestino, "*.txt")
                                                     .Where(f => Path.GetFileName(f) != nombreArchivoCT))
                {
                    string nombreArchivo = Path.GetFileName(archivo);
                    int lineasConDatos = File.ReadLines(archivo).Count(linea => !string.IsNullOrWhiteSpace(linea));

                    // Formato de cada línea en el archivo CT
                    string lineaCT = $"{codigoHabilitacion},{fechaControl:dd/MM/yyyy},{nombreArchivo},{lineasConDatos}";
                    escritorCT.WriteLine(lineaCT);
                }
            }
        }
    }
}
