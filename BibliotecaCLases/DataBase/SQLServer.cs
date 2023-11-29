using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BibliotecaCLases.Modelo;
using System.Net;

namespace BibliotecaCLases.DataBase
{
    public class SQLServer
    {
        public  SqlConnection _conexion;
        public  string _cadenaConexion;
        public  SqlCommand _comando;

        public SQLServer()
        {
            string Server = ConfigurationManager.AppSettings["DataBaseServer"]!;
            string DatabaseName = ConfigurationManager.AppSettings["DataBaseName"]!;
            _cadenaConexion = @$"Server={Server};Database={DatabaseName};Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";
            _conexion = new SqlConnection(_cadenaConexion);

            _comando = new SqlCommand();
            _comando.CommandType = CommandType.Text;
            _comando.Connection = _conexion;
        }
        public void Guardar(string nombre, string apellido, int edad, int dni, int id, string nombreDeTabla)
        {
            try
            {
                _conexion.Open();
                /*
                if (!TableExists(_conexion, nombreDeTabla))
                {
                    List<Administrador> list = new List<Administrador>();
                    CreateTable(_conexion, nombreDeTabla, list);
                }*/
                var query = $"INSERT INTO {nombreDeTabla} (ID, Nombre, Apellido, DNI, Edad) VALUES (@ID, @Nombre, @Apellido, @DNI, @Edad)";
                _comando.CommandText = query;

                // Ajuste de parámetros con valores reales
                _comando.Parameters.AddWithValue("@ID", id);
                _comando.Parameters.AddWithValue("@Nombre", nombre);
                _comando.Parameters.AddWithValue("@Apellido", apellido);
                _comando.Parameters.AddWithValue("@DNI", dni);
                _comando.Parameters.AddWithValue("@Edad", edad);

                //comando.Parameters.Clear();

                var filasAfectadas = _comando.ExecuteNonQuery();

                Console.WriteLine("Filas afectadas " + filasAfectadas);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                //throw;
            }
            finally
            {
                _conexion.Close();
            }
        }

        public void GuardarPorTipo(string nombreDeTabla, Estudiante estudiante)
        {
            var query = $"INSERT INTO {nombreDeTabla} (Legajo, Nombre, Apellido, DNI, Direccion) VALUES (@Legajo, @Nombre, @Apellido, @DNI, @Edad)";
            _comando.CommandText = query;

            // Ajuste de parámetros con valores reales
            _comando.Parameters.AddWithValue("@Legajo", estudiante.Legajo);
            _comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
            _comando.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
            _comando.Parameters.AddWithValue("@DNI", estudiante.Dni);
            _comando.Parameters.AddWithValue("@Direccion", estudiante.Direccion);

            //comando.Parameters.Clear();

            var filasAfectadas = _comando.ExecuteNonQuery();

            Console.WriteLine("Filas afectadas " + filasAfectadas);
        }

        static bool TableExists(SqlConnection conexion, string nombreDeTabla)
        {
            string query = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{nombreDeTabla}'";

            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                int tableCount = (int)command.ExecuteScalar();
                return tableCount > 0;
            }
        }
        static void CreateTable(SqlConnection conexion, string nombreDeTabla, List<Administrador> lista)
        {
            string createTableQuery = $"CREATE TABLE {nombreDeTabla} (ID INT PRIMARY KEY, Nombre NVARCHAR(15), Apellido NVARCHAR(15),Dni INT,Edad INT)";

            using (SqlCommand command = new SqlCommand(createTableQuery, conexion))
            {
                command.ExecuteNonQuery();
                Console.WriteLine($"Se ha creado la tabla '{nombreDeTabla}'.");
            }
        }

    }
}
