using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Grades;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTest
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(70);
            book.AddGrade(77);
            book.AddGrade(90);
            GradeStatistics stats = book.ComputeStatistics();

            Assert.AreEqual(90, stats.HighestGrade);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(70);
            book.AddGrade(77);
            book.AddGrade(90);
            GradeStatistics stats = book.ComputeStatistics();

            Assert.AreEqual(70, stats.LowestGrade);
        }

        [TestMethod]
        public void ComputesAverageGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(70);
            book.AddGrade(78);
            book.AddGrade(90);
            GradeStatistics stats = book.ComputeStatistics();

            Assert.AreEqual(79.33, stats.AverageGrade, 0.01);
        }
        [TestMethod]
        public void ComputesAverageGradeFile()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(70);
            book.AddGrade(78);
            book.AddGrade(90);
            //book.AddGrade(92);
            //book.AddGrade(93);

            //this is just to test "using". you can delete this test method
            using (StreamWriter ouputFile = File.CreateText("unitMetin" + "3" + ".txt"))
            {
                book.WriteGrades(ouputFile);
            }
            
            //ouputFile.Close();
            GradeStatistics stats = book.ComputeStatistics();

            Assert.AreEqual(79.33, stats.AverageGrade, 0.01);
        }
    }
}
