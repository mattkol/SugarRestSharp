// -----------------------------------------------------------------------
// <copyright file="ModelnfoExtensions.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class represents ModelnfoExtensions class.
    /// </summary>
    internal static class ModelnfoExtensions
    {
        public static List<string> GetJsonPropertyNames(this ModelInfo modelInfo, List<string> selectedProperties)
        {
            var newSelectedProperties = new List<string>();

            if ((modelInfo == null) || (modelInfo.ModelProperties == null) || (selectedProperties == null))
            {
                return selectedProperties;
            }

            List<ModelProperty> modelProperties = modelInfo.ModelProperties;
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
    }
}