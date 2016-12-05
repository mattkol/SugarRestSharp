// -----------------------------------------------------------------------
// <copyright file="JsonConverterHelper.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.Helpers
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Reflection;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Linq;

    public static class JsonConverterHelper 
    {
        public static T Deserialize<T>(string content)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonToDeserialize = content;
            settings.ContractResolver = resolver;
            return JsonConvert.DeserializeObject<T>(content, settings);
        }

        public static T Deserialize<T>(JObject jobject)
        {
            var settings = new JsonSerializerSettings();
            DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
            resolver.JsonObjectToDeserialize = jobject;
            settings.ContractResolver = resolver;
            return JsonConvert.DeserializeObject<T>(jobject.ToString(), settings);
        }

        public static List<JObject> Serialize(List<object> objectList, Type type)
        {
            List<JObject> jobjectList = new List<JObject>();

            if ((objectList == null) || (objectList.Count == 0))
            {
                return jobjectList;
            }

            foreach (object obj in objectList)
            {
                string json = JsonConvert.SerializeObject(obj, type, Newtonsoft.Json.Formatting.Indented, null);
                jobjectList.Add(JObject.Parse(json));
            }

            return jobjectList;
        }
    }
}