using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBConceptoAsistencia:SQLServer
    {
        public DBConceptoAsistencia()
        {

        }
        public bool Guardar(ConceptoAsistencia conceptoAsistencia)
        {
            bool existe = false;
            try
            {
                _conexion.Open();

                var query = "INSERT INTO ConceptoAsistencia(LegajoEstudiante, Estado,CodigoCurso)" +
                "VALUES (@LegajoAgregar,@Estado,@CodigoCurso)";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@LegajoAgregar", conceptoAsistencia.Legajo);
                _comando.Parameters.AddWithValue("@Estado", conceptoAsistencia.EstadoAsistencia);
                _comando.Parameters.AddWithValue("@CodigoCurso", conceptoAsistencia.CodigoCurso);

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
