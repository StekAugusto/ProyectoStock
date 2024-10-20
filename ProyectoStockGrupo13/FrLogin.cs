﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Negocios;


namespace ProyectoStockGrupo13
{
    public partial class FrLogin : Form
    {
        public FrLogin()
        {
            InitializeComponent();
        }

        // PARA ARRASTRAR LA VENTANA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // Método para limpiar los campos de usuario y clave
        private void LimpiarCampos()
        {
            txtUsuario.Text = "Usuario";
            txtUsuario.ForeColor = Color.DimGray; // Restablecer el color del placeholder

            txtClave.Text = "Clave";
            txtClave.ForeColor = Color.DimGray; // Restablecer el color del placeholder
            txtClave.UseSystemPasswordChar = false; // Mostrar texto como texto normal
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor= Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if( txtUsuario.Text == "" )
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Clave")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.LightGray;
                txtClave.UseSystemPasswordChar = true;
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "Clave";
                txtClave.ForeColor = Color.DimGray;
                txtClave.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Evento para mover la ventana de login
        private void FrLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UserModel ControlUsuario = new UserModel();
            
            if(txtUsuario.Text != "Usuario")
            {
                if(txtClave.Text != "Clave")
                {
                    if (ControlUsuario.LoginUsuario(txtUsuario.Text, txtClave.Text) == true)
                    {

                        // Instancia menu principal
                        FrMenuPrincipal menuPrincipal = new FrMenuPrincipal();

                        // Mostrar formulario principal
                        menuPrincipal.Show();

                        menuPrincipal.FormClosed += CerrarSesion;

                        // Limpiar los campos del formulario de login
                        LimpiarCampos();

                        // Cerrar login
                        this.Hide(); // Oculta formulario


                    }
                    else
                    {
                        MessageBox.Show("ERROR: Datos invalidos");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: Ingrese clave");
                }
            }
            else
            {
                MessageBox.Show("ERROR: Ingrese usuario");
            }
            
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos del formulario de login
            LimpiarCampos();
        }

        private void CerrarSesion(object sender, FormClosedEventArgs e)
        {
            this.Show();
            txtUsuario.Focus();
        }
    }
}
