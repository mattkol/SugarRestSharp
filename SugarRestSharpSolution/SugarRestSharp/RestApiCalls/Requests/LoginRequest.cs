// -----------------------------------------------------------------------
// <copyright file="LoginRequest.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Requests
{
    /// <summary>
    /// Represents the LoginRequest class
    /// </summary>
    internal class LoginRequest
    {
        /// <summary>
        /// Gets or sets REST API Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets REST API SessionId
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets REST API Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets REST API Password
        /// </summary>
        public string Password { get; set; }
    }
}