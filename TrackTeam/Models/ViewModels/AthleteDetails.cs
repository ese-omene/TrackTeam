using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackTeam.Models.ViewModels
{
    public class AthleteDetails
    {
        public virtual Athlete athlete { get; set; }

        public List<Coach> coaches { get; set; }

        public List<Discipline> disciplines { get; set; }
    }
}