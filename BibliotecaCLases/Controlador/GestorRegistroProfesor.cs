using BibliotecaCLases.Controlador;
using BibliotecaCLases.Modelo;

public class GestorRegistroProfesores
{
    private CrudProfesor crudProfesor;
    private bool _validado;
    private Profesor _profesor;
    private string _mensajeError;
    private ValidadorDatos _validadorDatos;

    public GestorRegistroProfesores(Profesor profesor)
    {
        _profesor = profesor;
        _validadorDatos = new ValidadorDatos(_profesor.Nombre, _profesor.Apellido, _profesor.Dni, _profesor.Correo, _profesor.Direccion, _profesor.Telefono);

        _validado = _validadorDatos.Validar(out string mensajeError);

        if (_validado)
        {
            crudProfesor = new CrudProfesor();
        }
        else
        {
            _mensajeError = mensajeError;
        }
    }

    public bool VerificarDatosExistentes()
    {
        int numeroError = crudProfesor.VerificarDatosProfesor(_profesor.Correo, _profesor.Dni);

        if (numeroError == 1)
        {
            _mensajeError = "Error: El correo electrónico ya está registrado.";
            return false;
        }
        else if (numeroError == 2)
        {
            _mensajeError = "Error: El número de identificación (DNI) ya está registrado.";
            return false;
        }

        return true;
    }

    public string RegistrarProfesor()
    {
        return crudProfesor.RegistrarProfesor(_profesor.Nombre, _profesor.Apellido, _profesor.Dni, _profesor.Correo, _profesor.Direccion, _profesor.Telefono, _profesor.Especializacion);
    }

    public bool Validado
    {
        get { return _validado; }
        set { _validado = value; }
    }

    public string MensajeError
    {
        get { return _mensajeError; }
        set { _mensajeError = value; }
    }
}
