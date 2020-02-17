namespace TrackTeam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TrackTeams", newName: "Teams");
            DropForeignKey("dbo.Athletes", "TrackTeam_TrackTeamID", "dbo.TrackTeams");
            DropIndex("dbo.Athletes", new[] { "TrackTeam_TrackTeamID" });
            RenameColumn(table: "dbo.Athletes", name: "TrackTeam_TrackTeamID", newName: "TrackTeamID");
            AlterColumn("dbo.Athletes", "TrackTeamID", c => c.Int(nullable: false));
            CreateIndex("dbo.Athletes", "TrackTeamID");
            AddForeignKey("dbo.Athletes", "TrackTeamID", "dbo.Teams", "TrackTeamID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "TrackTeamID", "dbo.Teams");
            DropIndex("dbo.Athletes", new[] { "TrackTeamID" });
            AlterColumn("dbo.Athletes", "TrackTeamID", c => c.Int());
            RenameColumn(table: "dbo.Athletes", name: "TrackTeamID", newName: "TrackTeam_TrackTeamID");
            CreateIndex("dbo.Athletes", "TrackTeam_TrackTeamID");
            AddForeignKey("dbo.Athletes", "TrackTeam_TrackTeamID", "dbo.TrackTeams", "TrackTeamID");
            RenameTable(name: "dbo.Teams", newName: "TrackTeams");
        }
    }
}
