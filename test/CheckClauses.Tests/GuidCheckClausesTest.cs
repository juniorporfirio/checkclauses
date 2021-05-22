using System;
using Xunit;

namespace JuniorPorfirio.CheckClauses.Tests
{
    public class GuidCheckClausesTest
    {

        [Fact(DisplayName = "Guid with value, should return guid value")]
        public void Should_return_value_guid()
        {
            //Arrange
            var Id = Guid.NewGuid();

            //Arrange
            var IdValue = Check.Clauses(nameof(Id), Id).NullEmpty();
            //Assert
            Assert.Equal(Id, IdValue);
        }
        [Fact(DisplayName = "Guid is empty, should return empty exception")]
        public void Should_return_throw_empty_or_null_guid()
        {
            //Arrange
            var empty = Guid.Empty;
            var inputName = "Id";
            string message = "Field Id cannot be empty";
            //Arrange
            Action validate = () => Check
                                    .Clauses(inputName, empty)
                                    .NullEmpty();
            //Assert
            var exception = Assert.Throws<ArgumentException>(validate);
            Assert.Contains(message, exception.Message);
        }
    }
}