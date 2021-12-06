#nullable enable

using System;
using System.Text.Json;

namespace FileConverter.Lib.Json
{
    public class JsonConverter : FileConverter //TODO Реализовать парсинг корневого массива элементов
    {


        public JsonConverter() : base()
        {
        }

        public override void OnParse(string str)
        {
            using var doc = JsonDocument.Parse(str);
            var root = doc.RootElement;

            GetTypeJsonElement(root, null);
        }

        private void GetTypeJsonElement(JsonElement element, string? name)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Array:
                    JsonElementArrayParse(element, name);
                    break;
                case JsonValueKind.Object:
                    JsonElementObjectParse(element, name);
                    break;
                case JsonValueKind.Number:
                    JsonElementParse(element, name, new JsonNumber());
                    break;
                case JsonValueKind.String:
                    JsonElementParse(element, name, new JsonString());
                    break;
                case JsonValueKind.False:
                    break;
                case JsonValueKind.True:
                    break;
                case JsonValueKind.Null:
                    break;
                case JsonValueKind.Undefined:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void JsonElementParse(JsonElement element, string? name, ISingleElementParse jsonParse)
        {
            jsonParse.Parse(element, name, ref dom);
        }

        private void JsonElementArrayParse(JsonElement element, string? name)
        {
            var list = element.EnumerateArray();

            name ??= "element";
            var index = 1;
            foreach (var item in list)
            {
                GetTypeJsonElement(item, $"{name}_{index.ToString()}");
                ++index;
            }
        }

        private void JsonElementObjectParse(JsonElement element, string? name)
        {
            var objects = element.EnumerateObject();
            foreach (var item in objects)
            {
                GetTypeJsonElement(item.Value, item.Name);
            }
        }
    }
}