﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FilesFolders.ManejoArchivos
{
    class CArchivos
    {

        private string NumeroLineas;
        private DirectoryInfo directory;
        private int Edad;
        private string UnidadMedidaEdad;

        public CArchivos()
        {
            NumeroLineas = "0";
        }

        /// <summary>
        /// Obtiene el número de lineas de un archivo de texto específico
        /// </summary>
        /// <param name="PathFile"></param>
        /// <returns></returns>
        public string ContarLineas(string PathFile)
        {
            if (File.Exists(PathFile))
            {
                using (StreamReader reader = new StreamReader(PathFile, Encoding.GetEncoding("Windows-1252")))
                {
                    NumeroLineas = File.ReadAllLines(PathFile).Length.ToString();
                }
            }
            else
            {
                MessageBox.Show("Archivo no Existe");
                return NumeroLineas = "0";
            }

            return NumeroLineas;
        }

        /// <summary>
        /// Retorna una Lista de todos los archivos de una carpeta según un criterio
        /// Muestra el Nombre completo del Archivo incluyendo la Ruta
        /// No tiene en cuenta subcarpetas
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public List<string> ListarArchivosFullName(string directoryPath, string searchPattern)
        {
            directory = new DirectoryInfo(directoryPath);

            List<string> files = new List<string>();

            foreach (var file in directory.GetFiles(searchPattern, SearchOption.TopDirectoryOnly))
            {
                String nameFile = file.FullName;
                files.Add(nameFile);
            }

            return files;
        }

        /// <summary>
        /// Retorna una Lista de todos los archivos de una carpeta según un criterio
        /// Muestra el Nombre completo del Archivo incluyendo la Ruta
        /// Tiene en cuenta Subcarpetas
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public List<string> ListarArchivosFullNameRecursive(string directoryPath, string searchPattern)
        {
            directory = new DirectoryInfo(directoryPath);

            List<string> files = new List<string>();

            foreach (var file in directory.GetFiles(searchPattern, SearchOption.AllDirectories))
            {
                String nameFile = file.FullName;
                files.Add(nameFile);
            }

            return files;
        }

        /// <summary>
        /// Retorna una Lista de todos los archivos de una carpeta según un criterio
        /// Muestra el Nombre del archivo Unicamente, sin incluir la ruta
        /// No incluye subcarpetas
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public List<string> ListarArchivosName(string directoryPath, string searchPattern)
        {
            directory = new DirectoryInfo(directoryPath);

            List<string> files = new List<string>();

            foreach (var file in directory.GetFiles(searchPattern, SearchOption.TopDirectoryOnly))
            {
                String nameFile = file.Name;
                files.Add(nameFile);
            }

            return files;
        }
        /// <summary>
        /// Retorna una Lista de todos los archivos de una carpeta según un criterio
        /// Muestra el Nombre del archivo Unicamente, sin incluir la ruta
        /// Incluye Subcarpetas
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public List<string> ListarArchivosNameRecursive(string directoryPath, string searchPattern)
        {
            directory = new DirectoryInfo(directoryPath);

            List<string> files = new List<string>();

            foreach (var file in directory.GetFiles(searchPattern, SearchOption.AllDirectories))
            {
                String nameFile = file.Name;
                files.Add(nameFile);
            }

            return files;
        }
        /// <summary>
        /// Retorna el numero de lineas de los archivos de una carpeta según un criterio
        /// No Incluye Subcarpetas
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public string Lineas(string directoryPath, string searchPattern)
        {
            directory = new DirectoryInfo(directoryPath);

            foreach (var item in directory.GetFiles(searchPattern))
            {
                if (item == null)
                {
                    NumeroLineas = "0";
                }
                else
                {
                    String nameFile = item.FullName;
                    NumeroLineas = ContarLineas(nameFile);
                }
            }

            return NumeroLineas;
        }
        /// <summary>
        /// Retorna una Lista de todos los nombrs de carpetas de una ruta especifica
        /// Muestra el nombre completo de la carpeta, incluyendo al ruta
        /// No incluye subcarpetas
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public List<string> ListarNombresCarpetas(string directoryPath)
        {
            directory = new DirectoryInfo(directoryPath);

            List<string> folders = new List<string>();

            foreach (var folder in directory.GetDirectories())
            {
                String nameFolder = folder.FullName;
                folders.Add(nameFolder);
            }

            return folders;
        }
        /// <summary>
        /// Obtiene la edad de un usuario segun su numero de documento
        /// Busca la edad en todos los archivos US de los directorios y subdirectorios
        /// </summary>
        /// <param name="NumeroDocumento">El número de documetno del Usuario</param>
        /// <param name="dirPath">La ruta del directorio raíz donde se buscarán los archivos</param>
        /// <returns>La edad del usuario como un número entero</returns>
        public int ObtenerEdad(String NumeroDocumento, string dirPath)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (var fi in di.GetFiles("*US*", SearchOption.AllDirectories))
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

                                // Posición Numero de Documento en el Archivo US
                                string NumeroDocumentoUS = split[1];

                                if (NumeroDocumento == NumeroDocumentoUS)
                                {
                                    // Edad - Posición 8 del Archivo US
                                    Edad = int.Parse(split[8]);
                                }
                            }

                            lines.Add(line);
                        }
                    }
                }
            }

            return Edad;
        }

        /// <summary>
        /// Obtiene la unidad de medida edad de un usuario segun su numero de documento
        /// Busca la unidad de medida de la edad en todos los archivos US de los directorios y subdirectorios
        /// </summary>
        /// <param name="NumeroDocumento">El número de documetno del Usuario</param>
        /// <param name="dirPath">La ruta del directorio raíz donde se buscarán los archivos</param>
        /// <returns>La edad del usuario como un número entero</returns>
        public string ObtenerUnidadMedidaEdad(String NumeroDocumento, string dirPath)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (var fi in di.GetFiles("*US*", SearchOption.AllDirectories))
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

                                string NumeroDocumentoUS = split[1];

                                if (NumeroDocumento == NumeroDocumentoUS)
                                {
                                    // Unidad de Medida de la Edad - Posición 9 del Archivo US
                                    UnidadMedidaEdad = split[9];
                                }
                            }

                            lines.Add(line);
                        }
                    }

                }
            }

            return UnidadMedidaEdad;
        }

        /// <summary>
        /// Obtiene Valor Neto del AF
        /// </summary>
        /// <param name="directoryPath">La ruta del directorio raíz donde se buscarán los archivos</param>
        /// <param name="searchPatters">Patron de Busqueda que indica que tipo de archvio se va a buscar</param>
        /// <returns>La edad del usuario como un número entero</returns>
        public string valorAF(string directoryPath, string searchPatters)
        {
            directory = new DirectoryInfo(directoryPath);
            String valorNetoAF = "";

            foreach (var item in directory.GetFiles(searchPatters, SearchOption.AllDirectories))
            {
                string path = item.FullName;
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

                                // Obtenemos Valor Neto - Posición 16
                                valorNetoAF = split[16];

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Archivo no Existe");
                    return valorNetoAF = "0";
                }
            }
            return valorNetoAF;
        }
        /// <summary>
        /// Obtiene Valores del AF
        /// </summary>
        /// <param name="directoryPath">La ruta del directorio raíz donde se buscarán los archivos</param>
        /// <param name="valorPos">Posición donde se encuentra el Valor buscado</param>
        /// <param name="searchPatters">Patron de Busqueda que indica que tipo de archvio se va a buscar</param>
        /// <returns>Valores del Archivo AF</returns>
        public decimal ObtenerSumatoriaValores(string directoryPath, int valorPos, string searchPatters)
        {
            directory = new DirectoryInfo(directoryPath);
            decimal sumatoriaValores = 0;

            foreach (var item in directory.GetFiles(searchPatters, SearchOption.AllDirectories))
            {
                string path = item.FullName;
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

                                if (split.Length > valorPos)
                                {
                                    // Intenta convertir el valor a decimal
                                    if (decimal.TryParse(split[valorPos], out decimal valor))
                                    {
                                        // Suma el valor a la sumatoria total
                                        sumatoriaValores += valor;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Archivo no Existe");
                    return 0;
                }
            }
            return sumatoriaValores;
        }

        /// <summary>
        /// Obtiene Valores del Archvio AC
        /// </summary>
        /// <param name="directoryPath">La ruta del directorio raíz donde se buscarán los archivos</param>
        /// <param name="valorPos">Posición donde se encuentra el Valor buscado</param>
        /// <param name="searchPatters">Patron de Busqueda que indica que tipo de archvio se va a buscar</param>
        /// <returns>Valores del Archivo AC</returns>
    }
}
