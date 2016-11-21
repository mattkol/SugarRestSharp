// -----------------------------------------------------------------------
// <copyright file="DbServerType.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.PocoGen
{
    /// <summary>
    /// This enum class represents DbServerType class.
    /// </summary>
    public enum DbServerType
    {
        /// <summary>
        /// MS SQL database type
        /// </summary>
        MsSql,

        /// <summary>
        /// Sqlite database type
        /// </summary>
        Sqlite,

        /// <summary>
        /// MySql database type
        /// </summary>
        MySql,

        /// <summary>
        /// PostgreSQL database type
        /// </summary>
        Postgres
    }
}