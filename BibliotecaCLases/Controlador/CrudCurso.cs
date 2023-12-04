using BibliotecaCLases.DataBase;
using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;


namespace BibliotecaCLases.Controlador
{
    /// <summary>
    /// Clase que gestiona la operación CRUD (Crear, Leer, Actualizar, Eliminar) de cursos.
    /// </summary>
    public class CrudCurso
    {
        Serializador serializador = new Serializador();
        private List<Curso> listaCursos;
        private string _path;
        private GestionListasEspera _gestionListasEspera;
        DBCursos dBCurso = new DBCursos();
        DBCursosInscriptos _dBCursosInscriptos = new DBCursosInscriptos();
        /// <summary>
        /// Constructor de la clase CrudCurso.
        /// </summary>
        public CrudCurso()
        {
            listaCursos = dBCurso.ObtenerTodosLosCursos();
            _gestionListasEspera = new GestionListasEspera();
        }

        /// <summary>
        /// Agrega un nuevo curso a la lista de cursos.
        /// </summary>
        /// <param name="nombre">Nombre del curso.</param>
        /// <param name="codigo">Código del curso.</param>
        /// <param name="descripcion">Descripción del curso.</param>
        /// <param name="cupoMaximo">Cupo máximo del curso.</param>
        /// <param name="dia">Día del curso.</param>
        /// <param name="horario">Horario del curso.</param>
        /// <param name="aula">Aula del curso.</param>
        public void AgregarCurso(string nombre, string codigo, string descripcion, string cupoMaximo, string dia, string horario, string aula)
        {
            _gestionListasEspera.AgregarCurso(codigo);
            Curso nuevoCurso = new Curso(nombre, codigo, descripcion, cupoMaximo, dia, horario, aula, "", "6", "0");

            dBCurso.Guardar(nuevoCurso);
        }

        /// <summary>
        /// Edita un curso existente en la lista de cursos.
        /// </summary>
        /// <param name="codigo">Código del curso a editar.</param>
        /// <param name="nuevoCodigo">Nuevo código del curso.</param>
        /// <param name="nuevoNombre">Nuevo nombre del curso.</param>
        /// <param name="nuevaDescripcion">Nueva descripción del curso.</param>
        /// <param name="nuevoCupoMaximo">Nuevo cupo máximo del curso.</param>
        /// <returns>Un mensaje que indica si la edición fue exitosa o si ocurrió un error.</returns>
        public string EditarCurso(string codigo, string nuevoCodigo, string nuevoNombre, string nuevaDescripcion, string nuevoCupoMaximo, int antiguoCuposDispónibles, int antiguoCuposMaximo)
        {
            int.TryParse(codigo, out int codigoCurso);
            int.TryParse(nuevoCodigo, out int nuevoCodigoCurso);
            int.TryParse(nuevoCupoMaximo, out int cupoMaximoNuevo);

            try
            {
                int nuevoCuposDisponibles = ValidoCuposDisponibles(antiguoCuposMaximo, cupoMaximoNuevo, antiguoCuposDispónibles);
                if (dBCurso.ModificarCurso(nuevoNombre, nuevaDescripcion, nuevoCupoMaximo, codigoCurso, nuevoCodigoCurso, nuevoCuposDisponibles) && _gestionListasEspera.ActualizarCodigoCurso(codigo,nuevoCodigo))
                {

                    return "Se modificó correctamente";
                }

                else
                {
                    return "El curso no existe en la lista.";
                }
            }
            catch (Exception ex)
            {
                return "Error al guardar los cambios: " + ex.Message;
            }
        }

        public int ValidoCuposDisponibles(int cuposMaximosAntiguos, int nuevosCuposMaximos, int cuposDisponibles)
        {
            // Calcular la diferencia entre los cupos máximos antiguos y nuevos
            int diferenciaCupos = cuposMaximosAntiguos - nuevosCuposMaximos;

            // Calcular los nuevos cupos disponibles
            int nuevosCuposDisponibles = cuposDisponibles - diferenciaCupos;

            // Verificar que los nuevos cupos disponibles no sean negativos
            if (nuevosCuposDisponibles < 0)
            {
                // Si se vuelven negativos, ajustar a cero (no permitir cupos disponibles negativos)
                nuevosCuposDisponibles = 0;
            }

            return nuevosCuposDisponibles;
        }

