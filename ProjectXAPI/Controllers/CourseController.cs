using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectXDTO;
using ProjectXBL;
using Newtonsoft.Json;

namespace ProjectXAPI.Controllers
{
    public class CourseController : ApiController
    {
        CourseBL bllObj;
        public CourseController()
        {
            bllObj = new CourseBL();
        }

        [HttpGet]
        [ActionName("AllCourses")]
        public HttpResponseMessage GetAllCourses()
        {
            try
            {
                List<CoursesDTO> CourseLst = bllObj.FetchCourses();
                if (CourseLst != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(CourseLst));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("There is no data available at this moment");
                    return response;
                }

            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Somthing went wrong:(");
                return response;
            }
        }

        [HttpGet]
        [ActionName ("CoursesByFaculty")]
        public HttpResponseMessage GetCoursesByFaculty()
        {
            try
            {
                List<CourseFacultyDTO> lstCourses = bllObj.FetchCoursesByFaculty();
                if (lstCourses != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(lstCourses));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("No Data Found");
                    return response;
                }
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Somthing went wrong:(");
                return response;
            }
        }

        [HttpPost]
        [ActionName("AddCourse")]
        public HttpResponseMessage AddNewCourse(CoursesDTO coursObj)
        {
            try
            {
                if (coursObj != null && coursObj.CourseTitle != null && coursObj.Duration != 0)
                {
                    int retVal = bllObj.AddCourseDetails(coursObj);
                    if (retVal == 1)
                    {
                        var successResp = new HttpResponseMessage(HttpStatusCode.OK);
                        successResp.Content = new StringContent("Course Added Successfully!");
                        return successResp;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Course not added!");
                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Some details missing!");
                    return response;
                }
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Somthing went wrong:(");
                return response;
            }
        }
    }
}
