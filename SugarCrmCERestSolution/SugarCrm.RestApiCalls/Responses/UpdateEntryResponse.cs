// -----------------------------------------------------------------------
// <copyright file="UpdateEntryResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents UpdateEntryResponse class
    /// </summary>
    public class UpdateEntryResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the entity identifier of updated entity
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
