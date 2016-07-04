// -----------------------------------------------------------------------
// <copyright file="Util.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestApiCalls.MethodCalls
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Represents the Util class
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Gets module name from model type
        /// </summary>
        /// <param name="type">Model entity type</param>
        /// <returns>Module name</returns>
        public static string GetModuleName(Type type)
        {
            string moduleName = string.Empty;

            object[] attrs = type.GetCustomAttributes(typeof(ModulePropertyAttribute), false);
            if (attrs.Length == 1)
            {
                moduleName = ((ModulePropertyAttribute)attrs[0]).ModuleName;
            }

            return moduleName;
        }

        /// <summary>
        /// Calculates and returns password hash as required by SugarCrm REST API calls
        /// </summary>
        /// <param name="password">The user supplied plain password</param>
        /// <returns>Hased password</returns>
        public static string CalculateMd5Hash(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                stringBuilder.Append(hash[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
