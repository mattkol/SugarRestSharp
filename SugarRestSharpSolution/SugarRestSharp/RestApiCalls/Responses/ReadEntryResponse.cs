// -----------------------------------------------------------------------
// <copyright file="ReadEntryResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Responses
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents ReadEntryResponse class
    /// </summary>
    internal class ReadEntryResponse : BaseResponse
    {
        /// <summary>
        /// Gets the entity returned from SugarCrm to json array object
        /// </summary>
        [JsonIgnore]
        public JObject Entity
        {
            get
            {
                if (this.EntryListArray == null)
                {
                    return null;
                }

                var entityList = this.EntryListArray.Select(item => item.Entity).ToList();

                if (entityList.Count > 0)
                {
                    return entityList[0];
                }

                return new JObject();
            }
        }

        /// <summary>
        /// Gets or sets the entry list in json
        /// </summary>
        [JsonProperty(PropertyName = "entry_list")]
        public List<EntryListArray> EntryListArray { get; set; }

        /// <summary>
        /// Gets or sets the relationship link entry list in json
        /// </summary>
        [JsonProperty(PropertyName = "relationship_list")]
        public List<object> RelationshipList { get; set; }
    }
}
