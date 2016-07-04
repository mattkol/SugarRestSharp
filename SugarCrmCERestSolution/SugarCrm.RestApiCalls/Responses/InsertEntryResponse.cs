// -----------------------------------------------------------------------
// <copyright file="InsertEntryResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents InsertEntryResponse class
    /// </summary>
    public class InsertEntryResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the entity identifier of inserted entity
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
