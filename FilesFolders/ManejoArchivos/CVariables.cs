using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilesFolders.ManejoArchivos
{
    class CVariables
    {
        private string Path;
        private DirectoryInfo Directory;

        public string ReturnPath
        {
            get { return Path; }
            set { Path = value; }
        }

        public DirectoryInfo ReturnDirectory
        {
            get { return Directory; }
            set { Directory = value; }
        }
    }
}
