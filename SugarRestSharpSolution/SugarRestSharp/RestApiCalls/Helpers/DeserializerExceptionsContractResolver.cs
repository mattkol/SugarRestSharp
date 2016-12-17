// -----------------------------------------------------------------------
// <copyright file="DeserializerExceptionsContractResolver.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// This class represents DeserializerExceptionsContractResolver class.
    /// The class creates exception to some property deserialization.
    /// </summary>
    internal class DeserializerExceptionsContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        /// http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        /// http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        /// "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        /// </summary>
        static DeserializerExceptionsContractResolver instance;

        /// <summary>
        /// Initializes static members of the <see cref="DeserializerExceptionsContractResolver" /> class.
        /// </summary>
        protected DeserializerExceptionsContractResolver() : base() { }

        /// <summary>
        /// Initializes static members of the <see cref="DeserializerExceptionsContractResolver" /> class.
        /// </summary>
        static DeserializerExceptionsContractResolver()
        {
            instance = new DeserializerExceptionsContractResolver();
        }

        /// <summary>
        /// Gets the object instance.
        /// </summary>
        public static DeserializerExceptionsContractResolver Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the json JObject to deserialize.
        /// </summary>
        public JObject JsonObjectToDeserialize { private get; set; }

        /// <summary>
        /// Gets or sets the json string to deserialize.
        /// </summary>
        public string JsonToDeserialize { private get; set; }

        /// <summary>
        /// Gets the json JObject to deserialize.
        /// </summary>
        private JObject JsonObject 
        {
            get
            {
                try
                {
                    if (this.JsonObjectToDeserialize != null)
                    {
                        return this.JsonObjectToDeserialize;
                    }

                    if (!string.IsNullOrEmpty(this.JsonToDeserialize))
                    {
                        return JObject.Parse(this.JsonToDeserialize);
                    }
                }
                catch (Exception)
                {
                    return null;
                }

                return null;
            }
        }

        /// <summary>
        /// Creates a json property for the given C# property.
        /// </summary>
        /// <param name="member">C# property.</param>
        /// <param name="memberSerialization">Serialization option.</param>
        /// <returns>Json property.</returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (this.JsonObject == null)
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
                            IList<string> keys = JsonObject.Properties().Select(p => p.Name).ToList();
                            if (keys.Any(n => n == property.PropertyName))
                            {
                                JProperty jproperty = JsonObject.Properties().SingleOrDefault(p => p.Name == property.PropertyName);
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
                        catch (Exception)
                        {
                            return false;
                        }
                    };
            }

            return property;
        }
    }
}