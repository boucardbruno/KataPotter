using System.Collections.Generic;
using System.Linq;

namespace PotterTest
{
    public static class Series
    {
        public static double Price(List<int> shoppingBasket, Dictionary<int, double> bookDiscounts, double bookPrice)
        {
            return ComputeBestPrice(shoppingBasket, bookDiscounts, bookPrice);
        }

        private static double ComputeBestPrice(List<int> shoppingBasket, IReadOnlyDictionary<int, double> bookDiscounts, double bookPrice)
        {
            return bookDiscounts.Select(v => PriceSeries(shoppingBasket, bookDiscounts, bookPrice, v.Key)).Min();
        }

        private static double PriceSeries(List<int> shoppingBasket, IReadOnlyDictionary<int, double> bookDiscounts, double bookPrice, int pivot)
        {
            var series = new List<List<int>>();
            shoppingBasket.ForEach(book => InsertBook(book, series, pivot));
            return series.Sum(books => books.Count * bookPrice * bookDiscounts[books.Count]);
        }

        private static void InsertBook(int searchBookId, ICollection<List<int>> series, int optimumPivot)
        {
            var foundBooks = LookForBooksWithoutThisBook(series, searchBookId, optimumPivot);

            if (foundBooks.Any())
            {
                foundBooks.Add(searchBookId);
            }
            else
            {
                series.Add(new List<int> {searchBookId});
            }
        }

        private static List<int> LookForBooksWithoutThisBook(IEnumerable<List<int>> series, int searchBookId, int optimumPivot)
        {
            foreach (var currentBooks in series)
            {
                if (!currentBooks.Contains(searchBookId) && currentBooks.Count < optimumPivot)
                {
                    return currentBooks;
                }
            }
            return new List<int>();
        }
    }
}