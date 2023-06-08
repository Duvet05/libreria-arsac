namespace ARSACSoft
{
    partial class frmPrincipal
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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelBarraVentana = new System.Windows.Forms.Panel();
            this.lblTituloARSAC = new System.Windows.Forms.Label();
            this.pbLogoARSAC = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSede = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnReportes = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnRRHH = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnContabilidad = new System.Windows.Forms.Button();
            this.pbCerrarSesion = new System.Windows.Forms.PictureBox();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.pbCompras = new System.Windows.Forms.PictureBox();
            this.btnSede = new System.Windows.Forms.Button();
            this.pbEmpleados = new System.Windows.Forms.PictureBox();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.pbVentas = new System.Windows.Forms.PictureBox();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.pbAlmacen = new System.Windows.Forms.PictureBox();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.lblCargoUsuario = new System.Windows.Forms.Label();
            this.lblDatosUsuario = new System.Windows.Forms.Label();
            this.pbFotoUsuario = new System.Windows.Forms.PictureBox();
            this.lblSedeUsuario = new System.Windows.Forms.Label();
            this.panelBarraVentana.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoARSAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrarSesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(354, 80);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(953, 577);
            this.panelContenedor.TabIndex = 14;
            // 
            // panelBarraVentana
            // 
            this.panelBarraVentana.BackColor = System.Drawing.Color.White;
            this.panelBarraVentana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBarraVentana.Controls.Add(this.lblTituloARSAC);
            this.panelBarraVentana.Controls.Add(this.pbLogoARSAC);
            this.panelBarraVentana.Controls.Add(this.btnCerrar);
            this.panelBarraVentana.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraVentana.Location = new System.Drawing.Point(354, 0);
            this.panelBarraVentana.Name = "panelBarraVentana";
            this.panelBarraVentana.Size = new System.Drawing.Size(953, 80);
            this.panelBarraVentana.TabIndex = 13;
            this.panelBarraVentana.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBarraVentana_MouseDown);
            // 
            // lblTituloARSAC
            // 
            this.lblTituloARSAC.AutoSize = true;
            this.lblTituloARSAC.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloARSAC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(194)))), ((int)(((byte)(199)))));
            this.lblTituloARSAC.Location = new System.Drawing.Point(86, -5);
            this.lblTituloARSAC.Name = "lblTituloARSAC";
            this.lblTituloARSAC.Size = new System.Drawing.Size(542, 85);
            this.lblTituloARSAC.TabIndex = 15;
            this.lblTituloARSAC.Text = "Librería ARSAC";
            this.lblTituloARSAC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTituloARSAC_MouseDown);
            // 
            // pbLogoARSAC
            // 
            this.pbLogoARSAC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pbLogoARSAC.Image = global::ARSACSoft.Properties.Resources.logoARSAC_21;
            this.pbLogoARSAC.Location = new System.Drawing.Point(0, -1);
            this.pbLogoARSAC.Name = "pbLogoARSAC";
            this.pbLogoARSAC.Size = new System.Drawing.Size(80, 80);
            this.pbLogoARSAC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoARSAC.TabIndex = 16;
            this.pbLogoARSAC.TabStop = false;
            this.pbLogoARSAC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbLogoARSAC_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::ARSACSoft.Properties.Resources.eliminar;
            this.btnCerrar.Location = new System.Drawing.Point(910, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BackgroundImage = global::ARSACSoft.Properties.Resources.minimalist_desktop_131;
            this.panel1.Controls.Add(this.lblSedeUsuario);
            this.panel1.Controls.Add(this.lblSede);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnRRHH);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnContabilidad);
            this.panel1.Controls.Add(this.pbCerrarSesion);
            this.panel1.Controls.Add(this.btnCerrarSesion);
            this.panel1.Controls.Add(this.pbCompras);
            this.panel1.Controls.Add(this.btnSede);
            this.panel1.Controls.Add(this.pbEmpleados);
            this.panel1.Controls.Add(this.btnProveedores);
            this.panel1.Controls.Add(this.pbVentas);
            this.panel1.Controls.Add(this.btnPedidos);
            this.panel1.Controls.Add(this.pbAlmacen);
            this.panel1.Controls.Add(this.btnAlmacen);
            this.panel1.Controls.Add(this.lblCargoUsuario);
            this.panel1.Controls.Add(this.lblDatosUsuario);
            this.panel1.Controls.Add(this.pbFotoUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 657);
            this.panel1.TabIndex = 12;
            // 
            // lblSede
            // 
            this.lblSede.AutoSize = true;
            this.lblSede.BackColor = System.Drawing.Color.Transparent;
            this.lblSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSede.ForeColor = System.Drawing.Color.Black;
            this.lblSede.Location = new System.Drawing.Point(140, 103);
            this.lblSede.Name = "lblSede";
            this.lblSede.Size = new System.Drawing.Size(52, 20);
            this.lblSede.TabIndex = 20;
            this.lblSede.Text = "Sede:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = global::ARSACSoft.Properties.Resources.reporte_de_negocios;
            this.pictureBox3.Location = new System.Drawing.Point(48, 512);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.White;
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.Black;
            this.btnReportes.Location = new System.Drawing.Point(16, 507);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(312, 44);
            this.btnReportes.TabIndex = 17;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::ARSACSoft.Properties.Resources.equipo;
            this.pictureBox2.Location = new System.Drawing.Point(48, 462);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // btnRRHH
            // 
            this.btnRRHH.BackColor = System.Drawing.Color.White;
            this.btnRRHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRRHH.ForeColor = System.Drawing.Color.Black;
            this.btnRRHH.Location = new System.Drawing.Point(16, 457);
            this.btnRRHH.Name = "btnRRHH";
            this.btnRRHH.Size = new System.Drawing.Size(312, 44);
            this.btnRRHH.TabIndex = 15;
            this.btnRRHH.Text = "RRHH";
            this.btnRRHH.UseVisualStyleBackColor = false;
            this.btnRRHH.Click += new System.EventHandler(this.btnRRHH_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::ARSACSoft.Properties.Resources.contabilidad;
            this.pictureBox1.Location = new System.Drawing.Point(48, 412);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnContabilidad
            // 
            this.btnContabilidad.BackColor = System.Drawing.Color.White;
            this.btnContabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContabilidad.ForeColor = System.Drawing.Color.Black;
            this.btnContabilidad.Location = new System.Drawing.Point(16, 407);
            this.btnContabilidad.Name = "btnContabilidad";
            this.btnContabilidad.Size = new System.Drawing.Size(312, 44);
            this.btnContabilidad.TabIndex = 13;
            this.btnContabilidad.Text = "Contabilidad";
            this.btnContabilidad.UseVisualStyleBackColor = false;
            this.btnContabilidad.Click += new System.EventHandler(this.btnContabilidad_Click);
            // 
            // pbCerrarSesion
            // 
            this.pbCerrarSesion.BackColor = System.Drawing.Color.White;
            this.pbCerrarSesion.Image = global::ARSACSoft.Properties.Resources.imgSalir2;
            this.pbCerrarSesion.Location = new System.Drawing.Point(126, 592);
            this.pbCerrarSesion.Name = "pbCerrarSesion";
            this.pbCerrarSesion.Size = new System.Drawing.Size(36, 33);
            this.pbCerrarSesion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCerrarSesion.TabIndex = 12;
            this.pbCerrarSesion.TabStop = false;
            this.pbCerrarSesion.Click += new System.EventHandler(this.pbCerrarSesion_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.Location = new System.Drawing.Point(108, 586);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(220, 44);
            this.btnCerrarSesion.TabIndex = 11;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // pbCompras
            // 
            this.pbCompras.BackColor = System.Drawing.Color.White;
            this.pbCompras.Image = global::ARSACSoft.Properties.Resources.sede;
            this.pbCompras.Location = new System.Drawing.Point(48, 362);
            this.pbCompras.Name = "pbCompras";
            this.pbCompras.Size = new System.Drawing.Size(36, 33);
            this.pbCompras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCompras.TabIndex = 10;
            this.pbCompras.TabStop = false;
            // 
            // btnSede
            // 
            this.btnSede.BackColor = System.Drawing.Color.White;
            this.btnSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSede.ForeColor = System.Drawing.Color.Black;
            this.btnSede.Location = new System.Drawing.Point(16, 357);
            this.btnSede.Name = "btnSede";
            this.btnSede.Size = new System.Drawing.Size(312, 44);
            this.btnSede.TabIndex = 9;
            this.btnSede.Text = "Sede";
            this.btnSede.UseVisualStyleBackColor = false;
            this.btnSede.Click += new System.EventHandler(this.btnSede_Click);
            // 
            // pbEmpleados
            // 
            this.pbEmpleados.BackColor = System.Drawing.Color.White;
            this.pbEmpleados.Image = global::ARSACSoft.Properties.Resources.logoEmpleados;
            this.pbEmpleados.Location = new System.Drawing.Point(48, 312);
            this.pbEmpleados.Name = "pbEmpleados";
            this.pbEmpleados.Size = new System.Drawing.Size(36, 33);
            this.pbEmpleados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEmpleados.TabIndex = 8;
            this.pbEmpleados.TabStop = false;
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.White;
            this.btnProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.Black;
            this.btnProveedores.Location = new System.Drawing.Point(16, 307);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(312, 44);
            this.btnProveedores.TabIndex = 7;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // pbVentas
            // 
            this.pbVentas.BackColor = System.Drawing.Color.White;
            this.pbVentas.Image = global::ARSACSoft.Properties.Resources.logoVentas;
            this.pbVentas.Location = new System.Drawing.Point(48, 211);
            this.pbVentas.Name = "pbVentas";
            this.pbVentas.Size = new System.Drawing.Size(36, 33);
            this.pbVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVentas.TabIndex = 6;
            this.pbVentas.TabStop = false;
            // 
            // btnPedidos
            // 
            this.btnPedidos.BackColor = System.Drawing.Color.White;
            this.btnPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedidos.ForeColor = System.Drawing.Color.Black;
            this.btnPedidos.Location = new System.Drawing.Point(16, 207);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(312, 44);
            this.btnPedidos.TabIndex = 5;
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.UseVisualStyleBackColor = false;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // pbAlmacen
            // 
            this.pbAlmacen.BackColor = System.Drawing.Color.White;
            this.pbAlmacen.Image = global::ARSACSoft.Properties.Resources.logoAlmacen;
            this.pbAlmacen.Location = new System.Drawing.Point(48, 261);
            this.pbAlmacen.Name = "pbAlmacen";
            this.pbAlmacen.Size = new System.Drawing.Size(36, 33);
            this.pbAlmacen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAlmacen.TabIndex = 4;
            this.pbAlmacen.TabStop = false;
            this.pbAlmacen.Click += new System.EventHandler(this.pbAlmacen_Click);
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.BackColor = System.Drawing.Color.White;
            this.btnAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlmacen.ForeColor = System.Drawing.Color.Black;
            this.btnAlmacen.Location = new System.Drawing.Point(16, 257);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(312, 44);
            this.btnAlmacen.TabIndex = 3;
            this.btnAlmacen.Text = "Almacén";
            this.btnAlmacen.UseVisualStyleBackColor = false;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // lblCargoUsuario
            // 
            this.lblCargoUsuario.AutoSize = true;
            this.lblCargoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblCargoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblCargoUsuario.Location = new System.Drawing.Point(140, 81);
            this.lblCargoUsuario.Name = "lblCargoUsuario";
            this.lblCargoUsuario.Size = new System.Drawing.Size(144, 20);
            this.lblCargoUsuario.TabIndex = 2;
            this.lblCargoUsuario.Text = "lblCargoUsuario";
            // 
            // lblDatosUsuario
            // 
            this.lblDatosUsuario.AutoSize = true;
            this.lblDatosUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblDatosUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblDatosUsuario.Location = new System.Drawing.Point(140, 58);
            this.lblDatosUsuario.Name = "lblDatosUsuario";
            this.lblDatosUsuario.Size = new System.Drawing.Size(152, 20);
            this.lblDatosUsuario.TabIndex = 1;
            this.lblDatosUsuario.Text = "lblNombresUsuario";
            // 
            // pbFotoUsuario
            // 
            this.pbFotoUsuario.Image = global::ARSACSoft.Properties.Resources.hombre;
            this.pbFotoUsuario.Location = new System.Drawing.Point(34, 36);
            this.pbFotoUsuario.Name = "pbFotoUsuario";
            this.pbFotoUsuario.Size = new System.Drawing.Size(100, 100);
            this.pbFotoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoUsuario.TabIndex = 0;
            this.pbFotoUsuario.TabStop = false;
            // 
            // lblSedeUsuario
            // 
            this.lblSedeUsuario.AutoSize = true;
            this.lblSedeUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblSedeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSedeUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblSedeUsuario.Location = new System.Drawing.Point(201, 103);
            this.lblSedeUsuario.Name = "lblSedeUsuario";
            this.lblSedeUsuario.Size = new System.Drawing.Size(122, 20);
            this.lblSedeUsuario.TabIndex = 21;
            this.lblSedeUsuario.Text = "lblSedeUsuario";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 657);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelBarraVentana);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPrincipal_MouseDown);
            this.panelBarraVentana.ResumeLayout(false);
            this.panelBarraVentana.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoARSAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrarSesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbFotoUsuario;
        private System.Windows.Forms.Label lblCargoUsuario;
        private System.Windows.Forms.Label lblDatosUsuario;
        private System.Windows.Forms.Button btnAlmacen;
        private System.Windows.Forms.PictureBox pbAlmacen;
        private System.Windows.Forms.PictureBox pbCompras;
        private System.Windows.Forms.Button btnSede;
        private System.Windows.Forms.PictureBox pbEmpleados;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.PictureBox pbVentas;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.PictureBox pbCerrarSesion;
        private System.Windows.Forms.Panel panelBarraVentana;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblTituloARSAC;
        private System.Windows.Forms.PictureBox pbLogoARSAC;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnRRHH;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnContabilidad;
        private System.Windows.Forms.Label lblSede;
        private System.Windows.Forms.Label lblSedeUsuario;
    }
}