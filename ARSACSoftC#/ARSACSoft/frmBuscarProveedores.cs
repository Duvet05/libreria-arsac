using ARSACSoft.ProveedoresWS;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarProveedores : Form
    {
        private ProveedoresWSClient daoProveedores;
        private proveedor _proveedorSeleccionado;

        public proveedor ProveedorSeleccionado
        {
            get => _proveedorSeleccionado;
            set => _proveedorSeleccionado = value;
        }

        public frmBuscarProveedores()
        {
            InitializeComponent();
            daoProveedores = new ProveedoresWSClient();
            dgvProveedores.AutoGenerateColumns = false;
            // dgvProveedores.DataSource = daoProveedores.listarProveedoresXNombreXRUC("");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreRUC = txtNombreRUC.Text.Trim();
                dgvProveedores.DataSource = daoProveedores.listarProveedoresXNombreXRUC(nombreRUC);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones del servicio web
                MessageBox.Show("Error al buscar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow != null)
            {
                _proveedorSeleccionado = (proveedor)dgvProveedores.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Manejo de error cuando no hay fila seleccionada
                MessageBox.Show("No se ha seleccionado ningún proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvProveedores.Rows.Count)
                {
                    proveedor prov = (proveedor)dgvProveedores.Rows[e.RowIndex].DataBoundItem;
                    dgvProveedores.Rows[e.RowIndex].Cells[0].Value = prov.idProveedor;
                    dgvProveedores.Rows[e.RowIndex].Cells[1].Value = prov.nombre;
                    dgvProveedores.Rows[e.RowIndex].Cells[2].Value = prov.direccion;
                    dgvProveedores.Rows[e.RowIndex].Cells[3].Value = prov.RUC;
                    dgvProveedores.Rows[e.RowIndex].Cells[4].Value = prov.telefono;
                    //dgvProveedores.Rows[e.RowIndex].Cells[5].Value = prov.activo;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones de formato de celda
                MessageBox.Show("Error al formatear la celda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
