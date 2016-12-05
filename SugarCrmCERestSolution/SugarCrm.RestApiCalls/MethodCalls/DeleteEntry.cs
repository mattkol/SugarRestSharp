// -----------------------------------------------------------------------
// <copyright file="DeleteEntry.cs" company="SugarCrm + PocoGen + REST">
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
    /// Represents the DeleteEntry class
    /// </summary>
    public static class DeleteEntry
    {
        /// <summary>
        /// Deletes entry [SugarCrm REST method -set_entry (sets deleted to 1]
        /// </summary>
        /// <param name="sessionId">Session identifier</param>
        /// <param name="url">REST API Url</param>
        /// <param name="moduleName">SugarCrm module name</param>
        /// <param name="id">The entity identifier</param>
        /// <returns>DeleteEntryResponse object</returns>
        public static DeleteEntryResponse Run(string sessionId, string url, string moduleName, string id)
        {
            var deleteEntryResponse = new DeleteEntryResponse();
            var content = string.Empty;

            try
            {
                dynamic data = new
                {
                    session = sessionId,
                    module_name = moduleName,
                    name_value_list = DeleteDataToNameValueList(id)
                };

                var client = new RestClient(url);
                var request = new RestRequest(string.Empty, Method.POST);

                request.AddParameter("method", "set_entry");
                request.AddParameter("input_type", "json");
                request.AddParameter("response_type", "json");
                request.AddParameter("rest_data", JsonConvert.SerializeObject(data));

                var sugarApiRestResponse = client.ExecuteEx(request);
                var response = sugarApiRestResponse.RestResponse;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = response.Content;
                    deleteEntryResponse = JsonConverterHelper.Deserialize<DeleteEntryResponse>(content);
                    deleteEntryResponse.StatusCode = response.StatusCode;
                }
                else
                {
                    deleteEntryResponse.StatusCode = response.StatusCode;
                    deleteEntryResponse.Error = ErrorResponse.Format(response);
                }

                deleteEntryResponse.JsonRawRequest = sugarApiRestResponse.JsonRawRequest;
                deleteEntryResponse.JsonRawResponse = sugarApiRestResponse.JsonRawResponse;
            }
            catch (Exception exception)
            {
                deleteEntryResponse.StatusCode = HttpStatusCode.InternalServerError;
                deleteEntryResponse.Error = ErrorResponse.Format(exception, content); 
            }

            return deleteEntryResponse;
        }

        /// <summary>
        /// Format request to json friendly dynamic object
        /// </summary>
        /// <param name="id">The entity identifier</param>
        /// <returns>List of name value as object</returns>
        private static List<object> DeleteDataToNameValueList(string id)
        {
            var namevalueList = new List<object>();

            var namevalueDic = new Dictionary<string, object>();
            namevalueDic.Add("name", "id");
            namevalueDic.Add("value", id);
            namevalueList.Add(namevalueDic);

            namevalueDic = new Dictionary<string, object>();
            namevalueDic.Add("name", "deleted");
            namevalueDic.Add("value", 1);
            namevalueList.Add(namevalueDic);

            return namevalueList;
        }
    }
}
