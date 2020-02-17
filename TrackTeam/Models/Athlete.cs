using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackTeam.Models
{
    public class Athlete
    {
        [Key]
        public int AthleteID { get; set; }
        public string AthleteName { get; set; }
        public int AthleteAge { get; set; }
        public string AthleteGender { get; set; }


        // Representing Many in (Many Disciplines to Many Athletes)
        public ICollection<Discipline> Disciplines { get; set; }

        // Representing Many in (Many Coaches to Many Athletes)
        public ICollection<Coach> Coaches { get; set; }

    }
}