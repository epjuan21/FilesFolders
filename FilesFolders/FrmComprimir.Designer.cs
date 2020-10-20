namespace FilesFolders
{
    partial class FrmComprimir
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlComprimirArchivo = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtRutaEAPB = new System.Windows.Forms.TextBox();
            this.btnRutaEAPB = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbTipoFuente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComprimir = new System.Windows.Forms.Button();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbExtension = new System.Windows.Forms.ComboBox();
            this.cmbRegimen = new System.Windows.Forms.ComboBox();
            this.cmbTipoIdEntidad = new System.Windows.Forms.ComboBox();
            this.txtConsecutivo = new System.Windows.Forms.TextBox();
            this.txtNumeroIdEntidad = new System.Windows.Forms.TextBox();
            this.txtFechaCorte = new System.Windows.Forms.TextBox();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.lblExtension = new System.Windows.Forms.Label();
            this.lblConsecutivo = new System.Windows.Forms.Label();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.lblNumeroIdEntidad = new System.Windows.Forms.Label();
            this.lblTipoIdEntidad = new System.Windows.Forms.Label();
            this.lblFechaCorte = new System.Windows.Forms.Label();
            this.lblTema = new System.Windows.Forms.Label();
            this.lblTipoFuente = new System.Windows.Forms.Label();
            this.lblModuloInformacion = new System.Windows.Forms.Label();
            this.txtModuloInformacion = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlComprimirArchivo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlComprimirArchivo
            // 
            this.pnlComprimirArchivo.Controls.Add(this.btnSalir);
            this.pnlComprimirArchivo.Controls.Add(this.txtRutaEAPB);
            this.pnlComprimirArchivo.Controls.Add(this.btnRutaEAPB);
            this.pnlComprimirArchivo.Controls.Add(this.groupBox3);
            this.pnlComprimirArchivo.Controls.Add(this.label25);
            this.pnlComprimirArchivo.Location = new System.Drawing.Point(12, 12);
            this.pnlComprimirArchivo.Name = "pnlComprimirArchivo";
            this.pnlComprimirArchivo.Size = new System.Drawing.Size(612, 456);
            this.pnlComprimirArchivo.TabIndex = 15;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(526, 430);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtRutaEAPB
            // 
            this.txtRutaEAPB.Enabled = false;
            this.txtRutaEAPB.Location = new System.Drawing.Point(97, 37);
            this.txtRutaEAPB.Name = "txtRutaEAPB";
            this.txtRutaEAPB.Size = new System.Drawing.Size(504, 20);
            this.txtRutaEAPB.TabIndex = 14;
            // 
            // btnRutaEAPB
            // 
            this.btnRutaEAPB.Location = new System.Drawing.Point(16, 35);
            this.btnRutaEAPB.Name = "btnRutaEAPB";
            this.btnRutaEAPB.Size = new System.Drawing.Size(75, 23);
            this.btnRutaEAPB.TabIndex = 13;
            this.btnRutaEAPB.Text = "Ruta";
            this.btnRutaEAPB.UseVisualStyleBackColor = true;
            this.btnRutaEAPB.Click += new System.EventHandler(this.BtnRutaEAPB_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbTipoFuente);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnComprimir);
            this.groupBox3.Controls.Add(this.lblNombreArchivo);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.cmbExtension);
            this.groupBox3.Controls.Add(this.cmbRegimen);
            this.groupBox3.Controls.Add(this.cmbTipoIdEntidad);
            this.groupBox3.Controls.Add(this.txtConsecutivo);
            this.groupBox3.Controls.Add(this.txtNumeroIdEntidad);
            this.groupBox3.Controls.Add(this.txtFechaCorte);
            this.groupBox3.Controls.Add(this.txtTema);
            this.groupBox3.Controls.Add(this.lblExtension);
            this.groupBox3.Controls.Add(this.lblConsecutivo);
            this.groupBox3.Controls.Add(this.lblRegimen);
            this.groupBox3.Controls.Add(this.lblNumeroIdEntidad);
            this.groupBox3.Controls.Add(this.lblTipoIdEntidad);
            this.groupBox3.Controls.Add(this.lblFechaCorte);
            this.groupBox3.Controls.Add(this.lblTema);
            this.groupBox3.Controls.Add(this.lblTipoFuente);
            this.groupBox3.Controls.Add(this.lblModuloInformacion);
            this.groupBox3.Controls.Add(this.txtModuloInformacion);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(12, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(589, 337);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Comprimir Archivo";
            // 
            // cmbTipoFuente
            // 
            this.cmbTipoFuente.FormattingEnabled = true;
            this.cmbTipoFuente.Items.AddRange(new object[] {
            "170",
            "165",
            "165COVI"});
            this.cmbTipoFuente.Location = new System.Drawing.Point(9, 76);
            this.cmbTipoFuente.Name = "cmbTipoFuente";
            this.cmbTipoFuente.Size = new System.Drawing.Size(67, 21);
            this.cmbTipoFuente.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(207, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Formato AAAAMMDD";
            // 
            // btnComprimir
            // 
            this.btnComprimir.Image = global::FilesFolders.Properties.Resources.icons8_Archive_Folder_32;
            this.btnComprimir.Location = new System.Drawing.Point(523, 298);
            this.btnComprimir.Name = "btnComprimir";
            this.btnComprimir.Size = new System.Drawing.Size(50, 30);
            this.btnComprimir.TabIndex = 24;
            this.btnComprimir.UseVisualStyleBackColor = true;
            this.btnComprimir.Click += new System.EventHandler(this.BtnComprimir_Click);
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNombreArchivo.Location = new System.Drawing.Point(117, 307);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(103, 13);
            this.lblNombreArchivo.TabIndex = 23;
            this.lblNombreArchivo.Text = "NOMBREARCHIVO";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(6, 307);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(93, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "Nombre Archivo";
            // 
            // cmbExtension
            // 
            this.cmbExtension.FormattingEnabled = true;
            this.cmbExtension.Items.AddRange(new object[] {
            ".DAT",
            ".zip"});
            this.cmbExtension.Location = new System.Drawing.Point(9, 271);
            this.cmbExtension.Name = "cmbExtension";
            this.cmbExtension.Size = new System.Drawing.Size(102, 21);
            this.cmbExtension.TabIndex = 21;
            // 
            // cmbRegimen
            // 
            this.cmbRegimen.FormattingEnabled = true;
            this.cmbRegimen.Items.AddRange(new object[] {
            "",
            "C",
            "S",
            "O"});
            this.cmbRegimen.Location = new System.Drawing.Point(9, 214);
            this.cmbRegimen.Name = "cmbRegimen";
            this.cmbRegimen.Size = new System.Drawing.Size(102, 21);
            this.cmbRegimen.TabIndex = 20;
            // 
            // cmbTipoIdEntidad
            // 
            this.cmbTipoIdEntidad.FormattingEnabled = true;
            this.cmbTipoIdEntidad.Items.AddRange(new object[] {
            "MU",
            "DE",
            "DI",
            "NI"});
            this.cmbTipoIdEntidad.Location = new System.Drawing.Point(9, 159);
            this.cmbTipoIdEntidad.Name = "cmbTipoIdEntidad";
            this.cmbTipoIdEntidad.Size = new System.Drawing.Size(102, 21);
            this.cmbTipoIdEntidad.TabIndex = 19;
            // 
            // txtConsecutivo
            // 
            this.txtConsecutivo.Location = new System.Drawing.Point(9, 241);
            this.txtConsecutivo.Name = "txtConsecutivo";
            this.txtConsecutivo.Size = new System.Drawing.Size(102, 22);
            this.txtConsecutivo.TabIndex = 17;
            // 
            // txtNumeroIdEntidad
            // 
            this.txtNumeroIdEntidad.Location = new System.Drawing.Point(9, 186);
            this.txtNumeroIdEntidad.Name = "txtNumeroIdEntidad";
            this.txtNumeroIdEntidad.Size = new System.Drawing.Size(102, 22);
            this.txtNumeroIdEntidad.TabIndex = 15;
            // 
            // txtFechaCorte
            // 
            this.txtFechaCorte.Location = new System.Drawing.Point(9, 131);
            this.txtFechaCorte.Name = "txtFechaCorte";
            this.txtFechaCorte.Size = new System.Drawing.Size(102, 22);
            this.txtFechaCorte.TabIndex = 13;
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(9, 103);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(67, 22);
            this.txtTema.TabIndex = 12;
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtension.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblExtension.Location = new System.Drawing.Point(117, 274);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(116, 13);
            this.lblExtension.TabIndex = 10;
            this.lblExtension.Text = "Extensión del archivo";
            // 
            // lblConsecutivo
            // 
            this.lblConsecutivo.AutoSize = true;
            this.lblConsecutivo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsecutivo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblConsecutivo.Location = new System.Drawing.Point(117, 244);
            this.lblConsecutivo.Name = "lblConsecutivo";
            this.lblConsecutivo.Size = new System.Drawing.Size(126, 13);
            this.lblConsecutivo.TabIndex = 9;
            this.lblConsecutivo.Text = "Consecutivo de archivo";
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegimen.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblRegimen.Location = new System.Drawing.Point(117, 217);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(52, 13);
            this.lblRegimen.TabIndex = 8;
            this.lblRegimen.Text = "Régimen";
            // 
            // lblNumeroIdEntidad
            // 
            this.lblNumeroIdEntidad.AutoSize = true;
            this.lblNumeroIdEntidad.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroIdEntidad.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblNumeroIdEntidad.Location = new System.Drawing.Point(117, 192);
            this.lblNumeroIdEntidad.Name = "lblNumeroIdEntidad";
            this.lblNumeroIdEntidad.Size = new System.Drawing.Size(269, 13);
            this.lblNumeroIdEntidad.TabIndex = 7;
            this.lblNumeroIdEntidad.Text = "Número de Identificación de la Entidad Reportante";
            // 
            // lblTipoIdEntidad
            // 
            this.lblTipoIdEntidad.AutoSize = true;
            this.lblTipoIdEntidad.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoIdEntidad.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTipoIdEntidad.Location = new System.Drawing.Point(117, 162);
            this.lblTipoIdEntidad.Name = "lblTipoIdEntidad";
            this.lblTipoIdEntidad.Size = new System.Drawing.Size(190, 13);
            this.lblTipoIdEntidad.TabIndex = 6;
            this.lblTipoIdEntidad.Text = "Tipo de Identificación de la Entidad";
            // 
            // lblFechaCorte
            // 
            this.lblFechaCorte.AutoSize = true;
            this.lblFechaCorte.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCorte.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFechaCorte.Location = new System.Drawing.Point(117, 137);
            this.lblFechaCorte.Name = "lblFechaCorte";
            this.lblFechaCorte.Size = new System.Drawing.Size(84, 13);
            this.lblFechaCorte.TabIndex = 5;
            this.lblFechaCorte.Text = "Fecha de Corte";
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTema.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTema.Location = new System.Drawing.Point(82, 106);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(114, 13);
            this.lblTema.TabIndex = 4;
            this.lblTema.Text = "Tema de Información";
            // 
            // lblTipoFuente
            // 
            this.lblTipoFuente.AutoSize = true;
            this.lblTipoFuente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFuente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTipoFuente.Location = new System.Drawing.Point(82, 79);
            this.lblTipoFuente.Name = "lblTipoFuente";
            this.lblTipoFuente.Size = new System.Drawing.Size(85, 13);
            this.lblTipoFuente.TabIndex = 3;
            this.lblTipoFuente.Text = "Tipo de Fuente";
            // 
            // lblModuloInformacion
            // 
            this.lblModuloInformacion.AutoSize = true;
            this.lblModuloInformacion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuloInformacion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblModuloInformacion.Location = new System.Drawing.Point(82, 50);
            this.lblModuloInformacion.Name = "lblModuloInformacion";
            this.lblModuloInformacion.Size = new System.Drawing.Size(129, 13);
            this.lblModuloInformacion.TabIndex = 2;
            this.lblModuloInformacion.Text = "Módulo de Información";
            // 
            // txtModuloInformacion
            // 
            this.txtModuloInformacion.Location = new System.Drawing.Point(9, 47);
            this.txtModuloInformacion.Name = "txtModuloInformacion";
            this.txtModuloInformacion.Size = new System.Drawing.Size(67, 22);
            this.txtModuloInformacion.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label23.Location = new System.Drawing.Point(6, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(567, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Estructura del Nombre del Archivo según Resolución 1531 de 2014 del Ministerio de" +
    " Salud y Protección Social";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label25.Location = new System.Drawing.Point(12, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(402, 20);
            this.label25.TabIndex = 6;
            this.label25.Text = "Seleccione la ruta donde se encuentran los archivos RIPS";
            // 
            // FrmComprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 480);
            this.Controls.Add(this.pnlComprimirArchivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmComprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprimir Archivo EAPB";
            this.Load += new System.EventHandler(this.FrmComprimir_Load);
            this.pnlComprimirArchivo.ResumeLayout(false);
            this.pnlComprimirArchivo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlComprimirArchivo;
        private System.Windows.Forms.TextBox txtRutaEAPB;
        private System.Windows.Forms.Button btnRutaEAPB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnComprimir;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbExtension;
        private System.Windows.Forms.ComboBox cmbRegimen;
        private System.Windows.Forms.ComboBox cmbTipoIdEntidad;
        private System.Windows.Forms.TextBox txtConsecutivo;
        private System.Windows.Forms.TextBox txtNumeroIdEntidad;
        private System.Windows.Forms.TextBox txtFechaCorte;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.Label lblConsecutivo;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.Label lblNumeroIdEntidad;
        private System.Windows.Forms.Label lblTipoIdEntidad;
        private System.Windows.Forms.Label lblFechaCorte;
        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.Label lblTipoFuente;
        private System.Windows.Forms.Label lblModuloInformacion;
        private System.Windows.Forms.TextBox txtModuloInformacion;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoFuente;
    }
}