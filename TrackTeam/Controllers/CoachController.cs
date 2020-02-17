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
    public class CoachController : Controller
    {
        private TrackTeamContext db = new TrackTeamContext();
        // GET: Coach
        public ActionResult Index()
        {
            List<Coach> coaches = db.Coaches.SqlQuery("select * from coaches").ToList();
            Debug.WriteLine("Let's make check for this working coach function");

            return View(coaches);
        }

        // GET: Coach/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = db.Coaches.SqlQuery("select * from coaches where coachID = @CoachID", new SqlParameter("@CoachID", id)).FirstOrDefault();
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // GET: Coach/Create
        public ActionResult New()
        {
            List<Coach> coaches = db.Coaches.SqlQuery("select * from coaches").ToList();
            return View(coaches);
        }

        // POST: Coach/Create
        [HttpPost]
        public ActionResult Add(string CoachName, int TrackTeamID)
        {
            string query = "insert into coaches(CoachName, TrackTeamID) values(@CoachName, @TrackTeamID)";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@CoachName", CoachName);
            parameter[1] = new SqlParameter("@TrackTeamID", TrackTeamID);

            db.Database.ExecuteSqlCommand(query, parameter);

            return RedirectToAction("Index");

        }

        // GET: Coach/Update/5
        public ActionResult Update(int id)
        {
            Coach selectedCoach = db.Coaches.SqlQuery("select * from coaches where coachid = @id", new SqlParameter("@id", id)).FirstOrDefault();

            UpdateCoach UpdateCoachViewModel = new UpdateCoach();
            UpdateCoachViewModel.Coach = selectedCoach;
            return View(UpdateCoachViewModel);
        }

        // POST: Coach/Update/5
        [HttpPost]
        public ActionResult Update(int id, string CoachName)
        {
            string query = "update coaches set CoachName=@CoachName where CoachID=@id";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@CoachName", CoachName);

            db.Database.ExecuteSqlCommand(query, parameter);

            return RedirectToAction("Index");
        }

        // GET: Coach/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string query = "select * from coaches where coachid = @id";
            SqlParameter param = new SqlParameter("@id", id);
            Coach selectedCoach = db.Coaches.SqlQuery(query, param).FirstOrDefault();

            return View(selectedCoach);
        }

        // POST: Coach/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string query = "delete from coaches where coachid = @id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            return RedirectToAction("Index");
        }
    }
}
