// -----------------------------------------------------------------------
// <copyright file="Util.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.MethodCalls
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Represents the Util class
    /// </summary>
    internal static class Util
    {
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
