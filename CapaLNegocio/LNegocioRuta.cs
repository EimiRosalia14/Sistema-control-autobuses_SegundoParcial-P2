using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaAccesoDatos;

namespace CapaLNegocio
{
    public class LNegocioRuta
    {
        DatosRuta datosRuta = new DatosRuta();

        public DataTable Listar()
        {
            return datosRuta.Listar();
        }

        public bool Insertar(string nombreRuta)
        {
            return datosRuta.Insertar(nombreRuta);
        }

        public bool Actualizar(int rutaId, string nombreRuta)
        {
            return datosRuta.Actualizar(rutaId, nombreRuta);
        }

        public bool Eliminar(int rutaId)
        {
            return datosRuta.Eliminar(rutaId);
        }
    }
}