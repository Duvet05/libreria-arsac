namespace ARSACSoft
{
    partial class frmBursarDireccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBursarDireccion));
            this.label24 = new System.Windows.Forms.Label();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.button1 = new System.Windows.Forms.Button();
            this.botonUbicacion = new System.Windows.Forms.Button();
            this.btnBuscarSede = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(16, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 15);
            this.label24.TabIndex = 47;
            this.label24.Text = "Direccion:";
            // 
            // textDireccion
            // 
            this.textDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDireccion.Location = new System.Drawing.Point(81, 12);
            this.textDireccion.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(145, 21);
            this.textDireccion.TabIndex = 8;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(22, 47);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(231, 191);
            this.gMapControl1.TabIndex = 44;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.OnMapClick += new GMap.NET.WindowsForms.MapClick(this.gMapControl1_OnMapClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 34);
            this.button1.TabIndex = 48;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // botonUbicacion
            // 
            this.botonUbicacion.Location = new System.Drawing.Point(144, 215);
            this.botonUbicacion.Name = "botonUbicacion";
            this.botonUbicacion.Size = new System.Drawing.Size(109, 23);
            this.botonUbicacion.TabIndex = 9;
            this.botonUbicacion.Text = "Seleccionar Punto";
            this.botonUbicacion.UseVisualStyleBackColor = true;
            this.botonUbicacion.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscarSede
            // 
            this.btnBuscarSede.Image = global::ARSACSoft.Properties.Resources.Search;
            this.btnBuscarSede.Location = new System.Drawing.Point(230, 11);
            this.btnBuscarSede.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarSede.Name = "btnBuscarSede";
            this.btnBuscarSede.Size = new System.Drawing.Size(28, 23);
            this.btnBuscarSede.TabIndex = 49;
            this.btnBuscarSede.UseVisualStyleBackColor = true;
            this.btnBuscarSede.Click += new System.EventHandler(this.btnBuscarSede_Click);
            // 
            // frmBursarDireccion
            // 
            this.ClientSize = new System.Drawing.Size(279, 290);
            this.Controls.Add(this.btnBuscarSede);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.botonUbicacion);
            this.Controls.Add(this.textDireccion);
            this.Controls.Add(this.gMapControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBursarDireccion";
            this.Tag = "Buscar Direccion";
            this.Text = "Buscar Direccion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textDireccion;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button botonUbicacion;
        private System.Windows.Forms.Button btnBuscarSede;
    }
}