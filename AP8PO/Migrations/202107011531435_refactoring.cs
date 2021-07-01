namespace AP8PO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "AllocationPercent", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "LoadPercent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "LoadPercent", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "AllocationPercent");
        }
    }
}
