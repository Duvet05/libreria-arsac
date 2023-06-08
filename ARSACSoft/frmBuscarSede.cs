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
        public frmBuscarSede()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            /*
            if (dgvSedes.CurrentRow != null)
            {
                empleadoSeleccionado = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
            */
            this.DialogResult = DialogResult.OK;
        }
    }
}
