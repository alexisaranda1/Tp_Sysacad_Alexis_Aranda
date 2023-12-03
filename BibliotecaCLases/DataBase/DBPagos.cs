using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    internal class DBPagos : SQLServer
    {
        public DBPagos()
        {

        }
        public bool Guardar(Pago pago)
        {
            bool existe = false;
            try
            {
                _conexion.Open();
                var query = $"INSERT INTO Pago (LegajoEstudiante, MetodoPago, Fecha, MontoTotal) VALUES (@Legajo,@MetodoPago,GETDATE()," +
                    " @MontoTotal)";
                _comando.CommandText = query;
                _comando.Parameters.Clear();
                //Ajuste de parámetros con valores reales
                _comando.Parameters.AddWithValue("@Legajo", pago.IdUsuario);
                _comando.Parameters.AddWithValue("@MontoTotal", pago.MontoTotal);
                _comando.Parameters.AddWithValue("@MetodoPago", pago.MetodoPago);

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
    }
}
