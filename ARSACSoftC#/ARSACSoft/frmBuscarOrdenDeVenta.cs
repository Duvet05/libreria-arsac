using ARSACSoft.VentasWS;
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
    public partial class frmBuscarOrdenDeVenta : Form
    {
        private VentasWSClient daoVentas;
        private ordenDeVenta ordenSeleccionada;
        private int _id_empleado;





        public ordenDeVenta OrdenSeleccionada { get => ordenSeleccionada; set => ordenSeleccionada = value; }

        public frmBuscarOrdenDeVenta(int id_empleado)
        {
            InitializeComponent();

            daoVentas = new VentasWSClient();

            dgvOrdenes.AutoGenerateColumns = false;

            _id_empleado = id_empleado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingList<ordenDeVenta> o =
                new BindingList<ordenDeVenta>(daoVentas.listarOrdenesDeVentaPorPeriodo(_id_empleado, dtpInicio.Value, dtpfin.Value).ToList());
            dgvOrdenes.DataSource = o;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            ordenSeleccionada = (ordenDeVenta)dgvOrdenes.CurrentRow.DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }

        private void dgvOrdenes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ordenDeVenta orden = (ordenDeVenta)dgvOrdenes.Rows[e.RowIndex].DataBoundItem;

            dgvOrdenes.Rows[e.RowIndex].Cells[0].Value = orden.idOrdenDeVenta;
            dgvOrdenes.Rows[e.RowIndex].Cells[1].Value = orden.fechaOrden.AddDays(1).ToString("dd/MM/yyyy");
            dgvOrdenes.Rows[e.RowIndex].Cells[2].Value = orden.fechaEnvio.Year == 1 ? "" : orden.fechaEnvio.AddDays(1).ToString("dd/MM/yyyy");
            dgvOrdenes.Rows[e.RowIndex].Cells[3].Value = orden.precioTotal;


        }
    }
}