using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDTO;

namespace ProjectXDAL
{
    public class CourseDAL
    {
        ProjectXDBStr projectXDBStr;
        public CourseDAL()
        {
            projectXDBStr = new ProjectXDBStr();
        }
        public List<CoursesDTO> GetCourses()
        {
            try
            {
                List<CoursesDTO> lstCourse = new List<CoursesDTO>();
                var CourseDALListObj = projectXDBStr.Courses.ToList();
                foreach (var item in CourseDALListObj)
                {
                    lstCourse.Add(
                        new CoursesDTO
                        {
                            CourseID = item.CourseID,
                            CourseTitle = item.CourseTitle,
                            Duration = item.Duration,
                            Owner = item.Owner,
                            AssessmentMode = item.AssessmentMode

                        });
                }
                return lstCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseFacultyDTO> GetCoursesByFaculty()
        {
            try
            {
                List<CourseFacultyDTO> lstCourse = new List<CourseFacultyDTO>();
                var CourseList = (from C in projectXDBStr.Courses
                                  join F in projectXDBStr.Faculties
                                 on C.Owner equals F.FacultyName
                                  select new
                                 {
                                     CourseID = C.CourseID,
                                     CourseTitle = C.CourseTitle,
                                     FacultyName = F.FacultyName
                                 }).ToList(); 
                    
                foreach (var item in CourseList)
                {
                    lstCourse.Add(
                        new CourseFacultyDTO
                        {
                            CourseID = item.CourseID,
                            CourseTitle = item.CourseTitle,
                            FacultyName = item.FacultyName
                        });
                }
                return lstCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Insertion operation on Courses table in DB using EF
        public int InsertCourse(CoursesDTO coursDetails)
        {
            int ret = 0;
            try
            {
                using (var context = new ProjectXDBStr())
                {
                    Cours courseDAL = new Cours();
                    courseDAL.CourseID = coursDetails.CourseID;
                    courseDAL.CourseTitle = coursDetails.CourseTitle;
                    courseDAL.Duration = coursDetails.Duration;
                    courseDAL.Owner = coursDetails.Owner;
                    courseDAL.AssessmentMode = coursDetails.AssessmentMode;

                    context.Courses.Add(courseDAL);
                    ret = context.SaveChanges();
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
