namespace ARSACSoft
{
    partial class frmGestionPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionPedidos));
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.AgregarCliente = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.checkBoxFactura = new System.Windows.Forms.CheckBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.lblDNICliente = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxDescuento = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textCantProducto = new System.Windows.Forms.TextBox();
            this.BtnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.textNombreProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarProd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textDescuentoPorcentaje = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btCorreo = new System.Windows.Forms.Button();
            this.textMonto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btPedido = new System.Windows.Forms.Button();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnBuscarPedido = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscarDireccion = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.gbProveedor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProveedor
            // 
            this.gbProveedor.BackColor = System.Drawing.Color.White;
            this.gbProveedor.Controls.Add(this.AgregarCliente);
            this.gbProveedor.Controls.Add(this.btnCliente);
            this.gbProveedor.Controls.Add(this.label3);
            this.gbProveedor.Controls.Add(this.txtNombreCompleto);
            this.gbProveedor.Controls.Add(this.checkBoxFactura);
            this.gbProveedor.Controls.Add(this.lblNombreCliente);
            this.gbProveedor.Controls.Add(this.txtRazonSocial);
            this.gbProveedor.Controls.Add(this.txtRUC);
            this.gbProveedor.Controls.Add(this.lblDNICliente);
            this.gbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbProveedor.Location = new System.Drawing.Point(21, 35);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(671, 70);
            this.gbProveedor.TabIndex = 103;
            this.gbProveedor.TabStop = false;
            this.gbProveedor.Text = "Venta con Factura";
            // 
            // AgregarCliente
            // 
            this.AgregarCliente.Image = global::ARSACSoft.Properties.Resources.person;
            this.AgregarCliente.Location = new System.Drawing.Point(149, 37);
            this.AgregarCliente.Name = "AgregarCliente";
            this.AgregarCliente.Size = new System.Drawing.Size(29, 22);
            this.AgregarCliente.TabIndex = 99;
            this.AgregarCliente.Text = "...";
            this.AgregarCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AgregarCliente.UseVisualStyleBackColor = true;
            this.AgregarCliente.Click += new System.EventHandler(this.AgregarCliente_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(118, 37);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(29, 22);
            this.btnCliente.TabIndex = 98;
            this.btnCliente.Text = "...";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(367, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 97;
            this.label3.Text = "Nombre:";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Enabled = false;
            this.txtNombreCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCompleto.Location = new System.Drawing.Point(370, 38);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.ReadOnly = true;
            this.txtNombreCompleto.Size = new System.Drawing.Size(293, 20);
            this.txtNombreCompleto.TabIndex = 96;
            // 
            // checkBoxFactura
            // 
            this.checkBoxFactura.AutoSize = true;
            this.checkBoxFactura.Location = new System.Drawing.Point(110, 3);
            this.checkBoxFactura.Name = "checkBoxFactura";
            this.checkBoxFactura.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFactura.TabIndex = 95;
            this.checkBoxFactura.UseVisualStyleBackColor = true;
            this.checkBoxFactura.CheckedChanged += new System.EventHandler(this.checkBoxFactura_CheckedChanged);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(189, 21);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(83, 15);
            this.lblNombreCliente.TabIndex = 3;
            this.lblNombreCliente.Text = "Razon Social:";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(192, 38);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(163, 20);
            this.txtRazonSocial.TabIndex = 2;
            // 
            // txtRUC
            // 
            this.txtRUC.Enabled = false;
            this.txtRUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRUC.Location = new System.Drawing.Point(12, 38);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.ReadOnly = true;
            this.txtRUC.Size = new System.Drawing.Size(103, 20);
            this.txtRUC.TabIndex = 1;
            // 
            // lblDNICliente
            // 
            this.lblDNICliente.AutoSize = true;
            this.lblDNICliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNICliente.Location = new System.Drawing.Point(10, 21);
            this.lblDNICliente.Name = "lblDNICliente";
            this.lblDNICliente.Size = new System.Drawing.Size(36, 15);
            this.lblDNICliente.TabIndex = 0;
            this.lblDNICliente.Text = "RUC:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.checkBoxDescuento);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textCantProducto);
            this.groupBox1.Controls.Add(this.BtnQuitar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.textNombreProducto);
            this.groupBox1.Controls.Add(this.btnBuscarProd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textDescuentoPorcentaje);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(21, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 272);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Productos";
            // 
            // checkBoxDescuento
            // 
            this.checkBoxDescuento.AutoSize = true;
            this.checkBoxDescuento.Location = new System.Drawing.Point(347, 50);
            this.checkBoxDescuento.Name = "checkBoxDescuento";
            this.checkBoxDescuento.Size = new System.Drawing.Size(34, 17);
            this.checkBoxDescuento.TabIndex = 96;
            this.checkBoxDescuento.Text = "%";
            this.checkBoxDescuento.UseVisualStyleBackColor = true;
            this.checkBoxDescuento.CheckedChanged += new System.EventHandler(this.checkBoxDescuento_CheckedChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView2.ColumnHeadersHeight = 29;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Subtotal});
            this.dataGridView2.Location = new System.Drawing.Point(8, 77);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(655, 189);
            this.dataGridView2.TabIndex = 105;
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 71.26904F;
            this.Column1.HeaderText = "Id";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 71.26904F;
            this.Column2.HeaderText = "Producto";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.FillWeight = 71.26904F;
            this.Column3.HeaderText = "Cantidad";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 74;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 71.26904F;
            this.Column4.HeaderText = "Precio";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 243.6548F;
            this.Column5.HeaderText = "Descuento";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.FillWeight = 71.26904F;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.MinimumWidth = 6;
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(210, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "Cantidad:";
            // 
            // textCantProducto
            // 
            this.textCantProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textCantProducto.Location = new System.Drawing.Point(210, 48);
            this.textCantProducto.Name = "textCantProducto";
            this.textCantProducto.Size = new System.Drawing.Size(65, 20);
            this.textCantProducto.TabIndex = 97;
            this.textCantProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCantProducto_KeyDown);
            // 
            // BtnQuitar
            // 
            this.BtnQuitar.Location = new System.Drawing.Point(602, 48);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(61, 23);
            this.BtnQuitar.TabIndex = 96;
            this.BtnQuitar.Text = "Quitar";
            this.BtnQuitar.UseVisualStyleBackColor = true;
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(535, 47);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(61, 23);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // textNombreProducto
            // 
            this.textNombreProducto.Enabled = false;
            this.textNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombreProducto.Location = new System.Drawing.Point(10, 48);
            this.textNombreProducto.Name = "textNombreProducto";
            this.textNombreProducto.ReadOnly = true;
            this.textNombreProducto.Size = new System.Drawing.Size(148, 20);
            this.textNombreProducto.TabIndex = 81;
            // 
            // btnBuscarProd
            // 
            this.btnBuscarProd.Location = new System.Drawing.Point(161, 48);
            this.btnBuscarProd.Name = "btnBuscarProd";
            this.btnBuscarProd.Size = new System.Drawing.Size(32, 21);
            this.btnBuscarProd.TabIndex = 82;
            this.btnBuscarProd.Text = "...";
            this.btnBuscarProd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarProd.UseVisualStyleBackColor = true;
            this.btnBuscarProd.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(284, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Descuento:";
            // 
            // textDescuentoPorcentaje
            // 
            this.textDescuentoPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textDescuentoPorcentaje.Location = new System.Drawing.Point(287, 48);
            this.textDescuentoPorcentaje.Name = "textDescuentoPorcentaje";
            this.textDescuentoPorcentaje.Size = new System.Drawing.Size(54, 20);
            this.textDescuentoPorcentaje.TabIndex = 91;
            this.textDescuentoPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDescuentoPorcentaje_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 86;
            this.label8.Text = "Nombre de Producto:";
            // 
            // btCorreo
            // 
            this.btCorreo.BackColor = System.Drawing.Color.White;
            this.btCorreo.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCorreo.Location = new System.Drawing.Point(21, 429);
            this.btCorreo.Name = "btCorreo";
            this.btCorreo.Size = new System.Drawing.Size(158, 27);
            this.btCorreo.TabIndex = 108;
            this.btCorreo.Text = "Boleta de venta";
            this.btCorreo.UseVisualStyleBackColor = false;
            this.btCorreo.Click += new System.EventHandler(this.btCorreo_Click);
            // 
            // textMonto
            // 
            this.textMonto.Location = new System.Drawing.Point(402, 23);
            this.textMonto.Name = "textMonto";
            this.textMonto.ReadOnly = true;
            this.textMonto.Size = new System.Drawing.Size(97, 20);
            this.textMonto.TabIndex = 107;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(329, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 106;
            this.label11.Text = "Monto Total:";
            // 
            // btPedido
            // 
            this.btPedido.BackColor = System.Drawing.Color.White;
            this.btPedido.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPedido.Location = new System.Drawing.Point(21, 391);
            this.btPedido.Name = "btPedido";
            this.btPedido.Size = new System.Drawing.Size(158, 35);
            this.btPedido.TabIndex = 109;
            this.btPedido.Text = "Registrar";
            this.btPedido.UseVisualStyleBackColor = false;
            this.btPedido.Click += new System.EventHandler(this.btPedido_Click);
            // 
            // tsMenu
            // 
            this.tsMenu.BackColor = System.Drawing.Color.White;
            this.tsMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnBuscarPedido,
            this.btnCancelar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(715, 27);
            this.tsMenu.TabIndex = 110;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(70, 24);
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBuscarPedido
            // 
            this.btnBuscarPedido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPedido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscarPedido.Image = global::ARSACSoft.Properties.Resources.Search;
            this.btnBuscarPedido.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new System.Drawing.Size(70, 24);
            this.btnBuscarPedido.Text = "&Buscar";
            this.btnBuscarPedido.Click += new System.EventHandler(this.btnBuscarPedido_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Image = global::ARSACSoft.Properties.Resources.Cancel;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 24);
            this.btnCancelar.Text = "Limpiar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscarDireccion);
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textMonto);
            this.groupBox2.Controls.Add(this.dateFechaEntrega);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(185, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 65);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            // 
            // btnBuscarDireccion
            // 
            this.btnBuscarDireccion.Location = new System.Drawing.Point(278, 36);
            this.btnBuscarDireccion.Name = "btnBuscarDireccion";
            this.btnBuscarDireccion.Size = new System.Drawing.Size(32, 21);
            this.btnBuscarDireccion.TabIndex = 106;
            this.btnBuscarDireccion.Text = "...";
            this.btnBuscarDireccion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarDireccion.UseVisualStyleBackColor = true;
            this.btnBuscarDireccion.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(99, 36);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(173, 20);
            this.txtDireccion.TabIndex = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "Direccion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 107;
            this.label2.Text = "Fecha de entrega:";
            // 
            // dateFechaEntrega
            // 
            this.dateFechaEntrega.Location = new System.Drawing.Point(99, 10);
            this.dateFechaEntrega.Name = "dateFechaEntrega";
            this.dateFechaEntrega.Size = new System.Drawing.Size(211, 20);
            this.dateFechaEntrega.TabIndex = 106;
            // 
            // frmGestionPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::ARSACSoft.Properties.Resources.minimalist_desktop_131;
            this.ClientSize = new System.Drawing.Size(715, 470);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.btPedido);
            this.Controls.Add(this.btCorreo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbProveedor);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionPedidos";
            this.ShowInTaskbar = false;
            this.Text = "frmGestionsVentas";
            this.gbProveedor.ResumeLayout(false);
            this.gbProveedor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbProveedor;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.Label lblDNICliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox textNombreProducto;
        private System.Windows.Forms.Button btnBuscarProd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDescuentoPorcentaje;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btCorreo;
        private System.Windows.Forms.TextBox textMonto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCantProducto;
        private System.Windows.Forms.Button btPedido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.CheckBox checkBoxFactura;
        private System.Windows.Forms.CheckBox checkBoxDescuento;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnBuscarPedido;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.Button AgregarCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateFechaEntrega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.Button btnBuscarDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label4;
    }
}