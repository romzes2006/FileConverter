#nullable enable

using System.Text.Json;

namespace FileConverter.Lib.Json
{
    public interface ISingleElementParse
    {
        void Parse(JsonElement element, string? label, ref Dom.Dom dom);
    }
}