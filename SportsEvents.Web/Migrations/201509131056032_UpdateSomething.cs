namespace SportsEvents.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSomething : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Organizers_Id", newName: "Organizer_Id");
            RenameIndex(table: "dbo.Events", name: "IX_Organizers_Id", newName: "IX_Organizer_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_Organizer_Id", newName: "IX_Organizers_Id");
            RenameColumn(table: "dbo.Events", name: "Organizer_Id", newName: "Organizers_Id");
        }
    }
}
