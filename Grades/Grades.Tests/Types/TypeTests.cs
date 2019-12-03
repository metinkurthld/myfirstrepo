using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Grades;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void VariablesHoldReference()
        {
            Gradebook g1 = new Gradebook();
            Gradebook g2 = g1;
            g2 = new Gradebook();
            g2 = g1;

            g1.Name = "Metin's Grade book!";
            Assert.AreEqual(g1.Name, g2.Name);
      
        }

        [TestMethod]
        public void IntVariableHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;
            x1 = 4;
            x2 = 4;
            Assert.AreEqual(x1, x2);
           
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Metin";
            string name2 = "metin";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase); //, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReferenceTypePassbyValue()
        {
            Gradebook book1 = new Gradebook();
            Gradebook book2 = book1;

            GiveBookAName(book2);

            Assert.AreEqual("aaa Gradebook", book1.Name);

        }

        [TestMethod]
        public void ValuePassbyValue()
        {
            int x = 47;
            incrementNumber(x);
            Assert.AreEqual(47, x);
        }

        private void GiveBookAName(Gradebook book)
        {
            book = new Gradebook();
            book.Name = "aaa Gradebook";
        }

        private void incrementNumber(int number)
        {
            number += 1;
        }



        [TestMethod]
        public void ReferenceTypePassbyValueRef()
        {
            Gradebook book1 = new Gradebook();
            Gradebook book2 = book1;

            GiveBookANameRef(ref book2);

            Assert.AreEqual("aaaRef Gradebook", book2.Name);
        }

        private void GiveBookANameRef(ref Gradebook book) 
        {
            book = new Gradebook(); //by Ref parameter this is also changing the reference in the input gradebook
            book.Name = "aaaRef Gradebook";
        }

        [TestMethod]
        public void ValuePassbyValueRef()
        {
            int x = 47;
            incrementNumberRef(ref x);
            Assert.AreEqual(48, x); //ref keyword makes value type int x incremented as well.
        }

        private void incrementNumberRef(ref int number)
        {
            number += 1;
        }

        [TestMethod]
        public void AddDaystoADataTime()
        {
            DateTime date = new DateTime(2019, 12, 2);
            date = date.AddDays(1);

            Assert.AreEqual(3, date.Day);
        }

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades); 
            Assert.AreEqual(89.5f, grades[1]);
        }

        private void AddGrades(float[] grades) //this works because arrays are reference types. really interesting!!!. 
        {
            grades[1] = 89.5f;
        }
    }
}
