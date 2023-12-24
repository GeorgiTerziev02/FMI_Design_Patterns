using DesignPatterns_HW2.LabelDecorators;
using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Tests.Mocks;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.LabelDecoratorsTests
{
    [TestFixture]
    public class CyclingTransformationsDecoratorTests
    {
        private CyclingTransformationsDecorator cyclingTransformationsDecorator;

        [SetUp]
        public void SetUp()
        {
            cyclingTransformationsDecorator = new CyclingTransformationsDecorator(new Label("a"), new List<ITextTransformation>()
            {
                new FirstTransformationMock(),
                new SecondTransformationMock()
            });
        }

        [Test]
        public void GetTextShouldApplyCyclingTransformations()
        {
            // Assert
            Assert.That(cyclingTransformationsDecorator.GetText(), Is.EqualTo("First a"));
            Assert.That(cyclingTransformationsDecorator.GetText(), Is.EqualTo("Second a"));
            Assert.That(cyclingTransformationsDecorator.GetText(), Is.EqualTo("First a"));
        }
    }
}
