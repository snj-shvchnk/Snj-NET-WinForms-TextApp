using SnjTextLib.Abstract;
using SnjTextLib.Base;

namespace SnjTextLib.Classes
{
    internal class TextSpliter : TextSpliterBase, ITextSpliter
    {
        internal TextSpliter(IProcessorConfig config) : base(config) { }

        public override IEnumerable<string> Split(string text)
        {
            var splited =  text
                .Split(Config.WordsSeparator, SplitOptions)
                .Select(s => s.Trim())
                .Where(w => !string.IsNullOrEmpty(w))
                .ToArray();

            return splited;
        }
    }
}
