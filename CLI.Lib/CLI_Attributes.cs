using System;

namespace CLI.Lib
{
    public class CliAttributes
    {
        private string[] _attributes;

        public CliAttributes(string[] attributes)
        {
            _attributes = attributes;
        }

        public bool IsEmpty()
        {
            return _attributes.Length == 0;
        }

        private bool SearchKeyValue(string key, out string value)
        {
            for (int i = 0; i < _attributes.Length; i++)
            {
                if (_attributes[i] != key) continue;
                
                value = _attributes[i + 1];
                return true;
            }

            value = null;
            return false;
        }

        public bool InputKey(out string path)
        {
            return SearchKeyValue("-i", out path);
        }

        public bool OutputKey(out string path)
        {
            return SearchKeyValue("-o", out path);
        }

        public bool DelimiterKey(out char delimiter)
        {
            var res = SearchKeyValue("-s", out var d);
            delimiter = Convert.ToChar(d);
            return res;
        }
    }
}

