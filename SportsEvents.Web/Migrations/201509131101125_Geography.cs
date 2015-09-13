namespace SportsEvents.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class Geography : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visitors", "Coordinates", c => c.Geography());
            AddColumn("dbo.Events", "Coordinates", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Coordinates");
            DropColumn("dbo.Visitors", "Coordinates");
        }
    }
}
