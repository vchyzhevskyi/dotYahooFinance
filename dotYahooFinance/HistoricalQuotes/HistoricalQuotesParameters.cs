using System;
using VChyzhevskyi.dotYahooFinance.Base;

namespace VChyzhevskyi.dotYahooFinance.HistoricalQuotes
{
	public class HistoricalQuotesParameters : AbstractQuotesParameters
	{
		/// <summary>
		/// ID
		/// </summary>
		public string ID { get; private set; }
		/// <summary>
		/// From
		/// </summary>
		public DateTime FromDate { get; private set; }
		/// <summary>
		/// To
		/// </summary>
		public DateTime ToDate { get; private set; }
		/// <summary>
		/// Interval
		/// </summary>
		public HistoricalQuotesInterval Interval { get; private set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		public HistoricalQuotesParameters()
		{
			ID = string.Empty;
			FromDate = DateTime.Today;
			ToDate = DateTime.Today;
			Interval = HistoricalQuotesInterval.d;
		}

		/// <summary>
		/// Parameterized constructor
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="from">From date</param>
		/// <param name="to">To date</param>
		/// <param name="interval">Interval</param>
		public HistoricalQuotesParameters(string id, DateTime from, DateTime to, HistoricalQuotesInterval interval)
		{
			ID = id;
			FromDate = from;
			ToDate = to;
			Interval = interval;
		}

		/// <summary>
		/// Set ID for request
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>Parameters</returns>
		public HistoricalQuotesParameters WithID(string id)
		{
			ID = id;
			return this;
		}

		/// <summary>
		/// Set From date for request
		/// </summary>
		/// <param name="from">Date</param>
		/// <returns>Parameters</returns>
		public HistoricalQuotesParameters WithFromDate(DateTime from)
		{
			FromDate = from;
			return this;
		}

		/// <summary>
		/// Set To date for request
		/// </summary>
		/// <param name="to">Date</param>
		/// <returns>Parameters</returns>
		public HistoricalQuotesParameters WithToDate(DateTime to)
		{
			ToDate = to;
			return this;
		}

		/// <summary>
		/// Set interval for request
		/// </summary>
		/// <param name="interval">Interval</param>
		/// <returns>Parameters</returns>
		public HistoricalQuotesParameters WithInterval(HistoricalQuotesInterval interval)
		{
			Interval = interval;
			return this;
		}

		/// <summary>
		/// Get request url
		/// </summary>
		/// <returns>Url</returns>
		internal override string GetUrl()
		{
			string url = "http://ichart.yahoo.com/table.csv?s=";
			url = (ID.Length > 0 && url.Length > 0) ? string.Format("{0}{1}", url, ID) : "";
			url = (url.Length > 0) ? string.Format("{0}&a={1}&b={2}&c={3}", url, FromDate.Month - 1, FromDate.Day, FromDate.Year) : "";
			url = (url.Length > 0) ? string.Format("{0}&d={1}&e={2}&f={3}", url, ToDate.Month - 1, ToDate.Day, ToDate.Year) : "";
			url = (url.Length > 0) ? string.Format("{0}&g={1}", url, Interval) : "";
			url = (url.Length > 0) ? string.Format("{0}&ignore=csv", url) : "";
			if (url.Length <= 0)
				throw new NullReferenceException("Url is empty");
			return url;
		}
	}
}
