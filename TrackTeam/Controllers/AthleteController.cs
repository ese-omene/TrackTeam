using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackTeam.Data;
using TrackTeam.Models;
using TrackTeam.Models.ViewModels;
using System.Diagnostics;
using System.IO;

namespace TrackTeam.Controllers
{
    public class AthleteController : Controller
    {
        private TrackTeamContext db = new TrackTeamContext();
        // GET: Athlete
        public ActionResult Index(string athletesearch)
        {

            Debug.WriteLine("if i didn this right then we are searching for" + athletesearch);

            string query = "Select * from Athletes";
            if (athletesearch!="")
            {
                query = query + " where athletename like '%" + athletesearch + "%'";
                Debug.WriteLine("this is what we are using to search:" + query);
            }
            List<Athlete> athletes = db.Athletes.SqlQuery(query).ToList();
            Debug.WriteLine("let's make sure the list function works");
            return View(athletes);
        }

        // GET: Athlete/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete athlete = db.Athletes.SqlQuery("select * from athletes where athleteid = @AthleteID", new SqlParameter("@AthleteID", id)).FirstOrDefault();
            if (athlete == null)
            {
                return HttpNotFound();
            }

            // lvlup - create queries for  information about the coaches and events the athletes is involved with
           string query = "select * from coaches inner join coachathletes on coaches.coachid = coachathletes.coach_coachid where athlete_athleteid = @id";
            SqlParameter param = new SqlParameter("@id", id);
            List<Coach> CoachAthletes = db.Coaches.SqlQuery(query, param).ToList();

            string disQuery = "select * from disciplines inner join disciplineathletes on disciplines.disciplineid = disciplineathletes.discipline_disciplineid where athlete_athleteid = @id";
            SqlParameter sqlParam = new SqlParameter("@id", id);
            List<Discipline> DisciplineAthletes = db.Disciplines.SqlQuery(disQuery, sqlParam).ToList();

            AthleteDetails viewmodel = new AthleteDetails();
            viewmodel.athlete = athlete;
            viewmodel.coaches = CoachAthletes;
            viewmodel.disciplines = DisciplineAthletes;


            return View(viewmodel);
        }




        // POST: Athlete/Create
        [HttpPost]
        public ActionResult Add(int TrackTeamID, string AthleteName, int AthleteAge, string AthleteGender)
        {


            // TODO: Add insert logic here
            string query = "insert into athletes (AthleteName, AthleteAge, AthleteGender, TrackTeamID) values (@AthleteName, @AthleteAge, @AthleteGender, @TrackTeamID) ";
            SqlParameter[] sqlparams = new SqlParameter[4];
            sqlparams[0] = new SqlParameter("@AthleteName", AthleteName);
            sqlparams[1] = new SqlParameter("@AthleteAge", AthleteAge);
            sqlparams[2] = new SqlParameter("@AthleteGender", AthleteGender);
            sqlparams[3] = new SqlParameter("@TrackTeamID", TrackTeamID);


            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("Index");

        }
        // GET: Athlete/New
        public ActionResult New()
        {
            List<Athlete> athletes = db.Athletes.SqlQuery("select * from athletes").ToList();
            return View(athletes);
        }

        // GET: Athlete/Update/5
        public ActionResult Update(int id)
        {
            Athlete selectedAthlete = db.Athletes.SqlQuery("select * from athletes where athleteid = @id", new SqlParameter("@id", id)).FirstOrDefault();
           // List<Coach> coaches = db.Coaches.SqlQuery("select * from coaches").ToList();
            //List<TrackTeam> teams = db.teams.SqlQuery("select * from trackteams").ToList();

            UpdateAthlete UpdateAthleteViewModel = new UpdateAthlete();
            UpdateAthleteViewModel.Athlete = selectedAthlete;
           // UpdateAthleteViewModel.Coach = coaches;
            return View(UpdateAthleteViewModel);
        }

        // POST: Athlete/Update/5
        [HttpPost]
        public ActionResult Update(int id, string AthleteName, int AthleteAge, string AthleteGender)
        {
            string query = "update athletes set AthleteName=@AthleteName, AthleteAge=@AthleteAge, AthleteGender=@AthleteGender where AthleteID=@id";
            SqlParameter[] sqlparams = new SqlParameter[4];
           // sqlparams[0]= new SqlParameter("@TrackTeamID",TrackTeamID);
            sqlparams[0]= new SqlParameter("@AthleteName",AthleteName);
            sqlparams[1]= new SqlParameter("@AthleteAge",AthleteAge);
            sqlparams[2]= new SqlParameter("@AthleteGender",AthleteGender);
            sqlparams[3]= new SqlParameter("@id",id);

            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("Index");

        }

        // GET: Athlete/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string query = "select * from athletes where athleteid = @id";
            SqlParameter param = new SqlParameter("@id", id);
            Athlete selectedAthlete = db.Athletes.SqlQuery(query, param).FirstOrDefault();
            return View(selectedAthlete);
        }

        // POST: Athlete/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string query = "delete from athletes where athleteid = @id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            return RedirectToAction("Index");
        }
    }
}
