using Franx.Assignment.Domain.Models;

namespace Franx.Assignment.Application.Services
{
    public interface ITextService
    {
        string TransformText(Transformation transformation, string sentence);
    }
}