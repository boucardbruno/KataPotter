using System;
using System.Collections.Generic;

namespace PotterTest
{
    public class ShoppingBasket
    {
        private readonly List<int> _basket = new List<int>();
        private const int OptimumPivot = 4;
        private readonly Dictionary<int, double> _discounts = new Dictionary<int, double>
        {
            [1] = 0,
            [2] = 0.05,
            [3] = 0.10,
            [4] = 0.20,
            [5] = 0.25
        };

        public void Add(int newBook)
        {
            _basket.Add(newBook);
        }

        public double Price()
        {
            return new Series(_basket, _discounts, OptimumPivot).Price();
        }
    }
}