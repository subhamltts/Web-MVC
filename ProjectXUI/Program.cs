using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXBL;
using ProjectXDTO;

namespace ProjectXUI
{
    class Program
    {
        static void Main(string[] args)
        {
            FacultyBL obj = new FacultyBL();
            /*var output = obj.GetFaculty();
            foreach (var item in output)
            {
                Console.WriteLine(item.FacultyName);
            }*/

            // Insert Function calling...
            /*Console.WriteLine("Enter Faculty Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Faculty EmailID: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Faculty PSNo: ");
            int psno = Convert.ToInt32(Console.ReadLine());

            FacultyDTO facultyDTO = new FacultyDTO()
            {
                FacultyName = name,
                EmailID = email,
                PSNo = psno
            };

            int retVal = obj.insertFaculty(facultyDTO);
            if(retVal == 1)
            {
                Console.WriteLine("Inserted Successfully!");
                Console.WriteLine("****************  Faculty List  *************");
                var list = obj.GetFaculties();
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.FacultyName}  {item.EmailID}  {item.PSNo}");
                }
            }
            else
            {
                Console.WriteLine("Oops, Something went wrong:(");
            }*/
           
            // Update Function calling...
            /*Console.WriteLine("Enter Faculty PSNo: ");
            int psNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter faculty name:");
            string facName = Console.ReadLine();

            FacultyDTO faculty = new FacultyDTO
            {
                PSNo = psNum,
                FacultyName = facName
            };

            int ret = obj.updateFaculty(faculty);
            if (ret == 1)
            {
                Console.WriteLine("Updated Successfully!");
                Console.WriteLine("****************  Faculty List  *************");
                var list = obj.GetFaculties();
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.FacultyName}  {item.EmailID}  {item.PSNo}");
                }
            }
            else
            {
                Console.WriteLine("Oops, Something went wrong:(");
            }
            */
            // Delete function calling...
           /*Console.WriteLine("Enter Faculty PSNo: ");
            int psn = Convert.ToInt32(Console.ReadLine());

            FacultyDTO fDTO = new FacultyDTO
            {
                PSNo = psNum,
            };

            int retVal1 = obj.deleteFaculty(facultyDTO);
            if (ret == 1)
            {
                Console.WriteLine("Deleted Successfully!");
                Console.WriteLine("****************  Faculty List  *************");
                var list = obj.GetFaculties();
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.FacultyName}  {item.EmailID}  {item.PSNo}");
                }
            }
            else
            {
                Console.WriteLine("Oops, Something went wrong:(");
            }*/
        }
    }
}
