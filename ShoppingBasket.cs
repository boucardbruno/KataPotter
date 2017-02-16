using System.Collections.Generic;

namespace PotterTest
{
    public class ShoppingBasket
    {
        private List<int> Basket { get; } = new List<int>();
        private const double UnitBookPrice = 8.0;

        private static readonly Dictionary<string, int> BookNamesToBookIds = new Dictionary<string, int>
        {
            ["Harry Potter and the Philosopher's Stone"] = 1,
            ["Harry Potter and the Chamber of Secrets"] = 2,
            ["Harry Potter and the Prisoner of Azkaban"] = 3,
            ["Harry Potter and the Goblet of Fire"] = 4,
            ["Harry Potter and the Order of the Phoenix"] = 5
        };

        private Dictionary<int, double> BookDiscounts { get; } = new Dictionary<int, double>
        {
            [BookNamesToBookIds["Harry Potter and the Philosopher's Stone"]] = 1.0,
            [BookNamesToBookIds["Harry Potter and the Chamber of Secrets"]] = 0.95,
            [BookNamesToBookIds["Harry Potter and the Prisoner of Azkaban"]] = 0.90,
            [BookNamesToBookIds["Harry Potter and the Goblet of Fire"]] = 0.80,
            [BookNamesToBookIds["Harry Potter and the Order of the Phoenix"]] = 0.75
        };

        public void Add(string newBook)
        {
            Basket.Add(BookNamesToBookIds[newBook]);
        }

        public double Price()
        {
            return new Series().Price(Basket, BookDiscounts, UnitBookPrice);
        }
    }
}