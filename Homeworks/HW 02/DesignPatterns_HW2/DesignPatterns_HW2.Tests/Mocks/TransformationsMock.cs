using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.Mocks
{
    public class TransformationMock : ITextTransformation
    {
        public string Transform(string text) => "Test " + text;
    }

    public class FirstTransformationMock : ITextTransformation
    {
        public string Transform(string text) => "First " + text;
    }

    public class SecondTransformationMock : ITextTransformation
    {
        public string Transform(string text) => "Second " + text;
    }

}
