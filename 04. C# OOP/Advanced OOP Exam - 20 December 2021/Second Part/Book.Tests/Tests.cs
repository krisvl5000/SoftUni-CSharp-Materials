namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            book = new Book("Name", "Author");
        }

        [Test]
        public void Test_IsConstructorWorkingProperly()
        {
            Assert.That(book.BookName == "Name" && book.Author == "Author");
        }
    }
}