using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Factories
{
    // TODO: singleton?
    public class CensorTransformationFactory
    {
        // TODO: ImmutableDictionary
        private readonly IDictionary<string, CensorTransformation> _cache
            = new Dictionary<string, CensorTransformation>();

        ITextTransformation Create(string toCensor)
        {
            if (!_cache.ContainsKey(toCensor))
            {
                _cache[toCensor] = new CensorTransformation(toCensor);
            }

            return _cache[toCensor];
        }
    }
}
