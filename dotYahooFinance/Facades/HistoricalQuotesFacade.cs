using System;
using System.Collections.Generic;
using System.Linq;
using VChyzhevskyi.dotYahooFinance.HistoricalQuotes;

namespace VChyzhevskyi.dotYahooFinance.Facades
{
    public class HistoricalQuotesFacade
    {
        private static readonly char[] ColumnSeparator;
        private static readonly string[] RowSeparator;

        static HistoricalQuotesFacade()
        {
            ColumnSeparator = new[] {','};
            RowSeparator = new[] {Environment.NewLine, "\n"};
        }

        public IEnumerable<HistoricalQuote> Get(HistoricalQuotesParameters @params)
        {
            IList<HistoricalQuote> result = new List<HistoricalQuote>();

            var data = new HistoricalQuotes.HistoricalQuotes(@params).Download();
            var dataSplited = data.Split(RowSeparator, StringSplitOptions.RemoveEmptyEntries);
            var dataHeaderSplited = dataSplited.First().Split(ColumnSeparator);
            foreach (var row in dataSplited.Skip(1))
            {
                var dataRowSplited = row.Split(ColumnSeparator);
                var quote = new HistoricalQuote();

                for (var i = 0; i < dataRowSplited.Length; i++)
                {
                    quote.SetPropertyValue(dataHeaderSplited[i], dataRowSplited[i]);
                }

                result.Add(quote);
            }

            return result;
        }
    }

    public class HistoricalQuote
    {
        public DateTime Date { get; set; }

        public decimal AdjClose { get; set; }

        public decimal Volume { get; set; }

        public decimal Close { get; set; }

        public decimal Low { get; set; }

        public decimal High { get; set; }

        public decimal Open { get; set; }

        internal void SetPropertyValue(string header, string value)
        {
            switch (header)
            {
                case "Date":
                    Date = DateTime.Parse(value);
                    break;
                case "Open":
                    Open = decimal.Parse(value);
                    break;
                case "High":
                    High = decimal.Parse(value);
                    break;
                case "Low":
                    Low = decimal.Parse(value);
                    break;
                case "Close":
                    Close = decimal.Parse(value);
                    break;
                case "Volume":
                    Volume = decimal.Parse(value);
                    break;
                case "Adj Close":
                    AdjClose = decimal.Parse(value);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return string.Join(" ", Date, Open, High, Low, Close, Volume, AdjClose);
        }
    }
}