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
    public class FacultyController : Controller
    {
        FacultyBL faculty;

        // GET: Faculty
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFaculty()
        {
            try
            {
                faculty = new FacultyBL();
                var resultDTO = faculty.GetFaculties();
                List<Models.FacultyModel> lstFaculty = new List<Models.FacultyModel>();
                foreach (var item in resultDTO)
                {
                    lstFaculty.Add(new Models.FacultyModel()
                    {
                        FacultyName = item.FacultyName,
                        PSNo = item.PSNo
                    });
                }
                return View(lstFaculty);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult AddNewFaculty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewFaculty(FacultyCreateModel obj)
        {
            FacultyBL blObj = new FacultyBL();
            FacultyDTO newFacuObj = new FacultyDTO()
            {
                FacultyName = obj.FacultyName,
                EmailID = obj.EmailID,
                PSNo = obj.PSNo
            };
            int result = blObj.AddFacultyDetails(newFacuObj);

            if (result == 1)
            {
                return RedirectToAction("GetFaculty");
            }
            else
            {
                return View("Error");
            }
        } 
    }
}
