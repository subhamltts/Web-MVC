using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXBL;
using ProjectXDTO;

namespace ProjectXTest
{
    [TestClass]
    public class ProjectXBLLTest
    {
        [TestMethod]
        public void insertFacultyTest()
        {
            FacultyBL obj = new FacultyBL();
            FacultyDTO facultyDTO = new FacultyDTO
            {
                FacultyName = "Kiran",
                EmailID = "kiran.pandey@ltts.com",
                PSNo = 99004944
            };

            int ret = obj.insertFaculty(facultyDTO);
            int actualValue = ret;
            int expectedvalue = 1;
            Assert.AreEqual(expectedvalue, actualValue);
        }

        [TestMethod]
        public void updateFacultyTest()
        {
            FacultyBL obj = new FacultyBL();
            FacultyDTO facultyDTO = new FacultyDTO
            {
                PSNo = 99004944,
                FacultyName = "Kiran"
            };

            int ret = obj.updateFaculty(facultyDTO);
            int actualValue = ret;
            int expectedvalue = 1;
            Assert.AreEqual(expectedvalue, actualValue);
        }

        [TestMethod]
        public void deleteFacultyTest()
        {
            FacultyBL obj = new FacultyBL();
            FacultyDTO facultyDTO = new FacultyDTO
            {
                PSNo = 99004944
            };

            int ret = obj.deleteFaculty(facultyDTO);
            int actualValue = ret;
            int expectedvalue = 1;
            Assert.AreEqual(expectedvalue, actualValue);
        }
    }
}
