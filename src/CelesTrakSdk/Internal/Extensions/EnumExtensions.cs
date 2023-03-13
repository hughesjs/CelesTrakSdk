using System.Reflection;
using System.Runtime.Serialization;

namespace CelesTrakSdk.Internal.Extensions;

internal static class EnumExtensions
{
	public static string GetEnumMemberValue(this Enum myEnum)
	{
		EnumMemberAttribute? enumMemberAttribute = myEnum.GetType().GetMember(myEnum.ToString()).Single().GetCustomAttribute<EnumMemberAttribute>();
		return enumMemberAttribute?.Value ?? myEnum.ToString();
	}
}

