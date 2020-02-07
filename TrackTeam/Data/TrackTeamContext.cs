using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrackTeam.Models;

namespace TrackTeam.Data
{   
    public class TrackTeamContext: DbContext
    {
        public TrackTeamContext(): base("name=TrackTeamContext")
        {
        }

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Discipline>  Disciplines { get; set; }
        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<TrackTeam.Models.TrackTeam> TrackTeams { get; set; }

    }
}