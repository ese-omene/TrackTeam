using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackTeam.Models.ViewModels
{
    public class UpdateCoach
    {
        public Coach Coach { get; set; }
        public List <TrackTeam> Teams { get; set; }
    }
}