﻿using FilesFolders.ManejoArchivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class FrmArchivosSura : Form
    {
        public FrmArchivosSura()
        {
            InitializeComponent();
        }
        private void FrmArchivosSura_Load(object sender, EventArgs e)
        {
            // Limpiamos la Etiqueta Status
            lblStatus.Visible = false;
        }

        #region Variables

        string dirPath;
        string extensionArchivo;
        string nombreArchivo;
        string nombreAnteriorArchivo;
        string nombreNuevoArchivo;
        string numeroFactura;
        string separadorCarpeta;
        string directoryName;
        string fullDirectoryName;
        int numeroArchivos;
        long progressValue;

        public List<string> ListaArchivos { get; private set; }
        public List<string> ListaArchivosFullNameRecursive { get; private set; }

        public List<string> ListaArchivosFullName { get; private set; }
        public List<string> ListaCarpetas { get; private set; }

        public List<string> ListaCarpetasRIPS { get; private set; }

        readonly CArchivos Lista = new CArchivos();

        readonly CWork bgwArchivo = new CWork();

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            // Ubicación de la Carpeta con los SOPORTES
            if (fbdArchivosSura.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = fbdArchivosSura.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = fbdArchivosSura.SelectedPath;
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

            // Obtener Nombres de Directorios
            //DirectoryInfo informacionDirectorio = new DirectoryInfo(dirPath);

            // Almacenamos los nombres completos de los archivos en la variable ListaArchivosFullNameRecursive
            ListaArchivosFullNameRecursive = Lista.ListarArchivosFullNameRecursive(dirPath, "*.pdf");

            // Obtenemos el Numero de Archivos
            numeroArchivos = ListaArchivosFullNameRecursive.Count();

            // Almacenamos en la variable Tipo Lista los nombres de los archivos
            ListaArchivos = Lista.ListarArchivosNameRecursive(dirPath, "*.pdf");

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

                // Obtenemos el Numero de la Factura
                numeroFactura = ExtractNumber(directoryName);

                // Obtenemos el Nombre del Archivo
                nombreArchivo = Path.GetFileName(item);

                // Obtenemos la Extensión del archivo
                extensionArchivo = Path.GetExtension(nombreArchivo);

                // Establecemos las variables para el nombre del archivo
                string tipoSoporteFactura = "IMGFACTURA";
                string tipoSoporte = "IMGSOPORTES";
                string nitSopore = "890981494";
                string alfaSoporte = "FE";

                if (nombreArchivo.StartsWith("FE"))
                {
                    // Establecer el Nombre Anterior del Archivo
                    nombreAnteriorArchivo = string.Format("{0}{1}{2}", fullDirectoryName, separadorCarpeta, nombreArchivo);

                    // Establecer el Nombre Nuevo del Archivo
                    nombreNuevoArchivo = string.Format("{0}{1}{2}_{3}_{4}{5}{6}", fullDirectoryName, separadorCarpeta, tipoSoporteFactura, nitSopore, alfaSoporte, numeroFactura, extensionArchivo);

                    // Renombrar archvios
                    File.Move(nombreAnteriorArchivo, nombreNuevoArchivo);
                }
                else if (nombreArchivo.StartsWith("SOPORTE"))
                {
                    // Establecer el Nombre Anterior del Archivo
                    nombreAnteriorArchivo = string.Format("{0}{1}{2}", fullDirectoryName, separadorCarpeta, nombreArchivo);

                    // Establecer el Nombre Nuevo del Archivo
                    nombreNuevoArchivo = string.Format("{0}{1}{2}_{3}_{4}{5}{6}", fullDirectoryName, separadorCarpeta, tipoSoporte, nitSopore, alfaSoporte, numeroFactura, extensionArchivo);

                    // Renombrar archvios
                    File.Move(nombreAnteriorArchivo, nombreNuevoArchivo);
                }

                // Actualizar Barra de Progreso
                bgwArchivo.ReportProgress((int)progressValue);
            }

            // Recorremos Carpetas Principales
            foreach (var folder in ListaCarpetas)
            {
                // Obtenemos nombre de la carpeta que contiene los archivos
                directoryName = new DirectoryInfo(folder).Name;

                // Almacenamos los nombres de los archivos
                ListaArchivosFullName = Lista.ListarArchivosFullNameRecursive(folder, "*.pdf");

                // Extaemos el Número de la Factura
                string numeroFactura = ExtractNumber(directoryName);

                // Establecemos las variables para el nombre de la carpeta
                string nit = "890981494";
                string prefijo = "FE";
                string valorAF = "";
                string sufijo = "PBS";
                string nombreCarpeta = "";

                // Almacenamos en la variable Tipo Lista los nombres de la Carpetas que Contienen los RIPS
                ListaCarpetasRIPS = Lista.ListarNombresCarpetas(folder);

                // Recorremos Subcarpeta con RIPS
                foreach (var folderRIPS in ListaCarpetasRIPS)
                {
                    // Obtenemos el Valor del AF
                    valorAF = Lista.valorAF(folderRIPS, "*AF*");
                }

                int valor = (int)Convert.ToDouble(valorAF);

                nombreCarpeta = string.Format("{0}_{1}_{2}_{3}_{4}", nit, prefijo, numeroFactura, valor, sufijo);

                string nuevaCarpeta = string.Format("{0}\\{1}", folder, nombreCarpeta);

                // Creamos Carpeta Principal Con Soportes en PDF
                Directory.CreateDirectory(nuevaCarpeta);

                // Mover Soportes en PDF a la Nueva Carpeta Creada

                foreach (var item in ListaArchivosFullName)
                {
                    string sourceFile = item;
                    string fileName = Path.GetFileName(item);
                    string destinationFile = string.Format("{0}\\{1}", nuevaCarpeta, fileName);

                    File.Move(sourceFile, destinationFile);
                }
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