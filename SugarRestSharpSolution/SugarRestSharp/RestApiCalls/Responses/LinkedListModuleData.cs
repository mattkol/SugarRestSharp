// -----------------------------------------------------------------------
// <copyright file="LinkedListModuleData.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RestApiCalls.Responses;

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

        /// <summary>
        /// Gets the formatted record in json.
        /// </summary>
        public List<JObject> FormattedRecords
        {
            get
            {
                var entities = new List<JObject>();
                if (this.Records == null)
                {
                    return new List<JObject>();
                }

                foreach (LinkedRecordItem item in this.Records)
                {
                    entities.Add(item.FormattedValue);
                }

                return entities;
            }
        }
    }
}
