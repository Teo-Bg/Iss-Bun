using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.domain
{
    internal static class Cart
    {
        private static readonly List<Rental> _rentals = new();

        public static void AddToCart(Rental rental)
        {
            if (!_rentals.Any(r => r._book.Id == rental._book.Id))
                _rentals.Add(rental);
        }

        public static void RemoveFromCart(long bookId)
        {
            _rentals.RemoveAll(r => r._book.Id == bookId);
        }

        public static bool IsInCart(long bookId)
        {
            return _rentals.Any(r => r._book.Id == bookId);
        }

        public static List<Rental> GetAllRentals()
        {
            return _rentals.ToList();
        }

        public static void ClearCart()
        {
            _rentals.Clear();
        }
    }
}
