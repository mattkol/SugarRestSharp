// -----------------------------------------------------------------------
// <copyright file="SugarRestResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System.Collections.Generic;
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
        /// Gets or sets entity identifier returned.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets entity identifier returned.
        /// </summary>
        public List<string> Ids { get; set; }

        /// <summary>
        /// Gets or sets the raw json request sent by SugarCrm Rest API.
        /// </summary>
        public string JsonRawRequest { get; set; }

        /// <summary>
        /// Gets or sets the raw json response sent by SugarCrm Rest API.
        /// </summary>
        public string JsonRawResponse { get; set; }

        /// <summary>
        /// Gets or sets entity/entities data returned in json.
        /// </summary>
        public string JData { get; set; }

        /// <summary>
        /// Gets or sets entity/entities data returned. 
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
