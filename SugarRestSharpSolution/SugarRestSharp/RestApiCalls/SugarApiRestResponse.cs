// -----------------------------------------------------------------------
// <copyright file="SugarApiRestResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using RestSharp;

    internal class SugarApiRestResponse
    {
        public IRestResponse RestResponse { get; set; }
        public string JsonRawRequest { get; set; }
        public string JsonRawResponse { get; set; }
    }
}
