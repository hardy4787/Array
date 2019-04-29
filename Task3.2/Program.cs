using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray<ExamTest> testArray1 = new MyArray<ExamTest>(-10, -3);
            ExamTest s1 = new ExamTest("Христич", "Математика", 100, new DateTime(2018, 10, 10));
            ExamTest s2 = new ExamTest("Бартов", "Математика", 70, new DateTime(2017, 4, 12));
            ExamTest s3 = new ExamTest("Пасечник", "Математика", 80, new DateTime(2016, 2, 3));
            ExamTest s4 = new ExamTest("Стратила", "Математика", 90, new DateTime(2017, 5, 10));
            ExamTest s5 = new ExamTest("Черепанцева", "Математика", 85, new DateTime(2018, 10, 1));
            ExamTest s6 = new ExamTest("Демченко", "Математика", 85, new DateTime(2018, 10, 1));
            ExamTest s7 = new ExamTest("Демченко", "Математика", 85, new DateTime(2018, 10, 1));
            ExamTest s8 = new ExamTest("Демченко", "Математика", 85, new DateTime(2018, 10, 1));
            testArray1.Add(s1);
            testArray1.Add(s2);
            testArray1.Add(s3);
            testArray1.Add(s4);

            MyArray<int> testArray2 = new MyArray<int>(-5, 2) { 1, 5, 6, 8, 9, 2 };
            Console.WriteLine(testArray2[-5]);

            int[] arr1 = new int[10];
            testArray2.CopyTo(arr1, 0);

            List<int> list1 = new List<int> { 1, 2, 3, 5, 5, 5, 5, 5 };
            MyArray<int> testArray3 = new MyArray<int>(list1);
            foreach (var kek in testArray1)
                Console.WriteLine(kek);
            Console.WriteLine();
            foreach (var kek in testArray2)
                Console.WriteLine(kek);
            Console.WriteLine();
            foreach (var kek in arr1)
                Console.WriteLine(kek);

        }

    }
}
