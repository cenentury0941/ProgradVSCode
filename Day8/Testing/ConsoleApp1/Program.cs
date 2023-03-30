using Microsoft.VisualStudio.TestTools.UnitTesting;
using CGPACalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPACalculator.Tests
{
    [TestClass()]
    public class CGPACalTests
    {
        [TestMethod()]
        public void calculateCGPATest_A()
        {
            int subjectsCount1 = 3;
            List<float> marks1 = new() { 90.0f, 90.0f, 90.0f };
            /*string Actual = CGPACal.Main();
            string Expected = "O";*/
            try
            {
                CGPACal.Main();
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod()]
        public void calculateCGPATest_B()
        {
            int subjectCount = 3;
            List<float> marks = new List<float>() { 90.0f, 80.0f, 70.0f };
            string grade = CGPACal.calculateCGPA(subjectCount, marks);
            Console.WriteLine(grade);
            if (grade == "B")
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail();
        }
        [TestMethod()]
        public void calculateCGPATest_C()
        {
            int subjectCount = 3;
            List<float> marks = new List<float>() { 90.0f, 80.0f, 70.0f };
            string grade = CGPACal.calculateCGPA(subjectCount, marks);
            Console.WriteLine(grade);
            if (grade == "C")
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail();
            //Assert.Fail();
        }
    }
}