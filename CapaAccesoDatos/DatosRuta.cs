using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class DatosRuta
    {
        public string Conexion = "Data Source = DESKTOP-DML022K; Initial Catalog = SistemaControlAutobuses; Integrated Security = True;";

        public DataTable Listar()
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT RutaID, NombreRuta FROM Rutas", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public bool Insertar(string nombreRuta)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Rutas (NombreRuta) VALUES (@NombreRuta)", conn);
                cmd.Parameters.AddWithValue("@NombreRuta", nombreRuta);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Actualizar(int rutaId, string nombreRuta)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Rutas SET NombreRuta = @NombreRuta WHERE RutaID = @RutaID", conn);
                cmd.Parameters.AddWithValue("@RutaID", rutaId);
                cmd.Parameters.AddWithValue("@NombreRuta", nombreRuta);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Eliminar(int rutaId)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Rutas WHERE RutaID = @RutaID", conn);
                cmd.Parameters.AddWithValue("@RutaID", rutaId);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
    }
}