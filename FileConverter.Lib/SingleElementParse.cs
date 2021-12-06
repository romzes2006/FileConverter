#nullable enable

using System.Text.Json;

namespace FileConverter.Lib
{
    public interface ISingleElementParse
    {
        void Parse(JsonElement element, string? label, ref Dom dom);
    }
}