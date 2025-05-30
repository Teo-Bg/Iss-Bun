using LRSprojectISS.domain;
using LRSprojectISS.repository.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.service
{
    internal class BookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public Book GetBookById(long id)
        {
            var book = _bookRepo.FindOne(id);
            if (book == null)
                throw new Exception("Book not found");

            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepo.FindAll();
        }

        public IEnumerable<Book> SearchBooks(int pageNumber, int pageSize, string? title = null, string? author = null, Genre? genre = null)
        {
            return _bookRepo.SearchBooks(pageNumber, pageSize, title, author, genre);
        }
    }
}
