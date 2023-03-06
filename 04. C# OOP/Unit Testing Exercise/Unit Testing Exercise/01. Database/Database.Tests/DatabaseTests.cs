namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase(new int[]{ })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void ConstructorShouldInitializeDataWithCorrectCount(int[] data)
        {
            // Arrange

            // Act
            Database  db = new Database(data);

            // Assert
            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
        public void ConstructorShouldThrowExceptionWhenInputDataIsAbove16Count(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);
            }, "Array's capacity must be exactly 16 integers!");
        }

    }
}
