namespace SportsEvents.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address_LineOne = c.String(),
                        Address_LineTwo = c.String(),
                        Address_CityName = c.String(),
                        Address_CountryName = c.String(),
                        Address_CityId = c.Int(nullable: false),
                        Address_Zip = c.String(),
                        Address_State = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsFeatured = c.Boolean(nullable: false),
                        StartingPrice = c.Double(),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Address_LineOne = c.String(),
                        Address_LineTwo = c.String(),
                        Address_CityName = c.String(),
                        Address_CountryName = c.String(),
                        Address_CityId = c.Int(nullable: false),
                        Address_Zip = c.String(),
                        Address_State = c.String(),
                        Description = c.String(),
                        Details = c.String(),
                        Icon = c.Binary(),
                        VideoLink = c.String(),
                        ExternalLink = c.String(),
                        Coordinates = c.Geography(),
                        BeginTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        CityId = c.Int(nullable: false),
                        AddressString = c.String(),
                        SportId = c.Int(nullable: false),
                        SportName = c.String(),
                        EventTypeId = c.Int(nullable: false),
                        EventTypeName = c.String(),
                        OrganizerId = c.String(maxLength: 128),
                        OrganizerName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OrganizerId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.SportId)
                .Index(t => t.EventTypeId)
                .Index(t => t.OrganizerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Link = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address_LineOne = c.String(),
                        Address_LineTwo = c.String(),
                        Address_CityName = c.String(),
                        Address_CountryName = c.String(),
                        Address_CityId = c.Int(nullable: false),
                        Address_Zip = c.String(),
                        Address_State = c.String(),
                        OrganiztionName = c.String(),
                        OrganizationDecription = c.String(),
                        OrganaiztionLogo = c.Binary(),
                        ContactDetailsId = c.String(maxLength: 128),
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
                .ForeignKey("dbo.ContactDetails", t => t.ContactDetailsId)
                .Index(t => t.ContactDetailsId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.String(maxLength: 128),
                        ReceiverId = c.String(maxLength: 128),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryName = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Sports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.BookmarkerEventVisitors",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ClickerEventUsers",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.RegisterdEventVisitors",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.RegisterRequestEventVisitors",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Events", "SportId", "dbo.Sports");
            DropForeignKey("dbo.RegisterRequestEventVisitors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RegisterRequestEventVisitors", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.RegisterdEventVisitors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RegisterdEventVisitors", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Pictures", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            DropForeignKey("dbo.ClickerEventUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClickerEventUsers", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.BookmarkerEventVisitors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookmarkerEventVisitors", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "OrganizerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ContactDetailsId", "dbo.ContactDetails");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.RegisterRequestEventVisitors", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.RegisterRequestEventVisitors", new[] { "Event_Id" });
            DropIndex("dbo.RegisterdEventVisitors", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.RegisterdEventVisitors", new[] { "Event_Id" });
            DropIndex("dbo.ClickerEventUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ClickerEventUsers", new[] { "Event_Id" });
            DropIndex("dbo.BookmarkerEventVisitors", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BookmarkerEventVisitors", new[] { "Event_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pictures", new[] { "Event_Id" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Messages", new[] { "ReceiverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "ContactDetailsId" });
            DropIndex("dbo.Events", new[] { "OrganizerId" });
            DropIndex("dbo.Events", new[] { "EventTypeId" });
            DropIndex("dbo.Events", new[] { "SportId" });
            DropIndex("dbo.Events", new[] { "CityId" });
            DropTable("dbo.RegisterRequestEventVisitors");
            DropTable("dbo.RegisterdEventVisitors");
            DropTable("dbo.ClickerEventUsers");
            DropTable("dbo.BookmarkerEventVisitors");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Sports");
            DropTable("dbo.Pictures");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Cities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Events");
            DropTable("dbo.Countries");
            DropTable("dbo.ContactDetails");
            DropTable("dbo.Advertisements");
        }
    }
}
