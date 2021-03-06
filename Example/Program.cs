﻿using System;
using VChyzhevskyi.dotYahooFinance.Facades;
using VChyzhevskyi.dotYahooFinance.HistoricalQuotes;
using VChyzhevskyi.dotYahooFinance.MarketQuotes;
using VChyzhevskyi.dotYahooFinance.Quotes;

namespace VChyzhevskyi.dotYahooFinance.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(
                new Quotes.Quotes(new QuotesParameters().WithID("GOOG").WithProperty(QuotesProperty.l1)).Download());
            Console.WriteLine(new HistoricalQuotes.HistoricalQuotes(
                new HistoricalQuotesParameters().WithID("GOOG").WithFromDate(DateTime.Today.AddDays(-1))
                    .WithToDate(DateTime.Today.AddDays(-1))).Download());
            Console.WriteLine(
                new MarketQuotes.MarketQuotes(new MarketQuotesParameters().WithProperty(MarketQuotesProperty.coname)
                    .WithSortDirection(MarketQuotesSortDirection.u).WithSector(MarketQuotesSector.Technology)).Download());

            var facade = new HistoricalQuotesFacade();
            var quotes = facade.Get(new HistoricalQuotesParameters()
                .WithID("GOOG")
                .WithFromDate(DateTime.Today.AddDays(-7))
                .WithToDate(DateTime.Today.AddDays(-1)));
            foreach (var quote in quotes)
            {
                Console.WriteLine(quote);
            }

            Console.ReadKey();
        }
    }
}