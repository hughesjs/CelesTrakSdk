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
										 OrbitCentre    = OrbitCentre.Earth,
										 OrbitType      = OrbitType.Orbit
									 };

		SatCatRecord? zarya = await _client.GetRecord(SatCatRecordQueryType.Name, "ZARYA");

		zarya.ShouldNotBeNull();

		// Testing individual properties because orbit properties change over time
		zarya.ObjectName.ShouldBe(zaryaExpected.ObjectName);
		zarya.ObjectId.ShouldBe(zaryaExpected.ObjectId);
		zarya.NoradCatId.ShouldBe(zaryaExpected.NoradCatId);
		zarya.ObjectType.ShouldBe(zaryaExpected.ObjectType);
		zarya.OpsStatusCode.ShouldBe(zaryaExpected.OpsStatusCode);
		zarya.Owner.ShouldBe(zaryaExpected.Owner);
		zarya.LaunchDate.ShouldBe(zaryaExpected.LaunchDate);
		zarya.LaunchSite.ShouldBe(zaryaExpected.LaunchSite);
		zarya.DecayDate.ShouldBe(zaryaExpected.DecayDate);
		zarya.DataStatusCode.ShouldBe(zaryaExpected.DataStatusCode);
		zarya.OrbitCentre.ShouldBe(zaryaExpected.OrbitCentre);
		zarya.OrbitType.ShouldBe(zaryaExpected.OrbitType);

		// These should do until the ISS is deorbited
		(zarya.Period      - zaryaExpected.Period)?.ShouldBeLessThan(5.0);
		(zarya.Inclination - zaryaExpected.Inclination)?.ShouldBeLessThan(5.0);
		(zarya.Apogee      - zaryaExpected.Apogee)?.ShouldBeLessThan(5);
		(zarya.Perigee     - zaryaExpected.Perigee)?.ShouldBeLessThan(5);
		(zarya.Rcs         - zaryaExpected.Rcs)?.ShouldBeLessThan(5.0);
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
