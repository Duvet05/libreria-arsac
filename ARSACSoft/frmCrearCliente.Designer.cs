namespace ARSACSoft
{
    partial class frmCrearCliente
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
            this.label24 = new System.Windows.Forms.Label();
            this.botonUbicacion = new System.Windows.Forms.Button();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.txtCorreoCliente = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtDNICliente = new System.Windows.Forms.TextBox();
            this.txtApellidoCliente = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(400, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 15);
            this.label24.TabIndex = 43;
            this.label24.Text = "Direccion:";
            // 
            // botonUbicacion
            // 
            this.botonUbicacion.Location = new System.Drawing.Point(398, 278);
            this.botonUbicacion.Name = "botonUbicacion";
            this.botonUbicacion.Size = new System.Drawing.Size(92, 23);
            this.botonUbicacion.TabIndex = 42;
            this.botonUbicacion.Text = "Seleccionar";
            this.botonUbicacion.UseVisualStyleBackColor = true;
            // 
            // textDireccion
            // 
            this.textDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDireccion.Location = new System.Drawing.Point(495, 279);
            this.textDireccion.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(128, 21);
            this.textDireccion.TabIndex = 41;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(398, 72);
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
            this.gMapControl1.Size = new System.Drawing.Size(225, 194);
            this.gMapControl1.TabIndex = 40;
            this.gMapControl1.Zoom = 0D;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(149, 279);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(173, 21);
            this.txtRazonSocial.TabIndex = 39;
            // 
            // txtRUC
            // 
            this.txtRUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRUC.Location = new System.Drawing.Point(149, 245);
            this.txtRUC.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(173, 21);
            this.txtRUC.TabIndex = 38;
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoCliente.Location = new System.Drawing.Point(149, 211);
            this.txtTelefonoCliente.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.Size = new System.Drawing.Size(173, 21);
            this.txtTelefonoCliente.TabIndex = 37;
            // 
            // txtCorreoCliente
            // 
            this.txtCorreoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoCliente.Location = new System.Drawing.Point(149, 177);
            this.txtCorreoCliente.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtCorreoCliente.Name = "txtCorreoCliente";
            this.txtCorreoCliente.Size = new System.Drawing.Size(173, 21);
            this.txtCorreoCliente.TabIndex = 36;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(149, 75);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(173, 21);
            this.txtNombreCliente.TabIndex = 34;
            // 
            // txtDNICliente
            // 
            this.txtDNICliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNICliente.Location = new System.Drawing.Point(149, 143);
            this.txtDNICliente.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtDNICliente.Name = "txtDNICliente";
            this.txtDNICliente.Size = new System.Drawing.Size(173, 21);
            this.txtDNICliente.TabIndex = 35;
            // 
            // txtApellidoCliente
            // 
            this.txtApellidoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoCliente.Location = new System.Drawing.Point(149, 109);
            this.txtApellidoCliente.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtApellidoCliente.Name = "txtApellidoCliente";
            this.txtApellidoCliente.Size = new System.Drawing.Size(173, 21);
            this.txtApellidoCliente.TabIndex = 33;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(50, 281);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 15);
            this.label19.TabIndex = 32;
            this.label19.Text = "Razon Social:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(78, 215);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 15);
            this.label15.TabIndex = 31;
            this.label15.Text = "Telefono:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(97, 248);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 15);
            this.label17.TabIndex = 28;
            this.label17.Text = "RUC:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(82, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 15);
            this.label12.TabIndex = 27;
            this.label12.Text = "Apellido:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(88, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 15);
            this.label13.TabIndex = 26;
            this.label13.Text = "Nombre:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(89, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "Correo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(105, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 29;
            this.label11.Text = "DNI:";
            // 
            // frmCrearCliente
            // 
            this.ClientSize = new System.Drawing.Size(673, 345);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.botonUbicacion);
            this.Controls.Add(this.textDireccion);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.txtRUC);
            this.Controls.Add(this.txtTelefonoCliente);
            this.Controls.Add(this.txtCorreoCliente);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.txtDNICliente);
            this.Controls.Add(this.txtApellidoCliente);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Name = "frmCrearCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button botonUbicacion;
        private System.Windows.Forms.TextBox textDireccion;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.TextBox txtCorreoCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtDNICliente;
        private System.Windows.Forms.TextBox txtApellidoCliente;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
    }
}