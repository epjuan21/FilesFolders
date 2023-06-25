using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesFolders.Clases
{
    internal class Correcciones
    {
        /// <summary>
        /// Corrige Tipo de Documento
        /// </summary>
        /// <param name="line">Indica la linea en la que se encuentra el ciclo</param>
        /// <param name="tipoIdUsuarioPos">Posición del tipo de Id en el Archivo de Texto</param>
        /// <param name="edadPos">Posición de la edad en el Archivo de Texto</param>
        /// <param name="Edad">Edad del Usuario</param>
        /// <param name="numeroIdUsuarioPos">Posición del número de Id en el Archivo de Texto</param>
        /// <param name="unidadMedidaEdadPos">Posición de la unidad de medida de la Edad en el Archivo de Texto</param>
        /// <returns>Retorna el Tipo de Documento Correcto</returns>
        public string CorregirTipoDocumento(ref string line, int tipoIdUsuarioPos, int edadPos, int EdadUsuario, int numeroIdUsuarioPos, int unidadMedidaEdadPos, string UnidadMedidaEdadUsuario)
        {
            string[] split = line.Split(',');

            string TipoIdUsuario = split[tipoIdUsuarioPos];
            //int Edad = int.Parse(split[edadPos]);
            int Edad = (edadPos != -1) ? int.Parse(split[edadPos]) : EdadUsuario;
            string UnidadMedidaEdad = (unidadMedidaEdadPos != -1) ? split[unidadMedidaEdadPos] : UnidadMedidaEdadUsuario;
            //string UnidadMedidaEdad = split[unidadMedidaEdadPos];
            string NumeroIdUsuario = split[numeroIdUsuarioPos];
            string documentoCorrecto = TipoIdUsuario;

            // Corregir Tipo de Documento CE

            if (TipoIdUsuario == "CE" && Edad > 17)
            {
                documentoCorrecto = "AS";
               
            }
            if (TipoIdUsuario == "CE" && Edad < 18)
            {
                documentoCorrecto = "MS";
            }

            // Corregir Tipo de Documento CN
            
            if (TipoIdUsuario == "CN" && Edad < 17)
            {
                documentoCorrecto = "MS";
            }

            if (TipoIdUsuario == "NV")
            {
                documentoCorrecto = "MS";
            }

            // Corregir Tipo de Documento DE

            if (TipoIdUsuario == "DE" && Edad > 17)
            {
                documentoCorrecto = "AS";
            }
            if (TipoIdUsuario == "DE" && Edad < 18)
            {
                documentoCorrecto = "MS";
            }

            // Corregir Tipo de Documento PA

            if (TipoIdUsuario == "PA" && Edad > 17)
            {
                documentoCorrecto = "AS";
            }
            if (TipoIdUsuario == "PA" && Edad < 18)
            {
                documentoCorrecto = "MS";
            }

            // Corregir Tipo de Documento PE

            if (TipoIdUsuario == "PE" && Edad > 17)
            {
                documentoCorrecto = "AS";
            }
            if (TipoIdUsuario == "PE" && Edad < 18)
            {
                documentoCorrecto = "MS";
            }

            // Corregir Tipo de Documento PT

            if (TipoIdUsuario == "PT" && Edad > 17)
            {
                documentoCorrecto = "AS";
            }
            if (TipoIdUsuario == "PT" && Edad < 18)
            {
                documentoCorrecto = "MS";
            }

            // Corregir Tipo de Documento RC

            if (TipoIdUsuario == "RC" && (Edad >= 7 && Edad <= 17) && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "TI";
            }

            // Corregir Tipo de Documento TI

            if (TipoIdUsuario == "TI" && (Edad < 24) && (UnidadMedidaEdad == "2" || UnidadMedidaEdad == "3"))
            {
                documentoCorrecto = "RC";
            }

            if (TipoIdUsuario == "TI" && Edad > 17 && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "CC";
            }

            if (NumeroIdUsuario.Length < 9 && Edad < 18)
            {
                documentoCorrecto = "MS";
            }

            return documentoCorrecto;
        }

        /// <summary>
        /// Corrige Código CUPS
        /// </summary>
        /// <param name="line">Indica la linea en la que se encuentra el ciclo</param>
        /// <param name="codigoPos">Posición del Código CUPS en la línea evaluada</param>
        /// <returns>Retorna el Código CUPS Corregido</returns>
        public string CorregirCUPS(ref string line, int codigoPos)
        {
            string[] split = line.Split(',');
            string codigoCUPS = split[codigoPos];
            string codigoCUPSCorregido = codigoCUPS;

            if (codigoCUPS == "2")
            {
                codigoCUPSCorregido = "890301";
            }
            if (codigoCUPS == "22")
            {
                codigoCUPSCorregido = "890301";
            }
            if (codigoCUPS == "021126")
            {
                codigoCUPSCorregido = "872011";
            }
            if (codigoCUPS == "4")
            {
                codigoCUPSCorregido = "869500";
            }
            if (codigoCUPS == "021145")
            {
                codigoCUPSCorregido = "871060";
            }
            if (codigoCUPS == "021146")
            {
                codigoCUPSCorregido = "873123";
            }
            if (codigoCUPS == "232100")
            {
                codigoCUPSCorregido = "232104";
            }
            if (codigoCUPS == "542801")
            {
                codigoCUPSCorregido = "542700";
            }
            if (codigoCUPS == "579400")
            {
                codigoCUPSCorregido = "579401";
            }
            if (codigoCUPS == "579500")
            {
                codigoCUPSCorregido = "579501";
            }
            if (codigoCUPS == "697100")
            {
                codigoCUPSCorregido = "697101";
            }
            if (codigoCUPS == "673411")
            {
                codigoCUPSCorregido = "863101";
            }
            if (codigoCUPS == "873123")
            {
                codigoCUPSCorregido = "873122";
            }
            if (codigoCUPS == "873211")
            {
                codigoCUPSCorregido = "873210";
            }

            // Capítulo 16 CONSULTA, MONITORIZACIÓN Y PROCEDIMIENTOS DIAGNÓSTICOS

            // 89 CONSULTA, MEDICIONES ANATÓMICAS, FISIOLÓGICAS, EXÁMENES MANUALES Y ANATOMOPATOLÓGICOS

            // 890 ENTREVISTA, CONSULTA Y EVALUACIÓN [VALORACIÓN]

            if (codigoCUPS == "890200")
            {
                codigoCUPSCorregido = "890201";
            }

            if (codigoCUPS == "890300")
            {
                codigoCUPSCorregido = "890301";
            }

            if (codigoCUPS == "890600")
            {
                codigoCUPSCorregido = "890601";
            }

            if (codigoCUPS == "902201")
            {
                codigoCUPSCorregido = "911009";
            }
            if (codigoCUPS == "902212")
            {
                codigoCUPSCorregido = "911015";
            }
            if (codigoCUPS == "903825")
            {
                codigoCUPSCorregido = "903895";
            }
            if (codigoCUPS == "906916")
            {
                codigoCUPSCorregido = "906915";
            }
            if (codigoCUPS == "*908856")
            {
                codigoCUPSCorregido = "908856";
            }
            if (codigoCUPS == "965200")
            {
                codigoCUPSCorregido = "965201";
            }
            if (codigoCUPS == "995199")
            {
                codigoCUPSCorregido = "993513";
            }
            if (codigoCUPS == "995200")
            {
                codigoCUPSCorregido = "993122";
            }
            if (codigoCUPS == "997300")
            {
                codigoCUPSCorregido = "997301";
            }
            return codigoCUPSCorregido;
        }

        /// <summary>
        /// Corrige Finalidad en AP y AC
        /// </summary>
        /// <param name="line">Indica la linea en la que se encuentra el ciclo</param>
        /// <param name="finalidadPos">Posición la finalidad en la línea evaluada</param>
        /// <param name="diagnosticoPos">Posición del Diagnóstico Principal en la línea evaluada</param>
        /// <param name="codigoCUPSPos">Posición del Código CUPS en la línea evaluada</param>
        /// <param name="tipoArchivo">Indica el tipo de archivo Evaluado, las opciones son AC o AP</param>
        /// <returns>Retorna la Finalidad Corregida</returns>
        public string CorregirFinalidad(ref string line, int finalidadPos, int codigoCUPSPos, int diagnosticoPos, string tipoArchivo)
        {
            /*
                Finalidades del Archivo AP

                1 = Diagnostico
                2 = Terapeutico
                3 = Protección Especifica
                4 = Detección Temprana de Enfermedad General
                5 = Detección Temprana de Enfermedad Profesinoal

                Posición Finalidad en el AP : 8

                |-------------------------------------------------------------------------------|

                Finalidades del Archvio AC

                01 = Atención del parto (puerperio)
                02 = Atención del recién nacido
                03 = Atención de planificación familiar
                04 = Detección de alteraciones de crecimiento y desarrollo del menor de diez años
                05 = Detección de alteración de desarrollo joven
                06 = Detección de alteraciones del embarazo
                07 = Detección de alteraciones del adulto
                08 = Detección de alteraciones de agudeza visual
                09 = Detección de enfermedad profesional
                10 = No Aplica

                Posición Finalidad en el AC : 7
            */

            string[] split = line.Split(',');
            string finalidad = split[finalidadPos];
            string codigoCUPS  = split[codigoCUPSPos];
            string diagnostico = split[diagnosticoPos];
            string finalidadCorregida = finalidad;
            string tipo = tipoArchivo;

            if (codigoCUPS == "890201" && finalidad == "")
            {
                finalidadCorregida = "10";
            }
            if (codigoCUPS == "890203" && finalidad == "")
            {
                finalidadCorregida = "10";
            }
            if (codigoCUPS == "890301" && finalidad == "")
            {
                finalidadCorregida = "10";
            }
            if (codigoCUPS == "890305" && finalidad == "")
            {
                finalidadCorregida = "04";
            }
            if (codigoCUPS == "890305" && finalidad == "" && diagnostico == "Z300")
            {
                finalidadCorregida = "03";
            }
            if (codigoCUPS == "890601" && finalidad == "")
            {
                finalidadCorregida = "10";
            }
            if (codigoCUPS == "890701" && finalidad == "")
            {
                finalidadCorregida = "10";
            }
            if (codigoCUPS == "890703" && finalidad == "")
            {
                finalidadCorregida = "10";
            }

            // Finalidad 07 Detección de alteraciones del adulto

            if (finalidad != "" && diagnostico != "")
            {
                if (finalidad != "10" && (diagnostico.Substring(0, 1) != "Z"))
                {
                    finalidadCorregida = "10";
                }
            }

            return finalidadCorregida;
        }

        /// <summary>
        /// Elimina los caracteres especiales de un código.
        /// </summary>
        /// <param name="codigo">El código a procesar.</param>
        /// <returns>El código sin los caracteres especiales.</returns>
        public string EliminarCaracteresEspeciales(string codigo)
        {
            if (codigo.StartsWith("*"))
            {
                codigo = codigo.Substring(1);
            }

            int guionIndex = codigo.IndexOf("-");
            if (guionIndex != -1)
            {
                codigo = codigo.Substring(0, guionIndex);
            }

            return codigo;
        }

    }
}
