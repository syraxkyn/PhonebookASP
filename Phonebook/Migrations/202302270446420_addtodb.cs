namespace Phonebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HandbookRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HandbookRecords");
        }
    }
}
