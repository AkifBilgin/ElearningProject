namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWidgetName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Widgets", "Icon", c => c.String());
            DropColumn("dbo.Widgets", "Ícon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Widgets", "Ícon", c => c.String());
            DropColumn("dbo.Widgets", "Icon");
        }
    }
}
