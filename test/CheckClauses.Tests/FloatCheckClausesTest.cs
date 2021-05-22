using System;
using Xunit;

namespace JuniorPorfirio.CheckClauses.Tests
{
    public class FloatCheckClausesTest
    {
        [Fact(DisplayName = "Number of type float in range values, should return value")]
        public void Should_return_number_in_range_value()
        {
            //Arrange
            float number = 10.1F;
            var begin = 1.0F;
            var end = 10.1F;

            //Act
            var value = Check.Clauses(nameof(number), number).OutOfRange(begin, end);

            //Assert
            Assert.Equal(number, value);
        }

        [Fact(DisplayName = "Number of type float greater than zero, should return value")]
        public void Should_return_number_greater_than_zero()
        {
            //Arrange
            float number = 1;

            //Act
            var value = Check.Clauses(nameof(number), number).IsZero();

            //Assert
            Assert.Equal(number, value);
        }
        [Fact(DisplayName = "Number of type float is positive, should return value")]
        public void Should_return_number_positive()
        {
            //Arrange
            float number = 1;

            //Act
            var value = Check.Clauses(nameof(number), number).IsNegative();

            //Assert
            Assert.Equal(number, value);
        }


        [Fact(DisplayName = "Number of type float is negative, should return negative exception")]
        public void Should_return_throw_if_number_is_negative()
        {
            //Arrange
            float number = -1;
            var inputName = nameof(number);
            var message = $"Field number cannot be negative";

            //Act
            Action validate = () => Check.Clauses(inputName, number).IsNegative();

            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }



        [Fact(DisplayName = "Number of type float is positive greater than zero, should return value")]
        public void Should_return_number_positive_greater_than_zero()
        {
            //Arrange
            float number = 1F;

            //Act
            var value = Check.Clauses(nameof(number), number).IsNegativeOrZero();

            //Assert
            Assert.Equal(number, value);
        }


        [Fact(DisplayName = "Number of type float is negative or zero, should return negative or zero exception")]
        public void Should_return_throw_if_number_is_negative_or_zero()
        {
            //Arrange
            float number = 0;
            var inputName = nameof(number);
            var message = $"Field number cannot be negative or zero";

            //Act
            Action validate = () => Check.Clauses(inputName, number).IsNegativeOrZero();

            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }

        [Fact(DisplayName = "Number of type float is zero, should return zero exception")]
        public void Should_return_throw_if_number_is_zero()
        {
            //Arrange
            float number = 0;
            var inputName = nameof(number);
            var message = $"Field number cannot be zero";

            //Act
            Action validate = () => Check.Clauses(inputName, number).IsZero();

            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }


        [Fact(DisplayName = "Number of type float is greater than range values, should return between exception")]
        public void Should_return_throw_without_range_is_greater_than_numbers()
        {
            //Arrange
            float number = 10.0F;
            var begin = 1.1F;
            var end = 9.9F;
            var inputName = nameof(number);
            var message = $"Field number cannot be out of range {begin} and {end}";

            //Act
            Action validate = () => Check.Clauses(inputName, number).OutOfRange(begin, end);

            //Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(validate);
            Assert.Contains(message, exception.Message);
            Assert.Equal(inputName, exception.ParamName);
        }

        [Fact(DisplayName = "Number of type float is minor than range values, should return between exception")]
        public void Should_return_throw_without_range_is_minor_than_numbers()
        {
            //Arrange
            float number = 1.0F;
            var begin = 2.0F;
            var end = 9.0F;
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