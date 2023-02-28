namespace Unit_Testing_Tests
{
    public class FirstTest
    {
        [Test]
        public void Test()
        {
            int result = 1 + 6;

            Assert.AreEqual(7, result);
        }

        [Test]
        public void Test2()
        {
            int result = 1 + 6;

            Assert.AreEqual(7, result);
        }
    }
}