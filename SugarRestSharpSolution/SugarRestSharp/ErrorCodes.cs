// -----------------------------------------------------------------------
// <copyright file="ErrorCodes.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    /// <summary>
    /// Represents ErrorCodes class
    /// </summary>
    internal class ErrorCodes
    {
        /// <summary>
        /// Invalid url error code
        /// </summary>
        public static string UrlInvalid = "Url is not valid or not provided.";

        /// <summary>
        /// Invalid username error code
        /// </summary>
        public static string UsernameInvalid = "Username is not valid or not provided.";

        /// <summary>
        /// Invalid password error code
        /// </summary>
        public static string PasswordInvalid = "Password is not valid or not provided.";

        /// <summary>
        /// Invalid entity type error code
        /// </summary>
        public static string ModulenameInvalid = "Generic type T provided is not a valid EntityBase Type. Must be valid SugarCrm model.";

        /// <summary>
        /// Invalid identifier error code
        /// </summary>
        public static string IdInvalid = "Identifier is not valid or not provided.";

        /// <summary>
        /// Invalid enity or entities data error code
        /// </summary>
        public static string DataInvalid = "Entity or entities data object provided is not valid.";
    }
}
