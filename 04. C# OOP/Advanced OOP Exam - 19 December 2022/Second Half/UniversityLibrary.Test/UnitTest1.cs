using System.Collections.Generic;
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

        [Test]
        public void Test_SecondConstructorTest()
        {
            book.Holder = "Holder";
            library.AddTextBookToLibrary(book);

            Assert.That(book != null);
        }

        [Test]
        public void Test_TestIfTheHolderNameIsValid()
        {
            book.Holder = "Holder";
            library.AddTextBookToLibrary(book);

            Assert.That(book.Holder == "Holder");
        }

        [Test]
        public void Test_CatalogueTest()
        {
            book.Holder = "Holder";
            library.AddTextBookToLibrary(book);

            Assert.That(library.Catalogue != new List<TextBook>());
        }

        [Test]
        public void Test_IsTheToStringWorking()
        {
            book.Holder = "Holder";
            library.AddTextBookToLibrary(book);

            Assert.AreEqual($"Book: 1 - 1\r\nCategory: 3\r\nAuthor: 2", book.ToString());
        }
    }
}