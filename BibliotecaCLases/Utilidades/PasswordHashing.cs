using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Utilidades
{
    /// <summary>
    /// Clase que proporciona métodos para el hash y validación de contraseñas usando el algoritmo BCrypt.
    /// </summary>
    internal class PasswordHashing
    {

        /// <summary>
        /// Genera un hash para una contraseña dada.
        /// </summary>
        /// <param name="password">La contraseña que se va a hashear.</param>
        /// <returns>El hash de la contraseña.</returns>
        public static string GetHash(string password)
        {
            var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 8);
            return hash;
        }


        /// <summary>
        /// Valida si una contraseña coincide con su hash correspondiente.
        /// </summary>
        /// <param name="password">La contraseña a verificar.</param>
        /// <param name="hash">El hash de referencia para la contraseña.</param>
        /// <returns>true si la contraseña es válida; de lo contrario, false.</returns>
        public static bool ValidatePassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }

    }
}
