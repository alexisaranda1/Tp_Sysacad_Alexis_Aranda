using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public List<Tuple<ConceptoPago, string>> ObtenerConceptosPagosPorNombre(string nombreConcepto)
        {
            List<Tuple<ConceptoPago, string>> resultados = new List<Tuple<ConceptoPago, string>>();

            try
            {
                _conexion.Open();

                var query = "SELECT ConceptoPago.*, Estudiante.Nombre AS NombreEstudiante, Estudiante.Apellido as ApellidoEstudiante " +
                            "FROM ConceptoPago " +
                            "INNER JOIN Estudiante ON ConceptoPago.LegajoEstudiante = Estudiante.Legajo " +
                            "WHERE ConceptoPago.Nombre = @NombreConcepto";

                _comando.CommandText = query;
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("@NombreConcepto", nombreConcepto);

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //int ID = Convert.ToInt32(reader["ID"]),
                        //int LegajoEstudiante = Convert.ToInt32(reader["LegajoEstudiante"]),
                        string Nombre = reader["Nombre"].ToString()!;
                        int MontoAPagar = Convert.ToInt32(reader["MontoAPagar"]);
                        int MontoPagado = Convert.ToInt32(reader["MontoPagado"]);
                        ConceptoPago conceptoPago = new ConceptoPago(Nombre, MontoAPagar);
                        conceptoPago.MontoPagado = MontoPagado;

                        // Obtener el nombre del estudiante
                        string nombreEstudiante = reader["NombreEstudiante"].ToString()!;
                        string apellidoEstudiante = reader["ApellidoEstudiante"].ToString()!;

                        resultados.Add(new Tuple<ConceptoPago, string>(conceptoPago, $"{nombreEstudiante} {apellidoEstudiante}"));
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

            return resultados;
        }

    }
}
