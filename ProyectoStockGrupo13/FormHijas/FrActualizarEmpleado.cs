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
    public partial class FrActualizarEmpleado : Form
    {
        public FrActualizarEmpleado()
        {
            InitializeComponent();
        }

        private void FrActualizarEmpleado_Load(object sender, EventArgs e)
        {

        }

        // Metodos para limpiar los text box o volver el palceholder al texto original
        // -------------------------------------------------------------------------------
        private void tbDNI_Enter(object sender, EventArgs e)
        {
            if (tbDNI.Text == "DNI")
            {
                tbDNI.Text = "";
                tbDNI.ForeColor = Color.LightGray;
                tbDNI.UseSystemPasswordChar = true;
            }
        }

        private void tbDNI_Leave(object sender, EventArgs e)
        {
            if (tbDNI.Text == "")
            {
                tbDNI.Text = "DNI";
                tbDNI.ForeColor = Color.DimGray;
                tbDNI.UseSystemPasswordChar = false;
            }
        }

        private void tbApellido_Enter(object sender, EventArgs e)
        {
            if (tbApellido.Text == "Apellido")
            {
                tbApellido.Text = "";
                tbApellido.ForeColor = Color.LightGray;
                tbApellido.UseSystemPasswordChar = true;
            }
        }

        private void tbApellido_Leave(object sender, EventArgs e)
        {
            if (tbApellido.Text == "")
            {
                tbApellido.Text = "Apellido";
                tbApellido.ForeColor = Color.DimGray;
                tbApellido.UseSystemPasswordChar = false;
            }
        }

        private void tbNombre_Enter(object sender, EventArgs e)
        {
            if (tbNombre.Text == "Nombre")
            {
                tbNombre.Text = "";
                tbNombre.ForeColor = Color.LightGray;
                tbNombre.UseSystemPasswordChar = true;
            }
        }

        private void tbNombre_Leave(object sender, EventArgs e)
        {
            if (tbNombre.Text == "")
            {
                tbNombre.Text = "Nombre";
                tbNombre.ForeColor = Color.DimGray;
                tbNombre.UseSystemPasswordChar = false;
            }
        }

        private void tbTelefono_Enter(object sender, EventArgs e)
        {
            if (tbTelefono.Text == "Telefono")
            {
                tbTelefono.Text = "";
                tbTelefono.ForeColor = Color.LightGray;
                tbTelefono.UseSystemPasswordChar = true;
            }
        }

        private void tbTelefono_Leave(object sender, EventArgs e)
        {
            if (tbTelefono.Text == "")
            {
                tbTelefono.Text = "Telefono";
                tbTelefono.ForeColor = Color.DimGray;
                tbTelefono.UseSystemPasswordChar = false;
            }
        }

        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "Usuario")
            {
                tbUsuario.Text = "";
                tbUsuario.ForeColor = Color.LightGray;
                tbUsuario.UseSystemPasswordChar = true;
            }
        }

        private void tbUsuario_Leave(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "")
            {
                tbUsuario.Text = "Usuario";
                tbUsuario.ForeColor = Color.DimGray;
                tbUsuario.UseSystemPasswordChar = false;
            }
        }

        private void tbClave_Enter(object sender, EventArgs e)
        {
            if (tbClave.Text == "Clave")
            {
                tbClave.Text = "";
                tbClave.ForeColor = Color.LightGray;
                tbClave.UseSystemPasswordChar = true;
            }
        }

        private void tbClave_Leave(object sender, EventArgs e)
        {
            if (tbClave.Text == "")
            {
                tbClave.Text = "Clave";
                tbClave.ForeColor = Color.DimGray;
                tbClave.UseSystemPasswordChar = false;
            }
        }

        private void tbRepetirClave_Enter(object sender, EventArgs e)
        {
            if (tbRepetirClave.Text == "Repetir clave")
            {
                tbRepetirClave.Text = "";
                tbRepetirClave.ForeColor = Color.LightGray;
                tbRepetirClave.UseSystemPasswordChar = true;
            }
        }

        private void tbRepetirClave_Leave(object sender, EventArgs e)
        {
            if (tbRepetirClave.Text == "")
            {
                tbRepetirClave.Text = "Repetir clave";
                tbRepetirClave.ForeColor = Color.DimGray;
                tbRepetirClave.UseSystemPasswordChar = false;
            }
        }
        // --------------------------------------------------------------------------
    }
}
