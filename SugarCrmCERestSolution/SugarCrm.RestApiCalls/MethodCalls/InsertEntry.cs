// -----------------------------------------------------------------------
// <copyright file="InsertEntry.cs" company="SugarCrm + PocoGen + REST">
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
    using SugarCrm.RestApiCalls.Helpers;
    
    /// <summary>
    /// Represents the InsertEntry class
    /// </summary>
    public static class InsertEntry
    {
        /// <summary>
        /// Creates entry [SugarCrm REST method - set_entry]
        /// </summary>
        /// <param name="sessionId">Session identifier</param>
        /// <param name="url">REST API Url</param>
        /// <param name="moduleName">SugarCrm module name</param>
        /// <param name="entity">The entity object to create</param>
        /// <param name="selectFields">Selected field list</param>
        /// <returns>CreateEntryResponse object</returns>
        public static InsertEntryResponse Run(string sessionId, string url, string moduleName, object entity, List<string> selectFields)
        {
            var insertEntryResponse = new InsertEntryResponse();
            var content = string.Empty;

            try
            {
                dynamic data = new
                {
                    session = sessionId,
                    module_name = moduleName,
                    name_value_list = EntityToNameValueList(entity, selectFields)
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
                    var settings = new JsonSerializerSettings();
                    DeserializerExceptionsContractResolver resolver = DeserializerExceptionsContractResolver.Instance;
                    resolver.JsonObjectToDeserialize = JObject.Parse(content);
                    settings.ContractResolver = resolver;
                    insertEntryResponse = JsonConvert.DeserializeObject<InsertEntryResponse>(content, settings);
                    insertEntryResponse.StatusCode = response.StatusCode;
                }
                else
                {
                    insertEntryResponse.StatusCode = response.StatusCode;
                    insertEntryResponse.Error = ErrorResponse.Format(response);
                }

                insertEntryResponse.JsonRawRequest = sugarApiRestResponse.JsonRawRequest;
                insertEntryResponse.JsonRawResponse = sugarApiRestResponse.JsonRawResponse;
            }
            catch (Exception exception)
            {
                insertEntryResponse.StatusCode = HttpStatusCode.InternalServerError;
                insertEntryResponse.Error = ErrorResponse.Format(exception, content); 
            }

            return insertEntryResponse;
        }

        /// <summary>
        /// Format entity to json friendly dynamic object
        /// </summary>
        /// <param name="entity">The entity object to create</param>
        /// <param name="selectFields">Selected field list</param>
        /// <returns>List of name value as object</returns>
        public static List<object> EntityToNameValueList(object entity, List<string> selectFields)
        {
            var namevalueList = new List<object>();
            var jobject = JObject.FromObject(entity);

            bool useSelectedFields = (selectFields != null) && (selectFields.Count > 0);
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

                if (string.Compare("id", name, StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                        continue;
                }

                var namevalueDic = new Dictionary<string, object>();
                namevalueDic.Add("name", name);
                namevalueDic.Add("value", value);
                namevalueList.Add(namevalueDic);
            }

            return namevalueList;
        }
    }
}
