using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Cache;

namespace ProyectoStockGrupo13
{
    public partial class FrInicio : Form
    {
        public FrInicio()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            lblBienvenida.Text = "Bienvenido "+CacheLogin.NombreEmpleado + ", " + CacheLogin.ApellidoEmpleado;
        }
    }
}
