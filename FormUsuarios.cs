using Capa_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Capa_Negocios.N_Usuarios;

namespace Gestion_Bibloteca
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CargarRoles()
        {
            N_Rol obj = new N_Rol();
            DataTable dt = obj.MostrarRoles();

            string columnas = "";
            foreach (DataColumn col in dt.Columns)
            {
                columnas += col.ColumnName + " | ";
            }

            MessageBox.Show(columnas);

            cbRol.DataSource = dt;
            cbRol.DisplayMember = "Nombre_Rol";
            cbRol.ValueMember = "ID_Rol";
        }
        
        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtUsuario.Text == "" || txtClave.Text == "")
            {
                MessageBox.Show("Complete los campos obligatorios");
                return;
            }

            try
            {
                N_Usuarios obj = new N_Usuarios();

                obj.InsertarUsuario(
                    txtNombre.Text,
                    txtEmail.Text,
                    txtTelefono.Text,
                    txtUsuario.Text,
                    txtClave.Text,
                    Convert.ToInt32(cbRol.SelectedValue)
                );

                MessageBox.Show("Usuario registrado correctamente");

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            cbRol.SelectedIndex = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.FromArgb(90, 85, 255);


        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.FromArgb(108, 99, 255);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUsuarios login = new FrmUsuarios();
            login.Show();
            this.Close();
        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormPrincipal login = new FormPrincipal();
            login.Show();
            this.Close();
        }
    }
}
