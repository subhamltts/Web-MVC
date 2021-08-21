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
    public class CourseController : Controller
    {
        CourseBL courseBL;
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCourses()
        {
            try
            {
                courseBL = new CourseBL();
                var resultDTO = courseBL.FetchCoursesByFaculty();
                List<Models.CourseModel> lstCourses = new List<Models.CourseModel>();
                foreach (var item in resultDTO)
                {
                    lstCourses.Add(new Models.CourseModel()
                    {
                        CourseTitle = item.CourseTitle
                    });
                }
                return View(lstCourses);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult AddNewCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewCourse(CourseModel obj)
        {
            CourseBL blObj = new CourseBL();
            CoursesDTO newCoursObj = new CoursesDTO()
            {
                CourseID = obj.CourseID,
                CourseTitle = obj.CourseTitle,
                Duration = obj.Duration,
                Owner = obj.Owner,
                AssessmentMode = obj.AssessmentMode
            };
            int result = blObj.AddCourseDetails(newCoursObj);

            if (result == 1)
            {
                return RedirectToAction("GetCourses");
            }
            else
            {
                return View("Error");
            }
        }
    }
}