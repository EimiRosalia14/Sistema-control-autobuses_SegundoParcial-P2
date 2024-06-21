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
    public partial class FormRegistrarAutobuses : Form
    {
        LNegocioAutobus negocioAutobus = new LNegocioAutobus();
        public FormRegistrarAutobuses()
        {
            InitializeComponent();
        }

        private void FormRegistrarAutobuses_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            string placa = txtPlaca.Text;
            string color = txtColor.Text;
            int año = Convert.ToInt32(txtAño.Text);

            bool exito = negocioAutobus.Insertar(marca, modelo, placa, color, año);
            if (exito)
            {
                MessageBox.Show("Autobús registrado con éxito");
                LimpiarCampos();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al registrar el autobús");
            }
        }

        private void CargarDatos()
        {
            dataGridViewAutobuses.DataSource = negocioAutobus.Listar();
            dataGridViewAutobuses.Columns["AutobusID"].Visible = true;
        }

        private void LimpiarCampos()
        {
            txtMarca.Clear();
            txtModelo.Clear();
            txtPlaca.Clear();
            txtColor.Clear();
            txtAño.Clear();
        }

        private void dataGridViewAutobuses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAutobuses.Rows[e.RowIndex];
                txtMarca.Text = Convert.ToString(row.Cells["Marca"].Value);
                txtModelo.Text = Convert.ToString(row.Cells["Modelo"].Value);
                txtPlaca.Text = Convert.ToString(row.Cells["Placa"].Value);
                txtColor.Text = Convert.ToString(row.Cells["Color"].Value);
                txtAño.Text = Convert.ToString(row.Cells["Año"].Value);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAutobuses.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewAutobuses.SelectedRows[0];
                int autobusId = Convert.ToInt32(row.Cells["AutobusID"].Value);
                string marca = txtMarca.Text;
                string modelo = txtModelo.Text;
                string placa = txtPlaca.Text;
                string color = txtColor.Text;
                int año = Convert.ToInt32(txtAño.Text);

                bool exito = negocioAutobus.Actualizar(autobusId, marca, modelo, placa, color, año);
                if (exito)
                {
                    MessageBox.Show("Autobús actualizado con éxito.");
                    LimpiarCampos();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el autobús.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila completa para actualizar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAutobuses.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("¿Está seguro de querer eliminar este autobús?", "Eliminar Autobús", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataGridViewRow row = dataGridViewAutobuses.SelectedRows[0];
                    int autobusId = Convert.ToInt32(row.Cells["AutobusID"].Value);
                    bool exito = negocioAutobus.Eliminar(autobusId);
                    if (exito)
                    {
                        MessageBox.Show("Autobús eliminado con éxito.");
                        LimpiarCampos();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el autobús.");
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
