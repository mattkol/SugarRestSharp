// -----------------------------------------------------------------------
// <copyright file="SugarRestClientExtensions.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json.Linq;
    using Responses;
    using MethodCalls;
    using Requests;
    using Helpers;

    internal static class SugarRestClientExtensions
    {
        /// <summary>
        /// Gets enity by id
        /// </summary>
        /// <param name="client">SugarRestClient object</param>
        /// <param name="request">The request object</param>
        /// <param name="modelInfo">The entity model info.</param>
        /// <returns>SugarRestResponse object</returns>
        public static SugarRestResponse ExecuteGetById(this SugarRestClient client, SugarRestRequest request, ModelInfo modelInfo)
        {
            var sugarRestResponse = new SugarRestResponse();
            var loginResponse = new LoginResponse();

            try
            {
                var loginRequest = new LoginRequest
                {
                    Url = request.Url,
                    Username = request.Username,
                    Password = request.Password
                };

                loginResponse = Authentication.Login(loginRequest);

                var selectFields = request.Options == null ? new List<string>() : request.Options.SelectFields;
                selectFields = modelInfo.GetJsonPropertyNames(selectFields);
                var readEntryResponse = GetEntry.Run(loginResponse.SessionId, request.Url, request.ModuleName, request.Id, selectFields);

                if (readEntryResponse != null)
                {
                    sugarRestResponse.JsonRawRequest = readEntryResponse.JsonRawRequest;
                    sugarRestResponse.JsonRawResponse = readEntryResponse.JsonRawResponse;

                    var jsonEnityList = readEntryResponse.Entity;
                    if (jsonEnityList != null)
                    {
                        sugarRestResponse.JData = readEntryResponse.Entity.ToString();
                        sugarRestResponse.StatusCode = readEntryResponse.StatusCode;
                        sugarRestResponse.Data = sugarRestResponse.JData.ToObject(modelInfo.Type);
                    }
                    else
                    {
                        sugarRestResponse.Error = readEntryResponse.Error;
                        sugarRestResponse.StatusCode = readEntryResponse.StatusCode;
                    }
                }

                return sugarRestResponse;
            }
            catch (Exception exception)
            {
                sugarRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                sugarRestResponse.Error = ErrorResponse.Format(exception, string.Empty);
            }
            finally
            {
                Authentication.Logout(request.Url, loginResponse.SessionId);
            }

            return sugarRestResponse;
        }

        /// <summary>
        /// Gets all entities limited by MaxResultCount sets in request options
        /// </summary>
        /// <param name="client">SugarRestClient object</param>
        /// <param name="request">The request object</param>
        /// <param name="modelInfo">The entity model info.</param>
        /// <returns>SugarRestResponse object</returns>
        public static SugarRestResponse ExecuteGetAll(this SugarRestClient client, SugarRestRequest request, ModelInfo modelInfo)
        {
            var sugarRestResponse = new SugarRestResponse();
            var loginResponse = new LoginResponse();

            try
            {
                var loginRequest = new LoginRequest
                {
                    Url = request.Url,
                    Username = request.Username,
                    Password = request.Password
                };

                loginResponse = Authentication.Login(loginRequest);
                var selectFields = modelInfo.GetJsonPropertyNames(request.Options.SelectFields);
                var readEntryListResponse = GetEntryList.Run(loginResponse.SessionId, request.Url, request.ModuleName, selectFields, request.Options.MaxResult);

                if (readEntryListResponse != null)
                {
                    sugarRestResponse.JsonRawRequest = readEntryListResponse.JsonRawRequest;
                    sugarRestResponse.JsonRawResponse = readEntryListResponse.JsonRawResponse;

                    var jsonEnityList = readEntryListResponse.EntityList;
                    if (jsonEnityList != null)
                    {
                        sugarRestResponse.JData = readEntryListResponse.EntityList.ToString();
                        sugarRestResponse.StatusCode = readEntryListResponse.StatusCode;
                        sugarRestResponse.Data = sugarRestResponse.JData.ToObjects(modelInfo.Type);
                    }
                    else
                    {
                        sugarRestResponse.Error = readEntryListResponse.Error;
                        sugarRestResponse.StatusCode = readEntryListResponse.StatusCode;
                    }
                }

                return sugarRestResponse;
            }
            catch (Exception exception)
            {
                sugarRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                sugarRestResponse.Error = ErrorResponse.Format(exception, string.Empty);
            }
            finally
            {
                Authentication.Logout(request.Url, loginResponse.SessionId);
            }

            return sugarRestResponse;
        }

        /// <summary>
        /// Gets all entities by poge. Page options set in request options
        /// </summary>
        /// <param name="client">SugarRestClient object</param>
        /// <param name="request">The request object</param>
        /// <param name="modelInfo">The entity model info.</param>
        /// <returns>SugarRestResponse object</returns>
        public static SugarRestResponse ExecuteGetPaged(this SugarRestClient client, SugarRestRequest request, ModelInfo modelInfo)
        {
            var sugarRestResponse = new SugarRestResponse();
            var loginResponse = new LoginResponse();
            try
            {
                var loginRequest = new LoginRequest
                {
                    Url = request.Url,
                    Username = request.Username,
                    Password = request.Password
                };

                loginResponse = Authentication.Login(loginRequest);
                var selectFields = modelInfo.GetJsonPropertyNames(request.Options.SelectFields);
                var readEntryListResponse = GetPagedEntryList.Run(loginResponse.SessionId, loginRequest.Url, request.ModuleName, selectFields, request.Options.CurrentPage, request.Options.NumberPerPage);

                if (readEntryListResponse != null)
                {
                    sugarRestResponse.JsonRawRequest = readEntryListResponse.JsonRawRequest;
                    sugarRestResponse.JsonRawResponse = readEntryListResponse.JsonRawResponse;

                    var jsonEnityList = readEntryListResponse.EntityList;
                    if (jsonEnityList != null)
                    {
                        sugarRestResponse.JData = readEntryListResponse.EntityList.ToString();
                        sugarRestResponse.StatusCode = readEntryListResponse.StatusCode;
                        sugarRestResponse.Data = sugarRestResponse.JData.ToObjects(modelInfo.Type);
                    }
                    else
                    {
                        sugarRestResponse.Error = readEntryListResponse.Error;
                        sugarRestResponse.StatusCode = readEntryListResponse.StatusCode;
                    }
                }

                return sugarRestResponse;
            }
            catch (Exception exception)
            {
                sugarRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                sugarRestResponse.Error = ErrorResponse.Format(exception, string.Empty);
            }
            finally
            {
                Authentication.Logout(request.Url, loginResponse.SessionId);
            }

            return sugarRestResponse;
        }


        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="client">SugarRestClient object</param>
        /// <param name="request">The request object</param>
        /// <param name="modelInfo">The entity model info.</param>
        /// <returns>SugarRestResponse object</returns>
        public static SugarRestResponse ExecuteInsert(this SugarRestClient client, SugarRestRequest request, ModelInfo modelInfo)
        {
            var sugarRestResponse = new SugarRestResponse();
            var loginResponse = new LoginResponse();

            try
            {
                var loginRequest = new LoginRequest
                {
                    Url = request.Url,
                    Username = request.Username,
                    Password = request.Password
                };

                loginResponse = Authentication.Login(loginRequest);

                JObject jobject = JsonConverterHelper.Serialize(request.Data, modelInfo.Type);
                var selectFields = modelInfo.GetJsonPropertyNames(request.Options.SelectFields);
                var insertEntryResponse = InsertEntry.Run(loginResponse.SessionId, loginRequest.Url, request.ModuleName, jobject, selectFields);

                if (insertEntryResponse != null)
                {
                    sugarRestResponse.JsonRawRequest = insertEntryResponse.JsonRawRequest;
                    sugarRestResponse.JsonRawResponse = insertEntryResponse.JsonRawResponse;

                    if (!string.IsNullOrEmpty(insertEntryResponse.Id))
                    {
                        sugarRestResponse.Id = insertEntryResponse.Id;
                        sugarRestResponse.StatusCode = insertEntryResponse.StatusCode;
                    }
                    else
                    {
                        sugarRestResponse.Error = insertEntryResponse.Error;
                        sugarRestResponse.StatusCode = insertEntryResponse.StatusCode;
                    }
                }

                return sugarRestResponse;
            }
            catch (Exception exception)
            {
                sugarRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                sugarRestResponse.Error = ErrorResponse.Format(exception, string.Empty);
            }
            finally
            {
                Authentication.Logout(request.Url, loginResponse.SessionId);
            }

            return sugarRestResponse;
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="client">SugarRestClient object</param>
        /// <param name="request">The request object</param>
        /// <param name="modelInfo">The entity model info.</param>
        /// <returns>SugarRestResponse object</returns>
        public static SugarRestResponse ExecuteInserts(this SugarRestClient client, SugarRestRequest request, ModelInfo modelInfo)
        {
            var sugarRestResponse = new SugarRestResponse();
            var loginResponse = new LoginResponse();

            try
            {
                var loginRequest = new LoginRequest
                {
                    Url = request.Url,
                    Username = request.Username,
                    Password = request.Password
                };

                loginResponse = Authentication.Login(loginRequest);

                JArray objectList = JsonConverterHelper.SerializeList(request.Data, modelInfo.Type);
                var selectFields = modelInfo.GetJsonPropertyNames(request.Options.SelectFields);
                var insertEntriesResponse = InsertEntries.Run(loginResponse.SessionId, loginRequest.Url, request.ModuleName, objectList, selectFields);

                if (insertEntriesResponse != null)
                {
                    sugarRestResponse.JsonRawRequest = insertEntriesResponse.JsonRawRequest;
                    sugarRestResponse.JsonRawResponse = insertEntriesResponse.JsonRawResponse;

                    if ((insertEntriesResponse.Ids != null) && (insertEntriesResponse.Ids.Count > 0))
                    {
                        sugarRestResponse.Ids = insertEntriesResponse.Ids;
                        sugarRestResponse.StatusCode = insertEntriesResponse.StatusCode;
                    }
                    else
                    {
                        sugarRestResponse.Error = insertEntriesResponse.Error;
                        sugarRestResponse.StatusCode = insertEntriesResponse.StatusCode;
                    }
                }

                return sugarRestResponse;
            }
            catch (Exception exception)
            {
                sugarRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                sugarRestResponse.Error = ErrorResponse.Format(exception, string.Empty);
            }
            finally
            {
                Authentication.Logout(request.Url, loginResponse.SessionId);
            }

            return sugarRestResponse;
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="client">SugarRestClient object</param>
        /// <param name="request">The request object</param>
        /// <param name="modelInfo">The entity model info.</param>
        /// <returns>SugarRestResponse object</returns>
        public static SugarRestResponse ExecuteUpdate(this SugarRestClient client, SugarRestRequest request, ModelInfo modelInfo) 
        {
            var sugarRestResponse = new SugarRestResponse();
            var loginResponse = new LoginResponse();

            try
            {
                var loginRequest = new LoginRequest
                {
                    Url = request.Url,
                    Username = request.Username,
                    Password = request.Password
                };

                loginResponse = Authentication.Login(loginRequest);

                JObject jobject = JsonConverterHelper.Serialize(request.Data, modelInfo.Type);
                var selectFields = modelInfo.GetJsonPropertyNames(request.Options.SelectFields);
                var updateEntryResponse = UpdateEntry.Run(loginResponse.SessionId, loginRequest.Url, request.ModuleName, jobject, selectFields);

                if (updateEntryResponse != null)
                {
                    sugarRestResponse.JsonRawRequest = updateEntryResponse.JsonRawRequest;
                    sugarRestResponse.JsonRawResponse = updateEntryResponse.JsonRawResponse;

                    if (!string.IsNullOrEmpty(updateEntryResponse.Id))
                    {
                        sugarRestResponse.Id = updateEntryResponse.Id;
                        sugarRestResponse.StatusCode = updateEntryResponse.StatusCode;
                    }
                    else
                    {
                        sugarRestResponse.Error = updateEntryResponse.Error;
                        sugarRestResponse.StatusCode = updateEntryResponse.StatusCode;
                    }
                }

                return sugarRestResponse;
            }
            catch (Exception exception)
            {
                sugarRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                sugarRestResponse.Error = ErrorResponse.Format(exception, string.Empty);
            }
            finally
            {
                Authentication.Logout(request.Url, loginResponse.SessionId);
            }

            return sugarRestResponse;
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="client">SugarRestClient object</param>
        /// <param name="request">The request object</param>
        /// <param name="modelInfo">The entity model info.</param>
        /// <returns>SugarRestResponse object</returns>
        public static SugarRestResponse ExecuteUpdates(this SugarRestClient client, SugarRestRequest request, ModelInfo modelInfo)
        {
            var sugarRestResponse = new SugarRestResponse();
            var loginResponse = new LoginResponse();

            try
            {
                var loginRequest = new LoginRequest
                {
                    Url = request.Url,
                    Username = request.Username,
                    Password = request.Password
                };

                loginResponse = Authentication.Login(loginRequest);

                JArray objectList = JsonConverterHelper.SerializeList(request.Data, modelInfo.Type);
                var selectFields = modelInfo.GetJsonPropertyNames(request.Options.SelectFields);
                var updateEntriesResponse = UpdateEntries.Run(loginResponse.SessionId, loginRequest.Url, request.ModuleName, objectList, selectFields);

                if (updateEntriesResponse != null)
                {
                    sugarRestResponse.JsonRawRequest = updateEntriesResponse.JsonRawRequest;
                    sugarRestResponse.JsonRawResponse = updateEntriesResponse.JsonRawResponse;

                    if ((updateEntriesResponse.Ids != null) && (updateEntriesResponse.Ids.Count > 0))
                    {
                        sugarRestResponse.Ids = updateEntriesResponse.Ids;
                        sugarRestResponse.StatusCode = updateEntriesResponse.StatusCode;
                    }
                    else
                    {
                        sugarRestResponse.Error = updateEntriesResponse.Error;
                        sugarRestResponse.StatusCode = updateEntriesResponse.StatusCode;
                    }
                }

                return sugarRestResponse;
            }
            catch (Exception exception)
            {
                sugarRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                sugarRestResponse.Error = ErrorResponse.Format(exception, string.Empty);
            }
            finally
            {
                Authentication.Logout(request.Url, loginResponse.SessionId);
            }

            return sugarRestResponse;
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="client">SugarRestClient object</param>
        /// <param name="request">The request object</param>
        /// <param name="modelInfo">The entity model info.</param>
        /// <returns>SugarRestResponse object</returns>
        public static SugarRestResponse ExecuteDelete(this SugarRestClient client, SugarRestRequest request, ModelInfo modelInfo) 
        {
            var sugarRestResponse = new SugarRestResponse();
            var loginResponse = new LoginResponse();

            try
            {
                var loginRequest = new LoginRequest
                {
                    Url = request.Url,
                    Username = request.Username,
                    Password = request.Password
                };

                loginResponse = Authentication.Login(loginRequest);

                var deleteEntryResponse = DeleteEntry.Run(loginResponse.SessionId, loginRequest.Url, request.ModuleName, request.Id);

                if (deleteEntryResponse != null)
                {
                    sugarRestResponse.JsonRawRequest = deleteEntryResponse.JsonRawRequest;
                    sugarRestResponse.JsonRawResponse = deleteEntryResponse.JsonRawResponse;

                    if (!string.IsNullOrEmpty(deleteEntryResponse.Id))
                    {
                        sugarRestResponse.Id = deleteEntryResponse.Id;
                        sugarRestResponse.StatusCode = deleteEntryResponse.StatusCode;
                    }
                    else
                    {
                        sugarRestResponse.Error = deleteEntryResponse.Error;
                        sugarRestResponse.StatusCode = deleteEntryResponse.StatusCode;
                    }
                }

                return sugarRestResponse;
            }
            catch (Exception exception)
            {
                sugarRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                sugarRestResponse.Error = ErrorResponse.Format(exception, string.Empty);
            }
            finally
            {
                Authentication.Logout(request.Url, loginResponse.SessionId);
            }

            return sugarRestResponse;
        }
    }
}
