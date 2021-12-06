using System.Collections.Generic;

namespace FileConverter.Lib
{
    public interface IExport
    {
        string Export(Dictionary<string, string> dictionary);
    }
}