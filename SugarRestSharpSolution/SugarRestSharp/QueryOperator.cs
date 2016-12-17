// -----------------------------------------------------------------------
// <copyright file="QueryOperator.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    /// <summary>
    /// Represents the QueryOperator enum class.
    /// </summary>
    public enum QueryOperator
    {
        /// <summary>
        /// The "equal" operator.
        /// </summary>
        Equal,

        /// <summary>
        /// The "greater than" operator.
        /// </summary>
        GreaterThan,

        /// <summary>
        /// The "greater than or equal to" operator.
        /// </summary>
        GreaterThanOrEqualTo,

        /// <summary>
        /// The "less than" operator.
        /// </summary>
        LessThan,

        /// <summary>
        /// The "less than or equal to" operator.
        /// </summary>
        LessThanOrEqualTo,

        /// <summary>
        /// The "contains" operator.
        /// </summary>
        Contains,

        /// <summary>
        /// Gets the starts with operator.
        /// </summary>
        StartsWith,

        /// <summary>
        /// The "ends with" operator.
        /// </summary>
        EndsWith,

        /// <summary>
        /// The "between" operator.
        /// </summary>
        Between,

        /// <summary>
        /// The "where in" operator.
        /// </summary>
        WhereIn
    }
}
