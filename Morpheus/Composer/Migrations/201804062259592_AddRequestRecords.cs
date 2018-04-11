namespace Composer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestRecords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestRecords",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RequestUrl = c.String(maxLength: Configuration.MaxUrlLength),
                        Source = c.String(maxLength: Configuration.StandardStringLength),
                        DataContent = c.String(),
                        Format = c.String(maxLength: Configuration.StandardStringLength),
                        DateCreated = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UserCreated = c.String(maxLength: Configuration.StandardStringLength),
                        DateModified = c.DateTime(defaultValueSql: "GETDATE()"),
                        UserModified = c.String(maxLength: Configuration.StandardStringLength),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RequestRecords");
        }
    }
}
