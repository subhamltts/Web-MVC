using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectXWebApp.Models
{
    public class GradesModel
    {
        public int ParticipantID { get; set; }
        public int Marks_Obtained { get; set; }
        public string CourseID { get; set; }
        public string Feedback { get; set; }
        public string BatchID { get; set; }      
    }
}