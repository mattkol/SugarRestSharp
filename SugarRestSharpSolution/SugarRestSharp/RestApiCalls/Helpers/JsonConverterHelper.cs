// -----------------------------------------------------------------------
// <copyright file="JsonConverterHelper.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Helpers
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// This class represents JsonConverterHelper class.
    /// </summary>
    internal static class JsonConverterHelper
    {
        /// <summary>
        /// Deserialize json string to C# type.
        /// </summary>
        /// <typeparam name="T">SugarCRM C# model template type.</typeparam>
        /// <param name="content">Json data to deserialize.</param>
        /// <returns>Object instance of type SugarCRM C# model type..</returns>
        public static T Deserialize<T>(string content)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonToDeserialize = content;
            settings.ContractResolver = resolver;

            return JsonConvert.DeserializeObject<T>(content, settings);
        }

        /// <summary>
        /// Deserialize json string to C# object instance based on C# type.
        /// </summary>
        /// <param name="content">Json data to deserialize.</param>
        /// <param name="type">SugarCRM C# model type.</param>
        /// <returns>Object instance.</returns>
        public static object Deserialize(string content, Type type)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonToDeserialize = content;
            settings.ContractResolver = resolver;

            return JsonConvert.DeserializeObject(content, type, settings);
        }

        /// <summary>
        /// Deserialize json JObject to C# object instance.
        /// </summary>
        /// <typeparam name="T">SugarCRM C# model template type.</typeparam>
        /// <param name="jobject">Json JObject data to deserialize.</param>
        /// <returns>Object instance of type T.</returns>
        public static T Deserialize<T>(JObject jobject)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonObjectToDeserialize = jobject;
            settings.ContractResolver = resolver;

            return JsonConvert.DeserializeObject<T>(jobject.ToString(), settings);
        }

        /// <summary>
        /// Deserialize json JObject to C# object instance based on C# type.
        /// </summary>
        /// <param name="jobject">Json JObject data to deserialize.</param>
        /// <param name="type">SugarCRM C# model type.</param>
        /// <returns>Object instance.</returns>
        public static object Deserialize(JObject jobject, Type type)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonObjectToDeserialize = jobject;
            settings.ContractResolver = resolver;

            return JsonConvert.DeserializeObject(jobject.ToString(), type, settings);
        }

        /// <summary>
        /// Serialize C# object list instance to json JArray instance.
        /// </summary>
        /// <param name="objects">Objects to serialize.</param>
        /// <param name="type">SugarCRM C# model type.</param>
        /// <returns>Json JArray instance.</returns>
        public static JArray SerializeList(object objects, Type type)
        {
            string json = JsonConvert.SerializeObject(objects, type, Formatting.Indented, null);
            return JArray.Parse(json);
        }

        /// <summary>
        /// Serialize C# object instance to json JObject instance.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="type">SugarCRM C# model type.</param>
        /// <returns></returns>
        public static JObject Serialize(object obj, Type type)
        {
            string json = JsonConvert.SerializeObject(obj, type, Formatting.Indented, null);
            return JObject.Parse(json);
        }
    }
}