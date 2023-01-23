namespace SnjTextLib.Abstract
{
    public interface IProcessorConfig
    {
        char WordsSeparator { get; }
        IEnumerable<char> AcceptableChars { get; }
        bool AllowLetters { get; }
        bool AllowNumbers { get; }
        StringSplitOptions SplitOptions { get; }
        StringComparison CompareOptions { get; }
    }
}