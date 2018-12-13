using Exercise.EF.DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Exercise.EntityFramework.Test
{
    public class TestSetup
    {
        public void SetUpDatabase()
        {
            DestroyDatabase();
            CreateDatabase();
        }

        public void DeleteDatabase()
        {
            DestroyDatabase();
        }

        private static void CreateDatabase()
        {
            ExecuteSqlCommand(Master, $@"
                CREATE DATABASE [IntegrationTest]
                ON (NAME = 'Globalmantics',
                FILENAME = '{Filename}')");

            var migration = new MigrateDatabaseToLatestVersion<MyContext, Configuration>();

            migration.InitializeDatabase(new MyContext());
        }

        private static void DestroyDatabase()
        {
            var fileNames = ExecuteSqlQuery(Master, @"
                SELECT [physical_name] FROM [sys].[master_files]
                WHERE [database_id] = DB_ID('IntegrationTest')", row => (string)row["physical_name"]);

            if (fileNames.Any())
            {
                ExecuteSqlCommand(Master, @"
                    ALTER DATABASE [IntegrationTest] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    EXEC sp_detach_db 'IntegrationTest'");

                fileNames.ForEach(File.Delete);
            }
        }

        private static void ExecuteSqlCommand(SqlConnectionStringBuilder connectionStringBuilder,
                                              string commandText)
        {
            using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.ExecuteNonQuery();
                }
            }
        }

        private static List<T> ExecuteSqlQuery<T>(SqlConnectionStringBuilder connectionStringBuilder,
                                                  string queryText,
                                                  Func<SqlDataReader, T> read)
        {
            var result = new List<T>();
            using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = queryText;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(read(reader));
                        }
                    }
                }
            }
            return result;
        }

        private static SqlConnectionStringBuilder Master =>
            new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = "master",
                IntegratedSecurity = true
            };

        private static string Filename => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "IntegrationTest.mdf");
    }
}
