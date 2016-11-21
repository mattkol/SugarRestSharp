// -----------------------------------------------------------------------
// <copyright file="GetEntityTests.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestfulCRUD.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using Xunit;

    /// <summary>
    /// This class represents GetEntityTests class.
    /// </summary>
    public class GetEntityTests
    {

        [Fact]
        public void GetEntitySuccessTest()
        {
            using (var schemaReader = SchemaReaderProvider.GetReader(DbServerType.MySql))
            {
                Tables tables = schemaReader.ReadSchema(_connectionString);

                Assert.NotNull(schemaReader);
                Assert.NotNull(tables);
                Assert.Equal(11, tables.Count);
            }
        }
    }
}

