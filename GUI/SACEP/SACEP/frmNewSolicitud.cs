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
    public partial class frmNewSolicitud : Form
    {
        ConectarDbSolicitudes dbSolicitudes = new ConectarDbSolicitudes();
        public frmNewSolicitud()
        {
            InitializeComponent();
        }

        private void frmNewSolicitud_Load(object sender, EventArgs e)
        {
            int  soli = Convert.ToInt32(dbSolicitudes.UltimoID());
            soli+=1;
            txtCod.Text =Convert.ToString(soli);
        }
    }
}
