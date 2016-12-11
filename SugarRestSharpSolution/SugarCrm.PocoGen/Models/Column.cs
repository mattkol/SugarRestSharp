// -----------------------------------------------------------------------
// <copyright file="Column.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.PocoGen.Models
{
    /// <summary>
    /// This class represents a table column.
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Gets or sets name of the column name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name of the class property name.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets name of the class property type.
        /// </summary>
        public string PropertyType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether column is a primary key column.
        /// </summary>
        public bool IsPk { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether column is nullable.
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether column is an autocrement.
        /// </summary>
        public bool IsAutoIncrement { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether column should be ignored in mapping.
        /// </summary>
        public bool Ignore { get; set; }
    }
}
