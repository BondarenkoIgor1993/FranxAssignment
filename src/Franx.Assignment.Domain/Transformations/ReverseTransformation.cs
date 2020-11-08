using System.Linq;
using Franx.Assignment.Domain.Helpers;

namespace Franx.Assignment.Domain.Transformations
{
    public class ReverseTransformation : ITransformation
    {
        public string Transform(string text)
        {
            return text.SplitToWords().Reverse().JoinIntoSentence();
        }
    }
}