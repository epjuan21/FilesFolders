using System;

namespace FilesFolders.Clases
{
    class Cups
    {

        private String codigoAnterior;
        private String codigoNuevo;

        public Cups(String codigoAnterior, String codigoNuevo)
        {
            this.codigoAnterior = codigoAnterior;
            this.codigoNuevo = codigoNuevo;
        }

        public String GetCodigoAnterior()
        {
            return codigoAnterior;
        }

        public String GetCodigoNuevo()
        {
            return codigoNuevo;
        }

    }
}
