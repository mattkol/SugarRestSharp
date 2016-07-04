// -----------------------------------------------------------------------
// <copyright file="LoginResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.Responses
{
    /// <summary>
    /// Represents the LoginResponse class
    /// </summary>
    public class LoginResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the session identifier
        /// </summary>
        public string SessionId { get; set; }
    }
}
