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
    public class GraderController : ApiController
    {
        GraderBL graderObj;         

        [HttpGet]                   
        [ActionName("AllGrades")]  
        public HttpResponseMessage FetchAllGrades()
        {
            try
            {
                graderObj = new GraderBL(); //Object creation
                List<GraderDTO> list = graderObj.FetchAllGrades();
                if (list != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(list));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("There is no Grades Data available at this moment");
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
        [ActionName("GradesByCourse")]
        public HttpResponseMessage FetchAllGradesByCourseID(string courseID)
        {
            try
            {
                graderObj = new GraderBL(); //Object creation
                List<GraderDTO> list = graderObj.FetchGradesByCourse(courseID);
                if (list != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(list));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("There is no Grades Data available at this moment");
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
        [ActionName("AddGrades")]
        public HttpResponseMessage AddNewCourse(GraderDTO graderDTO)
        {
            try
            {
                if (graderDTO != null && graderDTO.ParticipantID != 0 && graderDTO.BatchID != null && graderDTO.CourseID !=null)
                {
                    graderObj = new GraderBL();
                    int retVal = graderObj.AddGrades(graderDTO);
                    if (retVal == 1)
                    {
                        var successResp = new HttpResponseMessage(HttpStatusCode.OK);
                        successResp.Content = new StringContent("Grades Added Successfully!");
                        return successResp;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Grades not added!");
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
