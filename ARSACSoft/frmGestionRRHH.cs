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
    public partial class frmGestionRRHH : Form
    {
        private Estado estadoEmpleado;
        private empleado empleado;
        private RRHHWSClient daoRRHH;

        public frmGestionRRHH()
        {
            InitializeComponent();

            estadoEmpleado = Estado.Inicial;
            establecerEstadoFormularioEmpleado();

            daoRRHH = new RRHHWSClient();

            cboTipoDeEmpleado.ValueMember = "idTipoDeEmpleado";
            cboTipoDeEmpleado.DisplayMember = "descripcion";

            cboTipoDeEmpleado.DataSource = daoRRHH.listarTiposDeEmpleados();

            limpiarComponentesEmpleado();
        }

        public void establecerEstadoFormularioEmpleado()
        {
            switch (estadoEmpleado)
            {
                case Estado.Inicial:
                    btnNuevoEmpleado.Enabled = true;
                    btnCancelarEmpleado.Enabled = false;
                    btnBuscarEmpleado.Enabled = true;
                    btnModificarEmpleado.Enabled = false;
                    btnEliminarEmpleado.Enabled = false;
                    
                    txtIDEmpleado.Enabled = false;
                    txtDNIEmpleado.Enabled = false;
                    txtNombreEmpleado.Enabled = false;
                    txtApellidoEmpleado.Enabled = false;
                    txtTelefonoEmpleado.Enabled = false;
                    dtpFechaContratacion.Enabled = false;
                    cboTipoDeEmpleado.Enabled = false;
                    txtCorreoEmpleado.Enabled = false;
                    txtSalario.Enabled = false;
                    txtDireccion.Enabled = false;

                    txtUsuario.Enabled = false;
                    txtContrasenha.Enabled = false;
                    btnBuscarSede.Enabled = false;

                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevoEmpleado.Enabled = false;
                    btnGuardarEmpleado.Enabled = true;
                    btnBuscarEmpleado.Enabled = false;
                    btnModificarEmpleado.Enabled = false;
                    btnEliminarEmpleado.Enabled = false;
                    btnCancelarEmpleado.Enabled = true;

                    txtIDEmpleado.Enabled = true;
                    txtDNIEmpleado.Enabled = true;
                    txtNombreEmpleado.Enabled = true;
                    txtTelefonoEmpleado.Enabled = true;
                    txtApellidoEmpleado.Enabled = true;
                    dtpFechaContratacion.Enabled = true;
                    cboTipoDeEmpleado.Enabled = true;
                    txtCorreoEmpleado.Enabled = true;
                    txtSalario.Enabled = true;
                    txtDireccion.Enabled = true;
                    btnBuscarSede.Enabled = true;

                    txtUsuario.Enabled = true;
                    txtContrasenha.Enabled = true;
                    txtDireccionSede.Enabled = true;

                    break;
                case Estado.Buscar:
                    btnNuevoEmpleado.Enabled = false;
                    btnGuardarEmpleado.Enabled = false;
                    btnBuscarEmpleado.Enabled = false;
                    btnModificarEmpleado.Enabled = true;
                    btnEliminarEmpleado.Enabled = true;
                    btnCancelarEmpleado.Enabled = true;

                    txtIDEmpleado.Enabled = false;
                    txtDNIEmpleado.Enabled = false;
                    txtNombreEmpleado.Enabled = false;
                    txtApellidoEmpleado.Enabled = false;
                    txtTelefonoEmpleado.Enabled = false;
                    dtpFechaContratacion.Enabled = false;
                    cboTipoDeEmpleado.Enabled = false;
                    txtCorreoEmpleado.Enabled = false;
                    txtSalario.Enabled = false;
                    txtDireccion.Enabled = false;
                    btnBuscarSede.Enabled = false;

                    txtUsuario.Enabled = false;
                    txtContrasenha.Enabled = false;
                    txtDireccionSede.Enabled = false;
                    break;
            }
        }
        public void limpiarComponentesEmpleado()
        {
            txtIDEmpleado.Text = "";
            txtDNIEmpleado.Text = "";
            txtNombreEmpleado.Text = "";
            txtApellidoEmpleado.Text = "";
            txtTelefonoEmpleado.Text = "";
            dtpFechaContratacion.Value = DateTime.Now;
            cboTipoDeEmpleado.SelectedIndex = -1;
            txtCorreoEmpleado.Text = "";
            txtSalario.Text = "";
            txtDireccion.Text = "";

            txtUsuario.Text = "";
            txtContrasenha.Text = "";
            txtDireccionSede.Text = "";
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            estadoEmpleado = Estado.Nuevo;
            limpiarComponentesEmpleado();
            establecerEstadoFormularioEmpleado();

            empleado = new empleado();
            empleado.sede = new sede();

        }

        private void btnBuscarSede_Click(object sender, EventArgs e)
        {
            frmBuscarSede frm = new frmBuscarSede();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                
                empleado.sede.idSede = frm.SedeSeleccionada.idSede;
                txtDireccionSede.Text = frm.SedeSeleccionada.direccion;


            }

        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleados frm = new frmBuscarEmpleados();

            if (frm.ShowDialog()  == DialogResult.OK)
            {
                empleado = frm.EmpleadoSeleccionado;


                txtIDEmpleado.Text = empleado.idPersona.ToString();
                txtDNIEmpleado.Text = empleado.DNI;
                txtNombreEmpleado.Text = empleado.nombre;
                txtApellidoEmpleado.Text = empleado.apellidos;
                txtTelefonoEmpleado.Text = empleado.telefono;
                dtpFechaContratacion.Value = empleado.fechaContratacion;
                cboTipoDeEmpleado.SelectedValue = empleado.tipo.idTipoDeEmpleado;
                txtCorreoEmpleado.Text = empleado.correo;
                txtSalario.Text = empleado.salario.ToString();
                txtDireccion.Text = empleado.direccion;

                txtUsuario.Text = empleado.usuario;
                txtContrasenha.Text = empleado.contrasenha;
                txtDireccionSede.Text = empleado.sede.direccion;

                estadoEmpleado = Estado.Buscar;
                establecerEstadoFormularioEmpleado();

            }



        }

        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            empleado.nombre = txtNombreEmpleado.Text;
            empleado.apellidos = txtApellidoEmpleado.Text;
            empleado.DNI = txtDNIEmpleado.Text;
            empleado.correo = txtCorreoEmpleado.Text;
            empleado.telefono = txtTelefonoEmpleado.Text;

            empleado.tipo = new tipoDeEmpleado();

            empleado.tipo.idTipoDeEmpleado = (int)cboTipoDeEmpleado.SelectedValue;

            empleado.fechaContratacion = dtpFechaContratacion.Value;
            empleado.fechaContratacionSpecified = true;

            empleado.salario = Double.Parse(txtSalario.Text);
            empleado.direccion = txtDireccion.Text;
            empleado.usuario = txtUsuario.Text;
            empleado.contrasenha = txtContrasenha.Text;

            if (estadoEmpleado == Estado.Nuevo)
            {
                int resultado = daoRRHH.insertarEmpleado(empleado);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha registrado con éxito", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIDEmpleado.Text = resultado.ToString();
                    estadoEmpleado = Estado.Inicial;
                    establecerEstadoFormularioEmpleado();
                }
                else
                    MessageBox.Show("Ha ocurrido un error con el registro", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (estadoEmpleado == Estado.Modificar)
            {
                int resultado = daoRRHH.modificarEmpleado(empleado);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha modificado con éxito", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoEmpleado = Estado.Inicial;
                    establecerEstadoFormularioEmpleado();
                }
                else
                    MessageBox.Show("Ha ocurrido un error con la modificación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            estadoEmpleado = Estado.Modificar;
            establecerEstadoFormularioEmpleado();
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            DialogResult resultadoInteraccion = MessageBox.Show("¿Está seguro de que desea eliminar a este empleado", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultadoInteraccion == DialogResult.Yes)
            {
                int resultado = daoRRHH.eliminarEmpleado(empleado.idPersona);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoEmpleado = Estado.Inicial;
                    establecerEstadoFormularioEmpleado();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al momento de eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelarEmpleado_Click(object sender, EventArgs e)
        {
            estadoEmpleado = Estado.Inicial;
            establecerEstadoFormularioEmpleado();
            limpiarComponentesEmpleado();
        }

        private void gbDatosEmpleado_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtIDEmpleado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
