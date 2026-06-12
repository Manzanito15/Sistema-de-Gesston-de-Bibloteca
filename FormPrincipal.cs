using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocios;

namespace Gestion_Bibloteca
{
    public partial class FormPrincipal : Form
    {
        N_Libros obj = new N_Libros();
        public FormPrincipal()
        {
            InitializeComponent();

        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormUsuarios login = new FormUsuarios();
            login.Show();
            this.Close();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AplicarPermisos();
        }

        private void AplicarPermisos()
        {
            string rol = VariablesGlobales.Rol;

           
            if (rol == "Administrador")
            {
                btnUsuarios.Enabled = true;
                btnLibros.Enabled = true;
                btnAutores.Enabled = true;
                btnLectores.Enabled = true;
                btnPrestamos.Enabled = true;
            }

            else if (rol == "Bibliotecario")
            {
                btnUsuarios.Enabled = false;
                btnLibros.Enabled = true;
                btnAutores.Enabled = true;
                btnLectores.Enabled = true;
                btnPrestamos.Enabled = true;
            }

       
            else if (rol == "Asistente")
            {
                btnUsuarios.Enabled = false;
                btnLibros.Enabled = true;
                btnAutores.Enabled = false;
                btnLectores.Enabled = true;
                btnPrestamos.Enabled = false;
            }

      
            else if (rol == "Encargado de Préstamos")
            {
                btnUsuarios.Enabled = false;
                btnLibros.Enabled = false;
                btnAutores.Enabled = false;
                btnLectores.Enabled = true;
                btnPrestamos.Enabled = true;
            }

           
            else if (rol == "Consultas")
            {
                btnUsuarios.Enabled = false;
                btnLibros.Enabled = false;
                btnAutores.Enabled = false;
                btnLectores.Enabled = false;
                btnPrestamos.Enabled = false;
            }

            
            else if (rol == "Auditor")
            {
                btnUsuarios.Enabled = false;
                btnLibros.Enabled = false;
                btnAutores.Enabled = false;
                btnLectores.Enabled = false;
                btnPrestamos.Enabled = false;
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios login = new FormUsuarios();
            login.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                  "¿Está seguro que desea cerrar sesión?",
                  "Cerrar Sesión",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );

            if (resultado == DialogResult.Yes)
            {
     
                VariablesGlobales.ID_Usuario = 0;
                VariablesGlobales.Nombre = "";
                VariablesGlobales.Rol = "";

                FrmUsuarios login = new FrmUsuarios();
                login.Show();

                this.Close();
            }
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblRol_Click(object sender, EventArgs e)
        {

        }

        private void btnAutores_Click(object sender, EventArgs e)
        {

        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            FormLibros login = new FormLibros();
            login.Show();
            this.Close();
        }

        private void btnLectores_Click(object sender, EventArgs e)
        {

        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            FormPrestamos frm = new FormPrestamos();
            frm.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }
        private void EstiloDataGrid(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(45, 66, 91);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(28, 41, 61);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            dgv.EnableHeadersVisualStyles = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormLibros login = new FormLibros();
            login.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
