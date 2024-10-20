using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entidades.Cache;
using Entidades;

namespace ProyectoStockGrupo13
{
    public partial class FrMenuPrincipal : Form
    {
        public FrMenuPrincipal()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrMenuPrincipal_Load);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        

        private void FrMenuPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormHija(new FrInicio());
            LoadUserData();

            // PERMISOS BOTONES
            // --------------------------------------------------------------------------------
            if(CacheLogin.TipoEmpleado == PosicionRol.Operador)
            {
                btnActualizarEmpleado.Enabled = false;
                btnConsultaYCRUD.Enabled = false;
            }
            if(CacheLogin.TipoEmpleado == PosicionRol.Auditor)
            {
                btnActualizarEmpleado.Enabled=false;
            }
            // ---------------------------------------------------------------------------------
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
            AbrirFormHija(new FrConsultarMovimientos());
        }

        private void btnCRUD_Click(object sender, EventArgs e)
        {
            panelConsultaYCRUD.Visible = false;
            AbrirFormHija(new FrCRUDProductos());
        }

        // FUNCION PARA ABRIR FORMULARIOS HIJAS
        private void AbrirFormHija(Form formHija)
        {
            this.panelContenedor.Controls.Clear();

            // Configuramos el formulario hijo
            formHija.TopLevel = false;
            formHija.Dock = DockStyle.Fill;

            // Agregamos el formulario al panel
            this.panelContenedor.Controls.Add(formHija);
            this.panelContenedor.Tag = formHija;

            // Mostramos el formulario
            formHija.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FrInicio());
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FrVenta());
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FrCompra());
        }

        private void btnActualizarEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new FrActualizarEmpleado());
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if(panelMenu.Width == 220)
            {
                panelMenu.Width = 50;
            }
            else
            {
                panelMenu.Width = 220;
            }
        }

        private void PanelSuperiorXYZ_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estas seguro de que desea cerrar sesion?", "WARNING", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            this.Close();
        }

        private void LoadUserData()
        {
            lblNombre.Text = CacheLogin.NombreEmpleado + ", "+CacheLogin.ApellidoEmpleado;
            lblRol.Text = CacheLogin.TipoEmpleado;
            lblUsuario.Text = CacheLogin.UsuarioEmpleado;
        }
    }
}
