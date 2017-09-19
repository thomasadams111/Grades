using System;
using System.Collections.Generic;

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
