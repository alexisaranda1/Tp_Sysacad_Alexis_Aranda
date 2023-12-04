﻿using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BibliotecaCLases.Modelo.Usuario;

namespace BibliotecaCLases.Controlador
{
    public class CrudProfesor
    {
        private string _path;
        private string _pathUltimoLegajo;
        private int _ultimoLegajoEnArchivo;
        private List<Profesor> _listaProfesoresRegistrados;
        private Serializador _serializador = new();
        private CrudCurso _crudCurso;

        public CrudProfesor()
        {
            _listaProfesoresRegistrados = new List<Profesor>();
            _path = PathManager.ObtenerRuta("Data", "DataUsuariosProfesores.json");
            _listaProfesoresRegistrados = _serializador.LeerJson<List<Profesor>>(_path) ?? new List<Profesor>();
            _pathUltimoLegajo = PathManager.ObtenerRuta("Data", "LegajoProfesor.json");
            _ultimoLegajoEnArchivo = _serializador.LeerJson<int>(_pathUltimoLegajo);
            _crudCurso = new CrudCurso();
        }

        public string RegistrarProfesor(string nombre, string apellido, string dni, string correo, string direccion, string telefono,string especializacion)
        {
            int legajo = ObtieneLegajo();

            string claveProvisional = GenerarContrasenaAleatoria(7, 12);
            string mensaje = Email.SendMessageSmtp(correo, claveProvisional, nombre, apellido);
            String contrasena = PasswordHashing.GetHash(claveProvisional.ToString());
            Profesor nuevoProfesor = new Profesor(nombre, apellido, dni, correo, direccion, telefono, contrasena, especializacion);
            nuevoProfesor.Legajo = legajo;

            _listaProfesoresRegistrados.Add(nuevoProfesor);

            string path = PathManager.ObtenerRuta("Data", "DataUsuariosProfesores.json");
            _serializador.ActualizarJson(_listaProfesoresRegistrados, path);

            return mensaje;
        }
        public string EliminarProfesor(int legajoProfesor)
        {
            Profesor profesorAEliminar = _listaProfesoresRegistrados.FirstOrDefault(profesor => profesor.Legajo == legajoProfesor);

            if (profesorAEliminar != null)
            {
                profesorAEliminar.Activo = "false";               
                string path = PathManager.ObtenerRuta("Data", "DataUsuariosProfesores.json");
                _serializador.ActualizarJson(_listaProfesoresRegistrados, path);
                return $"El Profesor {profesorAEliminar.Nombre} {profesorAEliminar.Apellido} (Legajo: {profesorAEliminar.Legajo}) ha sido eliminado exitosamente.";

            }
            return "No se pudo eliminar";
        }

        public List<Profesor> ObtenerProfesoresRegistrados()
        {
            _listaProfesoresRegistrados = _serializador.LeerJson<List<Profesor>>(_path) ?? new List<Profesor>();

            if (_listaProfesoresRegistrados.Any())
            {
                return _listaProfesoresRegistrados;
            }
            else
            {
                return new List<Profesor>();
            }
        }

        public Profesor ObtenerProfesorPorLegajo(int legajo)
        {
            return _listaProfesoresRegistrados.FirstOrDefault(profesor => profesor.Legajo == legajo);
        }
        public int VerificarDatosProfesor(string correo, string dni)
        {
            if (_listaProfesoresRegistrados != null)
            {
                if (_listaProfesoresRegistrados.Any(prof => prof.Correo == correo))
                {
                    return 1;
                }
                if (_listaProfesoresRegistrados.Any(prof => prof.Dni == dni))
                {
                    return 2;
                }
            }

            return 0; // Código para indicar que no hay problemas con los datos
        }

        public string ActualizarProfesor(int legajo, string nombre, string apellido, string dni, string correo, string direccion, string telefono,string nuevaEspecializacion)
        {
            Profesor profesorAActualizar = ObtenerProfesorPorLegajo(legajo);

            if (profesorAActualizar != null)
            {
                string mensejeError = "";

                if (ValidarDatos(nombre, apellido, dni, correo, direccion, telefono, out mensejeError))
                {
                    profesorAActualizar.Nombre = nombre;
                    profesorAActualizar.Apellido = apellido;
                    profesorAActualizar.Dni = dni;
                    profesorAActualizar.Correo = correo;
                    profesorAActualizar.Direccion = direccion;
                    profesorAActualizar.Telefono = telefono;
                    profesorAActualizar.Especializacion = nuevaEspecializacion;
                    string path = PathManager.ObtenerRuta("Data", "DataUsuariosProfesores.json");
                    _serializador.ActualizarJson(_listaProfesoresRegistrados, path);

                    return $"Los datos del profesor {profesorAActualizar.Nombre} {profesorAActualizar.Apellido} (Legajo: {profesorAActualizar.Legajo}) han sido actualizados exitosamente.";
                }
                else
                {
                    return $"Los datos no son válidos. Error: {mensejeError}. Por favor, verifique la información proporcionada.";
                }
            }

            return "No se pudo encontrar el profesor.";
        }

        private bool ValidarDatos(string nombre, string apellido, string dni, string correo, string direccion, string telefono, out string mensejeError)
        {
            ValidadorDatos validador = new ValidadorDatos(nombre, apellido, dni, correo, direccion, telefono);
            return validador.Validar(out mensejeError);
        }



        public bool AgregarCursoAProfesor(int legajoProfesor, Curso codigoCurso, out string mensajeError)
        {
            Profesor profesor = ObtenerProfesorPorLegajo(legajoProfesor);

            if (profesor != null)
            {
                //if (profesor.CursosAsignados.Contains(codigoCurso))
                //{
                //    mensajeError = "El profesor ya tiene asignado este curso.";
                //    return false;
                //}

                string mensaje = "";//_crudCurso.AsignarProfesorACurso(codigoCurso);

                if (mensaje == "Asignación exitosa.")
                {
                    //profesor.CursosAsignados.Add(codigoCurso);
                    string path = PathManager.ObtenerRuta("Data", "DataUsuariosProfesores.json");
                    _serializador.ActualizarJson(_listaProfesoresRegistrados, path);
                    mensajeError = null;
                    return true;
                }
                else
                {
                    mensajeError = mensaje;
                    return false;
                }
            }

            mensajeError = "El profesor no se encontró.";
            return false;
        }



        private int ObtieneLegajo()
        {
            _ultimoLegajoEnArchivo++;
            string pathLegajo = PathManager.ObtenerRuta("Data", "LegajoProfesor.json");
            Serializador.GuardarAJson(_ultimoLegajoEnArchivo, pathLegajo);
            return _ultimoLegajoEnArchivo;
        }

        static string GenerarContrasenaAleatoria(int longitudMinima, int longitudMaxima)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=<>?";

            Random random = new Random();
            int longitud = random.Next(longitudMinima, longitudMaxima + 1);
            StringBuilder contrasena = new StringBuilder();

            for (int i = 0; i < longitud; i++)
            {
                int indice = random.Next(caracteresPermitidos.Length);
                char caracterAleatorio = caracteresPermitidos[indice];
                contrasena.Append(caracterAleatorio);
            }

            return contrasena.ToString();
        }



    }

}
