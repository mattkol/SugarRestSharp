// -----------------------------------------------------------------------
// <copyright file="ErrorResponse.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.Responses
{
    using System;
    using System.Net;
    using Newtonsoft.Json;
    using RestSharp;

    /// <summary>
    /// Represents ErrorResponse class
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the http status code
        /// </summary>
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// Gets or sets the name of the returned error type
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of the error returned
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the error message description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Message { get; set; }

        /// <summary>
        /// Gets formatted error response based on RestSharp error
        /// </summary>
        /// <param name="response">Response object from RestSharp</param>
        /// <returns>ErrorResponse object</returns>
        public static ErrorResponse Format(IRestResponse response)
        {
            var errorResponse = new ErrorResponse();
            errorResponse.Name = string.IsNullOrEmpty(response.StatusDescription) ? "Internal server error." : response.StatusDescription;
            errorResponse.Number = (int)response.StatusCode;
            string message = response.ErrorMessage;
            if (string.IsNullOrEmpty(message))
            {
                if (response.ErrorException != null)
                {
                    message = response.ErrorException.Message;
                }
                else
                {
                    message = errorResponse.Name;
                }
            }

            errorResponse.Message = message;
            return errorResponse;
        }

        /// <summary>
        /// Gets formatted error response exception or SugarCrm error message
        /// </summary>
        /// <param name="exception">Exception from SugarCrm REST API calls or .NET error</param>
        /// <param name="errorContent">Error returned from SugarCrm</param>
        /// <returns>ErrorResponse object</returns>
        public static ErrorResponse Format(Exception exception, string errorContent)
        {
            var errorResponse = new ErrorResponse();
            errorResponse.Name = "An error has occurred!";
            errorResponse.Number = (int)HttpStatusCode.SeeOther;
            if (string.IsNullOrEmpty(errorContent))
            {
                errorResponse.Message = exception.Message;
            }
            else
            {
                errorResponse.Message = errorContent;
            }

            return errorResponse;
        }

        /// <summary>
        /// Gets formatted SugarCrm error message
        /// </summary>
        /// <param name="errorContent">Error returned from SugarCrm</param>
        /// <returns>ErrorResponse object</returns>
        public static ErrorResponse Format(string errorContent)
        {
            var errorResponse = new ErrorResponse();
            errorResponse.Name = "An error has occurred!";
            errorResponse.Number = (int)HttpStatusCode.SeeOther;
            errorResponse.Message = errorContent;

            return errorResponse;
        }
    }
}