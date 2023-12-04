using BibliotecaCLases.DataBase;
using BibliotecaCLases.Modelo;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BibliotecaCLases.Controlador
{
    public class CrudReporte
    {
        private List<Reporte> _listaReporte;
        private List<Curso> _listaCurso;
        private List<string> _listaPago;
        private List<Estudiante> _listaEstudiante;
        private DBCursos _dBCurso = new DBCursos();
        private DBConceptoPago _dbConceptoPago = new DBConceptoPago();
        private DBEstudiantes _dbEstudiantes = new DBEstudiantes();
        private DBGeneric _dBGeneric = new DBGeneric(); 
        private DBListaDeEspera _dBListaDeEspera = new DBListaDeEspera();   
        public CrudReporte()
        {

        }

        public List<Reporte> ObtenerTodosLosReportes() 
        {
            _listaReporte = new List<Reporte>
            {
                new Reporte("Informe de inscripciones por período"),
                new Reporte("Informe de estudiantes inscritos en un curso específico."),
                new Reporte("Informe de ingresos por conceptos de pago."),
                new Reporte("Informe de listas de espera de cursos.")
            };

            return _listaReporte;
        }

        public List<Curso> ObtenerTodosLosCursos()
        {
            _listaCurso = new List<Curso>();
            _listaCurso = _dBCurso.ObtenerTodosLosCursos();
            return _listaCurso;
        }

        public List<string> ObtenerTodosLosPagos()
        {
            _listaPago = new List<string>
            {
                new string("Noviembre"),
                new string("Diciembre"),
                new string("Febrero")
            };
            return _listaPago;
        }

        public List<Estudiante> ObtenerTodosLosEstudiante()
        {
            _listaEstudiante = new List<Estudiante>();
            _listaEstudiante = _dbEstudiantes.ObtenerTodosLosEstudiantes();
            return _listaEstudiante;
        }

        public string GeneraReportePorMateriaPeriodo(bool valido,string materia)
        {
            StringBuilder comprobante = new StringBuilder();
            List<Estudiante> estudiantesABuscar = _dbEstudiantes.ObtenerTodosLosEstudiantes();
            if (valido)
            {
                DateTime dateTime = DateTime.Now;
                comprobante.AppendLine($"Informe Detallado de Estudiantes Inscritos en: {materia}");
                comprobante.AppendLine($"Fecha Al Dia Del Informe: {dateTime.ToString("yyyy-MM-dd")}\n");
                foreach (Estudiante estudiante in estudiantesABuscar)
                {
                    comprobante.AppendLine($"Estudiante: {estudiante.Nombre} {estudiante.Apellido}");
                    comprobante.AppendLine($"Correo: {estudiante.Correo}");
                    comprobante.AppendLine("=================");
                }
            }
            return comprobante.ToString();
        }

        public string GeneraReportePorPago(bool valido, string nombrePago)
        {
            StringBuilder comprobante = new StringBuilder();
            List<Tuple<ConceptoPago, string>> conceptoYNombre = new List<Tuple<ConceptoPago, string>>();
            conceptoYNombre = _dBGeneric.ObtenerConceptosPagosPorNombre(nombrePago);
            if (valido)
            {
                DateTime dateTime = DateTime.Now;
                comprobante.AppendLine($"Informe Detallado de Ingresos de pago en : {nombrePago}");
                comprobante.AppendLine($"Fecha Al Dia Del Informe: {dateTime.ToString("yyyy-MM-dd")}\n");
                foreach (var resultado in conceptoYNombre)
                {
                    ConceptoPago conceptoPago = resultado.Item1;
                    string nombreApellidoAlumno = resultado.Item2;
                    string[] partesNombreApellido = nombreApellidoAlumno.Split(' ');
                    comprobante.AppendLine($"Estudiante: {partesNombreApellido[0]} {partesNombreApellido[1]}");
                    comprobante.AppendLine($"Monto A Pagar: {conceptoPago.MontoAPagar}$");
                    comprobante.AppendLine($"Monto Pagado: {conceptoPago.MontoPagado}$");
                    comprobante.AppendLine("=================");
                }
            }
            return comprobante.ToString();
        }
        public string GeneraReportePorEspera(bool valido, string materiaEspera, List<Curso> lista)
        {
            StringBuilder comprobante = new StringBuilder();
            Curso espera = buscoCursoPorMateria(lista, materiaEspera);
            Dictionary<Estudiante, DateTime> estudiantesYFechas = _dBListaDeEspera.ObtenerEstudiantesYFechasEnEsperaPorCurso(espera.Codigo);
            
            if (valido)
            {
                DateTime dateTime = DateTime.Now;
                comprobante.AppendLine($"Informe Detallado de Alumnos en Espera en la materia : {espera.Nombre}");
                comprobante.AppendLine($"Fecha Al Dia Del Informe: {dateTime.ToString("yyyy-MM-dd")}\n");

                foreach (var kvp in estudiantesYFechas)
                {
                    Estudiante estudiante = kvp.Key;
                    DateTime fecha = kvp.Value;
                    comprobante.AppendLine($"Estudiante: {estudiante.Nombre} {estudiante.Apellido}");
                    comprobante.AppendLine($"Fecha de espera: {fecha}$");
                    comprobante.AppendLine("=================");
                }
            }
            return comprobante.ToString();
        }

        public Curso buscoCursoPorMateria(List<Curso> lista,string materia)
        {
            Curso cursoEncontrado = null;
            foreach(Curso curso in lista)
            {
                if(curso.Nombre == materia)
                {
                    cursoEncontrado= curso;
                }
            }
            return cursoEncontrado!;
        }
    }
}
