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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (txtUsuario.Text.Trim() == "" || txtConstraseña.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese usuario y contraseña");
                return;
            }

            N_Usuarios obj = new N_Usuarios();
            DataTable dt = obj.Login(txtUsuario.Text, txtConstraseña.Text);

            if (dt.Rows.Count > 0)
            {
              
                VariablesGlobales.ID_Usuario = Convert.ToInt32(dt.Rows[0]["ID_Usuario"]);
                VariablesGlobales.Nombre = dt.Rows[0]["Nombre_Usuario"].ToString();
                VariablesGlobales.Rol = dt.Rows[0]["Nombre_Rol"].ToString();

                MessageBox.Show($"Bienvenido {VariablesGlobales.Nombre} - Rol: {VariablesGlobales.Rol}");


                FormPrincipal frm = new FormPrincipal();
                frm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
        
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtConstraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkConstraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Silver;
            }
        }

        private void txtConstraseña_Enter(object sender, EventArgs e)
        {
            if (txtConstraseña.Text == "Contraseña")
            {
                txtConstraseña.Text = "";
                txtConstraseña.ForeColor = Color.LightGray;
                txtConstraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtConstraseña_Leave(object sender, EventArgs e)
        {
            if (txtConstraseña.Text == "")
            {
                txtConstraseña.Text = "Contraseña";
                txtConstraseña.ForeColor = Color.Silver;
                txtConstraseña.UseSystemPasswordChar = false;
            }
        }

        private void FrmUsuarios_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IblErrorMessage_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormUsuarios frm = new FormUsuarios();
            frm.Show();
            this.Hide();
        }
    }
}
