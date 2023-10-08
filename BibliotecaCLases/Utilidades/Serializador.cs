using System;
using System.Collections.Generic;
using System.IO;
using BibliotecaCLases.Modelo;
using Newtonsoft.Json;

namespace BibliotecaCLases.Utilidades
{
    /// <summary>
    /// Clase estática que proporciona métodos para serializar y deserializar objetos a/desde JSON.
    /// </summary>
    public static class Serializador
    {



        /// <summary>
        /// Guarda un diccionario genérico como JSON en un archivo.
        /// </summary>
        /// <typeparam name="T">El tipo de los valores en el diccionario.</typeparam>
        /// <param name="objetoAGuardar">El diccionario que se va a guardar como JSON con Int  y tipo de dato generico .</param>
        /// <param name="path">La ubicación del archivo en la que se guardará el JSON.</param>
        public static void GuardarAJson<T>(Dictionary<int, T> objetoAGuardar, string path)
        {
            try
            {
                // Serializar el diccionario a formato JSON
                string json = JsonConvert.SerializeObject(objetoAGuardar, Newtonsoft.Json.Formatting.Indented);

                // Guardar el JSON en el archivo especificado
                File.WriteAllText(path, json);

                Console.WriteLine($"El diccionario se ha guardado correctamente como JSON en: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el diccionario como JSON: {ex.Message}");
            }
        }


        /// <summary>
        /// Guarda un diccionario en formato JSON en un archivo especificado. - (SOBRECARGA)
        /// </summary>
        /// <typeparam name="T">Tipo de datos de los valores del diccionario.</typeparam>
        /// <param name="objetoAGuardar">Diccionario a guardar como JSON.con String y tipo de dato generico </param>
        /// <param name="path">Ruta del archivo donde se guardará el JSON.</param>
        public static void GuardarAJson<T>(Dictionary<string, T> objetoAGuardar, string path)
        {
            try
            {
                // Serializar el diccionario a formato JSON
                string json = JsonConvert.SerializeObject(objetoAGuardar, Newtonsoft.Json.Formatting.Indented);

                // Guardar el JSON en el archivo especificado
                File.WriteAllText(path, json);

                Console.WriteLine($"El diccionario se ha guardado correctamente como JSON en: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el diccionario como JSON: {ex.Message}");
            }
        }


        // <summary>
        /// Guarda un valor entero en formato JSON en un archivo especificado.(SOBRECARGA)
        /// </summary>
        /// <param name="valorAGuardar">El valor entero a ser serializado y guardado.</param>
        /// <param name="path">La ruta del archivo donde se guardará el JSON.</param>
        public static void GuardarAJson(int valorAGuardar, string path)
        {
            try
            {
                // Serializar el valor a formato JSON
                string json = JsonConvert.SerializeObject(valorAGuardar, Newtonsoft.Json.Formatting.Indented);

                // Guardar el JSON en el archivo especificado
                File.WriteAllText(path, json);

                Console.WriteLine($"El valor se ha guardado correctamente como JSON en: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el valor como JSON: {ex.Message}");
            }
        }



        /// <summary>
        /// Guarda una lista genérica en formato JSON en un archivo especificado.(SOBRECARGA)
        /// </summary>
        /// <typeparam name="T">El tipo de elementos contenidos en la lista.</typeparam>
        /// <param name="objetoAGuardar">La lista genérica que se va a serializar y guardar.</param>
        /// <param name="path">La ruta del archivo donde se guardará el JSON.</param>
        public static void GuardarAJson<T>(List<T> objetoAGuardar, string path)
        {
            try
            {
                // Serializar la lista a formato JSON
                string json = JsonConvert.SerializeObject(objetoAGuardar, Newtonsoft.Json.Formatting.Indented);

                // Guardar el JSON en el archivo especificado
                File.WriteAllText(path, json);

                Console.WriteLine($"La lista se ha guardado correctamente como JSON en: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la lista como JSON: {ex.Message}");
            }
        }


        public static void ActualizarJson<T>(Dictionary<int, T> diccionario, string path)
        {
            try
            {
                // Serializa el diccionario completo a formato JSON
                string jsonResult = JsonConvert.SerializeObject(diccionario, Newtonsoft.Json.Formatting.Indented);

                // Guarda el JSON en el archivo especificado
                File.WriteAllText(path, jsonResult);

                Console.WriteLine($"El diccionario se ha actualizado correctamente como JSON en: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el diccionario como JSON: {ex.Message}");
            }
        }


        public static void ActualizarJson<T>(T objetoAAgregar,int id ,string path)
        {

            try
            {
                Dictionary<string, T> objetoExistente = new Dictionary<string, T>();

                // Si el archivo ya existe, lee el contenido actual
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    objetoExistente = JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
                }
                int nuevaClave = id;
                string nuevaClaveStr = nuevaClave.ToString();

                // Agrega el nuevo objeto al diccionario existente
                objetoExistente[nuevaClaveStr] = objetoAAgregar;

                // Serializa el diccionario completo a formato JSON
                string jsonResult = JsonConvert.SerializeObject(objetoExistente, Newtonsoft.Json.Formatting.Indented);

                // Guarda el JSON en el archivo especificado
                File.WriteAllText(path, jsonResult);

                Console.WriteLine($"El último dato se ha agregado correctamente al archivo JSON en: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el último dato al archivo JSON: {ex.Message}");
            }
        }


        /// <summary>
        /// sobrecarga del metodo ActualizarJson
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objetoAAgregar"></param>
        /// <param name="id"></param>
        /// <param name="path"></param>
        public static void ActualizarJson<T>(T objetoAAgregar, string id, string path)
        {

            try
            {
                Dictionary<string, T> objetoExistente = new Dictionary<string, T>();

                // Si el archivo ya existe, lee el contenido actual
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    objetoExistente = JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
                }
                string nuevaClave = id;
                string nuevaClaveStr = nuevaClave.ToString();

                // Agrega el nuevo objeto al diccionario existente
                objetoExistente[nuevaClaveStr] = objetoAAgregar;

                // Serializa el diccionario completo a formato JSON
                string jsonResult = JsonConvert.SerializeObject(objetoExistente, Newtonsoft.Json.Formatting.Indented);

                // Guarda el JSON en el archivo especificado
                File.WriteAllText(path, jsonResult);

                Console.WriteLine($"El último dato se ha agregado correctamente al archivo JSON en: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el último dato al archivo JSON: {ex.Message}");
            }
        }

        public static T LeerJson<T>(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string jsonString = File.ReadAllText(path);
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    Console.WriteLine($"El archivo JSON no existe en la ruta: {path}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
            }

            return default(T);
        }




        /// <summary>
        /// Elimina un archivo JSON en la ubicación especificada.- (NO IMPLEMENTADO LA BAJA FISICA)
        /// </summary>
        /// <param name="path">La ubicación del archivo JSON que se desea eliminar.</param>
        public static void EliminarJson(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine($"El archivo JSON en la ruta {path} se ha eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine($"El archivo JSON no existe en la ruta: {path}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el archivo JSON: {ex.Message}");
            }
        }
    }
    
}
