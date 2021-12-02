using System;
using System.Text.Json;

namespace FileConverter.Lib
{
    public class JsonConverter
    {
        public void OnParse(string str)
        {
            using var doc = JsonDocument.Parse(str);
            var root = doc.RootElement;

            var elements = root.EnumerateArray();

            while (elements.MoveNext())
            {
                var element = elements.Current;
                Console.WriteLine(elements);

                var props = element.EnumerateObject();

                while (props.MoveNext())
                {
                    var prop = props.Current;
                    Console.WriteLine($"{prop.Name}: {prop.Value}");
                }
            }
        }
    }
}