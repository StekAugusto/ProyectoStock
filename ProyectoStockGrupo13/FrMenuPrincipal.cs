using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoStockGrupo13
{
    public partial class FrMenuPrincipal : Form
    {
        public FrMenuPrincipal()
        {
            InitializeComponent();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pbMaximizar.Visible = false;
            pbRestaurar.Visible = true;
        }

        private void pbRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pbMaximizar.Visible = true;
            pbRestaurar.Visible = false;
        }

        private void btnConsultaYCRUD_Click(object sender, EventArgs e)
        {
            panelConsultaYCRUD.Visible = true;
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            panelConsultaYCRUD.Visible = false;
        }

        private void btnCRUD_Click(object sender, EventArgs e)
        {
            panelConsultaYCRUD.Visible = false;
        }
    }
}
