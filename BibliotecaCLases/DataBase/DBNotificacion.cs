using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBNotificacion: SQLServer
    {
        public DBNotificacion() 
        {

        }
        public bool Guardar(int legajo)
        {
            bool existe = false;
            try
            {
                _conexion.Open();

                // Si no está inscrito, agrega una nueva fila a la tabla CursosInscriptos
                var query = "INSERT INTO NotificacionPendiente(LegajoEstudiante, CorreoEstado)" +
                "VALUES (@LegajoAgregar, 'No Habilitado')";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@LegajoAgregar", legajo);

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
        public bool VerificaLegajo(int legajo)
        {
            bool existe = false;
            try
            {
                _conexion.Open();

                var query = "SELECT COUNT(*) FROM NotificacionPendiente WHERE LegajoEstudiante = @LegajoAgregar";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@LegajoAgregar", legajo);

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
