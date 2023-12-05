using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{
    public class Notificacion
    {
        private int _legajoEstudiante;
        private string _correoEstado;

        public Notificacion(int legajoEstudiante,string correoEstado)
        {
            _legajoEstudiante = legajoEstudiante;
            _correoEstado = correoEstado;
        }

        public int LegajoEstudiante 
        { 
            get { return _legajoEstudiante; }
            set { _legajoEstudiante = value; } 
        }

        public string CorreoEstado 
        {
            get {return _correoEstado; }
            set {_correoEstado = value; } 
        }
    }
}
