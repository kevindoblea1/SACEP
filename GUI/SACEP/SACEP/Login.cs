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
    public partial class frmLogin : Form
    {
        ConectarTbUsuarios dbUsuario = new ConectarTbUsuarios();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtUsuario.Clear();
            txtPass.Clear();
            txtUsuario.Focus();
        }
        private bool ValidarCajas()
        {
            if (txtPass.Text == "" || txtUsuario.Text == "")
            {
                MessageBox.Show("Por favor ingrese un usuario y contraseña");
                return false;
            }
            else
                return true;
                
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCajas())
                {
                    string codigo = txtUsuario.Text;
                    string contra = txtPass.Text;
                    bool encontrado = false;
                    encontrado = dbUsuario.Validar(codigo, contra);
                    string rol = "";
                    if (encontrado)
                    {
                        rol = dbUsuario.ObtenerRol(codigo);
                        rol = rol.Replace(" ", "");
                        MessageBox.Show("Credenciales Correctas: Bienvenido!");
                        if (rol == "Administrador")
                        {
                            frmMenuAdmin ma = new frmMenuAdmin();
                            ma.Text = "Sistema de Administracion de Copias y Examenes | Bienvenido " + dbUsuario.ObtenerNombre(codigo);
                            ma.Show();
                            this.Hide();
                        }
                        else if (rol == "Maestro")
                        {
                            frmMenuMaestro ma = new frmMenuMaestro();
                            ma.Text = "Sistema de Administracion de Copias y Examenes | Bienvenido " + dbUsuario.ObtenerNombre(codigo);
                            this.Hide();
                        }
                        else if (rol == "Oficial Academico")
                        {
                            frmMenuOficial ma = new frmMenuOficial();
                            ma.Text = "Sistema de Administracion de Copias y Examenes | Bienvenido " + dbUsuario.ObtenerNombre(codigo);
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credenciales Incorrectas");
                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
