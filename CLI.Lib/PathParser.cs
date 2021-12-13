using System;
using System.IO;

namespace CLI.Lib
{
    public class PathParser
    {
        private string _path;
        PathParser(string path) => _path = path;

        public string GetFileName(string filepath)
        {
            return Path.GetFileName(filepath);
        }

        public string GetFileWitoutExt(string filename)
        {
            var lastposition = filename.LastIndexOf('.');
            return filename.Substring(0, lastposition);
        }
    }
    
}