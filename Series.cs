using System.Collections.Generic;
using System.Linq;

namespace PotterTest
{
    public class Series
    {
        public double Price(List<int> shoppingBasket, Dictionary<int, double> bookDiscounts, double bookPrice)
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
            return series.Sum(serie => serie.Count * bookPrice * bookDiscounts[serie.Count]);
        }

        private static void InsertBook(int searchBookId, ICollection<List<int>> series, int optimumPivot)
        {
            var foundSerie = LookForSerieWithoutThisBook(series, searchBookId, optimumPivot);

            if (foundSerie.Any())
            {
                foundSerie.Add(searchBookId);
            }
            else
            {
                series.Add(new List<int> {searchBookId});
            }
        }

        private static List<int> LookForSerieWithoutThisBook(IEnumerable<List<int>> series, int searchBookId, int optimumPivot)
        {
            foreach (var currentSerie in series)
            {
                if (!currentSerie.Contains(searchBookId) && currentSerie.Count < optimumPivot)
                {
                    return currentSerie;
                }
            }
            return new List<int>();
        }
    }
}