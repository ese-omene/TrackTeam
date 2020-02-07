namespace TrackTeam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeCategories",
                c => new
                    {
                        AgeCategoryID = c.Int(nullable: false, identity: true),
                        AgeCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.AgeCategoryID);
            
            CreateTable(
                "dbo.Athletes",
                c => new
                    {
                        AthleteID = c.Int(nullable: false, identity: true),
                        AthleteName = c.String(),
                        AthleteAge = c.Int(nullable: false),
                        AthleteGender = c.String(),
                        TrackTeam_TrackTeamID = c.Int(),
                        AgeCategory_AgeCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.AthleteID)
                .ForeignKey("dbo.TrackTeams", t => t.TrackTeam_TrackTeamID)
                .ForeignKey("dbo.AgeCategories", t => t.AgeCategory_AgeCategoryID)
                .Index(t => t.TrackTeam_TrackTeamID)
                .Index(t => t.AgeCategory_AgeCategoryID);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        CoachID = c.Int(nullable: false, identity: true),
                        CoachName = c.String(),
                        TrackTeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoachID)
                .ForeignKey("dbo.TrackTeams", t => t.TrackTeamID, cascadeDelete: true)
                .Index(t => t.TrackTeamID);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        DisciplineID = c.Int(nullable: false, identity: true),
                        DisciplineName = c.String(),
                    })
                .PrimaryKey(t => t.DisciplineID);
            
            CreateTable(
                "dbo.TrackTeams",
                c => new
                    {
                        TrackTeamID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TrackTeamID);
            
            CreateTable(
                "dbo.CoachAthletes",
                c => new
                    {
                        Coach_CoachID = c.Int(nullable: false),
                        Athlete_AthleteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Coach_CoachID, t.Athlete_AthleteID })
                .ForeignKey("dbo.Coaches", t => t.Coach_CoachID, cascadeDelete: true)
                .ForeignKey("dbo.Athletes", t => t.Athlete_AthleteID, cascadeDelete: true)
                .Index(t => t.Coach_CoachID)
                .Index(t => t.Athlete_AthleteID);
            
            CreateTable(
                "dbo.DisciplineAthletes",
                c => new
                    {
                        Discipline_DisciplineID = c.Int(nullable: false),
                        Athlete_AthleteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discipline_DisciplineID, t.Athlete_AthleteID })
                .ForeignKey("dbo.Disciplines", t => t.Discipline_DisciplineID, cascadeDelete: true)
                .ForeignKey("dbo.Athletes", t => t.Athlete_AthleteID, cascadeDelete: true)
                .Index(t => t.Discipline_DisciplineID)
                .Index(t => t.Athlete_AthleteID);
            
            CreateTable(
                "dbo.DisciplineCoaches",
                c => new
                    {
                        Discipline_DisciplineID = c.Int(nullable: false),
                        Coach_CoachID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discipline_DisciplineID, t.Coach_CoachID })
                .ForeignKey("dbo.Disciplines", t => t.Discipline_DisciplineID, cascadeDelete: true)
                .ForeignKey("dbo.Coaches", t => t.Coach_CoachID, cascadeDelete: true)
                .Index(t => t.Discipline_DisciplineID)
                .Index(t => t.Coach_CoachID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "AgeCategory_AgeCategoryID", "dbo.AgeCategories");
            DropForeignKey("dbo.Coaches", "TrackTeamID", "dbo.TrackTeams");
            DropForeignKey("dbo.Athletes", "TrackTeam_TrackTeamID", "dbo.TrackTeams");
            DropForeignKey("dbo.DisciplineCoaches", "Coach_CoachID", "dbo.Coaches");
            DropForeignKey("dbo.DisciplineCoaches", "Discipline_DisciplineID", "dbo.Disciplines");
            DropForeignKey("dbo.DisciplineAthletes", "Athlete_AthleteID", "dbo.Athletes");
            DropForeignKey("dbo.DisciplineAthletes", "Discipline_DisciplineID", "dbo.Disciplines");
            DropForeignKey("dbo.CoachAthletes", "Athlete_AthleteID", "dbo.Athletes");
            DropForeignKey("dbo.CoachAthletes", "Coach_CoachID", "dbo.Coaches");
            DropIndex("dbo.DisciplineCoaches", new[] { "Coach_CoachID" });
            DropIndex("dbo.DisciplineCoaches", new[] { "Discipline_DisciplineID" });
            DropIndex("dbo.DisciplineAthletes", new[] { "Athlete_AthleteID" });
            DropIndex("dbo.DisciplineAthletes", new[] { "Discipline_DisciplineID" });
            DropIndex("dbo.CoachAthletes", new[] { "Athlete_AthleteID" });
            DropIndex("dbo.CoachAthletes", new[] { "Coach_CoachID" });
            DropIndex("dbo.Coaches", new[] { "TrackTeamID" });
            DropIndex("dbo.Athletes", new[] { "AgeCategory_AgeCategoryID" });
            DropIndex("dbo.Athletes", new[] { "TrackTeam_TrackTeamID" });
            DropTable("dbo.DisciplineCoaches");
            DropTable("dbo.DisciplineAthletes");
            DropTable("dbo.CoachAthletes");
            DropTable("dbo.TrackTeams");
            DropTable("dbo.Disciplines");
            DropTable("dbo.Coaches");
            DropTable("dbo.Athletes");
            DropTable("dbo.AgeCategories");
        }
    }
}
