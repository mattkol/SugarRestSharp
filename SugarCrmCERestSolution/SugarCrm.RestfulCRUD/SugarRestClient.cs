// -----------------------------------------------------------------------
// <copyright file="SugarRestClient.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;

namespace SugarCrm.RestfulCRUD
{
    using RestApiCalls;
    using RestApiCalls.MethodCalls;

    /// <summary>
    /// Represents SugarRestClient class
    /// </summary>
    public class SugarRestClient
    {
        public SugarRestResponse GetById(SugarRestRequest request)
        {
            return this.ExecuteGetById(request);
        }

        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse GetById<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            request.ModuleName = Util.GetModuleName(typeof(TEntity));
            var response = this.ExecuteGetById(request);

            if (!string.IsNullOrEmpty(response.Content))
            {
                response.Data = JsonConvert.DeserializeObject<TEntity>(response.Content);
            }

            return response;
        }

        /// <summary>
        /// Gets all entities limited by MaxResultCount sets in request options
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse GetAll(SugarRestRequest request)
        {
            return this.ExecuteGetAll(request);
        }

        /// <summary>
        /// Gets all entities limited by MaxResultCount sets in request options
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse GetAll<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            request.ModuleName = Util.GetModuleName(typeof(TEntity));
            var response = this.ExecuteGetById(request);

            if (!string.IsNullOrEmpty(response.Content))
            {
                response.Data = JsonConvert.DeserializeObject<List<TEntity>>(response.Content);
            }

            return response;
        }

        /// <summary>
        /// Gets all entities by poge. Page options set in request options
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse GetPaged(SugarRestRequest request)
        {
            return this.ExecuteGetPaged(request);
        }

        /// <summary>
        /// Gets all entities by poge. Page options set in request options
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse GetPaged<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            request.ModuleName = Util.GetModuleName(typeof(TEntity));
            var response = this.ExecuteGetById(request);

            if (!string.IsNullOrEmpty(response.Content))
            {
                response.Data = JsonConvert.DeserializeObject<List<TEntity>>(response.Content);
            }

            return response;
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Insert(SugarRestRequest request)
        {
            return this.ExecuteInsert(request);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Insert<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            request.ModuleName = Util.GetModuleName(typeof(TEntity));
            return this.ExecuteInsert(request);
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Inserts(SugarRestRequest request)
        {
            return this.ExecuteInserts(request);
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Inserts<TEntity>(SugarRestRequest request) where TEntity : EntityBase
        {
            request.ModuleName = Util.GetModuleName(typeof(TEntity));
            return this.ExecuteInserts(request);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Update(SugarRestRequest request)
        {
            return this.ExecuteUpdate(request);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Update<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            request.ModuleName = Util.GetModuleName(typeof(TEntity));
            return this.ExecuteUpdate(request);
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Updates(SugarRestRequest request)
        {
            return this.ExecuteUpdates(request);
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Updates<TEntity>(SugarRestRequest request) where TEntity : EntityBase
        {
            request.ModuleName = Util.GetModuleName(typeof(TEntity));
            return this.ExecuteUpdates(request);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Delete(SugarRestRequest request)
        {
            return this.ExecuteDelete(request);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object</returns>
        public SugarRestResponse Delete<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            request.ModuleName = Util.GetModuleName(typeof(TEntity));
            return this.ExecuteDelete(request);
        }
    }
}
