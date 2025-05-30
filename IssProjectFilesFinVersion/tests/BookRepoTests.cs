using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using LRSprojectISS.domain;
using LRSprojectISS.repository;

namespace LRSprojectISS.tests
{
    public class BookRepoTests
    {
        private readonly string _connectionString = @"Server=TEOJR\SQLEXPRESS;Database=LibraryRentalSystem;Integrated Security=true;TrustServerCertificate=true";
        private readonly BookRepository _bookRepo;

        public BookRepoTests()
        {
            _bookRepo = new BookRepository(_connectionString);
        }

        [Fact]
        public void FindOne_ExistingBookId_ReturnsBook()
        {

            long bookId = 1;
            var book = _bookRepo.FindOne(bookId);
            Assert.NotNull(book);
            Assert.Equal(bookId, book.Id);
        }

        [Fact]
        public void FindOne_NonExistentId_ReturnsNull()
        {
            var book = _bookRepo.FindOne(-1);
            Assert.Null(book);
        }

        [Fact]
        public void FindAll_ReturnsAtLeastOneBook()
        {
            var books = _bookRepo.FindAll().ToList();
            Assert.NotEmpty(books);
        }

        [Fact]
        public void SearchBooks_ByTitle_ReturnsMatchingBooks()
        {
            var books = _bookRepo.SearchBooks(1, 10, title: "Book A").ToList();
            Assert.All(books, b => Assert.Contains("Book A", b._title, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void SearchBooks_ByAuthor_ReturnsMatchingBooks()
        {
            var books = _bookRepo.SearchBooks(1, 10, author: "Author A").ToList();
            Assert.All(books, b => Assert.Contains("Author A", b._author, StringComparison.OrdinalIgnoreCase));
        }


        [Fact]
        public void SearchBooks_WithPagination_DoesNotExceedPageSize()
        {
            int pageSize = 5;
            var books = _bookRepo.SearchBooks(1, pageSize).ToList();
            Assert.True(books.Count <= pageSize);
        }

        public void RunAllTestsManually()
        {
            FindOne_ExistingBookId_ReturnsBook();
            FindOne_NonExistentId_ReturnsNull();
            FindAll_ReturnsAtLeastOneBook();
            SearchBooks_ByTitle_ReturnsMatchingBooks();
            SearchBooks_ByAuthor_ReturnsMatchingBooks();
            SearchBooks_WithPagination_DoesNotExceedPageSize();

            Console.WriteLine("BookRepository tests were successfully.");
        }
    }
}
