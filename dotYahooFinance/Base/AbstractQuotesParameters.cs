using System;

namespace Coirius.dotYahooFinance.Base
{
	internal abstract class AbstractQuotesParameters
	{
		internal abstract string GetUrl()
		{
			throw new NotImplementedException();
		}
	}
}
