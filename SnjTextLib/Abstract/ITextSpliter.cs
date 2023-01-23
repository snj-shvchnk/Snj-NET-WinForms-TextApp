namespace SnjTextLib.Abstract
{
    interface ITextSpliter
    {
        internal bool CheckWord(string word);
        IEnumerable<string> Split(string text);
    }
}
