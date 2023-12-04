using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBListaDeEspera: SQLServer
    {
        public List<ListaEspera> ObtenerTodasLasEsperas()
        {
            List<ListaEspera> listaespera = new List<ListaEspera>();

            try
            {
                _conexion.Open();
                var query = "SELECT * FROM ListaDeEspera ORDER BY FechaDeEspera ASC";
                _comando.CommandText = query;

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string codigo = reader["Codigo"].ToString()!;
                        int legajo = Convert.ToInt16(reader["LegajoEstudiante"])!;
                        string date = reader["FechaDeEspera"].ToString()!;
                        ListaEspera espera = new ListaEspera(codigo, legajo,date);
                        listaespera.Add(espera);
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

            return listaespera;
        }

        public Dictionary<Estudiante, DateTime> ObtenerEstudiantesYFechasEnEsperaPorCurso(string codigoCurso)
        {
            Dictionary<Estudiante, DateTime> estudiantesYFechas = new Dictionary<Estudiante, DateTime>();

            try
            {
                _conexion.Open();

                // Modificar la consulta para unir las tablas Estudiantes y ListaDeEspera
                var query = @"
                    SELECT E.*, L.FechaDeEspera
                    FROM Estudiante E
                    INNER JOIN ListaDeEspera L ON E.Legajo = L.LegajoEstudiante
                    WHERE L.CodigoCurso = @CodigoCurso
                    ORDER BY L.FechaDeEspera ASC";

                _comando.CommandText = query;

                // Usar parámetros para evitar la inyección de SQL
                _comando.Parameters.AddWithValue("@CodigoCurso", codigoCurso);

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
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
                        Estudiante estudiante = new Estudiante(nombre, apellido, dniAEstudiante, correo, direccion, telefono, contraseña, debeCambiar);
                        estudiante.Legajo = legajo;
                        //string codigo = reader["Codigo"].ToString()!;
                        //int legajo = Convert.ToInt32(reader["Legajo"]);
                        //string nombre = reader["Nombre"].ToString()!; // Ajustar si es necesario
                        //string apellido = reader["Apellido"].ToString()!; // Ajustar si es necesario
                        DateTime fechaDeEspera = Convert.ToDateTime(reader["FechaDeEspera"]);

                        // Crear un objeto Estudiante
                        //Estudiante estudiante = new Estudiante(le, nombre, apellido);

                        // Agregar el estudiante y su fecha de espera al diccionario
                        estudiantesYFechas.Add(estudiante, fechaDeEspera);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
            }
            finally
            {
                _conexion.Close();
            }

            return estudiantesYFechas;
        }
        public bool Guardar(string codigo, int legajo)
        {
            bool existe = false;
            try
            {
                _conexion.Open();
                var query = $"INSERT INTO ListaDeEspera (CodigoCurso, LegajoEstudiante, FechaDeEspera) VALUES (@CodigoCurso,@LegajoEstudiante,GETDATE())";
                _comando.CommandText = query;
                _comando.Parameters.Clear();
                int codigoCurso = int.Parse(codigo);
                //Ajuste de parámetros con valores reales
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("@CodigoCurso", codigoCurso);
                _comando.Parameters.AddWithValue("@LegajoEstudiante", legajo);

                //comando.Parameters.Clear();

                var filasAfectadas = _comando.ExecuteNonQuery();
                existe = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return existe;
        }
        public bool Eliminar(string codigo, int legajo)
        {
            bool eliminado = false;
            try
            {
                _conexion.Open();

                var query = "DELETE FROM ListaDeEspera WHERE CodigoCurso = @CodigoCurso AND LegajoEstudiante = @LegajoEstudiante";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                int codigoCurso = int.Parse(codigo);
                _comando.Parameters.AddWithValue("@CodigoCurso", codigoCurso);
                _comando.Parameters.AddWithValue("@LegajoEstudiante", legajo);

                var filasAfectadas = _comando.ExecuteNonQuery();
                eliminado = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return eliminado;
        }
        public bool GuardarCodigo(string codigo)
        {
            bool existe = false;
            try
            {
                _conexion.Open();
                var query = $"INSERT INTO MediadorEspera (CodigoCurso) VALUES (@CodigoCurso)";
                _comando.CommandText = query;
                _comando.Parameters.Clear();
                int codigoCurso = int.Parse(codigo);
                //Ajuste de parámetros con valores reales
                _comando.Parameters.AddWithValue("@CodigoCurso", codigoCurso);

                var filasAfectadas = _comando.ExecuteNonQuery();
                existe = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return existe;
        }

        public bool ActualizarCodigo(string codigo)
        {
            bool existe = false;
            try
            {
                _conexion.Open();
                var query = $"UPDATE MediadorEspera SET CodigoCurso = @CodigoCurso";
                _comando.CommandText = query;
                _comando.Parameters.Clear();
                int codigoCurso = int.Parse(codigo);
                //Ajuste de parámetros con valores reales
                _comando.Parameters.AddWithValue("@CodigoCurso", codigoCurso);

                var filasAfectadas = _comando.ExecuteNonQuery();
                existe = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return existe;
        }
        public bool VerificaEstudianteEnCurso(string codigo,int legajo)
        {
            bool valid = false;
            try
            {
                _conexion.Open();
                int codigoCurso = int.Parse(codigo);
                var query = $"SELECT COUNT(*) FROM ListaDeEspera WHERE CodigoCurso = @CodigoCurso AND LegajoEstudiante = @LegajoEstudiante";
                _comando.CommandText = query;
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("@CodigoCurso", codigoCurso);
                _comando.Parameters.AddWithValue("@LegajoEstudiante", legajo);

                int count = Convert.ToInt32(_comando.ExecuteScalar());

                valid = count > 0;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
            }
            finally
            {
                _conexion.Close();
            }
            return valid;
        }
    }
}
