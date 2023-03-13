using System.Reflection;
using System.Runtime.Serialization;

namespace CelesTrakSdk.Public.Models.Enums;

public enum OrbitCentre
{
	[EnumMember(Value = "AS")]
	Asteroid,
	[EnumMember(Value = "CO")]
	Comet,
	[EnumMember(Value = "EA")]
	Earth,
	[EnumMember(Value = "EL1")]
	EarthL1,
	[EnumMember(Value = "EL2")]
	EarthL2,
	[EnumMember(Value = "EM")]
	EarthMoonBarycenter,
	[EnumMember(Value = "JU")]
	Jupiter,
	[EnumMember(Value = "MA")]
	Mars,
	[EnumMember(Value = "ME")]
	Mercury,
	[EnumMember(Value = "MO")]
	Moon,
	[EnumMember(Value = "NE")]
	Neptune,
	[EnumMember(Value = "PL")]
	Pluto,
	[EnumMember(Value = "SA")]
	Saturn,
	[EnumMember(Value = "SS")]
	SolarSystemEscape,
	[EnumMember(Value = "SU")]
	Sun,
	[EnumMember(Value = "UR")]
	Uranus,
	[EnumMember(Value = "VE")]
	Venus,
	[EnumMember(Value = "Default")]
	Docked
}
