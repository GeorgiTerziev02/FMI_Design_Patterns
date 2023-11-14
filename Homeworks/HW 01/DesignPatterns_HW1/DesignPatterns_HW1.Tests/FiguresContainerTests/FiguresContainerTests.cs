using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Figures;
using System.Text;

namespace DesignPatterns_HW1.Tests.FiguresContainerTests
{
    [TestFixture]
    public class FiguresContainerTests
    {
        private const int CONTAINER_SIZE = 5;

        [Test]
        public void ConstructorShouldExectuteSuccessfully()
        {
            // Arrange
            // Act
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);
            // Assert
            Assert.That(figuresContainer, Is.Not.Null);
        }

        [Test]
        public void ConstructorShouldThrowIfCountIsNegative()
        {
            // Arrange
            var negativeCount = -1;
            // Act
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => new FiguresContainer.FiguresContainer(negativeCount));
            Assert.That(ex.Message, Is.EqualTo(ErrorMessages.INVALID_COUNT));
        }

        [Test]
        public void CountShouldReturnCorrectCount()
        {
            // Arrange
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);
            var figure = new Circle(1);

            // Act
            figuresContainer.Add(figure);
            var actualCount = figuresContainer.Count;

            // Assert
            Assert.That(actualCount, Is.EqualTo(1));
        }

        [Test]
        public void AddShouldAddCorrectly()
        {
            // arrange
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);
            var expectedFigure1 = new Circle(1);
            var expectedFigure2 = new Circle(2);

            // act
            figuresContainer.Add(expectedFigure1);
            figuresContainer.Add(expectedFigure2);
            var actualFigure1 = figuresContainer[0];
            var actualFigure2 = figuresContainer[1];

            // assert
            Assert.That(actualFigure1, Is.EqualTo(expectedFigure1));
            Assert.That(actualFigure2, Is.EqualTo(expectedFigure2));
        }

        [Test]
        public void IndexAccessShouldReturnCorrectly()
        {
            // actually tests the same thing
            this.AddShouldAddCorrectly();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(2)]
        public void IndexShouldThrowIfInvalidIndex(int index)
        {
            // arrange
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);

            // act
            // assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => { var test = figuresContainer[index]; });
            Assert.That(ex.ParamName, Is.EqualTo(ErrorMessages.INVALID_INDEX));
        }

        [Test]
        public void ListShouldConstructCorrectString()
        {
            // arrange
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);
            var figure = new Circle(1.5);
            var figure2 = new Rectangle(1, 5);
            figuresContainer.Add(figure);
            figuresContainer.Add(figure2);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(figure.ToString()).AppendLine(figure2.ToString());
            var expectedString = sb.ToString();

            // act
            var actualString = figuresContainer.List();

            // assert
            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        public void RemoveShouldRemoveCorrectly()
        {
            // arrange
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);
            var figure = new Circle(1.5);
            var figure2 = new Rectangle(1, 5);
            figuresContainer.Add(figure);
            figuresContainer.Add(figure2);
            var expectedCount = 1;

            // act
            figuresContainer.RemoveAt(0);
            var actualFigure = figuresContainer[0];
            var actualCount = figuresContainer.Count;

            // assert
            Assert.That(actualFigure, Is.EqualTo(figure2));
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveShouldThrowIfInvalidIndex()
        {
            // arrange
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);
            var figure = new Circle(1.5);
            var figure2 = new Rectangle(1, 5);
            figuresContainer.Add(figure);
            figuresContainer.Add(figure2);

            // act
            // assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => figuresContainer.RemoveAt(2));
            Assert.That(ex.ParamName, Is.EqualTo(ErrorMessages.INVALID_INDEX));
        }

        [Test]
        public void DuplicateShouldDuplicateCorrectly()
        {
            // arrange
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);
            var figure = new Circle(1.5);
            var figure2 = new Rectangle(1, 5);
            figuresContainer.Add(figure);
            figuresContainer.Add(figure2);
            var expectedCount = 3;

            // act
            figuresContainer.DuplicateAt(0);
            var actualFigure = figuresContainer[1];
            var actualCount = figuresContainer.Count;

            // assert
            Assert.That(actualFigure, Is.EqualTo(figure));
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void DuplicateShouldThrowIfInvalidIndex()
        {
            // arrange
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);
            var figure = new Circle(1.5);
            var figure2 = new Rectangle(1, 5);
            figuresContainer.Add(figure);
            figuresContainer.Add(figure2);

            // act
            // assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => figuresContainer.DuplicateAt(2));
            Assert.That(ex.ParamName, Is.EqualTo(ErrorMessages.INVALID_INDEX));
        }

        [Test]
        public void WriteToStreamShouldWriteCorrectly()
        {
            // arrange
            var figuresContainer = new FiguresContainer.FiguresContainer(CONTAINER_SIZE);
            using var stream = new MemoryStream();
            var figure = new Circle(1);
            var expectedResult = figure.ToString();

            // act
            figuresContainer.Add(figure);
            figuresContainer.WriteToStream(stream);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(stream);
            var result = reader.ReadLine();

            // assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
