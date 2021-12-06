#nullable enable

using System.Text.Json;

namespace FileConverter.Lib.Json
{
    public class JsonString : ISingleElementParse
    {
        public void Parse(JsonElement element, string? label, ref Dom.Dom dom)
        {
            dom.Add(label, element.GetString());
        }
    }
}