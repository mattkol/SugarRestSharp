// -----------------------------------------------------------------------
// <copyright file="RequestType.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestfulCRUD
{
    /// <summary>
    /// Represents RequestType enum class
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// SugarCrm get by id method call
        /// </summary>
        GetById,

        /// <summary>
        /// SugarCrm get all method call
        /// </summary>
        GetAll,

        /// <summary>
        /// SugarCrm get paged method call
        /// </summary>
        GetPaged,

        /// <summary>
        /// SugarCrm create method call
        /// </summary>
        Insert,

        /// <summary>
        /// SugarCrm update method call
        /// </summary>
        Update,

        /// <summary>
        /// SugarCrm delete method call
        /// </summary>
        Delete
    }
}
