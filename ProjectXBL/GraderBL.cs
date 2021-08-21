using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDAL;
using ProjectXDTO;

namespace ProjectXBL
{
    public class GraderBL
    {
        GraderDAL obj;
        public GraderBL()
        {
            obj = new GraderDAL();
        }

        public List<GraderDTO> FetchAllGrades()
        {
            var gradersList = obj.GetGrades();
            return gradersList;
        }

        public List<GraderDTO> FetchGradesByCourse(string courseId)
        {
            var gradersList = obj.GetGradesByCourseID(courseId);
            return gradersList;
        }

        public int AddGrades(GraderDTO graderDTO)
        {
            try
            {
                int result = obj.InsertGrades(graderDTO);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
