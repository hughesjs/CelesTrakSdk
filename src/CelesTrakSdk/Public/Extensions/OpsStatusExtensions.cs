using CelesTrakSdk.Public.Models.Enums;

namespace CelesTrakSdk.Public.Extensions;

public static class OpsStatusExtensions
{
	public static bool IsActive(this OpsStatus status) => status is OpsStatus.Operational 
																 or OpsStatus.PartiallyOperational 
																 or OpsStatus.BackupStandby 
																 or OpsStatus.Spare 
																 or OpsStatus.ExtendedMission;
}
