using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBConceptoPago : SQLServer
    {
        public DBConceptoPago()
        {

        }
        public bool Guardar(int legajo)
        {
            bool existe = false;
            try
            {
                _conexion.Open();

                // Si no está inscrito, agrega una nueva fila a la tabla CursosInscriptos
                var query = "INSERT INTO ConceptoPago(LegajoEstudiante, Nombre, MontoAPagar, MontoPagado)" +
                "VALUES (@LegajoAgregar, 'Noviembre', 25000, 0), (@LegajoAgregar, 'Diciembre', 25000, 0), (@LegajoAgregar, 'Febrero', 25000, 0)";
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

        public List<ConceptoPago> ObtenerTodosLosPagos()
        {
            List<ConceptoPago> pago = new List<ConceptoPago>();

            try
            {
                _conexion.Open();
                var query = "SELECT * FROM ConceptoPago";
                _comando.CommandText = query;

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Nombre = reader["Nombre"].ToString()!;
                        int montoAPagar = Convert.ToInt16(reader["MontoAPagar"])!;
                        int montoPagado = Convert.ToInt16(reader["MontoPagado"])!;
                        ConceptoPago conceptoPago = new ConceptoPago(Nombre,montoAPagar);
                        conceptoPago.MontoPagado = montoPagado;
                        pago.Add(conceptoPago);
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

            return pago;
        }

        public bool ActualizarConceptoPago(int legajo, string nombre, int montoPagado, int nuevoMontoAPagar)
        {
            bool actualizacionExitosa = false;

            try
            {
                _conexion.Open();

                var query = "UPDATE ConceptoPago SET MontoPagado = @MontoPagado, MontoAPagar = @NuevoMontoAPagar WHERE LegajoEstudiante = @Legajo AND Nombre = @Nombre";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@Legajo", legajo);
                _comando.Parameters.AddWithValue("@Nombre", nombre);
                _comando.Parameters.AddWithValue("@MontoPagado", montoPagado);
                _comando.Parameters.AddWithValue("@NuevoMontoAPagar", nuevoMontoAPagar);

                int filasAfectadas = _comando.ExecuteNonQuery();
                actualizacionExitosa = filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
            }
            finally
            {
                _conexion.Close();
            }

            return actualizacionExitosa;
        }

        public List<ConceptoPago> TraerConceptosPagoPorLegajo(int legajo)
        {
            List<ConceptoPago> conceptosPago = new List<ConceptoPago>();

            try
            {
                _conexion.Open();

                var query = "SELECT * FROM ConceptoPago WHERE LegajoEstudiante = @Legajo";
                _comando.CommandText = query;

                _comando.Parameters.Clear();

                _comando.Parameters.AddWithValue("@Legajo", legajo);

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader["Nombre"].ToString()!;
                        int montoAPagar = Convert.ToInt32(reader["MontoAPagar"]);
                        int montoPagado = Convert.ToInt32(reader["MontoPagado"]);

                        ConceptoPago concepto = new ConceptoPago(nombre, montoAPagar);
                        concepto.MontoPagado = montoPagado;
                        conceptosPago.Add(concepto);
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

            return conceptosPago;
        }
    }
}
