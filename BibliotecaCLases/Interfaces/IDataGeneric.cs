using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Interfaces
{
    public interface IDataGeneric
    {
        public void Guardar<T>(T objetoAGuardar);

    }
}
