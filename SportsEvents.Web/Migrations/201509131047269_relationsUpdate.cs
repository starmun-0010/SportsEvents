namespace SportsEvents.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationsUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Admins");
            DropIndex("dbo.Admins", "UserNameIndex");
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Receiver_Id = c.String(maxLength: 128),
                        Sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Receiver_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.EventVisitors",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        Visitor_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.Visitor_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.Visitors", t => t.Visitor_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.Visitor_Id);
            
            CreateTable(
                "dbo.EventVisitor1",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        Visitor_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.Visitor_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.Visitors", t => t.Visitor_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.Visitor_Id);
            
            CreateTable(
                "dbo.EventVisitor2",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        Visitor_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.Visitor_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.Visitors", t => t.Visitor_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.Visitor_Id);
            
            CreateTable(
                "dbo.Organiers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Events", "Organizers_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "Organizers_Id");
            CreateIndex("dbo.Admins", "Id");
            AddForeignKey("dbo.Events", "Organizers_Id", "dbo.Organiers", "Id");
            AddForeignKey("dbo.Admins", "Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Admins", "Email");
            DropColumn("dbo.Admins", "EmailConfirmed");
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "SecurityStamp");
            DropColumn("dbo.Admins", "PhoneNumber");
            DropColumn("dbo.Admins", "PhoneNumberConfirmed");
            DropColumn("dbo.Admins", "TwoFactorEnabled");
            DropColumn("dbo.Admins", "LockoutEndDateUtc");
            DropColumn("dbo.Admins", "LockoutEnabled");
            DropColumn("dbo.Admins", "AccessFailedCount");
            DropColumn("dbo.Admins", "UserName");
            DropColumn("dbo.Admins", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Admins", "UserName", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.Admins", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Admins", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "PhoneNumber", c => c.String());
            AddColumn("dbo.Admins", "SecurityStamp", c => c.String());
            AddColumn("dbo.Admins", "PasswordHash", c => c.String());
            AddColumn("dbo.Admins", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "Email", c => c.String(maxLength: 256));
            DropForeignKey("dbo.Visitors", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Organiers", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Admins", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "Organizers_Id", "dbo.Organiers");
            DropForeignKey("dbo.EventVisitor2", "Visitor_Id", "dbo.Visitors");
            DropForeignKey("dbo.EventVisitor2", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.EventVisitor1", "Visitor_Id", "dbo.Visitors");
            DropForeignKey("dbo.EventVisitor1", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.EventVisitors", "Visitor_Id", "dbo.Visitors");
            DropForeignKey("dbo.EventVisitors", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Visitors", new[] { "Id" });
            DropIndex("dbo.Organiers", new[] { "Id" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropIndex("dbo.EventVisitor2", new[] { "Visitor_Id" });
            DropIndex("dbo.EventVisitor2", new[] { "Event_Id" });
            DropIndex("dbo.EventVisitor1", new[] { "Visitor_Id" });
            DropIndex("dbo.EventVisitor1", new[] { "Event_Id" });
            DropIndex("dbo.EventVisitors", new[] { "Visitor_Id" });
            DropIndex("dbo.EventVisitors", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "Organizers_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropColumn("dbo.Events", "Organizers_Id");
            DropTable("dbo.Visitors");
            DropTable("dbo.Organiers");
            DropTable("dbo.EventVisitor2");
            DropTable("dbo.EventVisitor1");
            DropTable("dbo.EventVisitors");
            DropTable("dbo.Messages");
            DropTable("dbo.AspNetUsers");
            CreateIndex("dbo.Admins", "UserName", unique: true, name: "UserNameIndex");
            RenameTable(name: "dbo.Admins", newName: "AspNetUsers");
        }
    }
}
