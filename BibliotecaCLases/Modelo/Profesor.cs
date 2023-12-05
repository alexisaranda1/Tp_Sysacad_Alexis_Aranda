using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{
    public class Profesor: Usuario
    {
        public string Direccion { get; set; }
        public string Activo { get; set; }
        public string Telefono { get; set; }       
        public string Especializacion { get; set; }
        public List<int> CursosAsignados { get; set; }
        public Profesor(string nombre, string apellido, string dni, string correo, string direccion, string telefono, string clave, string especializacion)
           : base(nombre, apellido, dni, correo, clave, 2)
        {
            Activo = "true";
            Direccion = direccion;
            Telefono = telefono;
            Especializacion = especializacion;
            CursosAsignados = new List<int>();
        }
        public string ObtenerCursosAsignadosComoString()
        {
            return string.Join(", ", CursosAsignados.Select(c => c.ToString()));
        }

    }

}
