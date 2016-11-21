// -----------------------------------------------------------------------
// <copyright file="DeserializerExceptionsContractResolver.cs" company="SugarCrm + PocoGen + REST">
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

    public class DeserializerExceptionsContractResolver : DefaultContractResolver
    {
        protected DeserializerExceptionsContractResolver() : base() { }

        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static DeserializerExceptionsContractResolver instance;

        // Using an explicit static constructor enables lazy initialization.
        static DeserializerExceptionsContractResolver() { instance = new DeserializerExceptionsContractResolver(); }

        public static DeserializerExceptionsContractResolver Instance { get { return instance; } }

        public JObject JsonObjectToDeserialize { get; set; }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (JsonObjectToDeserialize == null)
            {
                return property;
            }

            Type type = Nullable.GetUnderlyingType(property.PropertyType);
            if (type == typeof(DateTime))
            {
                property.ShouldDeserialize =
                    instance =>
                    {
                        try
                        {
                            IList<string> keys = JsonObjectToDeserialize.Properties().Select(p => p.Name).ToList();
                            if (keys.Any(n => n == property.PropertyName))
                            {
                                JProperty jproperty = JsonObjectToDeserialize.Properties().SingleOrDefault(p => p.Name == property.PropertyName);
                                if (jproperty != null)
                                {
                                    string dateValue = jproperty.Value.ToString();

                                    if (string.IsNullOrEmpty(dateValue))
                                    {
                                        return false;
                                    }

                                    DateTime dateTime;
                                    return DateTime.TryParse(dateValue, out dateTime);
                                }
                            }

                            return true;
                        }
                        catch (Exception exception)
                        {
                            return false;
                        }
                    };
            }

            return property;
        }
    }
}