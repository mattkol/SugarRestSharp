// -----------------------------------------------------------------------
// <copyright file="QueryPredicate.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    /// <summary>
    /// Represents QueryPredicate class.
    /// </summary>
    public class QueryPredicate
    {
        /// <summary>
        /// Initializes a new instance of the QueryPredicate class.
        /// </summary>
        /// <param name="propertyName">The property name. This can be a C# model property name or json property name.</param>
        /// <param name="queryOperator">The query operator.</param>
        /// <param name="value">The predicate value.</param>
        /// <param name="fromValue">The predicate from value.</param>
        /// <param name="toValue">The predicate to value.</param>
        public QueryPredicate(string propertyName, QueryOperator queryOperator, object value, object fromValue = null, object toValue = null)
        {
            this.PropertyName = propertyName;
            this.Operator = queryOperator;
            this.Value = value;
            this.FromValue = fromValue;
            this.ToValue = toValue;
        }

        /// <summary>
        /// Gets or sets the property name.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public QueryOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the from value.
        /// </summary>
        public object FromValue { get; set; }

        /// <summary>
        /// Gets or sets the to value.
        /// </summary>
        public object ToValue { get; set; }
    }
}
