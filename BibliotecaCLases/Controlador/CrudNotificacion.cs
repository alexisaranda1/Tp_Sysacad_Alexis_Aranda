using BibliotecaCLases.DataBase;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Controlador
{
    public class CrudNotificacion
    {
        DBEstudiantes _dBEstudiante =   new DBEstudiantes();
        DBNotificacion _dBNotificacion = new DBNotificacion();
        public CrudNotificacion()
        {

        }

        public async Task enviar()
        {
            await EnviaNotificacionMesPagoAsync();
            await EnviaNotificacionInicioClasesAsync();
        }
        public async Task EnviaNotificacionMesPagoAsync()
        {
            await Task.Run(() =>
            {
                StringBuilder reporte = GeneraReporteMes();
                List<Estudiante> listEstudiante = _dBEstudiante.ObtenerTodosLosEstudiantes();

                Parallel.ForEach(listEstudiante, estudiante =>
                {
                    bool valid = Email.EnviarNotificacion(estudiante, reporte.ToString());
                    if (!valid)
                    {
                        GuardarMailNoEnviados(estudiante.Legajo);
                    }
                });
            });
        }
        public async Task EnviaNotificacionInicioClasesAsync()
        {
            await Task.Run(() =>
            {
                StringBuilder reporte = GeneraReporteInicioClases();
                List<Estudiante> listEstudiante = _dBEstudiante.ObtenerTodosLosEstudiantes();

                Parallel.ForEach(listEstudiante, estudiante =>
                {
                    bool valid = Email.EnviarNotificacion(estudiante, reporte.ToString());
                    if (!valid)
                    {
                        GuardarMailNoEnviados(estudiante.Legajo);
                    }
                });
            });
        }
        public void EnviaNotificacionInscripcionCurso()
        {
            StringBuilder reporte = GeneraReporteInscripcionCurso();
            List<Estudiante> listEstudiante = _dBEstudiante.ObtenerTodosLosEstudiantes();
            foreach (Estudiante estudiante in listEstudiante)
            {
                bool valid = Email.EnviarNotificacion(estudiante, reporte.ToString());
                if (!valid)
                {
                    GuardarMailNoEnviados(estudiante.Legajo);
                }
            }
        }
        public StringBuilder GeneraReporteInscripcionCurso()
        {
            StringBuilder reporte = new StringBuilder();
            DateTime hoy = DateTime.Now;
            if (DateTime.Now.Month == 3 || DateTime.Now.Month == 8)
            {
                reporte.AppendLine($"Aviso de inscripcion a curso el dia {hoy}");
                reporte.AppendLine("Estimado alumno,\n\nEste es un aviso del Systema Sysacad de que se registro en una nueva materia.");
                reporte.AppendLine("Si este mensaje llego por error o no se inscribio porfavor ignorar");
                reporte.AppendLine("¡Gracias!");
            }
            return reporte;
        }
        public StringBuilder GeneraReporteInicioClases()
        {
            StringBuilder reporte = new StringBuilder();
            DateTime hoy = DateTime.Now;
            if (DateTime.Now.Month == 3 || DateTime.Now.Month == 8)
            {
                string mesActual = hoy.ToString("MMMM");
                reporte.AppendLine($"Recordatorio de Inicio de Clases -{mesActual}");
                reporte.AppendLine("Estimado alumno,\n\nEste es un recordatorio del Systema Sysacad de que el inicio de cuatrimestre se acerca.");
                reporte.AppendLine("No olvide inscribirse a las materias requeridas");
                reporte.AppendLine("¡Gracias!");
            }
            return reporte;
        }

        public StringBuilder GeneraReporteMes()
        {
            StringBuilder reporte = new StringBuilder();
            DateTime hoy = DateTime.Now;
            if(DateTime.Now.Day == 1 && DateTime.Now.Month != 1)
            {
                string mesActual = hoy.ToString("MMMM"); 
                reporte.AppendLine($"Recordatorio de pago -{mesActual}");
                reporte.AppendLine("Estimado alumno,\n\nEste es un recordatorio del Systema Sysacad de que el pago para este mes debe realizarse. ¡Gracias!");
            }
            return reporte;
        }

        public void GuardarMailNoEnviados(int legajo)
        {
            if (_dBNotificacion.VerificaLegajo(legajo)) 
            {
                _dBNotificacion.Guardar(legajo);
            }
        }
    }
}
