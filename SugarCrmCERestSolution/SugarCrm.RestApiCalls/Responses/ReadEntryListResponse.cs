// -----------------------------------------------------------------------
// <copyright file="ReadEntryListResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents ReadEntryListResponse class
    /// </summary>
    public class ReadEntryListResponse : BaseResponse
    {
        /// <summary>
        /// Gets the entity list returned from SugarCrm to json array objects
        /// </summary>
        public JArray EntityList
        {
            get
            {
                if (this.EntryList == null)
                {
                    return null;
                }

                var entityList = new JArray();
                foreach (var item in this.EntryList)
                {
                    entityList.Add(item.Entity);
                }

                return entityList;
            }
        }

        /// <summary>
        /// Gets or sets the number of entries returned
        /// </summary>
        [JsonProperty(PropertyName = "result_count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the total count of entries available
        /// </summary>
        [JsonProperty(PropertyName = "total_count")]
        public string TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the next offset
        /// </summary>
        [JsonProperty(PropertyName = "next_offset")]
        public int NextOffset { get; set; }

        /// <summary>
        /// Gets or sets the entry list in json
        /// </summary>
        [JsonProperty(PropertyName = "entry_list")]
        public List<EntryListArray> EntryList { get; set; }

        /// <summary>
        /// Gets or sets the relationship link entry list in json
        /// </summary>
        [JsonProperty(PropertyName = "relationship_list")]
        public List<object> RelationshipList { get; set; }
    }
}
