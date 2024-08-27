using System.Collections.Generic;
using System.Linq;

namespace PotterTest;

public static class Series
{
    public static double Price(List<int> shoppingBasket, Dictionary<int, double> bookDiscounts, double bookPrice)
    {
        return shoppingBasket.ComputeBestPrice(bookDiscounts, bookPrice);
    }

    private static double ComputeBestPrice(this List<int> shoppingBasket,
        IReadOnlyDictionary<int, double> bookDiscounts, double bookPrice)
    {
        return bookDiscounts
            .Select(keyValuePair => PriceSeries(shoppingBasket, bookDiscounts, bookPrice, keyValuePair.Key)).Min();
    }

    private static double PriceSeries(List<int> shoppingBasket, IReadOnlyDictionary<int, double> bookDiscounts,
        double bookPrice, int pivot)
    {
        var series = new List<List<int>>();
        shoppingBasket.ForEach(book => series.InsertBook(book, pivot));
        return series.Sum(books => books.Count * bookPrice * bookDiscounts[books.Count]);
    }

    private static void InsertBook(this ICollection<List<int>> series, int searchBookId, int optimumPivot)
    {
        var foundBooksWithoutThisBook = series.LookForBooksWithoutThisBook(searchBookId, optimumPivot);

        if (foundBooksWithoutThisBook.Any())
            // We added the book founded to the right books series.
            foundBooksWithoutThisBook.Add(searchBookId);
        else
            series.Add([searchBookId]);
    }

    private static List<int> LookForBooksWithoutThisBook(this IEnumerable<List<int>> series, int searchBookId,
        int optimumPivot)
    {
        foreach (var currentBooks in series)
            if (!currentBooks.Contains(searchBookId) && currentBooks.Count < optimumPivot)
                return currentBooks;
        return [];
    }
}