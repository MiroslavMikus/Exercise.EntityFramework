﻿namespace Exercise.EF.DAL.Migrations
{
    using System.Data.Entity;

    public class MigrateInitializer : MigrateDatabaseToLatestVersion<MyContext, Configuration>
    {
        public MigrateInitializer(string connectionString) : base(true, new Configuration() { TargetDatabase=new  System.Data.Entity.Infrastructure.DbConnectionInfo(connectionString,"System.Data.SqlClient") })
        {
        }

    }
}
