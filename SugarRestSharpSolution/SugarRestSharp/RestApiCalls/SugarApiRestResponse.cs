// -----------------------------------------------------------------------
// <copyright file="SugarApiRestResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using RestSharp;

    /// <summary>
    /// 
    /// </summary>
    internal class SugarApiRestResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public IRestResponse RestResponse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string JsonRawRequest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string JsonRawResponse { get; set; }
    }
}
