using FluentAssertions;
using Franx.Assignment.Application.Services;
using Franx.Assignment.Domain.Factories;
using Franx.Assignment.Domain.Models;
using Xunit;

namespace Franx.Assignment.Application.UnitTests.ServiceTests
{
    public class TextServiceTests
    {
        [Theory]
        [InlineData(Transformation.None, "text text", "text text")]
        [InlineData(Transformation.Reverse, "1 1 2 2 3" , "3 2 2 1 1")]
        [InlineData(Transformation.Deduplicate, "1 1 1 1" , "1")]
        public void Should_TransformTextCorrect(Transformation transformation, string inputText, string expectedTransformedText)
        {
            //Arrange
            var transformationFactory = new TransformationFactory();
            var sut = new TextService(transformationFactory);

            //Act
            var transformedText = sut.TransformText(transformation, inputText);

            //Assert
            transformedText.Should().Be(expectedTransformedText);
        }


        [Fact]
        public void Should_ReturnTrimmedInputText()
        {
            //Arrange
            const string textSurroundedByWhiteSpaces = "     text      ";
            const string expectedText = "text";
            var transformationFactory = new TransformationFactory();
            var sut = new TextService(transformationFactory);

            //Act
            var transformedText = sut.TransformText(Transformation.None, textSurroundedByWhiteSpaces);

            //Assert
            transformedText.Should().Be(expectedText);
        }

        [Fact]
        public void Should_ReturnEmptyString_If_TextIsNull()
        {
            //Arrange
            const string nullText = null;
            const string expectedText = "";
            var transformationFactory = new TransformationFactory();
            var sut = new TextService(transformationFactory);

            //Act
            var transformedText = sut.TransformText(Transformation.None, nullText);

            //Assert
            transformedText.Should().Be(expectedText);
        }

        [Fact]
        public void Should_ReturnEmptyString_If_TextIsEmpty()
        {
            //Arrange
            const string emptyText = "";
            const string expectedText = "";
            var transformationFactory = new TransformationFactory();
            var sut = new TextService(transformationFactory);

            //Act
            var transformedText = sut.TransformText(Transformation.None, emptyText);

            //Assert
            transformedText.Should().Be(expectedText);
        }
    }
}