using LRSprojectISS.domain;
using LRSprojectISS.repository.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.service
{
    internal class RentalService
    {
        private readonly IRentalRepository _rentalRepo;

        public RentalService(IRentalRepository rentalRepo)
        {
            _rentalRepo = rentalRepo;
        }

        public Rental GetRentalById(long id)
        {
            var rental = _rentalRepo.FindOne(id);
            if (rental == null)
                throw new Exception($"No rental found with ID {id}.");

            return rental;
        }

        public IEnumerable<Rental> GetAllRentals()
        {
            return _rentalRepo.FindAll();
        }

        public IEnumerable<Rental> GetRentalsForMember(long memberId)
        {
            return _rentalRepo.FindAllByMemberId(memberId);
        }

        public void RentBook(long memberId, Book book, DateTime dueDate)
        {
            int activeRentals = _rentalRepo.GetActiveRentalCountForBook(book.Id);
            if (activeRentals >= book._copies)
                throw new Exception("No available copies for this book.");

            _rentalRepo.SaveRental(memberId, book.Id, dueDate);
        }

        public IEnumerable<Rental> SearchRentals(
            long memberId,
            int pageNumber,
            int pageSize,
            string? title = null,
            string? author = null,
            RentalStatus? status = null,
            Genre? genre = null)
        {
            return _rentalRepo.Search(memberId, pageNumber, pageSize, title, author, status, genre);
        }

        public int GetActiveRentalCountForBook(long bookId)
        {
            return _rentalRepo.GetActiveRentalCountForBook(bookId);
        }
    }
}
