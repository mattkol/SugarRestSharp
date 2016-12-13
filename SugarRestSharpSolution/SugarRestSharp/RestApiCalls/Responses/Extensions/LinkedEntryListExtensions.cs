// -----------------------------------------------------------------------
// <copyright file="LinkedEntryListExtensions.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.RestApiCalls.Responses.Extensions
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class represents LinkedEntryListExtensions class.
    /// </summary>
    internal static class LinkedEntryListExtensions
    {
        public static void SetModuleLinkedList(this JObject module, LinkedListModule linkedListModule)
        {
            if (linkedListModule == null)
            {
                return;
            }

            if ((linkedListModule.ModuleDataList == null) || (linkedListModule.ModuleDataList.Count == 0))
            {
                return;
            }

            foreach (var item in linkedListModule.ModuleDataList)
            {
                module[item.ModuleName] = JToken.FromObject(item.FormattedRecords);
            }
        }
     }
}