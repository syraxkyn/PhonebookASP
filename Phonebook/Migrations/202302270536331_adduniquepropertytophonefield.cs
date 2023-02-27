namespace Phonebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduniquepropertytophonefield : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.HandbookRecords", "Phone", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.HandbookRecords", new[] { "Phone" });
        }
    }
}
