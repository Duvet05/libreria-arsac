using ARSACSoft.RRHHWS;
using ARSACSoft.SedeWS;
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
    public partial class frmBuscarEmpleado : Form
    {
        private RRHHWebServiceClient daoEmpleado;
        private BindingList<empleado> sedes;
        private empleado empleadoSeleccionado;
        public frmBuscarEmpleado()
        {
            InitializeComponent();
            daoEmpleado = new RRHHWebServiceClient();

            dgvSedes.AutoGenerateColumns = false;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvSedes.CurrentRow != null)
            {
                empleadoSeleccionado = (empleado)dgvSedes.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }

        }

        public empleado SedeSeleccionada { get => empleadoSeleccionado; set => empleadoSeleccionado = value; }


        private void dgvSedes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            empleado sede = (empleado)dgvSedes.Rows[e.RowIndex].DataBoundItem;

            dgvSedes.Rows[e.RowIndex].Cells[0].Value =
                sede.nombre + ' ' + sede.apellidos;
            dgvSedes.Rows[e.RowIndex].Cells[1].Value =
                sede.direccion;
            dgvSedes.Rows[e.RowIndex].Cells[2].Value =
                sede.DNI;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvSedes.DataSource = daoEmpleado.listarporNombreDNI(textBox1.Text);
        }
    }
}
