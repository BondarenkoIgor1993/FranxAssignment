using FluentAssertions;
using Franx.Assignment.Domain.Transformations;
using Xunit;

namespace Franx.Assignment.Application.UnitTests.TransformationsTests
{
    public class ReverseTransformationTests
    {
        [Fact]
        public void Should_ReturnReversedWordsOrder()
        {
            //Arrange
            const string text = "1 2 3";
            const string expectedText = "3 2 1";
            var sut = new ReverseTransformation();

            //Act
            var transformedText = sut.Transform(text);

            //Assert
            transformedText.Should().Be(expectedText);
        }
    }
}