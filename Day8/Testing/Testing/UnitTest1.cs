using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        [Test()]
        public void CalculateCGPATest_A()
        {
            int[] marks = { 90, 94, 95, 98, 98 };
            float cgpa = Program.CalculateCGPA(marks);
            Assert.IsTrue(cgpa == 9.5);
        }
        [Test()]
        public void CalculateCGPATest_B()
        {
            int[] marks = { 60, 70, 80, 90, 100 };
            float cgpa = Program.CalculateCGPA(marks);
            Assert.AreEqual(cgpa, 8.0);
        }
    }
}