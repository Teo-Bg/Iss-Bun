using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.domain
{
    internal class Book : Entity<long>
    {
        public string _title { get; set; }
        public string _author {  get; set; }
        public DateTime _publishDate { get; set; }
        public string _description { get; set; }
        public int _nrPages {  get; set; }
        public Genre _genres { get; set; }

        public int _copies { get; set; }

        public Book(string title, string author, DateTime publishDate, string description, int nrPages, Genre genres, int copies)
        {
            _title = title;
            _author = author;
            _publishDate = publishDate;
            _description = description;
            _nrPages = nrPages;
            _genres = genres;
            _copies = copies;
        }

    }
}
