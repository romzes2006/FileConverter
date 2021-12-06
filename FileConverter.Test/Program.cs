using System;
using System.IO;
using FileConverter.Lib.Dom;
using FileConverter.Lib.Json;

namespace FileConverter.Test
{
    static class Program
    {
        static void Main()
        {
            using var file = new StreamReader("test.json");
            var str = file.ReadToEnd();

            var json = new JsonConverter();
            json.OnParse(str);

            var temp = json.dom.ToString(new ExportToCsv('|'));
            Console.WriteLine(temp);
            
            Console.WriteLine(json.dom.ToString());
        }
    }
}