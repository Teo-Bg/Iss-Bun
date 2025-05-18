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
    internal class RentalRepository : IRentalRepository
    {
        private string _connectionString;
        public RentalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Rental? FindOne(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                SELECT r.*, m.Id AS MemberId, m.Cnp, m.Name, m.Address, m.Phone,
                       b.Id AS BookId, b.Title, b.Author, b.PublishDate, b.Description, b.NrPages, b.Genres, b.Copies
                FROM Rentals r
                JOIN Members m ON r.MemberId = m.Id
                JOIN Books b ON r.BookId = b.Id
                WHERE r.Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToRental(reader);
                        }
                    }
                }
            }

            return null;
        }

        public IEnumerable<Rental> FindAll()
        {
            List<Rental> rentals = new List<Rental>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                SELECT r.*, m.Id AS MemberId, m.Cnp, m.Name, m.Address, m.Phone,
                       b.Id AS BookId, b.Title, b.Author, b.PublishDate, b.Description, b.NrPages, b.Genres, b.Copies
                FROM Rentals r
                JOIN Members m ON r.MemberId = m.Id
                JOIN Books b ON r.BookId = b.Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentals.Add(MapReaderToRental(reader));
                        }
                    }
                }
            }

            return rentals;
        }

        public IEnumerable<Rental> FindAllByMemberId(long memberId)
        {
            List<Rental> rentals = new List<Rental>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                SELECT r.*, m.Id AS MemberId, m.Cnp, m.Name, m.Address, m.Phone,
                       b.Id AS BookId, b.Title, b.Author, b.PublishDate, b.Description, b.NrPages, b.Genres, b.Copies
                FROM Rentals r
                JOIN Members m ON r.MemberId = m.Id
                JOIN Books b ON r.BookId = b.Id
                WHERE r.MemberId = @MemberId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentals.Add(MapReaderToRental(reader));
                        }
                    }
                }
            }

            return rentals;
        }

        public void SaveRental(long memberId, long bookId, DateTime dueDate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            INSERT INTO Rentals (MemberId, BookId, RentDate, DueDate, ReturnDate)
            VALUES (@MemberId, @BookId, GETDATE(), @DueDate, NULL)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@DueDate", dueDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Rental> Search(
    long memberId,
    int pageNumber,
    int pageSize,
    string? title = null,
    string? author = null,
    RentalStatus? status = null,
    Genre? genre = null)
        {
            List<Rental> rentals = new List<Rental>();
            int offset = (pageNumber - 1) * pageSize;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                List<string> conditions = new List<string>
        {
            "r.MemberId = @MemberId"
        };

                if (!string.IsNullOrEmpty(title))
                    conditions.Add("b.Title LIKE @Title");

                if (!string.IsNullOrEmpty(author))
                    conditions.Add("b.Author LIKE @Author");

                if (status.HasValue)
                {
                    switch (status.Value)
                    {
                        case RentalStatus.Pending:
                            conditions.Add("r.ReturnDate IS NULL AND GETDATE() <= r.DueDate");
                            break;
                        case RentalStatus.Overdue:
                            conditions.Add("r.ReturnDate IS NULL AND GETDATE() > r.DueDate");
                            break;
                        case RentalStatus.Returned:
                            conditions.Add("r.ReturnDate IS NOT NULL");
                            break;
                    }
                }

                if (genre.HasValue)
                    conditions.Add("(b.Genres & @Genre) = @Genre");

                string whereClause = string.Join(" AND ", conditions);

                string query = $@"
            SELECT r.*, 
                   m.Id AS MemberId, m.Cnp, m.Name, m.Address, m.Phone,
                   b.Id AS BookId, b.Title, b.Author, b.PublishDate, b.Description, b.NrPages, b.Genres, b.Copies
            FROM Rentals r
            JOIN Members m ON r.MemberId = m.Id
            JOIN Books b ON r.BookId = b.Id
            WHERE {whereClause}
            ORDER BY r.Id
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    if (!string.IsNullOrEmpty(title))
                        command.Parameters.AddWithValue("@Title", $"%{title}%");

                    if (!string.IsNullOrEmpty(author))
                        command.Parameters.AddWithValue("@Author", $"%{author}%");

                    if (genre.HasValue)
                        command.Parameters.AddWithValue("@Genre", (int)genre.Value);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentals.Add(MapReaderToRental(reader));
                        }
                    }
                }
            }

            return rentals;
        }

        public int GetActiveRentalCountForBook(long bookId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Rentals 
            WHERE BookId = @BookId AND ReturnDate IS NULL";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private Rental MapReaderToRental(SqlDataReader reader)
        {
            
            long memberId = Convert.ToInt64(reader["MemberId"]);
            long cnp = Convert.ToInt64(reader["Cnp"]);
            string name = reader["Name"].ToString();
            string address = reader["Address"].ToString();
            long phone = Convert.ToInt64(reader["Phone"]);

            Member member = new Member(cnp, name, address, phone) { Id = memberId };

            
            long bookId = Convert.ToInt64(reader["BookId"]);
            string title = reader["Title"].ToString();
            string author = reader["Author"].ToString();
            DateTime publishDate = Convert.ToDateTime(reader["PublishDate"]);
            string description = reader["Description"].ToString();
            int nrPages = Convert.ToInt32(reader["NrPages"]);
            Genre genres = (Genre)Convert.ToInt32(reader["Genres"]);
            int nrCopies = Convert.ToInt32(reader["Copies"]);

            Book book = new Book(title, author, publishDate, description, nrPages, genres, nrCopies) { Id = bookId };

            
            DateTime rentDate = Convert.ToDateTime(reader["RentDate"]);
            DateTime dueDate = Convert.ToDateTime(reader["DueDate"]);
            DateTime? returnDate = reader["ReturnDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["ReturnDate"]);

            Rental rental = new Rental(member, book, rentDate, dueDate, returnDate)
            {
                Id = Convert.ToInt64(reader["Id"])
            };

            return rental;
        }
    }
}