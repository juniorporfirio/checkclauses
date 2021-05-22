using System;
using Xunit;

namespace JuniorPorfirio.CheckClauses.Tests
{
    public class DecimalCheckClausesTest
    {
        [Fact(DisplayName = "Number of type decimal in range values, should return value")]
        public void Should_return_number_in_range_value()
        {
            //Arrange
            decimal number = 10.1M;
            var begin = 1.0M;
            var end = 10.1M;

            //Act
            var value = Check.Clauses(nameof(number), number).OutOfRange(begin, end);

            //Assert
            Assert.Equal(number, value);
        }

        [Fact(DisplayName = "Number of type decimal greater than zero, should return value")]
        public void Should_return_number_greater_than_zero()
        {
            //Arrange
            decimal number = 1;

            //Act
            var value = Check.Clauses(nameof(number), number).IsZero();

            //Assert
            Assert.Equal(number, value);
        }
        [Fact(DisplayName = "Number of type decimal is positive, should return value")]
        public void Should_return_number_positive()
        {
            //Arrange
            decimal number = 1;

            //Act
            var value = Check.Clauses(nameof(number), number).IsNegative();

            //Assert
            Assert.Equal(number, value);
        }


        [Fact(DisplayName = "Number of type decimal is negative, should return negative exception")]
        public void Should_return_throw_if_number_is_negative()
        {
            //Arrange
            decimal number = -1;
            var inputName = nameof(number);
            var message = $"Field number cannot be negative";

            //Act
            Action validate = () => Check.Clauses(inputName, number).IsNegative();

            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }



        [Fact(DisplayName = "Number of type decimal is positive greater than zero, should return value")]
        public void Should_return_number_positive_greater_than_zero()
        {
            //Arrange
            decimal number = 1;

            //Act
            var value = Check.Clauses(nameof(number), number).IsNegativeOrZero();

            //Assert
            Assert.Equal(number, value);
        }


        [Fact(DisplayName = "Number of type decimal is negative or zero, should return negative or zero exception")]
        public void Should_return_throw_if_number_is_negative_or_zero()
        {
            //Arrange
            decimal number = 0;
            var inputName = nameof(number);
            var message = $"Field number cannot be negative or zero";

            //Act
            Action validate = () => Check.Clauses(inputName, number).IsNegativeOrZero();

            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }

        [Fact(DisplayName = "Number of type decimal is zero, should return zero exception")]
        public void Should_return_throw_if_number_is_zero()
        {
            //Arrange
            decimal number = 0;
            var inputName = nameof(number);
            var message = $"Field number cannot be zero";

            //Act
            Action validate = () => Check.Clauses(inputName, number).IsZero();

            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }


        [Fact(DisplayName = "Number of type decimal is greater than range values, should return between exception")]
        public void Should_return_throw_without_range_is_greater_than_numbers()
        {
            //Arrange
            decimal number = 10.0M;
            var begin = 1.1M;
            var end = 9.9M;
            var inputName = nameof(number);
            var message = $"Field number cannot be out of range {begin} and {end}";

            //Act
            Action validate = () => Check.Clauses(inputName, number).OutOfRange(begin, end);

            //Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }

        [Fact(DisplayName = "Number of type decimal is minor than range values, should return between exception")]
        public void Should_return_throw_without_range_is_minor_than_numbers()
        {
            //Arrange
            decimal number = 1.0M;
            var begin = 2.0M;
            var end = 9.0M;
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