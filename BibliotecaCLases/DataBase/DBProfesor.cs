﻿using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.DataBase
{
    public class DBProfesor: SQLServer
    {
        public DBProfesor() 
        {

        }
        public List<Profesor> ObtenerTodosLosProfesores()
        {
            List<Profesor> profesores = new List<Profesor>();

            try
            {
                _conexion.Open();
                var query = "SELECT * FROM Profesor where Estado = 'true'";
                _comando.CommandText = query;

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int legajo = Convert.ToInt16(reader["Legajo"])!;
                        string nombre = Convert.ToString(reader["Nombre"])!;
                        string apellido = Convert.ToString(reader["Apellido"])!;
                        string dni = Convert.ToString(reader["DNI"])!;
                        string correo = Convert.ToString(reader["Correo"])!;
                        string direccion = Convert.ToString(reader["Direccion"])!;
                        string telefono = Convert.ToString(reader["Telefono"])!;
                        string contraseña = Convert.ToString(reader["Clave"])!;
                        string especializacion = Convert.ToString(reader["Especializacion"])!;

                        Profesor profesorEncontrado = new Profesor(nombre, apellido, dni, correo, direccion, telefono, contraseña, especializacion);
                        profesorEncontrado.Legajo = legajo;
                        profesores.Add(profesorEncontrado);
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

            return profesores;
        }
        public bool Guardar(Profesor profesor)
        {
            bool valid = false;
            try
            {
                _conexion.Open();
                var query = $"INSERT INTO Profesor (Nombre, Apellido, DNI, Correo,Direccion, Telefono,Clave,Especializacion,Estado,TipoUsuario) VALUES (@Nombre," +
                    " @Apellido, @DNI, @Correo,@Direccion,@Telefono,@Clave,@Especializacion,@Estado,@TipoUsuario)";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                // Ajuste de parámetros con valores reales
                _comando.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                _comando.Parameters.AddWithValue("@Apellido", profesor.Apellido);
                _comando.Parameters.AddWithValue("@DNI", profesor.Dni);
                _comando.Parameters.AddWithValue("@Correo", profesor.Correo);
                _comando.Parameters.AddWithValue("@Direccion", profesor.Direccion);
                _comando.Parameters.AddWithValue("@Telefono", profesor.Telefono);
                _comando.Parameters.AddWithValue("@Clave", profesor.Clave);
                _comando.Parameters.AddWithValue("@Especializacion", profesor.Especializacion);
                _comando.Parameters.AddWithValue("@Estado", profesor.Activo);
                _comando.Parameters.AddWithValue("@TipoUsuario", profesor.TipoUsuario);

                //comando.Parameters.Clear();

                var filasAfectadas = _comando.ExecuteNonQuery();
                valid = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return valid;
        }
        public bool BorrarProfe(int legajoABuscar)
        {
            bool cambio = false;
            try
            {
                _conexion.Open();

                // Consulta SQL para borrar un curso
                var query = "UPDATE Profesor SET Estado = 'false' WHERE Legajo = @Legajo";
                _comando.CommandText = query;
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("@Legajo", legajoABuscar);

                // Ejecución de la consulta
                int filasAfectadas = _comando.ExecuteNonQuery();
                cambio = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return cambio;
        }
        public Profesor TraeProfesorPorLegajo(int legajo)
        {
            Profesor profesorEncontrado = null;
            try
            {
                _conexion.Open();

                var query = $"SELECT * FROM Profesor WHERE Legajo = @Legajo";
                _comando.CommandText = query;
                _comando.Parameters.Clear();
                _comando.Parameters.AddWithValue("@Legajo", legajo);

                using (SqlDataReader reader = _comando.ExecuteReader())
                {
                    // Verificar si se encontraron filas
                    if (reader.Read())
                    {
                        int legajoEncontrado = Convert.ToInt16(reader["Legajo"])!;
                        string nombre = Convert.ToString(reader["Nombre"])!;
                        string apellido = Convert.ToString(reader["Apellido"])!;
                        string dni = Convert.ToString(reader["DNI"])!;
                        string correo = Convert.ToString(reader["Correo"])!;
                        string direccion = Convert.ToString(reader["Direccion"])!;
                        string telefono = Convert.ToString(reader["Telefono"])!;
                        string contraseña = Convert.ToString(reader["Clave"])!;
                        string especializacion = Convert.ToString(reader["Especializacion"])!;
                        string activo = Convert.ToString(reader["Estado"])!;

                        profesorEncontrado = new Profesor(nombre, apellido, dni, correo, direccion, telefono, contraseña, especializacion);
                        profesorEncontrado.Legajo = legajoEncontrado;
                        profesorEncontrado.Activo = activo;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
            }
            finally
            {
                _conexion.Close();
            }
            return profesorEncontrado!;
        }
        public bool ModificarProfesor(string nombre, string apellido, string dni, string direccion, string correo, string telefono, string especializacion,int legajo)
        {
            bool cambio = false;
            try
            {
                _conexion.Open();

                // Consulta SQL para actualizar un curso
                var query = $"UPDATE Profesor SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Direccion = @Direccion,Correo = @Correo, Telefono = @Telefono, Especializacion = @Especializacion WHERE Legajo = @Legajo";
                _comando.CommandText = query;

                _comando.Parameters.Clear();
                // Ajuste de parámetros con los nuevos valores
                _comando.Parameters.AddWithValue("@Nombre", nombre);
                _comando.Parameters.AddWithValue("@Apellido", apellido);
                _comando.Parameters.AddWithValue("@DNI", dni);
                _comando.Parameters.AddWithValue("@Direccion", direccion);
                _comando.Parameters.AddWithValue("@Correo", correo);
                _comando.Parameters.AddWithValue("@Telefono", telefono);
                _comando.Parameters.AddWithValue("@Especializacion", especializacion);
                _comando.Parameters.AddWithValue("@Legajo", legajo);
                int filasAfectadas = _comando.ExecuteNonQuery();

                cambio = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return cambio;
        }
        public bool GuardarElCurso(int legajoProfesor,int curso)
        {
            bool valid = false;
            try
            {
                _conexion.Open();
                var query = $"INSERT INTO CursoAsignado (CodigoCurso, LegajoProfesor) VALUES (@CodigoCurso," +
                    " @LegajoProfesor)";
                //var query = $"INSERT INTO Profesor (Nombre, Apellido, Correo, DNI,Clave, TipoUsuario,DebeCambiar,Direccion,Telefono) VALUES ('{estudiante.Nombre}'," +
                //    $" '{estudiante.Apellido}', '{estudiante.Correo}', '{estudiante.Dni}','{estudiante.Clave}','{estudiante.TipoUsuario}',{estudiante.Debecambiar},'{estudiante.Direccion}','{estudiante.Telefono}')";
                _comando.CommandText = query;
                _comando.Parameters.Clear();

                // Ajuste de parámetros con valores reales
                _comando.Parameters.AddWithValue("@CodigoCurso", curso);
                _comando.Parameters.AddWithValue("@LegajoProfesor", legajoProfesor);

                //comando.Parameters.Clear();

                var filasAfectadas = _comando.ExecuteNonQuery();
                valid = filasAfectadas > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conexion.Close();
            }
            return valid;
        }
        public Dictionary<int, Tuple<string, string, string, List<string>>> ObtenerInformacionTodosLosProfesoresConCursos()
        {
            Dictionary<int, Tuple<string, string, string, List<string>>> resultados = new Dictionary<int, Tuple<string, string, string, List<string>>>();

            try
            {
                _conexion.Open();

                var query = @"SELECT P.Legajo, P.Nombre, P.Apellido, P.Telefono, P.Correo, P.Especializacion, ISNULL(C.Nombre, 'Sin Curso Asignado') AS NombreCurso
                      FROM Profesor P
                      LEFT JOIN CursoAsignado CA ON P.Legajo = CA.LegajoProfesor
                      LEFT JOIN Cursos C ON CA.CodigoCurso = C.Codigo";

                _comando.CommandText = query;
                _comando.Parameters.Clear();

                using (var lector = _comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        int legajoProfesor = lector.GetInt32(0);
                        string nombreProfesor = lector.GetString(1);
                        string apellidoProfesor = lector.GetString(2);
                        string especializacionProfesor = lector.GetString(3);
                        string correoProfesor = lector.GetString(4);
                        string telefonoProfesor = lector.GetString(5);
                        string nombreCurso = lector.GetString(6);

                        if (!resultados.ContainsKey(legajoProfesor))
                        {
                            resultados[legajoProfesor] = Tuple.Create(nombreProfesor, apellidoProfesor, telefonoProfesor, new List<string>());
                        }

                        resultados[legajoProfesor].Item4.Add(nombreCurso);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
            }
            finally
            {
                _conexion.Close();
            }

            return resultados;
        }
    }
}
