namespace Franx.Assignment.Domain.Transformations
{
    public class NoneTransformation : ITransformation
    {
        public string Transform(string text) => text;
    }
}