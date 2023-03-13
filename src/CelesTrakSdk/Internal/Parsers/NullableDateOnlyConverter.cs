using System.Text.Json;
using System.Text.Json.Serialization;

namespace CelesTrakSdk.Internal.Parsers;

public class NullableDateOnlyConverter: JsonConverter<DateOnly?>
{

	public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Null)
		{
			return null;
		}
		
		if (reader.TokenType != JsonTokenType.String)
		{
			throw new JsonException($"Unexpected token type '{reader.TokenType}'");
		}

		string? val = reader.GetString();

		if (string.IsNullOrWhiteSpace(val))
		{
			return null;
		}

		return DateOnly.Parse(val);
	}

	public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
	{
		if (value.HasValue)
		{
			writer.WriteStringValue(value.Value.ToString());
		}
		else
		{
			writer.WriteNullValue();
		}
	}
}
