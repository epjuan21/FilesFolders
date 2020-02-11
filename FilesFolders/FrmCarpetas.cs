using FilesFolders.ManejoArchivos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class FrmCarpetas : Form
    {
        public FrmCarpetas()
        {
            InitializeComponent();
        }

        #region Variables
        string dirPath;
        CArchivos Lista = new CArchivos();
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRutaCarpeta_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaCarpeta.Text = folderBrowserDialog1.SelectedPath;

                // Ruta Directorio
                dirPath = folderBrowserDialog1.SelectedPath;

                #region Variables
                // Creamos una Variable Tipo Lista para almacenar los nombres de los archivos
                List<string> ListaArchivos = new List<string>();

                // Creamos una lista para almacenar los numeros de Factura Temporales
                List<string> ListaNumerosFactura = new List<string>();

                // Creamos una lista para almacenar los numeros de Factura Unicos
                List<string> ListaNumerosFacturaUnicos = new List<string>();

                // Creamos una variable tipo lista para obtener el numbre completo de cada archvio, que incluye la ruta
                List<string> ListaArchivosFullName = new List<string>();

                // Cremos una variable tipo Lista para almacenar los nombres de los directorios nuevos creados
                //List<string> ListaDirectorios = new List<string>();

                #endregion

                // Almacenamos en la variable Tipo Lista los nombres de los archivos
                ListaArchivos = Lista.ListarArchivosName(dirPath, "*.txt");

                // Almacenamos los nombres completos de los archivos en la variable ListaArchivosFullName
                ListaArchivosFullName = Lista.ListarArchivosFullName(dirPath, "*.txt");

                foreach (var NombreArchivo in ListaArchivos)
                {
                    String IdFactura;

                    // Obtener el Numero de la Factura
                    IdFactura = NombreArchivo.Substring(2, 6);

                    // Agregamos los IdFactura a la Lista de Numeros de Factura
                    ListaNumerosFactura.Add(IdFactura);
                }

                // Leemos los Nombres de las Facturas almacendads en ListaNumerosFacturas
                // Si en ListaNumerosFacturaUnicos existe el Número de ListaNumerosFactura, no hace nada
                // Si no existe lo ingresa en ListaNumerosFacturaUnicos
                foreach (var Numeros in ListaNumerosFactura)
                {
                    if (ListaNumerosFacturaUnicos.Contains(Numeros))
                    {
                        //MessageBox.Show("Contiene el numero " + Numeros);
                    }
                    else
                    {
                        //MessageBox.Show("No Contiene el numero " + Numeros);
                        ListaNumerosFacturaUnicos.Add(Numeros);
                    }
                }

                // Leemos los numeros unicos y creamos las carpetas con cada nombre
                foreach (var NumeroUnico in ListaNumerosFacturaUnicos)
                {
                    // Directorio
                    string folderName = dirPath;

                    // SubCarpetas - Nombres de Facturas Unicas
                    string pathString = System.IO.Path.Combine(folderName, NumeroUnico);

                    //Creacion de Carpetas
                    System.IO.Directory.CreateDirectory(pathString);
                }

                // Mover Archivos a sus Respectivos Directorios

                // Almacenamos en un arreglo el listado de los Directorios Nuevos
                string[] ListaDirectorios = System.IO.Directory.GetDirectories(dirPath);

                foreach (var Directorios in ListaDirectorios)
                {
                    foreach (var Archivo in ListaArchivosFullName)
                    {
                        // NOMBRE CARPETA

                        // Obtenemos la posicion del ultimo BackSlach para identificar donde empieza el nombre del Directorio
                        // Se añade 1 para no obtener el BackSlach
                        int PosicionUltimoSlash = Directorios.LastIndexOf("\\") + 1;
                        // Obtenemos la longitud total de la cadena
                        int LongitudNombre = Directorios.Length;
                        // Obtenemos el Nombre de la Carpeta
                        string nombreDirectorio = Directorios.Substring(PosicionUltimoSlash, LongitudNombre - PosicionUltimoSlash);

                        // NOMBRE ARCHIVO

                        // Obtenemos la posicion del ultimo BackSlach para identificar donde empieza el nombre del Archivo
                        // Se suman dos posiciones para quitar el BackSlach y las Iniciales del Archivo de RIPS
                        int PosicionUltimoSlashArchivo = Archivo.LastIndexOf("\\") + 3;
                        // Obtenemos la longitud total de la cadena
                        // Se restan 4 posiciones por la extension de los archivos
                        int LongitudNombreArchivo = Archivo.Length - 4;
                        // Obtenemos el Nombre del Archivo
                        string nombreArchivo = Archivo.Substring(PosicionUltimoSlashArchivo, LongitudNombreArchivo - PosicionUltimoSlashArchivo);

                        // Obtenemos el Nombre del Archivo incluida la Extension
                        int Slash = Archivo.LastIndexOf("\\") + 1;
                        int Longitud = Archivo.Length;
                        string nombreCompleto = Archivo.Substring(Slash, Longitud - Slash);

                        if (nombreArchivo == nombreDirectorio)
                        {
                            string archivoOrigen = Archivo;
                            string archivoDestino = System.IO.Path.Combine(Directorios, nombreCompleto);

                            System.IO.File.Move(archivoOrigen, archivoDestino);
                        }
                    }
                }
            }
        }
    }
}
