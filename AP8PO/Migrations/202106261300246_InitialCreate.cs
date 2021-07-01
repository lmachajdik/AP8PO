﻿namespace AP8PO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseCommits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbrevation = c.String(),
                        Hours = c.Int(nullable: false),
                        NumberOfStudents = c.Int(nullable: false),
                        CourseType = c.Int(nullable: false),
                        Language = c.Int(nullable: false),
                        Autogenerated = c.Boolean(nullable: false),
                        Course_ID = c.Int(),
                        Employee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID)
                .Index(t => t.Course_ID)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(),
                        Name = c.String(),
                        Abbrevation = c.String(),
                        MaxStudentsPerClass = c.Int(nullable: false),
                        NumberOfWeeks = c.Int(nullable: false),
                        HoursOfLectures = c.Int(nullable: false),
                        HoursOfPractises = c.Int(nullable: false),
                        HoursOfSeminars = c.Int(nullable: false),
                        CompletionType = c.Int(nullable: false),
                        Language = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.GroupID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbrevation = c.String(),
                        Semester = c.Int(nullable: false),
                        StudyForm = c.Int(nullable: false),
                        StudyType = c.Int(nullable: false),
                        StudentsCount = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Surname = c.String(),
                        Telephone = c.String(),
                        WorkEmail = c.String(),
                        PrivateEmail = c.String(),
                        Doctorand = c.Boolean(nullable: false),
                        LoadPercent = c.Int(nullable: false),
                        CurrentLoad = c.Int(nullable: false),
                        LoadType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseCommits", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.CourseCommits", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "GroupID", "dbo.Groups");
            DropIndex("dbo.Courses", new[] { "GroupID" });
            DropIndex("dbo.CourseCommits", new[] { "Employee_ID" });
            DropIndex("dbo.CourseCommits", new[] { "Course_ID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Groups");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseCommits");
        }
    }
}