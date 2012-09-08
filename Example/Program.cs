using System;
using Coirius.dotYahooFinance.HistoricalQuotes;
using Coirius.dotYahooFinance.MarketQuotes;
using Coirius.dotYahooFinance.Quotes;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(new Quotes(new QuotesParameters().WithID("GOOG").WithProperty(QuotesProperty.l1)).Download());
			Console.WriteLine(new HistoricalQuotes(
				new HistoricalQuotesParameters().WithID("GOOG").WithFromDate(DateTime.Today.AddDays(-1))
				.WithToDate(DateTime.Today.AddDays(-1))).Download());
			Console.WriteLine(new MarketQuotes(new MarketQuotesParameters().WithProperty(MarketQuotesProperty.coname)
				.WithSortDirection(MarketQuotesSortDirection.u).WithSector(MarketQuotesSector.Technology)).Download());
			Console.ReadKey();
		}
	}
}
