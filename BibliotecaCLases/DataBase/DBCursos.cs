using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBCursos:SQLServer
    {
        public DBCursos() 
        {

        }
        public void Guardar(Curso curso)
        {
            try
            {
                _conexion.Open();
                var query = $"INSERT INTO Cursos (Codigo, Nombre, Descripcion, CupoMaximo, CuposDisponibles,Activo, Dia,Horario,Aula) VALUES (@Codigo, @Nombre," +
                    " @Descripcion, @CupoMaximo, @CuposDisponibles,@Activo,@Dia,@Horario,@Aula)";
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
                // Manejo de excepciones
            }
            finally
            {
                _conexion.Close();
            }

            return existe;
        }
        public void ModificarCurso(string nombre, string descripcion, string cupoMaximo, string codigo)
        {
            try
            {
                _conexion.Open();

                // Consulta SQL para actualizar un curso
                var query = $"UPDATE Cursos SET Codigo = @Codigo, Nombre = @Nombre, CupoMaximo = @CupoMaximo, Descripcion = @Descripcion";
                _comando.CommandText = query;

                // Ajuste de parámetros con los nuevos valores
                _comando.Parameters.AddWithValue("@Codigo", codigo);
                _comando.Parameters.AddWithValue("@Nombre", nombre);
                _comando.Parameters.AddWithValue("@CupoMaximo", cupoMaximo);
                _comando.Parameters.AddWithValue("@Descripcion", descripcion);

                // Ejecución de la consulta
                int filasAfectadas = _comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("Registro actualizado exitosamente");
                }
                else
                {
                    Console.WriteLine("No se encontró el curso con el código proporcionado");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
        }

        public void BorrarCurso(int codigoCurso)
        {
            try
            {
                _conexion.Open();

                // Consulta SQL para borrar un curso
                var query = "DELETE FROM Cursos WHERE CodigoCurso = @CodigoCurso";
                _comando.CommandText = query;

                // Ajuste de parámetros con el código del curso a borrar
                _comando.Parameters.AddWithValue("@CodigoCurso", codigoCurso);

                // Ejecución de la consulta
                int filasAfectadas = _comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("Registro borrado exitosamente");
                }
                else
                {
                    Console.WriteLine("No se encontró el curso con el código proporcionado");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
        }

    }
}
