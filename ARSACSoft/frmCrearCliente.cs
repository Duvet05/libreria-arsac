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
    public partial class frmCrearCliente : Form
    {


        public frmCrearCliente()
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //dgvProveedores.DataSource = daoProveedores.(txtNombreRUC.Text);

            }
            catch (Exception ex)
            {
                // Manejo de excepciones del servicio web
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void txtNombreRUC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
