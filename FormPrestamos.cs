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
    public partial class FormPrestamos : Form
    {
        DataTable dtDetalle = new DataTable();
        public FormPrestamos()
        {
            InitializeComponent();
        }

        private void FormPrestamos_Load(object sender, EventArgs e)
        {
            CrearTablaDetalle();
            EstiloGrid();
            CargarLectores();
            CargarLibros();
        }
        void CargarLectores()
        {
            N_Lectores obj = new N_Lectores();
            cbLector.DataSource = obj.MostrarLectores();
            cbLector.DisplayMember = "Nombre_Lector";
            cbLector.ValueMember = "ID_Lector";
        }
        void CargarLibros()
        {
            N_Libros obj = new N_Libros();

            cbLibro.DataSource = obj.MostrarLibros();
            cbLibro.DisplayMember = "Titulo_Libro";
            cbLibro.ValueMember = "ID_Libro";
        }
        void CrearTablaDetalle()
        {
            dtDetalle.Columns.Add("ID_Libro", typeof(int));
            dtDetalle.Columns.Add("Titulo", typeof(string));

            dgvDetalle.DataSource = dtDetalle;
        }
        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbLibro.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un libro");
                return;
            }

            int idLibro = Convert.ToInt32(cbLibro.SelectedValue);
            string titulo = cbLibro.Text;

            // evitar duplicados
            foreach (DataRow row in dtDetalle.Rows)
            {
                if ((int)row["ID_Libro"] == idLibro)
                {
                    MessageBox.Show("Este libro ya fue agregado");
                    return;
                }
            }

            // agregar al DataTable
            dtDetalle.Rows.Add(idLibro, titulo);

            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = dtDetalle;
        }
        void LimpiarCampos()
        {
            cbLector.SelectedIndex = 0;
            cbLibro.SelectedIndex = 0;
            dtPrestamo.Value = DateTime.Now;
            dtEntrega.Value = DateTime.Now.AddDays(7);
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
         LimpiarCampos();
        }

        private void cbLector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbLibro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtPrestamo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtEntrega_ValueChanged(object sender, EventArgs e)
        {

        }
void EstiloGrid()
{
    dgvDetalle.BorderStyle = BorderStyle.None;
    dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
    dgvDetalle.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
    dgvDetalle.DefaultCellStyle.SelectionForeColor = Color.White;
    dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    dgvDetalle.RowHeadersVisible = false;
}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormPrincipal frm = new FormPrincipal();
            frm.Show();
            this.Hide();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.ID_Prestamo == 0)
            {
                MessageBox.Show("Primero registre un préstamo");
                return;
            }

            FormReportePrestamos frm = new FormReportePrestamos();
            frm.ID_Prestamo = VariablesGlobales.ID_Prestamo;
            frm.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                if (dtDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un libro");
                    return;
                }

                N_Prestamos obj = new N_Prestamos();

                int idPrestamo = obj.InsertarPrestamoYRetornarID(
                    dtPrestamo.Value,
                    Convert.ToInt32(cbLector.SelectedValue),
                    dtEntrega.Value,
                    VariablesGlobales.ID_Usuario
                );

                // guardar detalle
                foreach (DataRow row in dtDetalle.Rows)
                {
                    obj.InsertarDetalle(idPrestamo, Convert.ToInt32(row["ID_Libro"]));
                }

                // 🔥 GUARDAR ID PARA REPORTE
                VariablesGlobales.ID_Prestamo = idPrestamo;

                MessageBox.Show("Préstamo registrado correctamente");

                dtDetalle.Clear();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPrincipal login = new FormPrincipal();
            login.Show();
            this.Close();
        }
    }
}
