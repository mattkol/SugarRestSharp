// -----------------------------------------------------------------------
// <copyright file="Utils.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.PocoGen.Models
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class represents a schema reading utitlity class.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Cleans up string matching the compiled regex supplied.
        /// </summary>
        public static Regex RxCleanUp = new Regex(@"[^\w\d_]", RegexOptions.Compiled);

        /// <summary>
        /// Cleans up function.
        /// </summary>
        public static Func<string, string> CleanUp = (str) =>
            {
                str = RxCleanUp.Replace(str, "_");
                if (char.IsDigit(str[0]))
                {
                    str = "_" + str;
                }

                return str;
            };

        /// <summary>
        /// Checks if column is nullable.
        /// </summary>
        /// <param name="col">Column name</param>
        /// <returns>Column type</returns>
        public static string CheckNullable(Column col)
        {
            string result = string.Empty;
            if (col.IsNullable &&
                col.PropertyType != "byte[]" &&
                col.PropertyType != "string" &&
                col.PropertyType != "Microsoft.SqlServer.Types.SqlGeography" &&
                col.PropertyType != "Microsoft.SqlServer.Types.SqlGeometry")
            {
                result = "?";
            }

            return result;
        }

        /// <summary>
        /// Singularize word.
        /// </summary>
        /// <param name="word">String to turn into singular</param>
        /// <returns>Singularzed string</returns>
        public static string Singularize(string word)
        {
            var singularword =
                System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(
                    CultureInfo.GetCultureInfo("en-us")).Singularize(word);
            return singularword;
        }

        /// <summary>
        /// Pluralize word.
        /// </summary>
        /// <param name="word">String to turn into plural</param>
        /// <returns>Pluralized string</returns>
        public static string Pluralize(string word)
        {
            word = PascalCase(word);
            var singularword =
                System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(
                    CultureInfo.GetCultureInfo("en-us")).Pluralize(word);
            return singularword;
        }

        /// <summary>
        /// Function removes table prefixes not required.
        /// </summary>
        /// <param name="word">String to remove table prefixes from</param>
        /// <returns>Table with removed prefixes part</returns>
        public static string RemoveTablePrefixes(string word)
        {
            var cleanword = word;
            if (cleanword.StartsWith("tbl_"))
            {
                cleanword = cleanword.Replace("tbl_", string.Empty);
            }

            if (cleanword.StartsWith("tbl"))
            {
                cleanword = cleanword.Replace("tbl", string.Empty);
            }

            return cleanword;
        }

        /// <summary>
        /// Gets or sets a value indicating whether listed table prefixes are excluded.
        /// </summary>
        /// <param name="tablename">Table name</param>
        /// <param name="excludeTablePrefixes">List of prefixes to be excluded</param>
        /// <returns>True of false</returns>
        public static bool IsExcluded(string tablename, string[] excludeTablePrefixes)
        {
            for (int i = 0; i < excludeTablePrefixes.Length; i++)
            {
                string s = excludeTablePrefixes[i];
                if (tablename.StartsWith(s))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Cleans table name.
        /// </summary>
        /// <param name="tablename">Table name</param>m>
        /// <returns>Cleaned table name</returns>
        public static string CleanName(string tablename)
        {
            string cleanName = CleanUp(tablename);
            if (cleanName.StartsWith("tbl_"))
            {
                cleanName = cleanName.Replace("tbl_", string.Empty);
            }

            if (cleanName.StartsWith("tbl"))
            {
                cleanName = cleanName.Replace("tbl", string.Empty);
            }

            return cleanName;
        }

        /// <summary>
        /// Converts singularized cleaned  table (or column) name to first letter capitalized.
        /// </summary>
        /// <param name="cleanName">Cleaned table name</param>m>
        /// <returns>Class name</returns>
        public static string CleanNameToClassName(string cleanName)
        {
            string className = Singularize(RemoveTablePrefixes(cleanName));
            className = PascalCase(className);

            return className;
        }

        /// <summary>
        /// Make get property name prettier.
        /// </summary>
        /// <param name="name">Name to turn to Pascal case</param>m>
        /// <returns>Name in Pascal case</returns>
        public static string PascalCase(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            var modName = string.Empty;
            bool toUpper = false;
            for (int ctr = 0; ctr <= name.Length - 1; ctr++)
            {
                if (ctr == 0)
                {
                    modName = char.ToUpper(name[ctr]).ToString(CultureInfo.InvariantCulture);
                    continue;
                }

                if (name[ctr] == '_')
                {
                    toUpper = true;
                    continue;
                }

                if (toUpper)
                {
                    modName += char.ToUpper(name[ctr]).ToString(CultureInfo.InvariantCulture);
                    toUpper = false;
                    continue;
                }

                modName += name[ctr].ToString(CultureInfo.InvariantCulture);
            }

            return modName;
        }
    }
}
