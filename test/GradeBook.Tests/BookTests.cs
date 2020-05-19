using System;
using Xunit;


namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void CorrectValueAdded()
        {
        //Given
        var book = new InMemoryBook("Value Book");
        book.AddGrade(99.1);
        book.AddGrade(56.2);
        //When
        var result = book.GetStatistics();
        
        //Then
        Assert.Equal(99.1, result.High);
        }
        [Fact]
        public void BookCalculatesStatistis()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var actual = book.GetStatistics();

            // assert
            Assert.Equal(85.6, actual.Avarage, 1);
            Assert.Equal(90.5, actual.High, 2);
            Assert.Equal(77.3, actual.Low, 2);
            Assert.Equal('B', actual.Letter);
        }
    }
}
