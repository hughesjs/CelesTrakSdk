using System.Runtime.Serialization;

namespace CelesTrakSdk.Public.Models.Enums;

public enum OpsStatus
{
	[EnumMember(Value = "+")]
	Operational,
	[EnumMember(Value = "-")]
	NonOperational,
	[EnumMember(Value = "P")]
	PartiallyOperational,
	[EnumMember(Value = "B")]
	BackupStandby,
	[EnumMember(Value = "S")]
	Spare,
	[EnumMember(Value = "X")]
	ExtendedMission,
	[EnumMember(Value = "D")]
	Decayed,
	[EnumMember(Value = "?")]
	Unknown,
	[EnumMember(Value = "")]
	NotApplicable
}
