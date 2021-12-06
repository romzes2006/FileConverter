namespace FileConverter.Lib
{
    public abstract class FileConverter
    {
        public Dom.Dom dom;
        
        protected FileConverter() => dom = new Dom.Dom();
        
        public abstract void OnParse(string str);
    }
}