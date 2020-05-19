using System;
using Xunit;


namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
        //Given
        WriteLogDelegate log;
        log = ReturnMessage;
        
        //When
        var result = log("Hello!");
        Assert.Equal("Hello!", result);
        //Then
        }

        string ReturnMessage(string message)
        {
            return (message);
        }
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
        //Given
        var x = GetInt();
        //When
        SetInt(x);
        //Then
        Assert.Equal(2, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return (2);
        }
        [Fact]
        public void CSharpcanPassedByRef()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }
        private void GetBookSetName(out Book book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }        
        [Fact]
        public void CSharpIsPassedByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }
        private void GetBookSetName(Book book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // act

            // assert
            Assert.Same(book1, book2);
        }

        Book GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
