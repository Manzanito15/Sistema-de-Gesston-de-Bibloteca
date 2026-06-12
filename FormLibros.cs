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
    public partial class FormLibros : Form
    {

        N_Libros obj = new N_Libros();

        public FormLibros()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void EstiloDataGrid()
        {
            dgvLibros.BorderStyle = BorderStyle.None;
            dgvLibros.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dgvLibros.DefaultCellStyle.BackColor = Color.White;
            dgvLibros.DefaultCellStyle.ForeColor = Color.Black;

            dgvLibros.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 95);
            dgvLibros.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvLibros.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);
            dgvLibros.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLibros.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            dgvLibros.EnableHeadersVisualStyles = false;

            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.RowHeadersVisible = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FormAgregarLibro frm = new FormAgregarLibro();
                frm.ShowDialog();


                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarLibros()
        {
            N_Libros obj = new N_Libros();
            dgvLibros.DataSource = obj.MostrarLibros();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dgvLibros.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un libro");
                return;
            }

            FormAgregarLibro frm = new FormAgregarLibro();

            CargarLibros();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un libro");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Desea eliminar este libro?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvLibros.CurrentRow.Cells["ID_Libro"].Value);

                N_Libros obj = new N_Libros();
                obj.EliminarLibro(id);

                MessageBox.Show("Libro eliminado");

                CargarLibros();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLibros.DataSource = obj.BuscarLibro(txtBuscar.Text);
        }

        private void FormLibros_Load(object sender, EventArgs e)
        {
            dgvLibros.DataSource = obj.MostrarLibros();
            EstiloDataGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            this.Hide();
        }
    }
}

