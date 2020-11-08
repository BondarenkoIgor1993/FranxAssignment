using Franx.Assignment.Domain.Factories;
using Franx.Assignment.Domain.Models;

namespace Franx.Assignment.Application.Services
{
    public class TextService : ITextService
    {
        private readonly ITransformationFactory _transformationFactory;

        public TextService(ITransformationFactory transformationFactory)
        {
            _transformationFactory = transformationFactory;
        }

        public string TransformText(Transformation transformation, string sentence)
        {
            sentence = SanitizeText(sentence);

            if (string.IsNullOrEmpty(sentence))
            {
                return string.Empty;
            }

            return _transformationFactory.Create(transformation).Transform(sentence);
        }

        private static string SanitizeText(string text)
        {
            return text?.Trim();
        }
    }
}