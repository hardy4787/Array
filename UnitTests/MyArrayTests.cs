using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Tests
{
    [TestClass()]
    public class MyArrayTests
    {
        private MyArray<ExamTest> students;
        private ExamTest testExam;
        [TestInitialize]
        public void TestInitialize()
        {
            students = new MyArray<ExamTest>(-6, -2);
            testExam = new ExamTest("Христич", "Математика", 100, new DateTime(2018, 10, 10));
            students.Add(testExam);
        }

        [ExpectedException(typeof(ArgumentException), "Exception not thrown")]
        [TestMethod()]
        public void MyArray_LeftBorderLessThanRightBorder_ThrowedException()
        {
            int leftBorder = 10;
            int rightBorder = 0;

            MyArray<int> MyArray = new MyArray<int>(leftBorder, rightBorder);
        }

        [TestMethod()]
        public void MyArray_LeftBorderIsFiveRightIsSeven_CorrectionIndexIsMinusFive()
        {
            int LeftBorder = 5;
            int RightBorder = 7;
            int expected = -5;

            MyArray<int> MyArray = new MyArray<int>(LeftBorder, RightBorder);
            MyArray.Add(10);
            int actual = MyArray.IndexOf(10) * -1;

            Assert.AreEqual(expected, actual, "Incorrect correction index.");
        }

        [ExpectedException(typeof(NullReferenceException), "Exception not thrown")]
        [TestMethod()]
        public void MyArray_TranferedNull_ThrowedException()
        {
            students = new MyArray<ExamTest>(null);
        }

        [TestMethod()]
        public void IndexOf_GetIndexTheFirstElementOfTheArrayFromMinus6ToMinus2_minus6Returned()
        {
            int expected = -6;

            int actual = students.IndexOf(testExam);
            
            Assert.AreEqual(expected, actual);
        }

        
        [TestMethod()]
        public void Insert_AddedElementWithIndexMinus3_Minus3ReturnedIndexAddedElement()
        {
            ExamTest student = new ExamTest("Стратила", "Математика", 90, new DateTime(2017, 5, 10));
            students.Insert(-5,student);
            int expected = -5;
            
            int actual = students.IndexOf(student);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveAt_DeletedElementWithIndexMinus6_Minus1ReturnedAfterCheckDeletedElementInIndexOf()
        {
            int expected = -1;
            students.RemoveAt(-6);

            int actual = students.IndexOf(testExam);

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(NullReferenceException), "Exception was not thrown")]
        [TestMethod()]
        public void AddTest()
        {
            students = new MyArray<ExamTest>(null);
        }

        [TestMethod()]
        public void Add_AddElementToEndArray_()
        {
            int expected = 2;

            students.Add(new ExamTest("Стратила", "Математика", 90, new DateTime(2017, 5, 10)));
            int actual = students.Count;
            
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Clear_ClearAllArray_0ReturnedNumberElementsInArray()
        {
            int expected = 0;

            students.Clear();
            int actual = students.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Contains_CheckAvailabilityExamTestInArray_TrueReturned()
        {
            bool expected = true;

            bool actual = students.Contains(testExam);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Copy_TestArrayCopuToActualArray_ArraysHaveEqualentItems()
        {
            MyArray<int> expectedMyArray = new MyArray<int>(-5, 2) { 1, 5, 6, 8, 9, 2 };
            int[] expectedArray = new int [] { 1, 5, 6, 8, 9, 2 }; 
            int[] actualArray = new int[6];

            expectedMyArray.CopyTo(actualArray, 0);

            CollectionAssert.AreEqual(expectedArray, actualArray);

        }

        [TestMethod()]
        public void Remove_DeletedAboveAddedElement_Minus1ReturnedAfterCheckDeletedElementInIndexOf()
        {
            int expected = -1;

            students.Remove(testExam);
            int actual = students.IndexOf(testExam);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetEnumerator_GetAllElementFromMyArrayAndPutTheirInTestCollection_MyArratAndCollectionHaveSameElements()
        {
            MyArray<int> MyCreatedArray = new MyArray<int>(-5, 2) { 1, 5, 6, 8, 9, 2 };
            ICollection<int> TestCollection = new List<int>();
            foreach (var el in MyCreatedArray)
                TestCollection.Add(el);
            int expectedCount = 0;
            int actualCount = -1;

            if (MyCreatedArray.Count == TestCollection.Count)
            {
                var Result = TestCollection.Except(MyCreatedArray);
                actualCount = Result.Count();
            }

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}