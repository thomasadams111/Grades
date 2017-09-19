using System;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook
    {
        // constructors
        public GradeBook(string name = "No Name")
        {
            Name = name;
            _grades = new List<float>();
        }

        // methods
        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100 )
            {
                _grades.Add(grade);
            }
        }



        public GradeStatistics ComputeStatistics()
        {
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

        public void WriteGrades(TextWriter textWriter)
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
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value)
                {
                    var oldValue = _name;
                    _name = value;
                    if (NameChanged != null) // Check for at least 1 subscriber
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;
                        NameChanged(this, args);
                    }
                }
            }
        }

        public event NameChangedDelegate NameChanged; // Delegate variable, need subscribers
        
        private List<float> _grades;
    }
}
