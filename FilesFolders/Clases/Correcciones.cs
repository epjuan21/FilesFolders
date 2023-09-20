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

            string TipoIdUsuario = split[tipoIdUsuarioPos];
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
        public string CorregirFinalidad(ref string line, int codigoCUPSPos, int finalidadPos,  int diagnosticoPos, string tipoArchivo)
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
            }
            #endregion

            #region AP
            if(tipoArchivo == "AP")
            {
                // CapItulo 05 NARIZ, BOCA Y FARINGE

                    // 21 PROCEDIMIENTOS EN NARIZ

                if (codigoCUPS == "210200" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "211204" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                    // 23 PROCEDIMIENTOS EN DIENTES

                if (codigoCUPS == "232101" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }

                    // 38 PROCEDIMIENTOS EN VASOS SANGUINEOS (INCISION, ESCISION Y OCLUSION)

                if (codigoCUPS == "389900" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                    // 54 OTROS PROCEDIMIENTOS EN ABDOMEN

                if (codigoCUPS == "542700" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "542801" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }

                    // 57 PROCEDIMIENTOS EN VEJIGA

                        // 579 OTROS PROCEDIMIENTOS EN VEJIGA

                if (codigoCUPS == "579401" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "579500" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "579501" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }

                    // 69 OTROS PROCEDIMIENTOS EN UTERO Y ESTRUCTURAS DE SOPORTE

                        // 697 INSERCION DE DISPOSITIVOS INTRAUTERINOS ANTICONCEPTIVOS

                if (codigoCUPS == "697101" && finalidad == "")
                {
                    finalidadCorregida = "3";
                }

                    // 86 PROCEDIMIENTOS EN PIEL Y TEJIDO CELULAR SUBCUTANEO

                if (codigoCUPS == "861101" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "861201" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "865101" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "865102" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "862701" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "869500" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }

                // Seccion 01 PROCEDIMIENTOS NO QUIRURGICOS

                    // CapItulo 15 IMAGENOLOGIA

                        // 87 IMAGENOLOGIA RADIOLOGICA

                if (codigoCUPS == "870001" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "870101" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "870105" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "870107" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "870108" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "870112" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "870113" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "870120" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "870131" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "870602" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "871010" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "871020" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "871030" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "871040" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "871050" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "871060" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "871111" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "871121" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "871129" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "872002" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "872011" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873111" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873112" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873121" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873122" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873204" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873205" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873206" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873210" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873311" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873312" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873313" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873333" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873411" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873412" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873420" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873422" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "873431" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }

                // CapItulo 16 CONSULTA, MONITORIZACION Y PROCEDIMIENTOS DIAGNOSTICOS

                    // 89 CONSULTA, MEDICIONES ANATOMICAS, FISIOLOGICAS, EXAMENES MANUALES Y ANATOMOPATOLOGICOS

                        // 890 ENTREVISTA, CONSULTA Y EVALUACION [VALORACION]

                if (codigoCUPS == "890301" && finalidad == "")
                {
                    finalidadCorregida = "4";
                }

                        // 892 MEDICIONES ANATOMICAS, FISIOLOGICAS Y EXAMENES MANUALES DE APARATO GENITOURINARIO

                if (codigoCUPS == "892901" && finalidad == "")
                {
                    finalidadCorregida = "4";
                }

                        // 895 OTROS PROCEDIMIENTOS DIAGNOSTICOS CARDIACOS Y VASCULARES NO QUIRURGICOS

                if (codigoCUPS == "895001" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "895100" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }

                        // 897 MONITORIZACION DE FETO

                if (codigoCUPS == "897011" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "897012" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }

                // CapItulo 17 LABORATORIO CLINICO

                    // 90 LABORATORIO CLINICO

                if (codigoCUPS == "903426" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906039" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906129" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906440" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906625" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "908856" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "901104" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "901107" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "901235" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "901236" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "901237" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "901304" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "901305" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "902043" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "902204" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "902206" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "902208" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "902221" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903026" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903604" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903703" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903801" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903809" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903841" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903856" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903866" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903867" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "903895" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "904508" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "904509" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906127" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906249" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906317" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906914" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906915" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "906916" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "907002" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "907004" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "907106" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }

                // CapItulo 18 MEDICINA TRANSFUSIONAL Y BANCO DE SANGRE

                    // 91 BANCO DE SANGRE Y MEDICINA TRANSFUSIONAL

                if (codigoCUPS == "911018" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }
                if (codigoCUPS == "911009" && finalidad == "")
                {
                    finalidadCorregida = "1";
                }

                // CapItulo 20 DESEMPEÑO FUNCIONAL Y REHABILITACION

                    // 93 PROCEDIMIENTOS E INTERVENCIONES EN DESEMPEÑO FUNCIONAL, REHABILITACION Y RELACIONADOS

                if (codigoCUPS == "935301" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "935302" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "935303" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "935304" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "935400" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "939402" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "936800" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "939402" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }

                // CapItulo 22 DIAGNOSTICO Y TRATAMIENTO EN SISTEMAS VISUAL Y AUDITIVO

                    // 95 PROCEDIMIENTOS E INTERVENCIONES NO QUIRURGICOS RELACIONADOS CON EL OJO Y OIDO

                if (codigoCUPS == "950601" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }

                // CapItulo 23 OTROS PROCEDIMIENTOS NO QUIRURGICOS

                    // 96 INTUBACION E IRRIGACION NO QUIRURGICOS

                if (codigoCUPS == "963300" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "965100" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "965200" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "965201" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }

                    // 97 SUSTITUCION Y EXTRACCION DE DISPOSITIVOS TERAPEUTICOS

                if (codigoCUPS == "977100" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }

                if (codigoCUPS == "973800" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }


                // 98 EXTRACCION DE CUERPO EXTRAÑO Y CALCULO NO OPERATORIO

                if (codigoCUPS == "981100" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "982102" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }

                // CapItulo 24 PROCEDIMIENTOS MISCELANEOS

                    // 99 PROCEDIMIENTOS PROFILACTICOS, TERAPEUTICOS Y OTROS PROCEDIMIENTOS MISCELANEOS

                if (codigoCUPS == "992901" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "993102" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "993120" && finalidad == "")
                {
                    finalidadCorregida = "2";
                }
                if (codigoCUPS == "993122" && finalidad == "")
                {
                    finalidadCorregida = "3";
                }
                if (codigoCUPS == "993501" && finalidad == "")
                {
                    finalidadCorregida = "3";
                }
                if (codigoCUPS == "993520" && finalidad == "")
                {
                    finalidadCorregida = "3";
                }
                if (codigoCUPS == "993522" && finalidad == "")
                {
                    finalidadCorregida = "3";
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

            string[] split = line.Split(',');
            string codigoCUPS = split[codigoCUPSPos];
            string ambito = split[ambitoPos];
            string ambitoCorregido = ambito;

            if (codigoCUPS == "232101" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "869500" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "865101" && ambito == "")
            {
                ambitoCorregido = "3";
            }
            if (codigoCUPS == "862701" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "870112" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "872011" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "873111" && ambito == "")
            {
                ambitoCorregido = "1";
            }   
            if (codigoCUPS == "873112" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "873422" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "890301" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "892901" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "895001" && ambito == "")
            {
                ambitoCorregido = "2";
            }
            if (codigoCUPS == "897011" && ambito == "")
            {
                ambitoCorregido = "2";
            }
            if (codigoCUPS == "897012" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "901107" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "901235" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "901236" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "901237" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "901305" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "902221" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "903026" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "903426" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "903604" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "903703" && ambito == "")
            {
                ambitoCorregido = "3";
            }
            if (codigoCUPS == "906039" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "906127" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "906129" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "906440" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "907004" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "908856" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "936800" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "950601" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "911018" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "935302" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "993102" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "963300" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "973800" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "981100" && ambito == "")
            {
                ambitoCorregido = "3";
            }
            if (codigoCUPS == "982102" && ambito == "")
            {
                ambitoCorregido = "3";
            }
            if (codigoCUPS == "992101" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "993120" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "993122" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "993501" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "993520" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (codigoCUPS == "993522" && ambito == "")
            {
                ambitoCorregido = "1";
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

            // MEDROXIPROGESTERONA Y ESTROGEN
            if (codigoCUM == "20002868-3"  && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "19999216-1";
            }

            // CALCIO CARBONATO
            if (codigoCUM == "19965399-4" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "207110-1";
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
            // VACUNA ANTITETANICA
            if (codigoCUM == "19940997-05" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "29151-2";
            }
            // DEXAMETASONA FOSFATO 8MG / 2 M
            if (codigoCUM == "19997625-07" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "28346-16";
            }
            // SODIO CLORURO AL 0.9%
            if (codigoCUM == "20055558-07" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "51076-2";
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
            if (codigoCUM == "19935303-04" && Entidad == "SSSA")
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
            if (codigoCUM == "19940721-05" && (Entidad == "SSSA" || Entidad == "SAVIASALUD"))
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
            if (codigoCUM == "20138453-1" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "20072679-1";
            }
            // CLOZAPINA
            if (codigoCUM == "19955124-1" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "19974655-1";
            }
            // VALPROICO ACIDO
            if (codigoCUM == "19956468-1" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "20205262-1";
            }
            // ACETILSALICILICO ACIDO
            if (codigoCUM == "19936296-8" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "57642-1";
            }
            // IBUPROFENO
            if (codigoCUM == "19980114-8" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "51330-12";
            }
            // AMOXICILINA
            if (codigoCUM == "20100042-1" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "19957924-1";
            }
            // CLOPIDOGREL
            if (codigoCUM == "20011353-1" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "19933487-1";
            }
            // ALPRAZOLAM
            if (codigoCUM == "20012839-1" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "13874-1";
            }
            // TETANOS TOXOIDE
            if (codigoCUM == "19940997-5" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "29151-2";
            }
            // METILPREDNISOLONA
            if (codigoCUM == "202576-1" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "19990590-16";
            }
            // BETAMETASONA 4 MG/ML SOLUCION I
            if (codigoCUM == "19980025-14" && Entidad == "SSSA")
            {
                codigoCUMCorregido = "19938121-3";
            }
            // NISTATINA
            if (codigoCUM == "19997076-2" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "19984679-4";
            }
            // GENTAMICINA
            if (codigoCUM == "19997076-2" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "28035-5";
            }
            // NIFEDIPINA
            if (codigoCUM == "51316-2" && Entidad == "SAVIASALUD")
            {
                codigoCUMCorregido = "20025310-19";
            }
            return codigoCUMCorregido;
        }

    }
}
