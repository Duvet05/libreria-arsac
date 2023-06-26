namespace ARSACSoft
{
    partial class frmBoletaDeVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoletaDeVenta));
            this.axBoletaDeVenta = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.axBoletaDeVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // axBoletaDeVenta
            // 
            this.axBoletaDeVenta.Enabled = true;
            this.axBoletaDeVenta.Location = new System.Drawing.Point(12, 12);
            this.axBoletaDeVenta.Name = "axBoletaDeVenta";
            this.axBoletaDeVenta.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBoletaDeVenta.OcxState")));
            this.axBoletaDeVenta.Size = new System.Drawing.Size(776, 426);
            this.axBoletaDeVenta.TabIndex = 0;
            // 
            // frmBoletaDeVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axBoletaDeVenta);
            this.Name = "frmBoletaDeVenta";
            this.Text = "frmBoletaDeVenta";
            ((System.ComponentModel.ISupportInitialize)(this.axBoletaDeVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axBoletaDeVenta;
    }
}