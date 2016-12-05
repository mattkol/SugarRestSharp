// -----------------------------------------------------------------------
// <copyright file="GetEntry.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.MethodCalls
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Responses;
    using RestSharp;
    using SugarCrm.RestApiCalls.Helpers;
    
    /// <summary>
    /// Represents the GetEntry class
    /// </summary>
    public static class GetEntry
    {
        /// <summary>
        /// Gets entry [SugarCrm REST method - get_entry]
        /// </summary>
        /// <param name="sessionId">Session identifier</param>
        /// <param name="url">REST API Url</param>
        /// <param name="moduleName">SugarCrm module name</param>
        /// <param name="identifier">The entity identier</param>
        /// <param name="selectFields">Selected field list</param>
        /// <returns>ReadEntryResponse object</returns>
        public static ReadEntryResponse Run(string sessionId, string url, string moduleName, string identifier, List<string> selectFields)
        {
            var readEntryResponse = new ReadEntryResponse();
            var content = string.Empty;

            try
            {
                dynamic data = new
                {
                    session = sessionId,
                    module_name = moduleName,
                    id = identifier,
                    select_fields = selectFields,
                    link_name_to_fields_array = string.Empty,
                    track_view = false
                };

                var client = new RestClient(url);
                var request = new RestRequest(string.Empty, Method.POST);

                request.AddParameter("method", "get_entry");
                request.AddParameter("input_type", "json");
                request.AddParameter("response_type", "json");
                request.AddParameter("rest_data", JsonConvert.SerializeObject(data));

                var sugarApiRestResponse = client.ExecuteEx(request);
                var response = sugarApiRestResponse.RestResponse;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = response.Content;
                    readEntryResponse = JsonConverterHelper.Deserialize<ReadEntryResponse>(content);
                    readEntryResponse.StatusCode = response.StatusCode;
                }
                else
                {
                    readEntryResponse.StatusCode = response.StatusCode;
                    readEntryResponse.Error = ErrorResponse.Format(response);
                }

                readEntryResponse.JsonRawRequest = sugarApiRestResponse.JsonRawRequest;
                readEntryResponse.JsonRawResponse = sugarApiRestResponse.JsonRawResponse;
            }
            catch (Exception exception)
            {
                readEntryResponse.StatusCode = HttpStatusCode.InternalServerError;
                readEntryResponse.Error = ErrorResponse.Format(exception, content);  
            }

            return readEntryResponse;
        }
    }
}