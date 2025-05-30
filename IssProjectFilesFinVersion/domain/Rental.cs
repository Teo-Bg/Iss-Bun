using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.domain
{
    public enum RentalStatus
    {
        Pending,
        Returned,
        Overdue
    }

    internal class Rental : Entity<long>
    {
        public Member _member { get; set; }
        public Book _book { get; set; }
        public DateTime _rentDate { get; set; }
        public DateTime _dueDate { get; set; }
        public DateTime? _returnDate { get; set; }

        public Rental(Member member, Book book, DateTime rentDate, DateTime dueDate, DateTime? returnDate = null)
        {
            _member = member;
            _book = book;
            _rentDate = rentDate;
            _dueDate = dueDate;
            _returnDate = returnDate;
        }

        public RentalStatus _status
        {
            get
            {
                if (_returnDate == null)
                {
                    return DateTime.Now > _dueDate ? RentalStatus.Overdue : RentalStatus.Pending;
                }
                else
                {
                    return _returnDate > _dueDate ? RentalStatus.Overdue : RentalStatus.Returned;
                }
            }
        }
    }
}
