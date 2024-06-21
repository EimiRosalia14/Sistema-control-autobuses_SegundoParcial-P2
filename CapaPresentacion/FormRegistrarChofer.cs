using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLNegocio;

namespace CapaPresentacion
{
    public partial class FormRegistrarChofer : Form
    {
        LNegocioChofer negocioChofer = new LNegocioChofer();
        public FormRegistrarChofer()
        {
            InitializeComponent();
        }

        private void FormRegistrarChofer_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime fechaNacimiento = DateTime.Parse(maskedTxtFechaNac.Text);
            string cedula = txtCedula.Text;

            bool exito = negocioChofer.Insertar(nombre, apellido, fechaNacimiento, cedula);
            if (exito)
            {
                MessageBox.Show("Chofer registrado con éxito");
                LimpiarCampos();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al registrar el chofer");
            }
        }

        private void CargarDatos()
        {
            dataGridViewChoferes.DataSource = negocioChofer.Listar();
            dataGridViewChoferes.Columns["ChoferID"].Visible = true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            maskedTxtFechaNac.Clear();
            txtCedula.Clear();
        }

        private void dataGridViewChoferes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskedTxtFechaNac_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewChoferes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewChoferes.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                maskedTxtFechaNac.Text = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value).ToString("dd/MM/yyyy");
                txtCedula.Text = row.Cells["Cedula"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewChoferes.SelectedRows.Count == 1) // Asegura que se haya seleccionado una fila completa
            {
                DataGridViewRow row = dataGridViewChoferes.SelectedRows[0];
                int choferId = Convert.ToInt32(row.Cells["ChoferID"].Value);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                DateTime fechaNacimiento;
                if (!DateTime.TryParse(maskedTxtFechaNac.Text, out fechaNacimiento))
                {
                    MessageBox.Show("Ingrese una fecha de nacimiento válida.");
                    return;
                }
                string cedula = txtCedula.Text;

                bool exito = negocioChofer.Actualizar(choferId, nombre, apellido, fechaNacimiento, cedula);
                if (exito)
                {
                    MessageBox.Show("Chofer actualizado con éxito");
                    LimpiarCampos();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el chofer");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila completa para actualizar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewChoferes.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("¿Está seguro de querer eliminar este chofer?", "Eliminar Chofer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataGridViewRow row = dataGridViewChoferes.SelectedRows[0];
                    int choferId = Convert.ToInt32(row.Cells["ChoferID"].Value);
                    bool exito = negocioChofer.Eliminar(choferId);
                    if (exito)
                    {
                        MessageBox.Show("Chofer eliminado con éxito.");
                        LimpiarCampos();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el chofer.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila completa para eliminar.");
            }
        }
    }
}