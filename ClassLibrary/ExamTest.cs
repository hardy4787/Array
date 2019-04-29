using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ExamTest : IComparable<ExamTest>
    {
        public string NameStudent { get; set; }
        public DateTime DataPassed { get; set; }
        public string Name { get; set; }
        public int Result { get; set; }
        public ExamTest(string nameStudent, string nameTest, int mark, DateTime date)
        {
            this.Result = mark;
            this.Name = nameTest;
            this.NameStudent = nameStudent;
            this.DataPassed = date;
        }

        public override string ToString()
        {
            return $"Имя студента: {NameStudent}\nТест: {Name}\nРезультат: {Result}\nДата: {DataPassed}\n";
        }

        public int CompareTo(ExamTest s)
        {
            return this.Result.CompareTo(s.Result);
        }
    }
}
