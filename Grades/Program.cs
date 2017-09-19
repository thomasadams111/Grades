﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook("Tom's book"); //Instatiate gradebook class, using constructor.
            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics(); // return statistics object

            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;
            book.NameChanged -= OnNameChanged;

            book.Name = "Allen's book";
            WriteNames(book.Name);

            Console.WriteLine($"Average grade: {stats.AverageGrade}");
            Console.WriteLine($"Highest grade: {stats.HighestGrade}");
            Console.WriteLine($"Lowest grade: {stats.LowestGrade}");
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
