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
    
    public partial class frmMenuAdmin : Form
    {
        private string GetRol;
        //recibe el valor ...
        public frmMenuAdmin(string rol)
        {
            InitializeComponent();
            //...y lo seteas en una variable de clase
            this.GetRol = rol;
        }

        ConectarTbUsuarios dbUsuarios = new ConectarTbUsuarios();
        public frmMenuAdmin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void carrerasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void solicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cerrarCesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin lg = new frmLogin();
                lg.Show();
                this.Hide();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminUsusarios le = new frmAdminUsusarios();
            le.MdiParent = this;
            le.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteUsuarios le = new frmReporteUsuarios();
                le.MdiParent = this;
                le.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void solicitudesPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void solicitudesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewSolicitud le = new frmNewSolicitud();
                le.MdiParent = this;
                le.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
