using SnjTextLib.Abstract;

namespace SnjTextLib.Base
{
    internal abstract class TextSpliterBase : ConfigProvider, ITextSpliter
    {
        protected TextSpliterBase(IProcessorConfig config) : base(config) { }

        public abstract IEnumerable<string> Split(string text);

        internal StringSplitOptions SplitOptions => Config.SplitOptions;

        public bool CheckWord(string word)
        {
            foreach (var c in word)
                if (!CheckChar(c)) return false;

            if (Config.SplitOptions.HasFlag(StringSplitOptions.RemoveEmptyEntries))
                return !string.IsNullOrEmpty(word);

            return true;
        }

        internal bool CheckChar(char c)
        {
            return
                (Config.AllowLetters && char.IsLetter(c))
                ||
                (Config.AllowNumbers && char.IsDigit(c))
                ||
                Config.AcceptableChars.Contains(c);
        }
    }
}
