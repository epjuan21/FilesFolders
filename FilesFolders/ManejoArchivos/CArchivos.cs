using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesFolders.ManejoArchivos
{
    class CArchivos: CVariables
    {
        private string NumeroLineas;
        private DirectoryInfo directory;             


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
            }

            return NumeroLineas;
        }

        /// <summary>
        /// Retorna una Lista de todos los archivos de una carpeta según un criterio
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public List<string> ListarArchivos(string directoryPath, string searchPattern)
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
        
        public string Lineas(string directoryPath, string searchPattern)
        {
            directory = new DirectoryInfo(directoryPath);

            foreach (var item in directory.GetFiles(searchPattern))
            {
                String nameFile = item.FullName;
                string NumeroLineas = ContarLineas(nameFile);
            }

            return NumeroLineas;
        }

    }
}
