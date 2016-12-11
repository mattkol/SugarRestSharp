// -----------------------------------------------------------------------
// <copyright file="SugarRestClient.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System;
    using System.Threading.Tasks;
    using System.Net;
    using Responses;

    /// <summary>
    /// Represents SugarRestClient class
    /// </summary>
    public class SugarRestClient
    {
        private string url;
        private string username;
        private string password;

        public SugarRestClient()
        {
        }

        public SugarRestClient(string url)
        {
            this.url = url;
        }

        public SugarRestClient(string url, string username, string password)
        {
            this.url = url;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// Execute client.
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Execute(SugarRestRequest request)
        {
            SugarRestResponse response = new SugarRestResponse();
            if (!IsRequestValidate(ref request,  ref response))
            {
                return response;
            }

            ModelInfo modelInfo = ModelInfo.ReadByName(request.ModuleName);
            return InternalExceute(request, modelInfo);
        }

        /// <summary>
        /// Execute client based on entity type.
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Execute<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            ModelInfo modelInfo = ModelInfo.ReadByType(typeof(TEntity));
            request.ModuleName = modelInfo.ModelName;

            SugarRestResponse response = new SugarRestResponse();
            if (!IsRequestValidate(ref request, ref response))
            {
                return response;
            }

            return InternalExceute(request, modelInfo);
        }

        public async Task<SugarRestResponse> ExecuteAsync(SugarRestRequest request)
        {
            SugarRestResponse response = new SugarRestResponse();
            if (!IsRequestValidate(ref request, ref response))
            {
                return response;
            }

            ModelInfo modelInfo = ModelInfo.ReadByName(request.ModuleName);
            return await Task.Run(() => { return InternalExceute(request, modelInfo); });
        }


        public async Task<SugarRestResponse> ExecuteAsync<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            ModelInfo modelInfo = ModelInfo.ReadByType(typeof(TEntity));
            request.ModuleName = modelInfo.ModelName;

            SugarRestResponse response = new SugarRestResponse();
            if (!IsRequestValidate(ref request, ref response))
            {
                return response;
            }
          
            return await Task.Run(() => { return InternalExceute(request, modelInfo); });
        }

        private SugarRestResponse InternalExceute(SugarRestRequest request, ModelInfo modelInfo)
        {
            switch (request.RequestType)
            {
                case RequestType.ReadById:
                {
                    return this.ExecuteGetById(request, modelInfo);
                }
                case RequestType.BulkRead:
                {
                    return this.ExecuteGetAll(request, modelInfo);
                }
                case RequestType.PagedRead:
                {
                    return this.ExecuteGetPaged(request, modelInfo);
                }
                case RequestType.Create:
                {
                    return this.ExecuteInsert(request, modelInfo);
                }
                case RequestType.BulkCreate:
                {
                    return this.ExecuteInserts(request, modelInfo);
                }
                case RequestType.Update:
                {
                    return this.ExecuteUpdate(request, modelInfo);
                }
                case RequestType.BulkUpdate:
                {
                    return this.ExecuteUpdates(request, modelInfo);
                }
                case RequestType.Delete:
                {
                    return this.ExecuteDelete(request, modelInfo);
                }
            }

            throw new Exception("Request type is invalid!");
        }


        private bool IsRequestValidate(ref SugarRestRequest request, ref SugarRestResponse response)
        {
            if (request == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Error = ErrorResponse.Format("Request is invalid.");
                return false;
            }

            request.Url = string.IsNullOrEmpty(request.Url) ? url : request.Url;
            request.Username = string.IsNullOrEmpty(request.Username) ? username : request.Username;
            request.Password = string.IsNullOrEmpty(request.Password) ? password : request.Password;

            if (!request.IsValid)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Error = ErrorResponse.Format(request.ValidationMessage);
                return false;
            }

            return true;
        }
    }
}
