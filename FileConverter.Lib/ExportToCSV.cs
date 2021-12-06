using System.Collections.Generic;

namespace FileConverter.Lib
{
    public class ExportToCsv : IExport
    {
        private readonly char _delimiter;

        public ExportToCsv(char delimiter) => _delimiter = delimiter;
        public string Export(Dictionary<string, string> dictionary)
        {
            var head = string.Empty;
            var str = string.Empty;
            foreach (var (key, value) in dictionary)
            {
                head += key + _delimiter;
                str += value + _delimiter;
            }

            return $"{head}\n{str}";
        }
    }
}