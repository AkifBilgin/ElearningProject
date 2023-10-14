namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDescriptionToInstructor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "Description");
        }
    }
}
