using System.Net.Http.Json;
using CelesTrakSdk.Internal.Extensions;
using CelesTrakSdk.Internal.Parsers;
using CelesTrakSdk.Public.Clients;
using CelesTrakSdk.Public.Models;
using CelesTrakSdk.Public.Models.Enums;
using Microsoft.Extensions.Logging;

namespace CelesTrakSdk.Internal.Clients;

internal class CelesTrakClient: ICelesTrakClient
{
	private readonly HttpClient               _client;
	private readonly ILogger<CelesTrakClient> _logger;

	private const string FormatSlug    = "FORMAT=json";
	private const string QueryEndpointSlug = "satcat/records.php";
	private const string CsvEndpointSlug = "pub/satcat.csv";

	public CelesTrakClient(HttpClient client, ILogger<CelesTrakClient> logger)
	{
		_client      = client;
		_logger      = logger;
	}

	public async Task<SatCatRecord?> GetRecord(SatCatRecordQueryType queryType, string queryValue)
	{
		List<SatCatRecord> res = await GetRecords(queryType, queryValue);

		if (res.Count > 1)
		{
			_logger.LogInformation("Single item request returned {NumResults} results, discarding all but first", res.Count);
		}

		return res.SingleOrDefault();
	}

	public async Task<List<SatCatRecord>> GetRecords(SatCatRecordQueryType queryType, string queryValue)
	{
		string             query = $"{QueryEndpointSlug}?{queryType.GetEnumMemberValue()}={queryValue}&{FormatSlug}";
		List<SatCatRecord> res   = await _client.GetFromJsonAsync<List<SatCatRecord>>(query) ?? new();
		return res;
	}

	public async Task<List<SatCatRecord>> GetAllRecords()
	{
		Stream csvStream = await _client.GetStreamAsync(CsvEndpointSlug);
		return await SatCatParser.Parse(csvStream);
	}
}
