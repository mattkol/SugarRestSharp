// -----------------------------------------------------------------------
// <copyright file="DeleteEntryResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents DeleteEntryResponse class
    /// </summary>
    internal class DeleteEntryResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the entity identifier of deleted entity
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
