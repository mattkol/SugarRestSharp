// -----------------------------------------------------------------------
// <copyright file="BaseResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Responses
{
    using System;
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// Base SugarCrm REST API response object
    /// </summary>
    internal class BaseResponse
    {
        /// <summary>
        /// Initializes a new instance of the BaseResponse class
        /// </summary>
        public BaseResponse()
        {
            this.Time = DateTime.UtcNow;
            this.Error = new ErrorResponse();
        }

        /// <summary>
        /// Gets or sets the time the API call was made
        /// </summary>
        [JsonIgnore]
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the raw json request sent by SugarCrm Rest API
        /// </summary>
        [JsonIgnore]
        public string JsonRawRequest { get; set; }

        /// <summary>
        /// Gets or sets the raw json response sent by SugarCrm Rest API
        /// </summary>
        [JsonIgnore]
        public string JsonRawResponse { get; set; }

        /// <summary>
        /// Gets or sets the error object
        /// </summary>
        [JsonIgnore]
        public ErrorResponse Error { get; set; }

        /// <summary>
        /// Gets or sets the http status code - either returned from the API call or assigned
        /// </summary>
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }
    }
}
