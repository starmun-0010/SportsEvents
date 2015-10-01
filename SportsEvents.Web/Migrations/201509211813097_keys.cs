namespace SportsEvents.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "Sport_Id", "dbo.Sports");
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropIndex("dbo.Events", new[] { "Sport_Id" });
            RenameColumn(table: "dbo.Messages", name: "Receiver_Id", newName: "ReceiverId");
            RenameColumn(table: "dbo.Messages", name: "Sender_Id", newName: "SenderId");
            RenameColumn(table: "dbo.Events", name: "Organizer_Id", newName: "OrganizerId");
            RenameColumn(table: "dbo.Events", name: "EventType_Id", newName: "EventTypeId");
            RenameColumn(table: "dbo.Events", name: "Sport_Id", newName: "SportId");
            RenameIndex(table: "dbo.Messages", name: "IX_Sender_Id", newName: "IX_SenderId");
            RenameIndex(table: "dbo.Messages", name: "IX_Receiver_Id", newName: "IX_ReceiverId");
            RenameIndex(table: "dbo.Events", name: "IX_Organizer_Id", newName: "IX_OrganizerId");
            AddColumn("dbo.Events", "SportName", c => c.String());
            AddColumn("dbo.Events", "EventTypeName", c => c.String());
            AddColumn("dbo.Events", "OrganizerName", c => c.String());
            AlterColumn("dbo.Events", "EventTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "SportId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "SportId");
            CreateIndex("dbo.Events", "EventTypeId");
            AddForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "SportId", "dbo.Sports", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "SportId", "dbo.Sports");
            DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "EventTypeId" });
            DropIndex("dbo.Events", new[] { "SportId" });
            AlterColumn("dbo.Events", "SportId", c => c.Int());
            AlterColumn("dbo.Events", "EventTypeId", c => c.Int());
            DropColumn("dbo.Events", "OrganizerName");
            DropColumn("dbo.Events", "EventTypeName");
            DropColumn("dbo.Events", "SportName");
            RenameIndex(table: "dbo.Events", name: "IX_OrganizerId", newName: "IX_Organizer_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_ReceiverId", newName: "IX_Receiver_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_SenderId", newName: "IX_Sender_Id");
            RenameColumn(table: "dbo.Events", name: "SportId", newName: "Sport_Id");
            RenameColumn(table: "dbo.Events", name: "EventTypeId", newName: "EventType_Id");
            RenameColumn(table: "dbo.Events", name: "OrganizerId", newName: "Organizer_Id");
            RenameColumn(table: "dbo.Messages", name: "SenderId", newName: "Sender_Id");
            RenameColumn(table: "dbo.Messages", name: "ReceiverId", newName: "Receiver_Id");
            CreateIndex("dbo.Events", "Sport_Id");
            CreateIndex("dbo.Events", "EventType_Id");
            AddForeignKey("dbo.Events", "Sport_Id", "dbo.Sports", "Id");
            AddForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes", "Id");
        }
    }
}
