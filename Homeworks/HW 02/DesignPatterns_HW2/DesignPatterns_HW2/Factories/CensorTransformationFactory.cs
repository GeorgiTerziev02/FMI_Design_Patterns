using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Factories
{
    public interface ICensorTransformationFactory
    {
        ITextTransformation Create(string toCensor);
    }

    public class CensorTransformationFactory : ICensorTransformationFactory
    {
        private readonly int MAX_CACHED_SIZE = 4;

        private readonly IDictionary<string, CensorTransformation> _cache
            = new Dictionary<string, CensorTransformation>();

        public ITextTransformation Create(string toCensor)
        {
            if(toCensor.Length > MAX_CACHED_SIZE)
            {
                return new CensorTransformation(toCensor);
            }

            if (!_cache.ContainsKey(toCensor))
            {
                _cache[toCensor] = new CensorTransformation(toCensor);
            }

            return _cache[toCensor];
        }
    }
}
