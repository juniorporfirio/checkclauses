using System;
using Xunit;

namespace JuniorPorfirio.CheckClauses.Tests
{
    public class IntCheckClausesTest
    {
        [Fact(DisplayName = "Number of type int in range values, should return value")]
        public void Should_return_number_in_range_value()
        {
            //Arrange
            int number = 10;
            var begin = 1;
            var end = 10;

            //Act
            var value = Check.Clauses(nameof(number), number).OutOfRange(begin, end);

            //Assert
            Assert.Equal(number, value);
        }

        [Fact(DisplayName = "Number of type int greater than zero, should return value")]
        public void Should_return_number_greater_than_zero()
        {
            //Arrange
            int number = 1;

            //Act
            var value = Check.Clauses(nameof(number), number).IsZero();

            //Assert
            Assert.Equal(number, value);
        }
        [Fact(DisplayName = "Number of type int is positive, should return value")]
        public void Should_return_number_positive()
        {
            //Arrange
            int number = 1;

            //Act
            var value = Check.Clauses(nameof(number), number).IsNegative();

            //Assert
            Assert.Equal(number, value);
        }


        [Fact(DisplayName = "Number of type int is negative, should return negative exception")]
        public void Should_return_throw_if_number_is_negative()
        {
            //Arrange
            int number = -1;
            var inputName = nameof(number);
            var message = $"Field number cannot be negative";

            //Act
            Action validate = () => Check.Clauses(inputName, number).IsNegative();

            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }



        [Fact(DisplayName = "Number of type int is positive greater than zero, should return value")]
        public void Should_return_number_positive_greater_than_zero()
        {
            //Arrange
            int number = 1;

            //Act
            var value = Check.Clauses(nameof(number), number).IsNegativeOrZero();

            //Assert
            Assert.Equal(number, value);
        }


        [Fact(DisplayName = "Number of type int is negative or zero, should return negative or zero exception")]
        public void Should_return_throw_if_number_is_negative_or_zero()
        {
            //Arrange
            int number = 0;
            var inputName = nameof(number);
            var message = $"Field number cannot be negative or zero";

            //Act
            Action validate = () => Check.Clauses(inputName, number).IsNegativeOrZero();

            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }

        [Fact(DisplayName = "Number of type int is zero, should return zero exception")]
        public void Should_return_throw_if_number_is_zero()
        {
            //Arrange
            int number = 0;
            var inputName = nameof(number);
            var message = $"Field number cannot be zero";

            //Act
            Action validate = () => Check.Clauses(inputName, number).IsZero();

            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }


        [Fact(DisplayName = "Number of type int is greater than range values, should return between exception")]
        public void Should_return_throw_without_range_is_greater_than_numbers()
        {
            //Arrange
            int number = 10;
            var begin = 1;
            var end = 9;
            var inputName = nameof(number);
            var message = $"Field number cannot be out of range {begin} and {end}";

            //Act
            Action validate = () => Check.Clauses(inputName, number).OutOfRange(begin, end);

            //Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }

        [Fact(DisplayName = "Number of type int is minor than range values, should return between exception")]
        public void Should_return_throw_without_range_is_minor_than_numbers()
        {
            //Arrange
            int number = 1;
            var begin = 2;
            var end = 9;
            var inputName = "number";
            var message = $"Field number cannot be out of range {begin} and {end}";

            //Act
            Action validate = () => Check.Clauses(inputName, number).OutOfRange(begin, end);

            //Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }



    }
}