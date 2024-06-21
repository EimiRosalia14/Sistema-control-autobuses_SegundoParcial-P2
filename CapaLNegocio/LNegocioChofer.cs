using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaAccesoDatos;

namespace CapaLNegocio
{
    public class LNegocioChofer
    {
        DatosChofer datosChofer = new DatosChofer();

        public DataTable Listar()
        {
            return datosChofer.Listar();
        }

        public bool Insertar(string nombre, string apellido, DateTime fechaNacimiento, string cedula)
        {
            return datosChofer.Insertar(nombre, apellido, fechaNacimiento, cedula);
        }

        public bool Actualizar(int choferId, string nombre, string apellido, DateTime fechaNacimiento, string cedula)
        {
            return datosChofer.Actualizar(choferId, nombre, apellido, fechaNacimiento, cedula);
        }

        public bool Eliminar(int choferId)
        {
            return datosChofer.Eliminar(choferId);
        }
    }
}