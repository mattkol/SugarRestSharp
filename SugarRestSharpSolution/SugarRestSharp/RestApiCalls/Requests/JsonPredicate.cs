// -----------------------------------------------------------------------
// <copyright file="JsonPredicate.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.RestApiCalls.Requests
{
    /// <summary>
    /// Represents JsonPredicate class.
    /// </summary>
    internal class JsonPredicate
    {
        /// <summary>
        /// Initializes a new instance of the JsonPredicate class.
        /// </summary>
        /// <param name="propertyName">The property name. This can be a C# model property name or json property name.</param>
        /// <param name="queryOperator">The query operator.</param>
        /// <param name="value">The predicate value.</param>
        /// <param name="fromValue">The predicate from value.</param>
        /// <param name="toValue">The predicate to value.</param>
        public JsonPredicate(string propertyName, QueryOperator queryOperator, string value, string fromValue, string toValue)
        {
            this.PropertyName = propertyName;
            this.Operator = queryOperator;
            this.Value = value;
            this.FromValue = fromValue;
            this.ToValue = toValue;
        }

        /// <summary>
        /// Gets or sets the json property name.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public QueryOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the from value.
        /// </summary>
        public string FromValue { get; set; }

        /// <summary>
        /// Gets or sets the to value.
        /// </summary>
        public string ToValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether value is numeric or not.
        /// </summary>
        public bool IsNumeric { get; set; }
    }
}
