using SnjTextLib.Abstract;

namespace SnjTextLib.Base
{
    public class ProcessorConfig : IProcessorConfig
    {
        public ProcessorConfig()
        {
            WordsSeparator = ' ';
            AcceptableChars = new[] { '-', '’', '\'' };
            AllowLetters = true;
            AllowNumbers = false;
            SplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
            CompareOptions = StringComparison.InvariantCultureIgnoreCase;
        }

        public char WordsSeparator { get; set; }
        public IEnumerable<char> AcceptableChars { get; set; }
        public bool AllowLetters { get; set; }
        public bool AllowNumbers { get; set; }
        public StringSplitOptions SplitOptions { get; set; }
        public StringComparison CompareOptions { get; set; }
    }
}