﻿namespace FilesFolders
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pnlRIPSCarpetas = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRutaCarpeta = new System.Windows.Forms.TextBox();
            this.btnRutaCarpeta = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlRIPSCarpetas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRIPSCarpetas
            // 
            this.pnlRIPSCarpetas.Controls.Add(this.label22);
            this.pnlRIPSCarpetas.Controls.Add(this.txtRutaCarpeta);
            this.pnlRIPSCarpetas.Controls.Add(this.btnRutaCarpeta);
            this.pnlRIPSCarpetas.Controls.Add(this.label13);
            this.pnlRIPSCarpetas.Location = new System.Drawing.Point(148, 139);
            this.pnlRIPSCarpetas.Name = "pnlRIPSCarpetas";
            this.pnlRIPSCarpetas.Size = new System.Drawing.Size(576, 243);
            this.pnlRIPSCarpetas.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 33);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(455, 39);
            this.label22.TabIndex = 10;
            this.label22.Text = resources.GetString("label22.Text");
            // 
            // txtRutaCarpeta
            // 
            this.txtRutaCarpeta.Enabled = false;
            this.txtRutaCarpeta.Location = new System.Drawing.Point(92, 99);
            this.txtRutaCarpeta.Name = "txtRutaCarpeta";
            this.txtRutaCarpeta.Size = new System.Drawing.Size(508, 20);
            this.txtRutaCarpeta.TabIndex = 9;
            // 
            // btnRutaCarpeta
            // 
            this.btnRutaCarpeta.Location = new System.Drawing.Point(11, 97);
            this.btnRutaCarpeta.Name = "btnRutaCarpeta";
            this.btnRutaCarpeta.Size = new System.Drawing.Size(75, 23);
            this.btnRutaCarpeta.TabIndex = 8;
            this.btnRutaCarpeta.Text = "Ruta";
            this.btnRutaCarpeta.UseVisualStyleBackColor = true;
            this.btnRutaCarpeta.Click += new System.EventHandler(this.btnRutaCarpeta_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(7, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(236, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Generación de carpetas por RIPS";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlRIPSCarpetas);
            this.Name = "Form2";
            this.Text = "Generación Carpetas";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.pnlRIPSCarpetas.ResumeLayout(false);
            this.pnlRIPSCarpetas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRIPSCarpetas;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtRutaCarpeta;
        private System.Windows.Forms.Button btnRutaCarpeta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}