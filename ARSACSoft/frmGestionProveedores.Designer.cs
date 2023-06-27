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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pbNotificacion = new System.Windows.Forms.PictureBox();
            this.lblMensajeQuitar = new System.Windows.Forms.Label();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.btnQuitarProveedor = new System.Windows.Forms.Button();
            this.rbRecibido = new System.Windows.Forms.RadioButton();
            this.rbCancelado = new System.Windows.Forms.RadioButton();
            this.rbEnProceso = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarProveedorOC = new System.Windows.Forms.Button();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtRazonSocialProveedorOC = new System.Windows.Forms.TextBox();
            this.txtRUCProveedorOC = new System.Windows.Forms.TextBox();
            this.lblDNICliente = new System.Windows.Forms.Label();
            this.btnBuscarHistorialCompras = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpfin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dgvOrdenesCompra = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estadoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcAlmacen.SuspendLayout();
            this.tpAdministrar.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.tpHistorialCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAlmacen
            // 
            this.tcAlmacen.Controls.Add(this.tpAdministrar);
            this.tcAlmacen.Controls.Add(this.tpHistorialCompras);
            this.tcAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAlmacen.Location = new System.Drawing.Point(12, 12);
            this.tcAlmacen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcAlmacen.Name = "tcAlmacen";
            this.tcAlmacen.SelectedIndex = 0;
            this.tcAlmacen.Size = new System.Drawing.Size(929, 555);
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
            this.tpAdministrar.Location = new System.Drawing.Point(4, 34);
            this.tpAdministrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpAdministrar.Name = "tpAdministrar";
            this.tpAdministrar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpAdministrar.Size = new System.Drawing.Size(921, 517);
            this.tpAdministrar.TabIndex = 0;
            this.tpAdministrar.Text = "Proveedor";
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
            this.groupBox4.Location = new System.Drawing.Point(488, 49);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(379, 185);
            this.groupBox4.TabIndex = 143;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Establecer productos del proveedor";
            // 
            // txtCosto
            // 
            this.txtCosto.Enabled = false;
            this.txtCosto.Location = new System.Drawing.Point(112, 114);
            this.txtCosto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(253, 24);
            this.txtCosto.TabIndex = 153;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(13, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 152;
            this.label3.Text = "Costo:";
            // 
            // btnQuitarProductoTabSede
            // 
            this.btnQuitarProductoTabSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarProductoTabSede.Location = new System.Drawing.Point(260, 148);
            this.btnQuitarProductoTabSede.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitarProductoTabSede.Name = "btnQuitarProductoTabSede";
            this.btnQuitarProductoTabSede.Size = new System.Drawing.Size(105, 28);
            this.btnQuitarProductoTabSede.TabIndex = 151;
            this.btnQuitarProductoTabSede.Text = "Quitar";
            this.btnQuitarProductoTabSede.UseVisualStyleBackColor = true;
            this.btnQuitarProductoTabSede.Click += new System.EventHandler(this.btnQuitarProductoTabSede_Click);
            // 
            // btnAgregarProductoTabSede
            // 
            this.btnAgregarProductoTabSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProductoTabSede.Location = new System.Drawing.Point(147, 149);
            this.btnAgregarProductoTabSede.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarProductoTabSede.Name = "btnAgregarProductoTabSede";
            this.btnAgregarProductoTabSede.Size = new System.Drawing.Size(105, 28);
            this.btnAgregarProductoTabSede.TabIndex = 150;
            this.btnAgregarProductoTabSede.Text = "Agregar";
            this.btnAgregarProductoTabSede.UseVisualStyleBackColor = true;
            this.btnAgregarProductoTabSede.Click += new System.EventHandler(this.btnAgregarProductoTabSede_Click);
            // 
            // btnBuscarProductoTabSede
            // 
            this.btnBuscarProductoTabSede.Location = new System.Drawing.Point(244, 28);
            this.btnBuscarProductoTabSede.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarProductoTabSede.Name = "btnBuscarProductoTabSede";
            this.btnBuscarProductoTabSede.Size = new System.Drawing.Size(43, 28);
            this.btnBuscarProductoTabSede.TabIndex = 149;
            this.btnBuscarProductoTabSede.Text = "...";
            this.btnBuscarProductoTabSede.UseVisualStyleBackColor = true;
            this.btnBuscarProductoTabSede.Click += new System.EventHandler(this.btnBuscarProductoTabSede_Click);
            // 
            // txtNombreProductoTabSede
            // 
            this.txtNombreProductoTabSede.Enabled = false;
            this.txtNombreProductoTabSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProductoTabSede.Location = new System.Drawing.Point(112, 60);
            this.txtNombreProductoTabSede.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreProductoTabSede.Multiline = true;
            this.txtNombreProductoTabSede.Name = "txtNombreProductoTabSede";
            this.txtNombreProductoTabSede.ReadOnly = true;
            this.txtNombreProductoTabSede.Size = new System.Drawing.Size(253, 43);
            this.txtNombreProductoTabSede.TabIndex = 148;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 64);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 18);
            this.label8.TabIndex = 147;
            this.label8.Text = "Producto:";
            // 
            // txtIdProductoTabSede
            // 
            this.txtIdProductoTabSede.Enabled = false;
            this.txtIdProductoTabSede.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProductoTabSede.Location = new System.Drawing.Point(112, 30);
            this.txtIdProductoTabSede.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdProductoTabSede.Name = "txtIdProductoTabSede";
            this.txtIdProductoTabSede.ReadOnly = true;
            this.txtIdProductoTabSede.Size = new System.Drawing.Size(123, 23);
            this.txtIdProductoTabSede.TabIndex = 146;
            // 
            // lblCodProducto
            // 
            this.lblCodProducto.AutoSize = true;
            this.lblCodProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProducto.Location = new System.Drawing.Point(13, 33);
            this.lblCodProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodProducto.Name = "lblCodProducto";
            this.lblCodProducto.Size = new System.Drawing.Size(91, 18);
            this.lblCodProducto.TabIndex = 145;
            this.lblCodProducto.Text = "ID Producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(35, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 109;
            this.label1.Text = "ID:";
            // 
            // txtIDProveedor
            // 
            this.txtIDProveedor.Enabled = false;
            this.txtIDProveedor.Location = new System.Drawing.Point(156, 46);
            this.txtIDProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIDProveedor.Name = "txtIDProveedor";
            this.txtIDProveedor.ReadOnly = true;
            this.txtIDProveedor.Size = new System.Drawing.Size(119, 24);
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
            this.Categoria,
            this.Column2});
            this.dgvProductos.Location = new System.Drawing.Point(39, 267);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(828, 229);
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
            // Column2
            // 
            this.Column2.HeaderText = "Costo";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnBuscarDirrecion
            // 
            this.btnBuscarDirrecion.Enabled = false;
            this.btnBuscarDirrecion.Location = new System.Drawing.Point(428, 150);
            this.btnBuscarDirrecion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarDirrecion.Name = "btnBuscarDirrecion";
            this.btnBuscarDirrecion.Size = new System.Drawing.Size(37, 28);
            this.btnBuscarDirrecion.TabIndex = 107;
            this.btnBuscarDirrecion.Text = "...";
            this.btnBuscarDirrecion.UseVisualStyleBackColor = true;
            this.btnBuscarDirrecion.Click += new System.EventHandler(this.btnBuscarDirrecion_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(156, 185);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(261, 24);
            this.txtTelefono.TabIndex = 104;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(156, 151);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(261, 24);
            this.txtDireccion.TabIndex = 103;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(36, 185);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(86, 18);
            this.lblTelefono.TabIndex = 102;
            this.lblTelefono.Text = "(*)Teléfono:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDireccion.Location = new System.Drawing.Point(36, 151);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(75, 18);
            this.lblDireccion.TabIndex = 101;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblRUC
            // 
            this.lblRUC.AutoSize = true;
            this.lblRUC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRUC.Location = new System.Drawing.Point(35, 81);
            this.lblRUC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(61, 18);
            this.lblRUC.TabIndex = 100;
            this.lblRUC.Text = "(*)RUC:";
            // 
            // txtRUC
            // 
            this.txtRUC.Enabled = false;
            this.txtRUC.Location = new System.Drawing.Point(156, 78);
            this.txtRUC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(261, 24);
            this.txtRUC.TabIndex = 99;
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNombreProveedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNombreProveedor.Location = new System.Drawing.Point(35, 113);
            this.lblNombreProveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(115, 18);
            this.lblNombreProveedor.TabIndex = 11;
            this.lblNombreProveedor.Text = "(*)Razón social:";
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Enabled = false;
            this.txtNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNombreProveedor.Location = new System.Drawing.Point(156, 111);
            this.txtNombreProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(261, 24);
            this.txtNombreProveedor.TabIndex = 10;
            // 
            // cbCafeteria
            // 
            this.cbCafeteria.AutoSize = true;
            this.cbCafeteria.Location = new System.Drawing.Point(1189, 446);
            this.cbCafeteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCafeteria.Name = "cbCafeteria";
            this.cbCafeteria.Size = new System.Drawing.Size(89, 22);
            this.cbCafeteria.TabIndex = 41;
            this.cbCafeteria.Text = "Cafetería";
            this.cbCafeteria.UseVisualStyleBackColor = true;
            // 
            // cbSalasEstudio
            // 
            this.cbSalasEstudio.AutoSize = true;
            this.cbSalasEstudio.Location = new System.Drawing.Point(956, 446);
            this.cbSalasEstudio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSalasEstudio.Name = "cbSalasEstudio";
            this.cbSalasEstudio.Size = new System.Drawing.Size(139, 22);
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
            this.tsMenu.Location = new System.Drawing.Point(3, 2);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(915, 30);
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
            this.btnNuevo.Size = new System.Drawing.Size(84, 27);
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
            this.btnGuardar.Size = new System.Drawing.Size(96, 27);
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
            this.btnBuscar.Size = new System.Drawing.Size(84, 27);
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Image = global::ARSACSoft.Properties.Resources.boton_editar1;
            this.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(97, 27);
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
            this.btnCancelar.Size = new System.Drawing.Size(100, 27);
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblGestionSedes
            // 
            this.lblGestionSedes.AutoSize = true;
            this.lblGestionSedes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionSedes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGestionSedes.Location = new System.Drawing.Point(35, 230);
            this.lblGestionSedes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGestionSedes.Name = "lblGestionSedes";
            this.lblGestionSedes.Size = new System.Drawing.Size(288, 20);
            this.lblGestionSedes.TabIndex = 3;
            this.lblGestionSedes.Text = "Catálogo de Productos Ofrecidos";
            // 
            // tpHistorialCompras
            // 
            this.tpHistorialCompras.Controls.Add(this.pbNotificacion);
            this.tpHistorialCompras.Controls.Add(this.lblMensajeQuitar);
            this.tpHistorialCompras.Controls.Add(this.rbTodos);
            this.tpHistorialCompras.Controls.Add(this.btnQuitarProveedor);
            this.tpHistorialCompras.Controls.Add(this.rbRecibido);
            this.tpHistorialCompras.Controls.Add(this.rbCancelado);
            this.tpHistorialCompras.Controls.Add(this.rbEnProceso);
            this.tpHistorialCompras.Controls.Add(this.label2);
            this.tpHistorialCompras.Controls.Add(this.btnBuscarProveedorOC);
            this.tpHistorialCompras.Controls.Add(this.lblNombreCliente);
            this.tpHistorialCompras.Controls.Add(this.txtRazonSocialProveedorOC);
            this.tpHistorialCompras.Controls.Add(this.txtRUCProveedorOC);
            this.tpHistorialCompras.Controls.Add(this.lblDNICliente);
            this.tpHistorialCompras.Controls.Add(this.btnBuscarHistorialCompras);
            this.tpHistorialCompras.Controls.Add(this.label4);
            this.tpHistorialCompras.Controls.Add(this.label5);
            this.tpHistorialCompras.Controls.Add(this.dtpfin);
            this.tpHistorialCompras.Controls.Add(this.dtpInicio);
            this.tpHistorialCompras.Controls.Add(this.dgvOrdenesCompra);
            this.tpHistorialCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHistorialCompras.Location = new System.Drawing.Point(4, 34);
            this.tpHistorialCompras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpHistorialCompras.Name = "tpHistorialCompras";
            this.tpHistorialCompras.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpHistorialCompras.Size = new System.Drawing.Size(921, 517);
            this.tpHistorialCompras.TabIndex = 1;
            this.tpHistorialCompras.Text = "Historial de compras";
            this.tpHistorialCompras.UseVisualStyleBackColor = true;
            // 
            // pbNotificacion
            // 
            this.pbNotificacion.Image = ((System.Drawing.Image)(resources.GetObject("pbNotificacion.Image")));
            this.pbNotificacion.Location = new System.Drawing.Point(-83, 450);
            this.pbNotificacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbNotificacion.Name = "pbNotificacion";
            this.pbNotificacion.Size = new System.Drawing.Size(29, 30);
            this.pbNotificacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNotificacion.TabIndex = 74;
            this.pbNotificacion.TabStop = false;
            // 
            // lblMensajeQuitar
            // 
            this.lblMensajeQuitar.AutoSize = true;
            this.lblMensajeQuitar.Location = new System.Drawing.Point(-44, 457);
            this.lblMensajeQuitar.Name = "lblMensajeQuitar";
            this.lblMensajeQuitar.Size = new System.Drawing.Size(0, 18);
            this.lblMensajeQuitar.TabIndex = 73;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(108, 114);
            this.rbTodos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(83, 22);
            this.rbTodos.TabIndex = 72;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "TODOS";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // btnQuitarProveedor
            // 
            this.btnQuitarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarProveedor.Location = new System.Drawing.Point(829, 23);
            this.btnQuitarProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitarProveedor.Name = "btnQuitarProveedor";
            this.btnQuitarProveedor.Size = new System.Drawing.Size(71, 28);
            this.btnQuitarProveedor.TabIndex = 71;
            this.btnQuitarProveedor.Text = "Quitar";
            this.btnQuitarProveedor.UseVisualStyleBackColor = true;
            this.btnQuitarProveedor.Click += new System.EventHandler(this.btnQuitarProveedor_Click);
            this.btnQuitarProveedor.MouseLeave += new System.EventHandler(this.btnQuitarProveedor_MouseLeave);
            this.btnQuitarProveedor.MouseHover += new System.EventHandler(this.btnQuitarProveedor_MouseHover);
            // 
            // rbRecibido
            // 
            this.rbRecibido.AutoSize = true;
            this.rbRecibido.Location = new System.Drawing.Point(475, 114);
            this.rbRecibido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbRecibido.Name = "rbRecibido";
            this.rbRecibido.Size = new System.Drawing.Size(100, 22);
            this.rbRecibido.TabIndex = 70;
            this.rbRecibido.TabStop = true;
            this.rbRecibido.Text = "RECIBIDO";
            this.rbRecibido.UseVisualStyleBackColor = true;
            // 
            // rbCancelado
            // 
            this.rbCancelado.AutoSize = true;
            this.rbCancelado.Location = new System.Drawing.Point(347, 114);
            this.rbCancelado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbCancelado.Name = "rbCancelado";
            this.rbCancelado.Size = new System.Drawing.Size(121, 22);
            this.rbCancelado.TabIndex = 69;
            this.rbCancelado.TabStop = true;
            this.rbCancelado.Text = "CANCELADO";
            this.rbCancelado.UseVisualStyleBackColor = true;
            // 
            // rbEnProceso
            // 
            this.rbEnProceso.AutoSize = true;
            this.rbEnProceso.Location = new System.Drawing.Point(207, 114);
            this.rbEnProceso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbEnProceso.Name = "rbEnProceso";
            this.rbEnProceso.Size = new System.Drawing.Size(130, 22);
            this.rbEnProceso.TabIndex = 68;
            this.rbEnProceso.TabStop = true;
            this.rbEnProceso.Text = "EN PROCESO";
            this.rbEnProceso.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 67;
            this.label2.Text = "Estado:";
            // 
            // btnBuscarProveedorOC
            // 
            this.btnBuscarProveedorOC.BackColor = System.Drawing.Color.White;
            this.btnBuscarProveedorOC.Location = new System.Drawing.Point(773, 23);
            this.btnBuscarProveedorOC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarProveedorOC.Name = "btnBuscarProveedorOC";
            this.btnBuscarProveedorOC.Size = new System.Drawing.Size(40, 28);
            this.btnBuscarProveedorOC.TabIndex = 66;
            this.btnBuscarProveedorOC.Text = "...";
            this.btnBuscarProveedorOC.UseVisualStyleBackColor = false;
            this.btnBuscarProveedorOC.Click += new System.EventHandler(this.btnBuscarProveedorOC_Click);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(332, 30);
            this.lblNombreCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(99, 18);
            this.lblNombreCliente.TabIndex = 65;
            this.lblNombreCliente.Text = "Razón social:";
            // 
            // txtRazonSocialProveedorOC
            // 
            this.txtRazonSocialProveedorOC.BackColor = System.Drawing.SystemColors.Control;
            this.txtRazonSocialProveedorOC.Enabled = false;
            this.txtRazonSocialProveedorOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocialProveedorOC.Location = new System.Drawing.Point(467, 25);
            this.txtRazonSocialProveedorOC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRazonSocialProveedorOC.Name = "txtRazonSocialProveedorOC";
            this.txtRazonSocialProveedorOC.ReadOnly = true;
            this.txtRazonSocialProveedorOC.Size = new System.Drawing.Size(283, 24);
            this.txtRazonSocialProveedorOC.TabIndex = 64;
            // 
            // txtRUCProveedorOC
            // 
            this.txtRUCProveedorOC.BackColor = System.Drawing.SystemColors.Control;
            this.txtRUCProveedorOC.Enabled = false;
            this.txtRUCProveedorOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRUCProveedorOC.Location = new System.Drawing.Point(108, 25);
            this.txtRUCProveedorOC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRUCProveedorOC.Name = "txtRUCProveedorOC";
            this.txtRUCProveedorOC.ReadOnly = true;
            this.txtRUCProveedorOC.Size = new System.Drawing.Size(201, 24);
            this.txtRUCProveedorOC.TabIndex = 63;
            // 
            // lblDNICliente
            // 
            this.lblDNICliente.AutoSize = true;
            this.lblDNICliente.BackColor = System.Drawing.Color.Transparent;
            this.lblDNICliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNICliente.Location = new System.Drawing.Point(17, 30);
            this.lblDNICliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDNICliente.Name = "lblDNICliente";
            this.lblDNICliente.Size = new System.Drawing.Size(45, 18);
            this.lblDNICliente.TabIndex = 62;
            this.lblDNICliente.Text = "RUC:";
            // 
            // btnBuscarHistorialCompras
            // 
            this.btnBuscarHistorialCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarHistorialCompras.Location = new System.Drawing.Point(753, 124);
            this.btnBuscarHistorialCompras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarHistorialCompras.Name = "btnBuscarHistorialCompras";
            this.btnBuscarHistorialCompras.Size = new System.Drawing.Size(147, 28);
            this.btnBuscarHistorialCompras.TabIndex = 61;
            this.btnBuscarHistorialCompras.Text = "Buscar";
            this.btnBuscarHistorialCompras.UseVisualStyleBackColor = true;
            this.btnBuscarHistorialCompras.Click += new System.EventHandler(this.btnBuscarHistorialCompras_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(471, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 60;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 59;
            this.label5.Text = "(*)Entre:";
            // 
            // dtpfin
            // 
            this.dtpfin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfin.Location = new System.Drawing.Point(531, 70);
            this.dtpfin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpfin.Name = "dtpfin";
            this.dtpfin.Size = new System.Drawing.Size(321, 24);
            this.dtpfin.TabIndex = 58;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Location = new System.Drawing.Point(109, 70);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(321, 24);
            this.dtpInicio.TabIndex = 57;
            // 
            // dgvOrdenesCompra
            // 
            this.dgvOrdenesCompra.AllowUserToAddRows = false;
            this.dgvOrdenesCompra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenesCompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI,
            this.dataGridViewTextBoxColumn1,
            this.s,
            this.dataGridViewTextBoxColumn2,
            this.Estadoa});
            this.dgvOrdenesCompra.Location = new System.Drawing.Point(13, 166);
            this.dgvOrdenesCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvOrdenesCompra.Name = "dgvOrdenesCompra";
            this.dgvOrdenesCompra.ReadOnly = true;
            this.dgvOrdenesCompra.RowHeadersVisible = false;
            this.dgvOrdenesCompra.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenesCompra.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOrdenesCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenesCompra.Size = new System.Drawing.Size(885, 334);
            this.dgvOrdenesCompra.TabIndex = 55;
            this.dgvOrdenesCompra.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrdenesCompra_CellFormatting);
            // 
            // DNI
            // 
            this.DNI.FillWeight = 5.525574F;
            this.DNI.HeaderText = "ID";
            this.DNI.MinimumWidth = 6;
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Width = 70;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 44.31167F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Proveedor";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // s
            // 
            this.s.FillWeight = 58.17179F;
            this.s.HeaderText = "Fecha emisión";
            this.s.MinimumWidth = 6;
            this.s.Name = "s";
            this.s.ReadOnly = true;
            this.s.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 124.6113F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Monto total";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // Estadoa
            // 
            this.Estadoa.FillWeight = 267.3797F;
            this.Estadoa.HeaderText = "Estado";
            this.Estadoa.MinimumWidth = 6;
            this.Estadoa.Name = "Estadoa";
            this.Estadoa.ReadOnly = true;
            this.Estadoa.Width = 180;
            // 
            // frmGestionProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 578);
            this.Controls.Add(this.tcAlmacen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesCompra)).EndInit();
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
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton btnModificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.PictureBox pbNotificacion;
        private System.Windows.Forms.Label lblMensajeQuitar;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Button btnQuitarProveedor;
        private System.Windows.Forms.RadioButton rbRecibido;
        private System.Windows.Forms.RadioButton rbCancelado;
        private System.Windows.Forms.RadioButton rbEnProceso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarProveedorOC;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtRazonSocialProveedorOC;
        private System.Windows.Forms.TextBox txtRUCProveedorOC;
        private System.Windows.Forms.Label lblDNICliente;
        private System.Windows.Forms.Button btnBuscarHistorialCompras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpfin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DataGridView dgvOrdenesCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn s;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estadoa;
    }
}