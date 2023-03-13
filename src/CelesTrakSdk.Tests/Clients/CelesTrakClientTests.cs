using CelesTrakSdk.Internal.Clients;
using CelesTrakSdk.Public.Clients;
using CelesTrakSdk.Public.Models;
using CelesTrakSdk.Public.Models.Enums;
using Microsoft.Extensions.Logging.Abstractions;
using Shouldly;
using Xunit;

namespace CelesTrakSdk.Tests.Clients;

public class CelesTrakClientTests
{
	private ICelesTrakClient _client;

	public CelesTrakClientTests()
	{
		// This could benefit from being mocked or this test *is* going to be flaky, but I'm a bit busy atm...
		HttpClient client = new() {BaseAddress = new("https://celestrak.org/")};
		_client = new CelesTrakClient(client, NullLogger<CelesTrakClient>.Instance);
	}

	[Fact]
	public async Task CanGetSatCatRecord()
	{
		SatCatRecord zaryaExpected = new()
									 {
										 ObjectName     = "ISS (ZARYA)",
										 ObjectId       = "1998-067A",
										 NoradCatId     = 25544,
										 ObjectType     = "PAY",
										 OpsStatusCode  = OpsStatus.Operational,
										 Owner          = "ISS",
										 LaunchDate     = DateOnly.Parse("1998-11-20"),
										 LaunchSite     = "TYMSC",
										 DecayDate      = null,
										 Period         = 92.95,
										 Inclination    = 51.64,
										 Apogee         = 423,
										 Perigee        = 415,
										 Rcs            = 399.0524,
										 DataStatusCode = string.Empty,
										 OrbitCenter    = "EA",
										 OrbitType      = OrbitType.Orbit
									 };
		
		SatCatRecord? zarya = await _client.GetRecord(SatCatRecordQueryType.Name, "ZARYA");

		zarya.ShouldNotBeNull();
		zarya.ShouldBe(zaryaExpected);
	}

	[Fact]
	public async Task CanGetSatCatGroup()
	{
		List<SatCatRecord> stations = await _client.GetRecords(SatCatRecordQueryType.Group, "STATIONS");
		
		stations.SingleOrDefault(s => s.ObjectName == "ISS (ZARYA)").ShouldNotBeNull();
		stations.SingleOrDefault(s => s.ObjectName == "CSS (MENGTIAN)").ShouldNotBeNull();
	}

	[Fact]
	public async Task CanGetAllSatCatRecords()
	{
		List<SatCatRecord> allSatCats = await _client.GetAllRecords();
		
		allSatCats.Find(s => s.ObjectId == "1997-067A").ShouldNotBeNull();
		allSatCats.Count.ShouldBeGreaterThan(7500);
	}
	
}
