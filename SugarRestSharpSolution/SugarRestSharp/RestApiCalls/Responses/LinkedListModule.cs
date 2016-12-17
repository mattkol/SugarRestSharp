// -----------------------------------------------------------------------
// <copyright file="LinkedListModule.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.RestApiCalls.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using SugarRestSharp.Responses;

    /// <summary>
    /// Represents LinkedListModule class.
    /// </summary>
    internal class LinkedListModule
    {
        /// <summary>
        /// Gets or sets the linked module data list info.
        /// </summary>
        [JsonProperty(PropertyName = "link_list")]
        public List<LinkedListModuleData> ModuleDataList { get; set; }
    }
}
