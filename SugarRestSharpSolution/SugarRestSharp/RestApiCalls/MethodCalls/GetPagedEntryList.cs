// -----------------------------------------------------------------------
// <copyright file="GetPagedEntryList.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace SugarRestSharp.MethodCalls
{
    using System;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Responses;
    using RestSharp;
    using SugarRestSharp.Helpers;

    /// <summary>
    /// Represents the GetPagedEntryList class
    /// </summary>
    internal static class GetPagedEntryList
    {
        /// <summary>
        /// Gets entries [SugarCrm REST method - get_entry_list]
        /// </summary>
        /// <param name="sessionId">Session identifier</param>
        /// <param name="url">REST API Url</param>
        /// <param name="moduleName">SugarCrm module name</param>
        /// <param name="selectFields">Selected field list</param>
        /// <param name="currentPage">The current page number</param>
        /// <param name="numberPerPage">The number of pages per page</param>
        /// <returns>CreateEntryResponse object</returns>
        public static ReadEntryListResponse Run(string sessionId, string url, string moduleName, List<string> selectFields, int currentPage, int numberPerPage)
        {
            var readEntryPagedResponse = new ReadEntryListResponse();
            var content = string.Empty;

            try
            {
                dynamic data = new
                {
                    session = sessionId,
                    module_name = moduleName,
                    query = string.Empty,
                    order_by = string.Empty,
                    offset = (currentPage - 1) * numberPerPage,
                    select_fields = selectFields,
                    link_name_to_fields_array = string.Empty,
                    max_results = numberPerPage,
                    deleted = 0,
                    favorites = false
                };

                var client = new RestClient(url);
                var request = new RestRequest(string.Empty, Method.POST);
                string jsonData = JsonConvert.SerializeObject(data);

                request.AddParameter("method", "get_entry_list");
                request.AddParameter("input_type", "json");
                request.AddParameter("response_type", "json");
                request.AddParameter("rest_data", jsonData);

                var sugarApiRestResponse = client.ExecuteEx(request);
                var response = sugarApiRestResponse.RestResponse;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = response.Content;
                    readEntryPagedResponse = JsonConverterHelper.Deserialize<ReadEntryListResponse>(content);
                    readEntryPagedResponse.StatusCode = response.StatusCode;
                }
                else
                {
                    readEntryPagedResponse.StatusCode = response.StatusCode;
                    readEntryPagedResponse.Error = ErrorResponse.Format(response);
                }

                readEntryPagedResponse.JsonRawRequest = sugarApiRestResponse.JsonRawRequest;
                readEntryPagedResponse.JsonRawResponse = sugarApiRestResponse.JsonRawResponse;
            }
            catch (Exception exception)
            {
                readEntryPagedResponse.StatusCode = HttpStatusCode.InternalServerError;
                readEntryPagedResponse.Error = ErrorResponse.Format(exception, content); 
            }

            return readEntryPagedResponse;
        }
    }
}
