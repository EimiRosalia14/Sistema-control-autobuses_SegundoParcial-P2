using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class DatosViaje
    {
        private readonly string Conexion = "Data Source = DESKTOP-DML022K; Initial Catalog = SistemaControlAutobuses; Integrated Security = True;";

        public bool InsertarViaje(int choferId, int autobusId, int rutaId)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Viajes (ChoferID, AutobusID, RutaID) VALUES (@ChoferID, @AutobusID, @RutaID)", conn);
                cmd.Parameters.AddWithValue("@ChoferID", choferId);
                cmd.Parameters.AddWithValue("@AutobusID", autobusId);
                cmd.Parameters.AddWithValue("@RutaID", rutaId);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public DataTable ListarChoferesDisponibles()
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT c.ChoferID, c.Nombre + ' ' + c.Apellido AS NombreCompleto FROM Choferes c WHERE NOT EXISTS (SELECT 1 FROM Viajes v WHERE c.ChoferID = v.ChoferID)", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public DataTable ListarAutobusesDisponibles()
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT a.AutobusID, a.Marca + ' ' + a.Modelo AS Modelo FROM Autobuses a WHERE NOT EXISTS (SELECT 1 FROM Viajes v WHERE a.AutobusID = v.AutobusID)", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public DataTable ListarRutasDisponibles()
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT r.RutaID, r.NombreRuta FROM Rutas r WHERE NOT EXISTS (SELECT 1 FROM Viajes v WHERE r.RutaID = v.RutaID)", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public DataTable ListarViajesAsignados()
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
            SELECT v.ViajeID, c.Nombre + ' ' + c.Apellido AS Chofer, a.Marca + ' ' + a.Modelo AS Autobus, r.NombreRuta 
            FROM Viajes v JOIN Choferes c ON v.ChoferID = c.ChoferID JOIN Autobuses a ON v.AutobusID = a.AutobusID
            JOIN Rutas r ON v.RutaID = r.RutaID", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool EliminarViaje(int viajeId)
        {
            using (SqlConnection conn = new SqlConnection(Conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Viajes WHERE ViajeID = @ViajeID", conn);
                cmd.Parameters.AddWithValue("@ViajeID", viajeId);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
    }
}