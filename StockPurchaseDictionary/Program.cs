using System;
using System.Collections.Generic;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();

            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("GS", "Gamestop");
            stocks.Add("WM", "Waste Management");

            string GM = stocks["GM"];

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add((ticker: "GE", shares: 150, price: 23.21));
            purchases.Add((ticker: "GE", shares: 32, price: 17.87));
            purchases.Add((ticker: "GE", shares: 80, price: 19.02));
            purchases.Add((ticker: "CAT", shares: 150, price: 23.21));
            purchases.Add((ticker: "CAT", shares: 32, price: 17.87));
            purchases.Add((ticker: "CAT", shares: 80, price: 19.02));
            purchases.Add((ticker: "GS", shares: 150, price: 23.21));
            purchases.Add((ticker: "GS", shares: 32, price: 17.87));
            purchases.Add((ticker: "GS", shares: 80, price: 19.02));
            purchases.Add((ticker: "WM", shares: 150, price: 23.21));
            purchases.Add((ticker: "WM", shares: 32, price: 17.87));
            purchases.Add((ticker: "WM", shares: 80, price: 19.02));

            //Create a total ownership report that computes the total value of each stock that you have purchased.
            //This is the basic relational database join algorithm between two tables.

            // new dictionary to hold the ticker and value (share * price)

            Dictionary<string, double> ownershipReport = new Dictionary<string, double>();

            /*
             * Define a new Dictionary to hold the aggregated purchase information. - The key should be a string that is the full company name.
             * The value will be the valuation of each stock (price*amount) { "General Electric": 35900, "AAPL": 8445, ... }
            */
            // Iterate over the purchases and update the valuation for each stock
            foreach ((string ticker, int shares, double price) p in purchases)
            {
                var totalValue = p.shares * p.price;
                if (ownershipReport.ContainsKey(p.ticker))
                {
                    ownershipReport[p.ticker] += totalValue;
                    Console.WriteLine($"{p.ticker} {totalValue}");
                }
                else
                {
                    ownershipReport.Add(p.ticker, totalValue);
                    Console.WriteLine($"{p.ticker} {totalValue}");
                }
            }

            foreach (var instance in ownershipReport)
            {
                foreach (var stock in stocks)
                {
                    if (instance.Key == instance.Key)
                    {
                        Console.WriteLine($"{stock.Value}: {instance.Value}");
                    }
                }
            }
        }
    }
}
