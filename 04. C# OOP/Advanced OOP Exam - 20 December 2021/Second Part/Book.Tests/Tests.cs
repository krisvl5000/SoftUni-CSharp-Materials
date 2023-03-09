using NUnit.Framework.Constraints;

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

        [Test]
        public void Test_IsAddFootNoteWorkingProperly()
        {
            book.AddFootnote(5, "Test");

            Assert.That(book.FootnoteCount == 1);
        }

        [Test]
        public void Test_IsAddFootNoteThrowingWhenAddingTheSameNumber()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(5, "Test");
                book.AddFootnote(5, "Test2");
            });
        }

        [Test]
        public void Test_IsBookNameValidationThrowingWithEmptyName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var newBook = new Book("", "SomeAuthor");
            });
        }

        [Test]
        public void Test_IsAuthorNameValidationThrowingWithEmptyName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var newBook = new Book("SomeName", "");
            });
        }

        [Test]
        public void Test_IsFindFootNoteWorkingProperly()
        {
            book.AddFootnote(1, "SomeFootNote");

            Assert.That(book.FindFootnote(1) == $"Footnote #1: SomeFootNote");
        }

        [Test]
        public void Test_IsFindFootNoteThrowingWhenSearchingInvalidNumber()
        {
            book.AddFootnote(1, "SomeFootNote");

            Assert.Throws<InvalidOperationException>(() =>
            {
                Assert.That(book.FindFootnote(3) == "Footnote doesn't exists!");
            });
        }

        [Test]
        public void Test_IsAlterFootNoteWorkingProperly()
        {
            book.AddFootnote(1, "SomeFootNote");
            book.AlterFootnote(1, "NewFootNote");

            Assert.That(book.FindFootnote(1) == $"Footnote #1: NewFootNote");
        }

        [Test]
        public void Test_IsAlterFootNoteThrowingWhenNonExistentNoteIsSearched()
        {
            book.AddFootnote(1, "SomeFootNote");
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(10, "NewFootNote");
            });
        }
    }
}