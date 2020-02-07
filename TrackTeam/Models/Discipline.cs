using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace TrackTeam.Models
{
    public class Discipline
    {

        /*
         Discipline refers to the area of expertise, or competition and athlete
         participates in or a coach coaches.  
         An athlete can compete in multiple disciplines 
         Each  coach can coach multiple disciplines
         
         */


        public int DisciplineID { get; set; }
        public string DisciplineName { get; set; }


        //Representing the Many in One Coach to Many Disciplines
        public ICollection<Coach> Coaches { get; set; }


        //Representing the Many in One Athlete to Many Disciplines
        public ICollection<Athlete> Athletes { get; set; }




    }
}