namespace ARSACSoft
{
    partial class frmBuscarEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarEmpleados));
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.IdEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SedePrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreDNI = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEmpleado,
            this.NombreCompleto,
            this.Tipo,
            this.Sede,
            this.SedePrincipal});
            this.dgvEmpleados.Location = new System.Drawing.Point(8, 42);
            this.dgvEmpleados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.RowHeadersVisible = false;
            this.dgvEmpleados.RowHeadersWidth = 62;
            this.dgvEmpleados.RowTemplate.Height = 28;
            this.dgvEmpleados.Size = new System.Drawing.Size(676, 256);
            this.dgvEmpleados.TabIndex = 0;
            this.dgvEmpleados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEmpleados_CellFormatting);
            // 
            // IdEmpleado
            // 
            this.IdEmpleado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IdEmpleado.HeaderText = "ID";
            this.IdEmpleado.MinimumWidth = 8;
            this.IdEmpleado.Name = "IdEmpleado";
            this.IdEmpleado.ReadOnly = true;
            this.IdEmpleado.Width = 43;
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.MinimumWidth = 8;
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 8;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Sede
            // 
            this.Sede.HeaderText = "Sede";
            this.Sede.MinimumWidth = 8;
            this.Sede.Name = "Sede";
            this.Sede.ReadOnly = true;
            // 
            // SedePrincipal
            // 
            this.SedePrincipal.HeaderText = "Sede Principal";
            this.SedePrincipal.MinimumWidth = 8;
            this.SedePrincipal.Name = "SedePrincipal";
            this.SedePrincipal.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese el nombre o DNI del empleado:";
            // 
            // txtNombreDNI
            // 
            this.txtNombreDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreDNI.Location = new System.Drawing.Point(236, 10);
            this.txtNombreDNI.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreDNI.Name = "txtNombreDNI";
            this.txtNombreDNI.Size = new System.Drawing.Size(173, 21);
            this.txtNombreDNI.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(414, 8);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(59, 25);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(576, 9);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(108, 23);
            this.btnSeleccionar.TabIndex = 4;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // frmBuscarEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 306);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNombreDNI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEmpleados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBuscarEmpleados";
            this.Text = "Buscar Empleados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreDNI;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sede;
        private System.Windows.Forms.DataGridViewTextBoxColumn SedePrincipal;
    }
}