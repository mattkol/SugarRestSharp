// -----------------------------------------------------------------------
// <copyright file="InsertEntries.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.MethodCalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Responses;
    using RestSharp;
    using SugarRestSharp.Helpers;

    /// <summary>
    /// Represents the InsertEntries class
    /// </summary>
    internal static class InsertEntries
    {
        /// <summary>
        /// Creates entry [SugarCrm REST method - set_entries]
        /// </summary>
        /// <param name="sessionId">Session identifier</param>
        /// <param name="url">REST API Url</param>
        /// <param name="moduleName">SugarCrm module name</param>
        /// <param name="entities">The entity objects collection to create</param>
        /// <param name="selectFields">Selected field list</param>
        /// <returns>InsertEntriesResponse object</returns>
        public static InsertEntriesResponse Run(string sessionId, string url, string moduleName, JArray entities, List<string> selectFields)
        {
            var insertEntriesResponse = new InsertEntriesResponse();
            var content = string.Empty;

            try
            {
                dynamic data = new
                {
                    session = sessionId,
                    module_name = moduleName,
                    name_value_lists = EntityToNameValueList(entities, selectFields)
                };

                var client = new RestClient(url);
                var request = new RestRequest(string.Empty, Method.POST);
                string jsonData = JsonConvert.SerializeObject(data);

                request.AddParameter("method", "set_entries");
                request.AddParameter("input_type", "json");
                request.AddParameter("response_type", "json");
                request.AddParameter("rest_data", jsonData);

                var sugarApiRestResponse = client.ExecuteEx(request);
                var response = sugarApiRestResponse.RestResponse;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = response.Content;
                    insertEntriesResponse = JsonConverterHelper.Deserialize<InsertEntriesResponse>(content);
                    insertEntriesResponse.StatusCode = response.StatusCode;
                }
                else
                {
                    insertEntriesResponse.StatusCode = response.StatusCode;
                    insertEntriesResponse.Error = ErrorResponse.Format(response);
                }

                insertEntriesResponse.JsonRawRequest = sugarApiRestResponse.JsonRawRequest;
                insertEntriesResponse.JsonRawResponse = sugarApiRestResponse.JsonRawResponse;
            }
            catch (Exception exception)
            {
                insertEntriesResponse.StatusCode = HttpStatusCode.InternalServerError;
                insertEntriesResponse.Error = ErrorResponse.Format(exception, content);
            }

            return insertEntriesResponse;
        }

        /// <summary>
        /// Format entity to json friendly dynamic object
        /// </summary>
        /// <param name="entities">The entity objects collection to create</param>
        /// <param name="selectFields">Selected field list</param>
        /// <returns>List of name value as object</returns>
        private static List<object> EntityToNameValueList(JArray entities, List<string> selectFields)
        {
            bool useSelectedFields = (selectFields != null) && (selectFields.Count > 0);
            var entityObjectList = new List<object>();

            foreach (var entity in entities)
            {
                var entityObject = new Dictionary<string, object>();
                var jproperties = ((JObject)entity).Properties().ToList();
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

                    if (string.Compare("id", name, StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        continue;
                    }

                    var namevalueDic = new Dictionary<string, object>();
                    namevalueDic.Add("name", name);
                    namevalueDic.Add("value", value);

                    entityObject.Add(name, namevalueDic);
                }

                entityObjectList.Add(entityObject);
            }

            return entityObjectList;
        }
    }
}
