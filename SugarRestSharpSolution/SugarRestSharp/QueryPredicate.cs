// -----------------------------------------------------------------------
// <copyright file="QueryPredicate.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    public class QueryPredicate
    {
        public QueryPredicate(string propertyName, QueryOperator queryOperator, object value, object fromValue = null, object toValue = null)
        {
            PropertyName = propertyName;
            Operator = queryOperator;
            Value = value;
            FromValue = fromValue;
            ToValue = toValue;
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
        public object FromValue  { get; set; }

        /// <summary>
        /// Gets or sets the to value.
        /// </summary>
        public object ToValue { get; set; }
    }
}
