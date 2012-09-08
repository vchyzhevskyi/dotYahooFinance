using System;
using Coirius.dotYahooFinance.Quotes;
using Coirius.dotYahooFinance.HistoricalQuotes;

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
			Console.ReadKey();
		}
	}
}
