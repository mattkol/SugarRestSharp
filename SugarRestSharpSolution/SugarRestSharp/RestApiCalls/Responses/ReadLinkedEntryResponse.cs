// -----------------------------------------------------------------------
// <copyright file="ReadLinkedEntryResponse.cs" company="SugarCrm + PocoGen + REST">
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
    /// Represents ReadLinkedEntryResponse class
    /// </summary>
    internal class ReadLinkedEntryResponse : BaseResponse
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

                JObject jobject = new JObject();
                if (entityList.Count > 0)
                {
                    jobject = entityList[0];

                    foreach (List<LinkedModuleData> linkedModuleData in this.RelationshipList)
                    {
                        if (linkedModuleData != null)
                        {
                            foreach (LinkedModuleData item in linkedModuleData)
                            {
                                jobject[item.ModuleName] = JToken.FromObject(item.FormattedRecords);
                            }
                        }
                    }

                    return jobject;
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
        public List<List<LinkedModuleData>> RelationshipList { get; set; }
    }
}
