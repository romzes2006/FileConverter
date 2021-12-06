using System.Collections.Generic;

namespace FileConverter.Lib.Dom
{
    public interface IExport
    {
        string Export(Dictionary<string, string> dictionary);
    }
}