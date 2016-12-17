// -----------------------------------------------------------------------
// <copyright file="ModelInfo.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents ModelInfo class.
    /// </summary>
    internal class ModelInfo
    {
        /// <summary>
        /// Gets or sets the SugarCrm model name.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets the SugarCrm json model name.
        /// This maps to the tablename in model attibute.
        /// </summary>
        public string JsonModelName { get; set; }

        /// <summary>
        /// Gets or sets model C# object type.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets model properties.
        /// </summary>
        public List<ModelProperty> ModelProperties { get; set; }

        /// <summary>
        /// Gets the module model info object.
        /// </summary>
        /// <param name="type">The module model type.</param>
        /// <returns>The model info object.</returns>
        public static ModelInfo ReadByType(Type type)
        {
            var modelInfo = new ModelInfo();

            if (type != null)
            {
                object[] classAttrs = type.GetCustomAttributes(typeof(ModulePropertyAttribute), false);
                if (classAttrs.Length == 1)
                {
                    string modelName = ((ModulePropertyAttribute)classAttrs[0]).ModuleName;
                    string jsonModelName = ((ModulePropertyAttribute)classAttrs[0]).TableName;
                    modelInfo.ModelName = modelName;
                    modelInfo.JsonModelName = jsonModelName;
                    modelInfo.Type = type;
                    modelInfo.ModelProperties = new List<ModelProperty>();

                    var props = type.GetProperties();
                    foreach (PropertyInfo prop in props)
                    {
                        object[] propAttrs = prop.GetCustomAttributes(true);
                        foreach (object attr in propAttrs)
                        {
                            var modelProperty = new ModelProperty();
                            var jsonProperty = attr as JsonPropertyAttribute;
                            if (jsonProperty != null)
                            {
                                modelProperty.Name = prop.Name;
                                modelProperty.Type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                modelProperty.JsonName = jsonProperty.PropertyName;
                                modelInfo.ModelProperties.Add(modelProperty);
                            }
                        }
                    }
                }
            }

            return modelInfo;
        }

        /// <summary>
        /// Gets the module model info object.
        /// </summary>
        /// <param name="modelName">The module model name.</param>
        /// <returns>The model info object.</returns>
        public static ModelInfo ReadByName(string modelName)
        {
            var modelInfo = new ModelInfo();

            var types = from type in typeof(ModulePropertyAttribute).Assembly.GetTypes()
                        where Attribute.IsDefined(type, typeof(ModulePropertyAttribute))
                        select type;

            foreach (var type in types)
            {
                object[] classAttrs = type.GetCustomAttributes(typeof(ModulePropertyAttribute), false);
                if (classAttrs.Length == 1)
                {
                    string attrModelName = ((ModulePropertyAttribute)classAttrs[0]).ModuleName;
                    string attrJsonModelName = ((ModulePropertyAttribute)classAttrs[0]).TableName;

                    if (!string.IsNullOrEmpty(attrModelName) && (attrModelName.ToLower() == modelName.ToLower()))
                    {
                        modelInfo.ModelName = attrModelName;
                        modelInfo.JsonModelName = attrJsonModelName;
                        modelInfo.Type = type;
                        modelInfo.ModelProperties = new List<ModelProperty>();

                        var props = type.GetProperties();
                        foreach (PropertyInfo prop in props)
                        {
                            object[] propAttrs = prop.GetCustomAttributes(true);
                            foreach (object attr in propAttrs)
                            {
                                var modelProperty = new ModelProperty();
                                var jsonProperty = attr as JsonPropertyAttribute;
                                if (jsonProperty != null)
                                {
                                    modelProperty.Name = prop.Name;
                                    modelProperty.Type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                    modelProperty.JsonName = jsonProperty.PropertyName;
                                    modelInfo.ModelProperties.Add(modelProperty);
                                }
                            }
                        }

                        return modelInfo;
                    }
                }
            }

            return modelInfo;
        }

    }
}
