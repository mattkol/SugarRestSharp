// -----------------------------------------------------------------------
// <copyright file="LinkedListModule.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.RestApiCalls.Responses
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Linq;

    internal class LinkedRecordItem
    {
        [JsonProperty(PropertyName = "link_value")]
        public JObject Value { get; set; }

        public JObject FormattedValue
        {
            get
            {
                if (Value == null)
                {
                    return null;
                }

                JObject jentity = new JObject();
                IList<string> keys = Value.Properties().Select(p => p.Name).ToList();
                foreach (var key in keys)
                {
                    var newKey = (string) Value[key]["name"];
                    var newValue = (string) Value[key]["value"];
                    jentity.Add(new JProperty(newKey, newValue));
                }

                return jentity;
            }
        }
    }
}
