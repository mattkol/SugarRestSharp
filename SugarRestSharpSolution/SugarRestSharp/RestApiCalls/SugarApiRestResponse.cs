// -----------------------------------------------------------------------
// <copyright file="SugarApiRestResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using RestSharp;

    /// <summary>
    /// Represents SugarApiRestResponse class.
    /// </summary>
    internal class SugarApiRestResponse
    {
        /// <summary>
        /// Gets or sets the RestSharp response object.
        /// </summary>
        public IRestResponse RestResponse { get; set; }

        /// <summary>
        /// Gets or sets the RestSharp raw json request.
        /// </summary>
        public string JsonRawRequest { get; set; }

        /// <summary>
        /// Gets or sets the RestSharp raw json response content.
        /// </summary>
        public string JsonRawResponse { get; set; }
    }
}
