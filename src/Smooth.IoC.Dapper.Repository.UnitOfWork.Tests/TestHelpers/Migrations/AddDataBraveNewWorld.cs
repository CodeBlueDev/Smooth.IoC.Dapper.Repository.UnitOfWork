﻿using System;
using SimpleMigrations;

namespace Smooth.IoC.Dapper.FastCRUD.Repository.UnitOfWork.Tests.TestHelpers.Migrations
{
    [Migration(2)]
    public class AddDataBraveNewWorld : Migration
    {
        public override void Up()
        {
            if (!DB.ConnectionString.Contains("RepoTests.db") && !DB.ConnectionString.Contains(":memory:;")) return;
            Execute($@"INSERT INTO Worlds (Guid) VALUES ('{Guid.NewGuid()}');");
            Execute($@"INSERT INTO Worlds (Guid) VALUES ('{Guid.NewGuid()}');");
            Execute($@"INSERT INTO Worlds (Guid) VALUES ('{Guid.NewGuid()}');");

            Execute($@"INSERT INTO News (WorldId) VALUES (2);");
            Execute($@"INSERT INTO News (WorldId) VALUES (3);");
            Execute($@"INSERT INTO News (WorldId) VALUES (1);");

            Execute($@"INSERT INTO Braves (NewId) VALUES (3);");
            Execute($@"INSERT INTO Braves (NewId) VALUES (1);");
            Execute($@"INSERT INTO Braves (NewId) VALUES (2);");
        }

        public override void Down()
        {
            Execute("DROP TABLE Brave");
            Execute("DROP TABLE New");
            Execute("DROP TABLE World");
        }
    }
}
