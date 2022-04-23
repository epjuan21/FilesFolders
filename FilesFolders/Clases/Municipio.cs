using System.Collections.Generic;

namespace FilesFolders.Clases
{
    class Municipio
    {
        public string municipioViejo { get; set; }
        public string municipioNuevo { get; set; }

        public static List<Municipio> GetMunicipios()
        {
            List<Municipio> municipios = new List<Municipio>();

            municipios.Add(new Municipio
            {
                municipioViejo = "530",
                municipioNuevo = "091"
            });

            municipios.Add(new Municipio
            {
                municipioViejo = "591",
                municipioNuevo = "091"
            });

            municipios.Add(new Municipio
            {
                municipioViejo = "999",
                municipioNuevo = "091"
            });

            municipios.Add(new Municipio
            {
                municipioViejo = "91",
                municipioNuevo = "091"
            });

            municipios.Add(new Municipio
            {
                municipioViejo = "005",
                municipioNuevo = "091"
            });

            return municipios;
        }
    }
}
