using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexion;
namespace SACEP
{
    public partial class frmAdminUsusarios : Form
    {
        ConectarTbCarreras dbCarreras = new ConectarTbCarreras();
        ConectarTbUsuarios dbUsuario = new ConectarTbUsuarios();
        public frmAdminUsusarios()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPass.Clear();
            txtIdentidad.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            cbGenero.SelectedIndex = 0;
            cbRol.SelectedIndex = 0;
            cbGenero.Text = "";
            cbRol.Text = "";
            txtCodigo.Focus();
        }
        private void frmAdminUsusarios_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    string pass = txtPass.Text;
                    string nombre = txtNombre.Text;
                    string codigo = txtCodigo.Text;
                    string id = txtIdentidad.Text;
                    string genero = cbGenero.Text;
                    string rol = cbRol.Text;
                    string correo = txtCorreo.Text;
                    string telefono = txtTelefono.Text;


                    dbUsuario.GuardarUsuario(codigo,
                                             pass,
                                             id,
                                             nombre,
                                             genero,
                                             correo,
                                             telefono,
                                             rol);
                    MessageBox.Show("Usuario ingresado a la DB...!");
                    Limpiar();
                  }else
                {
                    MessageBox.Show("Dejo el codigo vacio, por favor llene los datos antes de guardar");
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    List<Usuario> lista_usuarios = new List<Usuario>();
                    lista_usuarios = dbUsuario.Encontrar(txtCodigo.Text);
                    if (lista_usuarios.Count > 0)
                    {
                        MessageBox.Show("Empleado encontrado en DB...!");
                        foreach (var lu in lista_usuarios)
                        {
                            txtCodigo.Text = lu.codigo_usuario;
                            txtPass.Text = lu.password;
                            txtIdentidad.Text = lu.identidad;
                            txtNombre.Text = lu.nombre_usuario;
                            cbGenero.Text = lu.genero;
                            txtCorreo.Text = lu.correo_usuario;
                            txtTelefono.Text = lu.telefono;
                            cbRol.Text= lu.rol;
                        }
                        btnActualizar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnGuardar.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("No hay un usuario con ese codigo, Cree usuario nuevo");
                        txtNombre.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Coloque un codigo a buscar...!");
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    string pass = txtPass.Text;
                    string nombre = txtNombre.Text;
                    string codigo = txtCodigo.Text;
                    string id = txtIdentidad.Text;
                    string genero = cbGenero.Text;
                    string rol = cbRol.Text;
                    string correo = txtCorreo.Text;
                    string telefono = txtTelefono.Text;
                    dbUsuario.ActualizarUsuario(codigo,
                                             pass,
                                             id,
                                             nombre,
                                             genero,
                                             correo,
                                             telefono,
                                             rol);
                    MessageBox.Show("Usuario Actualizado...!!");
                    Limpiar();
                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Ingrese codigo para eliminar...!!");
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
