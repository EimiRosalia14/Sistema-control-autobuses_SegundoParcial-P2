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
    public partial class FormViajes : Form
    {
        private LNegocioViaje negocioViaje = new LNegocioViaje();
        public FormViajes()
        {
            InitializeComponent();
            CargarDatosIniciales();
        }

        private void FormViajes_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatosIniciales()
        {

            var choferes = negocioViaje.ListarChoferesDisponibles();

            if (choferes.Rows.Count > 0)
            {
                comboBoxChoferes.DataSource = choferes;
                comboBoxChoferes.DisplayMember = "NombreCompleto";
                comboBoxChoferes.ValueMember = "ChoferID";
            }
            else
            {
                comboBoxChoferes.DataSource = null;
            }

            var autobuses = negocioViaje.ListarAutobusesDisponibles();
            if (autobuses.Rows.Count > 0)
            {
                comboBoxAutobuses.DataSource = autobuses;
                comboBoxAutobuses.DisplayMember = "Modelo";
                comboBoxAutobuses.ValueMember = "AutobusID";
            }
            else
            {
                comboBoxAutobuses.DataSource = null;
            }

            var rutas = negocioViaje.ListarRutasDisponibles();
            if (rutas.Rows.Count > 0)
            {
                comboBoxRutas.DataSource = rutas;
                comboBoxRutas.DisplayMember = "NombreRuta";
                comboBoxRutas.ValueMember = "RutaID";
            }
            else
            {
                comboBoxRutas.DataSource = null;
            }

            ActualizarVistaViajes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int choferId = Convert.ToInt32(comboBoxChoferes.SelectedValue);
                int autobusId = Convert.ToInt32(comboBoxAutobuses.SelectedValue);
                int rutaId = Convert.ToInt32(comboBoxRutas.SelectedValue);

                var exito = negocioViaje.InsertarViaje(choferId, autobusId, rutaId);
                if (exito)
                {
                    MessageBox.Show("Viaje asignado con éxito.");
                    CargarDatosIniciales(); 
                }
                else
                {
                    MessageBox.Show("No se pudo asignar el viaje.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ActualizarVistaViajes()
        {
            dataGridViewViajes.DataSource = negocioViaje.ListarViajesAsignados();
            dataGridViewViajes.Columns["ViajeID"].Visible = true;
            dataGridViewViajes.Columns["Chofer"].HeaderText = "Chofer";
            dataGridViewViajes.Columns["Autobus"].HeaderText = "Autobús";
            dataGridViewViajes.Columns["NombreRuta"].HeaderText = "Ruta";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewViajes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una fila completa para eliminar.");
                return;
            }

            int viajeId = Convert.ToInt32(dataGridViewViajes.SelectedRows[0].Cells["ViajeID"].Value);

            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar el viaje seleccionado?",
                                                 "Confirmar eliminación",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                bool exito = negocioViaje.EliminarViaje(viajeId);
                if (exito)
                {
                    MessageBox.Show("Viaje eliminado con éxito.");
                    CargarDatosIniciales();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el viaje.");
                }
            }
        }
    }
}