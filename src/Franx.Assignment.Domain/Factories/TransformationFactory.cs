using System;
using Franx.Assignment.Domain.Models;
using Franx.Assignment.Domain.Transformations;

namespace Franx.Assignment.Domain.Factories
{
    public class TransformationFactory: ITransformationFactory
    {
        public ITransformation Create(Transformation transformation)
        {
            switch (transformation)
            {
                case Transformation.None:
                    return new NoneTransformation();
                case Transformation.Reverse:
                    return new ReverseTransformation();
                case Transformation.Deduplicate:
                    return new DeduplicateTransformation();
                default:
                    throw new ArgumentOutOfRangeException(nameof(transformation), transformation, $"Can not find transformation {transformation}");
            }
        }
    }
}
