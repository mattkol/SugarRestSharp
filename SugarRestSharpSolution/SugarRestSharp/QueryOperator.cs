// -----------------------------------------------------------------------
// <copyright file="QueryOperator.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    public enum QueryOperator
    {
        /// <summary>
        /// Gets the equal.
        /// </summary>
        Equal,

        /// <summary>
        /// Gets the greater than.
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Gets the greater than or equal to.
        /// </summary>
        GreaterThanOrEqualTo,

        /// <summary>
        /// Gets the less than.
        /// </summary>
        LessThan,

        /// <summary>
        /// Gets the less than or equal to.
        /// </summary>
        LessThanOrEqualTo,

        /// <summary>
        /// Gets the contains.
        /// </summary>
        Contains,

        /// <summary>
        /// Gets the starts with.
        /// </summary>
        StartsWith,

        /// <summary>
        /// Gets the ends with.
        /// </summary>
        EndsWith,

        /// <summary>
        /// Gets the between.
        /// </summary>
        Between,

        /// <summary>
        /// The where in.
        /// </summary>
        WhereIn
    }
}
