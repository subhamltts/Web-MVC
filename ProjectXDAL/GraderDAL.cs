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
    public class GraderDAL
    {
        SqlConnection sqlConn;
        SqlCommand sqlCmd;

        ProjectXDBStr projectXDBStr;
        public GraderDAL()
        {
            projectXDBStr = new ProjectXDBStr();
           // sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["projectXConnStr"].ToString());

        }
        public List<GraderDTO> GetGrades()
        {
            try
            {
                List<GraderDTO> gradesList = new List<GraderDTO>();
                var lsGrades = projectXDBStr.Graders.ToList();
                foreach (var item in lsGrades)
                {
                    gradesList.Add(
                        new GraderDTO
                        {
                            ParticipantID = item.ParticipantID,
                            CourseID = item.CourseID,
                            BatchID = item.BatchID,
                            Marks_Obtained = item.Marks_Obtained
                        });
                }
                return gradesList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GraderDTO> GetGradesByCourseID(string courseId)
        {
            try
            {
                List<GraderDTO> lstGrades = new List<GraderDTO>();
                var gradesList = projectXDBStr.Graders.Where(x => x.CourseID == courseId).ToList();

                foreach (var item in gradesList)
                {
                    lstGrades.Add(
                        new GraderDTO
                        {
                            ParticipantID = item.ParticipantID,
                            BatchID = item.BatchID,
                            Marks_Obtained = item.Marks_Obtained
                        });
                }
                return lstGrades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Inserting/Adding Grade details in DB using ADO.NET
        public int InsertGrades(GraderDTO gradesDetails)
        {
            sqlCmd = new SqlCommand("[dbo].[uspInsertGrader]", sqlConn);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Marks_Obtain", gradesDetails.Marks_Obtained);
            sqlCmd.Parameters.AddWithValue("@Feedback", gradesDetails.Feedback);
            sqlCmd.Parameters.AddWithValue("@BatchID", gradesDetails.BatchID);
            sqlCmd.Parameters.AddWithValue("@CourseID", gradesDetails.CourseID);
            sqlCmd.Parameters.AddWithValue("@ParticipantID", gradesDetails.ParticipantID);

            try
            {
                sqlConn.Open();
                SqlParameter reValue = new SqlParameter("returnVal", System.Data.SqlDbType.Int);
                reValue.Direction = System.Data.ParameterDirection.ReturnValue;
                
                int rowsAffected = sqlCmd.ExecuteNonQuery(); //(int)reValue.Value;
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
    }
}
