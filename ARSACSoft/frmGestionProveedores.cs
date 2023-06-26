﻿using ARSACSoft.AlmacenWS;
using ARSACSoft.ProductosWS;
using ARSACSoft.Properties;
using ARSACSoft.ProveedoresWS;
using ARSACSoft.RRHHWS;
using ARSACSoft.SedeWS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ARSACSoft
{
    public partial class frmGestionProveedores : Form
    {
        private Estado _estadoPagProveedor;

        private ProveedoresWSClient daoProveedorWS;
        private ProveedoresWS.proveedor _proveedorSeleccionado;

        private RRHHWS.empleado _empleadoLogeado;

        public frmGestionProveedores(RRHHWS.empleado _empleadoLogeado)
        {
            InitializeComponent();

            daoProveedorWS = new ProveedoresWSClient();
            this._empleadoLogeado = _empleadoLogeado;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProveedoresWS.proveedor prov = new ProveedoresWS.proveedor();
            prov.direccion = txtDireccion.Text;
            prov.RUC = txtRUC.Text;
            prov.nombre = txtNombreProveedor.Text;
            prov.telefono = txtTelefono.Text;

            
            int resultado = daoProveedorWS.insertarProveedor(prov);

            if (resultado != 0)
            {
                MessageBox.Show("Se ha agregado el proveedor correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _estadoPagProveedor = Estado.Inicial;
                establecerEstadoFormularioProveedor();
                //txtIDProducto.Text = resultado.ToString();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al momento de guardar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _estadoPagProveedor = Estado.Inicial;
            LimpiarComponentes();
            establecerEstadoFormularioProveedor();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _estadoPagProveedor = Estado.Nuevo;
            LimpiarComponentes();
            establecerEstadoFormularioProveedor();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarProveedores frmBuscarProvee = new frmBuscarProveedores();
            if (frmBuscarProvee.ShowDialog() == DialogResult.OK)
            {
                _proveedorSeleccionado = frmBuscarProvee.ProveedorSeleccionado;

                txtDireccion.Text = _proveedorSeleccionado.direccion;
                txtNombreProveedor.Text = _proveedorSeleccionado.nombre;
                txtRUC.Text = _proveedorSeleccionado.RUC;
                txtTelefono.Text = _proveedorSeleccionado.telefono;

                if (_proveedorSeleccionado.activo == true)
                    txtEstado.Text = "PROVEEDOR VIGENTE";
                else txtEstado.Text = "PROVEEDOR NO VIGENTE";

                _estadoPagProveedor = Estado.Buscar;
                establecerEstadoFormularioProveedor();
            }
        }
                
            

        public void establecerEstadoFormularioProveedor()
        {
            switch (_estadoPagProveedor)
            {
                case Estado.Inicial:
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtNombreProveedor.Enabled = false;
                    txtRUC.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtEstado.Enabled = false;

                    break;
                case Estado.Nuevo:
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtDireccion.ReadOnly = false;
                    txtNombreProveedor.Enabled = true;
                    txtNombreProveedor.ReadOnly = false;
                    txtRUC.Enabled = true;
                    txtRUC.ReadOnly = false;
                    txtTelefono.Enabled = true;
                    txtTelefono.ReadOnly = false;
                    txtEstado.Enabled = false;
                    txtEstado.ReadOnly = true;
                    break;
                case Estado.Buscar:
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    txtDireccion.Enabled = false;
                    txtNombreProveedor.Enabled = false;
                    txtRUC.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtEstado.Enabled = false;
                    break;
            }
        }

    
        public void LimpiarComponentes()
        {
            txtDireccion.Text = "";
            txtRUC.Text = "";
            txtNombreProveedor.Text = "";
            txtTelefono.Text = "";
            txtEstado.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _estadoPagProveedor = Estado.Inicial;
            LimpiarComponentes();
            establecerEstadoFormularioProveedor();
        }
    }
    }
