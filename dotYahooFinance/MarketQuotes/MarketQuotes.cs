using System.Net;

namespace VChyzhevskyi.dotYahooFinance.MarketQuotes
{
	public class MarketQuotes
	{
		private MarketQuotesParameters _Parameters;

		public MarketQuotes(MarketQuotesParameters parameters)
		{
			_Parameters = parameters;
		}

		public string Download()
		{
			return new WebClient().DownloadString(_Parameters.GetUrl());
		}
	}
}
