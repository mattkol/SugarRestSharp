// -----------------------------------------------------------------------
// <copyright file="ModelnfoExtensions.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.Helpers
{
    using RestApiCalls.Helpers;
    using RestApiCalls.Requests;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class represents ModelnfoExtensions class.
    /// </summary>
    internal static class ModelnfoExtensions
    {
        /// <summary>
        /// Gets list of json property names based on the selected properties.
        /// The property name can be of json type or C# property name.
        /// And they can be mixed.
        /// </summary>
        /// <param name="modelInfo">SugarCRM module info.</param>
        /// <param name="selectedProperties">The selected property names.</param>
        /// <param name="makeSelectionOptional">Selection is optional. If no selection set, all properties returned if this value is true.</param>
        /// <returns>List of module json properties.</returns>
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

        /// <summary>
        /// Gets modules linked information.
        /// </summary>
        /// <param name="modelInfo">SugarCRM module info.</param>
        /// <param name="linkedModuleInfoList">The module linked info list.</param>
        /// <returns>Dictionary map of linked modules.</returns>
        public static Dictionary<string, List<string>> GetJsonLinkedInfo(this ModelInfo modelInfo, Dictionary<object, List<string>> linkedModuleInfoList)
        {
            if ((linkedModuleInfoList == null) || (linkedModuleInfoList.Count == 0))
            {
                return null;
            }

            var linkedInfo = new Dictionary<string, List<string>>();

            foreach (var item in linkedModuleInfoList)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelInfo"></param>
        /// <param name="queryPredicates"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static string GetQuery(this ModelInfo modelInfo, List<QueryPredicate> queryPredicates, string queryString)
        {
            if (!string.IsNullOrEmpty(queryString))
            {
                return " " + queryString.Trim() + " ";
            }

            List<JsonPredicate> jsonPredicates = modelInfo.GetJsonPredicates(queryPredicates);

            return QueryBuilder.GetWhereClause(jsonPredicates);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelInfo"></param>
        /// <param name="queryPredicates"></param>
        /// <returns></returns>
        private static List<JsonPredicate> GetJsonPredicates(this ModelInfo modelInfo, List<QueryPredicate> queryPredicates)
        {
            if ((queryPredicates == null) || (queryPredicates.Count == 0))
            {
                return null;
            }

            var jsonPredicates = new List<JsonPredicate>();

            List<ModelProperty> modelProperties = modelInfo.ModelProperties;

            foreach (var item in queryPredicates)
            {

                ModelProperty modelProperty = modelProperties.FirstOrDefault(x => ( (x.Name.ToLower() == item.PropertyName.ToLower()) ||
                                                                                    (x.JsonName.ToLower() == item.PropertyName.ToLower()) ));

                if (modelProperty != null)
                {
                    string jsonName = string.Format("{0}.{1}", modelInfo.JsonModelName, modelProperty.JsonName);
                    bool isNumeric = modelProperty.IsNumeric;
                    string value = GetFormattedValue(item.Value, isNumeric);
                    string fromValue = GetFormattedValue(item.FromValue, isNumeric); 
                    string toValue = GetFormattedValue(item.ToValue, isNumeric); 

                    jsonPredicates.Add(new JsonPredicate(jsonName, item.Operator, value, fromValue, toValue));
                }
            }

            return jsonPredicates;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isNumeric"></param>
        /// <returns></returns>
        private static string GetFormattedValue(object value, bool isNumeric)
        {
            if (value == null)
            {
                return null;
            }

            if (IsList(value))
            {
                try
                {
                    IList valueList = (IList) value;
                    List<string> strValueList = new List<string>();
                    foreach (var item in valueList)
                    {
                        if (isNumeric)
                        {
                            strValueList.Add(item.ToString());
                        }
                        else
                        {
                            strValueList.Add("\'" + item.ToString() + "\'");
                        }
                    }

                    return string.Join(",", strValueList.ToArray()); 
                }
                catch (Exception)
                {
                }
            }

            return value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsList(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj is IList &&
                   obj.GetType().IsGenericType &&
                   obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }
    }
}