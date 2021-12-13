using System;
using System.IO;
using CLI.Lib;
using FileConverter.Lib.Dom;
using FileConverter.Lib.Json;

namespace FileConverter.Test
{
    static class Program
    {
        static void Main(string[] args)
        {
            var attributes = new CliAttributes(args);

            if (attributes.IsEmpty())
            {
                Console.WriteLine("Нет аргументов!");
                return;
            }
            
            var input = attributes.InputKey(out var pathSource) ? pathSource : throw new Exception();
            var output = attributes.OutputKey(out var pathDist) ? pathDist : "output.csv";
            var delimiter = attributes.DelimiterKey(out var d) ? d : ';';
            
            using var file = new StreamReader(input);
            var str = file.ReadToEnd();

            var json = new JsonConverter();
            json.OnParse(str);

            var temp = json.dom.ToString(new ExportToCsv(delimiter));
            Console.WriteLine(temp);
            
            Console.WriteLine(json.dom.ToString());
        }
    }
}