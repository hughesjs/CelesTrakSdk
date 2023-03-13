using CelesTrakSdk.Public.Models;
using CelesTrakSdk.Public.Models.Enums;

namespace CelesTrakSdk.Internal.Extensions;

public static class OpsStatusExtensions
{
	public static bool IsActive(this OpsStatus status) => status is OpsStatus.Operational 
																 or OpsStatus.PartiallyOperational 
																 or OpsStatus.BackupStandby 
																 or OpsStatus.Spare 
																 or OpsStatus.ExtendedMission;
}
