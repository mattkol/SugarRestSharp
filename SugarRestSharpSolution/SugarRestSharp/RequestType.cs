// -----------------------------------------------------------------------
// <copyright file="RequestType.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    /// <summary>
    /// Represents RequestType enum class
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// SugarCrm get by id method call
        /// </summary>
        ReadById,

        /// <summary>
        /// SugarCrm get all method call.
        /// </summary>
        BulkRead,

        /// <summary>
        /// SugarCrm get paged method call.
        /// </summary>
        PagedRead,

        /// <summary>
        /// SugarCrm create method call.
        /// </summary>
        Create,

        /// <summary>
        /// SugarCrm bulk create method call.
        /// </summary>
        BulkCreate,

        /// <summary>
        /// SugarCrm update method call.
        /// </summary>
        Update,

        /// <summary>
        /// SugarCrm bulk update method call.
        /// </summary>
        BulkUpdate,

        /// <summary>
        /// SugarCrm delete method call.
        /// </summary>
        Delete
    }
}
