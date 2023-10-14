namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCourseVideo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseVideos",
                c => new
                    {
                        CourseVideoID = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        MyProperty = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseVideoID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseVideos", new[] { "CourseID" });
            DropTable("dbo.CourseVideos");
        }
    }
}
