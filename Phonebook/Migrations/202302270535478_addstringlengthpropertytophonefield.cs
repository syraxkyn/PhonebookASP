namespace Phonebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstringlengthpropertytophonefield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HandbookRecords", "Phone", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HandbookRecords", "Phone", c => c.String(nullable: false));
        }
    }
}
