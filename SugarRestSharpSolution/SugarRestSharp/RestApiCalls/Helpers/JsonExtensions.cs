// -----------------------------------------------------------------------
// <copyright file="JsonExtensions.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// This class represents JsonExtensions class.
    /// </summary>
    internal static class JsonExtensions
    {
        /// <summary>
        /// Converts json string to dynamic object collections datatable.
        /// </summary>
        /// <param name="json">Json string to extend.</param>
        /// <param name="type">The type.</param>
        /// <returns>DataTable object</returns>
        public static IList ToObjects(this string json, Type type)
        {
            IList data = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            JArray jarr = JArray.Parse(json);
            foreach (JObject jobject in jarr.Children<JObject>())
            {
                object tempObject = JsonConverterHelper.Deserialize(jobject.ToString(), type);
                data.Add(tempObject);
            }

            return data;
        }

        /// <summary>
        /// Converts json string to dynamic object datatable.
        /// </summary>
        /// <param name="json">Json string to extend.</param>
        /// <param name="type">The type.</param>
        /// <returns>DataTable object</returns>
        public static object ToObject(this string json, Type type)
        {
            JObject jobject = JObject.Parse(json);
            return JsonConverterHelper.Deserialize(jobject.ToString(), type);
        }
    }
}