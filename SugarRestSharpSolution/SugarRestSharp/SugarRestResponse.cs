// -----------------------------------------------------------------------
// <copyright file="SugarRestResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System.Net;
    using Responses;
  
    /// <summary>
    /// Represents SugarRestResponse class.
    /// </summary>
    public class SugarRestResponse
    {
        /// <summary>
        /// Initializes a new instance of the SugarRestResponse class.
        /// </summary>
        public SugarRestResponse()
        {
            this.Error = new ErrorResponse();
            this.JsonRawRequest = string.Empty;
            this.JsonRawResponse = string.Empty;
            this.JData = string.Empty;
        }

        /// <summary>
        /// Gets or sets the raw json request sent by SugarCrm Rest API.
        /// </summary>
        public string JsonRawRequest { get; set; }

        /// <summary>
        /// Gets or sets the raw json response sent by SugarCrm Rest API.
        /// </summary>
        public string JsonRawResponse { get; set; }

        /// <summary>
        /// Gets or sets identity, identifiers, entity or entities data returned in json.
        /// Data type returned for the following request type:
        /// ReadById - Entity
        /// BulkRead - Entity collection
        /// PagedRead - Entity collection
        /// Create - Identifier (Id)
        /// BulkCreate - Identifiers (Ids)
        /// Update - Identifier (Id)
        /// BulkUpdate - Identifiers (Ids)
        /// Delete - Identifier (Id)
        /// LinkedReadById - Entity 
        /// LinkedBulkRead - Entity collection
        /// </summary>
        public string JData { get; set; }

        /// <summary>
        /// Gets or sets identity, identifiers, entity or entities data returned. 
        /// Data type returned for the following request type:
        /// ReadById - Entity
        /// BulkRead - Entity collection
        /// PagedRead - Entity collection
        /// Create - Identifier (Id)
        /// BulkCreate - Identifiers (Ids)
        /// Update - Identifier (Id)
        /// BulkUpdate - Identifiers (Ids)
        /// Delete - Identifier (Id)
        /// LinkedReadById - Entity 
        /// LinkedBulkRead - Entity collection
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets status code returned.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets error object.
        /// </summary>
        public ErrorResponse Error { get; set; }
    }
}
