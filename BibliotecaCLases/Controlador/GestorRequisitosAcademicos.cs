using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Controlador
{
    public class GestorRequisitosAcademicos
    {

        private IRequisitosAcademicosVista _vista;
        private CrudCurso _crudCurso;
        public GestorRequisitosAcademicos(IRequisitosAcademicosVista vista)
        {
            _crudCurso = new CrudCurso();
            _vista = vista;
            _vista.OnListaCursosPedida += MostrarCursos;
            _vista.OnEditarPromedioRequerido += EditarPromedioRequerido;
            _vista.OnEditarCreditosRequeridos += EditarCreditosRequeridos;
            _vista.OnEditarCorrelativas += EditarCorrelativas;
        }
        /// <summary>
        /// Muestra la lista de cursos en la vista.
        /// </summary>
        public void MostrarCursos()
        {

            var listaCursos = _crudCurso.ObtenerListaCursos();
            _vista.MostrarCursos(listaCursos);
        }
        /// <summary>
        /// Obtiene o establece el código del curso.
        /// </summary>
        public string CodigoCurso { get; set; }
        public string CodigoCursoCorrelativa { get; set; }
        public string NuevoPromedio { get; set; }
        public string NuevoCredito { get; set; }
        public Curso ObtenerCursoPorCodigo()
        {
            return _crudCurso.ObtenerCursoPorCodigo(CodigoCurso);
        }

        public void EditarPromedioRequerido()
        {
            Curso curso = ObtenerCursoPorCodigo();
           
            if (curso != null && NuevoPromedio != null)
            {
                if (Validacion.EsNumeroEnRango(NuevoPromedio,6,10))
                {                                   
                    bool valid =  _crudCurso.EstablecerPromedioRequerido(CodigoCurso, NuevoPromedio);
                    Curso curso1 = ObtenerCursoPorCodigo();
                    if (valid) 
                    {
                        _vista.MostrarMensaje("Promedio requerido actualizado con éxito.");                                   
                    }
                    else
                    {
                        _vista.MostrarMensaje("No se puede guardar en la base de datos");
                    }
                }
                else
                {
                    _vista.MostrarMensaje("Ingrese un promedio válido (rango de 6 a 10).");
                }

            }   
        }

        public void EditarCreditosRequeridos()
        {
            Curso curso = ObtenerCursoPorCodigo();
            bool valid = false;

            if (curso != null && NuevoCredito != null)
            {
                if (Validacion.EsNumeroEnRango(NuevoCredito, 0, 100))
                {                    
                        valid = _crudCurso.EstablecerCreditosRequeridos(CodigoCurso, NuevoCredito);
                        Curso cursoActualizado = ObtenerCursoPorCodigo();
                    if (valid) 
                    {
                        _vista.MostrarMensaje("Créditos requeridos actualizados con éxito.");                   
                    }
                    else
                    {
                        _vista.MostrarMensaje("No se puede guardar en la base de datos");
                    }
                }
                else
                {
                    _vista.MostrarMensaje("Ingrese un numero válido (rango de 0 a 100).");
                }

            }        
        }

        public void EditarCorrelativas()
        {
            bool valid = false;
            Curso curso = ObtenerCursoPorCodigo();
            Curso CursoCorrellativa = _crudCurso.ObtenerCursoPorCodigo(CodigoCursoCorrelativa);
            if (curso != null && CursoCorrellativa != null)
            {
    
                if (CodigoCursoCorrelativa !=CodigoCurso)
                {
                    valid = _crudCurso.AgregarCorrelativa(CodigoCurso, CursoCorrellativa.Nombre);
                    Curso cursoActualizado = ObtenerCursoPorCodigo();
                    if (valid)
                    {
                        _vista.MostrarMensaje("Correlativas actualizadas con éxito.");
                    }
                    else
                    {
                        _vista.MostrarMensaje("No se puede guardar en la base de datos");
                    }
                }
                else
                {
                    _vista.MostrarMensaje("Error al agregar correlativa. No puedes agregar el mismo curso como correlativa.");
                }
            }
            else
            {
                _vista.MostrarMensaje("Error al editar las correlativas. Curso no válido.");
            }
        }






    }
}
