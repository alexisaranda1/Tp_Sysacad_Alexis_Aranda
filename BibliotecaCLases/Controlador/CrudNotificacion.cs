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

        public void EnviaNotificacionMesPago()
        {
            StringBuilder reporte = GeneraReporteMes();
            List<Estudiante> listEstudiante = _dBEstudiante.ObtenerTodosLosEstudiantes();
            foreach(Estudiante estudiante in listEstudiante)
            {
                bool valid = Email.EnviarNotificacion(estudiante, reporte.ToString());
                if (!valid ) 
                {
                    GuardarMailNoEnviados(estudiante.Legajo);
                }
            }
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
