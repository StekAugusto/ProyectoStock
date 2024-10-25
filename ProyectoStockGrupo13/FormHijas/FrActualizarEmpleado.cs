using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Cache;
using Negocios;

namespace ProyectoStockGrupo13
{
    public partial class FrActualizarEmpleado : Form
    {
        private UserModel userModel;
        public FrActualizarEmpleado()
        {
            InitializeComponent();
            userModel = new UserModel();
        }

        private void FrActualizarEmpleado_Load(object sender, EventArgs e)
        {
            // Llamar función para cargar empleados en el dgv
            CargarEmpleados();

            // Conectar evento
            dgvEmpleados.SelectionChanged += new EventHandler(dgvEmpleados_SelectionChanged);
        }
        private void CargarEmpleados()
        {
            dgvEmpleados.DataSource = userModel.ObtenerEmpleados();
            // No seleccionar ninguna fila
            dgvEmpleados.ClearSelection();

        }

        private void RefrescarDataGrid()
        {
            // Crear una instancia de UserModel
            UserModel userModel = new UserModel();

            // Llamar al método que obtiene todos los empleados desde la base de datos
            DataTable empleados = userModel.ObtenerEmpleados();

            // Asignar los datos al DataGridView
            dgvEmpleados.DataSource = empleados;

            // Evitar seleccionar cualquier fila al refrescar
            dgvEmpleados.ClearSelection(); // Esto asegura que no haya filas seleccionadas
        }



        // Metodos para limpiar los text box o volver el palceholder al texto original
        // -------------------------------------------------------------------------------
        private void tbDNI_Enter(object sender, EventArgs e)
        {
            if (tbDNI.Text == "DNI")
            {
                tbDNI.Text = "";
                tbDNI.ForeColor = Color.LightGray;
            }
        }

        private void tbDNI_Leave(object sender, EventArgs e)
        {
            if (tbDNI.Text == "")
            {
                tbDNI.Text = "DNI";
                tbDNI.ForeColor = Color.DimGray;
            }
        }

        private void tbApellido_Enter(object sender, EventArgs e)
        {
            if (tbApellido.Text == "Apellido")
            {
                tbApellido.Text = "";
                tbApellido.ForeColor = Color.LightGray;
            }
        }

        private void tbApellido_Leave(object sender, EventArgs e)
        {
            if (tbApellido.Text == "")
            {
                tbApellido.Text = "Apellido";
                tbApellido.ForeColor = Color.DimGray;
            }
        }

        private void tbNombre_Enter(object sender, EventArgs e)
        {
            if (tbNombre.Text == "Nombre")
            {
                tbNombre.Text = "";
                tbNombre.ForeColor = Color.LightGray;
            }
        }

        private void tbNombre_Leave(object sender, EventArgs e)
        {
            if (tbNombre.Text == "")
            {
                tbNombre.Text = "Nombre";
                tbNombre.ForeColor = Color.DimGray;
            }
        }

        private void tbTelefono_Enter(object sender, EventArgs e)
        {
            if (tbTelefono.Text == "Telefono")
            {
                tbTelefono.Text = "";
                tbTelefono.ForeColor = Color.LightGray;
            }
        }

