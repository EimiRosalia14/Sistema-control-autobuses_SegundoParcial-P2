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
    public partial class FormRegistrarRutas : Form
    {
        LNegocioRuta negocioRuta = new LNegocioRuta();
        public FormRegistrarRutas()
        {
            InitializeComponent();
        }

        private void FormRegistrarRutas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombreRuta = txtNombreRuta.Text;

            bool exito = negocioRuta.Insertar(nombreRuta);
            if (exito)
            {
                MessageBox.Show("Ruta registrada con éxito");
                txtNombreRuta.Clear();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al registrar la ruta");
            }
        }

        private void CargarDatos()
        {
            dataGridViewRutas.DataSource = negocioRuta.Listar();
            dataGridViewRutas.Columns["RutaID"].Visible = true;
        }

        private void dataGridViewRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewRutas.Rows[e.RowIndex];
                txtNombreRuta.Text = row.Cells["NombreRuta"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewRutas.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewRutas.SelectedRows[0];
                int rutaId = Convert.ToInt32(row.Cells["RutaID"].Value);
                string nombreRuta = txtNombreRuta.Text;

                bool exito = negocioRuta.Actualizar(rutaId, nombreRuta);
                if (exito)
                {
                    MessageBox.Show("Ruta actualizada con éxito.");
                    txtNombreRuta.Clear();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la ruta.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila completa para actualizar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewRutas.SelectedRows.Count == 1 && MessageBox.Show("¿Está seguro de querer eliminar esta ruta?", "Eliminar Ruta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridViewRutas.SelectedRows[0];
                int rutaId = Convert.ToInt32(row.Cells["RutaID"].Value);
                bool exito = negocioRuta.Eliminar(rutaId);
                if (exito)
                {
                    MessageBox.Show("Ruta eliminada con éxito.");
                    txtNombreRuta.Clear();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la ruta.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila completa para eliminar.");
            }
        }
    }
}
