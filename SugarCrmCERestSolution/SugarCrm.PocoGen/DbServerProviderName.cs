// -----------------------------------------------------------------------
// <copyright file="DbServerProviderName.cs" company="Poco Generator for Lite ORMs">
// Copyright (c) Lite Poco Generator. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.PocoGen
{
    /// <summary>
    /// This class represents DbServerProviderName class.
    /// </summary>
    public static class DbServerProviderName
    {
        /// <summary>
        /// MS SQL provider name
        /// </summary>
        public static string MsSql = "System.Data.SqlClient";

        /// <summary>
        /// Sqlite provider name
        /// </summary>
        public static string Sqlite = "System.Data.SQLite";

        /// <summary>
        /// MySql provider name
        /// </summary>
        public static string MySql = "MySql.Data.MySqlClient";

        /// <summary>
        /// PostgreSQL provider name
        /// </summary>
        public static string Postgres = "Npgsql";
    }
}
