using System.Runtime.Serialization;

namespace CelesTrakSdk.Public.Models.Enums;

public enum SatCatRecordQueryType
{
	[EnumMember(Value = "CATNR")]
	CatalogNumber,
	[EnumMember(Value = "INTDES")]
	InternationalDesignator,
	[EnumMember(Value = "GROUP")]
	Group,
	[EnumMember(Value = "NAME")]
	Name,
	[EnumMember(Value = "SPECIAL")]
	Special
}
