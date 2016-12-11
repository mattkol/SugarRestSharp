// -----------------------------------------------------------------------
// <copyright file="MySqlSugarSchemaReader.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.PocoGen.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Models;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// This class represents a MySql database schema reader.
    /// Class inherits abstract class SchemaReader.
    /// </summary>
    public class MySqlSugarSchemaReader : SchemaReader
    {
        /// <summary>
        /// MySql connection object.
        /// </summary>
         private MySqlConnection connection;

        /// <summary>
        /// Reads the Schema returning all tables in the databse.
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <returns>List of table objects</returns>
        public override Tables ReadSchema(string connectionString)
        {
            this.connection = new MySqlConnection(connectionString);
            var result = new Tables();

            this.connection.Open();

            using (var sqlCommand = new MySqlCommand(TableSql, this.connection))
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tbl = new Table();
                        tbl.Name = reader["TABLE_NAME"].ToString();
                        tbl.Schema = reader["TABLE_SCHEMA"].ToString();
                        tbl.IsView = string.Compare(reader["TABLE_TYPE"].ToString(), "View", StringComparison.OrdinalIgnoreCase) == 0;
                        tbl.CleanName = Utils.CleanName(tbl.Name);
                        tbl.ClassName = Utils.CleanNameToClassName(tbl.CleanName);
                        result.Add(tbl);
                    }
                }
            }

            // this will return everything for the DB
            var schema = this.connection.GetSchema("COLUMNS");

            // loop again - but this time pull by table name
            foreach (var item in result)
            {
                item.Columns = new List<Column>();

                // pull the columns from the schema
                var columns = schema.Select("TABLE_NAME='" + item.Name + "'");
                foreach (var row in columns)
                {
                    Column col = new Column();
                    col.Name = row["COLUMN_NAME"].ToString();
                    col.PropertyName = Utils.CleanUp(col.Name);
                    col.PropertyType = GetPropertyType(row);
                    col.IsNullable = row["IS_NULLABLE"].ToString() == "YES";
                    col.IsPk = row["COLUMN_KEY"].ToString() == "PRI";
                    col.IsAutoIncrement = row["extra"].ToString().ToLower().IndexOf("auto_increment", StringComparison.CurrentCultureIgnoreCase) >= 0;
                    item.Columns.Add(col);
                }

                // Only table with single primary key is allowed for this implementation
                // number of columns that are valid primary keys
                int pkeyCount = item.Columns.Count(x => x.IsPk);
                if (pkeyCount > 1)
                {
                    foreach (var column in item.Columns)
                    {
                        column.IsPk = false;
                    }
                }
            }

            var referencesInfoDataTable = this.connection.GetSchema("Foreign Key Columns");
            this.LoadReferencesKeysInfo(result, referencesInfoDataTable);

            return result;
        }

        /// <summary>
        /// Dispose resources.
        /// </summary>
        public sealed override void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose resources.
        /// </summary>
        /// <param name="disposing">True or false if currenlt disposing objects</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Gets the property type from the column.
        /// </summary>
        /// <param name="row">DataRow object</param>
        /// <returns>Property type</returns>
        private static string GetPropertyType(DataRow row)
        {
            bool bunsigned = row["COLUMN_TYPE"].ToString().IndexOf("unsigned", StringComparison.CurrentCultureIgnoreCase) >= 0;
            string propType = "string";
            switch (row["DATA_TYPE"].ToString())
            {
                case "bigint":
                    propType = bunsigned ? "ulong" : "long";
                    break;
                case "int":
                    propType = bunsigned ? "uint" : "int";
                    break;
                case "smallint":
                    propType = bunsigned ? "ushort" : "short";
                    break;
                case "guid":
                    propType = "Guid";
                    break;
                case "smalldatetime":
                case "date":
                case "datetime":
                case "timestamp":
                    propType = "DateTime";
                    break;
                case "float":
                    propType = "float";
                    break;
                case "double":
                    propType = "double";
                    break;
                case "numeric":
                case "smallmoney":
                case "decimal":
                case "money":
                    propType = "decimal";
                    break;
                case "bit":
                case "bool":
                case "boolean":
                    propType = "bool";
                    break;
                case "tinyint":
                    propType = bunsigned ? "byte" : "sbyte";
                    break;
                case "image":
                case "binary":
                case "blob":
                case "mediumblob":
                case "longblob":
                case "varbinary":
                    propType = "byte[]";
                    break;
            }

            return propType;
        }

        /// <summary>
        /// Loads the reference keys info for the entire database.
        /// </summary>
        /// <param name="tables">List of table objects</param>
        /// <param name="dataTable">DataTable object</param>
        private void LoadReferencesKeysInfo(Tables tables, DataTable dataTable)
        {
            var innerKeysDic = new Dictionary<string, List<Key>>();
            foreach (var item in tables)
            {
                item.OuterKeys = new List<Key>();
                item.InnerKeys = new List<Key>();

                // pull the foreign key details from the schema
                var columns = dataTable.Select("TABLE_NAME='" + item.Name + "'");
                foreach (DataRow row in columns)
                {
                    // Outer keys
                    var outerKey = new Key();
                    outerKey.Name = row["CONSTRAINT_NAME"].ToString();
                    var referencedTable = row["REFERENCED_TABLE_NAME"].ToString();
                    outerKey.ReferencedTableName = referencedTable;
                    outerKey.ReferencedTableColumnName = row["REFERENCED_COLUMN_NAME"].ToString();
                    outerKey.ReferencingTableColumnName = row["COLUMN_NAME"].ToString();
                    item.OuterKeys.Add(outerKey);

                    var innerKey = new Key();
                    innerKey.Name = row["CONSTRAINT_NAME"].ToString();
                    innerKey.ReferencingTableName = row["TABLE_NAME"].ToString();
                    innerKey.ReferencedTableColumnName = row["REFERENCED_COLUMN_NAME"].ToString();
                    innerKey.ReferencingTableColumnName = row["COLUMN_NAME"].ToString();

                    // add to inner keys references
                    if (innerKeysDic.ContainsKey(referencedTable))
                    {
                        var innerKeys = innerKeysDic[referencedTable];
                        innerKeys.Add(innerKey);
                        innerKeysDic[referencedTable] = innerKeys;
                    }
                    else
                    {
                        var innerKeys = new List<Key>();
                        innerKeys.Add(innerKey);
                        innerKeysDic[referencedTable] = innerKeys;
                    }
                }
            }

            // add inner references to tables
            foreach (var item in tables)
            {
                if (innerKeysDic.ContainsKey(item.Name))
                {
                    var innerKeys = innerKeysDic[item.Name];
                    item.InnerKeys = innerKeys;
                }
            }
        }

        /// <summary>
        /// Sql query to get table schema info.
        /// </summary>
        private const string TableSql = @"
			SELECT * 
			FROM information_schema.tables 
			WHERE (table_type='BASE TABLE' OR table_type='VIEW') AND TABLE_SCHEMA=DATABASE()
			";
    }
 }
