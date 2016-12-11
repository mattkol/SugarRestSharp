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

    internal static class JsonConverterHelper
    {
        public static T Deserialize<T>(string content)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonToDeserialize = content;
            settings.ContractResolver = resolver;

            return JsonConvert.DeserializeObject<T>(content, settings);
        }

        public static object Deserialize(string content, Type type)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonToDeserialize = content;
            settings.ContractResolver = resolver;

            return JsonConvert.DeserializeObject(content, type, settings);
        }

        public static T Deserialize<T>(JObject jobject)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonObjectToDeserialize = jobject;
            settings.ContractResolver = resolver;

            return JsonConvert.DeserializeObject<T>(jobject.ToString(), settings);
        }

        public static object Deserialize(JObject jobject, Type type)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonObjectToDeserialize = jobject;
            settings.ContractResolver = resolver;

            return JsonConvert.DeserializeObject(jobject.ToString(), type, settings);
        }

        public static JArray SerializeList(object objects, Type type)
        {
            string json = JsonConvert.SerializeObject(objects, type, Formatting.Indented, null);
            return JArray.Parse(json);
        }

        public static JObject Serialize(object obj, Type type)
        {
            string json = JsonConvert.SerializeObject(obj, type, Formatting.Indented, null);
            return JObject.Parse(json);
        }
    }
}