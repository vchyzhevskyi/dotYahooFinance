using System;

namespace Coirius.dotYahooFinance.Quotes
{
	/// <summary>
	/// Quotes parameters
	/// </summary>
	public class QuotesParameters
	{
		/// <summary>
		/// Comma-separeted IDs
		/// </summary>
		public string IDs { get; private set; }
		/// <summary>
		/// Properties
		/// </summary>
		public string Properties { get; private set; }

		/// <summary>
		/// Default contructor
		/// </summary>
		public QuotesParameters()
		{
			IDs = string.Empty;
			Properties = string.Empty;
		}

		/// <summary>
		/// Initialize Quotes with specified IDs and properties
		/// </summary>
		/// <param name="ids">Comma-separated IDs</param>
		/// <param name="properties">Request properties</param>
		public QuotesParameters(string ids, string properties)
		{
			IDs = ids;
			Properties = properties;
		}

		/// <summary>
		/// Add ID to request
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>Parameters</returns>
		public QuotesParameters WithID(string id)
		{
			IDs = string.Format("{0},{1}", IDs, id);
			return this;
		}

		/// <summary>
		/// Add property to request
		/// </summary>
		/// <param name="property">Property</param>
		/// <returns>Parameters</returns>
		public QuotesParameters WithProperty(QuotesProperty property)
		{
			Properties = string.Format("{0}{1}", Properties, property);
			return this;
		}

		/// <summary>
		/// Get request url
		/// </summary>
		/// <returns>Url</returns>
		internal string GetUrl()
		{
			string url = "http://download.finance.yahoo.com/d/quotes.csv?s=";
			url = (IDs.Length > 0 && url.Length > 0) ? string.Format("{0}{1}", url, IDs) : "";
			url = (Properties.Length > 0 && url.Length > 0) ? string.Format("{0}&f={1}", url, Properties) : "";
			url = (url.Length > 0) ? string.Format("{0}&e={1}", url, "csv") : "";
			if (url.Length <= 0)
				throw new NullReferenceException("Url is empty");
			return url;
		}
	}
}
