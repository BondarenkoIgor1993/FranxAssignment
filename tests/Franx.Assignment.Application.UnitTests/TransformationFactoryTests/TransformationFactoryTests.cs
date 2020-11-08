using System;
using FluentAssertions;
using Franx.Assignment.Domain.Factories;
using Franx.Assignment.Domain.Models;
using Franx.Assignment.Domain.Transformations;
using Xunit;

namespace Franx.Assignment.Application.UnitTests.TransformationFactoryTests
{
    public class TransformationFactoryTests
    {
        [Theory]
        [InlineData(Transformation.None, typeof(NoneTransformation))]
        [InlineData(Transformation.Reverse, typeof(ReverseTransformation))]
        [InlineData(Transformation.Deduplicate, typeof(DeduplicateTransformation))]
        public void Should_ReturnCorrectTransformation(Transformation transformation, Type expectedType)
        {
            //Arrange
            var sut = new TransformationFactory();

            //Act
            var createdTransformation = sut.Create(transformation);

            //Assert
            createdTransformation.Should().BeOfType(expectedType);
        }

        [Fact]
        public void Should_ThrowException_If_InvalidTransformation()
        {
            //Arrange
            const Transformation invalidTransformation = (Transformation)Int32.MaxValue;
            var sut = new TransformationFactory();

            //Act
            Func<ITransformation> act  = () => sut.Create(invalidTransformation);

            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
