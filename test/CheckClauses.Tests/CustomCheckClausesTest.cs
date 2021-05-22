using System;
using Xunit;

namespace JuniorPorfirio.CheckClauses.Tests
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CustomCheckClausesTest
    {

        [Fact(DisplayName = "Instance of class is null, should return null exception")]
        public void Should_return_throw_generic_null()
        {
            //Arrange
            People people = null;
            string DisplayName = nameof(people);

            var message = $"Field {DisplayName} cannot be null";
            //Act
            Action validate = () => Check.Clauses(DisplayName, people).IsNull();

            //Assert
            var exception = Assert.Throws<ArgumentNullException>(validate);
            Assert.Contains(message, exception.Message);
        }

        [Fact(DisplayName = "Instance of People is not null, should return instance")]
        public void Should_return_valid_instance()
        {
            //Arrange
            People people = new People();
            string DisplayName = nameof(people);
            var message = $"Field {DisplayName} cannot be null";

            //Act
            var data = Check.Clauses(DisplayName, people).IsNull();

            //Assert
            Assert.Equal(people, data);
        }

        [Fact(DisplayName = "Number is out of rule clauses, should return clause tion exception")]
        public void Should_return_throw_with_expression_fail()
        {
            //Arrange
            var result = 10;
            var message = "Field result is invalid rules";
            var inputName = "result";

            //Act
            Action check = () => Check
            .Clauses(inputName, result)
            .Where(e => e > 10);

            //Assert
            var exception = Assert.Throws<ArgumentException>(check);
            Assert.Contains(message, exception.Message);

        }

        [Fact(DisplayName = "Number is rule clauses, should return value")]
        public void Should_return_value_within_clauses()
        {
            //Arrange
            var result = 10;

            //Act
            var data = Check
            .Clauses(nameof(result), result)
            .Where(e => e == 10);

            //Assert
            Assert.Equal(data, result);

        }
    }
}