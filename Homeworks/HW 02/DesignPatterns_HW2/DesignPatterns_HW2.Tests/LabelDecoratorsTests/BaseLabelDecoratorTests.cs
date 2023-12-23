using DesignPatterns_HW2.LabelDecorators;
using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Tests.LabelDecoratorsTests
{
    [TestFixture]
    public class BaseLabelDecoratorTests
    {
        // As an alternative to installing MOQ
        public class BaseLabelDecoratorTestClass : BaseLabelDecorator
        {
            private readonly string _decoration;
            private readonly bool _equals;

            public BaseLabelDecoratorTestClass(
                ILabel label,
                string decoration = "",
                bool equals = true
                ) : base(label)
            {
                _decoration = decoration;
                _equals = equals;
            }

            public override bool Equals(object? obj)
            {
                return _equals;
            }

            public override string GetText()
            {
                return _decoration + base.GetText();
            }
        }

        private readonly string LABEL_TEXT = "test";
        private Label label;
        private BaseLabelDecoratorTestClass baseLabelDecorator;

        [SetUp]
        public void SetUp()
        {
            label = new Label(LABEL_TEXT);
            baseLabelDecorator = new BaseLabelDecoratorTestClass(label, "1");
        }

        [Test]
        public void GetTextShouldReturnCorrectly()
        {
            // Arrange
            // Act
            var actualText = baseLabelDecorator.GetText();

            // Assert
            Assert.That(actualText, Is.EqualTo("1" + LABEL_TEXT));
        }

        [Test]
        public void RemoveDecoratorShouldRemoveLastDecorator()
        {
            // Arrange
            var decoratorToRemove = new BaseLabelDecoratorTestClass(null);
            var decorator = new BaseLabelDecoratorTestClass(baseLabelDecorator, "2");
            Assert.That(decorator.GetText(), Is.EqualTo("21" + LABEL_TEXT));

            // Act
            var afterDecoratorRemoved = decorator.RemoveDecorator(decoratorToRemove);
            
            // Assert
            if(afterDecoratorRemoved is BaseLabelDecorator d)
            {
                Assert.That(d, Is.SameAs(baseLabelDecorator));
                Assert.That(d.GetText(), Is.EqualTo("1" + LABEL_TEXT));
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void RemoveDecoratorShouldRemoveMiddleDecorator()
        {
            // Arrange
            var decoratorToRemove = new BaseLabelDecoratorTestClass(null);
            var decorator = new BaseLabelDecoratorTestClass(baseLabelDecorator, "2");
            decorator = new BaseLabelDecoratorTestClass(decorator, "3", false);
            Assert.That(decorator.GetText(), Is.EqualTo("321" + LABEL_TEXT));

            // Act
            var afterDecoratorRemoved = decorator.RemoveDecorator(decoratorToRemove);

            // Assert
            if (afterDecoratorRemoved is BaseLabelDecorator d)
            {
                Assert.That(d, Is.SameAs(decorator));
                Assert.That(d.GetText(), Is.EqualTo("31" + LABEL_TEXT));
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void RemoveDecoratorShouldReturnLabelWhenOnlyOneDecorator()
        {
            // Arrange
            // Act
            var afterDecoratorRemoved = baseLabelDecorator.RemoveDecorator(baseLabelDecorator);

            // Assert
            Assert.That(afterDecoratorRemoved, Is.SameAs(label));
            Assert.That(afterDecoratorRemoved.GetText(), Is.EqualTo(LABEL_TEXT));
        }

        [Test]
        public void StaticRemoveDecoratorFromShouldRemoveLastDecorator()
        {
            // Arrange
            var decoratorToRemove = new BaseLabelDecoratorTestClass(null);
            var decorator = new BaseLabelDecoratorTestClass(baseLabelDecorator, "2");
            Assert.That(decorator.GetText(), Is.EqualTo("21" + LABEL_TEXT));

            // Act
            var afterDecoratorRemoved = BaseLabelDecorator.RemoveDecoratorFrom(decorator, decoratorToRemove);

            // Assert
            if (afterDecoratorRemoved is BaseLabelDecorator d)
            {
                Assert.That(d, Is.SameAs(baseLabelDecorator));
                Assert.That(d.GetText(), Is.EqualTo("1" + LABEL_TEXT));
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void StaticRemoveDecoratorFromShouldReturnLabelIfNoDecorators()
        {
            // Arrange
            var decoratorToRemove = new BaseLabelDecoratorTestClass(null);

            // Act
            var afterDecoratorRemoved = BaseLabelDecorator.RemoveDecoratorFrom(label, decoratorToRemove);

            // Assert
            if (afterDecoratorRemoved is Label d)
            {
                Assert.That(d, Is.SameAs(label));
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void StaticRemoveDecoratorFromShouldThrowWhenLabelIsNull()
        {
            // Arrange
            var decoratorToRemove = new BaseLabelDecoratorTestClass(null);

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => BaseLabelDecorator.RemoveDecoratorFrom(null, decoratorToRemove));
        }

        [Test]
        public void StaticRemoveDecoratorFromShouldThrowWhenDecoratorToRemoveIsNull()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => BaseLabelDecorator.RemoveDecoratorFrom(label, null));
        }
    }
}
