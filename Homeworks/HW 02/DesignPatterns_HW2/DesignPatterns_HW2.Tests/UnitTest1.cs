using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ILabel label = new Label("Hello World!");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}