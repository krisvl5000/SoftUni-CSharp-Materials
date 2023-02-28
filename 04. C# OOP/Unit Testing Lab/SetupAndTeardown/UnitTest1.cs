namespace SetupAndTeardown
{
    public class Tests
    {
        private int x = 0;

        [SetUp]
        public void Setup()
        {
            x = 55;
            // The Setup method is used to set up the data before every test, because 
            // without it every test will make changes to the value, therefore rendering
            // all other tests useless as well. It serves as a "checkpoint" from which
            // every test starts to make sure they are working separately and are 
            // independent from one another.
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(55, x);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(55, x);
        }

        [TearDown]
        public void CleanUp()
        {
            // This method is invoked after every test, and serves to clean up data
            // that has been altered from a test. It basically serves the same purpose
            // as the Setup method, but after the test, not before it.
        }
    }
}