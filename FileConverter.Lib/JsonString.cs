#nullable enable

using System.Text.Json;

namespace FileConverter.Lib
{
    public class JsonString : ISingleElementParse
    {
        public void Parse(JsonElement element, string? label, ref Dom dom)
        {
            dom.Add(label, element.GetString());
        }
    }
}