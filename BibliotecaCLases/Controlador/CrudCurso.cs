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
        /// <summary>
        /// Constructor de la clase CrudCurso.
        /// </summary>
        public CrudCurso()
        {
            _path = PathManager.ObtenerRuta("Data", "ListaCursos.json");
            listaCursos = serializador.LeerJson<List<Curso>>(_path) ?? new List<Curso>();
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
            Curso nuevoCurso = new Curso(nombre, codigo, descripcion, cupoMaximo, dia, horario, aula);

            if (listaCursos != null)
            {
                listaCursos.Add(nuevoCurso);
                _gestionListasEspera.AgregarCurso(codigo);
                serializador.ActualizarJson(listaCursos, _path);
            }
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
        public string EditarCurso(string codigo, string nuevoCodigo, string nuevoNombre, string nuevaDescripcion, string nuevoCupoMaximo)
        {
            int.TryParse(codigo, out int codigoCurso);
            int.TryParse(nuevoCodigo, out int nuevoCodigoCurso);

            try
            {
                if (listaCursos.Any(curso => curso.Codigo == codigo))
                {
                    Curso cursoExistente = listaCursos.First(curso => curso.Codigo == codigo);

                    if (codigoCurso != nuevoCodigoCurso)
                    {
                        listaCursos.RemoveAll(curso => curso.Codigo == codigo);
                    }

                    cursoExistente.Codigo = nuevoCodigo;
                    cursoExistente.Nombre = nuevoNombre;
                    cursoExistente.Descripcion = nuevaDescripcion;
                    cursoExistente.CupoMaximo = int.Parse(nuevoCupoMaximo);
                    if (cursoExistente.CuposDisponibles > cursoExistente.CupoMaximo)
                    {
                        cursoExistente.CuposDisponibles = int.Parse(nuevoCupoMaximo);
                    }
                    _gestionListasEspera.ActualizarCodigoCurso(codigo, nuevoCodigo);
                    serializador.ActualizarJson(listaCursos, _path);
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

        /// <summary>
        /// Elimina un curso de forma lógica, marcándolo como inactivo en la lista de cursos.
        /// </summary>
        /// <param name="curso">El curso a eliminar.</param>
        /// <returns>Un mensaje que indica si la eliminación fue exitosa o si ocurrió un error.</returns>
        public string EliminarCurso(Curso curso)
        {
            int.TryParse(curso.Codigo, out int codigoCurso);

            if (listaCursos.Any(c => c.Codigo == curso.Codigo))
            {
                Curso cursoAEliminar = listaCursos.First(c => c.Codigo == curso.Codigo);
                cursoAEliminar.Activo = false;

                serializador.ActualizarJson(listaCursos, _path);

                return "Se realizó la eliminación lógica del curso";
            }
            else
            {
                return "El curso no existe en la lista.";
            }
        }

        /// <summary>
        /// Verifica si un código de curso existe en la lista de cursos.
        /// </summary>
        /// <param name="codigo">El código de curso a verificar.</param>
        /// <returns>1 si el código de curso existe, 0 si no existe.</returns>
        public int VerificarCodigoCurso(string codigo)
        {
            if (listaCursos != null && listaCursos.Any(curso => curso.Codigo == codigo))
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Inscribe un estudiante en un curso si hay cupos disponibles.
        /// </summary>
        /// <param name="codigo">El código del curso en el que inscribir al estudiante.</param>
        /// <returns>Un mensaje que indica si la inscripción fue exitosa o si no hay cupos disponibles.</returns>
        public string InscribirEstudianteEnCurso(string codigo)
        {
            if (listaCursos != null)
            {
                int.TryParse(codigo, out int codigoCurso);
                if (listaCursos.Any(curso => curso.Codigo == codigo))
                {
                    Curso curso = listaCursos.First(curso => curso.Codigo == codigo);

                    if (curso.CuposDisponibles > 0)
                    {
                        curso.CuposDisponibles--;
                        serializador.ActualizarJson(listaCursos, _path);
                        return "Inscripción exitosa.";
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
        }

        /// <summary>
        /// Obtiene la lista de cursos completa.
        /// </summary>
        /// <returns>La lista de cursos.</returns>
        public List<Curso> ObtenerListaCursos()
        {
            listaCursos = serializador.LeerJson<List<Curso>>(_path) ?? new List<Curso>();
            return listaCursos;
        }

        /// <summary>
        /// Obtiene un curso por su código.
        /// </summary>
        /// <param name="codigo">El código del curso a obtener.</param>
        /// <returns>El curso correspondiente o un nuevo objeto Curso si no se encuentra.</returns>
        public Curso ObtenerCursoPorCodigo(string codigo)
        {
            int.TryParse(codigo, out int codigoCurso);

            if (listaCursos.Any(curso => curso.Codigo == codigo))
            {
                return listaCursos.First(curso => curso.Codigo == codigo);
            }
            else
            {
                return new Curso("", "", "", "", "", "", "");
            }
        }
        public void AgregarCorrelativa(string codigoCurso, string nombre)
        {
            Curso curso = ObtenerCursoPorCodigo(codigoCurso);
            if (curso != null)
            {

                curso.AgregarCorrelativa(nombre);
                ActualizarListaCursos(curso);
            }
        }

        public void EstablecerPromedioRequerido(string codigoCurso, string promedio)
        {
            Curso curso = ObtenerCursoPorCodigo(codigoCurso);
            if (curso != null)
            {
                curso.EstablecerPromedioRequerido(promedio);
                ActualizarListaCursos(curso);

            }
        }

        public void EstablecerCreditosRequeridos(string codigoCurso, string creditos)
        {
            Curso curso = ObtenerCursoPorCodigo(codigoCurso);
            if (curso != null)
            {
                curso.EstablecerCreditosRequeridos(creditos);
                ActualizarListaCursos(curso);

            }
        }

        private void ActualizarListaCursos(Curso cursoModificado)
        {
            int index = listaCursos.FindIndex(c => c.Codigo == cursoModificado.Codigo);

            if (index != -1)
            {
                listaCursos[index] = cursoModificado;
                serializador.ActualizarJson(listaCursos, _path);
            }
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