        /// <summary>
        /// Elimina un curso de forma lógica, marcándolo como inactivo en la lista de cursos.
        /// </summary>
        /// <param name="curso">El curso a eliminar.</param>
        /// <returns>Un mensaje que indica si la eliminación fue exitosa o si ocurrió un error.</returns>
        public string EliminarCurso(Curso curso)
        {
            int.TryParse(curso.Codigo, out int codigoCurso);

            if (dBCurso.BorrarCurso(codigoCurso))
            {

                return "Se realizó la eliminación lógica del curso";
            }
            else
            {
                return "El curso no existe en la lista.";
            }
        }

        /// <summary>
        /// Inscribe un estudiante en un curso si hay cupos disponibles.
        /// </summary>
        /// <param name="codigo">El código del curso en el que inscribir al estudiante.</param>
        /// <returns>Un mensaje que indica si la inscripción fue exitosa o si no hay cupos disponibles.</returns>
        public string InscribirEstudianteEnCurso(string codigo, int legajo)
        {
            if (listaCursos != null)
            {
                int.TryParse(codigo, out int codigoCurso);
                if (dBCurso.VerificaCodigo(codigo))
                {
                    Curso curso = dBCurso.TraePorCodigo(codigo);

                    if (curso.CuposDisponibles > 0)
                    {
                        curso.CuposDisponibles--;
                        if (_dBCursosInscriptos.AgregarCursosInscriptos(codigoCurso, legajo))
                        {
                            return "Inscripción exitosa.";
                        }
                    }
                    else
                    {
                        return "No hay cupos disponibles para este curso.";
                    }
                }
                else
                {
                    return "El curso no existe en la lista.";
                }
            }
            else
            {
                return "No se encontraron cursos.";
            }
            return "";
        }

        /// <summary>
        /// Obtiene la lista de cursos completa.
        /// </summary>
        /// <returns>La lista de cursos.</returns>
        public List<Curso> ObtenerListaCursos()
        {
            return dBCurso.ObtenerTodosLosCursos();
        }

        /// <summary>
        /// Obtiene un curso por su código.
        /// </summary>
        /// <param name="codigo">El código del curso a obtener.</param>
        /// <returns>El curso correspondiente o un nuevo objeto Curso si no se encuentra.</returns>
        public Curso ObtenerCursoPorCodigo(string codigo)
        {
            return dBCurso.TraePorCodigo(codigo);
        }
        public bool AgregarCorrelativa(string codigoCurso, string nombre)
        {
            bool valid = false;
            Curso curso = ObtenerCursoPorCodigo(codigoCurso);
            if (curso != null)
            {

                curso.AgregarCorrelativa(nombre);
                valid = ActualizarListaCursos(curso);
            }
            return valid;
        }

        public bool EstablecerPromedioRequerido(string codigoCurso, string promedio)
        {
            bool valid = false;
            Curso curso = ObtenerCursoPorCodigo(codigoCurso);
            if (curso != null)
            {
                curso.EstablecerPromedioRequerido(promedio);
                valid = ActualizarListaCursos(curso);
            }
            return valid;
        }

        public bool EstablecerCreditosRequeridos(string codigoCurso, string creditos)
        {
            bool valid = false;
            Curso curso = ObtenerCursoPorCodigo(codigoCurso);
            if (curso != null)
            {
                curso.EstablecerCreditosRequeridos(creditos);
                valid = ActualizarListaCursos(curso);

            }
            return valid;
        }

        private bool ActualizarListaCursos(Curso cursoModificado)
        {
            return dBCurso.ModificarCorrePromeCredi(cursoModificado);
        }



        /// <summary>
        /// Propiedad para obtener o establecer la ruta del archivo JSON de datos.
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}