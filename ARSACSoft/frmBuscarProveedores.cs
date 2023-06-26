using ARSACSoft.ProveedoresWS;
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
    public partial class frmBuscarProveedores : Form
    {
        ProveedoresWSClient daoProveedores;

        proveedor _proveedorSeleccionado;
        public proveedor ProveedorSeleccionado { get => _proveedorSeleccionado; set => _proveedorSeleccionado = value; }

        public frmBuscarProveedores()
        {
            InitializeComponent();
            daoProveedores = new ProveedoresWSClient();
            dgvProveedores.AutoGenerateColumns = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProveedores.DataSource = daoProveedores.listarProveedoresXNombreXRUC(txtNombreRUC.Text);

            }
            catch (Exception ex)
            {
                // Manejo de excepciones del servicio web
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            if (dgvProveedores.CurrentRow != null)
            {
                _proveedorSeleccionado = (ProveedoresWS.proveedor)dgvProveedores.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Manejo de error cuando no hay fila seleccionada
            }
        }

        private void dgvProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                proveedor proveed = (proveedor)dgvProveedores.Rows[e.RowIndex].DataBoundItem;
                dgvProveedores.Rows[e.RowIndex].Cells[0].Value = proveed.idProveedor;
                dgvProveedores.Rows[e.RowIndex].Cells[1].Value = proveed.nombre;
                dgvProveedores.Rows[e.RowIndex].Cells[2].Value = proveed.direccion;
                dgvProveedores.Rows[e.RowIndex].Cells[3].Value = proveed.RUC;
                dgvProveedores.Rows[e.RowIndex].Cells[4].Value = proveed.telefono;
                        }
            catch (Exception ex)
            {

            }
        }
    }
}
