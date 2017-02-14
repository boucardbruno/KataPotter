using System.Collections.Generic;
using System.Linq;

namespace PotterTest
{
    public class Series
    {
        private readonly int _optimumPivot;
        private readonly List<List<int>>  _series = new List<List<int>>();

        public Series(IEnumerable<int> basket, int optimumPivot)
        {
            _optimumPivot = optimumPivot;

            foreach (var book in basket)
            {
                InsertBook(book);
            }
        }

        public double Price(Dictionary<int, double> discounts, double bookPrice)
        {
            return _series.Sum(serie => ((IReadOnlyCollection<int>) serie).Count * bookPrice * discounts[serie.Count()]);
        }

        private void InsertBook(int newBook)
        {
            IList<int> serie;
            if ((serie = LookForExistingSerie(newBook)).Count > 0)
            {
                serie.Add(newBook);
            }
            else
            {
                _series.Add(new List<int> { newBook });
            }
        }

        private IList<int> LookForExistingSerie(int newBook)
        {
            foreach (var serie in _series)
            {
                if (!serie.Contains(newBook) && serie.Count < _optimumPivot)
                {
                    
                    return serie;
                }
            }
            return new List<int>();
        }
    }
}