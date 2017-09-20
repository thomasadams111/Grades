using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;

            try
            {
                using (FileStream stream = File.Open("grades.txt", FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        float grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = reader.ReadLine();
                    }

                    // higher level file reading
                    //string[] lines = File.ReadAllLines("grades.txt");
                    //foreach (string line in lines)
                    //{
                    //    float grade = float.Parse(line);
                    //    book.AddGrade(grade);
                    //}
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not locate the file grades.txt");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No access");
                return;
            }

            book.DoSomething();
            book.WriteGrades(Console.Out);
            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            try
            {
                //Console.WriteLine("Please enter a name for the book");
                //book.Name = Console.ReadLine();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Name");
            }


            WriteNames(book.Name);

            GradeStatistics stats = book.ComputeStatistics(); // return statistics object
            Console.WriteLine($"Average grade: {stats.AverageGrade}");
            Console.WriteLine($"Highest grade: {stats.HighestGrade}");
            Console.WriteLine($"Lowest grade: {stats.LowestGrade}");
            Console.WriteLine($"{stats.LetterGrade} {stats.Description}");
        }

        private static IGradeTracker CreateGradeBook()
        {
            //Instatiate gradebook class, using constructor.
            IGradeTracker book = new ThrowAwayGradeBook("Tom's Gradebook");
            return book;
        }

        private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("***");
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Name changed from {args.OldValue} to {args.NewValue}");
        }

        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }

        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }

        private static void WriteByteArray(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write($"0x{b:X} ");
            }
            Console.WriteLine();
        }

        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
