using ARSACSoft.RRHHWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarEmpleados : Form
    {
        private RRHHWSClient daoRRHH;
        private empleado empleadoSeleccionado;

        public frmBuscarEmpleados()
        {
            InitializeComponent();
            daoRRHH = new RRHHWSClient();
            dgvEmpleados.AutoGenerateColumns = false;
            
        }

        public empleado EmpleadoSeleccionado { get => empleadoSeleccionado; set => empleadoSeleccionado = value; }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = daoRRHH.listarEmpleadosPorNombreDNI(txtNombreDNI.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            empleadoSeleccionado = (empleado)dgvEmpleados.CurrentRow.DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }

        private void dgvEmpleados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            empleado empleado = (empleado)dgvEmpleados.Rows[e.RowIndex].DataBoundItem;

            dgvEmpleados.Rows[e.RowIndex].Cells[0].Value =
                empleado.idPersona.ToString();
            dgvEmpleados.Rows[e.RowIndex].Cells[1].Value =
                empleado.nombre + " " + empleado.apellidos;
            dgvEmpleados.Rows[e.RowIndex].Cells[2].Value =
                empleado.tipo.descripcion;
            dgvEmpleados.Rows[e.RowIndex].Cells[3].Value =
                empleado.sede.direccion;
            dgvEmpleados.Rows[e.RowIndex].Cells[4].Value =
                empleado.sede.esPrincipal ? "SI" : "NO";

        }
    }
}
