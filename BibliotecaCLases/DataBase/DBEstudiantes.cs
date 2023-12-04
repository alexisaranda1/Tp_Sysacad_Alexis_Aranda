using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBEstudiantes : SQLServer
    {
        public DBEstudiantes()
        {

        }

        public void Guardar(Estudiante estudiante)
        {
            try
            {
                _conexion.Open();
                //var query = $"INSERT INTO Estudiante (Nombre, Apellido, Correo, DNI,Clave, TipoUsuario,DebeCambiar,Direccion,Telefono,CursosInscriptos,EstadoDePago) VALUES (@Nombre," +
                //    " @Apellido, @Correo, @Dni,@Clave,@TipoUsuario,@DebeCambiar,@Direccion,@Telefono,@CursosInscriptos,@EstadoDePago)";
                var query = $"INSERT INTO Estudiante (Nombre, Apellido, Correo, DNI,Clave, TipoUsuario,DebeCambiar,Direccion,Telefono) VALUES ('{estudiante.Nombre}'," +
                    $" '{estudiante.Apellido}', '{estudiante.Correo}', '{estudiante.Dni}','{estudiante.Clave}','{estudiante.TipoUsuario}',{estudiante.Debecambiar},'{estudiante.Direccion}','{estudiante.Telefono}')";
                _comando.CommandText = query;
                //_comando.Parameters.Clear();

                // Ajuste de parámetros con valores reales
                //_comando.Parameters.AddWithValue("@Legajo", estudiante.Legajo);
                //_comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                //_comando.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                //_comando.Parameters.AddWithValue("@Correo", estudiante.Correo);
                //_comando.Parameters.AddWithValue("@Dni", estudiante.Dni);
                //_comando.Parameters.AddWithValue("@Clave", estudiante.Clave);
                //_comando.Parameters.AddWithValue("@TipoUsuario", estudiante.TipoUsuario);
                //_comando.Parameters.AddWithValue("@DebeCambiar", estudiante.Debecambiar);
                //_comando.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                //_comando.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
                //_comando.Parameters.AddWithValue("@EstadoPago", estudiante.EstadoDePago);

                //comando.Parameters.Clear();

                var filasAfectadas = _comando.ExecuteNonQuery();

                Console.WriteLine("Filas afectadas " + filasAfectadas);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
        }

        public Estudiante TraeEstudiantePorDNI(string dni)
        {
            Estudiante estudianteEncontrado = null;
            try
            {
                _conexion.Open();

                var query = $"SELECT * FROM Estudiante WHERE DNI = '{dni}'";
                _comando.CommandText = query;
                //_comando.Parameters.Clear();

                //_comando.Parameters.AddWithValue("@DNI", dni);

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    // Verificar si se encontraron filas
                    if (reader.Read())
                    {
                        int legajo = Convert.ToInt16(reader["Legajo"])!;
                        string nombre = Convert.ToString(reader["Nombre"])!;
                        string apellido = Convert.ToString(reader["Apellido"])!;
                        string dniAEstudiante = Convert.ToString(reader["DNI"])!;
                        string correo = Convert.ToString(reader["Correo"])!;
                        string direccion = Convert.ToString(reader["Direccion"])!;
                        string telefono = Convert.ToString(reader["Telefono"])!;
                        string contraseña = Convert.ToString(reader["Clave"])!;
                        int debeCambiar = Convert.ToInt16(reader["DebeCambiar"])!;
                        estudianteEncontrado = new Estudiante(nombre, apellido, dniAEstudiante, correo, direccion, telefono, contraseña, debeCambiar);
                        estudianteEncontrado.Legajo = legajo;
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
            return estudianteEncontrado;
        }

        public Estudiante TraeEstudiantePorLegajo(int legajo)
        {
            Estudiante estudianteEncontrado = null;
            try
            {
                _conexion.Open();

                var query = $"SELECT * FROM Estudiante WHERE Legajo = '{legajo}'";
                _comando.CommandText = query;

                //_comando.Parameters.AddWithValue("@DNI", dni);

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    // Verificar si se encontraron filas
                    if (reader.Read())
                    {
                        int legajoEncontrado = Convert.ToInt16(reader["Legajo"])!;
                        string nombre = Convert.ToString(reader["Nombre"])!;
                        string apellido = Convert.ToString(reader["Apellido"])!;
                        string dniAEstudiante = Convert.ToString(reader["DNI"])!;
                        string correo = Convert.ToString(reader["Correo"])!;
                        string direccion = Convert.ToString(reader["Direccion"])!;
                        string telefono = Convert.ToString(reader["Telefono"])!;
                        string contraseña = Convert.ToString(reader["Clave"])!;
                        int debeCambiar = Convert.ToInt16(reader["DebeCambiar"])!;
                        // Crear una instancia de la clase Estudiante con los datos de la fila encontrada
                        estudianteEncontrado = new Estudiante(nombre, apellido, dniAEstudiante, correo, direccion, telefono, contraseña, debeCambiar);
                        estudianteEncontrado.Legajo = legajoEncontrado;
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
            return estudianteEncontrado!;
        }



        public bool VerificaMail(string mail)
        {
            bool existe = false;

            try
            {
                _conexion.Open();

                var query = $"SELECT COUNT(*) FROM Estudiante WHERE Correo = '{mail}'";
                _comando.CommandText = query;

                //_comando.Parameters.AddWithValue("@Mail", mail);

                int count = Convert.ToInt32(_comando.ExecuteScalar());

                existe = count > 0;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
            }
            finally
            {
                _conexion.Close();
            }

            return existe;
        }
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            List<Estudiante> estudiante = new List<Estudiante>();

            try
            {
                _conexion.Open();
                var query = "SELECT * FROM Estudiante";
                _comando.CommandText = query;

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int legajoEncontrado = Convert.ToInt16(reader["Legajo"])!;
                        string nombre = Convert.ToString(reader["Nombre"])!;
                        string apellido = Convert.ToString(reader["Apellido"])!;
                        string dniAEstudiante = Convert.ToString(reader["DNI"])!;
                        string correo = Convert.ToString(reader["Correo"])!;
                        string direccion = Convert.ToString(reader["Direccion"])!;
                        string telefono = Convert.ToString(reader["Telefono"])!;
                        string contraseña = Convert.ToString(reader["Clave"])!;
                        int debeCambiar = Convert.ToInt16(reader["DebeCambiar"])!;
                        // Crear una instancia de la clase Estudiante con los datos de la fila encontrada
                        Estudiante estudianteEncontrado = new Estudiante(nombre, apellido, dniAEstudiante, correo, direccion, telefono, contraseña, debeCambiar);
                        estudianteEncontrado.Legajo = legajoEncontrado;
                        estudiante.Add(estudianteEncontrado);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }

            return estudiante;
        }
    }
}
