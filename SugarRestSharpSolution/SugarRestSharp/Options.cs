// -----------------------------------------------------------------------
// <copyright file="Options.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents Options class
    /// </summary>
    public class Options
    {
        /// <summary>
        /// The default max result count
        /// </summary>
        private const int MaxCountResult = 100;

        /// <summary>
        /// Initializes a new instance of the Options class
        /// </summary>
        public Options()
        {
            this.MaxResult = MaxCountResult;
            this.SelectFields = new List<string>();
        }

        /// <summary>
        /// Gets or sets the current page number
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the number of entities per page
        /// </summary>
        public int NumberPerPage { get; set; }

        /// <summary>
        /// Gets or sets the max result entities to return
        /// </summary>
        public int MaxResult { get; set; }

        /// <summary>
        /// Gets or sets selected module fields to return
        /// </summary>
        public List<string> SelectFields { get; set; }

        /// <summary>
        /// Gets or sets the linked modules fields. 
        /// The selected fields (value) can be null or empty, but the module type or name (key) must be valid.
        /// </summary>
        public Dictionary<object, List<string>> LinkedFields{ get; set; }
    }
}
