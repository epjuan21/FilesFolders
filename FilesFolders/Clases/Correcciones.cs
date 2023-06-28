using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

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
            if (split[6] == "869500" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "865101" && ambito == "")
            {
                ambitoCorregido = "3";
            }
            if (split[6] == "862701" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "870112" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "872011" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "873111" && ambito == "")
            {
                ambitoCorregido = "1";
            }   
            if (split[6] == "873112" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "873422" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "890301" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "892901" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "895001" && ambito == "")
            {
                ambitoCorregido = "2";
            }
            if (split[6] == "897011" && ambito == "")
            {
                ambitoCorregido = "2";
            }
            if (split[6] == "897012" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "901107" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "901235" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "901236" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "901237" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "901305" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "902221" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "903026" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "903426" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "903604" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "903703" && ambito == "")
            {
                ambitoCorregido = "3";
            }
            if (split[6] == "906039" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "906127" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "907004" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "908856" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "936800" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "950601" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "911018" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "935302" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "993102" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "963300" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "981100" && ambito == "")
            {
                ambitoCorregido = "3";
            }
            if (split[6] == "982102" && ambito == "")
            {
                ambitoCorregido = "3";
            }
            if (split[6] == "992101" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "993120" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "993122" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "993501" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "993520" && ambito == "")
            {
                ambitoCorregido = "1";
            }
            if (split[6] == "993522" && ambito == "")
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

    }
}
