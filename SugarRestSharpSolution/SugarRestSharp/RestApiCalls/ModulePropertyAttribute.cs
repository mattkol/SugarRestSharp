// -----------------------------------------------------------------------
// <copyright file="ModulePropertyAttribute.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System;

    /// <summary>
    /// Sugar crm module attributes [ModuleName - name of module, Tablename - name of associated table]
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class ModulePropertyAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets module name
        /// </summary>
        public string ModuleName { get;  set; }

        /// <summary>
        /// Gets or sets table name
        /// </summary>
        public string TableName { get;  set; }
    }
}