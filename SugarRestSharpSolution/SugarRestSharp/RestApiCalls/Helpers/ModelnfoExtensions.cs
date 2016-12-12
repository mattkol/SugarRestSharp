// -----------------------------------------------------------------------
// <copyright file="ModelnfoExtensions.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class represents ModelnfoExtensions class.
    /// </summary>
    internal static class ModelnfoExtensions
    {
        public static List<string> GetJsonPropertyNames(this ModelInfo modelInfo, List<string> selectedProperties, bool makeSelectionOptional = false)
        {
            var newSelectedProperties = new List<string>();

            if ((modelInfo == null) || (modelInfo.ModelProperties == null))
            {
                return selectedProperties;
            }

            List<ModelProperty> modelProperties = modelInfo.ModelProperties;
            if ( ((selectedProperties == null) || (selectedProperties.Count == 0)) && makeSelectionOptional)
            {
                return modelProperties.Select(x => x.JsonName).ToList();
            }

            foreach (string property in selectedProperties)
            {
                string jsonName = property;

                if (!string.IsNullOrEmpty(property))
                {
                    ModelProperty modelProperty = modelProperties.FirstOrDefault(x => (x.Name.ToLower() == property.ToLower()));
                    if (modelProperty != null)
                    {
                        jsonName = modelProperty.JsonName;
                    }
                }

                newSelectedProperties.Add(jsonName);
            }

            return newSelectedProperties;
        }

        public static Dictionary<string, List<string>> GetJsonLinkedInfo(this ModelInfo modelInfo, Dictionary<object, List<string>> linkedFields)
        {
            if ((linkedFields == null) || (linkedFields.Count == 0))
            {
                return null;
            }

            var linkedInfo = new Dictionary<string, List<string>>();

            foreach (var item in linkedFields)
            {
                ModelInfo linkedModelInfo = null;
                string moduleName = string.Empty;
                if(item.Key is Type)
                {
                    linkedModelInfo = ModelInfo.ReadByType((Type)item.Key);
                }
                else
                {
                    linkedModelInfo = ModelInfo.ReadByName(item.Key.ToString());
                }

                linkedInfo[linkedModelInfo.JsonModelName] = linkedModelInfo.GetJsonPropertyNames(item.Value, true);
            }

            return linkedInfo;
        }
    }
}