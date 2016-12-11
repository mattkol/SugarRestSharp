// -----------------------------------------------------------------------
// <copyright file="ModelProperty.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System;

    /// <summary>
    /// This class represents ModelProperty class.
    /// </summary>
    internal class ModelProperty
    {
        /// <summary>
        /// Gets or sets the C# property name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property name in json.
        /// </summary>
        public string JsonName { get; set; }

        /// <summary>
        /// Gets or sets property C# object type.
        /// </summary>
        public Type Type { get; set; }
    }
}
