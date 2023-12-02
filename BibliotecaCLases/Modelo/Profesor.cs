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
        public string Telefono { get; set; }       
        public List<string> AreasEspecializacion { get; set; }
        public List<string> CursosAsignados { get; set; }
        
        public Profesor(string nombre,string apellido,string dni, string correo, string direccion, string telefono, string clave)
           : base(nombre, apellido, dni, correo, clave, 2)
        {
            Direccion = direccion;
            Telefono = telefono;    
            AreasEspecializacion = new List<string>();
            CursosAsignados = new List<string>();
        }
    }

}
