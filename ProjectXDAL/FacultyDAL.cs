using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDTO;

namespace ProjectXDAL
{
    public class FacultyDAL
    {
        SqlConnection sqlConn;
        SqlCommand sqlCmd;
        public FacultyDAL()
        {
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["projectXConnStr"].ToString());
        }

       public List<FacultyDTO> GetFaculty()
        {
            try
            {
                List<FacultyDTO> facultyList = new List<FacultyDTO>();
                ProjectXDBStr projectXDBStr = new ProjectXDBStr();
                var lsFaclties = projectXDBStr.Faculties.ToList();
                foreach (var item in lsFaclties)
                {
                    facultyList.Add(
                        new FacultyDTO
                        {
                            FacultyName = item.FacultyName,
                            EmailID = item.EmailID,
                            PSNo = item.PSNo
                        });
                }
                return facultyList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // Performing isertion in DB using ADO.NET
        public int InsertFaculty(FacultyDTO facultyDTO)
        {
            sqlCmd = new SqlCommand("[dbo].[uspInsertFacultyDetails]", sqlConn);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Name", facultyDTO.FacultyName);
            sqlCmd.Parameters.AddWithValue("@Email", facultyDTO.EmailID);
            sqlCmd.Parameters.AddWithValue("@PSNo", facultyDTO.PSNo);

            try
            {
                sqlConn.Open();
                SqlParameter reValue = new SqlParameter("returnVal", System.Data.SqlDbType.Int);
                reValue.Direction = System.Data.ParameterDirection.ReturnValue;
                sqlCmd.Parameters.Add(reValue);
                int rowsAffected = sqlCmd.ExecuteNonQuery();
                sqlCmd.Parameters.Add(reValue);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        /*public int updateFaculty(FacultyDTO facultyDTO)
        {
            int ret = 0;
            try
            {
                using(var context = new ProjectXDBStr())
                {
                    Faculty facultyDAL = context.Faculties.Find(facultyDTO.PSNo);

                    context.Faculties.Attach(facultyDAL);
                    facultyDAL.FacultyName = facultyDTO.FacultyName;
                    ret = context.SaveChanges();
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteFaculty(FacultyDTO facultyDTO)
        {
            int ret = 0;
            try
            {
                using (var context = new ProjectXDBStr())
                {
                    Faculty facultyDAL = context.Faculties.Find(facultyDTO.PSNo);
                    facultyDAL.PSNo = facultyDTO.PSNo;
                    context.Faculties.Remove(facultyDAL);
                    ret = context.SaveChanges();
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}
