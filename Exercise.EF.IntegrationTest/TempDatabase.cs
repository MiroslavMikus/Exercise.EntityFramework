using Exercise.EF.DAL.Migrations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Exercise.EntityFramework.Test
{
    public class TempDatabase : IDisposable
    {
        public string ConnectionString { get; private set; }

        public string DatabaseName { get; private set; }

        public TempDatabase(string databaseName = null)
        {
            DatabaseName = databaseName ?? Guid.NewGuid().ToString();

            SetUpDatabase(DatabaseName);

            ConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = DatabaseName,
                IntegratedSecurity = true
            }.ConnectionString;
        }

        internal void SetUpDatabase(string dbFileName)
        {
            DestroyDatabase(dbFileName);
            CreateDatabase(dbFileName);
        }

        internal void DeleteDatabase(string dbFileName)
        {
            DestroyDatabase(dbFileName);
        }

        internal static void CreateDatabase(string dbFileName)
        {
            ExecuteSqlCommand(Master, $@"
                CREATE DATABASE [{dbFileName}]
                ON (NAME = '{dbFileName}',
                FILENAME = '{Filename(dbFileName)}')");
        }

        internal static void DestroyDatabase(string dbFileName)
        {
            var fileNames = ExecuteSqlQuery(Master, $@"
                SELECT [physical_name] FROM [sys].[master_files]
                WHERE [database_id] = DB_ID('{dbFileName}')", row => (string)row["physical_name"]);

            if (fileNames.Any())
            {
                var detachDb = $"EXEC sp_detach_db '{dbFileName}'";

                if (!File.Exists(Filename(dbFileName)))
                {
                    ExecuteSqlCommand(Master, detachDb);
                }
                else
                {
                    ExecuteSqlCommand(Master, $"ALTER DATABASE [{dbFileName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;{detachDb}");
                }

                fileNames.ForEach(File.Delete);
            }
        }

        internal static void ExecuteSqlCommand(SqlConnectionStringBuilder connectionStringBuilder,
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

        internal static List<T> ExecuteSqlQuery<T>(SqlConnectionStringBuilder connectionStringBuilder,
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

        internal static SqlConnectionStringBuilder Master =>
            new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = "master",
                IntegratedSecurity = true
            };

        internal static string Filename(string dbFileName) => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), dbFileName + ".mdf");

        public void Dispose()
        {
            DestroyDatabase(DatabaseName);
        }
    }
}
