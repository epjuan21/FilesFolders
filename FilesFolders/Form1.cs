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
        BackgroundWorker bgwAC;
        BackgroundWorker bgwAP;
        #endregion

        #region FormLoad
        private void Form1_Load(object sender, EventArgs e)
        {
            // Cuando carga el Formulario se oculta el Panel1
            panel1.Visible = false;

            // Ocultar Valores Totales de Archivos
            lblTotalAC.Text = string.Empty;
            lblTotalAP.Text = string.Empty;
            lblTotalAM.Text = string.Empty;
            lblTotalAT.Text = string.Empty;
            lblTotalUS.Text = string.Empty;
            lblStatusAP.Text = string.Empty;

            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnAC.Enabled = false;
            btnAP.Enabled = false;

        }
        #endregion

        #region Menu
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void rIPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
        #endregion
        
        // Seleccionamos la Carpeta donde se ecuentran los RIPS
        private void button1_Click(object sender, EventArgs e)
        {
            // Ubicación de la Carpeta con los RIPS
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;

                // Habilitamos los Botones
                btnAC.Enabled = true;
                btnAP.Enabled = true;

            }

            // Se guarda la ruta de la Carpeta en la variable dirPath
            dirPath = folderBrowserDialog1.SelectedPath;

            // Obtenemos la Cantidad de Archivos AC
            int CantidadAC = Directory.GetFiles(dirPath, "*AC*", SearchOption.AllDirectories).Length;

            // Obtenemos la Cantidad de Archivos AP
            int CantidadAP = Directory.GetFiles(dirPath, "*AP*", SearchOption.AllDirectories).Length;

            // Obtenemos la Cantidad de Archivos AM
            int CantidadAM = Directory.GetFiles(dirPath, "*AM*", SearchOption.AllDirectories).Length;

            // Obtenemos la Cantidad de Archivos AT
            int CantidadAT = Directory.GetFiles(dirPath, "*AT*", SearchOption.AllDirectories).Length;

            // Obtenemos la Cantidad de Archivos US
            int CantidadUS = Directory.GetFiles(dirPath, "*US*", SearchOption.AllDirectories).Length;

            lblTotalAC.Text = CantidadAC.ToString();

            lblTotalAP.Text = CantidadAP.ToString();

            lblTotalAM.Text = CantidadAM.ToString();

            lblTotalAT.Text = CantidadAT.ToString();

            lblTotalUS.Text = CantidadUS.ToString();
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            bgwAC = new BackgroundWorker();
            bgwAC.WorkerReportsProgress = true;
            bgwAC.WorkerSupportsCancellation = true;

            bgwAC.DoWork += new DoWorkEventHandler(bgwAC_DoWork);
            bgwAC.ProgressChanged += new ProgressChangedEventHandler(bgwAC_ProgressChanged);
            bgwAC.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwAC_RunWorkerCompleted);

            bgwAC.RunWorkerAsync();
        }

        private void btnAP_Click(object sender, EventArgs e)
        {
            bgwAP = new BackgroundWorker();
            bgwAP.WorkerReportsProgress = true;
            bgwAP.WorkerSupportsCancellation = true;

            bgwAP.DoWork += new DoWorkEventHandler(bgwAP_DoWork);
            bgwAP.ProgressChanged += new ProgressChangedEventHandler(bgwAP_ProgressChanged);
            bgwAP.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwAP_RunWorkerCompleted);

            bgwAP.RunWorkerAsync();
        }

        private void bgwAP_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*AP*", SearchOption.AllDirectories))
            {
                String pathAc = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(pathAc))
                {
                    using (StreamReader reader = new StreamReader(pathAc))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Codigo CUPS Archivo AC - Posoción 6

                                if (split[6] == "890300")
                                {
                                    split[6] = "890301";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                else if (split[6] == "890200")
                                {
                                    split[6] = "890201";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }

                            }

                            lines.Add(line);

                        }
                    }

                    using (StreamWriter writer = new StreamWriter(pathAc, false))
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

        private void bgwAC_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*AC*", SearchOption.AllDirectories))
            {
                String pathAc = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(pathAc))
                {
                    using (StreamReader reader = new StreamReader(pathAc))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Codigo CUPS Archivo AC - Posoción 6
                                if (split[6] == "890300")
                                {
                                    split[6] = "890301";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                else if (split[6] == "890200")
                                {
                                    split[6] = "890201";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(pathAc, false))
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
                bgwAC.ReportProgress(Convert.ToInt32(i*100/ contadorErrores));
                Thread.Sleep(50);
            }

        }

        private void bgwAC_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgBarAC.Value = e.ProgressPercentage;
            lblStatusAC.Text = "Procesando...... " + prgBarAC.Value.ToString() + "%";
        }

        private void bgwAP_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgBarAP.Value = e.ProgressPercentage;
            lblStatusAP.Text = "Procesando...... " + prgBarAP.Value.ToString() + "%";
        }

        private void bgwAC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAC.Text = "Finalizado";
        }

        private void bgwAP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAP.Text = "Finalizado";
        }

    }
}
