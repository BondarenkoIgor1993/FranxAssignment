using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Franx.Assignment.Domain.Helpers;
using Franx.Assignment.Domain.Transformations;
using Xunit;

namespace Franx.Assignment.Application.UnitTests.TransformationsTests
{
    public class DeduplicateTransformationTests
    {
        [Fact]
        public void Should_ReturnTextWithoutDuplicates_If_TextContainsDuplicates()
        {
            //Arrange
            const string text = "1 1 2 2 3";
            var uniqueWords = new HashSet<string> {"1", "2", "3"};
            var sut = new DeduplicateTransformation();

            //Act
            var transformedText = sut.Transform(text);

            //Assert
            TextShouldConsistOnlyOfGivenUniqueWords(transformedText, uniqueWords);
        }

        [Fact]
        public void Should_ReturnTheSameWords_If_TextDoesNotContainDuplicates()
        {
            //Arrange
            const string text = "1 2 3";
            var uniqueWords = new HashSet<string> { "1", "2", "3" };
            var sut = new DeduplicateTransformation();

            //Act
            var transformedText = sut.Transform(text);

            //Assert
            TextShouldConsistOnlyOfGivenUniqueWords(transformedText, uniqueWords);
        }

        private void TextShouldConsistOnlyOfGivenUniqueWords(string text, HashSet<string> uniqueWords)
        {
            var wordsFrequencyDictionary = MapTextToWordFrequenciesDictionary(text);
            wordsFrequencyDictionary
                .Where(x=> uniqueWords.Contains(x.Key))
                .Sum(x=>x.Value)
                .Should()
                .Be(uniqueWords.Count);
        }

        private static IDictionary<string, int> MapTextToWordFrequenciesDictionary(string transformedText)
        {
            var words = transformedText.SplitToWords();

            var wordFrequencies = new Dictionary<string, int>();

            foreach (var word in words)
                if (wordFrequencies.ContainsKey(word))
                {
                    wordFrequencies[word]++;
                }
                else
                {
                    wordFrequencies.Add(word, 1);
                }

            return wordFrequencies;
        }
    }
}