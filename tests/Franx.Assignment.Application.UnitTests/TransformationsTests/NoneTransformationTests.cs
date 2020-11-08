using FluentAssertions;
using Franx.Assignment.Domain.Transformations;
using Xunit;

namespace Franx.Assignment.Application.UnitTests.TransformationsTests
{
    public class NoneTransformationTests
    {
        [Fact]
        public void Should_ReturnTheSameText()
        {
            //Arrange
            const string text = "text";
            var sut = new NoneTransformation();

            //Act
            var transformedText = sut.Transform(text);

            //Assert
            transformedText.Should().Be(text);
        }
    }
}
