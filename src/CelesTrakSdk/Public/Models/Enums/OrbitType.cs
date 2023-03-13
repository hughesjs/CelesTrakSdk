using System.Runtime.Serialization;

namespace CelesTrakSdk.Public.Models.Enums;

public enum OrbitType
{
	[EnumMember(Value = "ORB")]
	Orbit,
	[EnumMember(Value = "LAN")]
	Landing,
	[EnumMember(Value = "IMP")]
	Impact,
	[EnumMember(Value = "DOC")]
	Docked,
	[EnumMember(Value = "R/T")]
	Roundtrip
}
