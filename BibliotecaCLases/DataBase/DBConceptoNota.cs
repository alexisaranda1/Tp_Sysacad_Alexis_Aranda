using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBConceptoNota:SQLServer
    {
        public DBConceptoNota() 
        {

        }

        public bool Guardar(ConceptoNota conceptoNota)
        {
            bool existe = false;
            try
            {
                _conexion.Open();

                // Si no está inscrito, agrega una nueva fila a la tabla CursosInscriptos
                var query = "INSERT INTO ConceptoNota(LegajoEstudiante, NombreParcial, Nota,CodigoCurso)" +
                "VALUES (@LegajoAgregar, @NombreParcial, @Nota,@CodigoCurso)";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@LegajoAgregar", conceptoNota.Legajo);
                _comando.Parameters.AddWithValue("@NombreParcial", conceptoNota.Nombre);
                _comando.Parameters.AddWithValue("@Nota", conceptoNota.Nota);
                _comando.Parameters.AddWithValue("@CodigoCurso", conceptoNota.Curso);

                int filasAfectadas = _comando.ExecuteNonQuery();

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
    }
}
