namespace SportsEvents.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableRename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventVisitors", newName: "BookmarkerEventVisitors");
            RenameTable(name: "dbo.EventVisitor1", newName: "RegisterdEventVisitors");
            RenameTable(name: "dbo.EventVisitor2", newName: "RegisterRequestEventVisitors");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RegisterRequestEventVisitors", newName: "EventVisitor2");
            RenameTable(name: "dbo.RegisterdEventVisitors", newName: "EventVisitor1");
            RenameTable(name: "dbo.BookmarkerEventVisitors", newName: "EventVisitors");
        }
    }
}
