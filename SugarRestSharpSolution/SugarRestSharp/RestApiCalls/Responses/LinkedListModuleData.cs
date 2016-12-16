// -----------------------------------------------------------------------
// <copyright file="LinkedListModuleData.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Responses
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RestApiCalls.Responses;
    using System.Collections.Generic;

    /// <summary>
    /// Represents LinkedListModuleData class
    /// </summary>
    internal class LinkedListModuleData
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
        public List<LinkedRecordItem> Records { get; set; }

        public List<JObject> FormattedRecords
        {
            get
            {
                var entities = new List<JObject>();
                if (Records == null)
                {
                    return new List<JObject>();
                }

                foreach (LinkedRecordItem item in Records)
                {
                    entities.Add(item.FormattedValue);
                }

                return entities;
            }
        }
    }
}
