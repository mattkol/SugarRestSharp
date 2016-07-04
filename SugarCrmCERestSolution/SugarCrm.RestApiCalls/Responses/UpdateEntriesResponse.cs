// -----------------------------------------------------------------------
// <copyright file="UpdateEntriesResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents UpdateEntriesResponse class
    /// </summary>
    public class UpdateEntriesResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the entity identifier of updated entity
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        public List<string> Ids { get; set; }
    }
}
