using ARSACSoft.RRHHWS;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarEmpleados : Form
    {
        private RRHHWSClient _daoRRHH;
        private empleado _empleadoSeleccionado;
        
        //llama
        X500DistinguishedName x;

        public frmBuscarEmpleados()
        {
            InitializeComponent();
            dgvEmpleados.AutoGenerateColumns = false;
            _daoRRHH = new RRHHWSClient();
            
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.DataSource = _daoRRHH.listarEmpleadosPorNombreDNI("");
        }

        public empleado EmpleadoSeleccionado { get => _empleadoSeleccionado; set => _empleadoSeleccionado = value; }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var empleados = _daoRRHH.listarEmpleadosPorNombreDNI(txtNombreDNI.Text);
                if (empleados != null)
                {
                    dgvEmpleados.DataSource = empleados;
                }
                else
                {
                    // Manejo de error cuando no hay datos
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones del servicio web
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                _empleadoSeleccionado = (empleado)dgvEmpleados.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Manejo de error cuando no hay fila seleccionada
            }
        }

        private void dgvEmpleados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEmpleados.Rows[e.RowIndex].DataBoundItem is empleado empleado)
            {
                dgvEmpleados.Rows[e.RowIndex].Cells[0].Value = empleado.idPersona.ToString();
                dgvEmpleados.Rows[e.RowIndex].Cells[1].Value = empleado.nombre + " " + empleado.apellidos;
                dgvEmpleados.Rows[e.RowIndex].Cells[2].Value = empleado.tipo.descripcion;
                dgvEmpleados.Rows[e.RowIndex].Cells[3].Value = empleado.sede.direccion;
                dgvEmpleados.Rows[e.RowIndex].Cells[4].Value = empleado.sede.esPrincipal ? "SI" : "NO";
            }
            else
            {
                // Manejo de error cuando el objeto enlazado no es un empleado
            }
        }
    }
}
