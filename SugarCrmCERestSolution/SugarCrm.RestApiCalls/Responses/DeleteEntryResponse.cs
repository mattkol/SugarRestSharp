// -----------------------------------------------------------------------
// <copyright file="DeleteEntryResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents DeleteEntryResponse class
    /// </summary>
    public class DeleteEntryResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the entity identifier of deleted entity
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
