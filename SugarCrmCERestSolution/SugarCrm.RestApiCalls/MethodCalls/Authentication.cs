// -----------------------------------------------------------------------
// <copyright file="Authentication.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.MethodCalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Requests;
    using Responses;
    using RestSharp;

    /// <summary>
    /// Base Authentication class for SugarCrm REST API calls
    /// </summary>
    public static class Authentication
    {
        /// <summary>
        /// Login to SugarCrm via REST API call
        /// </summary>
        /// <param name="loginRequest">LoginRequest object</param>
        /// <returns>LoginResponse object</returns>
        public static LoginResponse Login(LoginRequest loginRequest)
        {
            var loginResponse = new LoginResponse();
            
            dynamic authData = new
                {   
                    user_auth =
                        new
                            {
                                user_name = loginRequest.Username,
                                password = Util.CalculateMd5Hash(loginRequest.Password)
                            },
                    application_name = "RestClient"
                };

            var client = new RestClient(loginRequest.Url);
            var request = new RestRequest(string.Empty, Method.POST);

            request.AddParameter("method", "login");
            request.AddParameter("input_type", "json");
            request.AddParameter("response_type", "json");
            request.AddParameter("rest_data", JsonConvert.SerializeObject(authData));

            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = response.Content;

                JObject jsonObj = JObject.Parse(content);
                IList<string> keys = jsonObj.Properties().Select(p => p.Name).ToList();
                if (keys.Any(n => n == "id"))
                {
                    JProperty property = jsonObj.Properties().SingleOrDefault(p => p.Name == "id");
                    if (property != null)
                    {
                        string value = property.Value.ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            loginResponse.StatusCode = response.StatusCode;
                            loginResponse.SessionId = value;
                        }
                    }
                }
                else
                {
                    loginResponse.StatusCode = response.StatusCode;
                    loginResponse.Error = jsonObj.ToObject<ErrorResponse>();
                }
            }
            else
            {
                loginResponse.StatusCode = HttpStatusCode.InternalServerError;
                loginResponse.Error = ErrorResponse.Format(response);
            }

            return loginResponse;
        }

        /// <summary>
        /// Gets current session
        /// </summary>
        /// <param name="url">REST API Url</param>
        /// <param name="sessionId">Session identifier</param>
        /// <returns>LoginResponse object</returns>
        public static LoginResponse GetCurrentSession(string url, string sessionId)
        {
            var sessionResponse = new LoginResponse();

            dynamic currentSession = new
                {
                    session = sessionId
                };

            var client = new RestClient(url);

            var request = new RestRequest(string.Empty, Method.POST);

            request.AddParameter("method", "oauth_access");
            request.AddParameter("input_type", "json");
            request.AddParameter("response_type", "json");
            request.AddParameter("rest_data", JsonConvert.SerializeObject(currentSession));

            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = response.Content;

                var jsonObj = JObject.Parse(content);
                var keys = jsonObj.Properties().Select(p => p.Name).ToList();
                if (keys.Any(n => n == "id"))
                {
                    JProperty property = jsonObj.Properties().SingleOrDefault(p => p.Name == "id");
                    if (property != null)
                    {
                        string value = property.Value.ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            sessionResponse.StatusCode = response.StatusCode;
                            sessionResponse.SessionId = value;
                        }
                    }
                }
                else
                {
                    sessionResponse.StatusCode = response.StatusCode;
                    sessionResponse.Error = jsonObj.ToObject<ErrorResponse>();
                }
            }
            else
            {
                sessionResponse.StatusCode = HttpStatusCode.InternalServerError;
                sessionResponse.Error = ErrorResponse.Format(response);
            }

            return sessionResponse;
        }

        /// <summary>
        /// Logs out with the session identifier
        /// </summary>
        /// <param name="url">REST API Url</param>
        /// <param name="sessionId">Session identifier</param>
        public static void Logout(string url, string sessionId)
        {
            try
            {
                dynamic currentSession = new
                    {
                        session = sessionId
                    };

                var client = new RestClient(url);

                var request = new RestRequest(string.Empty, Method.POST);

                request.AddParameter("method", "logout");
                request.AddParameter("input_type", "json");
                request.AddParameter("response_type", "json");
                request.AddParameter("rest_data", JsonConvert.SerializeObject(currentSession));

                client.Execute(request);
            }
            catch 
            {
                // Suppress exception
            }
        }
    }
}