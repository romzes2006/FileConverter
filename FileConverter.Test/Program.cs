using System;
using System.IO;
using FileConverter.Lib;

namespace FileConverter.Test
{
    class Program
    {
        static void Main()
        {
            using var file = new StreamReader("test.json");
            var str = file.ReadToEnd();

            var json = new JsonConverter();
            json.OnParse(str);

            var temp = json.DOMToString();
            foreach (var s in temp)
            {
                Console.WriteLine(s);
            }
        }
    }
}