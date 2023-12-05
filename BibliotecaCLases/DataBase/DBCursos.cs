using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BibliotecaCLases.Modelo.Curso;

namespace BibliotecaCLases.DataBase
{
    public class DBCursos : SQLServer
    {
        public DBCursos()
        {

        }
        public void Guardar(Curso curso)
        {
            try
            {
                _conexion.Open();
                var query = $"INSERT INTO Cursos (Codigo, Nombre, Descripcion, CupoMaximo, CuposDisponibles,Activo, Dia,Horario,Aula,Correlativas,PromedioRequerido,CreditosRequeridos) VALUES (@Codigo, @Nombre," +
                    " @Descripcion, @CupoMaximo, @CuposDisponibles,@Activo,@Dia,@Horario,@Aula,@Correlativas,@PromedioRequerido,@CreditosRequeridos)";
                _comando.CommandText = query;

                //Ajuste de parámetros con valores reales
                _comando.Parameters.AddWithValue("@Codigo", curso.Codigo);
                _comando.Parameters.AddWithValue("@Nombre", curso.Nombre);
                _comando.Parameters.AddWithValue("@Descripcion", curso.Descripcion);
                _comando.Parameters.AddWithValue("@CupoMaximo", curso.CupoMaximo);
                _comando.Parameters.AddWithValue("@CuposDisponibles", curso.CuposDisponibles);
                _comando.Parameters.AddWithValue("@Activo", curso.Activo);
                _comando.Parameters.AddWithValue("@Dia", curso.Dia);
                _comando.Parameters.AddWithValue("@Horario", curso.Horario);
                _comando.Parameters.AddWithValue("@Aula", curso.Aula);
                _comando.Parameters.AddWithValue("@Correlativas", curso.Correlativas);
                _comando.Parameters.AddWithValue("@PromedioRequerido", curso.PromedioRequerido);
                _comando.Parameters.AddWithValue("@CreditosRequeridos", curso.CreditosRequerido);

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
        public bool VerificaCodigo(string codigo)
        {
            bool existe = false;

            try
            {
                _conexion.Open();

                var query = "SELECT COUNT(*) FROM Cursos WHERE Codigo = @Codigo";
                _comando.CommandText = query;

                _comando.Parameters.AddWithValue("@Codigo", codigo);

                int count = Convert.ToInt32(_comando.ExecuteScalar());

                existe = count > 0;
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

        public Curso TraePorCodigo(string codigoABuscar)
        {
            Curso curso = null;
            try
            {
                _conexion.Open();

                var query = "SELECT * FROM Cursos WHERE Codigo = @CodigoCurso";
                _comando.CommandText = query;
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("@CodigoCurso", codigoABuscar);

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string Codigo = reader["Codigo"].ToString()!;
                        string Nombre = reader["Nombre"].ToString()!;
                        string Descripcion = reader["Descripcion"].ToString()!;
                        string CupoMaximo = reader["CupoMaximo"].ToString()!;
                        int CuposDisponibles = Convert.ToInt32(reader["CuposDisponibles"]);
                        string Activo = reader["Activo"].ToString()!;
                        string Dia = reader["Dia"].ToString()!;
                        string Horario = reader["Horario"].ToString()!;
                        string Aula = reader["Aula"].ToString()!;
                        string Correlativas = reader["Correlativas"].ToString()!;
                        string PromedioRequerido = reader["PromedioRequerido"].ToString()!;
                        string CreditosRequeridos = reader["CreditosRequeridos"].ToString()!;
                        curso = new Curso(Nombre, Codigo, Descripcion, CupoMaximo, Dia, Horario, Aula, Correlativas, PromedioRequerido, CreditosRequeridos);
                        curso.CuposDisponibles = CuposDisponibles;
                        curso.Activo = Activo;
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

            return curso;
        }
        public bool ModificarCurso(string nombre, string descripcion, string cupoMaximo, int codigo, int nuevoCodigo, int cuposDisponibles)
        {
            bool cambio = false;
            try
            {
                _conexion.Open();

                // Consulta SQL para actualizar un curso
                var query = $"UPDATE Cursos SET Codigo = @NuevoCodigo, Nombre = @Nombre, CupoMaximo = @CupoMaximo, Descripcion = @Descripcion,CuposDisponibles = @CupoDisponible WHERE Codigo = @AntiguoCodigo";
                _comando.CommandText = query;

                _comando.Parameters.Clear();
                // Ajuste de parámetros con los nuevos valores
                _comando.Parameters.AddWithValue("@NuevoCodigo", nuevoCodigo);
                _comando.Parameters.AddWithValue("@AntiguoCodigo", codigo);
                _comando.Parameters.AddWithValue("@Nombre", nombre);
                _comando.Parameters.AddWithValue("@CupoMaximo", cupoMaximo);
                _comando.Parameters.AddWithValue("@Descripcion", descripcion);
                _comando.Parameters.AddWithValue("@CupoDisponible", cuposDisponibles);
                int filasAfectadas = _comando.ExecuteNonQuery();

                cambio = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return cambio;
        }
        public bool ModificarCorrePromeCredi(Curso curso)
        {
            bool cambio = false;
            try
            {
                _conexion.Open();

                // Consulta SQL para actualizar un curso
                var query = $"UPDATE Cursos SET Correlativas = @Correlativa, PromedioRequerido = @PromedioRequerido, CreditosRequeridos = @CreditosRequeridos WHERE Codigo = @Codigo";
                _comando.CommandText = query;

                // Ajuste de parámetros con los nuevos valores
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("@Codigo", curso.Codigo);
                _comando.Parameters.AddWithValue("@Correlativa", curso.Correlativas);
                _comando.Parameters.AddWithValue("@PromedioRequerido", curso.PromedioRequerido);
                _comando.Parameters.AddWithValue("@CreditosRequeridos", curso.CreditosRequerido);
                int filasAfectadas = _comando.ExecuteNonQuery();

                cambio = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return cambio;
        }

        public bool BorrarCurso(int codigoCurso)
        {
            bool cambio = false;
            try
            {
                _conexion.Open();

                // Consulta SQL para borrar un curso
                var query = "UPDATE Cursos SET Activo = 0 WHERE Codigo = @CodigoCurso";
                _comando.CommandText = query;
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("@CodigoCurso", codigoCurso);

                // Ejecución de la consulta
                int filasAfectadas = _comando.ExecuteNonQuery();
                cambio = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return cambio;
        }
        public List<Curso> ObtenerTodosLosCursos()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                _conexion.Open();
                var query = "SELECT * FROM Cursos";
                _comando.CommandText = query;

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Codigo = reader["Codigo"].ToString()!;
                        string Nombre = reader["Nombre"].ToString()!;
                        string Descripcion = reader["Descripcion"].ToString()!;
                        string CupoMaximo = reader["CupoMaximo"].ToString()!;
                        int CuposDisponibles = Convert.ToInt32(reader["CuposDisponibles"]);
                        string Activo = reader["Activo"].ToString()!;
                        string Dia = reader["Dia"].ToString()!;
                        string Horario = reader["Horario"].ToString()!;
                        string Aula = reader["Aula"].ToString()!;
                        string Correlativas = reader["Correlativas"].ToString()!;
                        string PromedioRequerido = reader["PromedioRequerido"].ToString()!;
                        string CreditosRequeridos = reader["CreditosRequeridos"].ToString()!;
                        Curso curso = new Curso(Nombre, Codigo, Descripcion, CupoMaximo, Dia, Horario, Aula, Correlativas, PromedioRequerido, CreditosRequeridos);
                        curso.CuposDisponibles = CuposDisponibles;
                        curso.Activo = Activo;
                        cursos.Add(curso);
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

            return cursos;
        }
    }
}
