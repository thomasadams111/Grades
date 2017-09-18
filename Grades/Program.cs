using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook(); //Instatiate gradebook class, using constructor.
            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics(); // return statistics object
            Console.WriteLine($"Average grade: {stats.AverageGrade}");
            Console.WriteLine($"Highest grade: {stats.HighestGrade}");
            Console.WriteLine($"Lowest grade: {stats.LowestGrade}");



        }
    }
}
