using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            else if (averageGrade >= 100 * 0.8)
                return 'A';
            else if (averageGrade >= 100 * 0.6)
                return 'B';
            else if (averageGrade >= 100 * 0.4)
                return 'C';
            else if (averageGrade >= 100 * 0.2)
                return 'D';
            return 'F';
        
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            int count = 0;
            foreach(var student in Students)
            {
                if (student.Grades.Count > 0)
                    count++;
            }
            if (count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
            base.CalculateStudentStatistics(name);
        }
    }
}
