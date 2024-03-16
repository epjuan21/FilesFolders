using FilesFolders.Clases;
using FilesFolders.ManejoArchivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace FilesFolders
{
    public partial class FrmRIPS : Form
    {
        public FrmRIPS()
        {
            InitializeComponent();
        }

        #region Variables
        string dirPath;
        string Edad;
        string UnidadMedidaEdad;
        readonly CWork bgwAC = new CWork();
        readonly CWork bgwAP = new CWork();
        readonly CWork bgwAT = new CWork();
        readonly CWork bgwAU = new CWork();
        readonly CWork bgwDOC = new CWork();
        readonly CWork bgwUS = new CWork();
        readonly CWork bgwAH = new CWork();
        readonly CWork bgwAF = new CWork();
        readonly CWork bgwAM = new CWork();

        readonly CArchivos CArchivos = new CArchivos();
        readonly Correcciones Correcciones = new Correcciones();

        List<Departamento> departamentos = Departamento.GetDepartamentos();
        List<Municipio> municipios = Municipio.GetMunicipios();
        #endregion

        private void FrmRIPS_Load(object sender, EventArgs e)
        {
            lblTotalAC.Text = string.Empty;
            lblTotalAP.Text = string.Empty;
            lblTotalAM.Text = string.Empty;
            lblTotalAT.Text = string.Empty;
            lblTotalUS.Text = string.Empty;
            lblTotalAU.Text = string.Empty;
            lblTotalAH.Text = string.Empty;

            // Oculta Etiqueta de Progreso
            lblStatusUS.Visible = false;
            lblStatusAC.Visible = false;
            lblStatusAP.Visible = false;
            lblStatusAT.Visible = false;
            lblStatusAU.Visible = false;
            lblStatusDoc.Visible = false;
            lblStatusAH.Visible = false;
            lblStatusAF.Visible = false;
            lblStatusAM.Visible = false;

            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnAC.Enabled = false;
            btnAP.Enabled = false;
            btnUS.Enabled = false;
            btnDoc.Enabled = false;
            btnAT.Enabled = false;
            btnAU.Enabled = false;
            btnAH.Enabled = false;
            btnAF.Enabled = false;
            btnAM.Enabled = false;

            btnEliminarAd.Enabled = false;
        }

        #region Ruta Cargue Masivo
        // Seleccionamos la Carpeta donde se ecuentran los RIPS
        private void BtnRuta_Click(object sender, EventArgs e)
        {
            // Ubicación de la Carpeta con los RIPS
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = folderBrowserDialog1.SelectedPath;

                // Obtenemos la Cantidad de Archivos AC
                int CantidadAC = Directory.GetFiles(dirPath, "AC*", SearchOption.AllDirectories).Length;
                lblTotalAC.Text = CantidadAC.ToString();

                // Obtenemos la Cantidad de Archivos AP
                int CantidadAP = Directory.GetFiles(dirPath, "AP*", SearchOption.AllDirectories).Length;
                lblTotalAP.Text = CantidadAP.ToString();

                // Obtenemos la Cantidad de Archivos AM
                int CantidadAM = Directory.GetFiles(dirPath, "AM*", SearchOption.AllDirectories).Length;
                lblTotalAM.Text = CantidadAM.ToString();

                // Obtenemos la Cantidad de Archivos AT
                int CantidadAT = Directory.GetFiles(dirPath, "AT*", SearchOption.AllDirectories).Length;
                lblTotalAT.Text = CantidadAT.ToString();

                // Obtenemos la Cantidad de Archivos AU
                int CantidadAU = Directory.GetFiles(dirPath, "AU*", SearchOption.AllDirectories).Length;
                lblTotalAU.Text = CantidadAU.ToString();

                // Obtenemos la Cantidad de Archivos US
                int CantidadUS = Directory.GetFiles(dirPath, "US*", SearchOption.AllDirectories).Length;
                lblTotalUS.Text = CantidadUS.ToString();

                // Obtenemos la Cantidad de Archivos AH
                int CantidadAH = Directory.GetFiles(dirPath, "AH*", SearchOption.AllDirectories).Length;
                lblTotalAH.Text = CantidadAH.ToString();

                // Habilitamos los Botones
                btnUS.Enabled = true;
                btnAC.Enabled = true;
                btnAP.Enabled = true;
                btnDoc.Enabled = true;
                btnAT.Enabled = true;
                btnAU.Enabled = true;
                btnAH.Enabled = true;
                btnAF.Enabled = true;
                btnAM.Enabled = true;
                btnEliminarAd.Enabled = true;

                chkBoxLonDoc.Enabled = true;
            }
        }
        #endregion

        #region US
        private void BtnUS_Click_1(object sender, EventArgs e)
        {
            bgwUS.ODoWorker(BgwUS_DoWork, BgwUS_ProgressChanged, BgwUS_RunWorkerCompleted);
        }

        private void BgwUS_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories).Where(file => file.Extension.Equals(".txt") && file.Name.StartsWith("US")))
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

                                #region Tipo Documento

                                // Tipo de identificación del usuario - Posición 0

                                if (chkBoxTipoDocSSSA.CheckState == CheckState.Checked)
                                {
                                    split[0] = Correcciones.CorregirTipoDocumento(ref line, 0, 8, -1, 1, 9, "");
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Codigo Entidad Administradora

                                // Código entidad administradora

                                string codigoEntidadAdministradora = split[2];

                                if (chkBoxEntidadAdministradora.CheckState == CheckState.Checked && String.IsNullOrEmpty(codigoEntidadAdministradora))
                                {
                                    split[2] = "05091";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (
                                        chkBoxAFSSSA.CheckState == CheckState.Checked &&
                                        (codigoEntidadAdministradora == "DLS001" ||
                                        codigoEntidadAdministradora == "FMS001" || codigoEntidadAdministradora == "AT1501" || codigoEntidadAdministradora == "36906"))
                                {
                                    split[2] = "05091";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Apellidos y Nombres

                                // Primer Apellido - Posición 4
                                string primerApellido = split[4];

                                // Reemplazar Caracteres Especiales

                                primerApellido = primerApellido.Replace("ñ", "N");
                                primerApellido = primerApellido.Replace(".", "");

                                // Borrar Espacios
                                split[4] = primerApellido.Trim();

                                // Segundo Apellido - Posición 5
                                string segundoApellido = split[5];

                                // Reemplazar Caracteres Especiales

                                segundoApellido = segundoApellido.Replace("ñ", "N");

                                // Borrar Espacios
                                split[5] = segundoApellido.Trim();

                                // Primer Nombre - Posición 6
                                string primerNombre = split[6];
                                split[6] = primerNombre.Trim();

                                // Segundo Nombre - Posición 7
                                string segundoNombre = split[7];
                                split[7] = segundoNombre.Trim();

                                line = String.Join(",", split);
                                contadorErrores++;

                                // Corregir Caracter Ñ para SAVIASALUD
                                if (chkBoxCarEsp.CheckState == CheckState.Checked)
                                {
                                    // Primer Apellido
                                    split[4] = primerApellido.Replace("Ñ", "N");
                                    line = String.Join(",", split);
                                    contadorErrores++;

                                    // Segundo Apellido
                                    split[5] = segundoApellido.Replace("Ñ", "N");
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Departamento
                                // Departamento - Posición 11
                                foreach (Departamento departamento in departamentos)
                                {
                                    if (split[11] == departamento.departamentoViejo)
                                    {
                                        split[11] = departamento.departamentoNuevo;
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Municipio
                                // Municipio - Posición 12
                                foreach (Municipio municipio in municipios)
                                {
                                    if (split[12] == municipio.municipioViejo)
                                    {
                                        split[12] = municipio.municipioNuevo;
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region TipoUsuario
                                // Tipo de Usuario

                                // Obtenemos la EPS
                                string EAPB = split[2];

                                if (EAPB == "EPSS40")
                                {
                                    split[3] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (EAPB == "EPS040")
                                {
                                    split[3] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("Windows-1252")))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                // Eliminar Ultimo Salto de Linea CR LF del Archivo

                string myFileData = File.ReadAllText(path);

                if (myFileData.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(path, myFileData.TrimEnd(Environment.NewLine.ToCharArray()), Encoding.GetEncoding("Windows-1252"));
                }
            }

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwUS.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(100);
            }
        }

        private void BgwUS_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusUS.Visible = true;
            prgBarUS.Value = e.ProgressPercentage;
            lblStatusUS.Text = "Procesando...... " + prgBarUS.Value.ToString() + "%";
        }

        private void BgwUS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusUS.Text = "Finalizado";
        }
        #endregion

        #region AC
        private void BtnAC_Click_1(object sender, EventArgs e)
        {
            bgwAC.ODoWorker(BgwAC_DoWork, BgwAC_ProgressChanged, BgwAC_RunWorkerCompleted);
        }

        private void BgwAC_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories).Where(file => file.Extension.Equals(".txt") && file.Name.StartsWith("AC")))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();
                //List<String> modifiedLines = new List<String>();

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

                                int EdadUsuario = CArchivos.ObtenerEdad(split[3], dirPath);
                                string UnidadMedidaEdad = CArchivos.ObtenerUnidadMedidaEdad(split[3], dirPath);

                                #region Factura
                                // Número Factura - Posición 0
                                string NumeroFactura = split[0];

                                // Obtenemos la Primera Letra del Número de la Factura
                                string FirsLetter = NumeroFactura.Substring(0, 1);

                                int Longitud = NumeroFactura.Length;

                                if (ChkBoxFac.CheckState == CheckState.Checked && FirsLetter == "V")
                                {
                                    split[0] = NumeroFactura.Substring(3, Longitud - 3);
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (chkBoxPrefijoFE.CheckState == CheckState.Checked)
                                {
                                    if (!NumeroFactura.Contains("FE"))
                                    {
                                        if (FirsLetter == "V")
                                        {
                                            NumeroFactura = NumeroFactura.Substring(3, Longitud - 3);

                                            NumeroFactura = String.Concat("FE", NumeroFactura);

                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                        else
                                        {
                                            NumeroFactura = String.Concat("FE", NumeroFactura);
                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                    }
                                }

                                #endregion

                                #region Tipo Documento

                                // Tipo de identificación del usuario - Posición 2

                                if (chkBoxTipoDocSSSA.CheckState == CheckState.Checked)
                                {
                                    split[2] = Correcciones.CorregirTipoDocumento(ref line, 2, -1, EdadUsuario, 3, -1, UnidadMedidaEdad);
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Número de autorización
                               
                                // Número de autorización - Posición 5
                               
                                if (chkBoxAutCapita.CheckState == CheckState.Checked)
                                {
                                    if (split[5] == "")
                                    {
                                        split[5] = "1-1";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                
                                #endregion

                                #region CUPS
                                // Codigo CUPS Archivo AC - Posición 6

                                // Eliminar Asteriscos y Guiones
                                split[6] = Correcciones.EliminarCaracteresEspeciales(split[6]);
                                line = String.Join(",", split);
                                contadorErrores++;

                                // Corrección de Códigos
                                split[6] = Correcciones.CorregirCUPS(ref line, 6);
                                line = String.Join(",", split);
                                contadorErrores++;

                                #endregion

                                #region Finalidad

                                // Finalidad - Posicion 7

                                split[7] = Correcciones.CorregirFinalidad(ref line, 6, 7, 9, "AC");
                                line = String.Join(",", split);
                                contadorErrores++;

                                #endregion

                                #region Causa Externa
                                // Causa Externa - Posicion 8
                                if (split[6] == "890201" && split[8] == "")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890203" && split[8] == "")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890301" && split[8] == "")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890305" && split[8] == "")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890305" && split[8] == "" && split[9] == "Z300")
                                {
                                    split[8] = "15";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890601" && split[8] == "")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890701" && split[8] == "")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890703" && split[8] == "")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                // Si Diagnostico Empieza por Z
                                // Causa Externa debe Ser 15 - Otra
                                if (split[8] != "" && split[9] != "")
                                {
                                    if (split[8] == "13" && (split[9].Substring(0, 1) == "Z"))
                                    {
                                        if (split[9] == "Z016")
                                        {
                                            split[8] = "13";
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                        else
                                        {
                                            split[8] = "15";
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }

                                    }
                                }

                                if (split[7] == "10" && split[8] == "15" && split[9] == "Z016" && chkACSumimedical.CheckState == CheckState.Checked)
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                // Finalidad 07 Detección de alteraciones del adulto
                                if (split[8] == "10" && split[9] == "J441")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Diagnóstico Principal
                                // Código del diagnóstico principal - Posicion  9

                                // Evaluar si la primera letra es minuscula

                                // Obtenemos la Primera Letra

                                if (split[9] != "")
                                {
                                    string firstLetter = split[9].Substring(0, 1);

                                    if (char.IsLower(Convert.ToChar(firstLetter)))
                                    {
                                        split[9] = split[9].ToUpper();
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                if (split[7] == "06" && split[9] == "K021")
                                {
                                    split[9] = "Z012";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[9] == "I844")
                                {
                                    split[9] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[9] == "K589")
                                {
                                    split[9] = "K588";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[9] == "M329")
                                {
                                    split[9] = "M331";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "")
                                {
                                    split[9] = "R101";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[9] == "Z002" && EdadUsuario < 5 && UnidadMedidaEdad == "1")
                                {
                                    split[9] = "Z001";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #region Correcciones para SSSA
                                if (chkBoxDXSSSA.CheckState == CheckState.Checked)
                                {
                                    if (split[9] == "A099")
                                    {
                                        split[9] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "H103")
                                    {
                                        split[9] = "H118";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "K649")
                                    {
                                        split[9] = "I842";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "M179")
                                    {
                                        split[9] = "L932";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "M321")
                                    {
                                        split[9] = "L932";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "I489")
                                    {
                                        split[9] = "I48X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "U071")
                                    {
                                        split[9] = "J22X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "U072")
                                    {
                                        split[9] = "J22X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Correcciones para SAVIASALUD
                                // Correccion para SAVIASALUD
                                if (chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    if (split[9] == "A09X")
                                    {
                                        split[9] = "A099";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "D752")
                                    {
                                        split[9] = "D572";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "H547")
                                    {
                                        split[9] = "H546";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "I842")
                                    {
                                        split[9] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "I848")
                                    {
                                        split[9] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "I841")
                                    {
                                        split[9] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "I845")
                                    {
                                        split[9] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "I48X")
                                    {
                                        split[9] = "I489";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "I849")
                                    {
                                        split[9] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "K359")
                                    {
                                        split[9] = "K358";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "M725")
                                    {
                                        split[9] = "M726";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "N180")
                                    {
                                        split[9] = "N179";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "O60X")
                                    {
                                        split[9] = "O600";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // Q314 ESTRIDOR LARINGEO CONGENITO
                                    // J042 LARINGOTRAQUEITIS AGUDA
                                    if (split[9] == "Q314")
                                    {
                                        split[9] = "J042";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "R500")
                                    {
                                        split[9] = "R509";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                #endregion

                                #endregion

                                #region Diagnostico Relacionado 1
                                // Código del diagnóstico relacionado 1 - Posición 10

                                // Evaluar si la primera letra es minuscula

                                // Obtenemos la Primera Letra

                                if (split[11] != "")
                                {
                                    string firstLetter = split[11].Substring(0, 1);

                                    if (char.IsLower(Convert.ToChar(firstLetter)))
                                    {
                                        split[11] = split[11].ToUpper();
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                #region Correcciones para SSSA
                                if (chkBoxDXSSSA.CheckState == CheckState.Checked)
                                {
                                    if (split[10] == "A099")
                                    {
                                        split[10] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "K588")
                                    {
                                        split[10] = "K580";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "K649")
                                    {
                                        split[10] = "I842";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I489")
                                    {
                                        split[10] = "I48X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "U071")
                                    {
                                        split[10] = "J181";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "U072")
                                    {
                                        split[10] = "J181";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Correcciones para SAVIASALUD
                                if (chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    if (split[10] == "A09X")
                                    {
                                        split[10] = "A099";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "D752")
                                    {
                                        split[10] = "D572";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "H547")
                                    {
                                        split[10] = "H546";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I48X")
                                    {
                                        split[10] = "I489";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I841")
                                    {
                                        split[10] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I842")
                                    {
                                        split[10] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I843")
                                    {
                                        split[10] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I844")
                                    {
                                        split[10] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I845")
                                    {
                                        split[10] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I848")
                                    {
                                        split[10] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I849")
                                    {
                                        split[10] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "M725")
                                    {
                                        split[10] = "M726";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "N180")
                                    {
                                        split[10] = "N179";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "N188")
                                    {
                                        split[10] = "N189";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "O60X")
                                    {
                                        split[10] = "O600";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // Q314 ESTRIDOR LARINGEO CONGENITO
                                    // J042 LARINGOTRAQUEITIS AGUDA
                                    if (split[10] == "Q314")
                                    {
                                        split[10] = "J042";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "R500")
                                    {
                                        split[10] = "R509";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #endregion

                                #region Diagnostico Relacionado 2
                                // Código del diagnóstico relacionado 2 - Posición 11

                                // Evaluar si la primera letra es minuscula

                                // Obtenemos la Primera Letra

                                if (split[11] != "")
                                {
                                    string firstLetter = split[11].Substring(0, 1);

                                    if (char.IsLower(Convert.ToChar(firstLetter)))
                                    {
                                        split[11] = split[11].ToUpper();
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                #region Correcciones para SSSA
                                if (chkBoxDXSSSA.CheckState == CheckState.Checked)
                                {
                                    if (split[11] == "A099")
                                    {
                                        split[11] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[11] == "K649")
                                    {
                                        split[11] = "I842";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[11] == "I489")
                                    {
                                        split[11] = "I48X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "U072")
                                    {
                                        split[9] = "J22X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Correcciones para SAVIASALUD
                                if (chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    if (split[11] == "A09X")
                                    {
                                        split[11] = "A099";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[11] == "H547")
                                    {
                                        split[11] = "H546";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[11] == "I48X")
                                    {
                                        split[11] = "I489";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[11] == "N180")
                                    {
                                        split[11] = "N179";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #endregion

                                #region Diagnostico Relacionado 3
                                // Código del diagnóstico relacionado 3 - Posición 12

                                // Corregir letras minusculas
                                if (split[12] != "")
                                {
                                    string firstLetter = split[12].Substring(0, 1);

                                    if (char.IsLower(Convert.ToChar(firstLetter)))
                                    {
                                        split[12] = split[12].ToUpper();
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                #region Correcciones para SSSA
                                if (chkBoxDXSSSA.CheckState == CheckState.Checked)
                                {
                                    if (split[12] == "A099")
                                    {
                                        split[12] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[12] == "K649")
                                    {
                                        split[12] = "I842";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[12] == "I489")
                                    {
                                        split[12] = "I48X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Correcciones para SAVIASALUD
                                if (chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    if (split[12] == "I48X")
                                    {
                                        split[12] = "I489";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[12] == "I849")
                                    {
                                        split[12] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #endregion

                                #region Tipo Diagnostico Principal
                                // Tipo de diagnóstico principal - Posicion 13
                                if (split[13] == "")
                                {
                                    split[13] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Valor Consulta

                                // Valor consulta - Posición 14

                                string valorConsulta = split[14];

                                double valorConsultaDouble;

                                valorConsultaDouble = Math.Truncate(Convert.ToDouble(valorConsulta));

                                if (chkBoxValSum.CheckState == CheckState.Checked)
                                {
                                    split[14] = valorConsultaDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Valor Cuota Moderadora

                                // Valor de la cuota moderadora - Posición 15

                                string valorCuota = split[15];

                                double valorCuotaDouble = Math.Truncate(Convert.ToDouble(valorCuota));

                                if (chkBoxValSum.CheckState == CheckState.Checked)
                                {
                                    split[15] = valorCuotaDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                // Valor Neto - Posición 16
                                string valorNeto = split[16];

                                if (valorCuota != "0.00" && chkBoxValCm.CheckState == CheckState.Checked)
                                {
                                    split[16] = valorConsulta;
                                    split[15] = "0.00";

                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Valor Neto

                                double valorNetoDouble = Math.Truncate(Convert.ToDouble(valorNeto));

                                if (chkBoxValSum.CheckState == CheckState.Checked)
                                {
                                    split[16] = valorNetoDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion
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

                // Eliminar Ultimo Salto de Linea CR LF del Archivo

                string myFileData = File.ReadAllText(path);

                if (myFileData.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(path, myFileData.TrimEnd(Environment.NewLine.ToCharArray()));
                }
            }

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwAC.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(100);
            }

        }

        private void BgwAC_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAC.Visible = true;
            prgBarAC.Value = e.ProgressPercentage;
            lblStatusAC.Text = "Procesando...... " + prgBarAC.Value.ToString() + "%";
        }

        private void BgwAC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAC.Text = "Finalizado";
        }
        #endregion

        #region AP
        private void BtnAP_Click_1(object sender, EventArgs e)
        {
            bgwAP.ODoWorker(BgwAP_DoWork, BgwAP_ProgressChanged, BgwAP_RunWorkerCompleted);
        }

        private void BgwAP_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories).Where(file => file.Extension.Equals(".txt") && file.Name.StartsWith("AP")))
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

                                int EdadUsuario = CArchivos.ObtenerEdad(split[3], dirPath);
                                string UnidadMedidaEdad = CArchivos.ObtenerUnidadMedidaEdad(split[3], dirPath);

                                #region Factura
                                // Número Factura - Posición 0
                                string NumeroFactura = split[0];

                                // Obtenemos la Primera Letra del Número de la Factura
                                string FirsLetter = NumeroFactura.Substring(0, 1);

                                int Longitud = NumeroFactura.Length;

                                if (ChkBoxFac.CheckState == CheckState.Checked)
                                {
                                    if (FirsLetter == "V")
                                    {
                                        split[0] = NumeroFactura.Substring(3, Longitud - 3);
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                if (chkBoxPrefijoFE.CheckState == CheckState.Checked)
                                {
                                    if (!NumeroFactura.Contains("FE"))
                                    {
                                        if (FirsLetter == "V")
                                        {
                                            NumeroFactura = NumeroFactura.Substring(3, Longitud - 3);

                                            NumeroFactura = String.Concat("FE", NumeroFactura);

                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                        else
                                        {
                                            NumeroFactura = String.Concat("FE", NumeroFactura);
                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                    }
                                }
                                #endregion

                                #region Tipo Documento

                                // Tipo de identificación del usuario - Posición 2

                                if (chkBoxTipoDocSSSA.CheckState == CheckState.Checked)
                                {
                                    split[2] = Correcciones.CorregirTipoDocumento(ref line, 2, -1, EdadUsuario, 3, -1, UnidadMedidaEdad);
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Número de autorización
                                // Número de autorización - Posición 5

                                if (chkBoxAutCapita.CheckState == CheckState.Checked)
                                {
                                    if (split[5] == "")
                                    {
                                        split[5] = "1-1";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region CUPS
                                // Codigo CUPS Archivo AP - Posoción 6

                                // Eliminar Asteriscos y Guiones
                                split[6] = Correcciones.EliminarCaracteresEspeciales(split[6]);
                                line = String.Join(",", split);

                                // Corrección de Códigos
                                split[6] = Correcciones.CorregirCUPS(ref line, 6);
                                line = String.Join(",", split);

                                #endregion

                                #region Ambito
                                // Ambito del Procedimiento - Posición 7

                                // Correcciones Ambito
                                split[7] = Correcciones.CorregirAmbito(ref line, 6, 7);
                                line = String.Join(",", split);

                                #endregion

                                #region Finalidad
                                // Finalidad - Posición 8

                                split[8] = Correcciones.CorregirFinalidad(ref line, 6, 8, 10, "AP");
                                line = String.Join(",", split);

                                #endregion

                                #region Personal
                                // Personal que Atiende - Posición 9
                                if (split[9] == "0")
                                {
                                    split[9] = "";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Diagnostico Principal
                                // Diagnóstico Principal - Posición 10

                                // Evaluar si la primera letra es minuscula
                                // Obtenemos la Primera Letra
                                if (split[10] != "" && chkBoxDxAxSum.CheckState != CheckState.Checked)
                                {
                                    string firstLetter = split[10].Substring(0, 1);

                                    if (char.IsLower(Convert.ToChar(firstLetter)))
                                    {
                                        split[10] = split[10].ToUpper();
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                // Inicio Correcciones para SSSA
                                if (chkBoxDXSSSA.CheckState == CheckState.Checked)
                                {
                                    if (split[10] == "A090")
                                    {
                                        split[10] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "A099")
                                    {
                                        split[10] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "K649")
                                    {
                                        split[10] = "I842";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I489")
                                    {
                                        split[10] = "I48X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "M321")
                                    {
                                        split[10] = "L932";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "U072")
                                    {
                                        split[10] = "J181";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                // Final Correcciones para SSSA

                                // Inicio Correcciones para SUMIMEDICAL
                                if (chkBoxDxAxSum.CheckState == CheckState.Checked)
                                {
                                    // Quitar Diagnóstico Principal para Sumimedical
                                    if (
                                        split[6].Substring(0, 2) == "21" ||
                                        split[6].Substring(0, 2) == "23" ||
                                        split[6].Substring(0, 2) == "57" ||
                                        split[6].Substring(0, 2) == "67" ||
                                        split[6].Substring(0, 2) == "69" ||
                                        split[6].Substring(0, 2) == "73" ||
                                        split[6].Substring(0, 2) == "87" ||
                                        split[6].Substring(0, 2) == "89" ||
                                        split[6].Substring(0, 2) == "90" ||
                                        split[6].Substring(0, 2) == "95" ||
                                        split[6].Substring(0, 2) == "96" ||
                                        split[6].Substring(0, 2) == "98" ||
                                        split[6].Substring(0, 2) == "99" ||
                                        split[6].Substring(0, 2) == "93"
                                        )
                                    {
                                        split[10] = "";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                // Final Correcciones para SUMIMEDICAL

                                // Inicio Correcciones para SURA
                                if (chkBoxAQSura.CheckState == CheckState.Checked)
                                {
                                    // Quitar Diagnóstico Principal para SURA
                                    if (
                                        split[6].Substring(0, 2) == "21" ||
                                        split[6].Substring(0, 2) == "67" ||
                                        split[6].Substring(0, 2) == "69" ||
                                        split[6].Substring(0, 2) == "73" ||
                                        split[6].Substring(0, 2) == "87" ||
                                        split[6].Substring(0, 2) == "89" ||
                                        split[6].Substring(0, 2) == "90" ||
                                        split[6].Substring(0, 2) == "95" ||
                                        split[6].Substring(0, 2) == "96" ||
                                        split[6].Substring(0, 2) == "97" ||
                                        split[6].Substring(0, 2) == "98" ||
                                        split[6].Substring(0, 2) == "99" ||
                                        split[6].Substring(0, 2) == "93"
                                        )
                                    {
                                        split[10] = "";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                // Final Correcciones para SURA

                                // Inicio Correcciones para SAVIASALUD
                                if (chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    if (split[10] == "A09X")
                                    {
                                        split[10] = "A090";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "H547")
                                    {
                                        split[10] = "H546";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I48X")
                                    {
                                        split[10] = "I489";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I845")
                                    {
                                        split[10] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "K359")
                                    {
                                        split[10] = "K358";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "N180")
                                    {
                                        split[10] = "N179";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "R500")
                                    {
                                        split[10] = "R509";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    // Q314 ESTRIDOR LARINGEO CONGENITO
                                    // J042 LARINGOTRAQUEITIS AGUDA

                                    if (split[10] == "Q314")
                                    {
                                        split[10] = "J042";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    if (split[10] == "R500")
                                    {
                                        split[10] = "R509";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                // Final Correcciones para SAVIASALUD

                                #endregion

                                #region Diagnostico Relacionado
                                // Diagnóstico Relacionado - Posición 11

                                // Corregir Diagnostico para SAVIASALUD
                                if (chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    if (split[11] == "A09X")
                                    {
                                        split[11] = "A099";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[11] == "R500")
                                    {
                                        split[11] = "R509";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                // Inicio Corregir Diagnóstico Relacionado para SURA
                                if (chkBoxAQSura.CheckState == CheckState.Checked)
                                {
                                    // Si el CUPS tiene alguno de lso siguientes Códigos
                                    // Se elimina el Diagnóstico Relacionado 1
                                    if (
                                        split[6].Substring(0, 2) == "21" ||
                                        split[6].Substring(0, 2) == "23" ||
                                        split[6].Substring(0, 2) == "57" ||
                                        split[6].Substring(0, 2) == "67" ||
                                        split[6].Substring(0, 2) == "69" ||
                                        split[6].Substring(0, 2) == "73" ||
                                        split[6].Substring(0, 2) == "87" ||
                                        split[6].Substring(0, 2) == "89" ||
                                        split[6].Substring(0, 2) == "90" ||
                                        split[6].Substring(0, 2) == "91" ||
                                        split[6].Substring(0, 2) == "95" ||
                                        split[6].Substring(0, 2) == "96" ||
                                        split[6].Substring(0, 2) == "97" ||
                                        split[6].Substring(0, 2) == "98" ||
                                        split[6].Substring(0, 2) == "99" ||
                                        split[6].Substring(0, 2) == "93"
                                        )
                                    {
                                        split[11] = "";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                // Final Corregir Diagnóstico Relacionado para SURA

                                // Corregir Diagnostico para SSSA
                                if (chkBoxDXSSSA.CheckState == CheckState.Checked)
                                {
                                    if (split[11] == "A099")
                                    {
                                        split[11] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                if (split[11] == "H547")
                                {
                                    split[11] = "H546";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[11] == "N180")
                                {
                                    split[11] = "N179";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Complicacion
                                // Complicación - Posición 12

                                // Corregir Código Complicación para SURA
                                if (chkBoxAQSura.CheckState == CheckState.Checked)
                                {
                                    // Quitar Diagnóstico Principal para SURA
                                    if (
                                        split[6].Substring(0, 2) == "21" ||
                                        split[6].Substring(0, 2) == "23" ||
                                        split[6].Substring(0, 2) == "67" ||
                                        split[6].Substring(0, 2) == "69" ||
                                        split[6].Substring(0, 2) == "73" ||
                                        split[6].Substring(0, 2) == "87" ||
                                        split[6].Substring(0, 2) == "89" ||
                                        split[6].Substring(0, 2) == "90" ||
                                        split[6].Substring(0, 2) == "95" ||
                                        split[6].Substring(0, 2) == "96" ||
                                        split[6].Substring(0, 2) == "98" ||
                                        split[6].Substring(0, 2) == "99" ||
                                        split[6].Substring(0, 2) == "93"
                                        )
                                    {
                                        split[12] = "";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Forma Acto Quirurgico
                                // Forma de realización del acto quirúrgico - Posición 13

                                // Quitar Acto Quirurgico para Sumimedical
                                if (split[13] != "" && chkBoxDxAxSum.CheckState == CheckState.Checked)
                                {
                                    split[13] = "";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[13] == "" && chkBoxDxAxSum.CheckState != CheckState.Checked)
                                {
                                    split[13] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                // Modificar Acto Quirurgico Para SAVIASALUD Segun CUPS

                                // Codigo CUPS Archivo AP - Posoción 6

                                if (chkBoxAxSavia.CheckState == CheckState.Checked)
                                {
                                    if (
                                        split[6].Substring(0, 2) == "69" ||
                                        split[6].Substring(0, 2) == "87" ||
                                        split[6].Substring(0, 2) == "89" ||
                                        split[6].Substring(0, 2) == "90" ||
                                        split[6].Substring(0, 2) == "95" ||
                                        split[6].Substring(0, 2) == "96" ||
                                        split[6].Substring(0, 2) == "98" ||
                                        split[6].Substring(0, 2) == "99" ||
                                        split[6].Substring(0, 2) == "93"
                                        )
                                    {
                                        split[13] = "";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    else if (
                                        split[6].Substring(0, 2) == "23" ||
                                        split[6].Substring(0, 2) == "57" ||
                                        split[6].Substring(0, 2) == "86"

                                            )
                                    {
                                        split[13] = "1";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                // Modificar Acto Quirurgico Para SSSA Segun CUPS

                                if (chkBoxSSSA.CheckState == CheckState.Checked)
                                {
                                    if (
                                        split[6].Substring(0, 2) == "21" ||
                                        split[6].Substring(0, 2) == "23" ||
                                        split[6].Substring(0, 2) == "24" ||
                                        split[6].Substring(0, 2) == "57" ||
                                        split[6].Substring(0, 2) == "67" ||
                                        split[6].Substring(0, 2) == "69" ||
                                        split[6].Substring(0, 2) == "73" ||
                                        split[6].Substring(0, 2) == "86" ||
                                        split[6].Substring(0, 2) == "87" ||
                                        split[6].Substring(0, 2) == "89" ||
                                        split[6].Substring(0, 2) == "91" ||
                                        split[6].Substring(0, 2) == "90" ||
                                        split[6].Substring(0, 2) == "95" ||
                                        split[6].Substring(0, 2) == "96" ||
                                        split[6].Substring(0, 2) == "97" ||
                                        split[6].Substring(0, 2) == "98" ||
                                        split[6].Substring(0, 2) == "99" ||
                                        split[6].Substring(0, 2) == "93"
                                        )
                                    {
                                        split[13] = "";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                // Inicio Modificar Acto Quirurgico Para SURA
                                if (chkBoxAQSura.CheckState == CheckState.Checked)
                                {
                                    if (
                                        split[6].Substring(0, 2) == "21" ||
                                        split[6].Substring(0, 2) == "23" ||
                                        split[6].Substring(0, 2) == "57" ||
                                        split[6].Substring(0, 2) == "67" ||
                                        split[6].Substring(0, 2) == "69" ||
                                        split[6].Substring(0, 2) == "73" ||
                                        split[6].Substring(0, 2) == "87" ||
                                        split[6].Substring(0, 2) == "89" ||
                                        split[6].Substring(0, 2) == "90" ||
                                        split[6].Substring(0, 2) == "91" ||
                                        split[6].Substring(0, 2) == "95" ||
                                        split[6].Substring(0, 2) == "96" ||
                                        split[6].Substring(0, 2) == "97" ||
                                        split[6].Substring(0, 2) == "98" ||
                                        split[6].Substring(0, 2) == "99" ||
                                        split[6].Substring(0, 2) == "93"
                                        )
                                    {
                                        split[13] = "";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                // Final Modificar Acto Quirurgico Para SURA

                                #endregion

                                #region Valor Procedimiento

                                // Valor Procedimiento - Posición 14

                                string valorProcedimiento = split[14];

                                double valorProcedimientoDouble;

                                valorProcedimientoDouble = Math.Truncate(Convert.ToDouble(valorProcedimiento));

                                if (chkBoxValSum.CheckState == CheckState.Checked)
                                {
                                    split[14] = valorProcedimientoDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion
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

                // Eliminar Ultimo Salto de Linea CR LF del Archivo

                string myFileData = File.ReadAllText(path);

                if (myFileData.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(path, myFileData.TrimEnd(Environment.NewLine.ToCharArray()));
                }
            }

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwAP.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(50);
            }
        }

        private void BgwAP_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAP.Visible = true;
            prgBarAP.Value = e.ProgressPercentage;
            lblStatusAP.Text = "Procesando...... " + prgBarAP.Value.ToString() + "%";
        }

        private void BgwAP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAP.Text = "Finalizado";
        }

        #endregion

        #region AM
        private void BtnAM_Click(object sender, EventArgs e)
        {
            bgwAM.ODoWorker(BgwAM_DoWork, BgwAM_ProgressChanged, BgwAM_RunWorkerCompleted);
        }

        private void BgwAM_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories).Where(file => file.Extension.Equals(".txt") && file.Name.StartsWith("AM")))
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

                                int EdadUsuario = CArchivos.ObtenerEdad(split[3], dirPath);
                                string UnidadMedidaEdad = CArchivos.ObtenerUnidadMedidaEdad(split[3], dirPath);

                                #region Factura
                                // Número Factura - Posición 0
                                string NumeroFactura = split[0];

                                // Obtenemos la Primera Letra del Número de la Factura
                                string FirsLetter = NumeroFactura.Substring(0, 1);

                                int Longitud = NumeroFactura.Length;

                                if (ChkBoxFac.CheckState == CheckState.Checked)
                                {
                                    if (FirsLetter == "V")
                                    {
                                        split[0] = NumeroFactura.Substring(3, Longitud - 3);
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                if (chkBoxPrefijoFE.CheckState == CheckState.Checked)
                                {
                                    if (!NumeroFactura.Contains("FE"))
                                    {
                                        if (FirsLetter == "V")
                                        {
                                            NumeroFactura = NumeroFactura.Substring(3, Longitud - 3);

                                            NumeroFactura = String.Concat("FE", NumeroFactura);

                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                        else
                                        {
                                            NumeroFactura = String.Concat("FE", NumeroFactura);
                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                    }
                                }
                                #endregion

                                #region TipoDocumento

                                // Tipo de identificación del usuario - Posición 2
                                if (chkBoxTipoDocSSSA.CheckState == CheckState.Checked)
                                {
                                    split[2] = Correcciones.CorregirTipoDocumento(ref line, 2, -1, EdadUsuario, 3, -1, UnidadMedidaEdad);
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Número de Autorización
                                // Número de autorización - Posición 5

                                if (chkBoxAutCapita.CheckState == CheckState.Checked)
                                {
                                    if (split[4] == "")
                                    {
                                        split[4] = "1-1";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Código del medicamento
                                // Código del medicamento - Posición 5

                                // Corregir Codigo Medicamento para SSSA
                                if (chkBoxAMSSSA.CheckState == CheckState.Checked)
                                {
                                    split[5] = Correcciones.CorregirCUMMedicamento(ref line, 5, "SSSA");
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (chkBoxAMSavia.CheckState == CheckState.Checked)
                                {
                                    split[5] = Correcciones.CorregirCUMMedicamento(ref line, 5, "SAVIASALUD");
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Tipo Medicamento
                                // Tipo Medicamento - Posición 6
                                if (split[6] == "")
                                {
                                    split[6] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "2")
                                {
                                    split[6] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Nombre Generico
                                // Nombre genérico del medicamento

                                #endregion

                                #region Forma Farmaceutica
                                // Forma Farmaceutica - Posición 8

                                // Quitar espacios al inicio y al final de la cadena

                                String FormaFarmaceutica = split[8];

                                split[8] = FormaFarmaceutica.Trim();
                                line = String.Join(",", split);
                                contadorErrores++;

                                #endregion

                                #region UnidadMedicamento

                                // Unidad de medida del medicamento - Posición 10

                                string unidadMedidaMedicamento = split[10];

                                unidadMedidaMedicamento = Regex.Replace(unidadMedidaMedicamento, @"[^\w\s]", "").Replace("  ", " ").Replace("Ñ", "N").Replace("Ó", "O").Replace("(", "").Trim();
                                split[10] = unidadMedidaMedicamento.Trim();
                                line = String.Join(",", split);
                                contadorErrores++;

                                #endregion

                                #region Numero de Unidades
                                // Número de unidades - Posición 11

                                string numeroUnidades = split[11];
                                double numeroUnidadesDouble = Math.Truncate(Convert.ToDouble(numeroUnidades));

                                string valorUnitarioMedicamento = split[12];
                                double valorUnitarioMedicamentoDouble = Math.Truncate(Convert.ToDouble(valorUnitarioMedicamento));

                                string valorTotalMedicamento = split[13];
                                double valorTotalMedicamentoDouble = Math.Truncate(Convert.ToDouble(valorTotalMedicamento));

                                numeroUnidadesDouble = valorTotalMedicamentoDouble / valorUnitarioMedicamentoDouble;

                                if (chkBoxAMSavia.CheckState == CheckState.Checked)
                                {
                                    split[11] = numeroUnidadesDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Valor unitario de medicamento

                                // Valor unitario de medicamento - Posición 12

                                // Quitar Decimales para Sumimedical
                                if (chkBoxValSum.CheckState == CheckState.Checked)
                                {
                                    split[12] = valorUnitarioMedicamentoDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Valor Total Medicamento

                                // Valor total de medicamento - Posición 13

                                // Quitar Decimales para Sumimedical
                                if (chkBoxValSum.CheckState == CheckState.Checked)
                                {
                                    split[13] = valorTotalMedicamentoDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion
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

                // Eliminar Ultimo Salto de Linea CR LF del Archivo

                string myFileData = File.ReadAllText(path);

                if (myFileData.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(path, myFileData.TrimEnd(Environment.NewLine.ToCharArray()), Encoding.GetEncoding("Windows-1252"));
                }
            }

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwAM.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(50);
            }
        }

        private void BgwAM_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAM.Visible = true;
            prgBarAM.Value = e.ProgressPercentage;
            lblStatusAM.Text = "Procesando...... " + prgBarAM.Value.ToString() + "%";
        }

        private void BgwAM_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAM.Text = "Finalizado";
        }

        #endregion

        #region AT
        private void BtnAT_Click_1(object sender, EventArgs e)
        {
            bgwAT.ODoWorker(BgwAT_DoWork, BgwAT_ProgressChanged, BgwAT_RunWorkerCompleted);
        }

        private void BgwAT_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories).Where(file => file.Extension.Equals(".txt") && file.Name.StartsWith("AT")))
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

                                int EdadUsuario = CArchivos.ObtenerEdad(split[3], dirPath);
                                string UnidadMedidaEdad = CArchivos.ObtenerUnidadMedidaEdad(split[3], dirPath);

                                #region Factura

                                // Número Factura - Posición 0
                                string NumeroFactura = split[0];

                                // Obtenemos la Primera Letra del Número de la Factura
                                string FirsLetter = NumeroFactura.Substring(0, 1);

                                int Longitud = NumeroFactura.Length;

                                if (chkBoxPrefijoFE.CheckState == CheckState.Checked)
                                {
                                    if (!NumeroFactura.Contains("FE"))
                                    {
                                        if (FirsLetter == "V")
                                        {
                                            NumeroFactura = NumeroFactura.Substring(3, Longitud - 3);

                                            NumeroFactura = String.Concat("FE", NumeroFactura);

                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                        else
                                        {
                                            NumeroFactura = String.Concat("FE", NumeroFactura);
                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                    }
                                }

                                if (NumeroFactura.Length == 9)
                                {
                                    split[0] = NumeroFactura.Substring(3, 6);
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Tipo Documento

                                // Tipo de identificación del usuario - Posición 2

                                if (chkBoxTipoDocSSSA.CheckState == CheckState.Checked)
                                {
                                    split[2] = Correcciones.CorregirTipoDocumento(ref line, 2, -1, EdadUsuario, 3, -1, UnidadMedidaEdad);
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Autorizacion

                                // Autorizacion - Posición 4

                                if (chkBoxAutCapita.CheckState == CheckState.Checked)
                                {
                                    if (split[4] == "")
                                    {
                                        split[4] = "1-1";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                #endregion

                                #region Tipo de Servicio

                                // Tipo de Servicio - Posición 5

                                //1 = Materiales e insumos
                                //2 = Traslados
                                //3 = Estancias
                                //4 = Honorarios

                                if (split[5] == "" && split[6] == "1")
                                {
                                    split[5] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[5] == "" && split[6] == "7")
                                {
                                    split[5] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[5] == "" && split[6] == "8")
                                {
                                    split[5] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[5] == "" && split[6] == "11")
                                {
                                    split[5] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[5] == "" && split[6] == "17")
                                {
                                    split[5] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[5] == "" && split[6] == "18")
                                {
                                    split[5] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[5] == "4" && split[6] == "S11104")
                                {
                                    split[5] = "3";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[5] == "4" && split[6] == "S20000")
                                {
                                    split[5] = "3";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[5] == "4" && split[6] == "5DSB01")
                                {
                                    split[5] = "3";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Codigo Servicio

                                // Código del Servicio - Posición 6

                                // Eliminar Asteriscos y Guiones
                                string cups = split[6].Replace("*", "");
                                if (cups.Length > 6)
                                {
                                    cups = cups.Substring(0, 6);
                                    split[6] = cups;
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[6] == "17")
                                {
                                    split[6] = "976500";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[5] == "4" && split[6] == "" && (split[7] == "SALA DE OBSERVACION MAYOR DE 6 HORAS MENOR DE 24 HORAS" || split[7] == "SALA DE OBSERVACION MENOR DE 6 HORAS"))
                                {
                                    split[6] = "5DSB01";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[5] == "3" && split[6] == "" && split[7] == "HABITACION BIPERSONAL COMPLEJIDAD BAJA")
                                {
                                    split[6] = "10B001";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[5] == "2" && split[6] == "" && split[7] == "HABITACION BIPERSONAL COMPLEJIDAD BAJA")
                                {
                                    split[6] = "10B001";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[5] == "2" && split[6] == "" && split[7] == "TRASLADO BASICO ANDES- HISPANIA -BOLIVAR KMT")
                                {
                                    split[6] = "S31301";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[5] == "4" && split[6] == "" && split[7] == "SALA DE PEQUEÑA CIRUGIA (SUTURAS)")
                                {
                                    split[6] = "S22102";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[5] == "4" && split[6] == "S22102" && split[7] == "SALA DE PEQUENA CIRUGIA SUTURAS")
                                {
                                    split[5] = "3";
                                    split[6] = "5DS003";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                // SALA DE YESOS
                                if (split[5] == "4" && split[6] == "" && split[7] == "SALA DE YESOS")
                                {
                                    split[5] = "3";
                                    split[6] = "5DS004";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                // Se elimina el codigo del servicio
                                // Aplica para el validador de SAVIASALUD

                                // Corregir Codigos AT Para SAVIASALUD
                                if (chkBoxSaviaAT.CheckState == CheckState.Checked)

                                {
                                    // S20000 SALA DE OBSERVACION MENOR DE 6 HORAS
                                    if (split[6] == "S20000")
                                    {
                                        split[6] = "5DSB01";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // S11101 TRASLADO ASISTENCIAL BASICO TERRESTRE PRIMARIO
                                    if (split[6] == "S11101")
                                    {
                                        split[6] = "601T01";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // S11102 HABITACION BIPERSONAL COMPLEJIDAD BAJA
                                    if (split[6] == "S11102")
                                    {
                                        split[6] = "10B001";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // S11104 SALA DE OBSERVACION MAYOR DE 6 HORAS MENOR DE 24 HORAS
                                    if (split[6] == "S11104")
                                    {
                                        split[6] = "5DSB01";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // S31102 TRASLADO BASICO CALDAS - MEDELLIN - BELLO - RIONEGRO KMT,
                                    if (split[6] == "S31102")
                                    {
                                        split[6] = "601T01";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // S21100 SALA DE PARTO DE COMPLEJIDAD BAJA SOD
                                    if (split[6] == "S21100")
                                    {
                                        split[6] = "90DS01";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // S22101 SALA DE PEQUEÑA CIRUGIA
                                    if (split[6] == "S22101" || split[6] == "S22102")
                                    {
                                        split[6] = "5DS003";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // S22103 SALA DE YESOS
                                    if (split[6] == "S22103")
                                    {
                                        split[6] = "5DS004";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // S33000 HORA PROFESIONAL MEDICO TRASLADO PACIENTES
                                    if (split[6] == "S33000")
                                    {
                                        split[6] = "S50003";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                #endregion

                                #region NombreServicio
                                // Nombre del Servicio - Posición 7

                                // Corregir Nombre del Servicio Para SAVIASALUD
                                if (chkBoxSaviaAT.CheckState == CheckState.Checked)
                                {
                                    // S20000 SALA DE OBSERVACION MENOR DE 6 HORAS
                                    if (split[6] == "5DSB01")
                                    {
                                        split[7] = "DERECHOS DE SALA DE OBSERVACION EN URGENCIAS COMPLEJIDAD BAJA";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                // Corregir Caracteres Especiales

                                string nombreServicio = split[7];

                                //nombreServicio = Regex.Replace(nombreServicio, @"[ ](?=[ ])|[^-_,A-Za-z0-9 ]+", "");
                                nombreServicio = Regex.Replace(nombreServicio, @"[^\w\s]", "").Replace("  ", " ").Replace("Ñ", "N").Replace("Ó", "O").Trim();

                                split[7] = nombreServicio;
                                line = String.Join(",", split);
                                contadorErrores++;

                                #endregion

                                #region Valor Unitario
                                // Valor Unitario - Posición 9
                                string valorUnitarioAT = split[9];

                                double valorUnitarioATDouble;

                                valorUnitarioATDouble = Math.Truncate(Convert.ToDouble(valorUnitarioAT));

                                if (chkBoxValSum.CheckState == CheckState.Checked)
                                {
                                    split[9] = valorUnitarioATDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Valor Total
                                // Valor Total - Posición 10
                                string valorTotalAT = split[10];

                                double valorTotalATDouble;

                                valorTotalATDouble = Math.Truncate(Convert.ToDouble(valorTotalAT));

                                if (chkBoxValSum.CheckState == CheckState.Checked)
                                {
                                    split[10] = valorTotalATDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("Windows-1252")))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                // Eliminar Ultimo Salto de Linea CR LF del Archivo

                string myFileData = File.ReadAllText(path);

                if (myFileData.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(path, myFileData.TrimEnd(Environment.NewLine.ToCharArray()));
                }
            }

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwAT.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(100);
            }
        }
        private void BgwAT_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAT.Visible = true;
            prgBarAT.Value = e.ProgressPercentage;
            lblStatusAT.Text = "Procesando...... " + prgBarAT.Value.ToString() + "%";
        }

        private void BgwAT_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAT.Text = "Finalizado";
        }
        #endregion

        #region AU
        private void BtnAU_Click_1(object sender, EventArgs e)
        {
            bgwAU.ODoWorker(BgwAU_DoWork, BgwAU_ProgressChanged, BgwAU_RunWorkerCompleted);
        }

        private void BgwAU_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories).Where(file => file.Extension.Equals(".txt") && file.Name.StartsWith("AU")))
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

                                int EdadUsuario = CArchivos.ObtenerEdad(split[3], dirPath);
                                string UnidadMedidaEdad = CArchivos.ObtenerUnidadMedidaEdad(split[3], dirPath);

                                #region Factura
                                // Número Factura - Posición 0
                                string NumeroFactura = split[0];

                                // Obtenemos la Primera Letra del Número de la Factura
                                string FirsLetter = NumeroFactura.Substring(0, 1);

                                int Longitud = NumeroFactura.Length;

                                if (ChkBoxFac.CheckState == CheckState.Checked)
                                {
                                    if (FirsLetter == "V")
                                    {
                                        split[0] = NumeroFactura.Substring(3, Longitud - 3);
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                if (chkBoxPrefijoFE.CheckState == CheckState.Checked)
                                {
                                    if (!NumeroFactura.Contains("FE"))
                                    {
                                        if (FirsLetter == "V")
                                        {
                                            NumeroFactura = NumeroFactura.Substring(3, Longitud - 3);

                                            NumeroFactura = String.Concat("FE", NumeroFactura);

                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                        else
                                        {
                                            NumeroFactura = String.Concat("FE", NumeroFactura);
                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                    }
                                }
                                #endregion

                                #region Tipo Documento

                                // Tipo de identificación del usuario - Posición 2

                                if (chkBoxTipoDocSSSA.CheckState == CheckState.Checked)
                                {
                                    split[2] = Correcciones.CorregirTipoDocumento(ref line, 2, -1, EdadUsuario, 3, -1, UnidadMedidaEdad);
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Autorizacion

                                // Autorizacion - Posición 6

                                if (chkBoxAutCapita.CheckState == CheckState.Checked)
                                {
                                    if (split[6] == "")
                                    {
                                        split[6] = "1-1";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                #endregion

                                #region Diagnóstico de Salida

                                // Diagnóstico de salida - Posición 8

                                #region Correcciones para SSSA
                                if (chkBoxDXSSSA.CheckState == CheckState.Checked)
                                {
                                    if (split[8] == "A099")
                                    {
                                        split[8] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[8] == "K649")
                                    {
                                        split[8] = "I842";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[8] == "I489")
                                    {
                                        split[8] = "I48X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[8] == "U072")
                                    {
                                        split[8] = "J181";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Correcciones para SAVIASALUD
                                if (chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    if (split[8] == "A09X")
                                    {
                                        split[8] = "A099";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[8] == "K359")
                                    {
                                        split[8] = "K358";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[8] == "N180")
                                    {
                                        split[8] = "N179";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    // Q314 ESTRIDOR LARINGEO CONGENITO
                                    // J042 LARINGOTRAQUEITIS AGUDA

                                    if (split[8] == "Q314")
                                    {
                                        split[8] = "J042";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    if (split[8] == "R500")
                                    {
                                        split[8] = "R509";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    if (split[8] == "O60X")
                                    {
                                        split[8] = "O600"; // PARTO PREMATURO
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #endregion

                                #region Diagnóstico Relacionado Nro. 1, a la salida
                                // Diagnóstico relacionado Nro. 1, a la salida - Posición 9

                                #region Correcciones para SSSA
                                if (chkBoxDXSSSA.CheckState == CheckState.Checked)
                                {
                                    if (split[9] == "A099")
                                    {
                                        split[9] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "K649")
                                    {
                                        split[9] = "I842";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[9] == "I489")
                                    {
                                        split[9] = "I48X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Correcciones para SAVIASALUD
                                if (chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    if (split[9] == "A09X")
                                    {
                                        split[9] = "A099";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #endregion

                                #region Diagnóstico relacionado Nro. 2, a la salida
                                // Diagnóstico relacionado Nro. 2, a la salida - Posición 10

                                #region Correcciones para SSSA
                                if (chkBoxDXSSSA.CheckState == CheckState.Checked)
                                {
                                    if (split[10] == "A099")
                                    {
                                        split[10] = "A09X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "K649")
                                    {
                                        split[10] = "I842";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I489")
                                    {
                                        split[10] = "I48X";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Correcciones para SAVIASALUD
                                if (chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    if (split[10] == "I48X")
                                    {
                                        split[10] = "I489";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "R500")
                                    {
                                        split[10] = "R509";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #endregion
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("Windows-1252")))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                // Eliminar Ultimo Salto de Linea CR LF del Archivo

                string myFileData = File.ReadAllText(path);

                if (myFileData.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(path, myFileData.TrimEnd(Environment.NewLine.ToCharArray()));
                }
            }

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwAU.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(100);
            }
        }

        private void BgwAU_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAU.Visible = true;
            prgBarAU.Value = e.ProgressPercentage;
            lblStatusAU.Text = "Procesando...... " + prgBarAU.Value.ToString() + "%";
        }

        private void BgwAU_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAU.Text = "Finalizado";
        }
        #endregion

        #region AH
        private void BtnAH_Click(object sender, EventArgs e)
        {
            bgwAH.ODoWorker(BgwAH_DoWork, BgwAH_ProgressChanged, BgwAH_RunWorkerCompleted);
        }

        private void BgwAH_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories).Where(file => file.Extension.Equals(".txt") && file.Name.StartsWith("AH")))
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

                                int EdadUsuario = CArchivos.ObtenerEdad(split[3], dirPath);
                                string UnidadMedidaEdad = CArchivos.ObtenerUnidadMedidaEdad(split[3], dirPath);

                                #region Factura
                                // Número Factura - Posición 0
                                string NumeroFactura = split[0];

                                // Obtenemos la Primera Letra del Número de la Factura
                                string FirsLetter = NumeroFactura.Substring(0, 1);

                                int Longitud = NumeroFactura.Length;

                                if (ChkBoxFac.CheckState == CheckState.Checked)
                                {
                                    if (FirsLetter == "V")
                                    {
                                        split[0] = NumeroFactura.Substring(3, Longitud - 3);
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                if (chkBoxPrefijoFE.CheckState == CheckState.Checked)
                                {
                                    if (!NumeroFactura.Contains("FE"))
                                    {
                                        if (FirsLetter == "V")
                                        {
                                            NumeroFactura = NumeroFactura.Substring(3, Longitud - 3);

                                            NumeroFactura = String.Concat("FE", NumeroFactura);

                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                        else
                                        {
                                            NumeroFactura = String.Concat("FE", NumeroFactura);
                                            split[0] = NumeroFactura;
                                            line = String.Join(",", split);
                                            contadorErrores++;
                                        }
                                    }
                                }
                                #endregion

                                #region Tipo Documento

                                // Tipo de identificación del usuario - Posición 2

                                if (chkBoxTipoDocSSSA.CheckState == CheckState.Checked)
                                {
                                    split[2] = Correcciones.CorregirTipoDocumento(ref line, 2, -1, EdadUsuario, 3, -1, UnidadMedidaEdad);
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Número de autorización
                                // Número de autorización - Posición 7

                                // Numero Autorizacion
                                //string numeroAutorizacion = split[7];
                                //split[7] = Regex.Replace(numeroAutorizacion, @"[^0-9]", "");

                                //line = String.Join(",", split);
                                //contadorErrores++;
                                #endregion

                                #region #region Diagnóstico Relacionado 1 de Egreso
                                // Diagnóstico Relacionado 1 de Egreso - Posición 11
                                if (split[11] == "A09X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[11] = "A099";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Diagnóstico Relacionado 2 de Egreso
                                // Diagnóstico Relacionado 2 de Egreso - Posición 12
                                if (split[12] == "I48X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[12] = "I489";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("Windows-1252")))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                // Eliminar Ultimo Salto de Linea CR LF del Archivo

                string myFileData = File.ReadAllText(path);

                if (myFileData.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(path, myFileData.TrimEnd(Environment.NewLine.ToCharArray()));
                }
            }

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwAH.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(100);
            }
        }

        private void BgwAH_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAH.Visible = true;
            prgBarAH.Value = e.ProgressPercentage;
            lblStatusAH.Text = "Procesando...... " + prgBarAH.Value.ToString() + "%";
        }

        private void BgwAH_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAH.Text = "Finalizado";
        }

        #endregion

        #region AF
        private void BtnAF_Click(object sender, EventArgs e)
        {
            bgwAF.ODoWorker(BgwAF_DoWork, BgwAF_ProgressChanged, BgwAF_RunWorkerCompleted);
        }
        private void BgwAF_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*", SearchOption.AllDirectories).Where(file => file.Extension.Equals(".txt") && file.Name.StartsWith("AF")))
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

                                #region Numero Identificacion

                                // Numero Identificacion - Poisición 3

                                string codigoEntidadAF = split[3];

                                if (codigoEntidadAF == "890981494-2")
                                {
                                    split[3] = "890981494";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Numero Factura

                                // Numero Factura - Posicion 4
                                string numeroFactura = split[4];

                                if (!numeroFactura.Contains("FE"))
                                {
                                    numeroFactura = String.Concat("FE", numeroFactura);
                                    split[4] = numeroFactura;
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region CodigoEntidad

                                // Codigo entidad administradora - Posición 8
                                if (chkBoxAFSSSA.CheckState == CheckState.Checked)
                                {
                                    split[8] = "05091";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region NombreEntidad

                                // Nombre entidad administradora - Posición 9

                                string nombreEntidad = split[9];
                                nombreEntidad = Regex.Replace(nombreEntidad, @"[^\w\s]", "").Replace("  ", " ").Replace("-", "").Trim();

                                split[9] = nombreEntidad;
                                line = String.Join(",", split);
                                contadorErrores++;

                                #endregion

                                #region Valor Copago
                                // Valor Copago - Poisición 13

                                string valorCopagoAF = split[13];

                                if (valorCopagoAF == "" && chkBoxCorregirAFSum.CheckState == CheckState.Checked)
                                {
                                    split[13] = "0";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                else if (valorCopagoAF == "")
                                {
                                    split[13] = "0.00";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Valor Comision
                                // Valor Comisión - Posición 14

                                string valorComisionAF = split[14];

                                if (valorComisionAF == "" && chkBoxCorregirAFSum.CheckState == CheckState.Checked)
                                {
                                    split[14] = "0";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                else if (valorComisionAF == "")
                                {
                                    split[14] = "0.00";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Valor Descuento
                                // Valor Descuento - Posición 15
                                string valorDescuentoAF = split[15];

                                if (valorDescuentoAF == "" && chkBoxCorregirAFSum.CheckState == CheckState.Checked)
                                {
                                    split[15] = "0";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                else if (valorDescuentoAF == "")
                                {
                                    split[15] = "0.00";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Valor Neto

                                // Valor Neto - Posición 16

                                string valorNetoAF = split[16];

                                double valorNetoAFDouble;

                                valorNetoAFDouble = Math.Truncate(Convert.ToDouble(valorNetoAF));

                                if (chkBoxCorregirAFSum.CheckState == CheckState.Checked)
                                {
                                    split[16] = valorNetoAFDouble.ToString();
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }


                                #endregion
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("Windows-1252")))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                // Eliminar Ultimo Salto de Linea CR LF del Archivo

                string myFileData = File.ReadAllText(path);

                if (myFileData.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(path, myFileData.TrimEnd(Environment.NewLine.ToCharArray()));
                }
            }

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwAF.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(100);
            }
        }

        private void BgwAF_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAF.Visible = true;
            prgBarAF.Value = e.ProgressPercentage;
            lblStatusAF.Text = "Procesando...... " + prgBarAF.Value.ToString() + "%";
        }

        private void BgwAF_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAF.Text = "Finalizado";
        }
        #endregion

        #region Correción Documentos
        private void BtnDoc_Click(object sender, EventArgs e)
        {
            bgwDOC.ODoWorker(BgwDOC_DoWork, BgwDOC_ProgressChanged, BgwDOC_RunWorkerCompleted);
        }

        private void BgwDOC_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*.txt*", SearchOption.AllDirectories))
            {
                String NombreArchivo = fi.Name;
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
                                if (NombreArchivo.StartsWith("US"))
                                {
                                    String[] split = line.Split(',');

                                    // Tipo de Documento - Posición 0
                                    string TipoDocumento = split[0];
                                    // Número de Documento - Posición 1
                                    string NumeroDocumento = split[1];
                                    // Longitud Número Documento
                                    int LongitudNumeroDocumento = NumeroDocumento.Length;
                                    // Edad - Posición 8
                                    int Edad = Convert.ToInt16(split[8]);
                                    // Unidad de medida de la Edad - Posición 9
                                    // 1 Años
                                    // 2 Meses
                                    // 3 Dias
                                    string UnidadMedidaEdad = split[9];

                                    // Si Es Mayor de 18 Años y Tiene Tipo de Documento TI
                                    // Se Cambia el Tipo de Documento por CC
                                    if (TipoDocumento == "TI" && Edad >= 18 && UnidadMedidaEdad == "1" && LongitudNumeroDocumento == 10)
                                    {
                                        CorregirDocumento(NumeroDocumento, "CC");

                                        split[0] = "CC";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // Para SAVIASALUD
                                    // Si Es Mayor de 18 Años y Tiene Tipo de Documento TI
                                    // Se Cambia el Tipo de Documento por CC Aún si la Longitud del Número de Documento es mayor a 10
                                    if (TipoDocumento == "TI" && Edad >= 18 && UnidadMedidaEdad == "1" && chkBoxLonDoc.CheckState == CheckState.Checked)
                                    {
                                        CorregirDocumento(NumeroDocumento, "CC");

                                        split[0] = "CC";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    // Si es Mayor o igual de 7 Años y Menor o Igual de 17 y Tiene Tipo de Documento RC
                                    // Se cambia el Tipo de Documento por TI
                                    if (TipoDocumento == "RC" && (Edad >= 7 && Edad <= 17) && UnidadMedidaEdad == "1" && LongitudNumeroDocumento == 10)
                                    {
                                        CorregirDocumento(NumeroDocumento, "TI");

                                        split[0] = "TI";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    // Si La Unidad de Medida de la Edad esta en Meses y Tiene Tipo de Documento CC y Edad Menor a 13
                                    // Se cambia Tipo de Documento CC Por RC
                                    if (TipoDocumento == "CC" && Edad < 13 && UnidadMedidaEdad == "2")
                                    {
                                        CorregirDocumento(NumeroDocumento, "RC");

                                        split[0] = "RC";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // Si es Mayor o igual de 7 Años y Menor o Igual de 17 y Tiene Tipo de Documento CC
                                    // Se cambia el Tipo de Documento por TI
                                    if (TipoDocumento == "CC" && (Edad >= 7 && Edad <= 17) && UnidadMedidaEdad == "1" && LongitudNumeroDocumento == 10)
                                    {
                                        CorregirDocumento(NumeroDocumento, "TI");

                                        split[0] = "TI";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    if (TipoDocumento == "CN" && Edad <= 17 && UnidadMedidaEdad == "1")
                                    {
                                        CorregirDocumento(NumeroDocumento, "MS");

                                        split[0] = "MS";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                }
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("Windows-1252")))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwDOC.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(50);
            }
        }

        private void BgwDOC_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusDoc.Visible = true;
            prgBarDoc.Value = e.ProgressPercentage;
            lblStatusDoc.Text = "Procesando...... " + prgBarDoc.Value.ToString() + "%";
        }

        private void BgwDOC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusDoc.Text = "Finalizado";
        }

        public void CorregirDocumento(String NumeroDocumento, String TipoDocumentoCorrecto)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (var fi in di.GetFiles("AC*", SearchOption.AllDirectories).Union(di.GetFiles("*AP*", SearchOption.AllDirectories).Union(di.GetFiles("*AM*", SearchOption.AllDirectories)).Union((di.GetFiles("*AT*", SearchOption.AllDirectories))).Union((di.GetFiles("*AU*", SearchOption.AllDirectories)))))
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

                                // Número Documento: AC, AM, AP, AT, AU - Posición 3
                                string NumeroDocumentoArchivo = split[3];

                                // Si el Número de Documento que viene por parametro 
                                // es igual al Número de Documento del Archivo
                                // Se Actualiza el Tipo de Documento
                                if (NumeroDocumentoArchivo == NumeroDocumento)
                                {
                                    split[2] = TipoDocumentoCorrecto;
                                    line = String.Join(",", split);
                                }
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("Windows-1252")))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}