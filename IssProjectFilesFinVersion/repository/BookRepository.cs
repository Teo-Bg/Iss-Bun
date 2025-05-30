using LRSprojectISS.domain;
using LRSprojectISS.repository.@interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Book? FindOne(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Books WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return MapReaderToBook(reader);
                    }
                }
            }

            return null;
        }

        public IEnumerable<Book> FindAll()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Books";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(MapReaderToBook(reader));
                        }
                    }
                }
            }

            return books;
        }

        public IEnumerable<Book> SearchBooks(
    int pageNumber,
    int pageSize,
    string? title = null,
    string? author = null,
    Genre? genre = null)
        {
            List<Book> books = new List<Book>();
            int offset = (pageNumber - 1) * pageSize;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(title))
                    conditions.Add("Title LIKE @Title");

                if (!string.IsNullOrEmpty(author))
                    conditions.Add("Author LIKE @Author");

                if (genre.HasValue)
                    conditions.Add("(Genres & @Genre) = @Genre");

                string whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";

                string query = $@"
            SELECT * FROM Books
            {whereClause}
            ORDER BY Id
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(title))
                        command.Parameters.AddWithValue("@Title", $"%{title}%");

                    if (!string.IsNullOrEmpty(author))
                        command.Parameters.AddWithValue("@Author", $"%{author}%");

                    if (genre.HasValue)
                        command.Parameters.AddWithValue("@Genre", (int)genre.Value);

                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(MapReaderToBook(reader));
                        }
                    }
                }
            }

            return books;
        }
        private Book MapReaderToBook(SqlDataReader reader)
        {
            string title = reader["Title"].ToString();
            string author = reader["Author"].ToString();
            DateTime publishDate = Convert.ToDateTime(reader["PublishDate"]);
            string description = reader["Description"].ToString();
            int nrPages = Convert.ToInt32(reader["NrPages"]);
            Genre genres = (Genre)Convert.ToInt32(reader["Genres"]);
            int copies = Convert.ToInt32(reader["Copies"]);

            Book book = new Book(title, author, publishDate, description, nrPages, genres, copies);
            book.Id = Convert.ToInt64(reader["Id"]);
            return book;
        }
    }
}
