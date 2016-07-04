// -----------------------------------------------------------------------
// <copyright file="SchemaReader.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.PocoGen.Readers
{
    using System;
    using Models;

    /// <summary>
    /// This abstract class for schema reading.
    /// </summary>
    public abstract class SchemaReader : IDisposable
    {
        /// <summary>
        /// Reads the Schema returning all tables in the databse.
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <returns>List of table objects</returns>
        public abstract Tables ReadSchema(string connectionString);

        /// <summary>
        /// Disposes of objects
        /// </summary>
        public abstract void Dispose();
    }
}
