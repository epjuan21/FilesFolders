using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesFolders.Clases
{
    class Departamentos
    {

        private String departamentoAnterior;
        private String departamentoNuevo;

        public Departamentos(String departamentoAnterior, String departamentoNuevo)
        {
            this.departamentoAnterior = departamentoAnterior;
            this.departamentoNuevo = departamentoNuevo;
        }

        public String GetDepartamentoAnterior()
        {
            return departamentoAnterior;
        }

        public String GetDepartamentoNuevo()
        {
            return departamentoNuevo;
        }

    }
}
