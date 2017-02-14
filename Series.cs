using System.Collections.Generic;
using System.Linq;

namespace PotterTest
{
    public class Series
    {
        private readonly int _optimumPivot;
        private readonly List<List<int>>  _series = new List<List<int>>();
        private readonly Dictionary<int, double> _discounts;

        public Series(IEnumerable<int> basket, Dictionary<int, double> discounts, int optimumPivot)
        {
            _optimumPivot = optimumPivot;
            _discounts = discounts;

            foreach (var book in basket)
            {
                InsertBook(book);
            }
        }

        public double Price()
        {
            double totalPrice = 0.0;
            foreach (var serie in _series)
            {
                var price = PricePerSerie(serie);
                totalPrice += ApplyDiscountPerSerie(price, serie);
            }
            return totalPrice;
        }

        private double ApplyDiscountPerSerie(double price, IEnumerable<int> serie)
        {
            return price - price * _discounts[serie.Count()];
        }

        private static double PricePerSerie(IReadOnlyCollection<int> serie)
        {
            return serie.Count * 8.0;
        }

        private void InsertBook(int book)
        {
            if (!InsertInExistingSerie(book)) _series.Add(new List<int> { book });
        }

        private bool InsertInExistingSerie(int book)
        {
            foreach (var serie in _series)
            {
                if (!serie.Contains(book) && serie.Count < _optimumPivot)
                {
                    serie.Add(book);
                    return true;
                }
            }
            return false;
        }
    }
}