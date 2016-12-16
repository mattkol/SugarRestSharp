// -----------------------------------------------------------------------
// <copyright file="RestClientExtensions.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using RestSharp;

    internal static class RestClientExtensions
    {
        /// <summary>
        /// Gets enity by id
        /// </summary>
        /// <param name="client">SugarRestClient object</param>
        /// <param name="request">The request object</param>
        /// <returns>SugarRestResponse object</returns>
        public static SugarApiRestResponse ExecuteEx(this IRestClient client, IRestRequest request)
        {
            var sugarApiRestResponse = new SugarApiRestResponse();
            IRestResponse response = null;
 
            try
            {
                response = client.Execute(request);
                sugarApiRestResponse.RestResponse = response;
            }
            catch (Exception e)
            {
            }
            finally
            {
                GetRawRequest(client, sugarApiRestResponse, request, response);
            }

            return sugarApiRestResponse;
        }

        private static void GetRawRequest(IRestClient client, SugarApiRestResponse sugarApiRestResponse, IRestRequest request, IRestResponse response)
        {
            var requestJson = new
            {
                resource = request.Resource,
                // Parameters are custom anonymous objects in order to have the parameter type as a nice string
                // otherwise it will just show the enum value
                parameters = request.Parameters.Select(parameter => new
                {
                    name = parameter.Name,
                    value = parameter.Value,
                    type = parameter.Type.ToString()
                }),

                // ToString() here to have the method as a nice string otherwise it will just show the enum value
                method = request.Method.ToString(),

                // This will generate the actual Uri used in the request
                uri = client.BuildUri(request),
            };

            var responseJson = new
            {
                statusCode = response.StatusCode,
                content = response.Content,
                headers = response.Headers,

                // The Uri that actually responded (could be different from the requestUri if a redirection occurred)
                responseUri = response.ResponseUri,
                errorMessage = response.ErrorMessage,
            };


            string jsonRawRequest = JsonConvert.SerializeObject(requestJson);
            string jsonRawResponse = JsonConvert.SerializeObject(responseJson);

            sugarApiRestResponse.JsonRawRequest = jsonRawRequest; 
            sugarApiRestResponse.JsonRawResponse = jsonRawResponse;

        }
    }
}
