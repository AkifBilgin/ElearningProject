namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsReaden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsReaden");
        }
    }
}
