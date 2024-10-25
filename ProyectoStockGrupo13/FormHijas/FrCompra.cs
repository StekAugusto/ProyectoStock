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
    public partial class FrCompra : Form
    {
        public FrCompra()
        {
            InitializeComponent();
            dtpFechaCompra.Value = DateTime.Now;      
        }

        private void FrCompra_Load(object sender, EventArgs e)
        {
                                


        }

        private void cbNombProveedor_Leave(object sender, EventArgs e)
        {
            if (!cbNombProveedor.Items.Contains(cbNombProveedor.Text))
            {
                MessageBox.Show("Debe seleccionar un proveedor existente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbNombProveedor.Focus();
            }
        }
    }
}
