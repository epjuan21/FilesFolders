﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesFolders
{    public partial class FrmRIPS : Form
    {
        public FrmRIPS()
        {
            InitializeComponent();
        }

        #region Variables
        string dirPath;

        CWork bgwAC = new CWork();
        CWork bgwAP = new CWork();
        CWork bgwAT = new CWork();
        CWork bgwAU = new CWork();
        CWork bgwDOC = new CWork();
        CWork bgwUS = new CWork();
        CWork bgwAH = new CWork();
        CWork bgwAF = new CWork();
        CWork bgwAM = new CWork();
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
        }

        #region Ruta Cargue Masivo
        // Seleccionamos la Carpeta donde se ecuentran los RIPS
        private void btnRuta_Click(object sender, EventArgs e)
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

                chkBoxLonDoc.Enabled = true;
            }
        }
        #endregion

        #region US
        private void btnUS_Click_1(object sender, EventArgs e)
        {
            bgwUS.ODoWorker(bgwUS_DoWork, bgwUS_ProgressChanged, bgwUS_RunWorkerCompleted);
        }

        private void bgwUS_DoWork(object sender, DoWorkEventArgs e)
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
                                if(chkBoxCarEsp.CheckState == CheckState.Checked)
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

        private void bgwUS_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusUS.Visible = true;
            prgBarUS.Value = e.ProgressPercentage;
            lblStatusUS.Text = "Procesando...... " + prgBarUS.Value.ToString() + "%";
        }

        private void bgwUS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusUS.Text = "Finalizado";
        }
        #endregion

        #region AC
        private void btnAC_Click_1(object sender, EventArgs e)
        {
            bgwAC.ODoWorker(bgwAC_DoWork, bgwAC_ProgressChanged, bgwAC_RunWorkerCompleted);
        }

        private void bgwAC_DoWork(object sender, DoWorkEventArgs e)
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
                                if (split[7] != "10" && (split[9].Substring(0, 1) != "Z"))
                                {
                                    split[7] = "10";
                                    line = String.Join(",", split);
                                    contadorErrores++;
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
                                
                                if (split[9] == "")
                                {
                                    split[9] = "R101";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                // Correccion para SAVIASALUD
                                if (split[9] == "A09X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "A099";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "D752" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "D572";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "H547" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "H546";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "I842" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "I848" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "I841" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "I845" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "I48X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "I489";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "I849" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "K359" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "K358";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "M725" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "M726";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "N180" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "N179";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "O60X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "O600";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                // Q314 ESTRIDOR LARINGEO CONGENITO
                                // J042 LARINGOTRAQUEITIS AGUDA
                                if (split[9] == "Q314" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "J042";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "R500" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "R509";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Diagnostico Relacionado 1
                                // Código del diagnóstico relacionado 1 - Posición 10
                                if (split[10] == "A09X")
                                {
                                    split[10] = "A099";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[10] == "D752" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "D572";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[10] == "H547" && chkBoxDiagSavia.CheckState == CheckState.Checked)
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
                                if (split[10] == "I841" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[10] == "I842" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[10] == "I845" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[10] == "I848" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[10] == "I849" && chkBoxDiagSavia.CheckState == CheckState.Checked)
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
                                if (split[10] == "O60X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "O600";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                // Q314 ESTRIDOR LARINGEO CONGENITO
                                // J042 LARINGOTRAQUEITIS AGUDA
                                if (split[10] == "Q314" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "J042";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[10] == "R500" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "R509";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
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
                                        split[11
                                            ] = split[11].ToUpper();
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                                if (split[11] == "A09X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[11] = "A099";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[11] == "H547" && chkBoxDiagSavia.CheckState == CheckState.Checked)
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
                                if (split[11] == "N180" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[11] = "N179";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Diagnostico Relacionado 3
                                // Código del diagnóstico relacionado 3 - Posición 12

                                // Evaluar si la primera letra es minuscula

                                // Obtenemos la Primera Letra

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

                                if (split[12] == "I48X")
                                {
                                    split[12] = "I489";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[12] == "I849" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[12] = "K649";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
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

        private void bgwAC_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAC.Visible = true;
            prgBarAC.Value = e.ProgressPercentage;
            lblStatusAC.Text = "Procesando...... " + prgBarAC.Value.ToString() + "%";
        }

        private void bgwAC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAC.Text = "Finalizado";
        }
        #endregion

        #region AP
        private void btnAP_Click_1(object sender, EventArgs e)
        {
            bgwAP.ODoWorker(bgwAP_DoWork, bgwAP_ProgressChanged, bgwAP_RunWorkerCompleted);
        }

        private void bgwAP_DoWork(object sender, DoWorkEventArgs e)
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
                                if (split[6] == "901305")
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
                                if (split[6] == "579500")
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
                                if (split[6] == "935302" && split[8] == "")
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

                                // Quitar Diagnóstico Principal para Sumimedical

                                if (split[10] != "" && chkBoxDxAxSum.CheckState == CheckState.Checked)
                                {
                                    split[10] = "";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                // Si el campo Diagnóstico Principal esta vació y Finalidad es 3 o 4

                                if (chkBoxDxAxSum.CheckState != CheckState.Checked)
                                {
                                    if (split[10] == "" && (split[8] == "3" || split[8] == "4"))
                                    {
                                        split[10] = "Z012";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "A09X")
                                    {
                                        split[10] = "A099";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "D752")
                                    {
                                        split[10] = "D750";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "H547" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                    {
                                        split[10] = "H546";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I48X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                    {
                                        split[10] = "I489";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "I845" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                    {
                                        split[10] = "K649";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "K359" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                    {
                                        split[10] = "K358";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    if (split[10] == "N180" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                    {
                                        split[10] = "N179";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    // Q314 ESTRIDOR LARINGEO CONGENITO
                                    // J042 LARINGOTRAQUEITIS AGUDA

                                    if (split[10] == "Q314" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                    {
                                        split[10] = "J042";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    if (split[10] == "R500" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                    {
                                        split[10] = "R509";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }


                                #endregion

                                #region Diagnostico Relacionado
                                // Diagnóstico Relacionado - Posición 11
                                if (split[11] == "A09X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
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
                                if (split[11] == "N180")
                                {
                                    split[11] = "N179";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[11] == "R500" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[11] = "R509";
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
                                        split[6].Substring(0, 2) == "23" ||
                                        split[6].Substring(0,2) == "57" ||
                                        split[6].Substring(0,2) == "86" ||
                                        split[6].Substring(0,2) == "87" ||
                                        split[6].Substring(0,2) == "89" ||
                                        split[6].Substring(0,2) == "90" ||
                                        split[6].Substring(0,2) == "95" ||
                                        split[6].Substring(0,2) == "96" ||
                                        split[6].Substring(0,2) == "98" ||
                                        split[6].Substring(0,2) == "99" || 
                                        split[6].Substring(0,2) == "93"
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

        private void bgwAP_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAP.Visible = true;
            prgBarAP.Value = e.ProgressPercentage;
            lblStatusAP.Text = "Procesando...... " + prgBarAP.Value.ToString() + "%";
        }

        private void bgwAP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAP.Text = "Finalizado";
        }

        #endregion

        #region AM

        private void btnAM_Click(object sender, EventArgs e)
        {
            bgwAM.ODoWorker(bgwAM_DoWork, bgwAM_ProgressChanged, bgwAM_RunWorkerCompleted);
        }

        private void bgwAM_DoWork(object sender, DoWorkEventArgs e)
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

        private void bgwAM_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAM.Visible = true;
            prgBarAM.Value = e.ProgressPercentage;
            lblStatusAM.Text = "Procesando...... " + prgBarAM.Value.ToString() + "%";
        }

        private void bgwAM_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAM.Text = "Finalizado";
        }

        #endregion

        #region AT
        private void btnAT_Click_1(object sender, EventArgs e)
        {
            bgwAT.ODoWorker(bgwAT_DoWork, bgwAT_ProgressChanged, bgwAT_RunWorkerCompleted);
        }

        private void bgwAT_DoWork(object sender, DoWorkEventArgs e)
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
                                    split[6] = "S20000";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[5] == "3" && split[6] == "" && split[7] == "HABITACION BIPERSONAL COMPLEJIDAD BAJA")
                                {
                                    split[6] = "S11102";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[5] == "2" && split[6] == "" && split[7] == "HABITACION BIPERSONAL COMPLEJIDAD BAJA")
                                {
                                    split[6] = "S11102";
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
                                if (split[6] == "S32302")
                                {
                                    split[6] = "S31301";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "S33000")
                                {
                                    split[6] = "S31301";
                                    line = String.Join(",", split);
                                    contadorErrores++;
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

        private void bgwAT_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAT.Visible = true;
            prgBarAT.Value = e.ProgressPercentage;
            lblStatusAT.Text = "Procesando...... " + prgBarAT.Value.ToString() + "%";
        }

        private void bgwAT_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAT.Text = "Finalizado";
        }
        #endregion

        #region AU
        private void btnAU_Click_1(object sender, EventArgs e)
        {
            bgwAU.ODoWorker(bgwAU_DoWork, bgwAU_ProgressChanged, bgwAU_RunWorkerCompleted);
        }

        private void bgwAU_DoWork(object sender, DoWorkEventArgs e)
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
                                #endregion

                                #region Diagnóstico de Salida
                                // Diagnóstico de salida - Posición 8
                                if (split[8] == "A09X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[8] = "A099";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[8] == "K359" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[8] = "K358";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[8] == "N180" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[8] = "N179";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                // Q314 ESTRIDOR LARINGEO CONGENITO
                                // J042 LARINGOTRAQUEITIS AGUDA

                                if (split[8] == "Q314" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[8] = "J042";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[8] == "R500" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[8] = "R509";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                if (split[8] == "O60X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[8] = "O600"; // PARTO PREMATURO
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                                #endregion

                                #region Diagnóstico Relacionado Nro. 1, a la salida
                                // Diagnóstico relacionado Nro. 1, a la salida - Posición 9
                                if (split[9] == "A09X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[9] = "A099";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Diagnóstico relacionado Nro. 2, a la salida
                                // Diagnóstico relacionado Nro. 2, a la salida - Posición 10
                                if (split[10] == "I48X" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "I489";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[10] == "R500" && chkBoxDiagSavia.CheckState == CheckState.Checked)
                                {
                                    split[10] = "R509";
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
                bgwAU.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(100);
            }
        }

        private void bgwAU_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAU.Visible = true;
            prgBarAU.Value = e.ProgressPercentage;
            lblStatusAU.Text = "Procesando...... " + prgBarAU.Value.ToString() + "%";
        }

        private void bgwAU_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAU.Text = "Finalizado";
        }
        #endregion

        #region AH
        private void btnAH_Click(object sender, EventArgs e)
        {
            bgwAH.ODoWorker(bgwAH_DoWork, bgwAH_ProgressChanged, bgwAH_RunWorkerCompleted);
        }

        private void bgwAH_DoWork(object sender, DoWorkEventArgs e)
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

        private void bgwAH_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAH.Visible = true;
            prgBarAH.Value = e.ProgressPercentage;
            lblStatusAH.Text = "Procesando...... " + prgBarAH.Value.ToString() + "%";
        }

        private void bgwAH_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAH.Text = "Finalizado";
        }

        #endregion

        #region AF
        private void btnAF_Click(object sender, EventArgs e)
        {
            bgwAF.ODoWorker(bgwAF_DoWork, bgwAF_ProgressChanged, bgwAF_RunWorkerCompleted);
        }

        private void bgwAF_DoWork(object sender, DoWorkEventArgs e)
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

                                #region Código Entidad Administradora

                                // Código Entidad Administradora - Poisición 8

                                string codigoEntidadAF = split[3];

                                if (codigoEntidadAF == "890981494-2")
                                {
                                    split[3] = "890981494";
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

        private void bgwAF_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusAF.Visible = true;
            prgBarAF.Value = e.ProgressPercentage;
            lblStatusAF.Text = "Procesando...... " + prgBarAF.Value.ToString() + "%";
        }

        private void bgwAF_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAF.Text = "Finalizado";
        }
        #endregion

        #region Correción Documentos
        private void btnDoc_Click(object sender, EventArgs e)
        {
            bgwDOC.ODoWorker(bgwDOC_DoWork, bgwDOC_ProgressChanged, bgwDOC_RunWorkerCompleted);
        }

        private void bgwDOC_DoWork(object sender, DoWorkEventArgs e)
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
                                        CorregirDocumento(TipoDocumento, NumeroDocumento, "CC");

                                        split[0] = "CC";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // Para SAVIASALUD
                                    // Si Es Mayor de 18 Años y Tiene Tipo de Documento TI
                                    // Se Cambia el Tipo de Documento por CC Aún si la Longitud del Número de Documento es mayor a 10
                                    if (TipoDocumento == "TI" && Edad >= 18 && UnidadMedidaEdad == "1" && chkBoxLonDoc.CheckState == CheckState.Checked)
                                    {
                                        CorregirDocumento(TipoDocumento, NumeroDocumento, "CC");

                                        split[0] = "CC";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    // Si es Mayor o igual de 7 Años y Menor o Igual de 17 y Tiene Tipo de Documento RC
                                    // Se cambia el Tipo de Documento por TI
                                    if (TipoDocumento == "RC" && (Edad >= 7 && Edad <= 17) && UnidadMedidaEdad == "1" && LongitudNumeroDocumento == 10)
                                    {
                                        CorregirDocumento(TipoDocumento, NumeroDocumento, "TI");

                                        split[0] = "TI";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }

                                    // Si La Unidad de Medida de la Edad esta en Meses y Tiene Tipo de Documento CC y Edad Menor a 13
                                    // Se cambia Tipo de Documento CC Por RC
                                    if (TipoDocumento == "CC" && Edad < 13 && UnidadMedidaEdad == "2")
                                    {
                                        CorregirDocumento(TipoDocumento, NumeroDocumento, "RC");

                                        split[0] = "RC";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                    // Si es Mayor o igual de 7 Años y Menor o Igual de 17 y Tiene Tipo de Documento CC
                                    // Se cambia el Tipo de Documento por TI
                                    if (TipoDocumento == "CC" && (Edad >= 7 && Edad <= 17) && UnidadMedidaEdad == "1" && LongitudNumeroDocumento == 10)
                                    {
                                        CorregirDocumento(TipoDocumento, NumeroDocumento, "TI");

                                        split[0] = "TI";
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

        private void bgwDOC_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusDoc.Visible = true;
            prgBarDoc.Value = e.ProgressPercentage;
            lblStatusDoc.Text = "Procesando...... " + prgBarDoc.Value.ToString() + "%"; ;
        }

        private void bgwDOC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusDoc.Text = "Finalizado";
        }

        public void CorregirDocumento(String TipoDocumento, String NumeroDocumento, String TipoDocumentoCorrecto)
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

        private void chkBoxAxSavia_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
