using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class FrmFactura : Form
    {
        public FrmFactura()
        {
            InitializeComponent();
        }

        #region Variables
        string dirPath;
        readonly CWork bgwNumFac = new CWork();
        #endregion

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            // Oculta Etiqueta de Progreso
            lblStatusNumFac.Visible = false;

            // Inhabilitar Botones Hasta Seleccionar Ruta
            btnNumFac.Enabled = false;
        }

        private void BtnRuta_Click(object sender, EventArgs e)
        {
            // Ubicación de la Carpeta con los RIPS
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = folderBrowserDialog1.SelectedPath;

                // Habilitamos el Boton
                btnNumFac.Enabled = true;
            }
        }

        private void BtnNumFac_Click(object sender, EventArgs e)
        {
            if (txtNumFac.Text == "")
            {
                MessageBox.Show("Debe Digitar el Número de la Factura");
                txtNumFac.Focus();
            }
            else
            {
                bgwNumFac.ODoWorker(BgwNumFac_DoWork, BgwNumFac_ProgressChanged, BgwNumFac_RunWorkerCompleted);
            }

        }

        private void BgwNumFac_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(dirPath);
            int contadorErrores = 0;


            #region AF
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

                                split[4] = txtNumFac.Text;

                                line = String.Join(",", split);

                                contadorErrores++;
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
            #endregion

            #region AC AP AM AT AU AD AH
            foreach (var fi in di.GetFiles("AC*", SearchOption.AllDirectories).Union(di.GetFiles("*AP*", SearchOption.AllDirectories).Union(di.GetFiles("*AM*", SearchOption.AllDirectories)).Union((di.GetFiles("*AT*", SearchOption.AllDirectories))).Union((di.GetFiles("*AU*", SearchOption.AllDirectories)))).Union((di.GetFiles("*AD*", SearchOption.AllDirectories))).Union((di.GetFiles("*AH*", SearchOption.AllDirectories))))
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

                                split[0] = txtNumFac.Text;

                                line = String.Join(",", split);

                                contadorErrores++;
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
            #endregion

            for (int i = 1; i <= contadorErrores; i++)
            {
                bgwNumFac.ReportProgress(Convert.ToInt32(i * 100 / contadorErrores));
                Thread.Sleep(100);
            }
        }

        private void BgwNumFac_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatusNumFac.Visible = true;
            prgBarNumFac.Value = e.ProgressPercentage;
            lblStatusNumFac.Text = "Procesando...... " + prgBarNumFac.Value.ToString() + "%";
        }

        private void BgwNumFac_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusNumFac.Text = "Finalizado";
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
