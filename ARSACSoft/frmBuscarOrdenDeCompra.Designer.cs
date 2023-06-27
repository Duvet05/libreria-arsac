namespace ARSACSoft
{
    partial class frmBuscarOrdenDeCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarOrdenDeCompra));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpfin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgvOrdenesCompra = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarProveedorOC = new System.Windows.Forms.Button();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtRazonSocialProveedorOC = new System.Windows.Forms.TextBox();
            this.txtRUCProveedorOC = new System.Windows.Forms.TextBox();
            this.lblDNICliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbEnProceso = new System.Windows.Forms.RadioButton();
            this.rbCancelado = new System.Windows.Forms.RadioButton();
            this.rbRecibido = new System.Windows.Forms.RadioButton();
            this.btnQuitarProveedor = new System.Windows.Forms.Button();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.lblMensajeQuitar = new System.Windows.Forms.Label();
            this.pbNotificacion = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(584, 95);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 23);
            this.btnBuscar.TabIndex = 25;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(378, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "(*)Entre:";
            // 
            // dtpfin
            // 
            this.dtpfin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfin.Location = new System.Drawing.Point(422, 59);
            this.dtpfin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpfin.Name = "dtpfin";
            this.dtpfin.Size = new System.Drawing.Size(242, 21);
            this.dtpfin.TabIndex = 20;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Location = new System.Drawing.Point(107, 59);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(242, 21);
            this.dtpInicio.TabIndex = 19;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Location = new System.Drawing.Point(711, 95);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(112, 23);
            this.btnSeleccionar.TabIndex = 17;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dgvOrdenesCompra
            // 
            this.dgvOrdenesCompra.AllowUserToAddRows = false;
            this.dgvOrdenesCompra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenesCompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenesCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI,
            this.Column1,
            this.s,
            this.Column2,
            this.Estado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenesCompra.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenesCompra.Location = new System.Drawing.Point(10, 128);
            this.dgvOrdenesCompra.Name = "dgvOrdenesCompra";
            this.dgvOrdenesCompra.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenesCompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrdenesCompra.RowHeadersVisible = false;
            this.dgvOrdenesCompra.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenesCompra.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrdenesCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenesCompra.Size = new System.Drawing.Size(814, 225);
            this.dgvOrdenesCompra.TabIndex = 14;
            this.dgvOrdenesCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenesCompra_CellContentClick);
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
            // Column1
            // 
            this.Column1.FillWeight = 44.31167F;
            this.Column1.HeaderText = "Proveedor";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 250;
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
            // Column2
            // 
            this.Column2.FillWeight = 124.6113F;
            this.Column2.HeaderText = "Monto total";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Estado
            // 
            this.Estado.FillWeight = 267.3797F;
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 180;
            // 
            // btnBuscarProveedorOC
            // 
            this.btnBuscarProveedorOC.BackColor = System.Drawing.Color.White;
            this.btnBuscarProveedorOC.Location = new System.Drawing.Point(634, 22);
            this.btnBuscarProveedorOC.Name = "btnBuscarProveedorOC";
            this.btnBuscarProveedorOC.Size = new System.Drawing.Size(30, 23);
            this.btnBuscarProveedorOC.TabIndex = 31;
            this.btnBuscarProveedorOC.Text = "...";
            this.btnBuscarProveedorOC.UseVisualStyleBackColor = false;
            this.btnBuscarProveedorOC.Click += new System.EventHandler(this.btnBuscarProveedorOC_Click);
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(274, 27);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(81, 15);
            this.lblNombreCliente.TabIndex = 30;
            this.lblNombreCliente.Text = "Razón social:";
            // 
            // txtRazonSocialProveedorOC
            // 
            this.txtRazonSocialProveedorOC.BackColor = System.Drawing.SystemColors.Control;
            this.txtRazonSocialProveedorOC.Enabled = false;
            this.txtRazonSocialProveedorOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocialProveedorOC.Location = new System.Drawing.Point(374, 23);
            this.txtRazonSocialProveedorOC.Name = "txtRazonSocialProveedorOC";
            this.txtRazonSocialProveedorOC.ReadOnly = true;
            this.txtRazonSocialProveedorOC.Size = new System.Drawing.Size(247, 21);
            this.txtRazonSocialProveedorOC.TabIndex = 29;
            // 
            // txtRUCProveedorOC
            // 
            this.txtRUCProveedorOC.BackColor = System.Drawing.SystemColors.Control;
            this.txtRUCProveedorOC.Enabled = false;
            this.txtRUCProveedorOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRUCProveedorOC.Location = new System.Drawing.Point(106, 23);
            this.txtRUCProveedorOC.Name = "txtRUCProveedorOC";
            this.txtRUCProveedorOC.ReadOnly = true;
            this.txtRUCProveedorOC.Size = new System.Drawing.Size(152, 21);
            this.txtRUCProveedorOC.TabIndex = 28;
            // 
            // lblDNICliente
            // 
            this.lblDNICliente.AutoSize = true;
            this.lblDNICliente.BackColor = System.Drawing.Color.Transparent;
            this.lblDNICliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNICliente.Location = new System.Drawing.Point(28, 27);
            this.lblDNICliente.Name = "lblDNICliente";
            this.lblDNICliente.Size = new System.Drawing.Size(36, 15);
            this.lblDNICliente.TabIndex = 27;
            this.lblDNICliente.Text = "RUC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Estado:";
            // 
            // rbEnProceso
            // 
            this.rbEnProceso.AutoSize = true;
            this.rbEnProceso.Location = new System.Drawing.Point(180, 95);
            this.rbEnProceso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbEnProceso.Name = "rbEnProceso";
            this.rbEnProceso.Size = new System.Drawing.Size(95, 17);
            this.rbEnProceso.TabIndex = 33;
            this.rbEnProceso.TabStop = true;
            this.rbEnProceso.Text = "EN PROCESO";
            this.rbEnProceso.UseVisualStyleBackColor = true;
            // 
            // rbCancelado
            // 
            this.rbCancelado.AutoSize = true;
            this.rbCancelado.Location = new System.Drawing.Point(284, 95);
            this.rbCancelado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCancelado.Name = "rbCancelado";
            this.rbCancelado.Size = new System.Drawing.Size(90, 17);
            this.rbCancelado.TabIndex = 34;
            this.rbCancelado.TabStop = true;
            this.rbCancelado.Text = "CANCELADO";
            this.rbCancelado.UseVisualStyleBackColor = true;
            // 
            // rbRecibido
            // 
            this.rbRecibido.AutoSize = true;
            this.rbRecibido.Location = new System.Drawing.Point(380, 95);
            this.rbRecibido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbRecibido.Name = "rbRecibido";
            this.rbRecibido.Size = new System.Drawing.Size(76, 17);
            this.rbRecibido.TabIndex = 35;
            this.rbRecibido.TabStop = true;
            this.rbRecibido.Text = "RECIBIDO";
            this.rbRecibido.UseVisualStyleBackColor = true;
            // 
            // btnQuitarProveedor
            // 
            this.btnQuitarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarProveedor.Location = new System.Drawing.Point(670, 22);
            this.btnQuitarProveedor.Name = "btnQuitarProveedor";
            this.btnQuitarProveedor.Size = new System.Drawing.Size(53, 23);
            this.btnQuitarProveedor.TabIndex = 36;
            this.btnQuitarProveedor.Text = "Quitar";
            this.btnQuitarProveedor.UseVisualStyleBackColor = true;
            this.btnQuitarProveedor.Click += new System.EventHandler(this.btnQuitarProveedor_Click);
            this.btnQuitarProveedor.MouseLeave += new System.EventHandler(this.btnQuitarProveedor_MouseLeave);
            this.btnQuitarProveedor.MouseHover += new System.EventHandler(this.btnQuitarProveedor_MouseHover);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(106, 95);
            this.rbTodos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(63, 17);
            this.rbTodos.TabIndex = 37;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "TODOS";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // lblMensajeQuitar
            // 
            this.lblMensajeQuitar.AutoSize = true;
            this.lblMensajeQuitar.Location = new System.Drawing.Point(38, 365);
            this.lblMensajeQuitar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMensajeQuitar.Name = "lblMensajeQuitar";
            this.lblMensajeQuitar.Size = new System.Drawing.Size(0, 13);
            this.lblMensajeQuitar.TabIndex = 38;
            // 
            // pbNotificacion
            // 
            this.pbNotificacion.Image = ((System.Drawing.Image)(resources.GetObject("pbNotificacion.Image")));
            this.pbNotificacion.Location = new System.Drawing.Point(9, 359);
            this.pbNotificacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbNotificacion.Name = "pbNotificacion";
            this.pbNotificacion.Size = new System.Drawing.Size(22, 24);
            this.pbNotificacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNotificacion.TabIndex = 54;
            this.pbNotificacion.TabStop = false;
            // 
            // frmBuscarOrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 389);
            this.Controls.Add(this.pbNotificacion);
            this.Controls.Add(this.lblMensajeQuitar);
            this.Controls.Add(this.rbTodos);
            this.Controls.Add(this.btnQuitarProveedor);
            this.Controls.Add(this.rbRecibido);
            this.Controls.Add(this.rbCancelado);
            this.Controls.Add(this.rbEnProceso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarProveedorOC);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.txtRazonSocialProveedorOC);
            this.Controls.Add(this.txtRUCProveedorOC);
            this.Controls.Add(this.lblDNICliente);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpfin);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dgvOrdenesCompra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmBuscarOrdenDeCompra";
            this.Text = "frmBuscarOrdenDeCompra";
            this.Load += new System.EventHandler(this.frmBuscarOrdenDeCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpfin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.DataGridView dgvOrdenesCompra;
        private System.Windows.Forms.Button btnBuscarProveedorOC;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtRazonSocialProveedorOC;
        private System.Windows.Forms.TextBox txtRUCProveedorOC;
        private System.Windows.Forms.Label lblDNICliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbEnProceso;
        private System.Windows.Forms.RadioButton rbCancelado;
        private System.Windows.Forms.RadioButton rbRecibido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn s;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button btnQuitarProveedor;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Label lblMensajeQuitar;
        private System.Windows.Forms.PictureBox pbNotificacion;
    }
}