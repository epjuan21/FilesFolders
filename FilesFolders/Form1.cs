﻿using System;
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

namespace FilesFolders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void CorregirDocumentoAC(String TipoDocumento, String NumeroDocumento, String TipoDocumentoCorrecto)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*AC*", SearchOption.AllDirectories))
            {
                String NombreArchivo = fi.Name;
                String pathUS = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(pathUS))
                {
                    using (StreamReader reader = new StreamReader(pathUS, Encoding.GetEncoding("Windows-1252")))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                if (NombreArchivo.StartsWith("AC"))
                                {
                                    String[] split = line.Split(',');

                                    // Tipo Documento AC - Posición 2
                                    string TipoDocumentoAC = split[2];
                                    // Número Documento AC - Posición 3
                                    string NumeroDocumentoAC = split[3];

                                    // Si el Número de Documento que viene por parametro 
                                    // es igual al Número de Documento del Archivo AC
                                    // Se Actualiza el Tipo de Documento
                                    if (NumeroDocumentoAC == NumeroDocumento)
                                    {
                                        //MessageBox.Show("Tipo Documento AC: " + TipoDocumentoAC);
                                        //MessageBox.Show("Tipo Documento Correcto AC: " + TipoDocumentoCorrecto);
                                        //MessageBox.Show("Documento " + NumeroDocumento);

                                        split[2] = TipoDocumentoCorrecto;
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(pathUS, false, Encoding.GetEncoding("Windows-1252")))
                    {
                        foreach (String line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }


        #region Variables
        string dirPath;
        BackgroundWorker bgwAC;
        BackgroundWorker bgwAP;
        BackgroundWorker bgwUS;
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

            // Oculta Etiqueta de Progreso
            lblStatusUS.Visible = false;
            lblStatusAC.Visible = false;
            lblStatusAP.Visible = false;

            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnAC.Enabled = false;
            btnAP.Enabled = false;
            btnUS.Enabled = false;
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

        #region Ruta
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

                // Obtenemos la Cantidad de Archivos US
                int CantidadUS = Directory.GetFiles(dirPath, "*US*", SearchOption.AllDirectories).Length;
                lblTotalUS.Text = CantidadUS.ToString();

                // Habilitamos los Botones
                btnAC.Enabled = true;
                btnAP.Enabled = true;
                btnUS.Enabled = true;
            }
        }
        #endregion

        #region US
        private void btnUS_Click(object sender, EventArgs e)
        {
            bgwUS = new BackgroundWorker();
            bgwUS.WorkerReportsProgress = true;
            bgwUS.WorkerSupportsCancellation = true;

            bgwUS.DoWork += new DoWorkEventHandler(bgwUS_DoWork);
            bgwUS.ProgressChanged += new ProgressChangedEventHandler(bgwUS_ProgressChanged);
            bgwUS.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwUS_RunWorkerCompleted);

            bgwUS.RunWorkerAsync();
        }

        private void bgwUS_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*US*", SearchOption.AllDirectories))
            {
                String pathUS = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(pathUS))
                {
                    using (StreamReader reader = new StreamReader(pathUS, Encoding.GetEncoding("Windows-1252")))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                // Codigo Departamento y Municipio Archivo US - Posoción 6
                                if (split[11] == "30" && split[12] == "530")
                                {
                                    split[11] = "05";
                                    split[12] = "091";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                else if (split[11] == "91" && split[12] == "591")
                                {
                                    split[11] = "05";
                                    split[12] = "091";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(pathUS, false, Encoding.GetEncoding("Windows-1252")))
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
            bgwAC = new BackgroundWorker();
            bgwAC.WorkerReportsProgress = true;
            bgwAC.WorkerSupportsCancellation = true;

            bgwAC.DoWork += new DoWorkEventHandler(bgwAC_DoWork);
            bgwAC.ProgressChanged += new ProgressChangedEventHandler(bgwAC_ProgressChanged);
            bgwAC.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwAC_RunWorkerCompleted);

            bgwAC.RunWorkerAsync();
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
                                if (split[6] == "890200")
                                {
                                    split[6] = "890201";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                // Finalidad - Posicion 7
                                if (split[6] == "890201" && split[7] == "")
                                {
                                    split[7] = "10";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                // Causa Externa - Posicion 8
                                if (split[6] == "890201" && split[8] == "")
                                {
                                    split[8] = "13";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
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

                                // Codigo CUPS Archivo AP - Posoción 6

                                if (split[6] == "021146")
                                {
                                    split[6] = "873311";
                                    line = String.Join(",", split);
                                    contadorErrores++;
                                }
                                else if (split[6] == "021145")
                                {
                                    split[6] = "871060";
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
                Thread.Sleep(100);
            }
        }

        private void bgwAP_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgBarAP.Value = e.ProgressPercentage;
            lblStatusAP.Text = "Procesando...... " + prgBarAP.Value.ToString() + "%";
        }

        private void bgwAP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusAP.Visible = true;
            lblStatusAP.Text = "Finalizado";
        }
        #endregion

        #region Prueba Correción Documentos
        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;

            foreach (var fi in di.GetFiles("*.txt*", SearchOption.AllDirectories))
            {
                String NombreArchivo = fi.Name;
                String pathUS = fi.FullName;
                List<String> lines = new List<String>();

                if (File.Exists(pathUS))
                {
                    using (StreamReader reader = new StreamReader(pathUS, Encoding.GetEncoding("Windows-1252")))
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
                                        CorregirDocumentoAC(TipoDocumento, NumeroDocumento, "CC");
                                        //MessageBox.Show("Tipo Documento: " + TipoDocumento + " NumeroDocumento: " + NumeroDocumento + " Edad: " + Edad + " Unidad de Medida de la Edad: " + UnidadMedidaEdad);

                                        split[0] = "CC";
                                        line = String.Join(",", split);
                                        contadorErrores++;
                                    }
                                }

                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(pathUS, false, Encoding.GetEncoding("Windows-1252")))
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

    }
}
