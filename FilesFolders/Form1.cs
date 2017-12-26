using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rIPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }

            string dirPath = folderBrowserDialog1.SelectedPath;

            DirectoryInfo di = new DirectoryInfo(dirPath);

            int archivoAC = Directory.GetFiles(dirPath, "*AC*", SearchOption.AllDirectories).Length;

            label2.Text = archivoAC.ToString();

            foreach (var fi in di.GetFiles("*AC*", SearchOption.AllDirectories))
            {

                String pathAc = fi.FullName;

                List<String> lines = new List<String>();

                int contadorErrores = 0;

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

                    MessageBox.Show("Errores Corregidos: " + contadorErrores);

                    

                }
            }

        }
    }
}
