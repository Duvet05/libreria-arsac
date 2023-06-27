namespace ARSACSoft
{
    partial class frmGestionProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionProveedores));
            this.tcAlmacen = new System.Windows.Forms.TabControl();
            this.tpAdministrar = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuitarProductoTabSede = new System.Windows.Forms.Button();
            this.btnAgregarProductoTabSede = new System.Windows.Forms.Button();
            this.btnBuscarProductoTabSede = new System.Windows.Forms.Button();
            this.txtNombreProductoTabSede = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdProductoTabSede = new System.Windows.Forms.TextBox();
            this.lblCodProducto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDProveedor = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarDirrecion = new System.Windows.Forms.Button();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblRUC = new System.Windows.Forms.Label();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.cbCafeteria = new System.Windows.Forms.CheckBox();
            this.cbSalasEstudio = new System.Windows.Forms.CheckBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnModificar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.lblGestionSedes = new System.Windows.Forms.Label();
            this.tpHistorialCompras = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcAlmacen.SuspendLayout();
            this.tpAdministrar.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.tpHistorialCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAlmacen
            // 
            this.tcAlmacen.Controls.Add(this.tpAdministrar);
            this.tcAlmacen.Controls.Add(this.tpHistorialCompras);
            this.tcAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAlmacen.Location = new System.Drawing.Point(9, 10);
            this.tcAlmacen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcAlmacen.Name = "tcAlmacen";
            this.tcAlmacen.SelectedIndex = 0;
            this.tcAlmacen.Size = new System.Drawing.Size(697, 451);
            this.tcAlmacen.TabIndex = 2;
            // 
            // tpAdministrar
            // 
            this.tpAdministrar.Controls.Add(this.groupBox4);
            this.tpAdministrar.Controls.Add(this.label1);
            this.tpAdministrar.Controls.Add(this.txtIDProveedor);
            this.tpAdministrar.Controls.Add(this.dgvProductos);
            this.tpAdministrar.Controls.Add(this.btnBuscarDirrecion);
            this.tpAdministrar.Controls.Add(this.txtTelefono);
            this.tpAdministrar.Controls.Add(this.txtDireccion);
            this.tpAdministrar.Controls.Add(this.lblTelefono);
            this.tpAdministrar.Controls.Add(this.lblDireccion);
            this.tpAdministrar.Controls.Add(this.lblRUC);
            this.tpAdministrar.Controls.Add(this.txtRUC);
            this.tpAdministrar.Controls.Add(this.lblNombreProveedor);
            this.tpAdministrar.Controls.Add(this.txtNombreProveedor);
            this.tpAdministrar.Controls.Add(this.cbCafeteria);
            this.tpAdministrar.Controls.Add(this.cbSalasEstudio);
            this.tpAdministrar.Controls.Add(this.tsMenu);
            this.tpAdministrar.Controls.Add(this.lblGestionSedes);
            this.tpAdministrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpAdministrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tpAdministrar.Location = new System.Drawing.Point(4, 29);
            this.tpAdministrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpAdministrar.Name = "tpAdministrar";
            this.tpAdministrar.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpAdministrar.Size = new System.Drawing.Size(689, 418);
            this.tpAdministrar.TabIndex = 0;
            this.tpAdministrar.Text = "Administrar";
            this.tpAdministrar.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCosto);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnQuitarProductoTabSede);
            this.groupBox4.Controls.Add(this.btnAgregarProductoTabSede);
            this.groupBox4.Controls.Add(this.btnBuscarProductoTabSede);
            this.groupBox4.Controls.Add(this.txtNombreProductoTabSede);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtIdProductoTabSede);
            this.groupBox4.Controls.Add(this.lblCodProducto);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(366, 40);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(284, 150);
            this.groupBox4.TabIndex = 143;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Establecer productos del proveedor";
            // 
            // txtCosto
            // 
            this.txtCosto.Enabled = false;
            this.txtCosto.Location = new System.Drawing.Point(84, 93);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(191, 21);
            this.txtCosto.TabIndex = 153;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(10, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 152;
            this.label3.Text = "Costo:";
            // 
            // btnQuitarProductoTabSede
            // 
            this.btnQuitarProductoTabSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarProductoTabSede.Location = new System.Drawing.Point(195, 120);
            this.btnQuitarProductoTabSede.Name = "btnQuitarProductoTabSede";
            this.btnQuitarProductoTabSede.Size = new System.Drawing.Size(79, 23);
            this.btnQuitarProductoTabSede.TabIndex = 151;
            this.btnQuitarProductoTabSede.Text = "Quitar";
            this.btnQuitarProductoTabSede.UseVisualStyleBackColor = true;
            this.btnQuitarProductoTabSede.Click += new System.EventHandler(this.btnQuitarProductoTabSede_Click);
            // 
            // btnAgregarProductoTabSede
            // 
            this.btnAgregarProductoTabSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProductoTabSede.Location = new System.Drawing.Point(110, 121);
            this.btnAgregarProductoTabSede.Name = "btnAgregarProductoTabSede";
            this.btnAgregarProductoTabSede.Size = new System.Drawing.Size(79, 23);
            this.btnAgregarProductoTabSede.TabIndex = 150;
            this.btnAgregarProductoTabSede.Text = "Agregar";
            this.btnAgregarProductoTabSede.UseVisualStyleBackColor = true;
            this.btnAgregarProductoTabSede.Click += new System.EventHandler(this.btnAgregarProductoTabSede_Click);
            // 
            // btnBuscarProductoTabSede
            // 
            this.btnBuscarProductoTabSede.Location = new System.Drawing.Point(183, 23);
            this.btnBuscarProductoTabSede.Name = "btnBuscarProductoTabSede";
            this.btnBuscarProductoTabSede.Size = new System.Drawing.Size(32, 23);
            this.btnBuscarProductoTabSede.TabIndex = 149;
            this.btnBuscarProductoTabSede.Text = "...";
            this.btnBuscarProductoTabSede.UseVisualStyleBackColor = true;
            this.btnBuscarProductoTabSede.Click += new System.EventHandler(this.btnBuscarProductoTabSede_Click);
            // 
            // txtNombreProductoTabSede
            // 
            this.txtNombreProductoTabSede.Enabled = false;
            this.txtNombreProductoTabSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProductoTabSede.Location = new System.Drawing.Point(84, 49);
            this.txtNombreProductoTabSede.Multiline = true;
            this.txtNombreProductoTabSede.Name = "txtNombreProductoTabSede";
            this.txtNombreProductoTabSede.ReadOnly = true;
            this.txtNombreProductoTabSede.Size = new System.Drawing.Size(191, 36);
            this.txtNombreProductoTabSede.TabIndex = 148;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 147;
            this.label8.Text = "Producto:";
            // 
            // txtIdProductoTabSede
            // 
            this.txtIdProductoTabSede.Enabled = false;
            this.txtIdProductoTabSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProductoTabSede.Location = new System.Drawing.Point(84, 24);
            this.txtIdProductoTabSede.Name = "txtIdProductoTabSede";
            this.txtIdProductoTabSede.ReadOnly = true;
            this.txtIdProductoTabSede.Size = new System.Drawing.Size(93, 20);
            this.txtIdProductoTabSede.TabIndex = 146;
            // 
            // lblCodProducto
            // 
            this.lblCodProducto.AutoSize = true;
            this.lblCodProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProducto.Location = new System.Drawing.Point(10, 27);
            this.lblCodProducto.Name = "lblCodProducto";
            this.lblCodProducto.Size = new System.Drawing.Size(74, 15);
            this.lblCodProducto.TabIndex = 145;
            this.lblCodProducto.Text = "ID Producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 109;
            this.label1.Text = "ID:";
            // 
            // txtIDProveedor
            // 
            this.txtIDProveedor.Enabled = false;
            this.txtIDProveedor.Location = new System.Drawing.Point(119, 38);
            this.txtIDProveedor.Name = "txtIDProveedor";
            this.txtIDProveedor.ReadOnly = true;
            this.txtIDProveedor.Size = new System.Drawing.Size(90, 21);
            this.txtIDProveedor.TabIndex = 108;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeight = 29;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Producto,
            this.Marca,
            this.Categoria});
            this.dgvProductos.Location = new System.Drawing.Point(29, 217);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(621, 186);
            this.dgvProductos.TabIndex = 62;
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 17.48135F;
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Producto
            // 
            this.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Producto.FillWeight = 107.4251F;
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Marca
            // 
            this.Marca.FillWeight = 48.50356F;
            this.Marca.HeaderText = "Marca";
            this.Marca.MinimumWidth = 6;
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.FillWeight = 65.71369F;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // btnBuscarDirrecion
            // 
            this.btnBuscarDirrecion.Enabled = false;
            this.btnBuscarDirrecion.Location = new System.Drawing.Point(321, 121);
            this.btnBuscarDirrecion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscarDirrecion.Name = "btnBuscarDirrecion";
            this.btnBuscarDirrecion.Size = new System.Drawing.Size(28, 23);
            this.btnBuscarDirrecion.TabIndex = 107;
            this.btnBuscarDirrecion.Text = "...";
            this.btnBuscarDirrecion.UseVisualStyleBackColor = true;
            this.btnBuscarDirrecion.Click += new System.EventHandler(this.btnBuscarDirrecion_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(119, 150);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(230, 21);
            this.txtTelefono.TabIndex = 104;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(119, 122);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(197, 21);
            this.txtDireccion.TabIndex = 103;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(24, 150);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(71, 15);
            this.lblTelefono.TabIndex = 102;
            this.lblTelefono.Text = "(*)Teléfono:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDireccion.Location = new System.Drawing.Point(24, 123);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(62, 15);
            this.lblDireccion.TabIndex = 101;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblRUC
            // 
            this.lblRUC.AutoSize = true;
            this.lblRUC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRUC.Location = new System.Drawing.Point(23, 69);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(49, 15);
            this.lblRUC.TabIndex = 100;
            this.lblRUC.Text = "(*)RUC:";
            // 
            // txtRUC
            // 
            this.txtRUC.Enabled = false;
            this.txtRUC.Location = new System.Drawing.Point(119, 66);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(230, 21);
            this.txtRUC.TabIndex = 99;
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNombreProveedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNombreProveedor.Location = new System.Drawing.Point(23, 96);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(94, 15);
            this.lblNombreProveedor.TabIndex = 11;
            this.lblNombreProveedor.Text = "(*)Razón social:";
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Enabled = false;
            this.txtNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNombreProveedor.Location = new System.Drawing.Point(119, 94);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(230, 21);
            this.txtNombreProveedor.TabIndex = 10;
            // 
            // cbCafeteria
            // 
            this.cbCafeteria.AutoSize = true;
            this.cbCafeteria.Location = new System.Drawing.Point(892, 362);
            this.cbCafeteria.Name = "cbCafeteria";
            this.cbCafeteria.Size = new System.Drawing.Size(75, 19);
            this.cbCafeteria.TabIndex = 41;
            this.cbCafeteria.Text = "Cafetería";
            this.cbCafeteria.UseVisualStyleBackColor = true;
            // 
            // cbSalasEstudio
            // 
            this.cbSalasEstudio.AutoSize = true;
            this.cbSalasEstudio.Location = new System.Drawing.Point(717, 362);
            this.cbSalasEstudio.Name = "cbSalasEstudio";
            this.cbSalasEstudio.Size = new System.Drawing.Size(117, 19);
            this.cbSalasEstudio.TabIndex = 39;
            this.cbSalasEstudio.Text = "Salas de estudio";
            this.cbSalasEstudio.UseVisualStyleBackColor = true;
            // 
            // tsMenu
            // 
            this.tsMenu.BackColor = System.Drawing.Color.Transparent;
            this.tsMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnGuardar,
            this.btnBuscar,
            this.btnModificar,
            this.btnCancelar});
            this.tsMenu.Location = new System.Drawing.Point(2, 2);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(685, 27);
            this.tsMenu.TabIndex = 4;
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
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 24);
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscar.Image = global::ARSACSoft.Properties.Resources.Search;
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(70, 24);
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Image = global::ARSACSoft.Properties.Resources.boton_editar1;
            this.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(82, 24);
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Image = global::ARSACSoft.Properties.Resources.Cancel;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 24);
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblGestionSedes
            // 
            this.lblGestionSedes.AutoSize = true;
            this.lblGestionSedes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionSedes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGestionSedes.Location = new System.Drawing.Point(26, 187);
            this.lblGestionSedes.Name = "lblGestionSedes";
            this.lblGestionSedes.Size = new System.Drawing.Size(237, 16);
            this.lblGestionSedes.TabIndex = 3;
            this.lblGestionSedes.Text = "Catálogo de Productos Ofrecidos";
            // 
            // tpHistorialCompras
            // 
            this.tpHistorialCompras.Controls.Add(this.button1);
            this.tpHistorialCompras.Controls.Add(this.button2);
            this.tpHistorialCompras.Controls.Add(this.label2);
            this.tpHistorialCompras.Controls.Add(this.textBox1);
            this.tpHistorialCompras.Controls.Add(this.dataGridView2);
            this.tpHistorialCompras.Location = new System.Drawing.Point(4, 29);
            this.tpHistorialCompras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpHistorialCompras.Name = "tpHistorialCompras";
            this.tpHistorialCompras.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpHistorialCompras.Size = new System.Drawing.Size(689, 418);
            this.tpHistorialCompras.TabIndex = 1;
            this.tpHistorialCompras.Text = "Historial de compras";
            this.tpHistorialCompras.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(596, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 102;
            this.button1.Text = "Quitar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(494, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 23);
            this.button2.TabIndex = 101;
            this.button2.Text = "Agregar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 15);
            this.label2.TabIndex = 100;
            this.label2.Text = "Ingrese el nombre del producto:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(205, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 21);
            this.textBox1.TabIndex = 99;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView2.ColumnHeadersHeight = 29;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridView2.Location = new System.Drawing.Point(21, 77);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(490, 280);
            this.dataGridView2.TabIndex = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha emisión";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Proveedor";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Monto total";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // frmGestionProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 470);
            this.Controls.Add(this.tcAlmacen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmGestionProveedores";
            this.Text = "frmGestionCompras";
            this.tcAlmacen.ResumeLayout(false);
            this.tpAdministrar.ResumeLayout(false);
            this.tpAdministrar.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.tpHistorialCompras.ResumeLayout(false);
            this.tpHistorialCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAlmacen;
        private System.Windows.Forms.TabPage tpAdministrar;
        private System.Windows.Forms.CheckBox cbCafeteria;
        private System.Windows.Forms.CheckBox cbSalasEstudio;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.Label lblGestionSedes;
        private System.Windows.Forms.TabPage tpHistorialCompras;
        private System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.Label lblRUC;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnBuscarDirrecion;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDProveedor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnQuitarProductoTabSede;
        private System.Windows.Forms.Button btnAgregarProductoTabSede;
        private System.Windows.Forms.Button btnBuscarProductoTabSede;
        private System.Windows.Forms.TextBox txtNombreProductoTabSede;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdProductoTabSede;
        private System.Windows.Forms.Label lblCodProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton btnModificar;
    }
}