using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BibliotecaCLases.Modelo;
using System.Net;

namespace BibliotecaCLases.DataBase
{
    public class SQLServer
    {
        public SqlConnection _conexion;
        public string _cadenaConexion;
        public SqlCommand _comando;

        public SQLServer()
        {
            string Server = ConfigurationManager.AppSettings["DataBaseServer"]!;
            string DatabaseName = ConfigurationManager.AppSettings["DataBaseName"]!;
            _cadenaConexion = @$"Server={Server};Database={DatabaseName};Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";
            _conexion = new SqlConnection(_cadenaConexion);

            _comando = new SqlCommand();
            _comando.CommandType = CommandType.Text;
            _comando.Connection = _conexion;
        }
    }
}
