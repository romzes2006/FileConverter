using System.Collections.Generic;

namespace FileConverter.Lib.Dom
{
    public class Dom
    {
        private readonly Dictionary<string, string> _dom;

        public Dom()
        {
            _dom = new Dictionary<string, string>();
        }

        public void Add(string key, string value)
        {
            _dom.Add(key, value);
        }

        public override string ToString()
        {
            return ToString(new ExportToCsv(';'));
        }
        public string ToString(IExport exportTo)
        {
            return exportTo.Export(_dom);
        }
    }
}