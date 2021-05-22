using System;
using Xunit;

namespace JuniorPorfirio.CheckClauses.Tests
{
    public class DateTimeCheckClausesTest
    {

        [Fact(DisplayName = "Date now is of range, return value")]
        public void Should_return_date_of_range()
        {
            //Arrange
            var today = DateTime.Now;
            var begin = DateTime.Now.AddYears(-1);

            //Act
            var data = Check
            .Clauses(nameof(today), today)
            .OutOfRange(begin, today);


            //Assert
            Assert.Equal(today, data);
        }
        [Fact(DisplayName = "Date now is out of range, return out of range exception")]
        public void Should_return_thrown_date_of_range()
        {
            //Arrange
            var today = DateTime.Now;
            var begin = DateTime.Now.AddYears(-1);
            var end = DateTime.Now.AddDays(-1);
            var message = $"Field {nameof(today)} cannot be out of range {begin} and {end}";

            //Act
            Action check = () => Check
            .Clauses(nameof(today), today)
            .OutOfRange(begin, end);


            //Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(check);
            Assert.Contains(message, exception.Message);
        }
    }
}