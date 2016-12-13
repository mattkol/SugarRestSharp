// -----------------------------------------------------------------------
// <copyright file="LinkedListModule.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.RestApiCalls.Responses
{
    using Newtonsoft.Json;
    using SugarRestSharp.Responses;
    using System.Collections.Generic;

    internal class LinkedListModule
    {
        [JsonProperty(PropertyName = "link_list")]
        public List<LinkedListModuleData> ModuleDataList { get; set; }
    }
}
