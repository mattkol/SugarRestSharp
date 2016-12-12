// -----------------------------------------------------------------------
// <copyright file="LinkedModuleData.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Responses
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents LinkedModuleData class
    /// </summary>
    internal class LinkedModuleData
    {

        /// <summary>
        /// Gets or sets the linked module name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string ModuleName { get; set; }

        /// <summary>
        /// Gets or sets the linked module data.
        /// </summary>
        [JsonProperty(PropertyName = "records")]
        public List<JObject> Records { get; set; }

        public List<JObject> FormattedRecords
        {
            get
            {
                var entities = new List<JObject>();
                if (Records == null)
                {
                    return new List<JObject>();
                }

                foreach (JObject item in Records)
                {
                    JObject jentity = new JObject();
                    IList<string> keys = item.Properties().Select(p => p.Name).ToList();
                    foreach (var key in keys)
                    {
                        var newKey = (string) item[key]["name"];
                        var newValue = (string) item[key]["value"];
                        jentity.Add(new JProperty(newKey, newValue));
                    }

                    entities.Add(jentity);
                }

                return entities;
            }
        }
    }
}
