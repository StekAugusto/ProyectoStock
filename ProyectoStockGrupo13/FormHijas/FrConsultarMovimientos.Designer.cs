namespace ProyectoStockGrupo13
{
    partial class FrConsultarMovimientos
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
            this.lblTituloConsultarMovimientos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTituloConsultarMovimientos
            // 
            this.lblTituloConsultarMovimientos.AutoSize = true;
            this.lblTituloConsultarMovimientos.Location = new System.Drawing.Point(377, 76);
            this.lblTituloConsultarMovimientos.Name = "lblTituloConsultarMovimientos";
            this.lblTituloConsultarMovimientos.Size = new System.Drawing.Size(83, 13);
            this.lblTituloConsultarMovimientos.TabIndex = 2;
            this.lblTituloConsultarMovimientos.Text = "MOVIMIENTOS";
            // 
            // FrConsultarMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTituloConsultarMovimientos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrConsultarMovimientos";
            this.Text = "FrConsultarMovimientos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloConsultarMovimientos;
    }
}