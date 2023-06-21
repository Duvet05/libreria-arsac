using ARSACSoft.SedeWS;
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
            var sedes = daoSede.listarSedes();

            if (sedes != null)
            {
                dgvSedes.DataSource = sedes;
            }
            else
            {

                // Maneja la situación en la que 'listarSedes()' devuelve null
            }
        }

        public sede SedeSeleccionada { get => sedeSeleccionada; set => sedeSeleccionada = value; }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvSedes.CurrentRow != null && dgvSedes.CurrentRow.DataBoundItem is sede)
            {
                sedeSeleccionada = (sede)dgvSedes.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Maneja la situación en la que no hay fila actual seleccionada o el elemento enlazado no es una 'sede'
            }
        }

        private void dgvSedes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSedes.Rows[e.RowIndex].DataBoundItem is sede sede)
            {
                dgvSedes.Rows[e.RowIndex].Cells[0].Value = sede.idSede.ToString();
                dgvSedes.Rows[e.RowIndex].Cells[1].Value = sede.direccion;
                dgvSedes.Rows[e.RowIndex].Cells[2].Value = sede.esPrincipal ? "SI" : "NO";
                dgvSedes.Rows[e.RowIndex].Cells[3].Value = sede.correo;
            }
            else
            {
                // Maneja la situación en la que el elemento enlazado no es una 'sede'
            }
        }
    }
}
