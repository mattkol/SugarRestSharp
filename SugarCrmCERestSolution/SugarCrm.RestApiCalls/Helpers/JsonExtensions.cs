// -----------------------------------------------------------------------
// <copyright file="JsonExtensions.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.Helpers
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class JsonExtensions
    {
        /// <summary>
        /// Convert datatable to Json Array object.
        /// </summary>
        /// <param name="properties">Model properties.</param>
        /// <returns>DataTable object</returns>
        public static JObject FirstToJObject(this JArray jarray)
        {
            if (jarray == null)
            {
                return null;
            }

            JToken jtoken = jarray.FirstOrDefault();

            if (jtoken == null)
            {
                return null;
            }

            return (JObject)jtoken;
        }
    }
}
