using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void GiveBookAName(ref GradeBook book)
        {
            book = new GradeBook();
            book.Name = "The New GradeBook";
        }

        static void IncrememntNumber(ref int number)
        {
            number += 1;
        }

        static void Main(string[] args)
        {

            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello World");

            Arrays();
            Immutable();
            PassByValueAndRef();

            //GradeBook book = new GradeBook(); //Instatiate gradebook class, using constructor.
            //book.AddGrade(91f);
            //book.AddGrade(89.1f);
            //book.AddGrade(75f);

            //GradeStatistics stats = book.ComputeStatistics(); // return statistics object
            //Console.WriteLine($"Average grade: {stats.AverageGrade}");
            //Console.WriteLine($"Highest grade: {stats.HighestGrade}");
            //Console.WriteLine($"Lowest grade: {stats.LowestGrade}");
        }

        private static void Arrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            foreach (float grade in grades)
            {
                Console.WriteLine(grade);
            }
        }

        private static void AddGrades(float[] grades)
        {
            if (grades.Length >= 3)
            {
                grades[0] = 91f;
                grades[1] = 89.1f;
                grades[2] = 75f;
            }
        }

        private static void Immutable()
        {
            string name = " Scott ";
            name = name.Trim();
            DateTime date = new DateTime(2014, 01, 01);
            date = date.AddHours(25);

            Console.WriteLine(name);
            Console.WriteLine(date);
        }

        private static void PassByValueAndRef()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            GiveBookAName(ref g2);
            Console.WriteLine(g2.Name);

            int x1 = 10;
            IncrememntNumber(ref x1);
            Console.WriteLine(x1);
        }
    }
}
