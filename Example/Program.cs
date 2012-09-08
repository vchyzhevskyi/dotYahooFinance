using System;
using Coirius.dotYahooFinance.Quotes;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(new Quotes(new QuotesParameters().WithID("GOOG").WithProperty(QuotesProperty.l1)).Download());
			Console.ReadKey();
		}
	}
}
