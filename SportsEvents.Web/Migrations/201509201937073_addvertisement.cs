namespace SportsEvents.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvertisement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Link = c.String(),
                        Priority = c.Int(nullable: false),
                        Keywords = c.String(),
                        Prelogin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Events", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "Event_Id", "dbo.Events");
            DropIndex("dbo.Pictures", new[] { "Event_Id" });
            DropColumn("dbo.Events", "IsFeatured");
            DropTable("dbo.Advertisements");
            DropTable("dbo.Pictures");
        }
    }
}
