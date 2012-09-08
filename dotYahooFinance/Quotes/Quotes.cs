using System.Net;

namespace Coirius.dotYahooFinance.Quotes
{
	/// <summary>
	/// Get quotes from Yahoo! Finance
	/// </summary>
	public class Quotes
	{
		private QuotesParameters _Paramenters;

		/// <summary>
		/// Default contructor
		/// </summary>
		/// <param name="parameters">Quotes parameters</param>
		public Quotes(QuotesParameters parameters)
		{
			_Paramenters = parameters;
		}

		/// <summary>
		/// Download result from Yahoo! Finance
		/// </summary>
		/// <returns>Result as string</returns>
		public string Download()
		{
			return new WebClient().DownloadString(_Paramenters.GetUrl());
		}
	}
}
