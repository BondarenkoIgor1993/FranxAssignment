using Franx.Assignment.Domain.Models;
using Franx.Assignment.Domain.Transformations;

namespace Franx.Assignment.Domain.Factories
{
    public interface ITransformationFactory
    {
        ITransformation Create(Transformation transformation);
    }
}
