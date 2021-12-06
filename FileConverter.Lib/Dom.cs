using System.Collections.Generic;

namespace FileConverter.Lib
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

        public string ToString(IExport exportTo)
        {
            return exportTo.Export(_dom);
        }
    }
}