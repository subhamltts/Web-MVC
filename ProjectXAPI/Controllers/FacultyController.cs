using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ProjectXBL;
using ProjectXDTO;

namespace ProjectXAPI.Controllers
{
    public class FacultyController : ApiController
    {
        FacultyBL bllObj;         //Reference creation
        
        [HttpGet]                   //Attribute
        [ActionName("AllFaculty")]  //Change the Name of the Action
        public HttpResponseMessage FetchAllFaculty()
        {
            try
            {
                bllObj = new FacultyBL(); //Object creation
                List<FacultyDTO> list = bllObj.GetFaculties();
                if(list != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(list));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("There is no faculty available at this moment");
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
        [ActionName("AddFaculty")]
        public HttpResponseMessage AddNewFaculty(FacultyDTO facObj)
        {
            try
            {
                if (facObj != null && facObj.FacultyName != null && facObj.EmailID != null && facObj.PSNo!=0)
                {
                    bllObj = new FacultyBL();
                    int retVal = bllObj.AddFacultyDetails(facObj);
                    if (retVal == 1)
                    {
                        var successResp = new HttpResponseMessage(HttpStatusCode.OK);
                        successResp.Content = new StringContent("Faculty Added Successfully!");
                        return successResp;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Faculty not added!");
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
