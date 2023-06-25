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
    public partial class frmBuscarOrdenDeAbastecimiento : Form
    {

        private SedesWSClient _daoSede;
        private ordenDeAbastecimiento _ordenSeleccionada;
        private int _idEmpleado;

        public frmBuscarOrdenDeAbastecimiento(int idEmpleado)
        {
            InitializeComponent();

            _daoSede = new SedesWSClient();

            _idEmpleado = idEmpleado;

            dgvOrdenes.AutoGenerateColumns = false;
        }

        public ordenDeAbastecimiento OrdenSeleccionada { get => _ordenSeleccionada; set => _ordenSeleccionada = value; }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (rbPendiente.Checked)
                estado = "Pendiente";
            if (rbEntregado.Checked)
                estado = "Entregado";
            if (rbCancelado.Checked)
                estado = "Cancelado";

            dgvOrdenes.DataSource =
                _daoSede.listarOrdenesDeAbastecimientoPorIdEmpleadoEstado(_idEmpleado, estado);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            _ordenSeleccionada = (ordenDeAbastecimiento)dgvOrdenes.CurrentRow.DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }

        private void dgvOrdenes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ordenDeAbastecimiento orden = (ordenDeAbastecimiento)dgvOrdenes.Rows[e.RowIndex].DataBoundItem;
            dgvOrdenes.Rows[e.RowIndex].Cells[0].Value =
                orden.idOrdenDeAbastecimiento;
            dgvOrdenes.Rows[e.RowIndex].Cells[1].Value =
                orden.sede.direccion;
            dgvOrdenes.Rows[e.RowIndex].Cells[2].Value =
                orden.fechaRegistro;
            dgvOrdenes.Rows[e.RowIndex].Cells[3].Value =
                orden.fechaEntrega;
            dgvOrdenes.Rows[e.RowIndex].Cells[4].Value =
                orden.fechaCancelacion;
            dgvOrdenes.Rows[e.RowIndex].Cells[5].Value =
                orden.estado;
        }
    }
}
