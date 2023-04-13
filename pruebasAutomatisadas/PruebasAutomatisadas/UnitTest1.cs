namespace PruebasAutomatisadas
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var resutl = 55;
            Assert.AreEqual(resutl, 55);
        }
    }
}