namespace BibliotecaCLases.Modelo
{

    /// <summary>
    /// La clase Administrador representa un tipo de usuario con privilegios administrativos en la biblioteca.
    /// Hereda las propiedades y métodos de la clase base Usuario.
    /// </summary>
    public class Administrador : Usuario
    {


        /// <summary>
        /// Constructor de la clase Administrador.
        /// </summary>
        /// <param name="nombre">El nombre del administrador.</param>
        /// <param name="apellido">El apellido del administrador.</param>
        /// <param name="dni">El número de identificación del administrador.</param>
        /// <param name="correo">La dirección de correo electrónico del administrador.</param>
        /// <param name="clave">La contraseña del administrador.</param>
        public Administrador(string nombre, string apellido, string dni, string correo, string clave)
            : base(nombre, apellido, dni,correo ,clave, 0)
        {

        }

    }
}