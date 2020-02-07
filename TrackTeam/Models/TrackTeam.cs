using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrackTeam.Models
{
    public class TrackTeam
    {
        //There can be mulitple track teame, ie/ UTTC,Speed Academy, Flying Angels
        // Each track team is unique.  
        // Each track team will be made up of MANY athletes and coaches.
        // Each coach and athlete can only belong to ONE track team.
        [Key]
        public int TrackTeamID { get; set; }

        public string Name { get; set; }

        //the MANY to ONE relationships
        public ICollection<Athlete> Athletes { get; set; }

        public ICollection<Coach> Coaches { get; set; }


    }
}