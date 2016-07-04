// -----------------------------------------------------------------------
// <copyright file="ModelTemplate.cs" company="Poco Generator for Lite ORMs">
// Copyright (c) Lite Poco Generator. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

// ReSharper disable CheckNamespace
namespace SugarCrm.PocoGen.Templates
// ReSharper restore CheckNamespace
{
    using Models;

    /// <summary>
    /// This class represents ModelTemplate class.
    /// This a partial class of the template class generated from ModelTemplate.tt.
    /// Note that the namespace - PocoGen.Templates matches the template file namespace.
    /// </summary>
    public partial class ModelTemplate
    {
        /// <summary>
        /// Gets or sets namespace of model
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include relationship
        /// </summary>
        public bool IncludeRelationships { get; set; }

        /// <summary>
        /// Gets or sets the table object
        /// </summary>
        public Table Table { get; set; }

        /// <summary>
        /// Gets or sets list of table objects
        /// </summary>
        public Tables Tables { get; set; }
    }
}