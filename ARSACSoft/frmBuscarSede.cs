

using ARSACSoft.SedesWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarSede : Form
    {
        private SedesWSClient daoSede;
        private sede sedeSeleccionada;


        public frmBuscarSede()
        {
            InitializeComponent();
            daoSede = new SedesWSClient();

            dgvSedes.AutoGenerateColumns = false;
            dgvSedes.DataSource = daoSede.listarSedes();

        }

        public sede SedeSeleccionada { get => sedeSeleccionada; set => sedeSeleccionada = value; }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            if (dgvSedes.CurrentRow != null)
            {
                sedeSeleccionada = (sede)dgvSedes.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }

        }

        private void dgvSedes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            sede sede = (sede)dgvSedes.Rows[e.RowIndex].DataBoundItem;

            dgvSedes.Rows[e.RowIndex].Cells[0].Value =
                sede.idSede.ToString();
            dgvSedes.Rows[e.RowIndex].Cells[1].Value =
                sede.direccion;
            dgvSedes.Rows[e.RowIndex].Cells[2].Value =
                sede.esPrincipal ? "SI" : "NO";
            dgvSedes.Rows[e.RowIndex].Cells[3].Value =
                sede.correo;
        }
    }
}
