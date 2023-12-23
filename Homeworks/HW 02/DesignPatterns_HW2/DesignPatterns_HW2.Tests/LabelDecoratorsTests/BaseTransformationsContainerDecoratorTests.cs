using DesignPatterns_HW2.LabelDecorators;
using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.Tests.LabelDecoratorsTests
{
    [TestFixture]
    public class BaseTransformationsContainerDecoratorTests
    {
        public class BaseTransformationsContainerDecoratorTestClass : BaseTransformationsContainerDecorator
        {
            public BaseTransformationsContainerDecoratorTestClass(
                ILabel label,
                IList<ITextTransformation> transformations
                ) : base(label, transformations)
            {
            }

            public IList<ITextTransformation> Transformations
            {
                get
                {
                    return this.transformations;
                }
            }
        }

        private readonly string LABEL_TEXT = " a ";
        private Label label;
        private IList<ITextTransformation> transformations;
        private BaseTransformationsContainerDecoratorTestClass transformationsContainerDecorator;

        [SetUp]
        public void SetUp()
        {
            transformations = new List<ITextTransformation>()
            {
                new TrimLeftTransformation(),
                new TrimRightTransformation()
            };
            label = new Label(LABEL_TEXT);
            transformationsContainerDecorator = new BaseTransformationsContainerDecoratorTestClass
            (
                label,
                transformations
            );
        }

        [Test]
        public void ConstructorShouldSetTransformations()
        {
            // Arrange
            // Act
            var actualTransformations = transformationsContainerDecorator.Transformations;

            // Assert
            Assert.That(actualTransformations, Is.EqualTo(transformations));
        }

        [Test]
        public void ConstructorShouldThrowWhenNullProvidedForTransformations()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(
                () => new BaseTransformationsContainerDecoratorTestClass(label, null)
            );
        }

        [Test]
        public void ConstructorShouldThrowWhenEmptyListProvidedForTransformations()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(
                () => new BaseTransformationsContainerDecoratorTestClass(label, new List<ITextTransformation>())
            );
        }

        [Test]
        public void EqualsShouldReturnTrueWhenOtherDecoratorHasSameTransformations()
        {
            // Arrange
            var otherDecorator = new BaseTransformationsContainerDecoratorTestClass(label, transformations);

            // Act
            var actual = transformationsContainerDecorator.Equals(otherDecorator);

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenOtherDecoratorHasDifferentTransformationsCount()
        {
            // Arrange
            var otherDecorator = new BaseTransformationsContainerDecoratorTestClass(label, new List<ITextTransformation>()
            {
                new TrimLeftTransformation()
            });

            // Act
            var actual = transformationsContainerDecorator.Equals(otherDecorator);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenOtherDecoratorHasDifferentTransformationsOrder()
        {
            // Arrange
            var otherDecorator = new BaseTransformationsContainerDecoratorTestClass(label, new List<ITextTransformation>()
            {
                new TrimRightTransformation(),
                new TrimLeftTransformation(),
            });

            // Act
            var actual = transformationsContainerDecorator.Equals(otherDecorator);

            // Assert
            Assert.That(actual, Is.False);
        }


        [Test]
        public void EqualsShouldReturnFalseWhenOtherObjectIsNull()
        {
            // Arrange
            // Act
            var actual = transformationsContainerDecorator.Equals(null);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenOtherObjectIsNotBaseTransformationsContainerDecorator()
        {
            // Arrange
            var otherObj = new object();

            // Act
            var actual = transformationsContainerDecorator.Equals(otherObj);

            // Assert
            Assert.That(actual, Is.False);
        }
    }
}
