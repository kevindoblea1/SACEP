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
    public partial class frmReporteUsuarios : Form
    {
        ConectarTbUsuarios dbUsuarios = new ConectarTbUsuarios();
        public frmReporteUsuarios()
        {
            InitializeComponent();
        }

        private void frmReporteUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                dgvUsuarios.DataSource = dbUsuarios.GetUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
