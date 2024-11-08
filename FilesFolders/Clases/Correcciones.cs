using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            string TipoIdUsuario = split[tipoIdUsuarioPos]; // tipoIdUsuarioPos: Posición del Tipo de Id del Usuadio
            //int Edad = int.Parse(split[edadPos]);
            int Edad = (edadPos != -1) ? int.Parse(split[edadPos]) : EdadUsuario;
            string UnidadMedidaEdad = (unidadMedidaEdadPos != -1) ? split[unidadMedidaEdadPos] : UnidadMedidaEdadUsuario;
            //string UnidadMedidaEdad = split[unidadMedidaEdadPos];
            string NumeroIdUsuario = split[numeroIdUsuarioPos];
            string documentoCorrecto = TipoIdUsuario;

            // Corregit Tipo de Documento AS

            if (TipoIdUsuario == "AS" && Edad < 18 && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "MS";
            }

            if (TipoIdUsuario == "AS" && Edad < 30 && UnidadMedidaEdad == "3")
            {
                documentoCorrecto = "MS";
            }

            // Corregit Tipo de Documento CC

            if (TipoIdUsuario == "CC" && (Edad >= 7 && Edad < 18) && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "TI";
            }

            if ((TipoIdUsuario == "CC" && Edad < 8 && UnidadMedidaEdad == "1") || (TipoIdUsuario == "CC" && Edad < 12 && UnidadMedidaEdad == "2") || (TipoIdUsuario == "CC" && Edad < 30 && UnidadMedidaEdad == "3"))
            {
                documentoCorrecto = "RC";
            }

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

            // Corregir Tipo de Documento MS

            if (TipoIdUsuario == "MS" && Edad >= 18 && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "AS";
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

            if (TipoIdUsuario == "PT" && Edad > 17 && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "AS";
            }
            if (TipoIdUsuario == "PT" && Edad < 18 && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "MS";
            }

            // Corregir Tipo de Documento RC

            if (TipoIdUsuario == "RC" && (Edad >= 7 && Edad <= 17) && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "TI";
            }

            if (TipoIdUsuario == "RC" && Edad >= 18 && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "CC";
            }

            // Corregir Tipo de Documento TI

            if (TipoIdUsuario == "TI" && Edad < 7 && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "RC";
            }

            if (TipoIdUsuario == "TI" && Edad < 24 && (UnidadMedidaEdad == "2" || UnidadMedidaEdad == "3"))
            {
                documentoCorrecto = "RC";
            }

            if (TipoIdUsuario == "TI" && Edad > 17 && UnidadMedidaEdad == "1")
            {
                documentoCorrecto = "CC";
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

            if (codigoCUPS == "0001")
            {
                codigoCUPSCorregido = "895004";
            }

            if (codigoCUPS == "00022" || codigoCUPS == "0019")
            {
                codigoCUPSCorregido = "869501";
            }

            if (codigoCUPS == "02")
            {
                codigoCUPSCorregido = "973800";
            }

            if (codigoCUPS == "2" || codigoCUPS == "16" || codigoCUPS == "22")
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
                codigoCUPSCorregido = "232101";
            }
            if (codigoCUPS == "232102")
            {
                codigoCUPSCorregido = "232101";
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
            if (codigoCUPS == "8618AC")
            {
                codigoCUPSCorregido = "861801";
            }
            if (codigoCUPS == "8618AD")
            {
                codigoCUPSCorregido = "861801";
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
            if (codigoCUPS == "997107")
            {
                codigoCUPSCorregido = "997301";
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
        public string CorregirFinalidad(ref string line, int codigoCUPSPos, int finalidadPos, int diagnosticoPos, string tipoArchivo)
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
            string codigoCUPS = split[codigoCUPSPos];
            string diagnostico = split[diagnosticoPos];
            string finalidadCorregida = finalidad;

            #region AC
            if (tipoArchivo == "AC")
            {
                // CapItulo 16 CONSULTA, MONITORIZACION Y PROCEDIMIENTOS DIAGNOSTICOS

                // 89 CONSULTA, MEDICIONES ANATOMICAS, FISIOLOGICAS, EXAMENES MANUALES Y ANATOMOPATOLOGICOS

                // 890 ENTREVISTA, CONSULTA Y EVALUACION [VALORACION]

                if (codigoCUPS == "890201" && finalidad == "")
                {
                    finalidadCorregida = "10";
                }
                if (codigoCUPS == "890201" && finalidad == "42")
                {
                    finalidadCorregida = "03";
                }
                if (codigoCUPS == "890203" && finalidad == "")
                {
                    finalidadCorregida = "10";
                }
                if (codigoCUPS == "890205" && finalidad == "20")
                {
                    finalidadCorregida = "03";
                }
                if (codigoCUPS == "890301" && finalidad == "")
                {
                    finalidadCorregida = "10";
                }
                if (codigoCUPS == "890301" && finalidad == "42")
                {
                    finalidadCorregida = "03";
                }
                if (codigoCUPS == "890305" && finalidad == "")
                {
                    finalidadCorregida = "04";
                }
                if (codigoCUPS == "890305" && finalidad == "" && (diagnostico == "Z300" || diagnostico == "Z304"))
                {
                    finalidadCorregida = "03";
                }
                if (codigoCUPS == "890305" && finalidad == "42" && (diagnostico == "Z300" || diagnostico == "Z304"))
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
            }
            #endregion

            #region AP
            if (tipoArchivo == "AP")
            {
                // Diccionario para mapear los primeros tres caracteres de códigos CUPS a la finalidad correspondiente
                Dictionary<string, string> codigosFinalidad = new Dictionary<string, string>
                {
                    { "210", "2" }, { "211", "2" }, { "230", "2" }, { "232", "2" }, { "389", "2" },
                    { "542", "2" }, { "579", "2" }, { "697", "3" }, { "797", "2" },
                    { "861", "2" }, { "865", "2" }, { "869", "2" }, { "870", "1" },
                    { "871", "1" }, { "872", "1" }, { "873", "1" }, { "890", "4" },
                    { "892", "4" }, { "893", "4" }, { "895", "1" }, { "897", "1" },
                    { "898", "1" }, { "901", "1" }, { "902", "1" }, { "903", "1" },
                    { "906", "1" }, { "908", "1" }, { "911", "1" }, { "997", "1" }
                };

                // Truncar a los primeros tres caracteres de `codigoCUPS`
                string codigoCUPSTruncado = codigoCUPS.Length >= 3 ? codigoCUPS.Substring(0, 3) : codigoCUPS;

                // Verificar si la finalidad está vacía y si el código truncado está en el diccionario
                if (finalidad == "" && codigosFinalidad.TryGetValue(codigoCUPSTruncado, out string nuevaFinalidad))
                {
                    return nuevaFinalidad;
                }
            }
            #endregion

            return finalidadCorregida;
        }

        /// <summary>
        /// Corrige Ambito en AP
        /// </summary>
        /// <param name="line">Indica la linea en la que se encuentra el ciclo</param>
        /// <param name="codigoCUPSPos">Posición del Código CUPS en la línea evaluada</param>
        /// <param name="ambitoPos">Posición del Ambito en la línea evaluada</param>
        /// <returns>Retorna el Ambito Corregido</returns>
        public string CorregirAmbito(ref string line, int codigoCUPSPos, int ambitoPos)
        {
            /*
                Ambito Procedimiento

                1 = Ambulatorio
                2 = Hospitalario
                3 = En Urgencias

                Posición 7
            */

            // Mapeo de los primeros tres caracteres de código CUPS a los valores de ambitoCorregido
            var ambitoMap = new Dictionary<string, string>
                    {
                        { "230", "1" }, { "232", "1" }, { "697", "1" }, 
                        { "861", "1" }, { "869", "1" }, { "865", "3" }, 
                        { "862", "1" }, { "870", "1" }, { "871", "1" }, 
                        { "872", "1" }, { "873", "1" }, { "890", "1" }, 
                        { "892", "1" }, { "893", "1" }, { "895", "2" }, 
                        { "897", "2" }, { "898", "2" }, { "901", "1" },
                        { "902", "1" }, { "903", "1" }, { "904", "1" }, { "906", "1" },
                        { "907", "1" }, { "908", "1" }, { "936", "1" },
                        { "950", "1" }, { "911", "1" }, { "935", "1" },
                        { "993", "1" }, { "963", "1" }, { "973", "1" },
                        { "981", "3" }, { "982", "3" }, { "992", "1" },
                        { "995", "1" }, { "997", "1" }
                    };

            // Dividir la línea en partes
            string[] split = line.Split(',');

            // Obtener los valores de los índices proporcionados
            string codigoCUPS = split[codigoCUPSPos];
            string ambito = split[ambitoPos];
            string ambitoCorregido = ambito;

            // Verificar si el código CUPS está vacío y si los primeros tres caracteres coinciden en el diccionario
            if (ambito == "" && codigoCUPS.Length >= 3)
            {
                string codigoCUPSKey = codigoCUPS.Substring(0, 3);
                if (ambitoMap.TryGetValue(codigoCUPSKey, out string nuevoAmbito))
                {
                    ambitoCorregido = nuevoAmbito;
                }
            }
            return ambitoCorregido;
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

        /// <summary>
        /// Corrige Códigos CUM de Medicamnetos.
        /// </summary>
        /// <param name="line">Indica la linea en la que se encuentra el ciclo</param>
        /// <param name="codigoCUMPos">Posición del Código CUM en la línea evaluada</param>
        /// <returns>El Código CUM Corregido.</returns>
        public string CorregirCUMMedicamento(ref string line, int codigoCUMPos, string Entidad = "")
        {
            string[] split = line.Split(',');
            string codigoCUM = split[codigoCUMPos];
            string codigoCUMCorregido = codigoCUM;

            //  Ausencia de Codigo de Medicamento
            if (codigoCUM == "")
            {
                codigoCUMCorregido = "20105341-1";
            }
            //  Codido de Mericamento con solo un Guion "-"
            if (codigoCUM == "-")
            {
                codigoCUMCorregido = "20105341-1";
            }
            if (codigoCUM == "-")
            {
                split[7] = "SOLUCION SALINA";
            }
            if (codigoCUM == "-")
            {
                split[8] = "SOLUCION INYECTABLE";
            }
            if (codigoCUM == "-")
            {
                split[9] = "0.9 G";
            }
            if (codigoCUM == "-")
            {
                split[10] = "CADA BOLSA POR 100 M";
            }
            //  SUCCINILCOLINA 40MG/2ML
            if (codigoCUM == "J07AM01" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "58815-1";
            }
            //  SOLUCION SALINA 250MG
            if (codigoCUM == "B05BB01" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20055558-7";
            }
            //  AZATIOPRINA
            if (codigoCUM == "L04AX01" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20023909-1";
            }
            //  LABETALOL
            if (codigoCUM == "C07AG01" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20090031-1";
            }
            // AMPICILINA + SULBACTAM 1.5 G
            if (codigoCUM == "218004-19" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19931216-5";
            }
            // ALBENDAZOL 400MG/20ML SUSPENSI
            if (codigoCUM == "230417-6" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "230417-1";
            }
            // AMLODIPINO 10 MG
            if (codigoCUM == "55894-16" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "55895-6";
            }
            // LEVETIRACETAM 1000 MG (CEUMID)
            if (codigoCUM == "20007895-10" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20007896-1";
            }
            // ACETATO DE MEDROXIPROGESTERONA
            if (codigoCUM == "20175926-1" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "13854-2";
            }
            // OXACILINA 1 G POLVO EST?RIL PA
            if (codigoCUM == "20080533-2" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19953925-7";
            }
            // LEVODOPA
            if (codigoCUM == "48898-23" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "1980397-1";
            }
            // LANSOPRAZOL CAPSULAS DE LIBERA
            if (codigoCUM == "226859-10" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19989033-3";
            }
            // ESOMEPRAZOL
            if (codigoCUM == "19960407-13" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19960407-9";
            }
            // ESOPRONT 40 MG TABLETAS RECU
            if (codigoCUM == "20197137-5" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20037098-12";
            }
            // DICLOFENACO SODICO 75 MG/ 3 ML
            if (codigoCUM == "19986823-5" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "29151-2";
            }
            // VACUNA ANTITETANICA
            if (codigoCUM == "19940997-05" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "29151-2";
            }
            // MIDAZOLAN 5MG/5ML (CTROL)
            if (codigoCUM == "20198543-2" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19940108-12";
            }
            // ERGOTAMINA TARTRATO 1MG + CAFE
            if ((codigoCUM == "19912966-16" || codigoCUM == "20077272-7") && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20077272-5";
            }
            // CLINDAMICINA 600 MG / 4 ML SOL
            if (codigoCUM == "19943350-28" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19943350-5";
            }
            // LEVOTIROXINA 25 MCG TABLETAS
            if (codigoCUM == "20027645-37" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20009747-7";
            }
            // LEVOTIROXINA SODICA 50 MCG (TIR,TABLETA
            if (codigoCUM == "19960116-16" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "42722-2";
            }
            // EUTIROX 50 MCG
            if ((codigoCUM == "19976365-9" || codigoCUM == "19976365-10") && Entidad == "SSSA")
            {
                codigoCUMCorregido = "206776-12";
            }
            // SALES DE REHIDRATACION ORAL 20
            if (codigoCUM == "19976587-3" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20055558-7";
            }
            // DEXAMETASONA FOSFATO 8MG / 2 M
            if (codigoCUM == "19997625-07" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "28346-16";
            }
            // LEVETIRACETAM 500 MG (CEUMID)
            if (codigoCUM == "20007896-10" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "206776-12";
            }
            // CLOPIDOGREL 75 MG (PLATEMAX)
            if (codigoCUM == "20056052-22" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20011353-1";
            }
            // SODIO CLORURO AL 0.9%
            if (codigoCUM == "20055558-07" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "51076-2";
            }
            // METOCLOPRAMIDA CLORHIDRATO SOLUCION
            if (codigoCUM == "19903576-03" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19903576-3";
            }
            // METOCLOPRAMIDA 10 MG/2 ML
            if (codigoCUM == "20162259-4" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19903576-3";
            }
            // ATORVASTATINA 40 MG TABLETAS
            if (codigoCUM == "20007896-10" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20085383-15";
            }
            // ESTROGENOS CONJUGADOS 0.625 MG
            if (codigoCUM == "20157781-1" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19963293-4";
            }
            // ILEINE,SUSPENSION INYECTABL
            if (codigoCUM == "20175926-2" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20007675-2";
            }
            // METAMIZOL SODICO( DIPIRONA)1G
            if ((codigoCUM == "19907058-02" || split[5] == "20055558-02") && Entidad == "SSSA")
            {
                codigoCUMCorregido = "33644-4";
            }
            // HIOSCINA N-BUTIL BROMURO + DIP
            if (codigoCUM == "19926478-03" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "36344-1";
            }
            // TRAMADOL INYECTABLE X 50 MG/ML
            if (codigoCUM == "53285-02" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "51716-1";
            }
            // ACETAMINOFEN 500 MG
            if ((codigoCUM == "19935303-04" || split[5] == "19986458-9") && Entidad == "SSSA")
            {
                codigoCUMCorregido = "53560-3";
            }
            // DIFENHIDRAMINA HCL SOLUCION INYECTABLE
            if ((codigoCUM == "19962547-01" || split[5] == "20096034-01") && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19919306-1";
            }
            // FIREXIFEN JARABE
            if (codigoCUM == "20155033-03" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20155033-1";
            }
            // HIDROCORTISONA 100 MG
            if (codigoCUM == "19940721-05" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19940721-12";
            }
            // HIDROXIZINA CLOHIDRATO 100 MG
            if (codigoCUM == "20028014-01" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20028014-1";
            }
            // LACTATO DE RINGER (SOLUCION HA,SOLUCION INYECTABLE
            if (codigoCUM == "20055559-6")
            {
                codigoCUMCorregido = "32606-1";
            }
            // ACIDO TRANEXAMICO 500 MG TABLE
            if ((codigoCUM == "20138453-01" || split[5] == "20203819-1") && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20072679-1";
            }
            // BETAMETASONA 4 MG/ML SOLUCION I
            if (codigoCUM == "19980025-14" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19938121-3";
            }
            // OXIGENO MEDICINAL 1M3
            if (codigoCUM == "20191559-31" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20011125-3";
            }
            // OXIGENO MEDICINAL 0.5 M3
            if (codigoCUM == "20191559-10" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20011125-3";
            }
            // OXIGENO MEDICINAL 6 M3
            if (codigoCUM == "20191559-20" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19952050-9";
            }
            // VITAMINA A 50.000 UI
            if (codigoCUM == "19960905-12" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19924907-11";
            }
            // FEVENY CREMA 0.625MG/G VAGINA
            if (codigoCUM == "19993161-4" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19993239-1";
            }
            // VITAMIX 15
            if (codigoCUM == "11781-21" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19960905-11";
            }
            // PASTA DE CACAHUETE LECHE Y AZU
            if (codigoCUM == "20113506-1" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19960905-11";
            }
            // OXIGENO MEDICINAL 3.5 M3
            if (codigoCUM == "20191559-16" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20011125-3";
            }
            return codigoCUMCorregido;
        }

    }
}
