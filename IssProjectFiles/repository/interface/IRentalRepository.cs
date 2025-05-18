using LRSprojectISS.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.repository.@interface
{
    internal interface IRentalRepository : IRepository<long, Rental>
    {
        IEnumerable<Rental> FindAllByMemberId(long memberId);
        IEnumerable<Rental> Search(long memberId,int pageNumber,int pageSize,string? title = null,string? author = null,RentalStatus? status = null,Genre? genre = null);
        void SaveRental(long memberId, long bookId, DateTime dueDate);
        int GetActiveRentalCountForBook(long bookId);


    }
}
