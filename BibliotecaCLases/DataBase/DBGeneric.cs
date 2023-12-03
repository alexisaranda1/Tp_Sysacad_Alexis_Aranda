using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBGeneric : SQLServer
    {
        public DBGeneric()
        {

        }

        public bool AutenticarUsuario(string dni, string tabla)
        {
            bool existe = false;

            try
            {
                _conexion.Open();

                var query = $"SELECT COUNT(*) FROM {tabla} WHERE DNI = '{dni}'";
                _comando.CommandText = query;

                //_comando.Parameters.AddWithValue("@DNI", dni);

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
    }
}
