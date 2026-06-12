using Capa_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Bibloteca
{
    public partial class FormAgregarLibro : Form
    {
        public int ID_Libro = 0;
        public string Titulo = "";
        public bool Editar = false;

        N_Libros obj = new N_Libros();
        public FormAgregarLibro()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbAutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtISBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPaginas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                obj.InsertarLibro(
                    txtTitulo.Text,
                    1, // GENERO (temporal)
                    1, // AUTOR (temporal)
                    VariablesGlobales.ID_Usuario,
                    txtISBN.Text,
                    Convert.ToInt32(txtPaginas.Text),
                    Convert.ToInt32(txtStock.Text),
                    1, // UBICACION (temporal)
                    DateTime.Now
                );

                MessageBox.Show("Libro guardado correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAgregarLibro_Load(object sender, EventArgs e)
        {
            CargarGeneros();
            CargarAutores();
            CargarUbicaciones();

            if (Editar)
                {
                    txtTitulo.Text = Titulo;
                }
            }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                obj.InsertarLibro(
                    txtTitulo.Text,
                    1, // GENERO (temporal)
                    1, // AUTOR (temporal)
                    VariablesGlobales.ID_Usuario,
                    txtISBN.Text,
                    Convert.ToInt32(txtPaginas.Text),
                    Convert.ToInt32(txtStock.Text),
                    1, // UBICACION (temporal)
                    DateTime.Now
                );

                MessageBox.Show("Libro guardado correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        void CargarGeneros()
        {
            N_Genero obj = new N_Genero();

            cbGenero.DataSource = obj.MostrarGeneros();
            cbGenero.DisplayMember = "Nombre_Genero";
            cbGenero.ValueMember = "ID_Genero";
        }
        void CargarAutores()
        {
            N_Autor obj = new N_Autor();

            cbAutor.DataSource = obj.MostrarAutores();
            cbAutor.DisplayMember = "Nombre_Autor";
            cbAutor.ValueMember = "ID_Autor";
        }
        void CargarUbicaciones()
        {
            N_Ubicacion obj = new N_Ubicacion();

            cbUbicacion.DataSource = obj.MostrarUbicacion();
            cbUbicacion.DisplayMember = "Pasillo";
            cbUbicacion.ValueMember = "ID_Ubicacion";
        }
    }
}
