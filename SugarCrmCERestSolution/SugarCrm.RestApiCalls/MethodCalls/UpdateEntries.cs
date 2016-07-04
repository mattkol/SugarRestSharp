// -----------------------------------------------------------------------
// <copyright file="UpdateEntries.cs" company="SugarCrm + PocoGen + REST">
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
    using Responses;
    using RestSharp;

    /// <summary>
    /// Represents the UpdateEntries class
    /// </summary>
    public static class UpdateEntries
    {
        /// <summary>
        /// Updates entry [SugarCrm REST method - set_entries]
        /// </summary>
        /// <param name="sessionId">Session identifier</param>
        /// <param name="url">REST API Url</param>
        /// <param name="moduleName">SugarCrm module name</param>
        /// <param name="entities">The entity objects collection to create</param>
        /// <param name="selectFields">Selected field list</param>
        /// <returns>UpdateEntriesResponse object</returns>
        public static UpdateEntriesResponse Run(string sessionId, string url, string moduleName, List<object> entities, List<string> selectFields)
        {
            var updateEntryResponse = new UpdateEntriesResponse();
            var content = string.Empty;

            try
            {
                dynamic data = new
                {
                    session = sessionId,
                    module_name = moduleName,
                    name_value_list = EntityToNameValueList(entities, selectFields)
                };

                var client = new RestClient(url);
                var request = new RestRequest(string.Empty, Method.POST);

                request.AddParameter("method", "set_entries");
                request.AddParameter("input_type", "json");
                request.AddParameter("response_type", "json");
                request.AddParameter("rest_data", JsonConvert.SerializeObject(data));

                var sugarApiRestResponse = client.ExecuteEx(request);
                var response = sugarApiRestResponse.RestResponse;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = response.Content;
                    updateEntryResponse = JsonConvert.DeserializeObject<UpdateEntriesResponse>(content);
                    updateEntryResponse.StatusCode = response.StatusCode;
                }
                else
                {
                    updateEntryResponse.StatusCode = response.StatusCode;
                    updateEntryResponse.Error = ErrorResponse.Format(response);
                }

                updateEntryResponse.JsonRawRequest = sugarApiRestResponse.JsonRawRequest;
                updateEntryResponse.JsonRawResponse = sugarApiRestResponse.JsonRawResponse;
            }
            catch (Exception exception)
            {
                updateEntryResponse.StatusCode = HttpStatusCode.InternalServerError;
                updateEntryResponse.Error = ErrorResponse.Format(exception, content);
            }

            return updateEntryResponse;
        }

        /// <summary>
        /// Format entity to json friendly dynamic object
        /// </summary>
        /// <param name="entities">The entity objects collection to create</param>
        /// <param name="selectFields">Selected field list</param>
        /// <returns>List of name value as object</returns>
        public static List<object> EntityToNameValueList(List<object> entities, List<string> selectFields)
        {
            bool useSelectedFields = (selectFields != null) && (selectFields.Count > 0);
            var namevalueList = new List<object>();

            foreach (var entity in entities)
            {
                var jobject = JObject.FromObject(entity);


                var jproperties = jobject.Properties().ToList();
                foreach (JProperty jproperty in jproperties)
                {
                    string name = jproperty.Name;
                    if (useSelectedFields)
                    {
                        if (selectFields.All(x => x.ToLower() != name.ToLower()))
                        {
                            continue;
                        }
                    }

                    object value = jproperty.Value;

                    var namevalueDic = new Dictionary<string, object>();
                    namevalueDic.Add("name", name);
                    namevalueDic.Add("value", value);
                    var singleObject = new List<object>();
                    singleObject.Add(namevalueDic);
                    namevalueList.Add(singleObject);
                }
            }

            return namevalueList;
        }
    }
}