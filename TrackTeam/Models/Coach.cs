using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackTeam.Models
{
    public class Coach
    {/*
        A coach is someone who can coach multiple disciplines, as well as multiple athletes.
        Each coach can only be part of one team.
        Things that describe a coach:
        - Name
        - Discipline(s)
        - Athlete(s)
        
         */

        [Key]
        public int CoachID { get; set; }
        public string CoachName { get; set; }

        // One TrackTeam to Many Coaches
      //  public int TrackTeamID { get; set; }
       /// [ForeignKey("TrackTeamID")]
        public virtual TrackTeam Team { get; set; }

        //Representing the Many in One coach to Many Disciplines 
        public ICollection<Discipline> Disciplines { get; set; }


        //Representing the Many in Many Coaches to Many Athletes
        public ICollection<Athlete> Athletes { get; set; }

    }
}