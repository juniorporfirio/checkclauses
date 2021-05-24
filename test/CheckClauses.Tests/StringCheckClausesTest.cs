using System;
using Xunit;

namespace JuniorPorfirio.CheckClauses.Tests
{
    public class StringCheckClausesTest
    {
        private string ruleEmail = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        [Fact(DisplayName = "String is not null or empty, should return value string")]
        public void Should_return_valid_string()
        {
            //Arrange
            var myname = "Júnior";
            var inputName = "name";
            //Act
            string validName = Check.Clauses(inputName, myname).IsNullOrEmpty();
            //Assert
            Assert.Equal(myname, validName);
        }

        [Fact(DisplayName = "String e-mail is valid, should return the email")]
        public void Should_return_valid_string_format_email()
        {
            //Arrange
            var myemail = "juniorporfirio@gmail.com";
            var inputName = "e-mail";
            //Act
            string validEmail = Check.Clauses(inputName, myemail).IsMatchRegex(ruleEmail);
            //Assert
            Assert.Equal(myemail, validEmail);
        }
        [Fact(DisplayName = "String is not null or white space, should return value string")]
        public void Should_validate_null_or_whitespace_returning_string_value()
        {
            //Arrange
            var myname = "Júnior";
            var inputName = "name";

            //Act
            string validName = Check.Clauses(inputName, myname).IsNullOrWhiteSpace();

            //Assert
            Assert.Equal(myname, validName);
        }
        [Fact(DisplayName = "String e-mail is not valid, should return invalid exception")]
        public void Should_return_invalid_email_address()
        {
            //Arrange
            var myinvalidemail = "@juniorporfirio";
            var inputName = "e-mail";
            var message = $"Field {inputName} was with invalid format";

            //Act
            Action validateEmail = () => Check.Clauses(inputName, myinvalidemail).IsMatchRegex(ruleEmail);

            //Assert
            var exceptionEmail = Assert.Throws<ArgumentException>(validateEmail);
            Assert.Contains(message, exceptionEmail.Message);
        }

        [Fact(DisplayName = "String is empty or null, should return null or empty exception")]
        public void Should_return_throw_empty_or_null_string()
        {
            //Arrange
            var empty = "";
            string nullable = null;
            var inputName = "name";
            var message = $"Field {inputName} cannot be null or empty";

            //Act
            Action clausesEmpty = () => Check.Clauses(inputName, name: empty).IsNullOrEmpty();
            Action clausesNull = () => Check.Clauses(inputName, name: nullable).IsNullOrEmpty();

            //Assert
            var exceptionEmpty = Assert.Throws<ArgumentException>(clausesEmpty);
            Assert.Contains(message, exceptionEmpty.Message);

            var exceptionNull = Assert.Throws<ArgumentException>(clausesNull);
            Assert.Contains(message, exceptionNull.Message);

        }

        [Fact(DisplayName = "String is empty or whitespace, should return null whitespace or empty exception")]
        public void Should_return_throw_empty_or_whitespace_string()
        {
            //Arrange
            var whitespace = " ";
            string nullable = null;
            var inputName = "name";
            var message = $"Field {inputName} cannot be null or with white space";

            //Act
            Action clausesEmpty = () => Check.Clauses(inputName, name: whitespace).IsNullOrWhiteSpace();
            Action clausesNull = () => Check.Clauses(inputName, name: nullable).IsNullOrWhiteSpace();

            //Assert
            var exceptionEmpty = Assert.Throws<ArgumentException>(clausesEmpty);
            Assert.Contains(message, exceptionEmpty.Message);

            var exceptionNull = Assert.Throws<ArgumentException>(clausesNull);
            Assert.Contains(message, exceptionNull.Message);

        }


        [Fact(DisplayName = "String is not number, should return number exception")]
        public void Should_return_throw_cannot_be_number_string()
        {
            //Arrange
            var number = "One";
            var inputName = nameof(number);
            var message = $"Field {inputName} should be numeric";

            //Act
            Action clausesNumber = () => Check.Clauses(inputName, name: number).IsNumber();

            //Assert
            var exceptionEmpty = Assert.Throws<ArgumentException>(clausesNumber);
            Assert.Contains(message, exceptionEmpty.Message);

        }

        [Fact(DisplayName = "String is number, should return number")]
        public void Should_return_value_to_number_string()
        {
            //Arrange
            var number = "10";
            var inputName = nameof(number);

            //Act
            var value = Check.Clauses(inputName, name: number).IsNumber();

            //Assert
            Assert.Equal(number, value);

        }

        [Fact(DisplayName = "String length is minor than 10, should return string")]
        public void Should_return_value_with_length_minor_than_ten()
        {
            //Arrange
            var number = 10;
            var name = "Júnior";
            var inputName = nameof(name);

            //Act
            var value = Check.Clauses(inputName, name: name).MaxLength(number);

            //Assert
            Assert.Equal(name, value);

        }

        [Fact(DisplayName = "String is minor than length, should return maxlength exception")]
        public void Should_return_throw_cannot_be_minor_than_ten()
        {
            //Arrange
            var number = 10;
            var name = "Jeff Gordon";
            var inputName = nameof(name);
            var message = $"Field {inputName} cannot be minor than {number} caracteres";

            //Act
            Action clausesNumber = () => Check.Clauses(inputName, name: name).MaxLength(number);

            //Assert
            var exceptionEmpty = Assert.Throws<ArgumentException>(clausesNumber);
            Assert.Contains(message, exceptionEmpty.Message);

        }
    }
}
