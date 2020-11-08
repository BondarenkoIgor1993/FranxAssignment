using System.Collections.Generic;

namespace Franx.Assignment.Domain.Helpers
{
    public static class StringHelpers
    {
        private static readonly char Separator = ' ';

        public static string[] SplitToWords(this string text)
        {
            return text.Split(Separator);
        }

        public static string JoinIntoSentence(this IEnumerable<string> words)
        {
            return string.Join(Separator.ToString(), words);
        }
    }
}