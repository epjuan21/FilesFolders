using System;
using System.Collections.Generic;

namespace FilesFolders.Clases
{
    class Departamento
    {

        public String departamentoViejo { get; set; }
        public String departamentoNuevo { get; set; }

        public static List<Departamento> GetDepartamentos()
        {
            List<Departamento> departamentos = new List<Departamento>();

            departamentos.Add(new Departamento
            {
                departamentoViejo = "30",
                departamentoNuevo = "05"
            });

            departamentos.Add(new Departamento
            {
                departamentoViejo = "91",
                departamentoNuevo = "05"
            });

            departamentos.Add(new Departamento
            {
                departamentoViejo = "091",
                departamentoNuevo = "05"
            });

            departamentos.Add(new Departamento
            {
                departamentoViejo = "34",
                departamentoNuevo = "05"
            });

            departamentos.Add(new Departamento
            {
                departamentoViejo = "42",
                departamentoNuevo = "05"
            });

            return departamentos;
        }
    }
}
