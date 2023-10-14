namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWidget : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Widgets",
                c => new
                    {
                        WidgetID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Ícon = c.String(),
                    })
                .PrimaryKey(t => t.WidgetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Widgets");
        }
    }
}
