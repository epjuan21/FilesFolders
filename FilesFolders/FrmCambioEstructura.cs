using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class FrmCambioEstructura : Form
    {
        public FrmCambioEstructura()
        {
            InitializeComponent();
        }

        #region Variables
        string dirPath;
        string Edad;
        string UnidadMedidaEdad;
        CWork bgwEAPB = new CWork();
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcesarEAPB_Click(object sender, EventArgs e)
        {
            bgwEAPB.ODoWorker(bgwEAPB_DoWork, bgwEAPB_ProgressChanged, bgwEAPB_RunWorkerCompleted);
        }

        private void btnRutaCarpetaEAPB_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuraCarpetaEAPB.Text = folderBrowserDialog1.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = folderBrowserDialog1.SelectedPath;

                btnProcesarEAPB.Enabled = true;
            }
        }

        private void bgwEAPB_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);

            // Variable Código de la entidad administradora del plan de beneficios
            string CodigoEAPB = txtCodigoMunicipio.Text;

            if (string.IsNullOrEmpty(CodigoEAPB))
            {
                MessageBox.Show("El Campo Código Municpio no puede estar Vacío");
                Application.Exit();
            }

            #region CAMBIO ESCTURTURA

            #region US EAPB

            foreach (var fi in di.GetFiles("*US*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Tipo Documento - Posición Original 0
                                string TipoDocumento = split[0];

                                // Número Documento - Posición Original 1
                                string NumeroDocumento = split[1];

                                // Código Entidad - Posición Original 2
                                string CodigoEntidad = split[2];

                                // Tipo Usuario
                                string TipoUsuario = split[3];

                                // Primer Apellido
                                string PrimerApellido = split[4];

                                // Segundo Apellido
                                string SegundoApellido = split[5];

                                // Primer Nombre
                                string PrimerNombre = split[6];

                                // Segundo Nombre
                                string SegundoNombre = split[7];

                                // Edad
                                string Edad = split[8];

                                // Unidad de Medidad de la Edad
                                string UnidadMedidaEdad = split[9];

                                // Sexo
                                string Sexo = split[10];

                                // Código Departamento
                                string CodigoDepartamento = split[11];

                                // Código Municipio
                                string CodigoMunicipio = split[12];

                                // Zona Residencia
                                string Zona = split[13];

                                // Estructura Nueva

                                String[] newArray = new string[12];

                                // Código de la entidad administradora del plan de beneficios
                                newArray[0] = CodigoEAPB;

                                // Tipo de identificación del usuario
                                newArray[1] = TipoDocumento;

                                // Número de identificación del usuario en el Sistema
                                newArray[2] = NumeroDocumento;

                                // Tipo de usuario
                                newArray[3] = TipoUsuario;

                                // Tipo de afiliado
                                newArray[4] = "";

                                // Código de la ocupación
                                newArray[5] = "";

                                // Edad
                                newArray[6] = Edad;

                                // Unidad de medida de la edad
                                newArray[7] = UnidadMedidaEdad;

                                // Sexo
                                newArray[8] = Sexo;

                                // Código del departamento de residencia habitual
                                newArray[9] = CodigoDepartamento;

                                // Código de municipios de residencia habitual
                                newArray[10] = CodigoMunicipio;

                                // Zona de residencia habitual
                                newArray[11] = Zona;

                                line = String.Join(",", newArray);

                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            #endregion

            #region CT EAPB

            foreach (var fi in di.GetFiles("*CT*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Código Prestador - Posición Original 0
                                string CodigoPrestador = split[0];

                                if (CodigoPrestador == "050910457201")
                                {
                                    split[0] = CodigoEAPB;
                                    line = String.Join(",", split);
                                }
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            #endregion

            #region AC EAPB

            foreach (var fi in di.GetFiles("*AC*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Número de la Factura - Posición Original 0
                                string NumeroFactura = split[0];

                                // Código del prestador de servicios de salud - Posición Original 1
                                string CodigoPrestador = split[1];

                                // Tipo de identificación del usuario - Posición Original 2
                                string TipoDocumento = split[2];

                                // Número Documento - Posición Original 3
                                string NumeroDocumento = split[3];

                                // Fecha de la Consulta - Posición Original 4
                                string FechaConsulta = split[4];

                                // Número de autorización - Posición Original 5
                                string NumeroAutorizacion = split[5];

                                // Codigo Consulta - Posición Original 6
                                string CodigoConsulta = split[6];

                                // Finalidad de la consulta - Posición Original 7
                                string FinalidadConsulta = split[7];

                                // Causa Externa - Posición Original 8
                                string CausaExterna = split[8];

                                // Código del Diagnóstico Principal - Posición Original 9
                                string DiagnosticoPrincipal = split[9];

                                // Código del Diagnóstico Relacionado 1 - Posición Original 10
                                string DiagnosticoRelacionado1 = split[10];

                                // Código del Diagnóstico Relacionado 2 - Posición Original 11
                                string DiagnosticoRelacionado2 = split[11];

                                // Código del Diagnóstico Relacionado 3 - Posición Original 12
                                string DiagnosticoRelacionado3 = split[12];

                                // Tipo de Diagnóstico Principal - Posición Original 13
                                string TipoDiagnosticoPrincipal = split[13];

                                // Valor de la Consulta - Posición Original 14
                                string ValorConsulta = split[14];

                                // Valor de la cuota moderadora - Posición Original 15
                                string ValorCuotaModeradora = split[15];

                                // Valor neto a pagar - Posición Original 16
                                string ValorNeto = split[16];

                                // Estructura Nueva

                                // Código de la entidad administradora del plan de beneficio - Posición 0
                                split[0] = CodigoEAPB;

                                // Número de la Factura - Posición 2
                                split[2] = NumeroFactura;

                                // Tipo de identificación del usuario - Posición 3
                                split[3] = TipoDocumento;

                                // Número Documento - Posición 4
                                split[4] = NumeroDocumento;

                                // Fecha de la Consulta - Posición 5
                                split[5] = FechaConsulta;

                                // Codigo Consulta - Posición 6
                                split[6] = CodigoConsulta;

                                // Finalidad de la consulta - Posición 7
                                split[7] = FinalidadConsulta;

                                // Causa Externa - Posición 8
                                split[8] = CausaExterna;

                                // Código del Diagnóstico Principal - Posición 9
                                split[9] = DiagnosticoPrincipal;

                                // Código del Diagnóstico Relacionado 1 - Posición 10
                                split[10] = DiagnosticoRelacionado1;

                                // Código del Diagnóstico Relacionado 2 - Posición 11
                                split[11] = DiagnosticoRelacionado2;

                                // Código del Diagnóstico Relacionado 3 - Posición 12
                                split[12] = DiagnosticoRelacionado3;

                                // Tipo de Diagnóstico Principal - Posición 13
                                split[13] = TipoDiagnosticoPrincipal;

                                // Valor de la Consulta - Posición 14
                                split[14] = ValorConsulta;

                                // Valor de la cuota moderadora - Posición 15
                                split[15] = ValorCuotaModeradora;

                                // Valor neto a pagar - Posición 16
                                split[16] = ValorNeto;

                                line = String.Join(",", split);

                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            #endregion

            #region AP EAPB

            foreach (var fi in di.GetFiles("*AP*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Número de la Factura - Posición Original 0
                                string NumeroFactura = split[0];

                                // Código del prestador de servicios de salud - Posición Original 1
                                string CodigoPrestador = split[1];

                                // Tipo de identificación del usuario - Posición Original 2
                                string TipoDocumento = split[2];

                                // Número Documento - Posición Original 3
                                string NumeroDocumento = split[3];

                                // Fecha del Procedimiento - Posición Original 4
                                string FechaProcedimiento = split[4];

                                // Número de autorización - Posición Original 5
                                string NumeroAutorizacion = split[5];

                                // Codigo del Procedimiento - Posición Original 6
                                string CodigoProcedimiento = split[6];

                                // Ambito del Procedimiento - Posición Original 7
                                string AmbitoProcedimiento = split[7];

                                // Finalidad del Procedimiento - Posición Original 8
                                string FinalidadProcedimiento = split[8];

                                // Personal que Atiende - Posición Original 9
                                string PersonalAtiende = split[9];

                                // Diagnóstico Principal - Posición Original 10
                                string DiagnosticoPrincipal = split[10];

                                // Diagnóstico Relacionado - Posición Original 12
                                string DiagnosticoRelacionado = split[11];

                                // Complicación - Posición Original 13
                                string Complicacion = split[12];

                                // Forma de realización del acto quirúrgico - Posición Original 14
                                string FormaActoQuirurgico = split[13];

                                // Valor del Procedimiento - Posición Original 15
                                string ValorProcedimiento = split[14];

                                // Estructura Nueva

                                String[] newArray = new string[14];

                                // Código de la entidad administradora del plan de beneficio - Posición 0
                                newArray[0] = CodigoEAPB;

                                // Código del prestador de servicios de salud - Posición 1
                                newArray[1] = CodigoPrestador;

                                // Número de la Factura - Posición 2
                                newArray[2] = NumeroFactura;

                                // Tipo de identificación del usuario - Posición 3
                                newArray[3] = TipoDocumento;

                                // Número Documento - Posición 4
                                newArray[4] = NumeroDocumento;

                                // Fecha del Procedimiento - Posición 5
                                newArray[5] = FechaProcedimiento;

                                // Código del Procedimiento - Posición 6
                                newArray[6] = CodigoProcedimiento;

                                // Ambito del Procedimiento - Posición 7
                                newArray[7] = AmbitoProcedimiento;

                                // Finalidad del Procedimiento - Posición 8
                                newArray[8] = FinalidadProcedimiento;

                                // Personal que Atiende - Posición 9
                                newArray[9] = PersonalAtiende;

                                // Diagnóstico Principal - Posición 10
                                newArray[10] = DiagnosticoPrincipal;

                                // Diagnóstico Relacionado - Posición 11
                                newArray[11] = DiagnosticoRelacionado;

                                // Complicación - Posición 12
                                newArray[12] = Complicacion;

                                // Valor Procedimiento - Posición 13
                                newArray[13] = ValorProcedimiento;

                                line = String.Join(",", newArray);
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            #endregion

            #region AU EAPB

            foreach (var fi in di.GetFiles("*AU*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Número de la Factura - Posición Original 0
                                string NumeroFactura = split[0];

                                // Código del prestador de servicios de salud - Posición Original 1
                                string CodigoPrestador = split[1];

                                // Tipo de identificación del usuario - Posición Original 2
                                string TipoDocumento = split[2];

                                // Número Documento - Posición Original 3
                                string NumeroDocumento = split[3];

                                // Fecha de ingreso del usuario a observacíón - Posición Original 4
                                string FechaIngresoObservacion = split[4];

                                // Hora de ingreso del usuario a observación - Posición Original 5
                                string HoraIngresoObservacion = split[5];

                                // Número de autorización - Posición Original 6
                                string NumeroAutorizacion = split[6];

                                // Causa Externa - Posición Original 7
                                string CausaExterna = split[7];

                                // Diagnóstico de salida - Posición Original 8
                                string DiagnosticoSalida = split[8];

                                // Diagnóstico relacionado No. 1, a la salida - Posición Original 9
                                string DiagnosticoRelacionado1Salida = split[9];

                                // Diagnóstico relacionado Nro. 2, a la salida - Posición Original 10
                                string DiagnosticoRelacionado2Salida = split[10];

                                // Diagnóstico relacionado Nro. 3, a la salida - Posición Original 11
                                string DiagnosticoRelacionado3Salida = split[11];

                                // Destino del usuario a la salida de observación - Posición Original 12
                                string DestinoSalida = split[12];

                                // Estado a la salida - Posición Original 13
                                string EstadoSalida = split[13];

                                // Causa básica de muerte en urgencias - Posición Original 14
                                string CausaBasicaMuerte = split[14];

                                // Fecha de salida del usuario de observación - Posición Original 15
                                string FechaSalida = split[15];

                                // Hora de salida del usuario de observación - Posición Original 16
                                string HoraSalida = split[16];

                                // Estructura Nueva

                                String[] newArray = new string[15];

                                // Código de la entidad administradora del plan de beneficio - Posición 0
                                newArray[0] = CodigoEAPB;

                                // Código del prestador de servicios de salud - Posición 1
                                newArray[1] = CodigoPrestador;

                                // Número de la Factura - Posición 2
                                newArray[2] = NumeroFactura;

                                // Tipo de identificación del usuario - Posición 3
                                newArray[3] = TipoDocumento;

                                // Número Documento - Posición 4
                                newArray[4] = NumeroDocumento;

                                // Fecha de ingreso del usuario a observacíón - Posición 5
                                newArray[5] = FechaIngresoObservacion;

                                // Causa Externa - Posición 6
                                newArray[6] = CausaExterna;

                                // Diagnóstico principal a la salida - Posición 7
                                newArray[7] = DiagnosticoSalida;

                                // Diagnóstico relacionado No. 1, a la salida - Posición 8
                                newArray[8] = DiagnosticoRelacionado1Salida;

                                // Diagnóstico relacionado No. 2, a la salida - Posición 9
                                newArray[9] = DiagnosticoRelacionado2Salida;

                                // Diagnóstico relacionado No. 3, a la salida - Posición 10
                                newArray[10] = DiagnosticoRelacionado3Salida;

                                // Destino del usuario a la salida de observación - Posición 11
                                newArray[11] = DestinoSalida;

                                // Estado a la salida - Posición 12
                                newArray[12] = EstadoSalida;

                                // Causa básica de muerte en urgencias - Posición 13
                                newArray[13] = CausaBasicaMuerte;

                                // Fecha de salida del usuario de observación - Posición 14
                                newArray[14] = FechaSalida;

                                line = String.Join(",", newArray);
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            #endregion

            #region AH EAPB

            foreach (var fi in di.GetFiles("*AH*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Número de la Factura - Posición Original 0
                                string NumeroFactura = split[0];

                                // Código del prestador de servicios de salud - Posición Original 1
                                string CodigoPrestador = split[1];

                                // Tipo de identificación del usuario - Posición Original 2
                                string TipoDocumento = split[2];

                                // Número Documento - Posición Original 3
                                string NumeroDocumento = split[3];

                                // Vía de ingreso a la institución - Posición Original 4
                                string ViaIngreso = split[4];

                                // Fecha de ingreso del usuario a la institución - Posición Original 5
                                string FechaIngreso = split[5];

                                // Hora de ingreso del usuario a la Institución - Posición Original 6
                                string HoraIngreso = split[6];

                                // Número de autorización - Posición Original 7
                                string NumeroAutorizacion = split[7];

                                // Causa Externa - Posición Original 8
                                string CausaExterna = split[8];

                                // Diagnóstico principal de ingreso - Posición Original 9
                                string DiagnosticoPrincipalIngreso = split[9];

                                // Diagnóstico principal de egreso - Posición Original 10
                                string DiagnosticoPrincipalEgreso = split[10];

                                // Diagnóstico relacionado Nro. 1 de egreso - Posición Original 11
                                string DiagnosticoRelacionado1Egreso = split[11];

                                // Diagnóstico relacionado Nro. 2 de egreso - Posición Original 12
                                string DiagnosticoRelacionado2Egreso = split[12];

                                // Diagnóstico relacionado Nro. 3 de egreso - Posición Original 13
                                string DiagnosticoRelacionado3Egreso = split[13];

                                // Diagnóstico de la complicación - Posición Original 14
                                string DiagnosticoComplicacion = split[14];

                                // Estado a la salida - Posición Original 15
                                string EstadoSalida = split[15];

                                // Diagnóstico de la causa básica de muerte - Posición Original 16
                                string DiagnosticoCausaBasicaMuerte = split[16];

                                // Fecha de egreso del usuario a la institución - Posición Original 17
                                string FechaEgreso = split[17];

                                // Hora de egreso del usuario de la institución - Posición Original 18
                                string HoraEgreso = split[18];

                                // Estructura Nueva

                                // Código de la entidad administradora del plan de beneficio - Posición 0
                                split[0] = CodigoEAPB;

                                // Código del prestador de servicios de salud - Posición 1
                                split[1] = CodigoPrestador;

                                // Número de la Factura - Posición 2
                                split[2] = NumeroFactura;

                                // Tipo de identificación del usuario - Posición 3
                                split[3] = TipoDocumento;

                                // Número Documento - Posición 4
                                split[4] = NumeroDocumento;

                                // Vía de ingreso a la institución - Posición 5
                                split[5] = ViaIngreso;

                                // Fecha de ingreso del usuario a la institución - Posición 6
                                split[6] = FechaIngreso;

                                // Hora de ingreso del usuario a la Institución - Posición 7
                                split[7] = HoraIngreso;

                                // Causa Externa - Posición 8
                                split[8] = CausaExterna;

                                // Diagnóstico principal de ingreso - Posición 9
                                split[9] = DiagnosticoPrincipalIngreso;

                                // Diagnóstico principal de egreso - Posición 10
                                split[10] = DiagnosticoPrincipalEgreso;

                                // Diagnóstico relacionado Nro. 1 de egreso - Posición 11
                                split[11] = DiagnosticoRelacionado1Egreso;

                                // Diagnóstico relacionado Nro. 2 de egreso - Posición 12
                                split[12] = DiagnosticoRelacionado2Egreso;

                                // Diagnóstico relacionado Nro. 3 de egreso - Posición 13
                                split[13] = DiagnosticoRelacionado3Egreso;

                                // Diagnóstico de la complicación - Posición 14
                                split[14] = "";

                                // Estado a la salida - Posición Original 15
                                split[15] = EstadoSalida;

                                //  Diagnóstico de la causa básica de muerte -Posición 16
                                split[16] = DiagnosticoCausaBasicaMuerte;

                                // Fecha de egreso del usuario a la institución - Posición 17
                                split[17] = FechaEgreso;

                                // Hora de egreso del usuario de la institución - Posición 18
                                split[18] = HoraEgreso;

                                line = String.Join(",", split);
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            #endregion

            #region AN EAPB

            foreach (var fi in di.GetFiles("*AN*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Número de la Factura - Posición Original 0
                                string NumeroFactura = split[0];

                                // Código del prestador de servicios de salud - Posición Original 1
                                string CodigoPrestador = split[1];

                                // Tipo de identificación de la madre - Posición Original 2
                                string TipoDocumento = split[2];

                                // Número de idenfificación  de la madre en el Sistema - Posición Original 3
                                string NumeroDocumento = split[3];

                                // Fecha de nacimiento del recién nacido - Posición Original 4
                                string FechaNacimiento = split[4];

                                // Hora de nacimiento - Posición Original 5
                                string HoraNacimiento = split[5];

                                // Edad gestacional - Posición Original 6
                                string EdadGestacional = split[6];

                                // Control prenatal - Posición Original 7
                                string ControlPrenatal = split[7];

                                // Sexo - Posición Original 8
                                string Sexo = split[8];

                                // Peso - Posición Original 9
                                string Peso = split[9];

                                // Diagnóstico del recién nacido - Posición Original 10
                                string DiagnosticoRecienNacido = split[10];

                                // Causa básica de muerte - Posición Original 11
                                string CausaBasicaMuerte = split[11];

                                // Fecha de muerte del recién nacido - Posición Original 12
                                string FechaMuerteRecienNacido = split[12];

                                // Hora de muerte del recién nacido - Posición Original 13
                                string HoraMuerteRecienNacido = split[13];

                                // Estructura Nueva

                                String[] newArray = new string[15];

                                // Código de la entidad administradora del plan de beneficio - Posición 0
                                newArray[0] = CodigoEAPB;

                                // Código del prestador de servicios de salud - Posición 1
                                newArray[1] = CodigoPrestador;

                                // Número de la Factura - Posición 2
                                newArray[2] = NumeroFactura;

                                // Tipo de identificación del usuario - Posición 3
                                newArray[3] = TipoDocumento;

                                // Número Documento - Posición 4
                                newArray[4] = NumeroDocumento;

                                // Fecha de nacimiento del recién nacido - Posición 5
                                newArray[5] = FechaNacimiento;

                                // Hora de nacimiento - Posición Original 6
                                newArray[6] = HoraNacimiento;

                                // Edad gestacional - Posición Original 7
                                newArray[7] = EdadGestacional;

                                // Control prenatal - Posición Original 8
                                newArray[8] = ControlPrenatal;

                                // Sexo - Posición 9
                                newArray[9] = Sexo;

                                // Peso - Posición 10
                                newArray[10] = Peso;

                                // Diagnóstico del recién nacido - Posición Original 11
                                newArray[11] = DiagnosticoRecienNacido;

                                // Causa básica de muerte - Posición Original 12
                                newArray[12] = CausaBasicaMuerte;

                                // Fecha de muerte del recién nacido - Posición Original 13
                                newArray[13] = FechaMuerteRecienNacido;

                                // Hora de muerte del recién nacido - Posición Original 14
                                newArray[14] = HoraMuerteRecienNacido;

                                line = String.Join(",", newArray);
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            #endregion

            #region AM EAPB

            foreach (var fi in di.GetFiles("*AM*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Número de la Factura - Posición Original 0
                                string NumeroFactura = split[0];

                                // Código del prestador de servicios de salud - Posición Original 1
                                string CodigoPrestador = split[1];

                                // Tipo de identificación de la madre - Posición Original 2
                                string TipoDocumento = split[2];

                                // Número de idenfificación  de la madre en el Sistema - Posición Original 3
                                string NumeroDocumento = split[3];

                                // Número de autorización - Posición Original 4
                                string NumeroAutorizacion = split[4];

                                // Código del medicamento - Posición Original 5
                                string CodigoMedicamento = split[5];

                                // Tipo de Medicamento - Posición Original 6
                                string TipoMedicamento = split[6];

                                // Nombre genérico del medicamento - Posición Original 7
                                string NombreGenerico = split[7];

                                // Forma farmacéutica - Posición Original 8
                                string FormaFarmaceutica = split[8];

                                // Concentración de medicamento - Posición Original 9
                                string Concentracion = split[9];

                                // Unidad de medida del medicamento - Posición Original 10
                                string UnidadMedida = split[10];

                                // Número de unidades - Posición Original 11
                                string NumeroUnidades = split[11];

                                // Valor unitario de medicamento - Posición Original 12
                                string ValorUnitario = split[12];

                                // Valor total de medicamento - Posición Original 13
                                string ValorTotal = split[13];

                                // Estructura Nueva

                                String[] newArray = new string[15];

                                // Código de la entidad administradora del plan de beneficio - Posición 0
                                newArray[0] = CodigoEAPB;

                                // Código del prestador de servicios de salud - Posición 1
                                newArray[1] = CodigoPrestador;

                                // Número de la Factura - Posición 2
                                newArray[2] = NumeroFactura;

                                // Tipo de identificación del usuario - Posición 3
                                newArray[3] = TipoDocumento;

                                // Número Documento - Posición 4
                                newArray[4] = NumeroDocumento;

                                // Edad - Posición 5
                                newArray[5] = ObtenerEdad(NumeroDocumento);

                                // Unidad de medida de la edad - Posición Original 6
                                newArray[6] = ObtenerUnidadMedidaEdad(NumeroDocumento);

                                // Nombre del medicamento - Posición Original 7
                                newArray[7] = NombreGenerico;

                                // Tipo de Medicamento - Posición Original 8
                                newArray[8] = TipoMedicamento;

                                // Forma farmacéutica - Posición 9
                                newArray[9] = FormaFarmaceutica;

                                // Concentración del medicamento - Posición 10
                                newArray[10] = Concentracion;

                                // Unidad de medida del medicamento - Posición Original 11
                                newArray[11] = UnidadMedida;

                                // Número de unidades - Posición Original 12
                                newArray[12] = NumeroUnidades;

                                // Valor unitario del medicamento - Posición Original 13
                                newArray[13] = ValorUnitario;

                                // Valor total del medicamento - Posición Original 14
                                newArray[14] = ValorTotal;

                                line = String.Join(",", newArray);
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            #endregion

            #endregion

            for (int i = 0; i <= 100; i++)
            {
                bgwEAPB.ReportProgress(i);
                Thread.Sleep(10);
            }
        }

        private void bgwEAPB_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblEstatusEAPB.Visible = true;
            prgBarEAPB.Value = e.ProgressPercentage;
            prgBarEAPB.Update();
            lblEstatusEAPB.Text = "Procesando...... " + prgBarEAPB.Value.ToString() + "%";
        }

        private void bgwEAPB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblEstatusEAPB.Text = "Finalizado";
        }

        public string ObtenerEdad(String NumeroDocumento)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (var fi in di.GetFiles("*US*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Windows-1252")))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                string NumeroDocumentoUS = split[2];

                                if (NumeroDocumento == NumeroDocumentoUS)
                                {
                                    Edad = split[6];
                                }
                            }

                            lines.Add(line);
                        }
                    }

                }
            }

            return Edad;
        }

        public string ObtenerUnidadMedidaEdad(String NumeroDocumento)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (var fi in di.GetFiles("*US*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Windows-1252")))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                string NumeroDocumentoUS = split[2];

                                if (NumeroDocumento == NumeroDocumentoUS)
                                {
                                    UnidadMedidaEdad = split[7];
                                }
                            }

                            lines.Add(line);
                        }
                    }

                }
            }

            return UnidadMedidaEdad;
        }

        private void FrmCambioEstructura_Load(object sender, EventArgs e)
        {
            // Oculta Etiqueta de Progreso
            lblEstatusEAPB.Visible = false;

            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnProcesarEAPB.Enabled = false;
        }

        private void pnlCambioEsctuctura_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
