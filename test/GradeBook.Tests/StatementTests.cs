using System;
using Xunit;

namespace GradeBook.Tests
{
    public class StatementTests
    {
        [Fact]
        public void Test1()
        {
            var book1 = new InMemoryBook("Rodo");
            book1.AddGrade(90);
            book1.AddGrade(100);

            var stats = book1.GetStatistics();

            Assert.Equal(100, stats.High);
            
        }
    }

}