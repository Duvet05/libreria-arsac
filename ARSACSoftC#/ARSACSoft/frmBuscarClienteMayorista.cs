using ARSACSoft.RRHHWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarClienteMayorista : Form
    {
        private RRHHWSClient _daoRRHH;
        private clienteMayorista clienteMayoristaSeleccionado;

        public frmBuscarClienteMayorista()
        {
            InitializeComponent();
            dgvClientes.AutoGenerateColumns = false;
            _daoRRHH = new RRHHWSClient();

            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.DataSource = _daoRRHH.listarClientesMayoristasPorNombreDNI("");
            // Configurar el estilo de selección
        }

        public clienteMayorista ClienteMayoristaSeleccionado { get => clienteMayoristaSeleccionado; set => clienteMayoristaSeleccionado = value; }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var clientes = _daoRRHH.listarClientesMayoristasPorNombreDNI(txtNombreDNI.Text);
                if (clientes != null)
                {
                    dgvClientes.DataSource = clientes;
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
            if (dgvClientes.CurrentRow != null)
            {
                clienteMayoristaSeleccionado = dgvClientes.CurrentRow.DataBoundItem as clienteMayorista;
                if (clienteMayoristaSeleccionado != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila antes de presionar 'Seleccionar'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            clienteMayorista cliente = dgvClientes.Rows[e.RowIndex].DataBoundItem as clienteMayorista;

            if (cliente != null)
            {
                dgvClientes.Rows[e.RowIndex].Cells[0].Value = cliente.idPersona.ToString();
                dgvClientes.Rows[e.RowIndex].Cells[1].Value = cliente.DNI;
                dgvClientes.Rows[e.RowIndex].Cells[2].Value = cliente.nombre + " " + cliente.apellidos;
                dgvClientes.Rows[e.RowIndex].Cells[3].Value = cliente.razonSocial;
            }
        }
    }
}
