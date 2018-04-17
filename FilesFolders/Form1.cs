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

        CWork bgwAC = new CWork();
        CWork bgwAP = new CWork();
        CWork bgwAT = new CWork();
        CWork bgwAU = new CWork();
        CWork bgwDOC = new CWork();
        CWork bgwUS = new CWork();

        CArchivos LineasUS = new CArchivos();
        CArchivos LineasAC = new CArchivos();
        CArchivos Lista = new CArchivos();
        #endregion

        #region FormLoad
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rIPSDataSet.EntidadSet' Puede moverla o quitarla según sea necesario.
            //this.entidadSetTableAdapter.Fill(this.rIPSDataSet.EntidadSet);

            //using (RIPSModelContainer conexion = new RIPSModelContainer())
            //{
            //    this.dataGridView2.DataSource = conexion.EntidadSet.ToList();
            //}
            
            // Cuando carga el Formulario se oculta el Panel1
            pnlRIPS.Visible = false;
            pnlRIPSIndividual.Visible = false;
            pnlRIPSCarpetas.Visible = false;

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

            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnAC.Enabled = false;
            btnAP.Enabled = false;
            btnUS.Enabled = false;
            btnDoc.Enabled = false;
            btnAT.Enabled = false;
            btnAU.Enabled = false;

        }
        #endregion

        #region Menu
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void rIPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlRIPS.Visible = true;
            pnlRIPS.Location = new Point(0,27);
            pnlRIPSIndividual.Visible = false;
            pnlRIPSCarpetas.Visible = false;
        }

        private void rIPSIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlRIPSIndividual.Visible = true;
            pnlRIPSIndividual.Location = new Point(0, 27);
            pnlRIPS.Visible = false;
            pnlRIPSCarpetas.Visible = false;
        }

        private void rIPSCarpetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlRIPSCarpetas.Visible = true;
            pnlRIPSCarpetas.Location = new Point(0, 27);
            pnlRIPSIndividual.Visible = false;
            pnlRIPS.Visible = false;
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
                                // Codigo Departamento y Municipio Archivo US - Posoción 6
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
                                if (split[6] == "890701" && split[7] == "")
                                {
                                    split[7] = "10";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890201" && split[7] == "")
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
                                if (split[6] == "890701" && split[8] == "")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                if (split[6] == "890201" && split[8] == "")
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
                                if (split[6] == "901235")
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
                                if (split[6] == "871010")
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

        private void btnRutaCarpetaEAPB_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuraCarpetaEAPB.Text = folderBrowserDialog1.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = folderBrowserDialog1.SelectedPath;

            }
        }
    }
}

