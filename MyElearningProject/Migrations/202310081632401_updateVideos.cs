namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateVideos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CourseVideos", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseVideos", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
