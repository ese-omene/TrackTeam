using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackTeam.Models
{
    public class Athlete
    {

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