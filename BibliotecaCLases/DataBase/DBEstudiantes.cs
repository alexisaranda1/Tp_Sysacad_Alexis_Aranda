using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBEstudiantes<T>:SQLServer where T : Estudiante
    {
        public DBEstudiantes()
        {

        }

        public void Guardar(Estudiante estudiante)
        {
            try
            {
                _conexion.Open();
                var query = $"INSERT INTO Estudiante (Legajo, Nombre, Apellido, Correo, DNI,Clave, TipoUsuario,DebeCambiar,Direccion,Telefono,CursosInscriptos,EstadoDePago) VALUES (@Legajo, @Nombre," +
                    " @Apellido, @Correo, @Dni,@Clave,@TipoUsuario,@DebeCambiar,@Direccion,@Telefono,@CursosInscriptos,@EstadoDePago)";
                _comando.CommandText = query;

                // Ajuste de parámetros con valores reales
                _comando.Parameters.AddWithValue("@Legajo", estudiante.Legajo);
                _comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                _comando.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                _comando.Parameters.AddWithValue("@Correo", estudiante.Correo);
                _comando.Parameters.AddWithValue("@Dni", estudiante.Dni);
                _comando.Parameters.AddWithValue("@Clave", estudiante.Clave);
                _comando.Parameters.AddWithValue("@TipoUsuario", estudiante.TipoUsuario);
                _comando.Parameters.AddWithValue("@DebeCambiar", estudiante.Debecambiar);
                _comando.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                _comando.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
                _comando.Parameters.AddWithValue("@CursosInscriptos", estudiante.CursosInscriptos);
                _comando.Parameters.AddWithValue("@EstadoPago", estudiante.EstadoDePago);

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

        public bool VerificaDni(string dni)
        {
            bool existe = false;

            try
            {
                _conexion.Open();

                var query = "SELECT COUNT(*) FROM Estudiante WHERE DNI = @Dni";
                _comando.CommandText = query;

                _comando.Parameters.AddWithValue("@DNI", dni);

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

        public bool VerificaMail(string mail)
        {
            bool existe = false;

            try
            {
                _conexion.Open();

                var query = "SELECT COUNT(*) FROM Estudiante WHERE Correo = @Mail";
                _comando.CommandText = query;

                _comando.Parameters.AddWithValue("@Mail", mail);

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
