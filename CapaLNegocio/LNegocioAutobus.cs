using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaAccesoDatos;

namespace CapaLNegocio
{
    public class LNegocioAutobus
    {
        DatosAutobus datosAutobus = new DatosAutobus();

        public DataTable Listar()
        {
            return datosAutobus.Listar();
        }

        public bool Insertar(string marca, string modelo, string placa, string color, int año)
        {
            return datosAutobus.Insertar(marca, modelo, placa, color, año);
        }

        public bool Actualizar(int autobusId, string marca, string modelo, string placa, string color, int año)
        {
            return datosAutobus.Actualizar(autobusId, marca, modelo, placa, color, año);
        }

        public bool Eliminar(int autobusId)
        {
            return datosAutobus.Eliminar(autobusId);
        }
    }
}