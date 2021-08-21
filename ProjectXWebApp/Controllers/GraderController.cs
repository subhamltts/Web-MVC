using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectXBL;
using ProjectXDTO;
using ProjectXWebApp.Models;

namespace ProjectXWebApp.Controllers
{
    public class GraderController : Controller
    {
        GraderBL graderBL;
        // GET: Grader
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetGrades()
        {
            try
            {
                graderBL = new GraderBL();
                var resultDTO = graderBL.FetchAllGrades();
                List<Models.GradesModel> lstGrades = new List<Models.GradesModel>();
                foreach (var item in resultDTO)
                {
                    lstGrades.Add(new Models.GradesModel()
                    {
                          ParticipantID = item.ParticipantID,
                          CourseID = item.CourseID,
                          Marks_Obtained = item.Marks_Obtained
                    });
                }
                return View(lstGrades);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult AddNewGrades()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewGrades(GradesModel obj)
        {
            GraderBL blObj = new GraderBL();
            GraderDTO newGradesObj = new GraderDTO()
            {
                ParticipantID = obj.ParticipantID,
                Marks_Obtained = obj.Marks_Obtained,
                BatchID = obj.BatchID,
                Feedback = obj.Feedback
            };
            int result = blObj.AddGrades(newGradesObj);

            if (result == 1)
            {
                return RedirectToAction("GetGrades");
            }
            else
            {
                return View("Error");
            }
        }
    }
}