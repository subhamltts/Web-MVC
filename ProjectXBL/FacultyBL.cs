using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDAL;
using ProjectXDTO;

namespace ProjectXBL
{
    public class FacultyBL
    {
        FacultyDAL obj;
        public FacultyBL()
        {
            obj = new FacultyDAL();
        }

        public List<FacultyDTO> GetFaculties()
        {
            try
            {
                var facultyList = obj.GetFaculty();
                return facultyList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddFacultyDetails(FacultyDTO facDTO)
        {
            try
            {
                int result = obj.InsertFaculty(facDTO);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public int updateFaculty(FacultyDTO facultyDTO)
        {
            int ret = obj.updateFaculty(facultyDTO);
            return ret;
        }

        /*public int deleteFaculty(FacultyDTO facultyDTO)
        {
            int ret = obj.deleteFaculty(facultyDTO);
            return ret;
        }*/
    }
}
