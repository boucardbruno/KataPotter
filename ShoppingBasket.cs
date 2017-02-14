using System.Collections.Generic;

namespace PotterTest
{
    public class ShoppingBasket
    {
        private readonly List<int> _basket = new List<int>();
        private const int OptimumPivot = 4;
        private const double BookPrice = 8.0;

        private readonly Dictionary<int, double> _discounts = new Dictionary<int, double>
        {
            [1] = 1.0,
            [2] = 0.95,
            [3] = 0.90,
            [4] = 0.80,
            [5] = 0.75
        };

        private readonly Dictionary<string, int> _bookNamesToIds = new Dictionary<string, int>
        {
            ["first"] = 1,
            ["second"] = 2,
            ["third"] = 3,
            ["fourth"] = 4,
            ["fifth"] = 5
        };
        public void Add(string newBook)
        {
            _basket.Add(_bookNamesToIds[newBook]);
        }

        public double Price()
        {
            return new Series(_basket, OptimumPivot).Price(_discounts, BookPrice);
        }
    }
}