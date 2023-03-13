using System.Text.Json.Serialization;
using CelesTrakSdk.Internal.Parsers;
using CelesTrakSdk.Public.Models.Enums;
using CsvHelper.Configuration.Attributes;

namespace CelesTrakSdk.Public.Models;


//Note: NameAttribute, TypeConverter				-> CSV parsing for bulk download
//		JsonPropertyNameAttribute, JsonConverter	-> Json parsing for queries
public record SatCatRecord
{
	[JsonPropertyName("OBJECT_NAME")]
	[Name("OBJECT_NAME")]
	public required string ObjectName { get; init; }

	[JsonPropertyName("OBJECT_ID")]
	[Name("OBJECT_ID")]
	public required string ObjectId { get; init; }

	[JsonPropertyName("NORAD_CAT_ID")]
	[Name("NORAD_CAT_ID")]
	public required int NoradCatId { get; init; }

	[JsonPropertyName("OBJECT_TYPE")]
	[Name("OBJECT_TYPE")]
	public required string ObjectType { get; init; } //TODO Enumify this

	[JsonPropertyName("OPS_STATUS_CODE")]
	[Name("OPS_STATUS_CODE")]
	[JsonConverter(typeof(JsonStringEnumConverterWithAttributeSupport))]
	[TypeConverter(typeof(StringEnumConverterWithAttributeSupport<OpsStatus>))]
	public required OpsStatus OpsStatusCode { get; init; }

	[JsonPropertyName("OWNER")]
	[Name("OWNER")]
	public required string Owner { get; init; }

	[JsonPropertyName("LAUNCH_DATE")]
	[Name("LAUNCH_DATE")]
	public required DateOnly LaunchDate { get; init; }

	[JsonPropertyName("LAUNCH_SITE")]
	[Name("LAUNCH_SITE")]
	public required string LaunchSite { get; init; }

	[JsonPropertyName("DECAY_DATE")]
	[Name("DECAY_DATE")]
	[JsonConverter(typeof(NullableDateOnlyConverter))]
	public DateOnly? DecayDate { get; init; }

	[JsonPropertyName("PERIOD")]
	[Name("PERIOD")]
	public double? Period { get; init; }

	[JsonPropertyName("INCLINATION")]
	[Name("INCLINATION")]
	public double? Inclination { get; init; }

	[JsonPropertyName("APOGEE")]
	[Name("APOGEE")]
	public int? Apogee { get; init; }

	[JsonPropertyName("PERIGEE")]
	[Name("PERIGEE")]
	public int? Perigee { get; init; }

	[JsonPropertyName("RCS")]
	[Name("RCS")]
	public double? Rcs { get; init; }

	[JsonPropertyName("DATA_STATUS_CODE")]
	[Name("DATA_STATUS_CODE")]
	public required string DataStatusCode { get; init; }

	[JsonPropertyName("ORBIT_CENTER")]
	[Name("ORBIT_CENTER")]
	public required string OrbitCenter { get; init; }

	[JsonPropertyName("ORBIT_TYPE")]
	[Name("ORBIT_TYPE")]
	public required string OrbitType { get; init; }
}
