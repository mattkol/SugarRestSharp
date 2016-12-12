// -----------------------------------------------------------------------
// <copyright file="GetLinkedEntryList.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.MethodCalls
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Helpers;
    using Newtonsoft.Json;
    using Responses;
    using RestSharp;

    /// <summary>
    /// Represents the GetLinkedEntryList class
    /// </summary>
    internal static class GetLinkedEntryList
    {
        /// <summary>
        /// Gets entries [SugarCrm REST method - get_entry_list]
        /// </summary>
        /// <param name="sessionId">Session identifier</param>
        /// <param name="url">REST API Url</param>
        /// <param name="moduleName">SugarCrm module name</param>
        /// <param name="selectFields">Selected field list</param>
        /// <param name="linkedSelectFields">Linked field info.</param>
        /// <param name="maxCountResult">Maxium number of entries to return</param>
        /// <returns>CreateEntryResponse object</returns>
        public static ReadEntryListResponse Run(string sessionId, string url, string moduleName, List<string> selectFields, Dictionary<string, List<string>> linkedSelectFields, int maxCountResult)
        {
            var readEntryListResponse = new ReadEntryListResponse();
            var content = string.Empty;

            try
            {
                dynamic data = new
                {
                    session = sessionId,
                    module_name = moduleName,
                    query = string.Empty,
                    order_by = string.Empty,
                    offset = 0,
                    select_fields = selectFields,
                    link_name_to_fields_array = LinkedInfoToLinkedFieldsList(linkedSelectFields),
                    max_results = maxCountResult,
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
                    readEntryListResponse = JsonConverterHelper.Deserialize<ReadEntryListResponse>(content);
                    readEntryListResponse.StatusCode = response.StatusCode;
                }
                else
                {
                    readEntryListResponse.StatusCode = response.StatusCode;
                    readEntryListResponse.Error = ErrorResponse.Format(response);
                }

                readEntryListResponse.JsonRawRequest = sugarApiRestResponse.JsonRawRequest;
                readEntryListResponse.JsonRawResponse = sugarApiRestResponse.JsonRawResponse;
            }
            catch (Exception exception)
            {
                readEntryListResponse.StatusCode = HttpStatusCode.InternalServerError;
                readEntryListResponse.Error = ErrorResponse.Format(exception, content);
            }

            return readEntryListResponse;
        }

        /// <summary>
        /// Format linked list info to json friendly dynamic object
        /// </summary>
        /// <param name="linkedSelectFields">Linked field info.</param>
        /// <returns>List of linked name value as object.</returns>
        private static List<object> LinkedInfoToLinkedFieldsList(Dictionary<string, List<string>> linkedSelectFields)
        {
            var linkedListInfo = new List<object>();
            foreach (var item in linkedSelectFields)
            {
                var namevalueDic = new Dictionary<string, object>();
                namevalueDic.Add("name", item.Key);
                namevalueDic.Add("value", item.Value);

                linkedListInfo.Add(namevalueDic);
            }

            return linkedListInfo;
        }
    }
}