        private void tbTelefono_Leave(object sender, EventArgs e)
        {
            if (tbTelefono.Text == "")
            {
                tbTelefono.Text = "Telefono";
                tbTelefono.ForeColor = Color.DimGray;
            }
        }

        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "Usuario")
            {
                tbUsuario.Text = "";
                tbUsuario.ForeColor = Color.LightGray;
            }
        }

        private void tbUsuario_Leave(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "")
            {
                tbUsuario.Text = "Usuario";
                tbUsuario.ForeColor = Color.DimGray;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Comprobacion de seleccion de fila
            if(dgvEmpleados.SelectedRows.Count > 0)
            {
                // Obtener fila seleccionada
                DataGridViewRow row = dgvEmpleados.SelectedRows[0];

                // Pasar valores a los textbox
                tbDNI.Text = row.Cells["DNI"].Value.ToString();
                tbApellido.Text = row.Cells["Apellido"].Value.ToString();
                tbNombre.Text = row.Cells["Nombre"].Value.ToString();
                tbTelefono.Text = row.Cells["Telefono"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(row.Cells["FechaNac"].Value);
                tbUsuario.Text = row.Cells["Usuario"].Value.ToString();

                tbClave.UseSystemPasswordChar = true;
                tbRepetirClave.UseSystemPasswordChar = true;

                tbClave.Text = row.Cells["Clave"].Value.ToString();
                tbRepetirClave.Text = row.Cells["Clave"].Value.ToString(); // Asegúrate de manejar bien esto
                cbRol.SelectedItem = row.Cells["TipoEmpleado"].Value.ToString(); // ComboBox para los roles

                tbDNI.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Fila no seleccionada. Seleccione una fila primero.");
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos
            long dni = Convert.ToInt64(tbDNI.Text);
            string apellido = tbApellido.Text;
            string nombre = tbNombre.Text;
            string telefono = tbTelefono.Text;
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string usuario = tbUsuario.Text;
            string clave = tbClave.Text;
            // -------------- VALIDACIONES --------------
            // Clave
            if (tbClave.Text != tbRepetirClave.Text)
            {
                MessageBox.Show("Las claves no coinciden. Por favor, verifícalas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // rol
            string rol = null;
            if (cbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un rol válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detener el proceso si no se seleccionó ningún rol
            }
            

            if (cbRol.SelectedItem != null)
            {
                rol = cbRol.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Por favor selecciona un rol.");
                return; // Evita continuar si no se seleccionó un rol
            }
            

            // Crear una instancia de UserModel para manejar la lógica
            UserModel userModel = new UserModel();

            // Verificar si el empleado con el DNI ya existe
            if (userModel.ExisteEmpleado(dni))
            {
                // Modificar el empleado si ya existe
                bool modificado = userModel.ModificarEmpleado(dni, apellido, nombre, telefono, fechaNacimiento, usuario, clave, rol);
                if (modificado)
                {
                    MessageBox.Show("Empleado modificado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al modificar el empleado.");
                }
            }
            else
            {
                // Agregar un nuevo empleado si no existe
                bool agregado = userModel.AgregarEmpleado(dni, apellido, nombre, telefono, fechaNacimiento, usuario, clave, rol);
                if (agregado)
                {
                    MessageBox.Show("Nuevo empleado agregado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al agregar el empleado.");
                }
            }
            RefrescarDataGrid();
            btnLimpiar_Click(sender, e);
        }


        // ------------------------------------------------------------------------------------------------------------
        // Obtener empleado por DNI
        
        // ------------------------------------------------------------------------------------------------------------
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Obtén el DNI del TextBox
            long dni = Convert.ToInt64(tbDNI.Text.Trim());

            // Crea una instancia de UserModel para acceder a la lógica de negocio
            UserModel userModel = new UserModel();

            // Verifica si el empleado existe
            if (userModel.ExisteEmpleado(dni))
            {
                // Si existe, obtén el nombre y apellido del empleado
                var empleado = userModel.ObtenerEmpleados().AsEnumerable()
                                          .FirstOrDefault(row => row.Field<long>("DNI") == dni);

                if (empleado != null)
                {
                    string nombreCompleto = $"{empleado.Field<string>("Nombre")} {empleado.Field<string>("Apellido")}";

                    // Muestra un mensaje de confirmación
                    DialogResult dialogResult = MessageBox.Show(
                        $"¿Está seguro que desea eliminar a {nombreCompleto}?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    // Si el usuario selecciona 'Sí', realiza la eliminación
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (userModel.EliminarEmpleado(dni)) // Llama al método de eliminación en la capa de negocio
                        {
                            MessageBox.Show("Empleado eliminado exitosamente.");
                            // Actualiza el DataGridView si es necesario
                            dgvEmpleados.DataSource = userModel.ObtenerEmpleados();
                            RefrescarDataGrid();
                            btnLimpiar_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el empleado.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El empleado no existe.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar campos
            // ----------------------------------------------------------
            tbDNI.Text = "";
            tbApellido.Text = "";
            tbNombre.Text = "";
            tbTelefono.Text = "";
            tbUsuario.Text = "";
            tbClave.Text = "";
            tbRepetirClave.Text = "";
            // ----------------------------------------------------------

            // Llamar eventos leave para no repetir codigo
            // ----------------------------------------------------------
            tbDNI_Leave(tbDNI, EventArgs.Empty);
            tbApellido_Leave(tbApellido, EventArgs.Empty);
            tbNombre_Leave(tbNombre, EventArgs.Empty);
            tbTelefono_Leave(tbTelefono, EventArgs.Empty);
            tbUsuario_Leave(tbUsuario, EventArgs.Empty);
            tbClave_Leave(tbClave, EventArgs.Empty);
            tbRepetirClave_Leave(tbRepetirClave, EventArgs.Empty);
            // ----------------------------------------------------------

            tbDNI.ReadOnly = false;
        }

        private void dgvEmpleados_SelectionChanged_1(object sender, EventArgs e)
        {
            // Comprobación de selección de fila
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                // Obtener fila seleccionada
                DataGridViewRow row = dgvEmpleados.SelectedRows[0];

                // Comprobar si la fila no es la última fila vacía
                if (row.IsNewRow) return; // No hacer nada si es la última fila (vacía)

                // Pasar valores a los TextBox
                tbDNI.Text = row.Cells["DNI"].Value.ToString();
                tbApellido.Text = row.Cells["Apellido"].Value.ToString();
                tbNombre.Text = row.Cells["Nombre"].Value.ToString();
                tbTelefono.Text = row.Cells["Telefono"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(row.Cells["FechaNac"].Value);
                tbUsuario.Text = row.Cells["Usuario"].Value.ToString();

                tbClave.UseSystemPasswordChar = true;
                tbRepetirClave.UseSystemPasswordChar = true;

                tbClave.Text = row.Cells["Clave"].Value.ToString();
                tbRepetirClave.Text = row.Cells["Clave"].Value.ToString(); // Asegúrate de manejar bien esto
                cbRol.SelectedItem = row.Cells["TipoEmpleado"].Value.ToString(); // ComboBox para los roles

                tbDNI.ReadOnly = true;
            }
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            // Comprobación de selección de fila
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                // Obtener fila seleccionada
                DataGridViewRow row = dgvEmpleados.SelectedRows[0];

                // Comprobar si la fila no es la última fila vacía
                if (row.IsNewRow) return; // No hacer nada si es la última fila (vacía)

                // Pasar valores a los TextBox
                tbDNI.Text = row.Cells["DNI"].Value.ToString();
                tbApellido.Text = row.Cells["Apellido"].Value.ToString();
                tbNombre.Text = row.Cells["Nombre"].Value.ToString();
                tbTelefono.Text = row.Cells["Telefono"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(row.Cells["FechaNac"].Value);
                tbUsuario.Text = row.Cells["Usuario"].Value.ToString();

                tbClave.UseSystemPasswordChar = true;
                tbRepetirClave.UseSystemPasswordChar = true;

                tbClave.Text = row.Cells["Clave"].Value.ToString();
                tbRepetirClave.Text = row.Cells["Clave"].Value.ToString(); // Asegúrate de manejar bien esto
                cbRol.SelectedItem = row.Cells["TipoEmpleado"].Value.ToString(); // ComboBox para los roles

                tbDNI.ReadOnly = true;
            }
        }
    }
}
