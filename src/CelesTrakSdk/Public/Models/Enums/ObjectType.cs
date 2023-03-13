using System.Runtime.Serialization;

namespace CelesTrakSdk.Public.Models.Enums;

public enum ObjectType
{
	[EnumMember(Value = "PAY")]
	Payload,
	[EnumMember(Value = "R/B")]
	RocketBody,
	[EnumMember(Value = "DEB")]
	Debris,
	[EnumMember(Value = "UNK")]
	Unknown
}
