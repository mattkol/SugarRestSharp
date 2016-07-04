// -----------------------------------------------------------------------
// <copyright file="SchemaReaderProvider.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.PocoGen.Readers
{
    using System;

    /// <summary>
    /// This class represents a provier class to get right schema reader based on database type.
    /// </summary>
    public class SchemaReaderProvider
    {
        /// <summary>
        /// Get reader based on database type
        /// </summary>
        /// <param name="dbserverType">Database type [MsSql, Sqlite, MySql PostgreSQL]</param>
        /// <returns>SchemaReader object</returns>
        public static SchemaReader GetReader(DbServerType dbserverType)
        {
            SchemaReader schemaReader = null;
            switch (dbserverType)
            {
                case DbServerType.MsSql:
                    throw new NotImplementedException();
                case DbServerType.Sqlite:
                   throw new NotImplementedException();
                case DbServerType.MySql:
                    schemaReader = new MySqlSugarSchemaReader();
                    break;
                case DbServerType.Postgres:
                    throw new NotImplementedException();
            }

            return schemaReader;
        }
    }
}
