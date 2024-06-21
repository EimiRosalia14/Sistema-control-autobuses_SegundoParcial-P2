using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class DatosAutobus
    {
        public string Conexion = "Data Source = DESKTOP-DML022K; Initial Catalog = SistemaControlAutobuses; Integrated Security = True;";

        public DataTable Listar()
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT AutobusID, Marca, Modelo, Placa, Color, Año FROM Autobuses", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public bool Insertar(string marca, string modelo, string placa, string color, int año)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Autobuses (Marca, Modelo, Placa, Color, Año) VALUES (@Marca, @Modelo, @Placa, @Color, @Año)", conn);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@Placa", placa);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.Parameters.AddWithValue("@Año", año);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Actualizar(int autobusId, string marca, string modelo, string placa, string color, int año)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Autobuses SET Marca = @Marca, Modelo = @Modelo, Placa = @Placa, Color = @Color, Año = @Año WHERE AutobusID = @AutobusID", conn);
                cmd.Parameters.AddWithValue("@AutobusID", autobusId);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@Placa", placa);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.Parameters.AddWithValue("@Año", año);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Eliminar(int autobusId)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Autobuses WHERE AutobusID = @AutobusID", conn);
                cmd.Parameters.AddWithValue("@AutobusID", autobusId);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
    }
}