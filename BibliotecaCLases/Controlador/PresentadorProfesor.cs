using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Controlador
{

  
    public class PresentadorProfesor
    {
        public int LegajoObtenido { get; set; }
        private readonly IProfesorVista _profesorVista;
        private readonly CrudProfesor _crudProfesor;

        public PresentadorProfesor(IProfesorVista profesorVista)
        {
            _profesorVista = profesorVista;
            _crudProfesor = new();
            CargarListaProfesores();
            profesorVista.OnEliminarProfesorSolicitada += () => EliminarProfesor();


        }



        public List<Profesor> CargarListaProfesores()
        {            
                List<Profesor> profesores = _crudProfesor.ObtenerProfesoresRegistrados();
            return profesores;
        }

        private void IniciarEdicionProfesor()
        {
            
        }
        public void AgregarProfesor()
        {

            Profesor profesor = _profesorVista.ObtenerDatosNuevoProfesor();
            GestorRegistroProfesores gestorRegistroProfesores = new(profesor);
            if (gestorRegistroProfesores.Validado && gestorRegistroProfesores.VerificarDatosExistentes())
            {
                string mensaje = gestorRegistroProfesores.RegistrarProfesor();
                _profesorVista.MostrarMensaje(mensaje);               
            }
            else
            {
                _profesorVista.MostrarMensaje(gestorRegistroProfesores.MensajeError);
            }
        }
        public void EliminarProfesor()
        {
            string mensaje = _crudProfesor.EliminarProfesor(LegajoObtenido);
            _profesorVista.MostrarMensaje(mensaje);
            _profesorVista.RecargarPrograma();
        }
        public void CargarCursosAsignados(int legajoProfesor)
        {
            Profesor profesor = _crudProfesor.ObtenerProfesorPorLegajo(legajoProfesor);

            if (profesor != null)
            {
                _profesorVista.ActualizarCursosAsignados(profesor.CursosAsignados);
            }
            else
            {
                _profesorVista.MostrarMensaje("Profesor no encontrado.");
            }
        }

    }


}
