using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        // constructors
        public GradeBook(string name = "No Name")
        {
            Console.WriteLine("Grade Book ctor");
            Name = name;
            _grades = new List<float>();
        }

        // methods
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100 )
            {
                _grades.Add(grade);
            }
        }

        public override IEnumerator GetEnumerator()
        {
            Console.WriteLine("Print using Interface");
            return _grades.GetEnumerator();
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook Compute");

            GradeStatistics stats = new GradeStatistics();

            float sum = 0f;
            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / _grades.Count;

            return stats;
        }

        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Grades:");
            //int i = 0;
            //do
            //{
            //    textWriter.WriteLine(_grades[i]);
            //    i++;
            //} while (i < _grades.Count);

            //int i = 0;
            //while (i < _grades.Count)
            //{
            //    textWriter.WriteLine(_grades[i]);
            //    i++;
            //}

            //for (int i = _grades.Count-1; i >= 0; i--)
            //{
            //    textWriter.WriteLine(_grades[i]);
            //}

            //for (int i = 0; i < _grades.Count; i++)
            //{
            //    textWriter.WriteLine(_grades[i]);
            //}

            foreach (float grade in _grades)
            {
                textWriter.WriteLine(grade);
            }
            textWriter.WriteLine("*********");
        }

        // fields
        protected List<float> _grades;
    }
}
