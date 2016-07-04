// -----------------------------------------------------------------------
// <copyright file="Key.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.PocoGen.Models
{
    /// <summary>
    /// This class represents a key of table column.
    /// </summary>
    public class Key
    {
        /// <summary>
        /// Gets or sets key name. For foreign key this is the constraint name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets referenced table name.
        /// </summary>
        public string ReferencedTableName { get; set; }

        /// <summary>
        /// Gets or sets column name referenced in referenced table.
        /// </summary>
        public string ReferencedTableColumnName { get; set; }

        /// <summary>
        /// Gets or sets the refenrencing table name. This will be the table where key is defined.
        /// </summary>
        public string ReferencingTableName { get; set; }

        /// <summary>
        /// Gets or sets the refenrencing column name. This will be in the table where key is defined.
        /// </summary>
        public string ReferencingTableColumnName { get; set; }
    }
}
