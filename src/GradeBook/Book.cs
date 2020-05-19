using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public class NamedObject
    {
        public NamedObject(String name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade.ToString());
                result.RecieveNumber(grade);
                if (GradeAdded != null)
                    GradeAdded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            result.ComputeAvarage();
            result.GetLetterValue();
            return result;
        }


        public override event GradeAddedDelegate GradeAdded;
        List<double> grades;
        public Statistics result = new Statistics();
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break ;
                case 'B':
                    AddGrade(80);
                    break ;
                case 'C':
                    AddGrade(70);
                    break ;
                case 'D':
                    AddGrade(60);
                    break ;
                default:
                    AddGrade(0);
                    break ;

            }
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                result.RecieveNumber(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"invalid grade --> {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            result.ComputeAvarage();
            result.GetLetterValue();
            return result;
        }
        List<double> grades;
        public Statistics result = new Statistics();

    }
}