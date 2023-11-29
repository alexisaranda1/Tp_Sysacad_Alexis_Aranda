using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    internal class DBPagos:SQLServer
    {
        public DBPagos() 
        {

        }
        public void Guardar(Pago pago)
        {
            try
            {
                _conexion.Open();
                var query = $"INSERT INTO Cursos (IdUsuario, Fecha, NombreUsuario, ApellidoUsuario, MontoTotal,MetodoPago) VALUES (@IdUsuario, @Fecha," +
                    " @NombreUsuario, @ApellidoUsuario, @MontoTotal,@MetodoPago)";
                _comando.CommandText = query;

                //Ajuste de parámetros con valores reales
                _comando.Parameters.AddWithValue("@IdUsuario", pago.IdUsuario);
                _comando.Parameters.AddWithValue("@Fecha", pago.Fecha);
                _comando.Parameters.AddWithValue("@NombreUsuario", pago.NombreUsuario);
                _comando.Parameters.AddWithValue("@ApellidoUsuario", pago.ApellidoUsuario);
                _comando.Parameters.AddWithValue("@MontoTotal", pago.MontoTotal);
                _comando.Parameters.AddWithValue("@MetodoPago", pago.MetodoPago);

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
    }
}
