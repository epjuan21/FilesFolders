using FilesFolders.ManejoArchivos;
using System;
using System.IO;
using System.Windows.Forms;

namespace FilesFolders
{
    public partial class FrmRIPSIndividual : Form
    {
        public FrmRIPSIndividual()
        {
            InitializeComponent();
        }

        #region Variables

        string dirPath;
        decimal valorCopagoAF;
        decimal valorComisionAF;
        decimal valorDescuentosAF;
        decimal valorNetoAF;

        decimal valorConsultaAC;
        decimal valorCoutaModeradoraAC;
        decimal valorNetoAC;

        decimal cantidadAT;
        decimal valorUnitarioAT;
        decimal valorTotalAT;

        decimal valorTotalAM;

        decimal valorTotalAP;

        decimal sumatoriDetalles;

        decimal diferencia;

        readonly CArchivos CArchivos = new CArchivos();

        #endregion

        #region Ruta Cargue Individual
        private void BtnRutaIndividual_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaIndividual.Text = folderBrowserDialog1.SelectedPath;

                // Se guarda la ruta de la Carpeta en la variable dirPath
                dirPath = folderBrowserDialog1.SelectedPath;

                #region Cantidad Archivos
                // Obtenemos la Cantidad de Archivos AC
                int CantidadAC = Directory.GetFiles(dirPath, "AC*", SearchOption.AllDirectories).Length;
                lblCantidadAC.Text = CantidadAC.ToString();

                // Obtenemos la Cantidad de Archivos AH
                int CantidadAH = Directory.GetFiles(dirPath, "AH*", SearchOption.AllDirectories).Length;
                lblCantidadAH.Text = CantidadAH.ToString();

                // Obtenemos la Cantidad de Archivos AM
                int CantidadAM = Directory.GetFiles(dirPath, "AM*", SearchOption.AllDirectories).Length;
                lblCantidadAM.Text = CantidadAM.ToString();

                // Obtenemos la Cantidad de Archivos AP
                int CantidadAP = Directory.GetFiles(dirPath, "AP*", SearchOption.AllDirectories).Length;
                lblCantidadAP.Text = CantidadAP.ToString();

                // Obtenemos la Cantidad de Archivos AT
                int CantidadAT = Directory.GetFiles(dirPath, "AT*", SearchOption.AllDirectories).Length;
                lblCantidadAT.Text = CantidadAT.ToString();

                // Obtenemos la Cantidad de Archivos AU
                int CantidadAU = Directory.GetFiles(dirPath, "AU*", SearchOption.AllDirectories).Length;
                lblCantidadAU.Text = CantidadAU.ToString();

                // Obtenemos la Cantidad de Archivos US
                int CantidadUS = Directory.GetFiles(dirPath, "US*", SearchOption.AllDirectories).Length;
                lblCantidadUS.Text = CantidadUS.ToString();
                #endregion

                #region Valores AF

                // Obtenemos el Valor total del pago compartido (copago) - Posición 13
                valorCopagoAF = CArchivos.ObtenerSumatoriaValores(dirPath, 13, "AF*");
                txtCopago.Text = valorCopagoAF.ToString();

                // Obtenemos el Valor de la comisón - Posición 14
                valorComisionAF = CArchivos.ObtenerSumatoriaValores(dirPath, 14, "AF*");
                txtComision.Text = valorComisionAF.ToString();

                // Obtenemos el Valor total de descuentos - Posición 15
                valorDescuentosAF = CArchivos.ObtenerSumatoriaValores(dirPath, 15, "AF*");
                txtDescuentos.Text = valorDescuentosAF.ToString();

                // Obtenemos el Valor neto a pagar por la entidad contratante - Posición 16
                valorNetoAF = CArchivos.ObtenerSumatoriaValores(dirPath, 16, "AF*");
                txtNeto.Text = valorNetoAF.ToString();

                #endregion

                #region Valores AC

                // Obtenemos el Valor de la consulta del Archvio AC - Posición 14
                valorConsultaAC = CArchivos.ObtenerSumatoriaValores(dirPath, 14, "AC*");
                txtValorConsultaAC.Text = valorConsultaAC.ToString();

                // Obtenemos el Valor de la cuota moderadora del Archvio AC - Posición 15
                valorCoutaModeradoraAC = CArchivos.ObtenerSumatoriaValores(dirPath, 15, "AC*");
                txtValorCuotaModeradoraAC.Text = valorCoutaModeradoraAC.ToString();

                // Obtenemos el Valor neto a pagar del Archvio AC - Posición 16
                valorNetoAC = CArchivos.ObtenerSumatoriaValores(dirPath, 16, "AC*");
                txtValorNetoAC.Text = valorNetoAC.ToString();

                #endregion

                #region Valores AT

                // Obtenemos Cantidad del Archvio AT - Posición 8
                cantidadAT = CArchivos.ObtenerSumatoriaValores(dirPath, 8, "AT*");
                txtCantidadAT.Text = cantidadAT.ToString();

                // Obtenemos Valor unitario del material e insumo del Archvio AT - Posición 9
                valorUnitarioAT = CArchivos.ObtenerSumatoriaValores(dirPath, 9, "AT*");
                txtValorUnitarioAT.Text = valorUnitarioAT.ToString();

                // Obtenemos Valor total del material e insumo del Archvio AT - Posición 10
                valorTotalAT = CArchivos.ObtenerSumatoriaValores(dirPath, 10, "AT*");
                txtValorTotalAT.Text = valorTotalAT.ToString();

                #endregion

                #region Valores AM

                // Obtenemos Valor total de medicamento del Archvio AM - Posición 13
                valorTotalAM = CArchivos.ObtenerSumatoriaValores(dirPath, 13, "AM*");
                txtValorTotalAM.Text = valorTotalAM.ToString();

                #endregion

                #region Valores AP

                // Obtenemos Valor del Procedimiento del Archvio AP - Posición 14
                valorTotalAP = CArchivos.ObtenerSumatoriaValores(dirPath, 14, "AP*");
                txtValorTotalAP.Text = valorTotalAP.ToString();

                #endregion

                #region Sumatoria Detalles

                sumatoriDetalles = valorNetoAC + valorTotalAT + valorTotalAM + valorTotalAP;
                txtSumatoriaDetalles.Text = sumatoriDetalles.ToString();

                diferencia = sumatoriDetalles - valorNetoAF;
                txtDiferencia.Text = diferencia.ToString();

                #endregion



            }
        }
        #endregion

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblValorUnitarioAT_Click(object sender, EventArgs e)
        {

        }
    }
}
