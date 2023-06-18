using ARSACSoft.RRHHWS;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmIniciarSesion : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        RRHHWSClient daoRRHWSClient = new RRHHWSClient();
        cuentaUsuario _cuenta;
        public frmIniciarSesion()
        {
            InitializeComponent();
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            _cuenta = new cuentaUsuario();
            _cuenta.username = txtUsuario.Text.Trim();
            _cuenta.password = txtContrasenha.Text;
            int resultado = daoRRHWSClient.verificarCuenta(_cuenta);

            if (resultado == 0)
            {
                MessageBox.Show("Las credenciales no son correctas", "Ups",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                empleado empleadoLogeado = daoRRHWSClient.obtenerEmpleadoPorID(resultado);

                frmPrincipal formPrincipal = new frmPrincipal(empleadoLogeado);
                this.Hide();
                //Verificamos roles
                
                if (empleadoLogeado.tipo.descripcion == "RECURSOS HUMANOS")
                {
                    formPrincipal.BtnPedidos.Visible = false;
                    formPrincipal.BtnAlmacen.Visible = false;
                    formPrincipal.BtnProveedores.Visible = false;
                    //formPrincipal.BtnSede.Visible = false;
                    formPrincipal.BtnContabilidad.Visible = false;
                    //formPrincipal.BtnRRHH.Visible = false;
                    //formPrincipal.BtnReportes.Visible = false;
                }
                if (empleadoLogeado.tipo.descripcion == "VENTAS")
                {
                    //formPrincipal.BtnPedidos.Visible = false;
                    formPrincipal.BtnAlmacen.Visible = false;
                    formPrincipal.BtnProveedores.Visible = false;
                    formPrincipal.BtnSede.Visible = false;
                    formPrincipal.BtnContabilidad.Visible = false;
                    formPrincipal.BtnRRHH.Visible = false;
                    //formPrincipal.BtnReportes.Visible = false;
                }

                if (empleadoLogeado.tipo.descripcion == "ALMACEN")
                {
                    formPrincipal.BtnPedidos.Visible = false;
                    //formPrincipal.BtnAlmacen.Visible = false;
                    //formPrincipal.BtnProveedores.Visible = false;
                    //formPrincipal.BtnSede.Visible = false;
                    formPrincipal.BtnContabilidad.Visible = false;
                    formPrincipal.BtnRRHH.Visible = false;
                    formPrincipal.BtnReportes.Visible = false;
                }
                if (empleadoLogeado.tipo.descripcion == "LOGISTICA")
                {
                    formPrincipal.BtnPedidos.Visible = false;
                    formPrincipal.BtnAlmacen.Visible = false;
                    //formPrincipal.BtnProveedores.Visible = false;
                    //formPrincipal.BtnSede.Visible = false;
                    formPrincipal.BtnContabilidad.Visible = false;
                    //formPrincipal.BtnRRHH.Visible = false;
                    //formPrincipal.BtnReportes.Visible = false;
                }
                if (empleadoLogeado.tipo.descripcion == "CONTABILIDAD")
                {
                    formPrincipal.BtnPedidos.Visible = false;
                    formPrincipal.BtnAlmacen.Visible = false;
                    formPrincipal.BtnProveedores.Visible = false;
                    formPrincipal.BtnSede.Visible = false;
                    formPrincipal.BtnContabilidad.Visible = false;
                    //formPrincipal.BtnRRHH.Visible = false;
                    //formPrincipal.BtnReportes.Visible = false;
                }



                formPrincipal.ShowDialog();
                txtUsuario.Text = "";
                txtContrasenha.Text = "";
                this.Visible = true;
            }
        }

        private void frmIniciarSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void txtContrasenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                _cuenta = new cuentaUsuario();
                _cuenta.username = txtUsuario.Text.Trim();
                _cuenta.password = txtContrasenha.Text;
                int resultado = daoRRHWSClient.verificarCuenta(_cuenta);

                if (resultado == 0)
                {
                    MessageBox.Show("Las credenciales no son correctas", "Ups",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    empleado empleadoLogeado = daoRRHWSClient.obtenerEmpleadoPorID(resultado);

                    frmPrincipal formPrincipal = new frmPrincipal(empleadoLogeado);
                    this.Hide();
                    //Verificamos roles

                    if (empleadoLogeado.tipo.descripcion == "RECURSOS HUMANOS")
                    {
                        formPrincipal.BtnPedidos.Visible = false;
                        formPrincipal.BtnAlmacen.Visible = false;
                        formPrincipal.BtnProveedores.Visible = false;
                        //formPrincipal.BtnSede.Visible = false;
                        formPrincipal.BtnContabilidad.Visible = false;
                        //formPrincipal.BtnRRHH.Visible = false;
                        //formPrincipal.BtnReportes.Visible = false;
                    }
                    if (empleadoLogeado.tipo.descripcion == "VENTAS")
                    {
                        //formPrincipal.BtnPedidos.Visible = false;
                        formPrincipal.BtnAlmacen.Visible = false;
                        formPrincipal.BtnProveedores.Visible = false;
                        formPrincipal.BtnSede.Visible = false;
                        formPrincipal.BtnContabilidad.Visible = false;
                        formPrincipal.BtnRRHH.Visible = false;
                        //formPrincipal.BtnReportes.Visible = false;
                    }

                    if (empleadoLogeado.tipo.descripcion == "ALMACEN")
                    {
                        formPrincipal.BtnPedidos.Visible = false;
                        //formPrincipal.BtnAlmacen.Visible = false;
                        //formPrincipal.BtnProveedores.Visible = false;
                        //formPrincipal.BtnSede.Visible = false;
                        formPrincipal.BtnContabilidad.Visible = false;
                        formPrincipal.BtnRRHH.Visible = false;
                        formPrincipal.BtnReportes.Visible = false;
                    }
                    if (empleadoLogeado.tipo.descripcion == "LOGISTICA")
                    {
                        formPrincipal.BtnPedidos.Visible = false;
                        formPrincipal.BtnAlmacen.Visible = false;
                        //formPrincipal.BtnProveedores.Visible = false;
                        //formPrincipal.BtnSede.Visible = false;
                        formPrincipal.BtnContabilidad.Visible = false;
                        //formPrincipal.BtnRRHH.Visible = false;
                        //formPrincipal.BtnReportes.Visible = false;
                    }
                    if (empleadoLogeado.tipo.descripcion == "CONTABILIDAD")
                    {
                        formPrincipal.BtnPedidos.Visible = false;
                        formPrincipal.BtnAlmacen.Visible = false;
                        formPrincipal.BtnProveedores.Visible = false;
                        formPrincipal.BtnSede.Visible = false;
                        formPrincipal.BtnContabilidad.Visible = false;
                        //formPrincipal.BtnRRHH.Visible = false;
                        //formPrincipal.BtnReportes.Visible = false;
                    }



                    formPrincipal.ShowDialog();
                    txtUsuario.Text = "";
                    txtContrasenha.Text = "";
                    this.Visible = true;
                }
            }
        }
    }
}
