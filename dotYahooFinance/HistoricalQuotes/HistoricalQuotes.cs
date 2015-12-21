using System.Net;

namespace VChyzhevskyi.dotYahooFinance.HistoricalQuotes
{
	/// <summary>
	/// Get historical quotes from Yahoo! Finace
	/// </summary>
	public class HistoricalQuotes
	{
		private HistoricalQuotesParameters _Parameters;

		/// <summary>
		/// Parameterized constructor
		/// </summary>
		/// <param name="parameters">Parameters</param>
		public HistoricalQuotes(HistoricalQuotesParameters parameters)
		{
			_Parameters = parameters;
		}

		/// <summary>
		/// Download result from Yahoo! Finance
		/// </summary>
		/// <returns>Result as string</returns>
		public string Download()
		{
			return new WebClient().DownloadString(_Parameters.GetUrl());
		}
	}
}
