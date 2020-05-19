using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Besnik's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);
            var stats = book.GetStatistics();
            System.Console.WriteLine($"For the book name {book.Name}");
            System.Console.WriteLine($"The avarage grade is {stats.Avarage:N1}");
            System.Console.WriteLine($"Maximum is {stats.High}");
            System.Console.WriteLine($"Minimum value {stats.Low}");
            Console.WriteLine($"the letter is {stats.Letter}");

        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                System.Console.WriteLine("Please enter grades");
                var input = Console.ReadLine();

                if (input == "Q")
                    break;
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade was added");
        }
    }
}