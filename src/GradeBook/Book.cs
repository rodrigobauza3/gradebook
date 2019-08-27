using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class NamedOject
        {
        public NamedOject(string name)
        {
            Name = name;
        }

        public string Name 
            { 
                get; 
                set; 
            }
        }
    public class Book : NamedOject
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public Book(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
            category = "";
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C': 
                    AddGrade(70);
                    break;
                
                default:
                    AddGrade(0);
                    break;                
            }
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }                
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} in Book.cs file");
                //Console.WriteLine("Invalid value");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public void ShowBookName()
        {
            Console.WriteLine($"The GradeBook Name is: {Name}");
            Console.WriteLine("");
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for(var index = 0; index < grades.Count; index++)
            {
                if (grades[index] == 42.1)
                {
                    continue;
                }

                result.Average += grades[index];
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
            }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        /*public string Name 
        {
            get
            {
                return name;
            } 
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
            } 
        }
        private string name;

        variable 'name' not needed as we can use a prop get;set; and exclude any of them with private keyword*/

        readonly string category = "Science";

        public const string VENDOR = "MS";

        private List<double> grades;
    }
}