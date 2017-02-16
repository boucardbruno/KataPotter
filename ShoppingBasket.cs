using System.Collections.Generic;

namespace PotterTest
{
    public class ShoppingBasket
    {
        private List<int> Basket { get; } = new List<int>();
        private const int OptimumPivot = 4;
        private const double UnitBookPrice = 8.0;

        private static readonly Dictionary<string, int> BookNamesToBookIds = new Dictionary<string, int>
        {
            ["first"] = 1,
            ["second"] = 2,
            ["third"] = 3,
            ["fourth"] = 4,
            ["fifth"] = 5
        };

        private Dictionary<int, double> BookDiscounts { get; } = new Dictionary<int, double>
        {
            [BookNamesToBookIds["first"]] = 1.0,
            [BookNamesToBookIds["second"]] = 0.95,
            [BookNamesToBookIds["third"]] = 0.90,
            [BookNamesToBookIds["fourth"]] = 0.80,
            [BookNamesToBookIds["fifth"]] = 0.75
        };

        public void Add(string newBook)
        {
            Basket.Add(BookNamesToBookIds[newBook]);
        }

        public double Price()
        {
            return new Series(Basket, OptimumPivot).Price(BookDiscounts, UnitBookPrice);
        }
    }
}