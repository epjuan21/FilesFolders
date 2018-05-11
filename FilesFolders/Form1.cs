using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using FilesFolders.Data;
using FilesFolders.ManejoArchivos;
using System.IO.Compression;
using System.Diagnostics;

namespace FilesFolders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Variables
        string dirPath;
        string Edad;
        string UnidadMedidaEdad;
        string FileName;

        CWork bgwAC = new CWork();
        CWork bgwAP = new CWork();
        CWork bgwAT = new CWork();
        CWork bgwAU = new CWork();
        CWork bgwDOC = new CWork();
        CWork bgwUS = new CWork();
        CWork bgwEAPB = new CWork();

        CArchivos LineasUS = new CArchivos();
        CArchivos LineasAC = new CArchivos();
        CArchivos Lista = new CArchivos();
        #endregion

        #region FormLoad
        private void Form1_Load(object sender, EventArgs e)
        {
            
            // Cuando carga el Formulario se ocultan todos los paneles
            pnlRIPS.Visible = false;
            pnlRIPSIndividual.Visible = false;
            pnlRIPSCarpetas.Visible = false;
            pnlComprimirArchivo.Visible = false;
            pnlCambioEsctuctura.Visible = false;

            // Ocultar Valores Totales de Archivos
            lblTotalAC.Text = string.Empty;
            lblTotalAP.Text = string.Empty;
            lblTotalAM.Text = string.Empty;
            lblTotalAT.Text = string.Empty;
            lblTotalUS.Text = string.Empty;
            lblTotalAU.Text = string.Empty;

            // Oculta Etiqueta de Progreso
            lblStatusUS.Visible = false;
            lblStatusAC.Visible = false;
            lblStatusAP.Visible = false;
            lblStatusAT.Visible = false;
            lblStatusAU.Visible = false;
            lblStatusDoc.Visible = false;
            lblEstatusEAPB.Visible = false;

            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnAC.Enabled = false;
            btnAP.Enabled = false;
            btnUS.Enabled = false;
            btnDoc.Enabled = false;
            btnAT.Enabled = false;
            btnAU.Enabled = false;
            btnProcesarEAPB.Enabled = false;
            btnComprimir.Enabled = false;

            // EABP

                // Comprimir Archivo
    
                    // Cargar Valores Predeterminados en TextBox

            txtModuloInformacion.Enabled = false;
            txtModuloInformacion.Text = "RIP";

            txtTipoFuente.Enabled = false;
            txtTipoFuente.Text = "170";

            txtTema.Enabled = false;
            txtTema.Text = "RIPS";

            // Combo Box No Editable
            cmbTipoIdEntidad.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbRegimen.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbTipoIdEntidad.SelectedIndex = 0;

            txtNumeroIdEntidad.Text = "";

            cmbRegimen.SelectedIndex = 2;

            txtConsecutivo.Text = "01";

            cmbExtension.SelectedIndex = 0;

            // Nombre Archvio Comprimido EAPB

            txtFechaCorte.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            cmbTipoIdEntidad.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            txtNumeroIdEntidad.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            cmbRegimen.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            txtConsecutivo.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);
            cmbExtension.TextChanged += new System.EventHandler(this.txtFechaCorte_TextChanged);

            lblNombreArchivo.Text = txtModuloInformacion.Text +  txtTipoFuente.Text + txtTema.Text + txtFechaCorte.Text + cmbTipoIdEntidad.Text + txtNumeroIdEntidad.Text + cmbRegimen.Text + txtConsecutivo.Text + cmbExtension.Text;
          
        }
        #endregion

        #region Menu
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void rIPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlRIPSIndividual.Visible = false;
            pnlCambioEsctuctura.Visible = false;
            pnlRIPSCarpetas.Visible = false;
            pnlComprimirArchivo.Visible = false;

            pnlRIPS.Visible = true;
            pnlRIPS.Location = new Point(0,27);
        }

        private void rIPSIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCambioEsctuctura.Visible = false;
            pnlRIPS.Visible = false;
            pnlRIPSCarpetas.Visible = false;
            pnlComprimirArchivo.Visible = false;

            pnlRIPSIndividual.Visible = true;
            pnlRIPSIndividual.Location = new Point(0, 27);
        }

        private void rIPSCarpetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlRIPS.Visible = false;
            pnlRIPSIndividual.Visible = false;
            pnlCambioEsctuctura.Visible = false;
            pnlComprimirArchivo.Visible = false;

            pnlRIPSCarpetas.Location = new Point(0, 27);
            pnlRIPSCarpetas.Visible = true;

        }



        private void rIPSEAPBToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            pnlRIPSCarpetas.Visible = false;
            pnlRIPSIndividual.Visible = false;
            pnlRIPS.Visible = false;

            pnlComprimirArchivo.Location = new Point(0, 27);
            pnlComprimirArchivo.Visible = true;
        }

        private void cambioEstructuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlRIPS.Visible = false;
            pnlRIPSIndividual.Visible = false;
            pnlRIPSCarpetas.Visible = false;
            pnlComprimirArchivo.Visible = false;

            pnlCambioEsctuctura.Location = new Point(0, 27);
            pnlCambioEsctuctura.Visible = true;

        }

        private void comprimirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlRIPS.Visible = false;
            pnlRIPSIndividual.Visible = false;
            pnlRIPSCarpetas.Visible = false;
            pnlComprimirArchivo.Visible = false;
            pnlCambioEsctuctura.Visible = false;

            pnlComprimirArchivo.Visible = true;
        }

        #endregion

        #region Ruta Cargue Masivo
        // Seleccionamos la Carpeta donde se ecuentran los RIPS
        private void button1_Click(object sender, EventArgs e)
        {
            // Ubicación de la Carpeta con los RIPS
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = folderBrowserDialog1.SelectedPath;

                // Obtenemos la Cantidad de Archivos AC
                int CantidadAC = Directory.GetFiles(dirPath, "*AC*", SearchOption.AllDirectories).Length;
                lblTotalAC.Text = CantidadAC.ToString();

                // Obtenemos la Cantidad de Archivos AP
                int CantidadAP = Directory.GetFiles(dirPath, "*AP*", SearchOption.AllDirectories).Length;
                lblTotalAP.Text = CantidadAP.ToString();

                // Obtenemos la Cantidad de Archivos AM
                int CantidadAM = Directory.GetFiles(dirPath, "*AM*", SearchOption.AllDirectories).Length;
                lblTotalAM.Text = CantidadAM.ToString();

                // Obtenemos la Cantidad de Archivos AT
                int CantidadAT = Directory.GetFiles(dirPath, "*AT*", SearchOption.AllDirectories).Length;
                lblTotalAT.Text = CantidadAT.ToString();

                // Obtenemos la Cantidad de Archivos AU
                int CantidadAU = Directory.GetFiles(dirPath, "*AU*", SearchOption.AllDirectories).Length;
                lblTotalAU.Text = CantidadAU.ToString();

                // Obtenemos la Cantidad de Archivos US
                int CantidadUS = Directory.GetFiles(dirPath, "*US*", SearchOption.AllDirectories).Length;
                lblTotalUS.Text = CantidadUS.ToString();

                // Habilitamos los Botones
                btnUS.Enabled = true;
                btnAC.Enabled = true;
                btnAP.Enabled = true;
                btnDoc.Enabled = true;
                btnAT.Enabled = true;
                btnAU.Enabled = true;

                chkBoxLonDoc.Enabled = true;
            }
        }
        #endregion

        #region Ruta Cargue Individual
        private void btnRutaIndividual_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaIndividual.Text = folderBrowserDialog1.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = folderBrowserDialog1.SelectedPath;

            }
        }
        #endregion

        #region US
        private void btnUS_Click(object sender, EventArgs e)
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
                                split[4] = primerApellido.Trim();

                                // Segundo Apellido - Posición 5
                                string segundoApellido = split[5];
                                split[5] = segundoApellido.Trim();

                                // Primer Nombre - Posición 6
                                string primerNombre = split[6];
                                split[6] = primerNombre.Trim();

                                // Segundo Nombre - Posición 7
                                string segundoNombre = split[7];
                                split[7] = segundoNombre.Trim();
                                
                                line = String.Join(",", split);
                                contadorErrores++;

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
        private void btnAC_Click(object sender, EventArgs e)
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

                                if (NumeroFactura.Length == 9)
                                {
                                    split[0] = NumeroFactura.Substring(3, 6);
                                    line = String.Join(",", split);
                                    contadorErrores++;
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
                                if (split[6] == "890301" && split[7] == "")
                                {
                                    split[7] = "10";
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
                                // Finalidad 07 Detección de alteraciones del adulto
                                if (split[7] == "07" && split[9] == "I10X")
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
                                if (split[6] == "890301" && split[8] == "")
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
                                #endregion

                                #region Diagnóstico Principal
                                // Código del diagnóstico principal - Posicion  9
                                if (split[9] == "")
                                {
                                    split[9] = "R101";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "A09X")
                                {
                                    split[9] = "A099";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[9] == "I849")
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
                                #endregion

                                #region Diagnostico Relacionado 1
                                // Código del diagnóstico relacionado 1 - Posición 10
                                if (split[10] == "A09X")
                                {
                                    split[10] = "A099";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[10] == "I48X")
                                {
                                    split[10] = "I489";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Diagnostico Relacionado 2
                                // Código del diagnóstico relacionado 2 - Posición 11
                                if (split[11] == "I48X")
                                {
                                    split[11] = "I489";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region Diagnostico Relacionado 3
                                // Código del diagnóstico relacionado 3 - Posición 12
                                if (split[12] == "I48X")
                                {
                                    split[12] = "I489";
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

                                #region Valor Cuota Moderadora
                                // Valor de la cuota moderadora - Posición 15
                                string valorCuota = split[15];

                                // Valor consulta - Posición 14
                                string valorConsulta = split[14];

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
        private void btnAP_Click(object sender, EventArgs e)
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

                                #region Numero Factura
                                // Número Factura - Posición 0
                                string NumeroFactura = split[0];

                                if (NumeroFactura.Length == 9)
                                {
                                    split[0] = NumeroFactura.Substring(3, 6);
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                #endregion

                                #region CUPS
                                // Codigo CUPS Archivo AP - Posoción 6
                                if (split[6] == "021145")
                                {
                                    split[6] = "871060";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "021146")
                                {
                                    split[6] = "873311";
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
                                if (split[6] == "872011")
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
                                if (split[6] == "897011")
                                {
                                    split[7] = "2";
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
                                if (split[6] == "911018" && split[7] == "")
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
                                if (split[6] == "870107")
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
                                if (split[6] == "871040")
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
                                if (split[6] == "873112")
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
                                if (split[6] == "902204")
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
                                if (split[6] == "903809")
                                {
                                    split[8] = "1";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "903825")
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
                                if (split[6] == "903895")
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
                                if (split[6] == "982102" && split[8] == "")
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

        #region AT
        private void btnAT_Click(object sender, EventArgs e)
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

                                // Código del Servicio - Posición 6
                                // Se elimina el codigo del servicio
                                // Aplica para el validador de SAVIASALUD
                                if (split[6] != "")
                                {
                                    split[6] = "";
                                    line = String.Join(",", split);
                                    contadorErrores++;
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
        private void btnAU_Click(object sender, EventArgs e)
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

                                // Número Factura - Posición 0
                                string NumeroFactura = split[0];

                                if (NumeroFactura.Length == 9)
                                {
                                    split[0] = NumeroFactura.Substring(3, 6);
                                    line = String.Join(",", split);
                                    contadorErrores++;
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

        #endregion

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

        #region Carpetas
        private void btnRutaCarpeta_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaCarpeta.Text = folderBrowserDialog1.SelectedPath;

                // Ruta Directorio
                dirPath = folderBrowserDialog1.SelectedPath;

                #region Variables
                // Creamos una Variable Tipo Lista para almacenar los nombres de los archivos
                List<string> ListaArchivos = new List<string>();

                // Creamos una lista para almacenar los numeros de Factura Temporales
                List<string> ListaNumerosFactura = new List<string>();

                // Creamos una lista para almacenar los numeros de Factura Unicos
                List<string> ListaNumerosFacturaUnicos = new List<string>();

                // Creamos una variable tipo lista para obtener el numbre completo de cada archvio, que incluye la ruta
                List<string> ListaArchivosFullName = new List<string>();

                // Cremos una variable tipo Lista para almacenar los nombres de los directorios nuevos creados
                //List<string> ListaDirectorios = new List<string>();
                                
                #endregion

                // Almacenamos en la variable Tipo Lista los nombres de los archivos
                ListaArchivos = Lista.ListarArchivosName(dirPath, "*.txt");

                // Almacenamos los nombres completos de los archivos en la variable ListaArchivosFullName
                ListaArchivosFullName = Lista.ListarArchivosFullName(dirPath, "*.txt");

                foreach (var NombreArchivo in ListaArchivos)
                {
                    String IdFactura;

                    // Obtener el Numero de la Factura
                    IdFactura = NombreArchivo.Substring(2, 6);

                    // Agregamos los IdFactura a la Lista de Numeros de Factura
                    ListaNumerosFactura.Add(IdFactura);
                }

                // Leemos los Nombres de las Facturas almacendads en ListaNumerosFacturas
                // Si en ListaNumerosFacturaUnicos estiste el Numero de ListaNumerosFactura, no hace nada
                // Si no existe lo ingresa en ListaNumerosFacturaUnicos
                foreach (var Numeros in ListaNumerosFactura)
                {
                    if (ListaNumerosFacturaUnicos.Contains(Numeros))
                    {
                        //MessageBox.Show("Contiene el numero " + Numeros);
                    }
                    else
                    {
                        //MessageBox.Show("No Contiene el numero " + Numeros);
                        ListaNumerosFacturaUnicos.Add(Numeros);
                    }
                }

                // Leemos los numeros unicos y creamos las carpetas con cada nombre
                foreach (var NumeroUnico in ListaNumerosFacturaUnicos)
                {
                    // Directorio
                    string folderName = dirPath;

                    // SubCarpetas - Nombres de Facturas Unicas
                    string pathString = System.IO.Path.Combine(folderName, NumeroUnico);

                    //Creacion de Carpetas
                    System.IO.Directory.CreateDirectory(pathString);
                }

                // Mover Archivos a sus Respectivos Directorios

                // Almacenamos en un arreglo el listado de los Directorios Nuevos
                string[] ListaDirectorios = Directory.GetDirectories(dirPath);

                foreach (var Directorios in ListaDirectorios)
                {
                    foreach (var Archivo in ListaArchivosFullName)
                    {
                        // NOMBRE CARPETA
                        
                        // Obtenemos la posicion del ultimo BackSlach para identificar donde empieza el nombre del Directorio
                        // Se añade 1 para no obtener el BackSlach
                        int PosicionUltimoSlash = Directorios.LastIndexOf("\\") + 1;
                        // Obtenemos la longitud total de la cadena
                        int LongitudNombre = Directorios.Length;
                        // Obtenemos el Nombre de la Carpeta
                        string nombreDirectorio = Directorios.Substring(PosicionUltimoSlash, LongitudNombre - PosicionUltimoSlash);

                        // NOMBRE ARCHIVO
                        
                        // Obtenemos la posicion del ultimo BackSlach para identificar donde empieza el nombre del Archivo
                        // Se suman dos posiciones para quitar el BackSlach y las Iniciales del Archivo de RIPS
                        int PosicionUltimoSlashArchivo = Archivo.LastIndexOf("\\") + 3;
                        // Obtenemos la longitud total de la cadena
                        // Se restan 4 posiciones por la extension de los archivos
                        int LongitudNombreArchivo = Archivo.Length - 4;
                        // Obtenemos el Nombre del Archivo
                        string nombreArchivo = Archivo.Substring(PosicionUltimoSlashArchivo, LongitudNombreArchivo - PosicionUltimoSlashArchivo);

                        // Obtenemos el Nombre del Archivo incluida la Extension
                        int Slash = Archivo.LastIndexOf("\\") + 1;
                        int Longitud = Archivo.Length;
                        string nombreCompleto = Archivo.Substring(Slash, Longitud - Slash);

                        if (nombreArchivo == nombreDirectorio)
                        {
                            
                            string archivoOrigen = Archivo;
                            string archivoDestino = System.IO.Path.Combine(Directorios, nombreCompleto);

                           System.IO.File.Move(archivoOrigen, archivoDestino);

                        }
                    }
                }
            }
        }

        #endregion

        #region EAPB
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

        private void btnProcesarEAPB_Click(object sender, EventArgs e)
        {
            bgwEAPB.ODoWorker(bgwEAPB_DoWork, bgwEAPB_ProgressChanged, bgwEAPB_RunWorkerCompleted);
        }

        private void bgwEAPB_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);

            // Variable Código de la entidad administradora del plan de beneficios

            string CodigoEAPB = "05091";

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

        #endregion

        #region CREAR ARCHIVO EAPB

        private void btnRutaEAPB_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaEAPB.Text = folderBrowserDialog1.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = folderBrowserDialog1.SelectedPath;

                // Habilitar Boton de Comprimir
                btnComprimir.Enabled = true;
            }
        }

        private void txtFechaCorte_TextChanged(object sender, EventArgs e)
        {
            // Obtenemos la candidad de digitos en el Campo Numero Id Entidad
            int charCount = txtNumeroIdEntidad.Text.Length;

            //Etablecemos la Cantidad Maxima de Digitos Permitidos
            const int charIdEntidad = 12;

            // Variable para establecer los digitos faltantes en el campo
            int charLeft = charIdEntidad - charCount;

            string ceros = "0";

            if (charLeft > 0 && charLeft < 12)
            {

                for (int i = 1; i < charLeft; i++)
                {
                    ceros = ceros + "0";
                }
            }

            FileName = txtModuloInformacion.Text + txtTipoFuente.Text + txtTema.Text + txtFechaCorte.Text + cmbTipoIdEntidad.Text + ceros + txtNumeroIdEntidad.Text + cmbRegimen.Text + txtConsecutivo.Text + cmbExtension.Text;
            lblNombreArchivo.Text = FileName;
        }

        private void ZipDirFile(string dir)
        {
            string parent = Path.GetDirectoryName(dir);
            Process.Start(parent);
            //string name = Path.GetFileName(dir);
            string fileName = Path.Combine(parent, FileName);
            ZipFile.CreateFromDirectory(dir, fileName, CompressionLevel.Fastest, false);
        }

        private void btnComprimir_Click(object sender, EventArgs e)
        {
            ZipDirFile(dirPath);
        }


        #endregion

        private void rIPSCarpetasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}

