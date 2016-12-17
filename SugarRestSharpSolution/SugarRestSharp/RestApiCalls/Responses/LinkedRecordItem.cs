// -----------------------------------------------------------------------
// <copyright file="LinkedRecordItem.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.RestApiCalls.Responses
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents LinkedRecordItem class.
    /// </summary>
    internal class LinkedRecordItem
    {
        /// <summary>
        /// Gets or sets the json link value.
        /// </summary>
        [JsonProperty(PropertyName = "link_value")]
        public JObject Value { get; set; }

        /// <summary>
        /// Gets the json formatted link value.
        /// </summary>
        public JObject FormattedValue
        {
            get
            {
                if (this.Value == null)
                {
                    return null;
                }

                JObject jentity = new JObject();
                IList<string> keys = this.Value.Properties().Select(p => p.Name).ToList();
                foreach (var key in keys)
                {
                    var newKey = (string)this.Value[key]["name"];
                    var newValue = (string)this.Value[key]["value"];
                    jentity.Add(new JProperty(newKey, newValue));
                }

                return jentity;
            }
        }
    }
}
