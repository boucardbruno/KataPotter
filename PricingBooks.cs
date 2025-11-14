using System.Collections.Generic;
using System.Linq;

namespace PotterTest;

public static class PricingBooks
{
    public static double Price(List<int> shoppingBasket, Dictionary<int, double> bookDiscounts, double bookPrice)
    {
        return shoppingBasket.ComputeBestPrice(bookDiscounts, bookPrice);
    }

    private static double ComputeBestPrice(this List<int> shoppingBasket,
        IReadOnlyDictionary<int, double> bookDiscounts, double bookPrice)
    {
        return bookDiscounts
            .Select(keyValuePair => PriceBooks(shoppingBasket, bookDiscounts, bookPrice, keyValuePair.Key))
            .Min();
    }

    private static double PriceBooks(List<int> shoppingBasket, IReadOnlyDictionary<int, double> bookDiscounts,
        double bookPrice, int pivot)
    {
        var groupsOfBooks = new List<List<int>>();
        shoppingBasket.ForEach(book => groupsOfBooks.InsertBook(book, pivot));
        return groupsOfBooks.Sum(books => books.Count * bookPrice * bookDiscounts[books.Count]);
    }

    private static void InsertBook(this List<List<int>> groupsOfBooks, int lookForThisBook, int optimumPivot)
    {
        var foundBooksWithoutThisBook = groupsOfBooks.LookForBooksWithoutThisBook(lookForThisBook, optimumPivot);

        if (foundBooksWithoutThisBook.Any())
            foundBooksWithoutThisBook.Add(lookForThisBook);
        else
            groupsOfBooks.Add([lookForThisBook]);
    }

    private static List<int> LookForBooksWithoutThisBook(this List<List<int>> groupsOfBooks, int searchThisBook,
        int optimumPivot)
    {
        foreach (var currentBooks in groupsOfBooks)
            if (!currentBooks.Contains(searchThisBook) && currentBooks.Count < optimumPivot)
                return currentBooks;
        return [];
        
    }
}