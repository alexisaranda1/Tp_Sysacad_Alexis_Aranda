using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBCursosInscriptos : SQLServer
    {
        public DBCursosInscriptos()
        {

        }

        public bool VerificaCodigo(int codigo, int legajo)
        {
            bool existe = false;

            try
            {
                _conexion.Open();

                var query = $"SELECT COUNT(*) FROM CursosInscriptos WHERE CodigoCurso = @CodigoVerificar AND LegajoEstudiante = @LegajoVerificar";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@CodigoVerificar", codigo);
                _comando.Parameters.AddWithValue("@LegajoVerificar", legajo);

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
        public bool AgregarCursosInscriptos(int codigo, int legajo)
        {
            bool existe = false;
            try
            {
                _conexion.Open();

                // Si no está inscrito, agrega una nueva fila a la tabla CursosInscriptos
                var query = $"INSERT INTO CursosInscriptos (CodigoCurso, LegajoEstudiante) VALUES (@CodigoAgregar, @LegajoAgregar)";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@CodigoAgregar", codigo);
                _comando.Parameters.AddWithValue("@LegajoAgregar", legajo);

                int filasAfectadas = _comando.ExecuteNonQuery();

                existe = filasAfectadas > 0;

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

        public List<Curso> VerCursosInscriptosPorLegajo(int legajo)
        {
            List<Curso> cursosInscriptos = new List<Curso>();

            try
            {
                _conexion.Open();

                var query = "SELECT Cursos.* FROM CursosInscriptos " +
                            "INNER JOIN Cursos ON CursosInscriptos.CodigoCurso = Cursos.Codigo " +
                            "WHERE CursosInscriptos.LegajoEstudiante = @Legajo";

                _comando.CommandText = query;
                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@Legajo", legajo);

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construir objetos Curso con los datos de la consulta
                        string Codigo = reader["Codigo"].ToString()!;
                        string Nombre = reader["Nombre"].ToString()!;
                        string descripcion = reader["Descripcion"].ToString()!;
                        string cupoMaximo = reader["CupoMaximo"].ToString()!;
                        int cupoDisponible = Convert.ToInt16(reader["CuposDisponibles"])!;
                        string activo = reader["Activo"].ToString()!;
                        string dia = reader["Dia"].ToString()!;
                        string horario = reader["Horario"].ToString()!;
                        string aula = reader["Aula"].ToString()!;
                        string correlativas = reader["Correlativas"].ToString()!;
                        string promedioRequerido = reader["PromedioRequerido"].ToString()!;
                        string creditosRequerido = reader["CreditosRequeridos"].ToString()!;
                        Curso curso = new Curso(Nombre, Codigo, descripcion, cupoMaximo, dia, horario, aula, correlativas, promedioRequerido, creditosRequerido);
                        curso.CuposDisponibles = cupoDisponible;

                        cursosInscriptos.Add(curso);
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

            return cursosInscriptos;
        }

        public bool ContarCursosInscriptosPorLegajo(int legajo)
        {
            bool cambio = false;

            try
            {
                _conexion.Open();

                var query = "SELECT COUNT(*) FROM CursosInscriptos " +
                            "WHERE LegajoEstudiante = @Legajo";

                _comando.CommandText = query;
                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@Legajo", legajo);

                int cantidadCursos = Convert.ToInt32(_comando.ExecuteScalar());
                cambio = cantidadCursos > 0;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
            }
            finally
            {
                _conexion.Close();
            }

            return cambio;
        }

    }
}
