using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

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
        readonly CWork bgwAC = new CWork();
        readonly CWork bgwAP = new CWork();
        readonly CWork bgwAT = new CWork();
        readonly CWork bgwAU = new CWork();
        readonly CWork bgwDOC = new CWork();
        readonly CWork bgwUS = new CWork();
        readonly CWork bgwAH = new CWork();
        readonly CWork bgwAF = new CWork();
        readonly CWork bgwAM = new CWork();
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

                                #region Apellidos y Nombres

                                // Primer Apellido - Posición 4
                                string primerApellido = split[4];

                                // Reemplazar Caracteres Especiales

                                primerApellido = primerApellido.Replace("ñ", "N");

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
                                    split[4] = primerApellido = primerApellido.Replace("Ñ", "N");
                                    line = String.Join(",", split);
                                    contadorErrores++;

                                    // Segundo Apellido
                                    split[5] = segundoApellido = segundoApellido.Replace("Ñ", "N");
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Departamento y Municipio
                                // Codigo Departamento y Municipio Archivo US - Posoción 11 y Posición 12
                                if (split[11] == "30" && split[12] == "530")
                                {
                                    split[11] = "05";
                                    split[12] = "091";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[11] == "91" && split[12] == "591")
                                {
                                    split[11] = "05";
                                    split[12] = "091";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[11] == "11" && split[12] == "005")
                                {
                                    split[11] = "11";
                                    split[12] = "001";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[11] == "05" && split[12] == "91")
                                {
                                    split[11] = "05";
                                    split[12] = "091";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[11] == "05" && split[12] == "999")
                                {
                                    split[11] = "05";
                                    split[12] = "091";
                                    line = String.Join(",", split);
                                    contadorErrores++;
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

                                #region Número de autorización
                                // Número de autorización - Posición 5

                                // Numero Autorizacion
                                string numeroAutorizacion = split[5];
                                split[5] = Regex.Replace(numeroAutorizacion, @"[^0-9]", "");

                                line = String.Join(",", split);
                                contadorErrores++;
                                #endregion

                                #region CUPS
                                // Codigo CUPS Archivo AC - Posición 6
                                if (split[6] == "890300")
                                {
                                    split[6] = "890301";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890200")
                                {
                                    split[6] = "890201";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890600")
                                {
                                    split[6] = "890601";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Finalidad
                                // Finalidad - Posicion 7
                                if (split[6] == "890201" && split[7] == "")
                                {
                                    split[7] = "10";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890203" && split[7] == "")
                                {
                                    split[7] = "10";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890301" && split[7] == "")
                                {
                                    split[7] = "10";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890305" && split[7] == "")
                                {
                                    split[7] = "04";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890305" && split[7] == "" && split[9] == "Z300")
                                {
                                    split[7] = "03";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890601" && split[7] == "")
                                {
                                    split[7] = "10";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890701" && split[7] == "")
                                {
                                    split[7] = "10";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890703" && split[7] == "")
                                {
                                    split[7] = "10";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                // Finalidad 07 Detección de alteraciones del adulto
                                if (split[7] != "" && split[9] != "")
                                {
                                    if (split[7] != "10" && (split[9].Substring(0, 1) != "Z"))
                                    {
                                        split[7] = "10";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

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

                                if (split[9] == "")
                                {
                                    split[9] = "R101";
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
                                    if (split[9] == "K649")
                                    {
                                        split[9] = "I842";
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

                                #region Número de autorización
                                // Número de autorización - Posición 5

                                // Numero Autorizacion
                                string numeroAutorizacion = split[5];
                                split[5] = Regex.Replace(numeroAutorizacion, @"[^0-9]", "");

                                line = String.Join(",", split);
                                contadorErrores++;
                                #endregion

                                #region CUPS
                                // Codigo CUPS Archivo AP - Posoción 6
                                if (split[6] == "4")
                                {
                                    split[6] = "869500";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "021145")
                                {
                                    split[6] = "871060";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "021146")
                                {
                                    split[6] = "873123";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "232100")
                                {
                                    split[6] = "232104";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "542801")
                                {
                                    split[6] = "542700";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "579400")
                                {
                                    split[6] = "579401";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "579500")
                                {
                                    split[6] = "579501";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "697100")
                                {
                                    split[6] = "697101";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "673411")
                                {
                                    split[6] = "863101";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873123")
                                {
                                    split[6] = "873122";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873211")
                                {
                                    split[6] = "873210";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "902201")
                                {
                                    split[6] = "911009";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "902212")
                                {
                                    split[6] = "902210";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "903825")
                                {
                                    split[6] = "903895";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906916")
                                {
                                    split[6] = "906915";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "*908856")
                                {
                                    split[6] = "908856";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "965200")
                                {
                                    split[6] = "965201";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "995199")
                                {
                                    split[6] = "993513";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "995200")
                                {
                                    split[6] = "993122";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "997300")
                                {
                                    split[6] = "997301";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Ambito
                                // Ambito del Procedimiento
                                // 1 - Ambulatorio
                                // 2 - Hospitalario
                                // 3 - En Urgencias

                                if (split[6] == "232101")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "869500")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "865101")
                                {
                                    split[7] = "3";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "862701")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "872011")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873111")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873112")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873422")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "892901")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "897011")
                                {
                                    split[7] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "897012")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901107")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901235")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901237")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901305")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "902221")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906039")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906127")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "907004")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "908856")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "936800")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "950601")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "911018" && split[7] == "")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "993102" && split[7] == "")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "963300" && split[7] == "")
                                {
                                    split[7] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Finalidad
                                // Finalidad - Posición 8
                                // 1 - Diagnóstico
                                // 2 - Terapéutico

                                if (split[6] == "210200")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "232101")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "389900")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "542700")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "542801")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "579401")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "579500")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "579501")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "697101")
                                {
                                    split[8] = "3";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "861101")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "861201")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "865101")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "865102")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "862701")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "869500" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "870001")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "870101")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "870105")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "870107")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "870113")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "870120")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "870131")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "870602")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "871010")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "871020")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "871030")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "871040")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "871060")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "871111")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "871121")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "871129")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "872002" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "872011" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873111")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873112")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873121")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873122")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873204")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873205")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873206")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873210")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873311")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873312" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873313" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873333" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873411" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873412" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873420" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873422" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "873431")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "892901")
                                {
                                    split[8] = "4";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "895100")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "897011")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "897012")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906039")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906625")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "908856")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "911009" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901104" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901107" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901235" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901237" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901304" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "901305" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "902043" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "902204")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "902206")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "902208")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "902210")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "902221")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "903801")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "903809")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "903841")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "903856")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "903866")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "903867")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "903895")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "904508")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "904509")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906127")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906249")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906317")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906914")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906915")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "906916")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "907002")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "907004")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "907106")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "911018" && split[8] == "")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "935301" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "935302" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "935303" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "935304" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "935400")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "939402")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "936800")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "939402")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "950601")
                                {
                                    split[8] = "4";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "963300" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "965100" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "965200" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "965201" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "981100" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "982102" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "993102" && split[8] == "")
                                {
                                    split[8] = "2";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
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

                                #region Correcciones para SSSA
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
                                    if (split[10] == "U072")
                                    {
                                        split[10] = "J181";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                #endregion

                                #region Correcciones para SUMIMEDICAL
                                if (chkBoxDxAxSum.CheckState == CheckState.Checked)
                                {
                                    // Quitar Diagnóstico Principal para Sumimedical
                                    if (split[10] != "")
                                    {
                                        split[10] = "";
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
                                #endregion

                                // Si el campo Diagnóstico Principal esta vació y Finalidad es 3 o 4

                                if (chkBoxDxAxSum.CheckState != CheckState.Checked)
                                {
                                    if (split[10] == "" && (split[8] == "3" || split[8] == "4"))
                                    {
                                        split[10] = "Z012";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "D752")
                                    {
                                        split[10] = "D750";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                                #endregion

                                #region Diagnostico Relacionado
                                // Diagnóstico Relacionado - Posición 11

                                #region Corregir Diagnostico para SAVIASALUD
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
                                #endregion

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
                                        split[6].Substring(0, 2) == "57" ||
                                        split[6].Substring(0, 2) == "67" ||
                                        split[6].Substring(0, 2) == "69" ||
                                        split[6].Substring(0, 2) == "73" ||
                                        split[6].Substring(0, 2) == "86" ||
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

                                }

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

                                #region Código del medicamento
                                // Código del medicamento - Posición 5

                                if (split[5] == "20055559-6")
                                {
                                    split[5] = "20041458-1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Tipo Medicamento
                                // Tipo Medicamento - Posición 6
                                if (split[6] == "2")
                                {
                                    split[6] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Forma Farmaceutica
                                // Forma Farmaceutica - Posición 8

                                // Quitar espacios al inicio y al final de la cadena

                                String FormaFarmaceutica = split[8];

                                split[8] = FormaFarmaceutica.Trim();
                                line = String.Join(",", split);
                                contadorErrores++;

                                #endregion

                                // Número de unidades - Posición 11
                                string numeroUnidades = split[11];
                                double numeroUnidadesDouble = Math.Truncate(Convert.ToDouble(numeroUnidades));

                                // Valor unitario de medicamento - Posición 12

                                string valorUnitarioMedicamento = split[12];
                                double valorUnitarioMedicamentoDouble = Math.Truncate(Convert.ToDouble(valorUnitarioMedicamento));

                                // Valor total de medicamento - Posición 13

                                string valorTotalMedicamento = split[13];
                                double valorTotalMedicamentoDouble = Math.Truncate(Convert.ToDouble(valorTotalMedicamento));

                                #region Numero de Unidades
                                // Número de unidades - Posición 11

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

            foreach (var fi in di.GetFiles("*AT*", SearchOption.AllDirectories))
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

                                #region Tipo de Servicio

                                // Tipo de Servicio - Posición 5

                                //1 = Materiales e insumos
                                //2 = Traslados
                                //3 = Estancias
                                //4 = Honorarios

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
                                #endregion

                                #region Codigo Servicio
                                // Código del Servicio - Posición 6

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
                                        split[6] = "602T01";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

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

            foreach (var fi in di.GetFiles("*AU*", SearchOption.AllDirectories))
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

            foreach (var fi in di.GetFiles("*AH*", SearchOption.AllDirectories))
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

                                #region Número de autorización
                                // Número de autorización - Posición 7

                                // Numero Autorizacion
                                string numeroAutorizacion = split[7];
                                split[7] = Regex.Replace(numeroAutorizacion, @"[^0-9]", "");

                                line = String.Join(",", split);
                                contadorErrores++;
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

            foreach (var fi in di.GetFiles("*AF*", SearchOption.AllDirectories))
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

        #region AD

        // Eliminar Archvio AD
        private void BtnEliminarAd_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (var fi in di.GetFiles("*CT*", SearchOption.AllDirectories))
            {
                String path = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(path))
                {
                    var lineaConAD = System.IO.File.ReadAllLines(path);
                    var lineaSinAD = lineaConAD.Where(line => !line.Contains("AD"));
                    System.IO.File.WriteAllLines(path, lineaSinAD);
                }

                // Eliminar Ultimo Salto de Linea CR LF del Archivo

                string myFileData = File.ReadAllText(path);

                if (myFileData.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(path, myFileData.TrimEnd(Environment.NewLine.ToCharArray()));
                }
            }

            foreach (var fi in di.GetFiles("AD*", SearchOption.AllDirectories))
            {
                fi.Delete();
            }

            MessageBox.Show("Se ha eliminado el archivo AD Correctamente");
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
            lblStatusDoc.Text = "Procesando...... " + prgBarDoc.Value.ToString() + "%"; ;
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