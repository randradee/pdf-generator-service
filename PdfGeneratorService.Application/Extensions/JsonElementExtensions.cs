using System.Text.Json;

namespace PdfGeneratorService.WebApi.Extensions;

public static class JsonElementExtensions
{
    public static Dictionary<string, object> ToDictionary(this JsonElement element)
    {
        var dict = new Dictionary<string, object>();
        foreach (var prop in element.EnumerateObject())
        {
            dict[prop.Name] = prop.Value.ValueKind switch
            {
                JsonValueKind.String => prop.Value.GetString() ?? "",
                JsonValueKind.Number => prop.Value.GetDouble(),
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                _ => prop.Value.GetRawText()
            };
        }
        return dict;
    }
}