using System.Globalization;
using CelesTrakSdk.Internal.Extensions;
using CelesTrakSdk.Public.Models;
using CsvHelper;

namespace CelesTrakSdk.Internal.Parsers;

internal static class SatCatParser
{
	public static async Task<List<SatCatRecord>> Parse(Stream csvStream)
	{
		using StreamReader reader = new(csvStream);
		using CsvReader    csv    = new(reader, CultureInfo.InvariantCulture);
		
		return await csv.GetRecordsAsync<SatCatRecord>().ToListAsync();
	}
}
