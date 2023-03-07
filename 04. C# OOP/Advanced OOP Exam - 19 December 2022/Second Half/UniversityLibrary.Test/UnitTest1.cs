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
        public void Test_IsTheConstructorWorking()
        {
            Assert.AreEqual(0, library.Catalogue.Count);
        }

        [Test]
        public void Test_AreTextBooksAddedInLibrary()
        {
            library.AddTextBookToLibrary(book);
            Assert.AreEqual(1, library.Catalogue.Count);
        }

        [Test]
        public void Test_IsTheBookNotReturnedWhenUsingLoanBook()
        {
            book.Holder = "Holder";
            library.AddTextBookToLibrary(book);

            Assert.AreEqual($"Holder still hasn't returned 1!", library.LoanTextBook(1, "Holder"));
        }

        [Test]
        public void Test_IsTheBookLoanedWhenUsingLoanBook()
        {
            book.Holder = "Holder";
            library.AddTextBookToLibrary(book);

            Assert.AreEqual($"1 loaned to Misho.", library.LoanTextBook(1, "Misho"));
        }

        [Test]
        public void Test_IsTextBookReturnedProperly()
        {
            book.Holder = "Holder";
            library.AddTextBookToLibrary(book);

            Assert.AreEqual($"1 is returned to the library.", library.ReturnTextBook(1));
        }

        [Test]
        public void Test_IsTheHolderErasedWhenReturned()
        {
            book.Holder = "Holder";
            library.AddTextBookToLibrary(book);
            library.ReturnTextBook(1);

            Assert.AreEqual(string.Empty, book.Holder);
        }
    }
}