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
