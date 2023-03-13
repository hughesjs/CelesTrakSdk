using System.Reflection;
using System.Runtime.Serialization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CelesTrakSdk.Internal.Parsers;

public class StringEnumConverterWithAttributeSupport<TEnum>: EnumConverter where TEnum: struct, Enum
{
	public StringEnumConverterWithAttributeSupport() : base(typeof(TEnum)) { }

	public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
	{
		if (Enum.TryParse<TEnum>(text, true, out var value))
		{
			return value;
		}

		FieldInfo[] fieldInfos = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);

		FieldInfo? relevantMember = fieldInfos.SingleOrDefault(m => m.GetCustomAttribute<EnumMemberAttribute>()?.Value == text);

		if (relevantMember is not null)
		{
			return relevantMember.GetValue(null)!;
		}

		FieldInfo? defaultMember = fieldInfos.SingleOrDefault(m => m.GetCustomAttribute<EnumMemberAttribute>()?.Value == "Default");

		return defaultMember?.GetValue(null) ?? throw new($"Cannot convert {text} to {typeof(TEnum).Name}");
	}
}
