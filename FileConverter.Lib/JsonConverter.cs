#nullable enable

using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace FileConverter.Lib
{
    public class JsonConverter //TODO Реализовать парсинг корневого массива элементов
    {
        private Dictionary<string, string> _dom;

        public JsonConverter()
        {
            _dom = new Dictionary<string, string>();
        }
        
        public void OnParse(string str)
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
                    JsonElementNumberParse(element, name);
                    break;
                case JsonValueKind.String:
                    JsonElementStringParse(element, name);
                    break;
                case JsonValueKind.False:
                    break;
                case JsonValueKind.True:
                    break;
                case JsonValueKind.Null:
                    break;
                case JsonValueKind.Undefined:
                    break;
            }
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

        private void JsonElementNumberParse(JsonElement element, string? name)
        {
            var number = element.GetDecimal();
            _dom.Add(name, number.ToString(CultureInfo.InvariantCulture));
        }

        private void JsonElementStringParse(JsonElement element, string? name)
        {
            var str = element.GetString();
            _dom.Add(name, str);
        }

        public string[] DOMToString()
        {
            var result = new string[_dom.Count];

            var index = 0;
            foreach (var item in _dom)
            {
                result[index] = $"{item.Key} -> {item.Value}";
                ++index;
            }
            
            return result;
        }
    }
}