#nullable enable

using System.Globalization;
using System.Text.Json;

namespace FileConverter.Lib
{
    public class JsonNumber : ISingleElementParse
    {
        public void Parse(JsonElement element, string? label, ref Dom dom)
        {
            dom.Add(label, element.GetDecimal().ToString(CultureInfo.InvariantCulture));
        }
    }
}