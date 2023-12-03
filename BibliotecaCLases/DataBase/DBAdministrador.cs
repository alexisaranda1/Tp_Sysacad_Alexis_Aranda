using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBAdministrador : SQLServer
    {
        public DBAdministrador()
        {

        }
        public Administrador VerificaDni(string dni)
        {
            Administrador administradorEncontrado = null;
            try
            {
                _conexion.Open();

                var query = $"SELECT * FROM Administrador WHERE DNI = '{dni}'";
                _comando.CommandText = query;

                _comando.Parameters.AddWithValue("@Dni", dni);

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    // Verificar si se encontraron filas
                    if (reader.Read())
                    {
                        string nombre = Convert.ToString(reader["Nombre"])!;
                        string apellido = Convert.ToString(reader["Apellido"])!;
                        string dniAEstudiante = Convert.ToString(reader["DNI"])!;
                        string correo = Convert.ToString(reader["Correo"])!;
                        string contraseña = Convert.ToString(reader["Clave"])!;
                        // Crear una instancia de la clase Estudiante con los datos de la fila encontrada
                        administradorEncontrado = new Administrador(nombre, apellido, dni, correo, contraseña);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
            }
            finally
            {
                _conexion.Close();
            }
            return administradorEncontrado;
        }
    }
}
