// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.PocoGen.Console
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using Readers;
    using Templates;

    class Program
    {
        static void Main(string[] args)
        {
             using (var schemaReader = SchemaReaderProvider.GetReader(DbServerType.MySql))
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["MySqlSugarCrmConnectionString"].ConnectionString;;
                    if (schemaReader == null || string.IsNullOrEmpty(connectionString))
                    {
                      //  return new GeneratePocoResponse();
                    }

                    var tables = schemaReader.ReadSchema(connectionString);

                    if (tables == null || tables.Count <= 0)
                    {
                        throw new Exception(string.Format("Empty database or invalid connection string: {0}", connectionString));
                    }

                    var fileNames = new List<string>();
                    foreach (var table in tables)
                    {
                        var model = new ModelTemplate();
                        model.Namespace = "Sugar.PocoGen.Console.Models";
                        model.IncludeRelationships = true;
                        model.Table = table;
                        model.Tables = tables;

                        // get page content
                        string pageContent = model.TransformText();

                        string folder = "Models";
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        // Write model to file
                        string fileName = table.ClassName + ".cs";
                        File.WriteAllText(Path.Combine(folder, fileName), pageContent);
                        fileNames.Add(fileName);
                    }

                }
            }
    }
}
