using LRSprojectISS.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.repository.@interface
{
    internal interface IBookRepository : IRepository<long, Book>
    {
        IEnumerable<Book> SearchBooks(int pageNumber, int pageSize, string? title = null, string? author = null, Genre? genre = null);
    }
}
