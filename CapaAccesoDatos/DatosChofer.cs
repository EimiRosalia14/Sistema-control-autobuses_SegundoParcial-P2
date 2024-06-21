using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class DatosChofer
    {
        public string Conexion = "Data Source = DESKTOP-DML022K; Initial Catalog = SistemaControlAutobuses; Integrated Security = True;";

        public DataTable Listar()
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ChoferID, Nombre, Apellido, FechaNacimiento, Cedula FROM Choferes", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public bool Insertar(string nombre, string apellido, DateTime fechaNacimiento, string cedula)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Choferes (Nombre, Apellido, FechaNacimiento, Cedula) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Cedula)", conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@Cedula", cedula);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Actualizar(int choferId, string nombre, string apellido, DateTime fechaNacimiento, string cedula)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Choferes SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Cedula = @Cedula WHERE ChoferID = @ChoferID", conn);
                cmd.Parameters.AddWithValue("@ChoferID", choferId);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@Cedula", cedula);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Eliminar(int choferId)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Choferes WHERE ChoferID = @ChoferID", conn);
                cmd.Parameters.AddWithValue("@ChoferID", choferId);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
    }
}