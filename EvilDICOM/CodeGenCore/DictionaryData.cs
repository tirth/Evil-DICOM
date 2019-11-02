namespace EvilDICOM.CodeGenerator
{
    public class DictionaryData
    {
        private string _id;
        public string Id
        {
            get => _id;
            set => _id = value.Replace("\u200B", "");
        }

        public string Name { get; internal set; }

        private string _keyword;
        public string Keyword
        {
            get => _keyword;
            internal set => _keyword = value.Replace("\u200B", "");
        }

        public string VR { get; internal set; }
        public string VM { get; internal set; }
        public string Metadata { get; internal set; }
    }
}
