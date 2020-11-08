using System.Linq;
using Franx.Assignment.Domain.Helpers;

namespace Franx.Assignment.Domain.Transformations
{
    public class DeduplicateTransformation : ITransformation
    {
        public string Transform(string text)
        {
            return text.SplitToWords().Distinct().JoinIntoSentence();
        }
    }
}