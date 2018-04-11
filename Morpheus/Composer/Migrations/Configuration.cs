namespace Composer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //Entity Framework
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.SqlServer;

    internal sealed class Configuration : DbMigrationsConfiguration<ComposerEngine>
    {
        public static int MaxUrlLength = 2083;
        public static int StandardStringLength = 50;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new BaseEntitySqlServerMigrationSqlGenerator());
        }

        protected override void Seed(ComposerEngine context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }

    internal class BaseEntitySqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetCreatedUtcColumn(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetCreatedUtcColumn(createTableOperation.Columns);

            base.Generate(createTableOperation);
        }

        private static void SetCreatedUtcColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (var columnModel in columns)
            {
                SetCreatedUtcColumn(columnModel);
            }
        }

        private static void SetCreatedUtcColumn(PropertyModel column)
        {
            if (column.Name == "DateCreated")
            {
                column.DefaultValueSql = "GETDATE()";
            }
            if (column.Name == "DateModified")
            {
                column.DefaultValueSql = "GETDATE()";
            }
        }
    }
}
