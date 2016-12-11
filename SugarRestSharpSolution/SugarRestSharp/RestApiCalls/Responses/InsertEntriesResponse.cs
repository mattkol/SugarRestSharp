// -----------------------------------------------------------------------
// <copyright file="InsertEntriesResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents InsertEntriesResponse class
    /// </summary>
    internal class InsertEntriesResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the entity identifier of inserted entity
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        public List<string> Ids { get; set; }
    }
}
