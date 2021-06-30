namespace AP8PO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CourseCommits", name: "Employee_ID", newName: "EmployeeID");
            RenameIndex(table: "dbo.CourseCommits", name: "IX_Employee_ID", newName: "IX_EmployeeID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CourseCommits", name: "IX_EmployeeID", newName: "IX_Employee_ID");
            RenameColumn(table: "dbo.CourseCommits", name: "EmployeeID", newName: "Employee_ID");
        }
    }
}
