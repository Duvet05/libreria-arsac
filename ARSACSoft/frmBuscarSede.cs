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
    public partial class frmBuscarSede : Form
    {
        private SedeWSClient daoSede;
        private BindingList<sede> sedes;
        private sede sedeSeleccionada;


        public frmBuscarSede()
        {
            InitializeComponent();
            daoSede = new SedeWSClient();

            dgvSedes.AutoGenerateColumns = false;
            dgvSedes.DataSource = daoSede.listarSedes();

        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvSedes.CurrentRow != null)
            {
                sedeSeleccionada = (sede)dgvSedes.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }

        }
        public sede SedeSeleccionada { get => sedeSeleccionada; set => sedeSeleccionada = value; }


        private void dgvSedes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            sede sede = (sede)dgvSedes.Rows[e.RowIndex].DataBoundItem;

            dgvSedes.Rows[e.RowIndex].Cells[0].Value =
                sede.idSede.ToString();
            dgvSedes.Rows[e.RowIndex].Cells[1].Value =
                sede.direccion;
            dgvSedes.Rows[e.RowIndex].Cells[2].Value =
                sede.esAlmacen ? "SI" : "NO";
            dgvSedes.Rows[e.RowIndex].Cells[3].Value =
                sede.correo;
        }
    }
}
