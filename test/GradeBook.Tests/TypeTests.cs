using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        public delegate string WriteLogDelegate(string logMessage);

        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;            
            return message;
        }
        
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "rodo";
            var upper = MakeUpperCase(name);

            Assert.Equal("rodo", name);            
            Assert.Equal("RODO", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
         public void Test1()
         {
             var x = GetInt();
             SetInt(out x);

             Assert.Equal(42, x);
         }

        private void SetInt(out int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            //act         

            //assert
            Assert.Equal("New Name",book1.Name);
        }
        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CSharpIsPassingByValue()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            //act         

            //assert
            Assert.Equal("Book 1",book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            //book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            //act         

            //assert
            Assert.Equal("New Name",book1.Name);
        }

        private void SetName(InMemoryBook book1, string name)
        {
            //book1.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act         

            //assert
            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            //Arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act         

            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}