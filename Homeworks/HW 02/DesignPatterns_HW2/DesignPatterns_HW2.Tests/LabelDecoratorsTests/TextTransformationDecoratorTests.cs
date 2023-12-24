using DesignPatterns_HW2.LabelDecorators;
using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Tests.Mocks;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.LabelDecoratorsTests
{

    [TestFixture]
    public class TextTransformationDecoratorTests
    {
        private Label label;
        private ITextTransformation transformation;
        private TextTransformationDecorator decorator;

        [SetUp]
        public void SetUp()
        {
            label = new Label("text");
            transformation = new TransformationMock();
            decorator = new TextTransformationDecorator(label, transformation);
        }

        [Test]
        public void GetTextShouldApplyTransfomation()
        {
            // Assert
            Assert.That(decorator.GetText(), Is.EqualTo("Test text"));
        }

        [Test]
        public void EqualsShouldReturnTrueForDecoratorWithSameTransformation()
        {
            // Arrange
            var otherDecorator = new TextTransformationDecorator(null, transformation);

            // Act
            var result = decorator.Equals(otherDecorator);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void EqualsShouldReturnFalseForDecoratorWithDifferentTransformation()
        {
            // Arrange
            var otherDecorator = new TextTransformationDecorator(null, new TrimLeftTransformation());

            // Act
            var result = decorator.Equals(otherDecorator);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void EqualsShouldReturnFalseForNull()
        {
            // Arrange
            // Act
            var result = decorator.Equals(null);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void EqualsShouldReturnFalseForOtherObject()
        {
            // Arrange
            var other = new object();

            // Act
            var result = decorator.Equals(other);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
