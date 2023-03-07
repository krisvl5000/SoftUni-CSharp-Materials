using System.Runtime.CompilerServices;

namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private UniversityLibrary library;
        private TextBook book;

        [SetUp]
        public void Setup()
        {
            library = new UniversityLibrary();
            book = new TextBook("1", "2", "3");
        }

        [Test]
        public void Test_TestingTheConstructor()
        {
            Assert.AreEqual(0, library.Catalogue.Count);
        }

        [Test]
        public void Test_AreTextBooksAddedInLibrary()
        {
            library.AddTextBookToLibrary(book);
            Assert.AreEqual(1, library.Catalogue.Count);
        }
    }
}