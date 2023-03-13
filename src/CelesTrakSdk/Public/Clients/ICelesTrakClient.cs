using CelesTrakSdk.Public.Models;
using CelesTrakSdk.Public.Models.Enums;

namespace CelesTrakSdk.Public.Clients;

public interface ICelesTrakClient
{
	public Task<SatCatRecord?>      GetRecord(SatCatRecordQueryType  queryType, string queryValue);
	public Task<List<SatCatRecord>> GetRecords(SatCatRecordQueryType queryType, string queryValue);
	public Task<List<SatCatRecord>> GetAllRecords();
}
