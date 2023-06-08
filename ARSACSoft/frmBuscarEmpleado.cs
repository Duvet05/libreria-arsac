using ARSACSoft.RRHHWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarEmpleado : Form
    {
        private RRHHWebServiceClient daoEmpleado;
        private empleado empleadoSeleccionado;

        public frmBuscarEmpleado()
        {
            InitializeComponent();
            daoEmpleado = new RRHHWebServiceClient();

            dgvEmpleados.AutoGenerateColumns = false;
            //dgvEmpleados.DataSource = daoEmpleado.listarporNombreDNI("12345");
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                empleadoSeleccionado = (empleado)dgvEmpleados.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }

        }

        public empleado EmpleadoSeleccionado { get => empleadoSeleccionado; set => empleadoSeleccionado = value; }


        private void dgvEmpleados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            empleado empleadito = (empleado)dgvEmpleados.Rows[e.RowIndex].DataBoundItem;

            dgvEmpleados.Rows[e.RowIndex].Cells[0].Value = empleadito.nombre + ' ' + empleadito.apellidos;
            dgvEmpleados.Rows[e.RowIndex].Cells[1].Value = empleadito.direccion;
            dgvEmpleados.Rows[e.RowIndex].Cells[2].Value = empleadito.DNI;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = daoEmpleado.listarporNombreDNI(textBox1.Text);
        }
    }
}
