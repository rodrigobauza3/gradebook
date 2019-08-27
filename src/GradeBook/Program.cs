using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Rodo's GradeBook");
            var flag = false;
            book.GradeAdded += OnGradeAdded;

            System.Console.WriteLine("Do you want to show Book's name? y/n");
            var n = Console.ReadLine();
            if (n == "y")
            {
                System.Console.WriteLine(book.Name);
            }

            flag = EnterGrades(book, flag);

            if (flag)
            {
                var stats = book.GetStatistics();

                Console.WriteLine($"The highest grade is {stats.High}");
                Console.WriteLine($"The lowest grade is {stats.Low}");
                Console.WriteLine($"The average grade is {stats.Average:N1}");
                Console.WriteLine($"The letter grade is {stats.Letter}");
                Console.WriteLine($"Vendor test name: {InMemoryBook.VENDOR}");
                //Console.WriteLine($"Category test name: {Book.category}");
            }
            else
            {
                Console.WriteLine("Sin entradas - Sin resultados para mostrar");
            }

        }

        private static bool EnterGrades(Book book, bool flag)
        {
            while (true)
            {
                Console.WriteLine("Please, enter a grade or 'q' to cancel:");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    flag = true;
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
                    //Console.WriteLine("Deja de mandarte cagadas mierda!");
                }
            }

            return flag;
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade was added!");
        }
    }
}
