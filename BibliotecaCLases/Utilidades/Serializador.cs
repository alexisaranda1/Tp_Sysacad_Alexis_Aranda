using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using BibliotecaCLases.Modelo;
using Newtonsoft.Json;

namespace BibliotecaCLases.Utilidades
{
    /// <summary>
    /// Clase que proporciona métodos para la serialización y deserialización de objetos en formato JSON.
    /// </summary>
    public class Serializador: Archivo
    {
        public Serializador()
        {

        }


        public  void GuardarAJson<T>(List<T> objetoAGuardar, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(objetoAGuardar, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(path, json);


            }
            catch (Exception ex)
            {

            }
        }


        public  void ActualizarJson<T>(List<T> lista, string path)
        {
            try
            {
                string jsonResult = JsonConvert.SerializeObject(lista, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(path, jsonResult);


            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Guarda un diccionario en formato JSON en el archivo especificado.
        /// </summary>
        /// <typeparam name="T">Tipo de los valores del diccionario.</typeparam>
        /// <param name="objetoAGuardar">Diccionario a guardar.</param>
        /// <param name="path">Ruta del archivo donde se guardará el JSON.</param>
        public override void GuardarAJson<T>(Dictionary<int, T> objetoAGuardar, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(objetoAGuardar, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(path, json);

               
            }
            catch (Exception ex)
            {
               
            }
        }

        public static void GuardarAJson(int valorAGuardar, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(valorAGuardar, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(path, json);

               
            }
            catch (Exception ex)
            {
             
            }
        }

        /// <summary>
        /// Actualiza un archivo JSON con un diccionario.
        /// </summary>
        /// <typeparam name="T">Tipo de los valores del diccionario.</typeparam>
        /// <param name="diccionario">Diccionario a actualizar.</param>
        /// <param name="path">Ruta del archivo JSON.</param>
        public override void ActualizarJson<T>(Dictionary<int, T> diccionario, string path)
        {
            try
            {
                string jsonResult = JsonConvert.SerializeObject(diccionario, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(path, jsonResult);

              
            }
            catch (Exception ex)
            {
               
            }
        }

        public static void ActualizarJson<T>(T objetoAAgregar,int id ,string path)
        {
            try
            {
                Dictionary<string, T> objetoExistente = new Dictionary<string, T>();

                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    objetoExistente = JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
                }
                int nuevaClave = id;
                string nuevaClaveStr = nuevaClave.ToString();

                objetoExistente[nuevaClaveStr] = objetoAAgregar;

                string jsonResult = JsonConvert.SerializeObject(objetoExistente, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(path, jsonResult);

                
            }
            catch (Exception ex)
            {
               
            }
        }

        /// <summary>
        /// Lee un archivo JSON y lo deserializa en un objeto del tipo especificado.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a deserializar.</typeparam>
        /// <param name="path">Ruta del archivo JSON.</param>
        /// <returns>El objeto deserializado.</returns>
        public override T LeerJson<T>(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string jsonString = File.ReadAllText(path);
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }

            }
            catch (Exception ex)
            {
              
            }

            return default(T);
        }
    }
}
