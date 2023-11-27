using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BibliotecaCLases.Utilidades
{
    internal class SQLServer
    {
        public static SqlConnection conexion;
        private static string cadenaConexion;
        private static SqlCommand comando;

        public SQLServer()
        {
            string Server = ConfigurationManager.AppSettings["DataBaseServer"]!;
            string DatabaseName = ConfigurationManager.AppSettings["DataBaseName"]!;
            cadenaConexion = @$"Server={Server};Database={DatabaseName};Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";
            conexion = new SqlConnection(cadenaConexion);

            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }
        public void Guardar(string nombre, string apellido, int edad, int dni, int id)
        {
            try
            {
                conexion.Open();

                //var query = $"INSERT INTO personas (nombre) VALUES ('{nombre}')";
                // Cambiado a una consulta parametrizada y ajuste de los parámetros
                var query = "INSERT INTO Estudiante (ID, Nombre, Apellido, DNI, Edad) VALUES (@ID, @Nombre, @Apellido, @DNI, @Edad)";
                comando.CommandText = query;

                // Ajuste de parámetros con valores reales
                comando.Parameters.AddWithValue("@ID", id);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido", apellido);
                comando.Parameters.AddWithValue("@DNI", dni);
                comando.Parameters.AddWithValue("@Edad", edad);

                //comando.Parameters.Clear();

                var filasAfectadas = comando.ExecuteNonQuery();

                Console.WriteLine("Filas afectadas " + filasAfectadas);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                //throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
