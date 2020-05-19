using System;

namespace GradeBook
{
    public class Statistics
    {

        public Statistics()
        {   
            Avarage = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
            Index = 0;
        }

        public void RecieveNumber(double grade)
        {
            Avarage += grade;
            High = Math.Max(High, grade);
            Low = Math.Min(Low, grade);
            Index++;
        }

        public void ComputeAvarage()
        {
            Avarage /= Index;
        }

        public void GetLetterValue()
        {
            switch(Avarage)
            {
                case var d when d >= 90.0:
                    Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    Letter = 'B';
                    break ;
                case var d when d >= 70.0:
                    Letter = 'C';
                    break ;
                case var d when d >= 60.0:
                    Letter = 'D';
                    break ;
                case var d when d >= 0.0:
                    Letter = 'F';
                    break ;
            }
        }
        
        public double Avarage;
        public double High;
        public double Low;
        public char Letter;
        public int Index;
    }
}