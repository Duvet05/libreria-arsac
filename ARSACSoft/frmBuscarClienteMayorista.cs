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
    public partial class frmBuscarClienteMayorista : Form
    {
        private RRHHWSClient daoRRHH;
        private clienteMayorista clienteMayoristaSeleccionado;

        public frmBuscarClienteMayorista()
        {
            InitializeComponent();
            dgvClientes.AutoGenerateColumns = false;
            daoRRHH = new RRHHWSClient();
        }

        public clienteMayorista ClienteMayoristaSeleccionado { get => clienteMayoristaSeleccionado; set => clienteMayoristaSeleccionado = value; }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreDNI.Text))
            {
                dgvClientes.DataSource = daoRRHH.listarClientesMayoristasPorNombreDNI(txtNombreDNI.Text);
            }
            else
            {
                MessageBox.Show("Por favor, introduzca el nombre o DNI del cliente para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
