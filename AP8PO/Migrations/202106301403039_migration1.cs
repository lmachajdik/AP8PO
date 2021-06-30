namespace AP8PO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CourseCommits", name: "Course_ID", newName: "CourseID");
            RenameIndex(table: "dbo.CourseCommits", name: "IX_Course_ID", newName: "IX_CourseID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CourseCommits", name: "IX_CourseID", newName: "IX_Course_ID");
            RenameColumn(table: "dbo.CourseCommits", name: "CourseID", newName: "Course_ID");
        }
    }
}
