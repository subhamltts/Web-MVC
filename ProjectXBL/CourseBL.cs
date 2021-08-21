using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDTO;
using ProjectXDAL;


namespace ProjectXBL
{
    public class CourseBL
    {
        CourseDAL obj;
        public CourseBL()
        {
            obj = new CourseDAL();
        }
        public List<CoursesDTO> FetchCourses()
        {
            var CourseList = obj.GetCourses();
            return CourseList;
        }

        public List<CourseFacultyDTO> FetchCoursesByFaculty()
        {
            var CourseList = obj.GetCoursesByFaculty();
            return CourseList;
        }

        public int AddCourseDetails(CoursesDTO course)
        {
            try
            {
                int result = obj.InsertCourse(course);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
