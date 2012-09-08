using System;
using Coirius.dotYahooFinance.Base;

namespace Coirius.dotYahooFinance.MarketQuotes
{
	public class MarketQuotesParameters : AbstractQuotesParameters
	{
		public int Sector { get; private set; }
		public MarketQuotesProperty Properties { get; private set; }
		public MarketQuotesSortDirection SortDirection { get; private set; }

		public MarketQuotesParameters()
		{
			Properties = MarketQuotesProperty.coname;
			SortDirection = MarketQuotesSortDirection.u;
			Sector = -1;
		}

		public MarketQuotesParameters(MarketQuotesProperty prop, MarketQuotesSortDirection sort)
		{
			Properties = prop;
			SortDirection = sort;
			Sector = -1;
		}

		public MarketQuotesParameters WithProperty(MarketQuotesProperty prop)
		{
			Properties = prop;
			return this;
		}

		public MarketQuotesParameters WithSortDirection(MarketQuotesSortDirection sort)
		{
			SortDirection = sort;
			return this;
		}

		public MarketQuotesParameters WithSector(int sector)
		{
			Sector = sector;
			return this;
		}

		internal override string GetUrl()
		{
			string url = "http://biz.yahoo.com/p/csv/";
			url = (Sector != -1) ? string.Format("{0}{1}", url, Sector) : string.Format("{0}s_", url);
			url = (url.Length > 0) ? string.Format("{0}{1}", url, Properties) : "";
			url = (url.Length > 0) ? string.Format("{0}{1}", url, SortDirection) : "";
			url = (url.Length > 0) ? string.Format("{0}.csv", url) : "";
			if (url.Length <= 0)
				throw new NullReferenceException("Url is empty");
			return url;
		}
	}
}
