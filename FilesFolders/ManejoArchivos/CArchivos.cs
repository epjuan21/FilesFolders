using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesFolders.ManejoArchivos
{
    class CArchivos: CVariables
    {
        private string NumeroLineas;

        public string ContarLineas(string PathFile)
        {
            using (StreamReader reader = new StreamReader(PathFile, Encoding.GetEncoding("Windows-1252")))
            {
                NumeroLineas = File.ReadAllLines(PathFile).Length.ToString();
            }

            return NumeroLineas;
        }
    }
}
