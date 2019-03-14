using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("SNE", "Sony");
            stocks.Add("MSFT", "Microsoft");
            stocks.Add("LEGO", "Lego");

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add((ticker: "GM", shares: 150, price: 23.21));
            purchases.Add((ticker: "GM", shares: 23, price: 19.20));
            purchases.Add((ticker: "CAT", shares: 32, price: 17.87));
            purchases.Add((ticker: "CAT", shares: 64, price: 18.04));
            purchases.Add((ticker: "SNE", shares: 80, price: 19.02));
            purchases.Add((ticker: "SNE", shares: 23, price: 19.08));
            purchases.Add((ticker: "SNE", shares: 45, price: 18.22));
            purchases.Add((ticker: "MSFT", shares: 20, price: 35.02));
            purchases.Add((ticker: "MSFT", shares: 3, price: 33.52));
            purchases.Add((ticker: "LEGO", shares: 13, price: 15.02));

            Dictionary<string, double> ownershipReport = new Dictionary<string, double>();

            //1. What we are joining is a list of purchases to a dictionary stocks
            //2. On the variable outside of the .Join, we define Key as being from the KVP above
            //3. We 'join it' at the ticker, thus y.ticker
            //4. We instantiate a new IEnumberable as defined below
            var smashedData = stocks
                .Join(purchases, 
                    x => x.Key,
                    y => y.ticker,
                    (x, y) => new { Ticker = x.Value, Quantity = y.shares, Price = y.price});


            foreach (var stock in smashedData)
            {
                //If the ownsershipReport already contains the key for particular stock...
                if (ownershipReport.ContainsKey(stock.Ticker))
                //Update the total overall value for that stock in the ownershipReport
                {
                    ownershipReport[stock.Ticker] = ownershipReport[stock.Ticker] + (stock.Quantity * stock.Price);
                }
                else
                //Otherwise, just add the key to the report, and set its value
                {
                    ownershipReport.Add(stock.Ticker, (stock.Quantity * stock.Price));
                }
            }

            Console.ReadKey();
        }
    }
}