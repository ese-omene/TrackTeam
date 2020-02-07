using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackTeam.Models
{
    public class AgeCategory
    {

        //depending on the age of the athlete, they are placed in an age cateorgy for competition
        // Each athlete can be part of one age category.  Each category can have many athletes
        
        [Key]
        public  int AgeCategoryID { get; set; }
        public string AgeCategoryName { get; set; }

        public ICollection<Athlete> Athletes { get; set; }



    }
}