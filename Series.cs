using System.Collections.Generic;
using System.Linq;

namespace PotterTest
{
    public class Series
    {
        private int OptimumPivot { get; }
        private IList<List<int>> PoolSeries { get; } = new List<List<int>>();
        private static readonly List<int> EmptySerie = new List<int>();

        public Series(List<int> shoppingBasket, int optimumPivot)
        {
            OptimumPivot = optimumPivot;

            shoppingBasket.ForEach(InsertBook);
        }

        public double Price(Dictionary<int, double> bookDiscounts, double bookPrice)
        {
            return PoolSeries.Sum(serie => serie.Count * bookPrice * bookDiscounts[serie.Count]);
        }

        private void InsertBook(int newBookId)
        {
            var foundSerie = LookForExistingSerie(newBookId);

            if (foundSerie.Any())
            {
                foundSerie.Add(newBookId);
            }
            else
            {
                PoolSeries.Add(new List<int> {newBookId});
            }
        }

        private List<int> LookForExistingSerie(int newBookId)
        {
            foreach (var currentSerie in PoolSeries)
            {
                if (!currentSerie.Contains(newBookId) && currentSerie.Count < OptimumPivot)
                {
                    return currentSerie;
                }
            }
            return EmptySerie;
        }
    }
}