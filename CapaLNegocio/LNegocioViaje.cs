using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaAccesoDatos;

namespace CapaLNegocio
{
    public class LNegocioViaje
    {
        private DatosViaje datosViaje = new DatosViaje();

        public bool InsertarViaje(int choferId, int autobusId, int rutaId)
        {
            return datosViaje.InsertarViaje(choferId, autobusId, rutaId);
        }

        public DataTable ListarChoferesDisponibles()
        {
            return datosViaje.ListarChoferesDisponibles();
        }

        public DataTable ListarAutobusesDisponibles()
        {
            return datosViaje.ListarAutobusesDisponibles();
        }

        public DataTable ListarRutasDisponibles()
        {
            return datosViaje.ListarRutasDisponibles();
        }

        public DataTable ListarViajesAsignados()
        {
            return datosViaje.ListarViajesAsignados();
        }

        public bool EliminarViaje(int viajeId)
        {
            return datosViaje.EliminarViaje(viajeId);
        }
    }
}